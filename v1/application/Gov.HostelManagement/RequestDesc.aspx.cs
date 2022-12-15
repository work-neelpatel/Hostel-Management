using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string Request_Id, Enrollment_No;

    protected void Page_Load(object sender, EventArgs e)
    {
            if (!string.IsNullOrEmpty(Session["Enroll_no"] as string))
            {
                Request_Id = Request.QueryString["Request"];
                if (Request_Id == "" || Request_Id == null)
                    Response.Redirect("RequestBox");
                Enrollment_No = Session["Enroll_no"].ToString();
                UpdateDetails_div.Visible = ChangeRoom_div.Visible = false;
                Req_Update_Data();
            }
            else
                Response.Redirect("Login");
    }

    public void Req_Update_Data()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.Stud_Fname, s.Stud_Lname, u.* from Update_data u inner join Student s on s.Enrollment_No=u.Enrollment_No where Req_ID =" + Request_Id + " and u.Enrollment_no = '" + Enrollment_No + "' or Req_Enrollment_No = '" + Enrollment_No + "' ", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
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
                Curr_Room_no.Text = dr["Room_ID"].ToString();
                Change_Reason.Text = dr["reason_to_Change"].ToString();
                Req_Room_no.Text = dr["Req_Room_ID"].ToString();

                if (dr["Rholder_res"].ToString() == "")
                {
                    if (dr["Req_Enrollment_No"].ToString() == Enrollment_No)
                        Result.Visible = Result2_lbls.Visible = false;
                    else
                        Result.Visible = Allow.Visible = Deny.Visible = accept.Visible = denied.Visible = false;
                }
                else if (Convert.ToInt16(dr["Rholder_res"]) == 1)
                {
                    Allow.Visible = Deny.Visible = denied.Visible = pending.Visible = false;
                    if (dr["Result"].ToString() == "")
                        accept2.Visible = denied2.Visible = false;
                    else if (Convert.ToInt16(dr["Result"]) == 1)
                        pending2.Visible = denied2.Visible = false;
                    else
                        pending2.Visible = accept2.Visible = false;
                }
                else
                    Result.Visible = Allow.Visible = Deny.Visible = accept.Visible = pending.Visible = false;

            }
            else if (dr["Old_mob"] != DBNull.Value || dr["Old_email"] != DBNull.Value || dr["Old_recovery_email"] != DBNull.Value)
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

                RHResult.Visible = Allow.Visible = Deny.Visible = denied.Visible = pending.Visible = false;
                if (dr["Result"].ToString() == "")
                    accept2.Visible = denied2.Visible = false;
                else if (Convert.ToInt16(dr["Result"]) == 1)
                    pending2.Visible = denied2.Visible = false;
                else
                    pending2.Visible = accept2.Visible = false;
            }
        }
        else
        {
            dr.Close();
            con.Close();
            Response.Redirect("RequestBox");
        }
        dr.Close();
        con.Close();
    }

    protected void Allow_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Update_data set Rholder_res=1 where Req_Id=" + Request_Id + "", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Request Accepted.');</script>");
        con.Close();
        Req_Update_Data();
    }
    protected void Deny_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("update Update_data set Rholder_res=0 where Req_Id=" + Request_Id + "", con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Request Rejected.');</script>");
        con.Close();
        Req_Update_Data();
    }

}