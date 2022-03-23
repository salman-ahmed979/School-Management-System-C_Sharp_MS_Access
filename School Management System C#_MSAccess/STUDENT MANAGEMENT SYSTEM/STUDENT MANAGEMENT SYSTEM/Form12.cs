using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class Form12 : Form
    {
        int rows = 0,stop=0;
        
        int paidd = 0;
        public Form12()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             try
            {
                if (comboBox2.SelectedItem  == null || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please Select Class And section");
                }
                else if(comboBox2.SelectedItem != null || comboBox1.SelectedItem !=null)
                 {
                dataGridView1.Rows.Clear();
                student std = new student();
                OleDbCommand command = std.fees_data_fetch(Convert.ToInt32(comboBox2.SelectedItem),comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter(command);
                adapt.Fill(dt);
                
                rows = dt.Rows.Count;
               
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[1].ToString(); //Student Name
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[0].ToString(); //Roll no
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i].ItemArray[14].ToString();//Class
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i].ItemArray[15].ToString(); //Section
                }
            }}
            catch (Exception ex)
            {
                MessageBox.Show("Eror "+ ex); 
            }
        
           }

        private void button3_Click(object sender, EventArgs e)
        {

            admin obj = new admin();
            OleDbDataReader reader = null;
            reader = obj.fee_challan();
            int i = 0;
            int check = 0, checker=0;;
            int date_value_flag = 0;
            DateTime issuedate = dateTimePicker1.Value;
            issuedate = new DateTime(issuedate.Year, issuedate.Month, issuedate.Day, 0, 0, 0);
            DateTime duedate = dateTimePicker2.Value;
            duedate = new DateTime(duedate.Year, duedate.Month, duedate.Day, 0, 0, 0);
            int result = DateTime.Compare(issuedate, duedate);
            //MessageBox.Show("datecheck"+result);

            if (result == 0)
            {
                MessageBox.Show(issuedate.ToShortDateString() + " is same " + duedate.ToShortDateString() + ". Please re-type");
                date_value_flag = 1;
            }
            if (result > 0)
            {
                MessageBox.Show(issuedate.ToShortDateString() + " is later than " + duedate.ToShortDateString() + ". Please re-type");
                date_value_flag = 1;
            }
           // MessageBox.Show("flag"+date_value_flag);
            if (date_value_flag == 0)
            {
                while (reader.Read())
                {
                    check = 0;
                    Random rand = new Random();
                    int n = rand.Next(1000, 9000);
                    //MessageBox.Show("Roll no. " + reader.GetInt32(1));

                    if ((Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) == reader.GetInt32(1)))
                    {
                        MessageBox.Show("STUDENT No " + i);
                        MessageBox.Show("Working on Roll no. " + reader.GetInt32(1));
                        int classes = reader.GetInt32(2);
                        string section = reader.GetString(3);
                        double fee_amt = reader.GetDouble(4);
                       
                        DateTime database_due_date = reader.GetDateTime(6);
                        database_due_date = new DateTime(database_due_date.Year, database_due_date.Month, database_due_date.Day, 0, 0, 0);
                        int pd = reader.GetInt16(8);
                        if (Convert.ToInt32(comboBox2.SelectedItem) == classes && comboBox1.SelectedItem.ToString() == section)
                        {
                            checker = 1;
                            // if () // Date sahi banalena
                            int checker_date = DateTime.Compare(issuedate, database_due_date);
                            if (checker_date > 0)
                            {
                                if (pd != 1)
                                {

                                    double total_amount_value = Convert.ToDouble(textBox1.Text) + (fee_amt);
                                   
                                    obj.update_fee(total_amount_value, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), Convert.ToInt32(n), paidd, Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                                    check = 1;
                                    MessageBox.Show("Done! Data is Modified on Paid Column 0");
                                    i++;
                                }
                                if (check == 0 && pd == 1)
                                {
                                    obj.update_fee(Convert.ToDouble(textBox1.Text), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), Convert.ToInt32(n), paidd, Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                                    check = 1;
                                    MessageBox.Show("Done! Data is Modified on Paid Column 1");
                                    i += 1;
                                }
                            }
                            else
                            {
                                stop = 1;
                                MessageBox.Show("ERROR in Selecting Issue Date " + checker_date);
                            }

                        }





                    }
                    }
                    if (check == 0 && checker==0)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            Random random = new Random();
                            int nn = random.Next(1000, 9000);
                            obj.enter_fee(dataGridView1.Rows[j].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[j].Cells[1].Value), Convert.ToInt32(dataGridView1.Rows[j].Cells[2].Value), dataGridView1.Rows[j].Cells[3].Value.ToString(), Convert.ToDouble(textBox1.Text), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), Convert.ToInt32(nn), paidd);
                            MessageBox.Show("Done! New Data is Inserted");


                        }
                    }
                }
            }
        
             
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
             Form1 f=new Form1();
           f.ShowDialog();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
           // dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker1.Value = DateTime.Now.Date;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Int Value");

            }
        }

    }

    }
       