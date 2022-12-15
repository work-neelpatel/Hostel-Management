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
    HttpContext context = HttpContext.Current;

    char utype;
    int uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
        }
    }

    //forgot password
    protected void forgot_pass_Click(object sender, EventArgs e)
    {
        if (email.Text != "")
        {
            context.Session["email"] = email.Text;
            string str = "select * from Login where Email_ID='" + email.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["Email"] = email.Text;
                dr.Close();

                try
                {
                    //genrate OTP
                    Random r = new Random();
                    int n;
                    n = r.Next(100000, 999999);
                    Context.Session["OTP"] = n;

                    //send otp on mail
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("ljhostels@gmail.com", "LJHostels@20");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(email.Text);
                    msg.From = new MailAddress("ljhostels@gmail.com", "LJHostels@20");
                    msg.Subject = "Forgot Password!";
                    msg.Body = "Your OTP is " + n;
                    client.Send(msg);

                    Response.Redirect("ForgotPassword");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please try again Later!');window.location ='Login';", true);
                }

            }
            else
            {
                email.Attributes.CssStyle.Add("border-color", "red");
                Empty_Email.Visible = true;
                Empty_Email.Visible = Invailed.Visible = false;
            }
            dr.Close();
        }
        else
        {
            email.Attributes.CssStyle.Add("border-color","red");
            Empty_Email.Visible = true;
            Invailed.Visible = Invailed_Email.Visible = false;
        }
    }

    //login
    protected void login_Click(object sender, EventArgs e)
    {
        /*
        string np, sp;
        Password p = new Password();
        np = password.Text;
        int n = 0;
        while (n < np.Length)
        {
            p.newp = np[n];
            n++;
        }
        sp = p.show;
        */

        SqlCommand cmd = new SqlCommand("select User_Type,User_ID from Login where Email_ID = '" + email.Text + "' and Password = '" + password.Text + "' collate sql_latin1_general_cp1_cs_as", con);//make password case sensitive
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            utype = Convert.ToChar(dr["User_type"]);
            uid = Convert.ToInt16(dr["User_ID"]);
            context.Session["UId"] = uid;
            context.Session["UType"] = utype;
            dr.Close();

            if (utype == 's')
            {
                SqlCommand cmd1 = new SqlCommand("select Stud_Fname, Stud_Lname from Student where User_ID= " + uid + "", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    context.Session["Username"] = dr1["Stud_Fname"].ToString() + " " + dr1["Stud_Lname"].ToString();
                    dr1.Close();
                    con.Close();
                    Response.Redirect("NoticeBox");
                }
            }
            else if (utype == 'a')
            {
                SqlCommand cmd1 = new SqlCommand("select Name from Hostel where ID= " + uid + "", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    context.Session["Username"] = dr1["Name"].ToString();
                    dr1.Close();
                    con.Close();
                    Response.Redirect("HNoticeBox");
                }
            }
        }
        else
        {
            email.Attributes.CssStyle.Add("border-color", "red");
            password.Attributes.CssStyle.Add("border-color", "red");
            Invailed.Visible = true;
            Empty_Email.Visible = Invailed_Email.Visible = false; 
        }
    }



}