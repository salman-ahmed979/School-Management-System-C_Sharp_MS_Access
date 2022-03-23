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
    public partial class Form19 : Form
    {
        string user;
        OleDbConnection connection = new OleDbConnection();
        public Form19()
        {
            InitializeComponent();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
        }
        int no_of_rows;

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 fm = new Form10();
            fm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where [teacher]='" + user + "' AND [class]=" + Convert.ToInt32(comboBox1.SelectedItem) + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox2.Items.Clear();

            comboBox3.Items.Clear();

            comboBox3.Items.Add(dt.Rows[j].ItemArray[1]);

            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToString(dt.Rows[j].ItemArray[1]) != Convert.ToString(dt.Rows[i].ItemArray[1]))
                {
                    comboBox3.Items.Add(dt.Rows[i].ItemArray[1]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
            
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker1.Value = DateTime.Now.Date;
            button2.Visible = false;
            
            
            dataGridView1.Visible = false;

            //-----------------for adding teacher  names in teacher comboobox-----------
            StreamReader fileu = new StreamReader(("Connection/ttdu.txt"), true);
            user = fileu.ReadLine();
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where teacher='" + user + "'";

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(dt.Rows[j].ItemArray[0]);

            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToInt32(dt.Rows[j].ItemArray[0]) != Convert.ToInt32(dt.Rows[i].ItemArray[0]))
                {
                    comboBox1.Items.Add(dt.Rows[i].ItemArray[0]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where [teacher]='" + user + "' AND [class]=" + Convert.ToInt32(comboBox1.SelectedItem) + " AND [section]='" + (comboBox3.SelectedItem) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox2.Items.Clear();
            comboBox2.Items.Add(dt.Rows[j].ItemArray[4]);




            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToString(dt.Rows[j].ItemArray[4]) != Convert.ToString(dt.Rows[i].ItemArray[4]))
                {
                    comboBox2.Items.Add(dt.Rows[i].ItemArray[4]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null || comboBox2.SelectedItem==null || dateTimePicker1.Value.ToShortDateString()==null)
            {
                MessageBox.Show(" Please Select Class Section Date And course To Add Attendence");

            }

            else if (comboBox1.SelectedItem != null && comboBox3.SelectedItem != null || comboBox2.SelectedItem!=null || dateTimePicker1.Value.ToShortDateString()!=null)
            {
                
                    dataGridView1.Rows.Clear();
                   

                    teacher obj = new teacher();
                    OleDbCommand cmd = obj.Update_attenedence_date_show(Convert.ToInt32(comboBox1.SelectedItem.ToString()), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), dateTimePicker1.Value.ToShortDateString());
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    no_of_rows = dt.Rows.Count;
                    // con.Close();

                    int i;
                    if (no_of_rows == 0)
                    {
                       
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(" PLEASE SELECT NO FOR HOME PAGE OR YESS TO ADD ATTENDENCE FIRST OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + " OF DATE " + dateTimePicker1.Value.ToShortDateString(), "ATTENDENCE UPLOAD", buttons);
                        if (result == DialogResult.Yes)
                        {
                            this.Hide();
                            Form9 fm = new Form9();
                            fm.ShowDialog();

                        }
                        else
                        {
                            this.Hide();
                            Form10 fm = new Form10();
                            fm.ShowDialog();

                        }
                    }
                    else if (no_of_rows > 0)
                    {
                        MessageBox.Show("ATTENDENCE OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + "");
                        dataGridView1.Visible = true;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[0].ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[1].ToString();
                            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i].ItemArray[5].ToString();

                        }
                        button1.Visible = false;
                        button2.Visible = true;
                        dataGridView1.Visible = true;
                        label2.Enabled = false;
                        label3.Enabled = false;
                        comboBox2.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        label4.Enabled = false;
                        label1.Enabled = false;
                        comboBox1.Enabled = false;
                        comboBox3.Enabled = false;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && dateTimePicker1.Value.ToShortDateString() != null)
            {
                int count = 0;
                for (int i = 0; i < no_of_rows; i++)
                {
                    int count_1 = 0;
                    teacher ob = new teacher();
                    
                    count_1 = ob.insert_attendence(0, dataGridView1.Rows[i].Cells[0].Value.ToString(), comboBox2.SelectedItem.ToString(), dateTimePicker1.Value.ToShortDateString(), comboBox3.SelectedItem.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(comboBox1.SelectedItem), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                    //
                   
                    count = count + count_1;
                }
                if (count == no_of_rows)
                {
                    MessageBox.Show("ATTENDENCE UPDATED SUCCESSFULLY");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    //comboBox2.SelectedItem = null;
                    //comboBox3.SelectedItem = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    dateTimePicker1.Value = DateTime.Today;
                }
            }

            else
            {
                MessageBox.Show("ERROR IN ADDING ATTENDENCE");
            }
        }
    }
}
