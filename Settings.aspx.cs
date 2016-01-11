using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

public partial class Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("redirectionpage.aspx"); /* Help From http://stackoverflow.com/questions/12219246/submit-show-results-delay-3-seconds-and-redirect */
        };

        mainPageUsername.Text = Session["Username"].ToString();
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

    protected void newUsernameSubmit_Click(object sender, EventArgs e)
    {
               
        string sql2 = string.Format("UPDATE users SET Username = '{0}' WHERE ID = {1}", newUserName.Text, Session["ID"]);
        var db2 = new DBCon();
        var reader2 = db2.Execute(sql2);        
        db2.Close();
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }

    protected void newPasswordSubmit_Click(object sender, EventArgs e)
    {
        string sql2 = string.Format("UPDATE users SET users.Password = '{0}' WHERE ID = {1}", newPass.Text, Session["ID"]);
        var db2 = new DBCon();
        
        db2.Execute(sql2);
        db2.Close();
        Session.RemoveAll();  
              
        Response.Redirect("Default.aspx");
    }

    protected void newPass_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("logout.aspx");
    }

    protected void deleteAccButton_Click(object sender, EventArgs e)
    {
        if (password.Text == Session["Password"].ToString())
        {
            var con = new DBCon();
            string sql = string.Format("DELETE FROM Notes WHERE userID={0}", Session["ID"]);
            var reader = con.Execute(sql);
            con.Close();
            string sql2 = string.Format("DELETE FROM Reminders WHERE userID={0}", Session["ID"]);
            reader = con.Execute(sql2);
            con.Close();
            string sql3 = string.Format("DELETE FROM Alarms WHERE userID={0}", Session["ID"]);
            reader = con.Execute(sql3);
            con.Close();
            string sql4 = string.Format("DELETE FROM users WHERE ID={0}", Session["ID"]);
            reader = con.Execute(sql4);
            con.Close();
            Response.Redirect("Default.aspx");
        }
        else
            errorDeleteAcc.Text = "Invalid Password!";
        
    }
}