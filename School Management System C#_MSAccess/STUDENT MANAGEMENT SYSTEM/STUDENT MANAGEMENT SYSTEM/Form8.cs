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
    public partial class Form8 : Form
    {
        double fee_check;
        int fee_code;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            label7.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            student std = new student();
            if (textBox3.Text == "")
            {
                MessageBox.Show("PLEASE ENTER ROLL NO");
            }
            else if (textBox3.Text != "")
            {
                OleDbCommand commandd = std.show_fees_data(Convert.ToInt32(textBox3.Text));
                DataTable dtt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter(commandd);
                adapt.Fill(dtt);



                if (dtt.Rows.Count > 0)
                {
                    int i = 0;

                    fee_check = Convert.ToDouble(dtt.Rows[i].ItemArray[4].ToString());
                    fee_code = Convert.ToInt32(dtt.Rows[i].ItemArray[7].ToString());
                    dataGridView1.Rows[i].Cells[0].Value = dtt.Rows[i].ItemArray[0].ToString(); //Student Name
                    dataGridView1.Rows[i].Cells[1].Value = dtt.Rows[i].ItemArray[1].ToString(); //Roll no
                    dataGridView1.Rows[i].Cells[2].Value = dtt.Rows[i].ItemArray[2].ToString();//Class
                    dataGridView1.Rows[i].Cells[3].Value = dtt.Rows[i].ItemArray[3].ToString(); //Section
                    dataGridView1.Rows[i].Cells[4].Value = dtt.Rows[i].ItemArray[5].ToString();//Issue Date
                    dataGridView1.Rows[i].Cells[5].Value = dtt.Rows[i].ItemArray[6].ToString();//Due Date
                    dataGridView1.Rows[i].Cells[6].Value = dtt.Rows[i].ItemArray[4].ToString();//Fee Amount
                    dataGridView1.Rows[i].Cells[7].Value = dtt.Rows[i].ItemArray[8].ToString();//Paid column

                    textBox3.Enabled = true;

                    dataGridView1.Visible = true;
                    textBox1.Visible = true;
                    label5.Visible = true;
                    button2.Visible = true;
                    button2.Enabled = true;
                    textBox1.Enabled = true;
                    label5.Enabled = true;
                }

                else
                {
                    MessageBox.Show("FEE CHALLAN NOT GENERATED");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER FEE AMOUNT");
            }
            else if (textBox1.Text != "")
            {
                if (Convert.ToDouble(textBox1.Text) == fee_check)
                {
                    label8.Text = fee_code.ToString();
                    label6.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    button3.Visible = true;
                    button5.Visible = true;
                    textBox2.Visible = true;
                    dataGridView1.Enabled = false;
                    button2.Enabled = false;
                    textBox1.Enabled = false;
                    //Enabled
                    label6.Enabled = true;
                    label8.Enabled = true;
                    label9.Enabled = true;
                    textBox2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = true;
                }
                else if (Convert.ToDouble(textBox1.Text) != fee_check)
                {
                    MessageBox.Show("AMOUNT IS NOT MATCH WITH TOTAL FEE");
                }
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            textBox3.Enabled = false;
            
            label5.Enabled = false;
            label6.Enabled = false;
            label8.Enabled= false;
            label9.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled= false;
            button3.Enabled = false;
            button5.Enabled = false;
            label7.Enabled= false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("PLEASE ENTER CODE");
            }
            else if (textBox1.Text != "")
            {
                if (Convert.ToDouble(textBox2.Text) == fee_code)
                {
                    int check_digit = 0;
                    admin obj = new admin();
                    check_digit=obj.submit_fee(Convert.ToInt32(textBox3.Text));
                    if (check_digit == 1)
                    {
                        MessageBox.Show("FEE SUBMITTED SUCCESSFULLY");
                        button1.Enabled = true;
                        textBox3.Text = "";
                    }
                    else 
                    {
                        MessageBox.Show("ERROR IN SUBMITTING FEE");
                    }
                    dataGridView1.Enabled = false;
                    
                    
                    label5.Enabled = false;
                    label6.Enabled = false;
                    label8.Enabled = false;
                    label9.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    label7.Enabled = false;

                }
                else 
                {
                    MessageBox.Show("ENTER VALID CODE");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
