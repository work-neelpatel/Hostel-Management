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
    int uid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch_drp();
        }
    }

    public void fetch_drp()
    {
        //assign values to college dropdown
        SqlCommand cmd = new SqlCommand("select * from College", con);
        con.Open();
        college.DataSource = cmd.ExecuteReader();
        college.DataTextField = "Clg_FullName";
        college.DataValueField = "User_ID";
        college.DataBind();
        con.Close();
    }
    protected void college_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (enroll.Text == "")
        {
            Response.Write("<script>alert('First Enter Your Enrollment No. Above!')</script>");

            if (college.SelectedIndex == 0)
            { college.SelectedIndex = 1; }
            else
            { college.SelectedIndex = 0; }
        }
        else
        {
            con.Open();
            //check if registration is already complated or not
            SqlCommand cm = new SqlCommand("select * from Requested_Stud where Enrollment_no = '" + enroll.Text + "'", con);
            SqlDataReader fdr = cm.ExecuteReader();
            if (fdr.Read())
            {
                if (fdr["Email"].ToString() == "")
                {
                    con.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You already Completed Phase 1 Registration.');window.location ='Registration2?User=" + enroll.Text+ "';", true);
                }
                else
                {
                    con.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You already Completed Registration process.');window.location ='Login';", true);
                }
                fdr.Close();
            }
            else
            {
                /*
                Registration Process Required Data
                Phase - 1
                User_ID, Enroll_no, Clg_ID, Stud_fname, Stud_lname, DOB, Mobile, Gender, Father_Name, Father_Mobile, Mother_Name, Mother_Mobile, Address, Area_ID, Category_ID, Department_ID, DOJHostel, DOJ_College, College_curr_Sem, Percentage, Allocation
                Phase - 2
                Email, Password, Img,Recovery Email
                */
                fdr.Close();
                con.Close();
                con.Open();
                SqlCommand nc = new SqlCommand("select c.*,d.duration,a.city_ID,a.Area_Name,ci.city_Name,d.Department_Name,ca.category_Type from College_Stud as c inner join Department as d on c.Department_ID = d.Department_ID inner join area as a on c.Area_ID = a.Area_ID inner join city as ci on a.City_ID = ci.City_ID inner join category as ca on c.Category_id = ca.Category_id where Enrollment_no = '" + enroll.Text + "' and Clg_ID = '" + Convert.ToInt16(college.SelectedValue) + "' ", con);
                SqlDataReader dr = nc.ExecuteReader();
                if (dr.Read())
                {
                    fname.Text = (dr["First_name"].ToString());
                    lname.Text = (dr["Last_Name"].ToString());
                    gen.SelectedValue = (dr["gender"].ToString()); 
                    Dept_Due.Text = (dr["duration"].ToString());
                    parc.Text = (dr["Get_Percentege"].ToString());
                    dob.Text = Convert.ToDateTime(dr["Stud_DOB"]).ToString("yyyy/MM/dd");
                    add.Text = (dr["Address"].ToString());
                    add_area.Text = dr["Area_Name"].ToString();
                    city.Text = dr["City_Name"].ToString();
                    dept.Text = (dr["Department_Name"].ToString());
                    category.Text = (dr["Category_Type"].ToString());

                    //find college sem
                    curr_clg_sem.Text = ((FindMonths(dr["Stud_DOJ"].ToString()) / 6) + 1).ToString();
                    clg_doj.Text = Convert.ToDateTime(dr["Stud_DOJ"]).ToString("yyyy/MM/dd");

                    //find college year
                    /*
                    double curr_year = Convert.ToDouble((FindMonths(dr["Stud_DOJ"].ToString()) / 6) + 1)/ 2;
                    if (curr_year > Convert.ToInt16(curr_year))
                    {
                        curr_clg_year.Text = (curr_year + 1).ToString().Substring(0,1);
                    }
                     else
                     {
                        curr_clg_year.Text = (curr_year).ToString();                      
                     }
                     */

                    area_id.InnerText = dr["Area_ID"].ToString();
                    clg_id.InnerText = dr["Clg_ID"].ToString();
                    dept_id.InnerText = dr["Department_id"].ToString();
                    cat_id.InnerText = dr["Category_ID"].ToString();

                    dr.Close();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('No Data Found.')</script>");
                }
            }
        }
    }
    protected void next_Click1(object sender, EventArgs e)
    {
        con.Open();
/*        SqlCommand cmd = new SqlCommand("select * from Area where Area_Name ='" + add_area.Text + "'", con);
        SqlDataReader area = cmd.ExecuteReader();
        if (area.Read())
            area_id = (area["Area_ID"].ToString());
        area.Close();
  

        SqlCommand cmd2 = new SqlCommand("select * from Category where Category_Type ='" + category.Text + "'", con);
        SqlDataReader cat = cmd2.ExecuteReader();
        if (cat.Read())
            cat_id = Convert.ToInt16(cat["Category_ID"]);
        cat.Close();

        SqlCommand cmd3 = new SqlCommand("select * from  Department where  Department_Name ='" + dept.Text + "'", con);
        SqlDataReader dep = cmd3.ExecuteReader();
        if (dep.Read())
            dept_id = Convert.ToInt16(dep["Department_ID"]);
        dep.Close();
        */

        SqlCommand cmd4 = new SqlCommand("Insert into Requested_Stud(Enrollment_no, Clg_ID, Stud_fname, Stud_lname, DOB, Mobile, Gender, Father_Name, Father_Mobile, Mother_Name, Mother_Mobile, Address, Area_ID, Category_ID, Department_ID, DOJ_Hostel, DOJ_College, College_curr_Sem, Percentage, Allocation) values('" + enroll.Text + "'," + Convert.ToInt16(clg_id.InnerText) + ",'" + fname.Text + "','" + lname.Text + "','" + dob.Text + "','" + mobile.Text + "','" + gen.SelectedValue + "','" + faname.Text + "' ,'" + famobile.Text + "' ,'" + mname.Text + "' ,'" + mmobile.Text + "' ,'" + add.Text + "','" + area_id.InnerText + "'," + Convert.ToInt16(cat_id.InnerText) + "," + Convert.ToInt16(dept_id.InnerText) + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + clg_doj.Text + "'," + Convert.ToInt16(curr_clg_sem.Text) + ",'" + parc.Text + "',0)", con);
        cmd4.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Registration2?User="+enroll.Text+"");
    }

    public int FindMonths(string DOJ)
    {
        DateTime edt = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
        DateTime sdt = Convert.ToDateTime(DOJ);
        int numMonths = 0;
        while (sdt < edt)
        {
            sdt = sdt.AddMonths(1);
            numMonths++;
        }
        return numMonths;
    }

}