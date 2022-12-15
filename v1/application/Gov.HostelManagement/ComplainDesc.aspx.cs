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
    string nbody, ntype, ndate, ntime, name, Enrollno, Complain_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["Enroll_no"] as string))
        {
            Complain_Id = Request.QueryString["Complain"];
            if (Complain_Id == "" || Complain_Id == null)
                Response.Redirect("ComplainBox");
            Enrollno = Session["Enroll_no"].ToString();
            complain_Data();
        }
        else
            Response.Redirect("Login");
    }

    public void complain_Data()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select c.* from Student s inner join Complains c on c.Enrollment_no=s.Enrollment_no where Comp_Id=" + Complain_Id + " and c.Enrollment_No = '"+Enrollno+"'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            title.Text = "Subject: " + (dr["Comp_Type"]).ToString();
            content.Text = dr["Comp_Desc"].ToString();
            date.InnerText = Convert.ToDateTime(dr["Date"]).ToString("dddd, dd MMMM yyyy");
            tdiff.InnerText = Convert.ToDateTime(dr["Date"]).ToString("hh:mm tt");
            if (dr["Response"].ToString() == "")
            {
                accept.Visible = denied.Visible = false;
            }
            else if (Convert.ToInt16(dr["Response"]) == 1)
            {
                pending.Visible = denied.Visible = false;
            }
            else
            {
                pending.Visible = accept.Visible = false;
            }
        }
        else
        {
            dr.Close();
            con.Close();
            Response.Redirect("ComplainBox");
        }
        dr.Close();
        con.Close();
    }
}