using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class adminloginForm : Form
    {
        public adminloginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                adminForm af = new adminForm();
                af.Show();
            }
            else
            {
                MessageBox.Show("If You are Admin,Please Enter the correct username and password");
            }
        }
    }
}
