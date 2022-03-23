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
    public partial class Form14 : Form
    {
        string user;
        public Form14()
        {
            InitializeComponent();
            button3.Visible = false;
            button1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 foam = new Form10();
            foam.ShowDialog();

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //-----------------------------------------------------
            StreamReader fileu = new StreamReader(("Connection/ttdu.txt"), true);
            user = fileu.ReadLine();
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where teacher='"+user+"'";

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
           // OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where [teacher]='"+user+"' AND [class]=" + Convert.ToInt32(comboBox1.SelectedItem) + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
           
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                button3.Visible = true;
            }
            else
            {
                MessageBox.Show("SELECT CLASS OR SECTION");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            label1.Enabled = false;
            label4.Enabled = false;
            comboBox3.Enabled = false;
            comboBox1.Enabled = false;
            button1.Visible = true;
            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("EMPTY FIELDS");
            }
            else if (comboBox1.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                teacher obj = new teacher();
                OleDbCommand cmd;
                cmd = obj.view_data(Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString());
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("NO RECORD OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + "");
                }
                else if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("DATA OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + "");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[1].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[0].ToString();

                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Enabled = true;
            label4.Enabled = true;
            comboBox3.Enabled = true;
            comboBox1.Enabled = true;
            button1.Visible = false ;
            button3.Visible = false;
            dataGridView1.Rows.Clear();
            comboBox3.SelectedItem = null;
           
        }
        }
    }
