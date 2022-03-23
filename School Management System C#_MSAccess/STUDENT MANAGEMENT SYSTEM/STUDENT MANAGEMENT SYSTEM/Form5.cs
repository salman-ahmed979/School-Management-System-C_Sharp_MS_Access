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
    public partial class Form5 : Form
    {
        int y=0;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check = 0,check1=0;
            string option = "TEACHER";
            if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Value.ToShortDateString() == DateTime.Today.ToShortDateString() || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox8.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "@gmailcom" || textBox11.Text == ""  || textBox13.Text == "" || textBox14.Text == "" || openFileDialog1.FileName == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null || comboBox5.SelectedItem == null || y==0)
            {
                if (y == 0)
                {
                    MessageBox.Show("PLEASE INSERT IMAGE");
                }
                MessageBox.Show("ENTER DATA");
            }
            else if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString() && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "@gmailcom" && textBox11.Text != "" && textBox13.Text != "" && textBox14.Text != "" && openFileDialog1.FileName != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null)
            {
                teacher obj = new teacher(Convert.ToDouble(textBox11.Text), comboBox1.SelectedItem.ToString(), textBox8.Text, Convert.ToInt32(textBox13.Text),comboBox4.SelectedItem.ToString() ,comboBox5.SelectedItem.ToString());
                obj.set_data(textBox1.Text, textBox2.Text, textBox9.Text, textBox10.Text, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), dateTimePicker1.Value.ToShortDateString(),comboBox2.SelectedItem.ToString(),comboBox3.SelectedItem.ToString(), textBox6.Text, Convert.ToDouble(textBox14.Text), openFileDialog1.FileName,textBox14.Text);
                check = obj.save_data();
                check1=obj.add_login_info(option);
                if (check == 1 && check1 == 1)
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
                else if (check == 2 && check1 == 2)
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
        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next(1000, 9999);
            textBox14.Text = num.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            y = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source;
                source = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(source);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                button1.Enabled = true;

            }
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

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox14.Enabled = false;
            button1.Enabled = false;
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
    }
}
