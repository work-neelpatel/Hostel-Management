using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection  con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    StringBuilder htmlTable = new StringBuilder();
    int y, d, c, gender, tv = 0, t = 0, z = 0, a, b = 0, flag = 1;
    string cmd;
    int tot = 0;
    short[] x = new short[160];
    string[] g = new string[2];
    string[] ary = { "ENG.", "MEDICAL", "COMMERCE", "ARTS", "MENEGMENT" };


    protected void Page_Load(object sender, EventArgs e)
    {
        g[0] = "male"; g[1] = "female";
        con.Open();
        for (y = 1; y <= 5; y++)
        {
            htmlTable.Append("<tr><td rowspan=4 align='center'>" + ary[y - 1] + "</td>");
            for (d = 1; d <= 4; d++)
            {
                htmlTable.Append("<td>" + d + "</td>");
                for (gender = 0; gender < 2; gender++)
                {
                    for (c = 1; c <= 4; c++)
                    {
                        SqlCommand cmd2 = new SqlCommand("Select Assigned_Seats from Provided_Seats where Gender = '" + g[gender] + "' and  Category_ID =" + c + " and Department_ID = " + y + " and Current_Year = " + d + "", con);
                        SqlDataReader dr = cmd2.ExecuteReader();
                        if (dr.Read())
                        {
                            tot = tot + Convert.ToInt16(dr["Assigned_Seats"]);
                            htmlTable.Append("<td>" + dr["Assigned_Seats"] + "</td>");
                        }
                        dr.Close();
                    }
                    htmlTable.Append("<td>" + tot + "</td>");
                    tot = 0;
                }
                htmlTable.Append("</tr>");
            }
        }
        show_merit.Controls.Add(new Literal { Text = htmlTable.ToString() });
    }

}