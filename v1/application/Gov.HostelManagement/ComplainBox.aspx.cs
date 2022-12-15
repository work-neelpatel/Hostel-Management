using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    int comp_id, day, hour, min;
    string cdate, ctime, Enrollment_No;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["Enroll_no"] as string))
        {
            Enrollment_No = Session["Enroll_no"].ToString();
            load_notification();
        }
        else
            Response.Redirect("Login");
    }

    public void load_notification()
    {
        int i = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Complains where Enrollment_no = '"+Enrollment_No+"' order by Date desc", con);
        SqlDataReader dr = cmd.ExecuteReader();
        for (i = 0; dr.Read(); i++)
        {
            //div1
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            if (dr["Response"] == DBNull.Value)
            { div1.Attributes["class"] = "card shadow mb-4 border-left-secondary"; }
            else if (Convert.ToInt16(dr["Response"]) == 1)
            { div1.Attributes["class"] = "card shadow mb-4 border-left-success"; }
            else
            { div1.Attributes["class"] = "card shadow mb-4 border-left-danger"; }
            ComplainBox.Controls.Add(div1);

            //div2
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Attributes["class"] = "card-header py-3 form-inline";
            div1.Controls.Add(div2);

            //div3
            HtmlGenericControl div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "card-body";
            div1.Controls.Add(div3);

            //Subject - Lable 
            Label lt1 = new Label();
            lt1.Attributes["class"] = "m-0 p-0 col-10 font-weight-bold text-danger";
            lt1.Text = "Subject : " + dr["Comp_Type"].ToString() + "";

            //Time - Lable
            Label lt2 = new Label();
            lt2.Attributes["class"] = "m-0 p-0 fo pt-1";

            //link Button
            LinkButton title = new LinkButton();
            title.Attributes["class"] = "mb-0 font-weight-bold text-dark text-decoration-none";
            title.Text = dr["Comp_Desc"].ToString();
            if (title.Text.Length > 50)
                title.Text = dr["Comp_Desc"].ToString().Substring(0, 50) + "...";
            cdate = Convert.ToDateTime(dr["Date"]).ToString();
            ctime = Convert.ToDateTime(dr["Date"]).ToString("hh:mm:tt");
            title.ID = Convert.ToInt32(dr["Comp_ID"]).ToString();
            title.Click += delegate(object sender, EventArgs e) { Button1_Click(sender, e, title.ID); };
            TimeSpan diff = DateTime.Now - Convert.ToDateTime(cdate);
            day = (int)diff.TotalDays;
            if (day < 1)
            {
                hour = (int)diff.TotalHours;
                if (hour < 1)
                {
                    min = day = (int)diff.TotalMinutes;
                    lt2.Text += "<span class='time'>" + min + " Min ago" + "</span>";
                }
                else
                    lt2.Text += "<span class='time'>" + hour + " Hour ago" + "</span>";
            }
            else
                lt2.Text += "<span class='time'>" + day + " Day ago" + "</span>";

            div2.Controls.Add(lt1);
            div2.Controls.Add(lt2);
            div3.Controls.Add(title);

        }
        dr.Close();
        con.Close();
        if (i == 0)
            empty_box.Visible = true;
        else
            empty_box.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e, string nid)
    {
        Response.Redirect("ComplainDesc?Complain=" + nid + "");
    }

}