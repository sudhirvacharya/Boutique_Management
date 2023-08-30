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
    public partial class Mainform : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public Mainform()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
        }

        

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewForm nf = new NewForm();
            nf.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //NewForm nf = new NewForm();
            //nf.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm rp = new ReportForm();
            rp.ShowDialog();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            string query = "Select SUM(Total) From sell_db";
            con.Open();
            cmd = new MySqlCommand(query, con);
            Int32 fuc = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label10.Text = "Total Purchase Amount  =" + fuc.ToString();
            

            string queryquantity = "Select SUM(Quantity) From sell_db";
            con.Open();
            cmd = new MySqlCommand(queryquantity, con);
            Int32 fuc1 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label5.Text = "Total Purchase Quantitys =" + fuc1.ToString();

            string queryorder = "Select SUM(Total) From order_db";
            con.Open();
            cmd = new MySqlCommand(queryorder, con);
            Int32 fuc2 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label6.Text = "Total Order Amount =" + fuc2.ToString();

            string queryorderquantity = "Select SUM(Quantity) From order_db";
            con.Open();
            cmd = new MySqlCommand(queryorderquantity, con);
            Int32 fuc3 = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            label7.Text = "Total Order Quantity =" + fuc3.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminloginForm adf = new adminloginForm();
            adf.ShowDialog();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewForm nf = new NewForm();
            nf.ShowDialog();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            wForm wf = new wForm();
            wf.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            BabyForm bf = new BabyForm();
            bf.ShowDialog();
        }
    }
}
