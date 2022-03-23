using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace STUDENT_MANAGEMENT_SYSTEM
{
        class student : person
        {

            private string section;
            private int classs;
            public student()
            { }

            public student(double cnicc, string sex, int clas, string relligion, int year, string sect)
                : base(cnicc, sex, relligion, year)
            {
                section = sect;
                classs = clas;

            }
            public int save_data()
            {

                int check = 0;
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Table1 values('" + roll_no + "','" + name + "','" + father_name + "','" + cnic + "','" + phone_no + "','" + father_phone_no + "','" + date_of_birth + "','" + gender + "','" + country + "','" + city + "','" + address + "','" + email + "','" + nationality + "','" + religion + "','" + classs + "','" + section + "','" + year_0f_join + "','"+password+"','" + image + "')";
                check = cmd.ExecuteNonQuery();
                connection.Close();
                if (check > 0)
                {

                    return (1);
                }
                else
                {

                    return (2);
                }

            }

            public OleDbCommand view_data()
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from table1";
                cmd.ExecuteNonQuery();
                connection.Close();
                return (cmd);




            }
            public OleDbCommand search_by_cnic(string id)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table1 where CNIC like '" + id + "'";
                cmd.ExecuteNonQuery();
                connection.Close();
                return (cmd);
                
           }
            public OleDbCommand search_by_section(int clas)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
               // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table1 where Class like '" +clas+"'";
                cmd.ExecuteNonQuery();
                connection.Close();
                return (cmd);

            }
            public OleDbCommand fees_data_fetch(int clas, string sec)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Table1 where [Class] like " + clas + "AND [Section] like '" + sec + "'";
                command.ExecuteNonQuery();
                connection.Close();
                return command;


            }
            
            public OleDbCommand search_by_cnic(string name, double pass)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table1 where name like '" + name + "' AND password like " + pass + "";
                cmd.ExecuteNonQuery();
                connection.Close();
                return (cmd);

            }
            public OleDbCommand student_view(string name, int rollno,int option_no)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (option_no == 1)
                {
                    cmd.CommandText = "select * from Table5 where [Name] like '" + name + "' AND [Roll No] like " + rollno + "";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return (cmd);
                }
                else
                {
                    
                    cmd.CommandText = "select * from Table2 where [Section] like '" + name + "' AND [Class] like " + rollno + "";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return (cmd);
 
                }
 
            }
            public OleDbCommand marks_view(int rollno, int option_no)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                if (option_no == 1)
                {
                    cmd.CommandText = "select * from Table8 where [Roll No] like " + rollno + "";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return (cmd);
                }
                else if (option_no==2)
                {

                    cmd.CommandText = "select * from Table9 where [Roll No] like " + rollno + "";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return (cmd);

                }
                else 
                {

                    cmd.CommandText = "select * from Table10 where [Roll No] like " + rollno + "";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return (cmd);

                }


            }
            public OleDbCommand show_fees_data(int rooll_no)
            {
                OleDbConnection connection = new OleDbConnection();
                StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
                String con = file.ReadLine();
                connection.ConnectionString = con;
                // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table7 where [Rollno] like " + rooll_no + "";
                cmd.ExecuteNonQuery();
                connection.Close();
                return (cmd);

            }
            ~student()
            {

            }
        }
    
}
