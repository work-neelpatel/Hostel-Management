using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    StringBuilder htmlTable = new StringBuilder();
    string q1, q2, q3, q4, n1, n2, n3, n4, qry;
    int i, s1, s2, j = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Gender_drpdwn.SelectedValue = Cat_drpdwn.SelectedValue = Dept_drpdwn.SelectedValue = DeptYear_drpdwn.SelectedValue = "";
            FindSeats_Click(sender, e);
        }
    }
    void fetchdata(string qry)
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        con.Open();
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataReader dr = cmd.ExecuteReader();

        int sem, i = 0;
        double curr_year;
        for (i = 0; dr.Read(); i++)
        {
            htmlTable.Append("<tr>");
            htmlTable.Append("<td><a href='HStudentProfile?Student=" + dr["Enrollment_No"] + "&Type=Req'  class='text-decoration-none text-secondary'>" + dr["Stud_Fname"] + " " + dr["Stud_Lname"] + "</a></td>");
            htmlTable.Append("<td>" + dr["Enrollment_No"] + "</td>");
            htmlTable.Append("<td>" + dr["Percentage"] + "</td>");
            htmlTable.Append("<td class='text-capitalize'>" + dr["Gender"] + "</td>");
            htmlTable.Append("<td>" + dr["Department_Name"] + "</td>");
            sem = Convert.ToInt16(dr["College_Curr_Sem"]);
            curr_year = Convert.ToDouble(sem) / 2;
            sem = (curr_year > Convert.ToInt16(curr_year)) ? (Convert.ToInt16(curr_year) + 1) : (Convert.ToInt16(curr_year));
            htmlTable.Append("<td>" + sem + "</td>");
            htmlTable.Append("<td>" + dr["Category_Type"] + "</td>");
            htmlTable.Append("</tr>");
        }
        if (i <= 0)
            data.Text = "none";
        dr.Close();
        Student_tbl.Controls.Add(new Literal { Text = htmlTable.ToString() });

        htmlTable.Clear();

        SqlCommand cmd2 = new SqlCommand(qry, con);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        while (dr2.Read())
        {
            htmlTable.Append("<tr>");
            htmlTable.Append("<td>" + dr2["Stud_Fname"] + " " + dr2["Stud_Lname"] + "</td>");
            htmlTable.Append("<td>" + dr2["Enrollment_No"] + "</td>");
            htmlTable.Append("<td>" + dr2["Percentage"] + "</td>");
            htmlTable.Append("<td class='text-capitalize'>" + dr2["Gender"] + "</td>");
            htmlTable.Append("<td>" + dr2["Department_Name"] + "</td>");
            sem = Convert.ToInt16(dr2["College_Curr_Sem"]);
            curr_year = Convert.ToDouble(sem) / 2;
            sem = (curr_year > Convert.ToInt16(curr_year)) ? (Convert.ToInt16(curr_year) + 1) : (Convert.ToInt16(curr_year));
            htmlTable.Append("<td>" + sem + "</td>");
            htmlTable.Append("<td>" + dr2["Category_Type"] + "</td>");
            htmlTable.Append("</tr>");
        }
        dr2.Close();
        Student_tbl2.Controls.Add(new Literal { Text = htmlTable.ToString() });
        con.Close();
    }
    protected void GenrateReport_Click(object sender, EventArgs e)
    {
        if (data.Text != "none")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + tblname.Text + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Output.Write(Request.Form[hfGridHtml.UniqueID]);
            Response.Flush();
            Response.End();
        }
    }
    protected void FindSeats_Click(object sender, EventArgs e)
    {
        if (Gender_drpdwn.SelectedValue != "")
        {
            q1 = "s.Gender='" + Gender_drpdwn.SelectedValue + "' ";
            n1 = "_Gen-" + Gender_drpdwn.SelectedValue + "";
        }

        if (Dept_drpdwn.SelectedValue != "")
        {
            q2 = "and d.Department_Name='" + Dept_drpdwn.SelectedValue + "' ";
            n2 = "_Dept-" + Dept_drpdwn.SelectedValue + "";
        }

        if (DeptYear_drpdwn.SelectedValue != "")
        {
            i = Convert.ToInt16(DeptYear_drpdwn.SelectedValue);
            //find semester from year
            for (j = 0; j < 4; j++)
                if ((j + 1) == i)
                    break;
            s1 = i + j;
            s2 = s1 + 1;
            q3 = "and s.College_curr_Sem=" + s1 + " or s.College_curr_Sem=" + s2 + " ";
            n3 = "_Year-" + DeptYear_drpdwn.SelectedValue + "";
        }

        if (Cat_drpdwn.SelectedValue != "")
        {
            q4 = "and c.Category_Type = '" + Cat_drpdwn.SelectedValue + "' ";
            n4 = "_Cat-" + Cat_drpdwn.SelectedValue + "";
        }

        qry = "select s.Stud_Fname,s.Stud_Lname,s.Enrollment_No,s.Percentage,s.Gender, d.Department_Name, c.Category_Type,s.College_Curr_Sem from Requested_Stud s inner join Department d on s.Department_id=d.Department_ID inner join Category c on s.Category_ID=c.Category_ID and s.Allocation = 0";
        qry += " where " + q1 + "" + q2 + "" + q3 + "" + q4 + " ";
        tblname.Text = "RequestedSeats " + n1 + "" + n2 + "" + n3 + "" + n4 + "";
        qry = qry.Replace("where and", "where");
        qry = qry.Replace("where  ", "");
        tblname.Text = tblname.Text.Replace(" _", " ");
        fetchdata(qry);
    }
}