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
    public partial class adminForm : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();

        public object Photo { get; private set; }

        public adminForm()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=user_infotb;userid=root;password=;";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mainform mf = new Mainform();
            mf.ShowDialog();
        }

        private void label20_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                string query = "select * from man_db ";
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

        private void label12_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                MySqlCommand coman = new MySqlCommand();
                coman.Connection = con;
                string query = "select * from woman_db ";
                coman.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
                string query = "select * from baby_db ";
                coman.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(coman);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox6.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Photo, 0, Photo.Length);

                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO man_db(ID,ProductTypes,Size,Colour,Stocks,Prices,Photo) Values ('" + text_id.Text + "','" + text_type.Text + "','" + text_size.Text + "','" + text_colour.Text + "','" + text_stock.Text + "','" + text_price.Text + "',@photo)";
                cmd.Parameters.AddWithValue("@photo", Photo);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Save Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(fd.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(fd.FileName);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image = Image.FromFile(fd.FileName);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                string updatequery = "UPDATE man_db  SET ID = '" + text_id.Text + "',ProductTypes = '" + text_type.Text + "', Size = '"+ text_size.Text + "',Colour = '" + text_colour.Text + "',Stocks = '" + text_stock.Text + "',Prices = '" + text_price.Text + "' WHERE ID= '" + text_id.Text + "' ";
                MySqlCommand coman = new MySqlCommand(updatequery, con);
                MySqlDataReader rd;
                con.Open();
                rd = coman.ExecuteReader();
                MessageBox.Show("Data Updated");
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string deletequery = "DELETE FROM man_db  WHERE ID = '"+text_id.Text+"'  ";
                MySqlCommand coman = new MySqlCommand(deletequery, con);
                MySqlDataReader rd;
                con.Open();
                rd = coman.ExecuteReader();
                MessageBox.Show("Data Deleted");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            text_id.Text = "";
            text_type.Text = "";
            text_size.Text = "";
            text_colour.Text = "";
            text_stock.Text = "";
            text_price.Text = "";
            pictureBox6.Image = null;
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

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox4.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] Photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Photo, 0, Photo.Length);

                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO woman_db(ID,ProductTypes,Size,Colour,Stocks,Prices,Photo) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox12.Text + "',@photo)";
                cmd.Parameters.AddWithValue("@photo", Photo);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Save Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                string updatequery = "UPDATE woman_db  SET ID = '" + text_id.Text + "',ProductTypes = '" + text_type.Text + "', Size = '" + text_size.Text + "',Colour = '" + text_colour.Text + "',Stocks = '" + text_stock.Text + "',Prices = '" + text_price.Text + "' WHERE ID= '" + text_id.Text + "' ";
                MySqlCommand coman = new MySqlCommand(updatequery, con);
                MySqlDataReader rd;
                con.Open();
                rd = coman.ExecuteReader();
                MessageBox.Show("Data Updated");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                string deletequery = "DELETE FROM woman_db  WHERE ID = '" + text_id.Text + "'  ";
                MySqlCommand coman = new MySqlCommand(deletequery, con);
                MySqlDataReader rd;
                con.Open();
                rd = coman.ExecuteReader();
                MessageBox.Show("Data Deleted");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            text_id.Text = "";
            text_type.Text = "";
            text_size.Text = "";
            text_colour.Text = "";
            text_stock.Text = "";
            text_price.Text = "";
            pictureBox4.Image = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["ID"].Value.ToString();
            textBox2.Text = row.Cells["ProductTypes"].Value.ToString();
            textBox3.Text = row.Cells["Size"].Value.ToString();
            textBox4.Text = row.Cells["Colour"].Value.ToString();
            textBox5.Text = row.Cells["Stocks"].Value.ToString();
            textBox12.Text = row.Cells["Prices"].Value.ToString();

            //image display
            byte[] bytes = (byte[])dataGridView1.CurrentRow.Cells["Photo"].Value;
            MemoryStream ms = new MemoryStream(bytes);
            pictureBox4.Image = Image.FromStream(ms);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
