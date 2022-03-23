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
    public partial class Form3 : Form
    {


        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int check = 0;
            if (textBox1.Text == "" || comboBox1.SelectedItem == null || textBox2.Text == "")
            {
                MessageBox.Show("EMPTY FIELDS");
            }
            else if (textBox1.Text != "" && comboBox1.SelectedItem != null && textBox2.Text != "")
            {
                login obj = new login(textBox1.Text, Convert.ToInt32(textBox2.Text), comboBox1.SelectedItem.ToString());
                
                check = obj.login_check();
               
                if (check > 0 && comboBox1.SelectedItem.ToString() == "ADMIN")
                {
                    if (File.Exists(("Connection/atdu.txt")))
                    {
                        File.Delete(("Connection/atdu.txt"));
                    }
                    StreamWriter conwrti = new StreamWriter(("Connection/atdu.txt"), true);
                    conwrti.WriteLine(comboBox1.SelectedItem.ToString());
                    conwrti.Flush();
                    conwrti.Dispose();
                    this.Hide();
                    Form1 foam = new Form1();
                    foam.ShowDialog();


                }
                if (check > 0 && comboBox1.SelectedItem.ToString() == "TEACHER")
                {
                    if (File.Exists(("Connection/ttdu.txt")))
                    {
                        File.Delete(("Connection/ttdu.txt"));
                    }
                    if (File.Exists(("Connection/atdu.txt")))
                    {
                        File.Delete(("Connection/atdu.txt"));
                    }
                    if (File.Exists(("Connection/ttdp.txt")))
                    {
                        File.Delete(("Connection/ttdp.txt"));
                    }
                    StreamWriter conwrtu = new StreamWriter(("Connection/ttdu.txt"), true);
                    conwrtu.WriteLine(textBox1.Text.ToString());
                    conwrtu.Flush();
                    conwrtu.Dispose();
                    StreamWriter conwrtuu = new StreamWriter(("Connection/ttdp.txt"), true);
                    conwrtuu.WriteLine(textBox2.Text.ToString());
                    conwrtuu.Flush();
                    conwrtuu.Dispose();

                    StreamWriter conwrt1 = new StreamWriter(("Connection/atdu.txt"), true);
                    conwrt1.WriteLine(comboBox1.SelectedItem.ToString());
                    conwrt1.Flush();
                    conwrt1.Dispose();
                    this.Hide();
                    Form10 foam = new Form10();
                    foam.ShowDialog();

                }
                if (check > 0 && comboBox1.SelectedItem.ToString() == "STUDENT")
                {
                    if (File.Exists(("Connection/stdu.txt")))
                    {
                        File.Delete(("Connection/stdu.txt"));
                    }

                    if (File.Exists(("Connection/stdp.txt")))
                    {
                        File.Delete(("Connection/stdp.txt"));
                    }
                    StreamWriter conwrtu = new StreamWriter(("Connection/stdu.txt"), true);
                    conwrtu.WriteLine(textBox1.Text.ToString());
                    conwrtu.Flush();
                    conwrtu.Dispose();

                    StreamWriter conwrtp = new StreamWriter(("Connection/stdp.txt"), true);
                    conwrtp.WriteLine(textBox2.Text.ToString());
                    conwrtp.Flush();
                    conwrtp.Dispose();
                    this.Hide();
                    Form15 foam = new Form15();
                    foam.ShowDialog();

                }
            }
            if (check == 0)
            {
                MessageBox.Show("INVALID USER NAME AND PASSWORD");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedItem = null;

            }
            else { MessageBox.Show("THANK YOU FOR VISITING"); }
        }

       
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
