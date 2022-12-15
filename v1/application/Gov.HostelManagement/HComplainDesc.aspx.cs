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
    SqlConnection  con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string nbody, ntype, ndate, ntime, name, Enrollno, Complain_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Complain_Id = Request.QueryString["Complain"];
        if (Complain_Id == "" || Complain_Id == null)
            Response.Redirect("HComplainBox");
        
        complain_Data();
    }

    public void complain_Data()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.Stud_Fname ,s.Stud_Lname ,c.* from Student s inner join Complains c on c.Enrollment_no=s.Enrollment_no where Comp_Id=" + Complain_Id + "", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            sname.Text = "Student: " + (dr["Stud_Fname"].ToString()) + " " + (dr["Stud_Lname"].ToString());
            title.Text = "Subject: " + (dr["Comp_Type"]).ToString();
            content.Text = dr["Comp_Desc"].ToString();
            date.InnerText = Convert.ToDateTime(dr["Date"]).ToString("dddd, dd MMMM yyyy");
            tdiff.InnerText = Convert.ToDateTime(dr["Date"]).ToString("hh:mm tt");
            Enrollno = dr["Enrollment_No"].ToString();
            if (dr["Response"].ToString() == "")
            {
                accept.Visible = denied.Visible = false;
            }
            else if (Convert.ToInt16(dr["Response"]) == 1)
            {
                Acc.Visible = Den.Visible = denied.Visible = false;
            }
            else
            {
                Acc.Visible = Den.Visible = accept.Visible = false;
            }
        }
        else {
            dr.Close();
            con.Close();
            Response.Redirect("HComplainBox");        
        }
        dr.Close();
        con.Close();
    }

    protected void Acc_Click(object sender, EventArgs e)
    {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Complains set Response=1 where Enrollment_No=" + Enrollno + " and Comp_ID=" + Complain_Id + "", con);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Respose Submitted.');</script>");
            con.Close();
            accept.Visible = true;
            complain_Data();
    }
    protected void Den_Click(object sender, EventArgs e)
    {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Complains set Response=0 where Enrollment_No=" + Enrollno + " and Comp_ID=" + Complain_Id + "", con);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Respose Submitted.!');</script>");
            con.Close();
            denied.Visible = true;
            complain_Data();        
    }
}