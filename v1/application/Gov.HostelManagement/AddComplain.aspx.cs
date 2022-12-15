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
    string Enrollment_No;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["Enroll_no"] as string))
        {
            Enrollment_No = Session["Enroll_no"].ToString();
        }
        else
            Response.Redirect("Login");
    }
    protected void send_comp(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Complains(Enrollment_no,Comp_Desc,Comp_Type,Date) values('" + Enrollment_No + "','" + TextBox3.Text + "','" + TextBox1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm tt") + "')", con);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Complain send successfully.');window.location ='ComplainBox';", true);
    }
}