using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class mainpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["Username"]==null)
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

    protected void newNote_TextChanged(object sender, EventArgs e)
    {

    }

    protected void newNoteName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void noteSubmitButton_Click(object sender, EventArgs e)
    {
        DateTime t = DateTime.Now;
        string time = t.ToString();

        if (newNoteName.Text != "")
        {
            
            
            var con = new DBCon();
            string sql = string.Format("INSERT INTO Notes ([noteTitle], [note2], [noteTime], [userID]) VALUES ('{0}', '{1}', '{2}',{3})",  newNoteName.Text, newNote.Text,time, Session["ID"]);
            var reader = con.Execute(sql);
            con.Close();
            Response.Redirect("noteSuccess.aspx");
        }
        else
            errorLabelNotes.Text = "*Enter Title!";
            

    }

    protected void reminderSubmitButton_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (newReminderTime.Text != "")
        {
            DateTime t1 = DateTime.Now;             //http://forums.asp.net/t/1025431.aspx?How+to+compare+Time+in+C+

            DateTime t2 = Convert.ToDateTime(string.Format("{0} {1}", newReminderDate.Text.ToString(), newReminderTime.Text.ToString())); //("{ 0:0000}", value)


            i = DateTime.Compare(t1, t2);
        }

        if (newReminderName.Text != ""&& i < 0 && newReminderTime.Text != "")
            {
                var con = new DBCon();
                string sql = string.Format("INSERT INTO Reminders ( [name], [reminder],[time],[userID] ) VALUES ( '{0}', '{1}', '{2} {3}',{4})", newReminderName.Text, newReminder.Text, newReminderDate.Text, newReminderTime.Text, Session["ID"]);
                var reader = con.Execute(sql);
                con.Close();
               Response.Redirect("reminderSuccess.aspx");
               
            }
            else if (newReminderName.Text == "")
            {
                errorLabelReminder.Text = "*Enter Name!";
            }
            else if (i >= 0)
            {
                errorLabelReminder.Text = "*Enter correct Time!";
            }
             else
                errorLabelReminder.Text = "*Enter correct Time!";

    }

    protected void alarmSubmitButton_Click(object sender, EventArgs e)
    {
       
        if (newAlarmTime.Text != "")
        {
            var con = new DBCon();
            string sql = string.Format("INSERT INTO Alarms ( [time],[userID] ) VALUES ('{0}', {1})", newAlarmTime.Text, Session["ID"]);
            var reader = con.Execute(sql);
            con.Close();
            Response.Redirect("alarmSuccess.aspx");
        }

        
       
    }

    protected void openMain_Click(object sender, EventArgs e)
    {

    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("logout.aspx");
    }
}