using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection  con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string Request_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Request_Id = Request.QueryString["Request"];
        if (Request_Id == "" || Request_Id == null)
            Response.Redirect("HRequestBox");
        UpdateDetails_div.Visible = ChangeRoom_div.Visible = false;
        Req_Update_Data();
    }

    public void Req_Update_Data()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select u.*,s.Stud_Fname,s.Stud_Lname from Update_Data u inner join Student s on s.Enrollment_No=u.Enrollment_No where Req_Id = "+Request_Id+"", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((dr["Room_Id"].ToString() != "" && dr["Rholder_res"].ToString() == "1") || dr["Room_Id"].ToString() == "")
            {
                sname.Text = "Student: " + (dr["Stud_Fname"].ToString()) + " " + (dr["Stud_Lname"].ToString());
                if (dr["Room_ID"] != DBNull.Value)
                    title.Text = "Subject: Room Change";
                if (dr["Old_mob"] != DBNull.Value || dr["Old_email"] != DBNull.Value || dr["Old_recovery_email"] != DBNull.Value)
                    title.Text = "Subject: Update Details";
                date.InnerText = Convert.ToDateTime(dr["Date"]).ToString("dddd, dd MMMM yyyy");
                tdiff.InnerText = Convert.ToDateTime(dr["Date"]).ToString("hh:mm tt");

                if (dr["Room_ID"] != DBNull.Value)
                {
                    ChangeRoom_div.Visible = true;
                    Rholder.Text = dr["Enrollment_No"].ToString();
                    Curr_Room_no.Text = dr["Room_ID"].ToString();
                    Change_Reason.Text = dr["reason_to_Change"].ToString().Replace("~","'");
                    Req_Room_no.Text = dr["Req_Room_ID"].ToString();
                    RRholder.Text = dr["Req_Enrollment_No"].ToString();
                }
                if (dr["Old_mob"] != DBNull.Value || dr["Old_email"] != DBNull.Value || dr["Old_recovery_email"] != DBNull.Value)
                {
                    UpdateDetails_div.Visible = true;
                    if (dr["Old_mob"] != DBNull.Value)
                    {
                        Old_Mobile.Text = dr["Old_mob"].ToString();
                        New_Mobile.Text = dr["New_mob"].ToString();
                    }
                    else
                        ChangeMobile_div.Visible = false;

                    if (dr["Old_email"] != DBNull.Value)
                    {
                        Old_Email.Text = dr["Old_email"].ToString();
                        New_Email.Text = dr["New_email"].ToString();
                    }
                    else
                        ChangeEmail_div.Visible = false;

                    if (dr["Old_recovery_email"] != DBNull.Value)
                    {
                        Old_REmail.Text = dr["Old_recovery_email"].ToString();
                        New_REmail.Text = dr["New_recovery_email"].ToString();
                    }
                    else
                        ChangeREmail_div.Visible = false;
                }
                if (dr["Result"].ToString() == "")
                {
                    accept.Visible = denied.Visible = false;
                }
                else if (Convert.ToInt16(dr["Result"]) == 1)
                {
                    Allow.Visible = Deny.Visible = denied.Visible = false;
                }
                else
                {
                    Allow.Visible = Deny.Visible = accept.Visible = false;
                }
            }
            else
            {
                dr.Close();
                con.Close();
                Response.Redirect("HRequestBox");
            }
        }
        else
        {
            dr.Close();
            con.Close();
            Response.Redirect("HRequestBox");        
        }
        dr.Close();
        con.Close();
    }

    protected void Allow_Click(object sender, EventArgs e)
    {
        string p1, p2;
        p1 = p2 = "";
        con.Open();
        if (ChangeRoom_div.Visible == true)
        {
            SqlCommand cmd2 = new SqlCommand("update Seat_Allocation Set Enrollment_No='" + Rholder.Text + "' where Room_No=" + Req_Room_no.Text + "", con);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("update Seat_Allocation Set Enrollment_No='" + RRholder.Text + "' where Room_No=" + Curr_Room_no.Text + "", con);
            cmd3.ExecuteNonQuery();
        }
        else if (UpdateDetails_div.Visible == true)
        {
            if (ChangeMobile_div.Visible == true)
                p1 = "Mobile = '" + New_Mobile.Text + "'";
            if (ChangeREmail_div.Visible == true)
                p2= ",Recovery_Email = '"+New_REmail.Text+"'";
            if (ChangeEmail_div.Visible == true)
            {
                SqlCommand cmd = new SqlCommand("update Login set Email_ID = '"+New_Email.Text+"' where Email_ID = '"+Old_Email.Text+"'",con);
                cmd.ExecuteNonQuery();
            }
            if (p1 != "" || p2 != "")
            {
                SqlCommand cmd2 = new SqlCommand("update Student set " + p1 + "" + p2 + " where Enrollment_No='" + Rholder.Text + "'".Replace(" ,", ""), con);
                cmd2.ExecuteNonQuery();
            }
        }
        SqlCommand cmd4 = new SqlCommand("update Update_data set Result=1 where Enrollment_No=" + Rholder.Text + " and Req_Id=" + Request_Id + "", con);
        cmd4.ExecuteNonQuery();
        Response.Write("<script>alert('Request Accepted.');</script>");
        con.Close();
        Req_Update_Data();
    }
    protected void Deny_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Update_data set Result=0 where Enrollment_No=" + Rholder.Text + " and Req_Id=" + Request_Id + "", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Request Rejected.');</script>");
        con.Close();
        Req_Update_Data();
    }
}