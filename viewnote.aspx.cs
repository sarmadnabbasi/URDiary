using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class viewnote : System.Web.UI.Page
{
    public int ID;
    public string nn;

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
            var reader = db.Execute(string.Format("SELECT * FROM Notes WHERE ID={0}", id));
            while (reader.Read())
            {
                noteName.Text = reader["noteTitle"].ToString();
                nn = reader["noteTitle"].ToString();
                ID = id;
                noteBody.Text = reader["note2"].ToString();
                DateTime.Text = reader["noteTime"].ToString();
            }
            
            db.Close();
        }
    }

    protected void noteBody_TextChanged(object sender, EventArgs e)
    {

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

    protected void submit_Click(object sender, EventArgs e)
    {
        DateTime t = System.DateTime.Now;
        string time = t.ToString();

        if (noteName.Text != "")
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var con = new DBCon();            
            string sql = string.Format("UPDATE Notes SET noteTitle = '{0}' WHERE ID = {1}", noteName.Text, id);
            var reader = con.Execute(sql);
            con.Close();
         
            var con2 = new DBCon();
            string sql2 = string.Format("UPDATE Notes SET note2 = '{0}' WHERE ID = {1}", noteBody.Text, id);            
           var reader2= con2.Execute(sql2);
            con2.Close();
                        

            var con3 = new DBCon();
            string sql3 = string.Format("UPDATE Notes SET noteTime = '{0}' WHERE ID = {1}", time, id);
            var reader3 = con3.Execute(sql3);
            con3.Close();
            errorLabelNotes.Text = sql2;

            Response.Redirect("Success.aspx");
        }
        else
            errorLabelNotes.Text = "*Enter Title!";

    }

    protected void delete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        var con = new DBCon();

        string sql = string.Format("DELETE FROM Notes WHERE ID={0}", id );
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