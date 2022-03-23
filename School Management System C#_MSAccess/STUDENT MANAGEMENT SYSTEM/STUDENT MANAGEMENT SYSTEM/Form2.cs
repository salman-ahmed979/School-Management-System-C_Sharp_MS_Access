using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form2 : Form
    {
        int y=0;
        public Form2()
        {
            InitializeComponent();
            button4.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
             int a=0,b=0;
            string option = "STUDENT";
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "@nu.edu.pk" || textBox6.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox13.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem== null|| comboBox4.SelectedItem == null ||comboBox5.SelectedItem == null ||dateTimePicker1.Value.ToShortDateString() == DateTime.Today.ToShortDateString() || openFileDialog1.FileName == ""|| textBox14.Text == "" || y==0)
            {
                if (y == 0)
                {
                    MessageBox.Show("PLEASE INSERT IMAGE");
                }
                MessageBox.Show("ENTER DATA");
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "@nu.edu.pk" && textBox6.Text != "" && comboBox1.SelectedItem != null && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && comboBox2.SelectedItem != null && textBox13.Text != "" && comboBox3.SelectedItem != null && dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString() && comboBox4.SelectedItem != null && openFileDialog1.FileName != "" && comboBox5.SelectedItem != null && textBox14.Text != "")
            {
                student obj = new student(Convert.ToDouble(textBox11.Text),comboBox1.SelectedItem.ToString(), Convert.ToInt32(comboBox4.SelectedItem), textBox8.Text, Convert.ToInt32(textBox13.Text), comboBox5.SelectedItem.ToString());
                obj.set_data(textBox1.Text, textBox2.Text, textBox9.Text, textBox10.Text, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), dateTimePicker1.Value.ToShortDateString(), comboBox3.SelectedItem.ToString() , comboBox2.SelectedItem.ToString(), textBox6.Text, Convert.ToDouble(textBox14.Text), openFileDialog1.FileName,textBox14.Text);
                a = obj.save_data();
                b = obj.add_login_info(option);
                if (a == 1 && b == 1)
                {
                    MessageBox.Show("DATA RECORDED");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "@gmail.com";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    comboBox1.SelectedItem = null;
                    comboBox2.SelectedItem = null;
                    comboBox3.SelectedItem = null;
                    comboBox4.SelectedItem = null;
                    comboBox5.SelectedItem = null;
                    dateTimePicker1.Value = DateTime.Today;
                    openFileDialog1.FileName = null;
                    pictureBox1.Image = null;



                    this.Hide();
                    Form1 fm = new Form1();
                    fm.ShowDialog();
                }
                else if (a == 2 && b == 2)
                {
                    MessageBox.Show("DATA NOT RECORD");
                    this.Hide();
                    Form1 fm = new Form1();
                    fm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("DATA NOT RECORD");
                
            }
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox14.Enabled =false;
            button1.Enabled = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next(1000, 9999);
            textBox14.Text = num.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source;

                source = openFileDialog1.FileName;
                y++;
                pictureBox1.Image = Image.FromFile(source);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                button1.Enabled = true;
                button5.Enabled = false;
                button4.Enabled = true;
                
            }
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            if(button5.Enabled == false)
            {
                y--;
                if (y < 0) y = 0;
                pictureBox1.Image = null;
                button4.Enabled = false;
                button5.Enabled = true;
                button1.Enabled = false;
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( !(char.IsLetter(e.KeyChar)) && (char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
