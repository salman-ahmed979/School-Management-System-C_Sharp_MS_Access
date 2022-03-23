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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            set_page();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void set_page()
        {
            panel_add.Visible = false;
            panel_fee.Visible = false;
            panel_view.Visible = false;
        }
        private void hide_sub_menu()
        {
            if (panel_view.Visible == true)
                panel_view.Visible = false;
            if (panel_add.Visible == true)
                panel_add.Visible = false;
            if (panel_fee.Visible == true)
                panel_fee.Visible = false;
        }
        private void show_sub_menue(Panel sub_menue)
        {
            if (sub_menue.Visible == false)
            {
                hide_sub_menu();
                sub_menue.Visible = true;
            }
            else
            {
                sub_menue.Visible = false;
            }

        }


     

     
       
        private void Form10_Load(object sender, EventArgs e)
        {

            main1.BringToFront();

        }

        private void announcement1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_add);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            this.Hide();
            Form6 fm = new Form6();
            fm.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            teacher_view1.BringToFront();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            this.Hide();
            Form11 f = new Form11();
            f.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            this.Hide();
            Form13 f = new Form13();
            f.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_view);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_fee);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f = new Form17(1);
            f.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 f = new Form14();
            f.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOU LOGOUT");
            if (File.Exists(("Connection/ttdu.txt")))
            {
                File.Delete(("Connection/ttdu.txt"));
            }
            if (File.Exists(("Connection/atdu.txt")))
            {
                File.Delete(("Connection/atdu.txt"));
            }
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form19 f = new Form19();
            f.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 fm = new Form9();
            fm.ShowDialog();
        }
    }
}
