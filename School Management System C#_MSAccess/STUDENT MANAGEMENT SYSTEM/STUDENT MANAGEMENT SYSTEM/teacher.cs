using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    class teacher : person 
    {
        private string qualification,choosen_as;
        public teacher()
        { 
        }
    
        public teacher(double cnicc, string sex,string relligion, int year, string qualification,string choosen_as) 
                : base(cnicc, sex, relligion, year)
        {

            this.choosen_as = choosen_as;
            this.qualification=qualification;
           
        }
        public int save_data()
        {
            int check = 0;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
           // OleDbConnection conect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table3 values('"+name+"' , '"+ father_name +"' , '"+cnic+"','"+phone_no+"', '"+father_phone_no+"' , '"+date_of_birth+"' , '"+gender+"','"+country+"' , '"+city+"' ,'"+address+"' ,'"+email+"' ,'"+nationality+"' ,'"+religion+"' ,'"+qualification+"' ,'"+choosen_as+"' , '"+year_0f_join+"' , '"+password+"','"+image+"' )";
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
        public OleDbCommand view_teacher_announcement(string categoryy)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table2 WHERE [Category] like '"+categoryy+"'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);




        }
       
        public OleDbCommand view_data()
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
           // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table3";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);




        }
       
        public OleDbCommand Update_attenedence_date_show(int clas, string section, string subject, string att_date)
        {
           
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Table5] WHERE [Class] like " + clas + " AND [Section] like '" + section + "' AND [Course] like '" + subject + "' AND [Attendence_Date] like '" + att_date + "' ";
             cmd.ExecuteNonQuery();
             return (cmd);
        }

        public int insert_attendence(int choice,string name,string subject,string date,string section,string attendence, int clas,int roll_no_student)
        {
            int check = 0;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            // OleDbConnection conect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                cmd.CommandText = cmd.CommandText = "insert into Table5 values('" +name + "','" + roll_no_student + "','" + clas + "','" +section + "','" + subject + "','" + attendence + "','" + date + "')";
                check = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else if (choice==0)
            {
                cmd.CommandText = "UPDATE [Table5] SET [Attendence]='" + attendence + "' WHERE [Name] like '" + name + "' AND [Roll No] like " + roll_no_student + " AND [Class] like " + clas + " AND [Section] like '" + section + "' AND [Course] like '" + subject + "' AND [Attendence_Date] like '" + date + "'";
                
                check = cmd.ExecuteNonQuery();
                connection.Close();
 
            }
            
            if (check > 0)
            {
                return (1);
            }
            else
            {
                return (check);
            }
 
        }
        public OleDbCommand view_data(int cls,string section)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Table1] WHERE [Class] like " + cls + " AND [Section] like '" + section + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);




        }
        public OleDbCommand view_data(string user, string section)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Saad Talal\Desktop\New folder (5)\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Table3] WHERE [Name] like '" + user + "' AND [Password] like '" + Convert.ToDouble(section) + "'";
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
            cmd.CommandText = "select * from Table3 where CNIC like '" + id + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);

        }
        public OleDbCommand search_by_option(string option)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table3 where Select_As like '" + option + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);

        }
        public OleDbCommand teacher_name_find(string option)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table6 where [teacher] like '" + option + "'";
             cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);

        }
        public OleDbCommand add_atendence(int cl,string sec )
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Table1] WHERE [Class] like " +cl+ " AND [Section] like '" + sec + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);
 
        }
        public int update_mark(int cl, string sec, string subject, int choice)
        {

            int check;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
          //  OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            if (choice == 1)
            {
                command.CommandText = "SELECT * FROM [Table8] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                command.ExecuteNonQuery();
                DataTable dtt = new DataTable();
                OleDbDataAdapter dda = new OleDbDataAdapter(command);
                dda.Fill(dtt);
                check = Convert.ToInt32(dtt.Rows.Count.ToString());
                connection.Close();
                if (check > 0)
                {
                    return (1);
                }
                else
                {
                    return (0);
                }
            }
            else if (choice == 2)
            {
                command.CommandText = "SELECT * FROM [Table9] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                command.ExecuteNonQuery();
                DataTable dtt = new DataTable();
                OleDbDataAdapter dda = new OleDbDataAdapter(command);
                dda.Fill(dtt);
                check = Convert.ToInt32(dtt.Rows.Count.ToString());
                connection.Close();
                if (check > 0)
                {
                    return (1);
                }
                else
                {
                    return (0);
                }
            }
            else
            {
                command.CommandText = "SELECT * FROM [Table10] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                command.ExecuteNonQuery();
                DataTable dtt = new DataTable();
                OleDbDataAdapter dda = new OleDbDataAdapter(command);
                dda.Fill(dtt);
                check = Convert.ToInt32(dtt.Rows.Count.ToString());
                connection.Close();

                if (check > 0)
                {
                    return (1);
                }
                else
                {
                    return (0);
                }
            }

        }
        public int upload_marks(string name,int roll_no,int cl, string sec, string subject, int choice,decimal marks,int check)
        {
            int optionn;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmmd = connection.CreateCommand();
            cmmd.CommandType = CommandType.Text;
            if (choice == 1)
            {

                cmmd.CommandText = "UPDATE [Table8] SET [Quiz Marks]="+marks+" , [Flag One]="+ check +" WHERE [Name] like '"+name+"' AND [Roll No] like "+roll_no+" AND [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                optionn=cmmd.ExecuteNonQuery();
                return (optionn);
            }
            if (choice == 2)
            {
                cmmd.CommandText = "UPDATE [Table9] SET [Mid Marks]=" + marks + " , [Flag One]=" + check + " WHERE [Name] like '" + name + "' AND [Roll No] like " + roll_no + " AND [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                optionn = cmmd.ExecuteNonQuery();
                return (optionn);
            }
            else
            {
                cmmd.CommandText = "UPDATE [Table10] SET [Final Marks]=" + marks + " , [Flag One]=" + check + " WHERE [Name] like '" + name + "' AND [Roll No] like " + roll_no + " AND [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                optionn = cmmd.ExecuteNonQuery();
                return (optionn);
            }


        }
        public OleDbCommand update_marks(int cl, string sec,string subject , int choice)
        {

            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmmd = connection.CreateCommand();
            cmmd.CommandType = CommandType.Text;
            if (choice == 1)
            {
                
                cmmd.CommandText = "SELECT * FROM [Table8] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '"+ subject+"'";
                cmmd.ExecuteNonQuery();
                return (cmmd);
            }
            if (choice == 2)
            {
                cmmd.CommandText = "SELECT * FROM [Table9] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                cmmd.ExecuteNonQuery();
                return (cmmd);
            }
            else
            {
                cmmd.CommandText = "SELECT * FROM [Table10] WHERE [Class] like " + cl + " AND [Section] like '" + sec + "' AND [Subject] like '" + subject + "'";
                cmmd.ExecuteNonQuery();
                return (cmmd);
            }
            
 
        }
    }
}
