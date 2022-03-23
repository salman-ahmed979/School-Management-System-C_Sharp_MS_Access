using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class teacher_view : UserControl
    {
        public teacher_view()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 fm = new Form10();
            fm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader filep = new StreamReader(("Connection/atdu.txt"), true);
            String category = filep.ReadLine();



            teacher obj = new teacher();
            OleDbCommand cmd = obj.view_teacher_announcement(category);
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
    }
}
