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
    public partial class view_announcement : UserControl
    {
        public view_announcement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader fileu = new StreamReader(("Connection/stdu.txt"), true);
            String user = fileu.ReadLine();


            StreamReader filep = new StreamReader(("Connection/stdp.txt"), true);
            String pass = filep.ReadLine();

            student obj = new student();
            OleDbCommand command = obj.search_by_cnic(user, Convert.ToDouble(pass));
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);

            int clas = Convert.ToInt32(dt.Rows[0].ItemArray[14].ToString());
            string section = dt.Rows[0].ItemArray[15].ToString();

            
            OleDbCommand cmd = obj.student_view(section,clas,0);
            DataTable dtt = new DataTable();
            OleDbDataAdapter daa = new OleDbDataAdapter(cmd);
            daa.Fill(dtt);
           
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dtt.Rows[i].ItemArray[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dtt.Rows[i].ItemArray[3].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dtt.Rows[i].ItemArray[4].ToString();
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 fm = new Form15();
            fm.ShowDialog();
        }
    }
}
