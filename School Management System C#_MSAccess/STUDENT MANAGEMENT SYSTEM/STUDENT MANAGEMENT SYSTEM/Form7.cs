using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            teacher obj = new teacher();
            OleDbCommand command = obj.view_data();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            teacher obj = new teacher();
            OleDbCommand command = obj.search_by_cnic(textBox2.Text);

            DataTable dt = new DataTable();
            
            
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {

                string  mtstr1 = row["Name"].ToString();
                
                MessageBox.Show(mtstr1);
            }
            
            
            dataGridView1.DataSource = dt;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacher obj = new teacher();
            OleDbCommand command = obj.search_by_option(textBox1.Text);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }
    }
}
