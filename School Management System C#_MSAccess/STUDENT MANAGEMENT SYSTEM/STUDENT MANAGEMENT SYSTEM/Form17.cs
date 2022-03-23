using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form17 : Form
    {
        int z;
        public Form17(int x)
        {
            InitializeComponent();
            z = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
     
            if (z == 0)
            {



                StreamReader fileu = new StreamReader(("Connection/stdu.txt"), true);
                String user = fileu.ReadLine();
                fileu.Dispose();
                fileu.Close();


                StreamReader filep = new StreamReader(("Connection/stdp.txt"), true);
                String pass = filep.ReadLine();
                filep.Dispose();
                filep.Close();

                student obj = new student();
                OleDbCommand command = obj.search_by_cnic(user, Convert.ToDouble(pass));
                DataTable dt2 = new DataTable();
                OleDbDataAdapter da2 = new OleDbDataAdapter(command);
                da2.Fill(dt2);

                int clas = Convert.ToInt32(dt2.Rows[0].ItemArray[14].ToString());
                string sec = dt2.Rows[0].ItemArray[15].ToString();
                MessageBox.Show("" + clas +sec);

                //------------------------------------------------------------------------------
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();

                admin objj = new admin();
                OleDbCommand cmdd = objj.view_time_table(clas, sec);

                DataTable dt = new DataTable();
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmdd);
                da1.Fill(dt);
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    

                    string x = dt.Rows[i].ItemArray[2].ToString();
                    string y = dt.Rows[i].ItemArray[3].ToString();
                   
                    dataGridView1.Rows[Convert.ToInt32(y)].Cells[Convert.ToInt32(x)].Value = String.Concat(dt.Rows[i].ItemArray[4].ToString(), "(", dt.Rows[i].ItemArray[5].ToString(), ")");


                }
            }
            else if (z == 1)
            {


                StreamReader fileu = new StreamReader(("Connection/ttdu.txt"), true);
                String user = fileu.ReadLine();


                StreamReader filep = new StreamReader(("Connection/ttdp.txt"), true);
                String pass = filep.ReadLine();


                fileu.Dispose();
                fileu.Close();
                filep.Dispose();
                filep.Close();

                teacher obj = new teacher();
                OleDbCommand command = obj.view_data(user, pass);
                DataTable dt2 = new DataTable();
                OleDbDataAdapter da2 = new OleDbDataAdapter(command);
                da2.Fill(dt2);

                string teacherr = dt2.Rows[0].ItemArray[0].ToString();

                //============================================================================
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();

                teacher objectt = new teacher();
                OleDbCommand cmmd = objectt.teacher_name_find(teacherr);
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmmd);
                da.Fill(dt);



                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string x = dt.Rows[i].ItemArray[2].ToString();
                    string y = dt.Rows[i].ItemArray[3].ToString();

                    dataGridView1.Rows[Convert.ToInt32(y)].Cells[Convert.ToInt32(x)].Value = String.Concat(dt.Rows[i].ItemArray[4].ToString(), " (", dt.Rows[i].ItemArray[0].ToString(), " ", dt.Rows[i].ItemArray[1].ToString(), ")");


                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (z == 0)
            {
                this.Hide();
                Form15 fm = new Form15();
                fm.ShowDialog();
            }
            else if (z == 1)
            {
                this.Hide();
                Form10 fm2 = new Form10();
                fm2.ShowDialog();

            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label4.Enabled = true;

        }
    }
}
