using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

// Got help from Abdullah Gulraiz with Connecting to Database

    public class DBCon
    {
        private OleDbConnection con;
        public DBCon()
        {
            string constring = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\UrDiary'sDatabase.mdb;User Id=admin;Password=;");
            con = new OleDbConnection(constring);

        }

        public OleDbDataReader Execute(string sql)
        {
            con.Open();
            var reader = new OleDbCommand(sql, con).ExecuteReader();
             return reader;
        }
        public void Close()
        {
            con.Close();
        }
    }