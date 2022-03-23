using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
namespace STUDENT_MANAGEMENT_SYSTEM
{
    class admin
    {
        private int cls;
        private string section, announce, date, time ,category;
        public admin(string date, string time)
        {
            this.date = date;
            this.time = time;
        }
        public admin() { }
        public void announcement(int cls, string section ,string announce,string category)
        {
            this.cls = cls;
            this.section = section;
            this.announce = announce;
            this.category = category;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
          //  OleDbConnection conect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "insert into Table2 values ('"+category+"','"+cls+"','"+section+"','"+announce+"','"+date+"','"+time+"')";
            cmd.ExecuteNonQuery();
            connection.Close();
 
        }
        public OleDbCommand show_fees_data(int rolno)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Table7 where [Rollno] like '" + rolno + "'";
            command.ExecuteNonQuery();
            connection.Close();
            return command;
        }
        public OleDbDataReader fee_challan()
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            OleDbDataReader reader = null;
            command.CommandText = "select * from Table7";
            reader=command.ExecuteReader(); 
            return (reader);
        }
        //------------------//------------------//
        
        public void enter_fee(string name,int roll_no, int cl, string section ,double amount,string issue_date ,string due_date,int code,int paid)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Table7 values('" + name + "','" + roll_no + "','" + cl + "', '" + section + "' ,'" + amount + "','" + issue_date + "' ,'" + due_date + "','" + code + "','" + paid + "')";
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void update_fee(double fees, string isuee_date, string duee_date, int pin_code, int paidd, int roll_no)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText ="UPDATE Table7 SET [FeeAmount]='" + fees + "', [Issue Date]='" + isuee_date + "', [Due Date]='" +duee_date + "', [Code]='" + pin_code+ "', [Paid]='" + paidd + "' WHERE [Rollno]=" +roll_no+ "";
            command.ExecuteNonQuery();
            connection.Close();
            
            
           
        }
        public OleDbCommand check_teacher()
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table3";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);

        }
        public OleDbCommand view_time_table(int clas ,string sec)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Table6] where [class]=" + clas + " AND [section]='" + sec + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);
 
        }
        public int submit_fee(int roll_no)
        {
            double pin_code = 0;
            int check = 1;
            int fees = 0;
            int i = 0;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Table7 SET [FeeAmount]=" + fees + " ,[Code]=" + pin_code + ", [Paid]=" + check+ " WHERE [Rollno]=" + roll_no + "";
            i=command.ExecuteNonQuery();
            connection.Close();
            if (i > 0 && i != 0)
            {
                return (1);
            }
            else
            {
                return (0);
            }




        }

         ~admin()
        { }

    }
}
 