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
    public partial class Form16 : Form
    {
        OleDbConnection connection;
        public Form16()
        {
            InitializeComponent();
            connection = new OleDbConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 fm = new Form15();
            fm.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Microsoft Sans Serif",18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            StreamReader fileu = new StreamReader(("Connection/stdu.txt"), true);
            String user = fileu.ReadLine();


            StreamReader filep = new StreamReader(("Connection/stdp.txt"), true);
            String pass = filep.ReadLine();


            fileu.Dispose();
            fileu.Close();
            filep.Dispose();
            filep.Close();


            student obj = new student();
            OleDbCommand command = obj.search_by_cnic(user, Convert.ToDouble(pass));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            //----------------------------------------------------

            student std = new student();
            OleDbCommand cmd = std.show_fees_data(Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()));
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adapt = new OleDbDataAdapter(cmd);
            adapt.Fill(dt2);
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("CHALLAN NOT GENERATED");
                button1.Enabled = true;
 
            }
            else if (dt2.Rows.Count > 0)
            {

                richTextBox1.Text += "            ***********ALKARAM PUBLIC SCHOOL**********\n";
                richTextBox1.Text += "\n";
                richTextBox1.Text += "            ---------------FEES CHALLAN--------------\n\n\n\n";
                richTextBox1.Text += "\tCode No :\t" + dt2.Rows[0].ItemArray[7].ToString() + "\n\n";
                richTextBox1.Text += "\tRoll No :\t" + dt2.Rows[0].ItemArray[1].ToString() + "\n\n";
                richTextBox1.Text += "\tStudent Name :\t" + dt2.Rows[0].ItemArray[0].ToString() + "\n\n";
                richTextBox1.Text += "\tFather Name :\t" + dt.Rows[0].ItemArray[2].ToString() + "\n\n";
                richTextBox1.Text += "\tClass :\t\t" + dt2.Rows[0].ItemArray[2].ToString() + "\n\n";
                richTextBox1.Text += "\tSection :\t" + dt2.Rows[0].ItemArray[3].ToString() + "\n\n";
                richTextBox1.Text += "\tIssue Date :\t" + dt2.Rows[0].ItemArray[5].ToString() + "\n\n";
                richTextBox1.Text += "\tDue Date :\t" + dt2.Rows[0].ItemArray[6].ToString() + "\n\n";
                richTextBox1.Text += "\t***** Amount ***** :\n\tPKR----" + dt2.Rows[0].ItemArray[4].ToString() + "---- ONLY\n\n\n";
                richTextBox1.Text += "\t\t\tBank Stamp : __________________\n\n";


            }
            richTextBox1.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
