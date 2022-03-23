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
    public partial class Form13 : Form
    {
        string user;
        int rows, choice, option;
        public Form13()
        {
            InitializeComponent();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where [teacher]='"+user+"' AND [class]=" + Convert.ToInt32(comboBox1.SelectedItem) + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox2.Items.Clear();

            comboBox3.Items.Clear();

            comboBox3.Items.Add(dt.Rows[j].ItemArray[1]);

            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToString(dt.Rows[j].ItemArray[1]) != Convert.ToString(dt.Rows[i].ItemArray[1]))
                {
                    comboBox3.Items.Add(dt.Rows[i].ItemArray[1]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where [teacher]='"+user+"' AND [class]=" + Convert.ToInt32(comboBox1.SelectedItem) + " AND [section]='" + (comboBox3.SelectedItem) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox2.Items.Clear();
            comboBox2.Items.Add(dt.Rows[j].ItemArray[4]);




            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToString(dt.Rows[j].ItemArray[4]) != Convert.ToString(dt.Rows[i].ItemArray[4]))
                {
                    comboBox2.Items.Add(dt.Rows[i].ItemArray[4]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
            button3.Visible = false; ;
            label3.Visible = false;
            button2.Visible = false;
            button5.Visible = false; 
            StreamReader fileu = new StreamReader(("Connection/ttdu.txt"), true);
             user = fileu.ReadLine();

            OleDbConnection connection = new OleDbConnection();
            StreamReader file = new StreamReader(("Connection/Connection.txt"), true);
            String con = file.ReadLine();
            connection.ConnectionString = con;
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lenovo\Desktop\New folder\New folder\New folder\Information123.mdb");
            connection.Open();
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table6 where teacher='"+user+"'";

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            connection.Close();
            int j = 0;
            comboBox1.Items.Add(dt.Rows[j].ItemArray[0]);

            for (int i = 1; i < dt.Rows.Count; i++)
            {

                if (Convert.ToInt32(dt.Rows[j].ItemArray[0]) != Convert.ToInt32(dt.Rows[i].ItemArray[0]))
                {
                    comboBox1.Items.Add(dt.Rows[i].ItemArray[0]);

                    j++;
                }
                else
                {
                    j++;
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                comboBox4.Visible = true;
                label3.Visible = true;
                comboBox4.Items.Add("25");
                comboBox4.SelectedItem = "25";

                option = 1;

                dataGridView1.Columns.Add("2", "QUIZ");
            }
            else if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                label3.Visible = false;
                comboBox4.SelectedItem = null;
                comboBox4.Visible = false;
                comboBox4.Items.Clear();
                dataGridView1.Columns.Remove("2");

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                comboBox4.Visible = true;
                label3.Visible = true;
                option = 2;
                comboBox4.Items.Add("25");
                comboBox4.SelectedItem = "25";

                dataGridView1.Columns.Add("3", "MID");
            }
            else if (checkBox3.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                label3.Visible = false;
                comboBox4.SelectedItem = null;
                comboBox4.Visible = false;
                comboBox4.Items.Clear();
                dataGridView1.Columns.Remove("3");

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Enabled = false;
                checkBox1.Enabled = false;
                comboBox4.Visible = true;
                label3.Visible = true;
                option = 3;
                comboBox4.Items.Add("50");
                dataGridView1.Columns.Add("4", "FINAL");
                comboBox4.SelectedItem = "50";

            }
            else if (checkBox3.Checked == false)
            {
                checkBox3.Enabled = true;
                checkBox1.Enabled = true;
                comboBox4.Visible = false;
                label3.Visible = false;
                comboBox4.SelectedItem = null;
                dataGridView1.Columns.Remove("4");
                comboBox4.Items.Clear();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null || comboBox2.SelectedItem == null || (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true))// || (checkBox1.Checked == true && (checkBox2.Checked == false && checkBox3.Checked == false)) || (checkBox2.Checked == true && (checkBox1.Checked == false && checkBox3.Checked == false)) || (checkBox3.Checked == true && (checkBox2.Checked == false && checkBox1.Checked == false)))
            {
                MessageBox.Show("EMPTY FIELD SELCT CLASS SECTION SUBJECT AND UPDATED MARKS FOR QUIZ/MID/FINAL");

            }

            else if (comboBox1.SelectedItem != null && comboBox3.SelectedItem != null && comboBox2.SelectedItem!=null && (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true))
            {
                try
                {
                    dataGridView1.Rows.Clear();

                    teacher obj = new teacher();
               
                    OleDbCommand cmmd = obj.update_marks(Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option);
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmmd);
                    da.Fill(dt);
                    
                    rows = dt.Rows.Count;


                    int i;
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("NO RECORD OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + "");
                        
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("DATA OF CLASS " + comboBox1.SelectedItem + " AND SECTION " + comboBox3.SelectedItem + "");
                        button3.Visible = true;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[0].ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[1].ToString();
                            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i].ItemArray[5].ToString();



                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("err" + ex);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {

                MessageBox.Show("EMPTY FIELDS");
            }

            else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                int i, j = 0,jj=0;


                for (i = 0; i < rows; i++)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    if (dataGridView1.Rows[i].Cells[2].Value == null || Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) == "-1")
                    {
                        DialogResult result = MessageBox.Show("SELECT OPTION YES TO ADD MARKS BY DEFFULT -1 OR NO TO ADD MARKS MANUALLY OF STUDENT           " + dataGridView1.Rows[i].Cells[0].Value.ToString(), "OPTION", buttons);
                        if (result == DialogResult.Yes)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = -1;
                        }
                        else
                        {
                            j = 1;
                            //break;
                        }

                    }
                }
                for (i = 0; i < rows; i++)
                {
                    MessageBoxButtons buttonss = MessageBoxButtons.YesNo;

                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value) > Convert.ToDecimal(comboBox4.SelectedItem))
                    {
                        DialogResult result = MessageBox.Show("MARKS IS GREATER THEN TOTAL MARKS SELECT YESS TO GIVE BY DEFAULT -1 OR NO TO ADD AGAIN         " + dataGridView1.Rows[i].Cells[0].Value.ToString(), "OPTION", buttonss);
                        if (result == DialogResult.Yes)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = -1;
                        }
                        else
                        {
                            jj = 1;
                            //break;
                        }

                    }

                }

                if (i++ == rows && j != 1 && jj != 1)
                {
                    button2.Visible = true;
                    button5.Visible = true;
                    dataGridView1.Enabled = false;

                    button3.Enabled = false;
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    label4.Enabled = false;
                    button1.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = false;

                }


            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button5.Visible = false;
            dataGridView1.Enabled = true;
            button3.Enabled = true;
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            button1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacher obj = new teacher();
            int check;
            int count = 0;

            if (option == 1)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value) == -1)
                    {
                        choice = 0;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;
                    }
                    else
                    {
                        choice = 1;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;

                    }

                }
                if (rows == count)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("MARKS ADDED SELECT YES FOR SAME FOAM OR NO FOR HOME PAGE" + option, "MARKS UPLOAD", buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Form13 fm = new Form13();
                        fm.ShowDialog();

                    }
                    else
                    {
                        this.Hide();
                        Form10 fm = new Form10();
                        fm.ShowDialog();

                    }
                }



            }
            if (option == 2)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value) == -1)
                    {
                        choice = 0;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;
                    }
                    else
                    {
                        choice = 1;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;
                    }
                }
                if (rows == count)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("MARKS ADDED SELECT YES FOR SAME FOAM OR NO FOR HOME PAGE" + option, "MARKS UPLOAD", buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Form13 fm = new Form13();
                        fm.ShowDialog();

                    }
                    else
                    {
                        this.Hide();
                        Form10 fm = new Form10();
                        fm.ShowDialog();

                    }
                }




            }
            if (option == 3)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value) == -1)
                    {
                        choice = 0;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;
                    }
                    else
                    {
                        choice = 1;
                        check = obj.upload_marks(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Convert.ToInt32(comboBox1.SelectedItem), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), option, Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value), choice);
                        count = count + check;
                    }
                }
                if (rows == count)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("MARKS ADDED SELECT YES FOR SAME FOAM OR NO FOR HOME PAGE" + option, "MARKS UPLOAD", buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Form13 fm = new Form13();
                        fm.ShowDialog();

                    }
                    else
                    {
                        this.Hide();
                        Form10 fm = new Form10();
                        fm.ShowDialog();

                    }
                }

            }


            //MessageBoxButtons buttonss = MessageBoxButtons.YesNo;
            //DialogResult resultt = MessageBox.Show("MARKS ADDED", "MARKS UPLOAD",buttonss);
            //if (resultt == DialogResult.Yes)
            //{
            //    this.Hide();
            //    Form11 fm = new Form11();
            //    fm.ShowDialog();
            //}
            //else
            //{
            //    this.Hide();
            //    Form10 fm = new Form10();
            //    fm.ShowDialog();

            //}

            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 fm = new Form10();
            fm.ShowDialog();
        }

    }
}