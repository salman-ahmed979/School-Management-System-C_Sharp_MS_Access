using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;



namespace STUDENT_MANAGEMENT_SYSTEM
{
     class login 
    {
        private string name, category;
        private int password;
        public login(string naam, int pin, string option)
        {
            name = naam;
            password = pin;
            category = option;
        }

        public login()
        {
            // TODO: Complete member initialization
        }
        
        
       
        public int login_check()
        {
            int count=0;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table4 where Name='"+name+"'and Password='"+password+"'and Category='"+category+"'";
            cmd.ExecuteNonQuery();
            DataTable dtt = new DataTable();
            OleDbDataAdapter dda = new OleDbDataAdapter(cmd);
            dda.Fill(dtt);
            count = Convert.ToInt32(dtt.Rows.Count.ToString());
            connection.Close();
            if (count > 0 )
            {
 
                return (1);
            }
            else if (count == 0)
            {
                return (0);
            }
            else
            {
                return (count);
            }
           
        }
        
    }
}
