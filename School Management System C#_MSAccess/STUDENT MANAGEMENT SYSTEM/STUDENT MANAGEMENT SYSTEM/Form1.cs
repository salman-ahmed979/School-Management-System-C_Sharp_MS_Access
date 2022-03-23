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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            main1.BringToFront();
            set_page();



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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    
        
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOU LOGOUT");
            if (File.Exists(("Connection/atdu.txt")))
            {
                File.Delete(("Connection/atdu.txt"));
            }
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form8 fm = new Form8();
            fm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form18 frm = new Form18();
            frm.ShowDialog();
        }

       

        private void button18_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            this.Hide();
            Form5 fm = new Form5();
            fm.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            hide_sub_menu();
            this.Hide();
            Form2 fm = new Form2();
            fm.ShowDialog();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            hide_sub_menu(); 
            this.Hide();
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hide_sub_menu(); 
            this.Hide();
            Form7 f_open = new Form7();
            f_open.ShowDialog();

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form18 frm = new Form18();
            frm.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fm = new Form6();
            fm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 fm = new Form8();
            fm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 fm = new Form12();
            fm.ShowDialog();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOU LOGOUT");
            if (File.Exists(("Connection/atdu.txt")))
            {
                File.Delete(("Connection/atdu.txt"));
            }
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_add);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_view);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            show_sub_menue(panel_fee);
        }

        private void panel_sidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
