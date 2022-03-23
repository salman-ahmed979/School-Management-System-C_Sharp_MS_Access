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
    public partial class Student_Info : UserControl
    {
        public Student_Info()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2();
            fm.ShowDialog();

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm = new Form5();
            fm.ShowDialog();
        }

        private void announcement1_Load(object sender, EventArgs e)
        {

        }

        private void Student_Info_Load(object sender, EventArgs e)
        {

        }
    }
}
