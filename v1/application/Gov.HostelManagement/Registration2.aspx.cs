using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string Enroll_no;

    protected void Page_Load(object sender, EventArgs e)
    {
        Enroll_no = Request.QueryString["User"];
        if (Enroll_no == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to complete Registration Phase 1 first!');window.location ='Registration1';", true);
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Requested_Stud where Enrollment_no = '"+Enroll_no+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                dr.Close();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invailed User!');window.location ='Registration1';", true);
            }
            else
            {
                if (dr["Email"].ToString() != "")
                {
                        dr.Close();
                        con.Close();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You Already Complated Registration.');window.location ='Login';", true);
                }
            }
            dr.Close();
            con.Close();
        }
    }
    protected void next2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Requested_Stud where Email = '" + email.Text + "' or Recovery_Email = '"+remail.Text+"'",con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            dr.Close();
            con.Close();
            Response.Write("<script>alert('Email Already Exists! Choose another Email Address.')</script>");
        }
        else
        {
            dr.Close();
            con.Close();
            if (email.Text != remail.Text)
            {
                if (passwordfield.Text == cpasswordfield.Text)
                {
                    con.Open();
                    string Stu_Img = @"E:\HACKATHON\Application\WebGov.HostelManagement\Registration_Uploads\Student_img\" + Enroll_no + "_Img" + System.IO.Path.GetExtension(StudImg.FileName);
                    if (StudImg.FileBytes.Length <= 1000000)
                    {
                        if ((Stu_Img.EndsWith(".jpg") || Stu_Img.EndsWith(".png") || Stu_Img.EndsWith(".jpeg")))
                        {
                            if (StudImg.HasFile == true)
                            {   //upload file
                                StudImg.SaveAs(Stu_Img);
                                Stu_Img = Stu_Img.Substring(49);
                            }
                        }
                        else
                            Response.Write("<script>alert('Your Photo Must be in Image format!')</script>");
                    }
                    else
                        Response.Write("<script>alert('Your Photo size must be less than 1 MB!')</script>");

                    SqlCommand next = new SqlCommand("update Requested_Stud set Email='" + email.Text.ToLower() + "', Password='" + passwordfield.Text + "', Recovery_Email='" + remail.Text.ToLower() + "', Img='" + Stu_Img + "' where Enrollment_no ='" + Enroll_no + "' ", con);
                    next.ExecuteNonQuery();

                    con.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration successfull.');window.location ='Login';", true);
                }
                else
                    Response.Write("<script>alert('Password did Not matched!')</script>");
            }
            else
                Response.Write("<script>alert('Email and Recovery email Must be unique!')</script>");
        }
    }
}