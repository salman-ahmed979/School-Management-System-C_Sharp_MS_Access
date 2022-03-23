using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;


namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class profile : UserControl
    {
        public profile()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void profile_Load(object sender, EventArgs e)
        {
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            StreamReader fileu = new StreamReader(("Connection/stdu.txt"), true);
            String user = fileu.ReadLine();


            StreamReader filep = new StreamReader(("Connection/stdp.txt"), true);
            String pass = filep.ReadLine();

            student obj = new student();
            OleDbCommand command = obj.search_by_cnic(user, Convert.ToDouble(pass));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
           // MessageBox.Show("" + dt.Rows.Count);
            label11.Text = dt.Rows[0].ItemArray[1].ToString();
            label12.Text = dt.Rows[0].ItemArray[2].ToString();
            label13.Text = dt.Rows[0].ItemArray[14].ToString();
            label14.Text = dt.Rows[0].ItemArray[15].ToString();
            label15.Text = dt.Rows[0].ItemArray[11].ToString();
            label16.Text = dt.Rows[0].ItemArray[7].ToString();
            label17.Text = dt.Rows[0].ItemArray[6].ToString();
            label18.Text = dt.Rows[0].ItemArray[3].ToString();
            label19.Text = dt.Rows[0].ItemArray[4].ToString();
            pictureBox1.Image = Image.FromFile(dt.Rows[0].ItemArray[18].ToString());
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 fm = new Form15();
            fm.ShowDialog();
        }
    }
}
