using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;  
using System.Collections;


public partial class _Default : System.Web.UI.Page
{   
    SqlConnection  con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\HACKATHON\Application\Gov.HM.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

    StringBuilder htmlTable = new StringBuilder();
    //dynamic array
    ArrayList UserEmail = new ArrayList();
    int[] UserId, Dept, Cat, Year;
    string[] Gender, Enroll_no;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            check();
            fetchdata();
        }
    }

    void fetchdata(string str = "select s.Gender,s.Assigned_Seats,s.Current_Year,s.Allocated_Seats, d.Department_Name, c.Category_Type from Provided_Seats s inner join Department d on s.Department_ID=d.Department_ID inner join Category c on s.Category_ID=c.Category_ID")
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            htmlTable.Append("<tr'>");
            htmlTable.Append("<td>" + dr["Gender"] + "</td>");
            htmlTable.Append("<td>" + dr["Department_Name"] + "</td>");
            htmlTable.Append("<td>" + dr["Current_Year"] + "</td>");
            htmlTable.Append("<td>" + dr["Category_Type"] + "</td>");
            htmlTable.Append("<td class='text--success'>" + dr["Assigned_Seats"] + "</td>");
            htmlTable.Append("<td class='text--danger'>" + dr["Allocated_Seats"] + "</td>");
            htmlTable.Append("</tr>");
        }
        Merit_tbl.Controls.Add(new Literal { Text = htmlTable.ToString() });
        dr.Close();
        con.Close();
    }

    void check()
    {
        con.Open();
        SqlCommand cmd4 = new SqlCommand("select * from Room_Devide where Room_For='Unassigned'", con);
        SqlDataReader dr2 = cmd4.ExecuteReader();
        if (dr2.Read())
        {
            ua_seats.InnerText = (dr2["Provided_Rooms"]).ToString();
        }
        dr2.Close();
        con.Close();
    }

    protected void AddSeats_Click(object sender, EventArgs e)
    {
        if (AddSeats_txt.Text != "")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Room_Devide where Room_For='Unassigned'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int ua_rooms = Convert.ToInt32(dr["Provided_Rooms"]);
                if (ua_rooms >= Convert.ToInt16(AddSeats_txt.Text))
                {
                    dr.Close();
                    SqlCommand cmd5 = new SqlCommand("select d.Department_ID,c.Category_ID from Department d inner join Category c on c.Category_Type='" + Cat_drpdwn.SelectedValue + "' where d.Department_Name='" + Dept_drpdwn.SelectedValue + "'", con);
                    SqlDataReader dr3 = cmd5.ExecuteReader();
                    if (dr3.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("update Provided_Seats set Assigned_Seats+=" + Convert.ToInt16(AddSeats_txt.Text) + " where Gender='" + Gender_drpdwn2.SelectedValue + "' and Department_ID=" + Convert.ToInt32(dr3["Department_ID"]) + " and Category_ID=" + Convert.ToInt32(dr3["Category_ID"]) + " and  Current_Year=" + DeptYear_drpdwn.SelectedValue + "", con);
                        SqlCommand cmd6 = new SqlCommand("insert into Manual_Seat_Allocation(Gender, Category_ID, Department_ID, Current_Year, AddSeat, Time) values('" + Gender_drpdwn.SelectedValue + "'," + Convert.ToInt32(dr3["Category_ID"]) + "," + Convert.ToInt32(dr3["Department_ID"]) + "," + DeptYear_drpdwn.SelectedValue + ",1,'" + DateTime.Now + "')", con);
                        dr3.Close();
                        cmd2.ExecuteNonQuery();
                        cmd6.ExecuteNonQuery();
                    }
                    dr3.Close();

                    SqlCommand cmd3 = new SqlCommand("update Room_Devide set Provided_Rooms-=" + Convert.ToInt16(AddSeats_txt.Text) + " where Room_For='Unassigned'", con);
                    cmd3.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand("update Room_Devide set Provided_Rooms+=" + Convert.ToInt16(AddSeats_txt.Text) + " where Room_For='Student'", con);
                    cmd4.ExecuteNonQuery();

                    con.Close();
                    check();
                }
                else
                {
                    dr.Close();
                    con.Close();
                    Response.Write("<script>alert('Only " + ua_rooms + " are Unassigned.');</script>");
                }
                find1();
            }
        }
    }
    protected void RemoveSeats_Click(object sender, EventArgs e)
    {
        if (RemoveSeats_txt.Text != "")
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select s.Assigned_Seats,s.Allocated_Seats from Provided_Seats s inner join Department d on s.Department_ID=d.Department_ID inner join Category c on s.Category_ID=c.Category_ID where Gender='" + Gender_drpdwn2.SelectedValue + "' and Department_Name='" + Dept_drpdwn2.SelectedValue + "'and Category_Type='" + Cat_drpdwn2.SelectedValue + "' and  Current_Year='" + DeptYear_drpdwn2.SelectedValue + "' and Allocated_Seats < Assigned_Seats", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int diff = (Convert.ToInt32(dr["Assigned_Seats"]) - Convert.ToInt32(dr["Allocated_Seats"]));
                dr.Close();
                if (diff >= Convert.ToInt32(RemoveSeats_txt.Text))
                {
                    SqlCommand cmd5 = new SqlCommand("select d.Department_ID,c.Category_ID from Department d inner join Category c on c.Category_Type='" + Cat_drpdwn2.SelectedValue + "' where d.Department_Name='" + Dept_drpdwn2.SelectedValue + "'", con);
                    SqlDataReader dr3 = cmd5.ExecuteReader();
                    if (dr3.Read())
                    {
                        SqlCommand cmd2 = new SqlCommand("update Provided_Seats set Assigned_Seats-=" + Convert.ToInt32(RemoveSeats_txt.Text) + " where Gender='" + Gender_drpdwn2.SelectedValue + "' and Department_ID='" + Convert.ToInt32(dr3["Department_ID"]) + "'and Category_ID='" + Convert.ToInt32(dr3["Category_ID"]) + "' and  Current_Year='" + DeptYear_drpdwn2.SelectedValue + "'", con);
                        SqlCommand cmd6 = new SqlCommand("insert into Manual_Seat_Allocation(Gender, Category_ID, Department_ID, Current_Year, RemoveSeat, Time) values('" + Gender_drpdwn2.SelectedValue + "'," + Convert.ToInt32(dr3["Category_ID"]) + "," + Convert.ToInt32(dr3["Department_ID"]) + "," + DeptYear_drpdwn2.SelectedValue + ",1,'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "')", con);
                        dr3.Close();
                        cmd2.ExecuteNonQuery();
                        cmd6.ExecuteNonQuery();
                    }
                    dr3.Close();
                    SqlCommand cmd3 = new SqlCommand("update Room_Devide set Provided_Rooms+=" + Convert.ToInt32(RemoveSeats_txt.Text) + " where Room_For='Unassigned'", con);
                    cmd3.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand("update Room_Devide set Provided_Rooms-=" + Convert.ToInt32(RemoveSeats_txt.Text) + " where Room_For='Student'", con);
                    cmd4.ExecuteNonQuery();
                    con.Close();
                    check();
                }
                else
                {
                    con.Close();
                    Response.Write("<script>alert('Only " + diff + " seats are available.');</script>");
                }
            }
            else
            {
                dr.Close();
                con.Close();
                Response.Write("<script>alert('All Seats are Allocated to the Students, You can not Remove Seats!');</script>");
            }
            find2();
        }
    }

    protected void FindSeats_Click(object sender, EventArgs e)
    {
        find1();
    }
    protected void FindSeats2_Click(object sender, EventArgs e)
    {
        find2();
    }

    public void find1()
    {
        htmlTable.Clear();
        fetchdata("select s.Gender,s.Assigned_Seats,s.Current_Year,s.Allocated_Seats, d.Department_Name, c.Category_Type from Provided_Seats s inner join Department d on s.Department_ID=d.Department_ID inner join Category c on s.Category_ID=c.Category_ID where s.Gender='" + Gender_drpdwn.SelectedValue + "' and d.Department_Name='" + Dept_drpdwn.SelectedValue + "' and c.Category_Type='" + Cat_drpdwn.SelectedValue + "' and  s.Current_Year='" + DeptYear_drpdwn.SelectedValue + "'");    
    }

    public void find2()
    {
        htmlTable.Clear();
        fetchdata("select s.Gender,s.Assigned_Seats,s.Current_Year,s.Allocated_Seats, d.Department_Name, c.Category_Type from Provided_Seats s inner join Department d on s.Department_ID=d.Department_ID inner join Category c on s.Category_ID=c.Category_ID where s.Gender='" + Gender_drpdwn2.SelectedValue + "' and d.Department_Name='" + Dept_drpdwn2.SelectedValue + "' and c.Category_Type='" + Cat_drpdwn2.SelectedValue + "' and  s.Current_Year='" + DeptYear_drpdwn2.SelectedValue + "'");
    }
    
    protected void AllocateSeats_Click(object sender, EventArgs e)
    {        
        int sem = 0, count=0, roomid=0;
        con.Open();

        SqlCommand cmd2 = new SqlCommand("select count(User_ID) 'total' from Requested_Stud where Allocation = 0", con);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        if (dr2.Read())
            count = Convert.ToInt32(dr2["total"]);
        dr2.Close();

        UserId = new int[count];
        Dept = new int[count];
        Cat = new int[count];
        Year = new int[count];
        Gender = new string[count];
        Enroll_no = new string[count];

        SqlCommand cmd = new SqlCommand("SELECT User_ID, Category_ID, Department_ID, gender, College_Curr_Sem,Enrollment_No  from Requested_Stud where Allocation = 0 ORDER BY Percentage DESC", con);
        SqlDataReader dr = cmd.ExecuteReader();
        for (int i = 0; dr.Read(); i++ )
        {
            //find college year
            sem = Convert.ToInt16(dr["College_Curr_Sem"]);
            double curr_year = Convert.ToDouble(sem) / 2;
            Year[i] = (curr_year > Convert.ToInt16(curr_year)) ? (Convert.ToInt16(curr_year ) + 1) : (Convert.ToInt16(curr_year));

            UserId[i] = Convert.ToInt16(dr["User_ID"]);
            Cat[i] = Convert.ToInt16(dr["Category_ID"]);
            Dept[i] = Convert.ToInt16(dr["Department_ID"]);
            Gender[i] = dr["gender"].ToString();
            Enroll_no[i] = dr["Enrollment_no"].ToString(); 
        }
        dr.Close();

        int j=0;

        foreach(int i in UserId)
        {
            SqlCommand cmd4 = new SqlCommand("select Room_No from Seat_Allocation where Enrollment_No is null", con);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
                roomid = Convert.ToInt32(dr4["Room_No"]);
            dr4.Close();

            SqlCommand cmd3 = new SqlCommand("SELECT s.* FROM Provided_Seats AS a INNER JOIN Requested_Stud AS s ON s.User_ID = " + i + " WHERE  (a.Gender = '" + Gender[j] + "') AND (a.Category_ID = " + Cat[j] + ") AND (a.Department_ID = " + Dept[j] + ") AND (a.Current_Year = " + Year[j] + ") AND (a.Assigned_Seats <> 0) AND (a.Allocated_Seats < a.Assigned_Seats)", con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                Response.Write("UserID: " + i + " Room No:" + roomid);
                UserEmail.Add( dr3["Email"].ToString() );
                SqlCommand cmd5 = new SqlCommand("Insert into Student(Enrollment_no, Clg_ID, Stud_fname, Stud_lname, DOB, Mobile, Gender, Father_Name, Father_Mobile, Mother_Name, Mother_Mobile, Address, Area_ID, Category_ID, Department_ID, DOJ_Hostel, DOJ_College, College_curr_Sem, Percentage, Img, Recovery_Email) values('" + dr3["Enrollment_no"].ToString() + "'," + Convert.ToInt32(dr3["Clg_ID"]) + ",'" + dr3["Stud_Fname"].ToString() + "','" + dr3["Stud_lname"].ToString() + "','" + Convert.ToDateTime(dr3["DOB"]).ToString("yyyy/MM/dd") + "','" + dr3["Mobile"].ToString() + "','" + dr3["Gender"].ToString() + "','" + dr3["Father_Name"].ToString() + "' ,'" + dr3["Father_Mobile"].ToString() + "' ,'" + dr3["Mother_Name"].ToString() + "' ,'" + dr3["Mother_Mobile"].ToString() + "' ,'" + dr3["Address"].ToString() + "','" + dr3["Area_ID"].ToString() + "'," + Convert.ToInt32(dr3["Category_ID"]) + "," + Convert.ToInt32(dr3["Department_ID"]) + ",'" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(dr3["DOJ_College"]).ToString("yyyy/MM/dd") + "'," + Convert.ToInt32(dr3["College_Curr_Sem"]) + ",'" + dr3["Percentage"].ToString() + "','" + dr3["Img"].ToString() + "','" + dr3["Recovery_Email"].ToString() + "')", con);
                SqlCommand cmd6 = new SqlCommand("update Seat_Allocation set Enrollment_No= " + Enroll_no[j] + " where Room_No = " + roomid + "", con);
                SqlCommand cmd7 = new SqlCommand("insert into Login(Email_ID, Password, User_ID, User_Type) values('" + dr3["Email"].ToString() + "','" + dr3["Password"].ToString() + "'," + i + ",'s')", con);
                dr3.Close();
                try
                {
                    cmd5.ExecuteNonQuery();
                    cmd7.ExecuteNonQuery();
                    cmd6.ExecuteNonQuery();
                    SqlCommand cmd8 = new SqlCommand("update Requested_Stud set Allocation= 1 where User_ID=" + i + " ", con);
                    cmd8.ExecuteNonQuery();
                    SqlCommand cmd9 = new SqlCommand("update Provided_Seats set Allocated_Seats= Allocated_Seats+1 where Gender = '" + Gender[j] + "' AND Category_ID = " + Cat[j] + " AND Department_ID = " + Dept[j] + " AND Current_Year = " + Year[j] + " ", con);
                    cmd9.ExecuteNonQuery();
                    SqlCommand cmd10 = new SqlCommand("update Room_Devide  set Allocated_Rooms= Allocated_Rooms + 1 where Room_For='Students' ", con);
                    cmd10.ExecuteNonQuery();
                }
                catch {
                    Response.Write("<script>alert('Data insert Problem!');</script>");
                }
            }
            j++;
        }
        con.Close();
        fetchdata();
    }

    protected void GenrateReport_Click(object sender, EventArgs e)
    {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Merit.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Output.Write(Request.Form[hfGridHtml.UniqueID]);
            Response.Flush();
            Response.End();
    }
}