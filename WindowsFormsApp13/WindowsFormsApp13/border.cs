using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
        public partial class border : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public border()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        }

        private void border_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                string query = "select * from baby_db ";
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

        private void text_quantity_TextChanged(object sender, EventArgs e)
        {
            if (text_quantity.Text.Length > 0)
            {
                text_total.Text = (Convert.ToInt16(text_price.Text) * Convert.ToInt16(text_quantity.Text)).ToString();
            }
        }

        private void text_payamount_TextChanged(object sender, EventArgs e)
        {
            if (text_payamount.Text.Length > 0)
            {
                text_repayamount.Text = (Convert.ToInt16(text_totalamount.Text) - Convert.ToInt16(text_payamount.Text)).ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            text_id.Text = row.Cells["ID"].Value.ToString();
            text_type.Text = row.Cells["ProductTypes"].Value.ToString();
            text_size.Text = row.Cells["Size"].Value.ToString();
            text_colour.Text = row.Cells["Colour"].Value.ToString();
            text_stock.Text = row.Cells["Stocks"].Value.ToString();
            text_price.Text = row.Cells["Prices"].Value.ToString();

            //image display
            byte[] bytes = (byte[])dataGridView2.CurrentRow.Cells["Photo"].Value;
            MemoryStream ms = new MemoryStream(bytes);
            pictureBox6.Image = Image.FromStream(ms);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string[] arr = new string[7];
            arr[0] = text_id.Text;
            arr[1] = text_type.Text;
            arr[2] = text_size.Text;
            arr[3] = text_colour.Text;
            arr[4] = text_price.Text;
            arr[5] = text_quantity.Text;
            arr[6] = text_total.Text;

            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);

            text_totalamount.Text = (Convert.ToInt16(text_totalamount.Text) + Convert.ToInt16(text_total.Text)).ToString();

            int var_stocks = 0;
            int var_sell = 0;
            int result = 0;
            var_stocks = Convert.ToInt32(text_stock.Text);
            var_sell = Convert.ToInt32(text_quantity.Text);
            result = var_stocks - var_sell;

            string updatequery = "UPDATE baby_db  SET Stocks = '" + result + "' WHERE ID= '" + text_id.Text + "' ";
            con.Open();
            MySqlCommand coman = new MySqlCommand(updatequery, con);
            coman.ExecuteNonQuery();
            con.Close();

            con.Open();
            MySqlCommand coman1 = new MySqlCommand();
            coman1.Connection = con;
            string query = "select * from baby_db ";
            coman1.CommandText = query;
            MySqlDataAdapter da = new MySqlDataAdapter(coman1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            text_id.Text = "";
            text_type.Text = "";
            text_size.Text = "";
            text_colour.Text = "";
            text_price.Text = "";
            text_quantity.Text = "";
            text_stock.Text = "";
            text_total.Text = "";
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int var_stocks = 0;
            int var_sell = 0;
            int result = 0;
            var_stocks = Convert.ToInt32(text_stock.Text);
            var_sell = Convert.ToInt32(text_quantity.Text);
            result = var_stocks + var_sell;

            string updatequery = "UPDATE baby_db  SET Stocks = '" + result + "' WHERE ID= '" + text_id.Text + "' ";
            con.Open();
            MySqlCommand coman = new MySqlCommand(updatequery, con);
            coman.ExecuteNonQuery();
            con.Close();

            con.Open();
            MySqlCommand coman1 = new MySqlCommand();
            coman1.Connection = con;
            string query = "select * from baby_db ";
            coman1.CommandText = query;
            MySqlDataAdapter da = new MySqlDataAdapter(coman1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            text_id.Text = "";
            text_type.Text = "";
            text_size.Text = "";
            text_colour.Text = "";
            text_price.Text = "";
            text_quantity.Text = "";
            text_stock.Text = "";
            text_total.Text = "";


            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    text_totalamount.Text = (Convert.ToInt16(text_totalamount.Text) - Convert.ToInt16(listView1.Items[i].SubItems[4].Text)).ToString();
                    listView1.Items[i].Remove();
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    text_totalamount.Text = (Convert.ToInt16(text_totalamount.Text) - Convert.ToInt16(listView1.Items[i].SubItems[4].Text)).ToString();
                    listView1.Items[i].Remove();
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lst_item in listView1.Items)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO order_db(Types,Size,Colour,Prices,Quantity,Total,Date) Values (@Types,@Size,@Colour,@Prices,@Quantity,@Total,'" + dateTimePicker1.Text + "')", con);
                //cmd.Parameters.AddWithValue("@ID", lst_item.SubItems[0].Text);
                cmd.Parameters.AddWithValue("@Types", lst_item.SubItems[1].Text);
                cmd.Parameters.AddWithValue("@Size", lst_item.SubItems[2].Text);
                cmd.Parameters.AddWithValue("@Colour", lst_item.SubItems[3].Text);
                cmd.Parameters.AddWithValue("@Prices", lst_item.SubItems[4].Text);
                cmd.Parameters.AddWithValue("@Quantity", lst_item.SubItems[5].Text);
                cmd.Parameters.AddWithValue("@Total", lst_item.SubItems[6].Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Save Data");

            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform mf = new Mainform();
            mf.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm rp = new ReportForm();
            rp.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
        }
    }
}
