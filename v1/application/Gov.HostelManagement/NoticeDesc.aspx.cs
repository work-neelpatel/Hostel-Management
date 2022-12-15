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
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    string NoticeID;

    protected void Page_Load(object sender, EventArgs e)
    {
        NoticeID = Request.QueryString["Notice"];
        if (NoticeID == "" || NoticeID == null)
            Response.Redirect("NoticeBox");
        fetch_desc();
    }

    public void fetch_desc()
    {
        con.Open();
        string[] path = new string[3];
        SqlCommand cmd = new SqlCommand("select * from Notice where Notice_ID = '" + NoticeID + "' and Enrollment_no is null", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            msg_body.Text = dr["Notice_Desc"].ToString().Replace("$", @"\");
            title.Text = "Subject: " + dr["Notice_Subject"].ToString();
            date.InnerText = Convert.ToDateTime(dr["Notice_date"]).ToString("dddd, dd MMMM yyyy");
            tdiff.InnerText = Convert.ToDateTime(dr["Notice_date"]).ToString("hh:mm tt");
            path[0] = (dr["Notice_Attechment1"]).ToString(); ;
            path[1] = (dr["Notice_Attechment2"]).ToString();
            path[2] = (dr["Notice_Attechment3"]).ToString();
            if (path[0] != "" || path[1] != "" || path[2] != "")
                ftitle.Text = "Atteched File(s)";

            for (int i = 0; i < (path.Length); i++)
            {
                if (path[i] != "")
                {
                    LinkButton l1 = new LinkButton();
                    l1.Attributes["class"] = "list-group-item border-0";
                    l1.Text = path[i].Substring(10);
                    l1.Click += delegate(object sender, EventArgs e) { download_file(sender, e, "~/Uploads/" + l1.Text); }; ;
                    attech_files.Controls.Add(l1);
                }
            }
            path[0] = path[1] = path[2] = "";
        }
        else
        {
            dr.Close();
            con.Close();
            Response.Redirect("NoticeBox");
        }
        dr.Close();
    }

    protected void download_file(object sender, EventArgs e, string path)
    {
        try
        {
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            Response.WriteFile(path);
            Response.End();
        }
        catch { }
    }
}