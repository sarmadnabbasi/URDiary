using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewReminder : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("redirectionpage.aspx"); // Help From http://stackoverflow.com/questions/12219246/submit-show-results-delay-3-seconds-and-redirect 
            };

            mainPageUsername.Text = Session["Username"].ToString();


            int id = Convert.ToInt32(Request.QueryString["id"]);
            var db = new DBCon();
            var reader = db.Execute(string.Format("SELECT * FROM Reminders WHERE ID={0}", id));
            while (reader.Read())
            {
                reminderName.Text = reader["name"].ToString();
                reminderBody.Text = reader["reminder"].ToString();
                DateTime.Text = reader["time"].ToString();
            }
            
            db.Close();
        }
    }

    protected void reminderName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        DateTime t = System.DateTime.Now;
        string time = t.ToString();
        int i = 0;
       

        
        if(reminderName.Text != "")
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string id1 = id.ToString();           
            var con = new DBCon();                       
            string sql = string.Format("UPDATE Reminders SET name = '{0}' WHERE ID = {1}", reminderName.Text, id);
            var reader = con.Execute(sql);
            con.Close();

            var con2 = new DBCon();
            string sql2 = string.Format("UPDATE Reminders SET reminder = '{0}' WHERE ID = {1}", reminderBody.Text, id);
            var reader2 = con2.Execute(sql2);
            con2.Close();
            
            Response.Redirect("success.aspx");
        }
        else
            errorLabelreminder.Text = "*Enter Title!";
    }
 

    protected void openNotes_Click1(object sender, EventArgs e)
    {
        Response.Redirect("allNotes.aspx");
    }


    protected void openReminders_Click(object sender, EventArgs e)
    {
        Response.Redirect("allReminders.aspx");
    }

    protected void openAlarms_Click(object sender, EventArgs e)
    {
        Response.Redirect("Alarms.aspx");
    }

    protected void openContacts_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }

    protected void openSettings_Click(object sender, EventArgs e)
    {
        Response.Redirect("Settings.aspx");
    }

    protected void openMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("mainpage.aspx");
    }

    protected void reminderBody_TextChanged(object sender, EventArgs e)
    {

    }

    protected void delete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        var con = new DBCon();
        string sql = string.Format("DELETE FROM Reminders WHERE ID={0}", id);
        var reader = con.Execute(sql);
        con.Close();
        Response.Redirect("success.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("logout.aspx");
    }
}