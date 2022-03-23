using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STUDENT_MANAGEMENT_SYSTEM
{
    public partial class location : UserControl
    {
        public location()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string location = "alkaram public school";
            try
            {
                StringBuilder querryaddress = new StringBuilder();
                querryaddress.Append("https://maps.google.com/maps?q=");
                if (location != string.Empty)
                {
                   querryaddress.Append(location + "," + "+");

                }
                webBrowser1.Navigate(querryaddress.ToString());

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString(), "ERROR");
            }
        }
    }
}
