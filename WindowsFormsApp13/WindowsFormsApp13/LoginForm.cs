using MySql.Data.MySqlClient;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You want to exit application", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string myConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
            MySqlConnection con = null;
            MySqlCommand cmd;
            MySqlDataReader dr;
            try
            {
                con = new MySqlConnection(myConnectionString);
                con.Open();
                //label5.Text = "con su";
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM login_tb WHERE UserName='" + textBox1.Text + "' AND Password='" + textBox2.Text + "' ";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   // MessageBox.Show("Success");
                    this.Hide();
                    Mainform mf = new Mainform();
                    mf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Enter the correct username and password");
                }
                
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
