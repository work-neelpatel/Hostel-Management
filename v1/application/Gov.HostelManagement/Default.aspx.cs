using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");    
    protected void Page_Load(object sender, EventArgs e)
    {
/*        for (int i = 1; i <= 120; i++)
        {
            con.Open();
            string sql = "insert into Seat_Allocation (room_no) values (" + i + ")";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteReader();
            con.Close();
        }*/
    }
}