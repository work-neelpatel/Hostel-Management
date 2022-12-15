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

    HttpContext context = HttpContext.Current;
    int day, hour, min;
    string ndate, ntime;

    protected void Page_Load(object sender, EventArgs e)
    {
        load_notification();
    }

    public void load_notification()
    {
        int i;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Notice where Enrollment_No is null order by Notice_Date desc", con);
        SqlDataReader dr = cmd.ExecuteReader();
        for (i = 0; dr.Read(); i++)
        {
            //div1
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes["class"] = "card shadow mb-4 border-left-primary";
            NoticeBox.Controls.Add(div1);

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
            lt1.Attributes["class"] = "m-0 p-0 col-10 font-weight-bold text-primary";
            lt1.Text = "Subject : " + dr["Notice_Subject"].ToString();

            //Time - Lable
            Label lt2 = new Label();
            lt2.Attributes["class"] = "m-0 p-0 fo";
            //lt2.Text = "Subject : " + dr["Notice_Type"].ToString();

            //link Button
            LinkButton title = new LinkButton();
            title.Attributes["class"] = "mb-0 font-weight-bold text-dark text-decoration-none";
            title.Text = dr["Notice_Desc"].ToString();
            if (title.Text.Length > 50)
                title.Text = dr["Notice_Desc"].ToString().Substring(0, 50) + "...";
            ndate = Convert.ToDateTime(dr["Notice_date"]).ToString();
            ntime = Convert.ToDateTime(dr["Notice_date"]).ToString("hh:mm tt");
            title.ID = Convert.ToInt32(dr["Notice_ID"]).ToString();
            title.Click += delegate(object sender, EventArgs e) { Button1_Click(sender, e, title.ID); };
            TimeSpan diff = DateTime.Now - Convert.ToDateTime(ndate);
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
        //context.Session["hnid"] = int.Parse(nid);
        Response.Redirect("NoticeDesc?Notice=" + nid + "");
    }

}