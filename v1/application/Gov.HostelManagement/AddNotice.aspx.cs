using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection  con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    HttpContext context = HttpContext.Current;

    int hid, i = 0, nid,uid;
    int noticeid;
    string FilePath1, FilePath2, FilePath3, MType = null; 
    protected void Page_Load(object sender, EventArgs e)
    {
        MType = Request.QueryString["MessType"];
        if (MType == "P" )
            SendType.SelectedValue = "Personal";
        else
            SendType.SelectedValue = "All";

        if (SendType.SelectedValue == "All")
            Enroll_div.Visible = StudName_div.Visible = false;
        else
            Enroll_div.Visible = true;
    }

    protected void Send_Click(object sender, EventArgs e)
    {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Notice_ID from Notice order by  Notice_Date desc", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                noticeid = Convert.ToInt16(dr["Notice_ID"]) ;
            }
            dr.Close();
            noticeid += 1;
            if (AttechFile1.FileName != "")
            {
                FilePath1 = Server.MapPath("Uploads") + "\\" + noticeid + "_File1" + System.IO.Path.GetExtension(AttechFile1.FileName);
                if (!(File.Exists(@"E:\HACKATHON\Application\WebGov.HostelManagement\Uploads\" + noticeid + "_File1" + System.IO.Path.GetExtension(AttechFile1.FileName))))
                {
                    try { AttechFile1.SaveAs(FilePath1); }
                    catch { Response.Write("<script>alert('Please resize Atteched File 1!')</script>"); }
                }
                FilePath1 = "~\\Uploads\\" + noticeid + "_File1" + System.IO.Path.GetExtension(AttechFile1.FileName);
            }
            if (AttechFile2.FileName != "")
            {
                FilePath2 = Server.MapPath("Uploads") + "\\" + noticeid + "_File2" + System.IO.Path.GetExtension(AttechFile2.FileName);
                if (!(File.Exists(@"E:\HACKATHON\Application\WebGov.HostelManagement\Uploads\" + noticeid + "_File2" + System.IO.Path.GetExtension(AttechFile2.FileName))))
                {
                    try { AttechFile2.SaveAs(FilePath2); }
                    catch { Response.Write("<script>alert('Please resize Atteched File 2!')</script>"); }
                }
                FilePath2 = "~\\Uploads\\" + noticeid + "_File2" + System.IO.Path.GetExtension(AttechFile2.FileName);
            }
            if (AttechFile3.FileName != "")
            {
                FilePath3 = Server.MapPath("Uploads") + "\\" + noticeid + "_File3" + System.IO.Path.GetExtension(AttechFile3.FileName);
                if (!(File.Exists(@"E:\HACKATHON\Application\WebGov.HostelManagement\Uploads\" + noticeid + "_File3" + System.IO.Path.GetExtension(AttechFile3.FileName))))
                {
                    try { AttechFile3.SaveAs(FilePath3); }
                    catch { Response.Write("<script>alert('Please resize Atteched File 3!')</script>"); }
                }
                FilePath3 = "~\\Uploads\\" + noticeid + "_File3" + System.IO.Path.GetExtension(AttechFile3.FileName);
            }

            if (SendType.SelectedValue == "All")
            {
                SqlCommand cmd2 = new SqlCommand("insert into Notice(Notice_Subject, Notice_Desc, Notice_Date, Enrollment_no, Notice_Attechment1, Notice_Attechment2, Notice_Attechment3) values('" + Subject.Text + "', '" + Description.Text + "','" + DateTime.Now + "', null , '" + FilePath1 + "', '" + FilePath2 + "', '" + FilePath3 + "')", con);
                cmd2.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Notice send successfully.');window.location ='HNoticeBox';", true);
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("insert into Notice(Notice_Subject, Notice_Desc, Notice_Date, Enrollment_no, Notice_Attechment1, Notice_Attechment2, Notice_Attechment3) values('" + Subject.Text + "', '" + Description.Text + "','" + DateTime.Now + "', '"+Enrollno.Text+"', '" + FilePath1 + "', '" + FilePath2 + "', '" + FilePath3 + "')", con);
                cmd2.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Notice send successfully.');window.location ='HNoticeBox';", true);
            }
    }

    protected void SendType_TextChanged(object sender, EventArgs e)
    {
        if (SendType.SelectedValue == "All")
            Enroll_div.Visible = StudName_div.Visible = false;
        else
            Enroll_div.Visible = true;
    }

    protected void Enrollno_TextChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select Stud_Fname, Stud_Lname from Student where Enrollment_no = '" + Enrollno.Text + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            StudName_div.Visible = true;
            StudName.Text = dr["Stud_Fname"].ToString() + " " + dr["Stud_Lname"].ToString();
            Enrollno.Attributes.CssStyle.Add("color", "gray");
        }
        else
        {
            Enrollno.Attributes.CssStyle.Add("color", "red");
            StudName_div.Visible = false;
            Response.Write("<script>alert('Invailed Enrollment No.');</script>");
        }
        dr.Close();
        con.Close();
    }

}