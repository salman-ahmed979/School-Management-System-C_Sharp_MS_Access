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
    public partial class marks_check : UserControl
    {
        public marks_check()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 fm = new Form15();
            fm.ShowDialog();
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

            int rollno = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());

            //-//---------------------------------------------------------------------------------------

            // for quiz
            OleDbCommand cmd2 = obj.marks_view(rollno,1); 
            DataTable dt2 = new DataTable();
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            da2.Fill(dt2);
            
            //for mid

            OleDbCommand cmd3=obj.marks_view(rollno,2);
            DataTable dt3 = new DataTable();
            OleDbDataAdapter da3 = new OleDbDataAdapter(cmd3);
            da3.Fill(dt3);
            

           // for final
            OleDbCommand cmd4 = obj.marks_view(rollno, 3);
            DataTable dt4 = new DataTable();
            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            da4.Fill(dt4);
            //------------------------------------------------------------------
            
            int q = 0, m = 0, f = 0;

            for (q = 0; q < dt2.Rows.Count; q++)
            {
                dataGridView1.Rows[q].Cells[0].Value = dt2.Rows[q].ItemArray[4].ToString();
                if (Convert.ToInt32(dt2.Rows[q].ItemArray[6].ToString()) == 1)
                {
                    dataGridView1.Rows[q].Cells[1].Value = dt2.Rows[q].ItemArray[5].ToString();

                }

                else { dataGridView1.Rows[q].Cells[1].Value = '-'; }


            }

            for (m = 0; m < dt3.Rows.Count; m++)
            {
                dataGridView2.Rows[m].Cells[0].Value = dt3.Rows[m].ItemArray[4].ToString();
                if (Convert.ToInt32(dt3.Rows[m].ItemArray[6].ToString()) == 1)
                {
                    dataGridView2.Rows[m].Cells[1].Value = dt3.Rows[m].ItemArray[5].ToString();

                }

                else { dataGridView2.Rows[m].Cells[1].Value = '-'; }


            }

            for (f = 0; f < dt4.Rows.Count; f++)
            {
                dataGridView3.Rows[f].Cells[0].Value = dt4.Rows[f].ItemArray[4].ToString();
                if (Convert.ToInt32(dt4.Rows[f].ItemArray[6].ToString()) == 1)
                {
                    dataGridView3.Rows[f].Cells[1].Value = dt4.Rows[f].ItemArray[5].ToString();

                }

                else { dataGridView3.Rows[f].Cells[1].Value = '-'; }


            }
       

            

      
            

        }
    }
}
