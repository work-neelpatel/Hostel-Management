using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class StudentMaster : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        try
        {
            string a = "select ID from Hostel where ID = " + Session["UId"] + "";
            SqlCommand cmd = new SqlCommand("select Enrollment_No from Student where User_ID = " + Session["UId"] + "", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Username.InnerText = Session["Username"].ToString();
                Session["Enroll_no"] = dr["Enrollment_No"].ToString();
                dr.Close();
                con.Close();
            }
            else
            {
                dr.Close();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User not found!');window.location ='Login';", true);
            }
        }
        catch {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User not found!');window.location ='Login';", true);
        }
    }
}
