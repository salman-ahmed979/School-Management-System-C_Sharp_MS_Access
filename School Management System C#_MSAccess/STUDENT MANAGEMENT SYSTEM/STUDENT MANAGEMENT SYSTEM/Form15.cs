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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

       
        private void Form15_Load(object sender, EventArgs e)
        {
            main1.BringToFront();
        }

      

       
       

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOU LOGOUT");
            if (File.Exists(("Connection/stdu.txt")))
            {
                File.Delete(("Connection/stdu.txt"));
            }

            if (File.Exists(("Connection/stdp.txt")))
            {
                File.Delete(("Connection/stdp.txt"));
            }

            this.Hide();
            Form3 fm = new Form3();
            fm.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form16 fm = new Form16();
            //Form8 fm = new Form8();
            fm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            profile1.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            marks_check1.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 fm = new Form17(0);
            //Form8 fm = new Form8();
            fm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            view_announcement1.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            student_attendence1.BringToFront();
        }

        private void top_bar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
