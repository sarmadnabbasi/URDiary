using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

public partial class allNotes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("redirectionpage.aspx"); // Help From http://stackoverflow.com/questions/12219246/submit-show-results-delay-3-seconds-and-redirect 
        };

        mainPageUsername.Text = Session["Username"].ToString();
        
        string sql = string.Format("SELECT * FROM Notes WHERE userID={0}", Session["ID"]);
        var db = new DBCon();
        var reader = db.Execute(sql);
        var sb = new StringBuilder();
        while (reader.Read())
        {
            sb.AppendLine("<tr>");
            sb.AppendLine(string.Format("<td margin_left: 30px ><a href='viewnote.aspx?id={0}'>{1}</a></td>", reader["ID"], reader["noteTitle"]));
            sb.AppendLine("</tr>");
        }
        lbl_table.Text = sb.ToString();
        db.Close();
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

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("logout.aspx");
    }
}