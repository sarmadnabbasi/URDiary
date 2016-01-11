using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Text;


public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Username"] = null;
        Session["ID"] = null;
       

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var con = new DBCon();
        string sql = string.Format("SELECT ID, Username, Password FROM users WHERE Username = '{0}' AND Password = '{1}'", loginId.Text, loginPass.Text);
        var reader = con.Execute(sql);
        while (reader.Read())
        {
            Session["ID"] = reader["ID"];
            Session["Password"] = reader["Password"];
        }
        if (reader.HasRows)
        {
            checking.Text = "Success!";           
            Session["Username"] = loginId.Text;
            
            con.Close();
            con.Close();
            Response.Redirect("mainpage.aspx");
            
        }
        else
        {
            checking.Text = "Invalid Username or Password!";
            con.Close();
            con.Close();
        }
        

    }

    

    protected void newPass_TextChanged(object sender, EventArgs e)
    {

    }

   

    protected void signUp_Click(object sender, EventArgs e)
    {
        if ((newPass.Text.Length != 0) && (newId.Text.Length != 0))
        {

           
            string sql2 = string.Format("SELECT Username FROM users WHERE Username = '{0}'", newId.Text);
            var con = new DBCon();
            var reader = con.Execute(sql2);
            RegexUtilities util = new RegexUtilities();
            bool check= util.IsValidEmail(newEmailid.Text);
            if (!reader.HasRows && check)
            {
                con.Close();
                
                string sql = string.Format("INSERT INTO users ([Username], [Password], [email]) VALUES ('{0}', '{1}', '{2}')", newId.Text, newPass.Text,newEmailid.Text);
                con.Execute(sql);
                checking.Text = "Account Created Successfully!";
                con.Close();
            }
            else if(reader.HasRows)
            {
                checking.Text = "Username Already Exists!";
                con.Close();
            }
            else if (!check)
            {
                checking.Text = "Invalid Email ID!";
                con.Close();
            }
            con.Close();

        }
        else
        {
            checking.Text = "Invalid Username or Password!";
            
        }
       
    }



    protected void newId_TextChanged(object sender, EventArgs e)
    {

    }

    protected void newPass_TextChanged1(object sender, EventArgs e)
    {

    }
}