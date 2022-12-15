using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string Enrollment_No;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["Enroll_no"] as string))
        {
            Enrollment_No = Session["Enroll_no"].ToString();
            studdata();
        }
        else
            Response.Redirect("Login");
    }

    public void studdata()
    {
        con.Open();
        string str = "SELECT s.* , l.Email_ID, c.Category_Type, d.Department_Name,d.duration, a.Area_Name, ci.City_Name, cl.Clg_FullName, sa.Room_No FROM Student AS s INNER JOIN Login AS l ON s.User_ID = l.User_ID INNER JOIN Category AS c ON s.Category_ID = c.Category_ID INNER JOIN Department AS d ON s.Department_ID = d.Department_ID INNER JOIN Area AS a ON s.Area_ID = a.Area_ID INNER JOIN City AS ci ON a.City_ID = ci.City_ID INNER JOIN College AS cl ON s.Clg_ID = cl.User_ID INNER JOIN Seat_Allocation AS sa ON s.Enrollment_no = sa.Enrollment_No where s.Enrollment_No='" + Enrollment_No + "'";
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Name.Text = (dr["Stud_Fname"].ToString()) + " " + (dr["Stud_Lname"].ToString());
            Enrolll_no.Text = dr["Enrollment_No"].ToString();
            Gender.Text = dr["Gender"].ToString();
            dob.Text = Convert.ToDateTime(dr["DOB"]).ToString("dd MMMM yyyy");
            Mobile.Text = dr["Mobile"].ToString();
            Email.Text = dr["Email_ID"].ToString();
            REmail.Text = dr["Recovery_Email"].ToString();
            Address.Text = dr["Address"].ToString();
            Percentage.Text = dr["Percentage"].ToString();
            StudImg.ImageUrl = dr["img"].ToString();
            FName.Text = dr["Father_Name"].ToString();
            FMobile.Text = dr["Father_Mobile"].ToString();
            MName.Text = dr["Mother_Name"].ToString();
            MMobile.Text = dr["Mother_Mobile"].ToString();

            Area.Text = dr["Area_Name"].ToString();
            City.Text = dr["City_Name"].ToString();

            ClgName.Text = dr["Clg_FullName"].ToString();
            //find college year
            double curr_year = Convert.ToDouble(Convert.ToInt16(dr["College_Curr_Sem"])) / 2;
            ClgCurr_Year.Text = (curr_year > Convert.ToInt16(curr_year)) ? (Convert.ToInt16(curr_year) + 1).ToString() : (Convert.ToInt16(curr_year)).ToString();

            Dept.Text = dr["Department_Name"].ToString();
            Depr_Year.Text = dr["Duration"].ToString();
            Category.Text = dr["Category_Type"].ToString();

            RoomNo.Text = dr["Room_No"].ToString();
            JoinDate.Text = Convert.ToDateTime(dr["DOJ_Hostel"]).ToString("dd MMMM yyyy");
            dr.Read();
            dr.Close();

            string str2 = "select (select count(Comp_ID) from Complains where Response is null and Enrollment_No ='" + Enrollment_No + "') as CP, (select count(Comp_ID) from Complains where Response = 0 and Enrollment_No ='" + Enrollment_No + "') as CD, (select count(Comp_ID) from Complains where Response = 1 and Enrollment_No ='" + Enrollment_No + "') as CA, (select count(Req_ID) from Update_data where Result = 1 and Enrollment_No ='" + Enrollment_No + "') as RA, (select count(Req_ID) from Update_data where Result = 0 and Enrollment_No ='" + Enrollment_No + "') as RD, (select count(Req_ID) from Update_data where Result is null and Enrollment_No ='" + Enrollment_No + "') as RP";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.Read())
            {
                CA.InnerText = "Accepted " + dr2["CA"].ToString();
                CD.InnerText = "Denied " + dr2["CD"].ToString();
                CP.InnerText = "Pending " + dr2["CP"].ToString();
                RA.InnerText = "Accepted " + dr2["RA"].ToString();
                RD.InnerText = "Denied " + dr2["RD"].ToString();
                RP.InnerText = "Pending " + dr2["RP"].ToString();
                dr2.Close();
            }
            else
            {
                dr2.Close();
                CA.InnerText = CD.InnerText = CP.InnerText = RA.InnerText = RD.InnerText = RP.InnerText = "0";
            }

        }
        else
        {
            dr.Close();
            Response.Redirect("NoticeBox");
        }
        con.Close();
    }

    protected void SendRequest_btn_Click(object sender, EventArgs e)
    {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Update_Data (Enrollment_No, Req_Enrollment_No, Room_ID, Req_Room_ID, reason_to_change, Date) values('" + Enrollment_No + "', '" + Enroll_no_lbl.Text + "', " + RoomNo.Text + ", " + RRno.Text + ", '" + Reason.Text.Replace(@"'", "~") + "', '" + DateTime.Now + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Request send successfully.');</script>");
            ChangeRoom.Visible = false;
            ChangeRoom_btn.Visible = true;
    }

    protected void ChangeRoom_btn_Click(object sender, EventArgs e)
    {
        ChangeRoom.Visible = true;
        ChangeRoom_btn.Visible = false;
    }

    protected void RRno_TextChanged(object sender, EventArgs e)
    {
        if (RRno.Text != RoomNo.Text)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select r.Enrollment_No, s.Stud_Fname, s.Stud_Lname from Seat_Allocation as r inner join Student as s on r.Enrollment_No = s.Enrollment_No where Room_No = '" + RRno.Text + "' and r.Enrollment_No is not null", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                RHname.Visible = true;
                Enroll_no_lbl.Text = dr["Enrollment_No"].ToString();
                RHname_lbl.Text = dr["Stud_Fname"].ToString() + " " + dr["Stud_Lname"].ToString();
                RRno.Attributes.CssStyle.Add("color", "gray");
            }
            else
            {
                RRno.Attributes.CssStyle.Add("color", "red");
                RHname.Visible = false;
                Response.Write("<script>alert('Invailed Room No.');</script>");
                RRno.Text = "";
            }
            dr.Close();
            con.Close();
        }
        else
        {
            RRno.Attributes.CssStyle.Add("color", "red");
            Response.Write("<script>alert('That is your Room.');</script>");
            RHname.Visible = false;
            RHname_lbl.Text = "";
            RRno.Text = "";
        }
    }
    protected void Change_details_btn_Click(object sender, EventArgs e)
    {
        REmail_txtbox.Visible = Email_txtbox.Visible = Mobile_txtbox.Visible = true;
        Change_details_btn.Visible = false;
        SendRequest_btn2.Visible = true;
    }
    protected void SendRequest_btn2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT s.User_ID FROM Student AS s INNER JOIN Login AS l ON s.User_ID = l.User_ID WHERE  (l.Email_ID = '" + Email_txtbox.Text + "') OR (l.Email_ID = '" + REmail_txtbox.Text + "') OR (s.Recovery_Email = '" + Email_txtbox.Text + "') OR(s.Recovery_Email = '" + REmail_txtbox.Text + "') OR (s.Mobile = '" + Mobile_txtbox.Text + "')", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (!dr.Read())
        {
            dr.Close();
            string p1, p2, p3;
            int c1, c2;
            c1 = Email_txtbox.Text.IndexOf(".");
            c2 = REmail_txtbox.Text.IndexOf(".");
            p1 = p2 = p3 = "null, null";
            if (Mobile_txtbox.Text != Mobile.Text && Mobile_txtbox.Text != "")
                p1 = "'" + Mobile.Text + "','" + Mobile_txtbox.Text + "'";
            if (Email_txtbox.Text != Email.Text && Email_txtbox.Text != "")
                p2 = "'" + Email.Text + "','" + Email_txtbox.Text.ToLower() + "'";
            if (REmail_txtbox.Text != REmail.Text && REmail_txtbox.Text != "")
                p3 = "'" + REmail.Text + "','" + REmail_txtbox.Text.ToLower() + "'";

            if (Mobile_txtbox.Text.Length == 10 || Mobile_txtbox.Text=="")
            {
                if (c1 == -1 && Email_txtbox.Text!="")
                {
                    Response.Write("<script>alert('Please Include . in Email ');</script>");
                    Email_txtbox.Attributes.CssStyle.Add("color", "gray");
                }
                else if (c2 == -1 && REmail_txtbox.Text!="")
                {
                    Response.Write("<script>alert('Please Include . in Recovery Email ');</script>");
                    REmail_txtbox.Attributes.CssStyle.Add("color", "gray");
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into Update_Data (Enrollment_No, Old_mob, New_mob, Old_email, New_email, old_recovery_email, New_recovery_email, Date)values('" + Enrolll_no.Text + "'," + p1 + "," + p2 + "," + p3 + ",'" + DateTime.Now + "')", con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    REmail_txtbox.Text = Email_txtbox.Text = Mobile_txtbox.Text = "";
                    REmail_txtbox.Visible = Email_txtbox.Visible = Mobile_txtbox.Visible = false;
                    Change_details_btn.Visible = true;
                    SendRequest_btn2.Visible = false;
                    Mobile_txtbox.Attributes.CssStyle.Add("color", "gray");
                    Email_txtbox.Attributes.CssStyle.Add("color", "gray");
                    REmail_txtbox.Attributes.CssStyle.Add("color", "gray");
                    Response.Write("<script>alert('Request send successfully.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Mobile number length must be 10 digits!');</script>");
                Mobile_txtbox.Attributes.CssStyle.Add("color", "red");
            }
        }
        else
        {
            dr.Close();
            Response.Write("<script>alert('This data already exists!!');</script>");
        } con.Close();
    }
}