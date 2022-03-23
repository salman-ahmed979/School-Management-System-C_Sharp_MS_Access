using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string time, date;
            time = DateTime.Now.ToString("HH:mm:ss tt");
            date = DateTime.Now.Date.ToShortDateString();
            admin obj = new admin(date, time);

            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false)
                     {
                        MessageBox.Show("PLEASE SELECT CHECKBOX TO ADD ANNOUNCEMENT");  
  
                     }
            
            
            if(((checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true ||checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true || checkBox9.Checked == true || checkBox10.Checked == true || checkBox11.Checked == true ) && (checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false)) )
                     {
                        MessageBox.Show("PLEASE SELECT SECTION CHECKBOX TO ADD ANNOUNCEMENT");

                    }
             else if(((checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true ||checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true || checkBox9.Checked == true || checkBox10.Checked == true || checkBox11.Checked == true ) && (checkBox13.Checked == true || checkBox14.Checked == true || checkBox15.Checked == true)) )
                    {
                        
                 
             
                if (checkBox11.Checked == true)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox5.Checked = true;
                    checkBox6.Checked = true;
                    checkBox7.Checked = true;
                    checkBox8.Checked = true;
                    checkBox9.Checked = true;
                    checkBox10.Checked = true;
                    checkBox15.Checked = true;
                    checkBox13.Checked = true;
                    checkBox14.Checked = true;

                }


                if (checkBox1.Checked == true )
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(1,"A",textBox1.Text,"Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(1, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(1, "C", textBox1.Text, "Student");
                    }
                    
                 
                }
                if (checkBox2.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(2, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(2, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(2, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox3.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(3, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(3, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(3, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox4.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(4, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(4, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                         obj.announcement(4,"C",textBox1.Text,"Student");
                    }
                }
                if (checkBox5.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(5, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(5, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(5, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox6.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(6, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(6, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(6, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox7.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(7, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(7, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(7, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox8.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(8, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(8, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(8, "C", textBox1.Text, "Student");
                    }
                }
                if (checkBox9.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(9, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                        obj.announcement(9, "B", textBox1.Text, "Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(9, "C", textBox1.Text, "Student");
                    }
                }

                if (checkBox10.Checked == true)
                {
                    if (checkBox13.Checked == true)
                    {
                        obj.announcement(10, "A", textBox1.Text, "Student");
                    }

                    if (checkBox14.Checked == true)
                    {
                         obj.announcement(10,"B",textBox1.Text,"Student");
                    }

                    if (checkBox15.Checked == true)
                    {
                        obj.announcement(10, "C", textBox1.Text, "Student");
                    }
                }



                MessageBox.Show("ANNOUNCEMENT HAS BEEN ADDED");
            }
            if (checkBox12.Checked == true)
            {
                obj.announcement(0, " ", textBox1.Text, "Teacher");
                MessageBox.Show("ANNOUNCEMENT HAS BEEN ADDED");
            }

            
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            
        }
    

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox15.Checked = true;
                checkBox13.Checked = true;
                checkBox14.Checked = true;

            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox15.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
 
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader filep = new StreamReader(("Connection/atdu.txt"), true);
            String pass = filep.ReadLine();
            MessageBox.Show(""+pass);
            if (pass=="ADMIN")
            {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
            }
            else if(pass=="TEACHER")
            {
                this.Hide();
                Form10 fm = new Form10();
                fm.ShowDialog();
            }

        }
        
    }
}
