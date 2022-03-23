using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form18 : Form
    {
        OleDbConnection connection;
        public Form18()
        {
            InitializeComponent();
            connection = new OleDbConnection();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();

        }

        private void Form18_Load(object sender, EventArgs e)
        {

            //-----------------for adding teacher  names in teacher comboobox-----------

            admin obj = new admin();
            OleDbCommand cmd = obj.check_teacher();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox6.Items.Add(dt.Rows[i].ItemArray[0]);
                comboBox8.Items.Add(dt.Rows[i].ItemArray[0]);
            }

            //---------------------------------------------------------------------------------------   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null || comboBox5.SelectedItem == null || comboBox6.SelectedItem == null)
            {

                MessageBox.Show("EMPTY FIELDS");

            }
            else
            {
                int check = 0;
                timetable objt = new timetable(Convert.ToInt32(comboBox1.SelectedItem.ToString()), comboBox2.SelectedItem.ToString(), Convert.ToInt32(comboBox3.SelectedIndex), Convert.ToInt32(comboBox4.SelectedIndex), comboBox5.SelectedItem.ToString(), comboBox6.SelectedItem.ToString());
                check = objt.save_data();
                if (check == 1)
                {
                    MessageBox.Show("TIME TABLE EDITED SUCCESSFULLY");
                }
                else
                {
                    MessageBox.Show("TIME TABLE EDIT NOT SUCCESSFULLY");

                }
            }

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem == null || comboBox9.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT CLASS AND SECTION TO VIEW TIME TABLE FOR CLASS");
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();

                timetable objj = new timetable();
                OleDbCommand cmd = objj.search_by_class(Convert.ToInt32(comboBox7.SelectedItem.ToString()), comboBox9.SelectedItem.ToString());
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                
                connection.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string x = dt.Rows[i].ItemArray[2].ToString();
                    string y = dt.Rows[i].ItemArray[3].ToString();

                    dataGridView1.Rows[Convert.ToInt32(y)].Cells[Convert.ToInt32(x)].Value = String.Concat(dt.Rows[i].ItemArray[4].ToString(), "(", dt.Rows[i].ItemArray[5].ToString(), ")");
                }
                
                
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

           
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();

                timetable ob = new timetable();
                OleDbCommand cmd = new OleDbCommand();
                cmd = ob.search_by_teacher(comboBox8.SelectedItem.ToString());
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string x = dt.Rows[i].ItemArray[2].ToString();
                    string y = dt.Rows[i].ItemArray[3].ToString();

                    dataGridView1.Rows[Convert.ToInt32(y)].Cells[Convert.ToInt32(x)].Value = String.Concat(dt.Rows[i].ItemArray[4].ToString(), " (", dt.Rows[i].ItemArray[0].ToString(), " ", dt.Rows[i].ItemArray[1].ToString(), ")");



                }

            }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        }
    
}
