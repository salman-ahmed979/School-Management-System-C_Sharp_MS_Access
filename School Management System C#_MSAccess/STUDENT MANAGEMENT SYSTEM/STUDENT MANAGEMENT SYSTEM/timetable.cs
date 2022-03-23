using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
namespace STUDENT_MANAGEMENT_SYSTEM
{
    class timetable
    {
        private int classs;
        private string section;
        private int day;
        private int slot;
        private string subject;
        private string teacher;
        public timetable()
        { }
        public timetable(int classss, string sectionn, int dayy, int slott, string subjectt, string teacherr)
        {
            classs = classss;
            section = sectionn;
            day = dayy;
            slot = slott;
            subject = subjectt;
            teacher = teacherr;
        }

        public int save_data()
        {
            int check;
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("connection/connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "UPDATE table6 SET teacher='" + teacher + "',subject='" + subject + "' WHERE class=" + classs + " AND section='" + section + "' AND day=" + day + " AND timeslot=" + slot + "";

            check = cmd.ExecuteNonQuery();
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
        public OleDbCommand search_by_teacher(string name)
        {

            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("connection/connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table6 where [teacher]='" + name + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);
        }
        public OleDbCommand search_by_class(int cl,string searching)
        {
            
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("connection/connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Table6] where [class]=" + cl + " AND [section]='" + searching + "'";
           cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);
        }


         
    }
}
