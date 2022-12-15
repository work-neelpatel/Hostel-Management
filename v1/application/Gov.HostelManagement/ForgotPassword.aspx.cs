using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string OTP, Email;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Email = Session["Email"].ToString();
            OTP = Session["OTP"].ToString();

            if (Email == null || OTP == null)
            {
                Response.Redirect("Login");
            }
        }
        catch
        {
            Response.Redirect("Login");
        }
    }

    protected void Change_Password_Click(object sender, EventArgs e)
    {
        if (otp.Text == OTP)
        {
            if (password.Text == cpassword.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Login set Password = '"+password.Text+"' where Email_ID='"+Email+"'", con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login");
            }
            else
            {
                otp.Attributes.CssStyle.Add("border"," 1px solid #d1d3e2");
                password.Attributes.CssStyle.Add("border-color", "red");
                cpassword.Attributes.CssStyle.Add("border-color", "red");
                Invailed_OTP.Visible = false;
                Pass_match.Visible = true;
            }
        }
        else {
            otp.Attributes.CssStyle.Add("border-color", "red");
            password.Attributes.CssStyle.Add("border", " 1px solid #d1d3e2");
            cpassword.Attributes.CssStyle.Add("border", " 1px solid #d1d3e2");
            Invailed_OTP.Visible = true;
            Pass_match.Visible = false;
        }
    }
}