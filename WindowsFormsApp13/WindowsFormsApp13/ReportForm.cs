using DGVPrinterHelper;
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
    public partial class ReportForm : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public ReportForm()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                string query = "select * from sell_db ";
                coman.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                string query = "select * from order_db ";
                coman.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform mf = new Mainform();
            mf.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "CODE SPACE YOUTUBE CHANNEL";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Footer";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView2);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
           
        }
    }
}
