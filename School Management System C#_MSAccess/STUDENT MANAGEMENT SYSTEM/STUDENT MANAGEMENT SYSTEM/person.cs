using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace STUDENT_MANAGEMENT_SYSTEM
{
    abstract class person
    {
        protected string name, father_name, address, email, date_of_birth, gender, city, country, nationality, religion, image,password1;
        protected int year_0f_join, roll_no;
        protected double cnic, phone_no, father_phone_no, password;
        public person()
        {
        }
        public person(double cnic, string sex, string relligion, int year)
        {
            this.cnic = cnic;
            gender = sex;
            religion = relligion;
            year_0f_join = year;
            Random r = new Random();
            int num = r.Next(1000000, 99999999);
            roll_no = num;

        }
        public void set_data(string n, string fn, string home, string mail, double no, double fno, string birth, string cty, string cntry, string nation, double password, string image,string password1)
        {
            name = n;
            father_name = fn;
            address = home;
            email = mail;
            phone_no = no;
            father_phone_no = fno;
            date_of_birth = birth;
            city = cty;
            this.image = image;
            country = cntry;
            this.password = password;
            this.password1 = password1;
            nationality = nation;

        }
        public int add_login_info(string category)
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
            cmd.CommandText = "insert into Table4 values('"+name+"','"+password1+"','"+category+"')";
            check = cmd.ExecuteNonQuery();
            if (check > 0)
            {
                return (1);
            }
            else
            {
                return (2);
            }

        }
        // Over ride function will be done in child class
        public OleDbCommand view_data()
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            connection.Close();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table1";
            cmd.ExecuteNonQuery();
            connection.Close();
            return (cmd);
        }
        ~person()
        {

        }



    }


}
