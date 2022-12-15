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
    string Student_ID, Type, qry;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Student_ID = Request.QueryString["Student"];
            if (Student_ID == "" || Student_ID == null)
                Response.Redirect("StudentsList");
            else
            {
                Type = Request.QueryString["Type"];
                if (Type == "Req" && Type != "" || Type != null)
                    qry = "SELECT s.* , c.Category_Type, d.Department_Name,d.duration, a.Area_Name, ci.City_Name, cl.Clg_FullName FROM Requested_Stud AS s INNER JOIN Category AS c ON s.Category_ID = c.Category_ID INNER JOIN Department AS d ON s.Department_ID = d.Department_ID INNER JOIN Area AS a ON s.Area_ID = a.Area_ID INNER JOIN City AS ci ON a.City_ID = ci.City_ID INNER JOIN College AS cl ON s.Clg_ID = cl.User_ID where s.Enrollment_No='" + Student_ID +"'";
                else
                    qry = "SELECT s.* , l.Email_ID, c.Category_Type, d.Department_Name,d.duration, a.Area_Name, ci.City_Name, cl.Clg_FullName, sa.Room_No FROM Student AS s INNER JOIN Login AS l ON s.User_ID = l.User_ID INNER JOIN Category AS c ON s.Category_ID = c.Category_ID INNER JOIN Department AS d ON s.Department_ID = d.Department_ID INNER JOIN Area AS a ON s.Area_ID = a.Area_ID INNER JOIN City AS ci ON a.City_ID = ci.City_ID INNER JOIN College AS cl ON s.Clg_ID = cl.User_ID INNER JOIN Seat_Allocation AS sa ON s.Enrollment_no = sa.Enrollment_No where s.Enrollment_No='" + Student_ID+"'";
            }
            studdata();
        }
    }

    public void studdata()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Name.Text = (dr["Stud_Fname"].ToString()) + " " + (dr["Stud_Lname"].ToString());
            Enrolll_no.Text = dr["Enrollment_No"].ToString();
            Gender.Text = dr["Gender"].ToString();
            dob.Text = Convert.ToDateTime(dr["DOB"]).ToString("dd MMMM yyyy");
            Mobile.Text = dr["Mobile"].ToString();
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

            try
            {
                Email.Text = dr["Email_ID"].ToString();
                RoomNo.Text = dr["Room_No"].ToString();
            }
            catch
            {
                Email.Text = dr["Email"].ToString();
                RoomNo.Text = "No Room Allocated";
                Com_Req.Visible = false;
            }
            JoinDate.Text = Convert.ToDateTime(dr["DOJ_Hostel"]).ToString("dd MMMM yyyy");
            dr.Close();

            string str2 = "select (select count(Comp_ID) from Complains where Response is null and Enrollment_No ='"+Student_ID+"') as CP, (select count(Comp_ID) from Complains where Response = 0 and Enrollment_No ='"+Student_ID+"') as CD, (select count(Comp_ID) from Complains where Response = 1 and Enrollment_No ='"+Student_ID+"') as CA, (select count(Req_ID) from Update_data where Result = 1 and Enrollment_No ='"+Student_ID+"') as RA, (select count(Req_ID) from Update_data where Result = 0 and Enrollment_No ='"+Student_ID+"') as RD, (select count(Req_ID) from Update_data where Result is null and Enrollment_No ='"+Student_ID+"') as RP";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.Read())
            {
                CA.InnerText = "Accepted "+ dr2["CA"].ToString();
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
            Response.Redirect("StudentsList");
        }
        
    }
}