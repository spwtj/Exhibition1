using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project6
{
    public partial class admin_online1 : Form
    {
        public admin_online1()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=exhibition;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        //เลือก combobox ให้เลือกฟังก์ชันเพื่อเรียกใช้
        private void comboBox_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_select.Text == "Picture love & like")
            {
                showvisitor_picll();
                countvisitor_pic();
            }
            else if (comboBox_select.Text == "Drawing with Ten Lee")
            {
                showvisitor_draw();
                countvisitor_draw();
            }
        }

        //โชว์ข้อมูล
        //โชว์ picture love & like
        private void showvisitor_picll()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM picture";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView_picture.DataSource = ds.Tables[0].DefaultView;
        }
        //โชว์ draw with ten lee
        private void showvisitor_draw()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM draw";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView_picture.DataSource = ds.Tables[0].DefaultView;
        }

        //นับจำนวนผู้เช้าชม
        //นับ picture love & like
        private void countvisitor_pic()
        {
            MySqlConnection conn = databaseConnection();
            String sql = "SELECT * FROM picture";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            label_count.Text = count.ToString();
            count = 0;
            conn.Close();
        }
        //นับ draw with ten lee
        private void countvisitor_draw()
        {
            MySqlConnection conn = databaseConnection();
            String sql = "SELECT * FROM draw ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            label_count.Text = count.ToString();
            count = 0;
            conn.Close();
        }

        //ไม่ได้ใช้
        private void admin_online1_Load(object sender, EventArgs e)
        {  
        }

        //ค้นหา
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (comboBox_select.Text == "Picture love & like")
            {
                if (textBox_search.Text != "")
                {
                    MySqlConnection conn = databaseConnection();
                    DataSet ds = new DataSet();
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();                  
                    cmd.CommandText = "SELECT * FROM picture WHERE name LIKE '" + "%" + textBox_search.Text.Trim() + "%" + "'";
                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    conn.Close();

                    dataGridView_picture.DataSource = ds.Tables[0].DefaultView;
                }
            }
            else if (comboBox_select.Text == "Drawing with Ten Lee")
            {
                if (textBox_search.Text != "")
                {
                    MySqlConnection conn = databaseConnection();
                    DataSet ds = new DataSet();
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM draw WHERE name LIKE '" + "%" + textBox_search.Text.Trim() + "%" + "'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    conn.Close();

                    dataGridView_picture.DataSource = ds.Tables[0].DefaultView;
                }
            }
           
        }
        
        //ดูทั้งหมด
        private void btn_viewall_Click(object sender, EventArgs e)
        {
            if (comboBox_select.Text == "Picture love & like")
            {
                showvisitor_picll();
            }
            else if (comboBox_select.Text == "Drawing with Ten Lee")
            {
                showvisitor_draw();
            }
        }

        //ลบข้อมูล
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (comboBox_select.Text == "Picture love & like")
            {
                DialogResult confirmdelete = MessageBox.Show("Are you sure you want to delete this record?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmdelete == DialogResult.Yes)
                {
                    int selectedRow = dataGridView_picture.CurrentCell.RowIndex;
                    int deleteID = Convert.ToInt32(dataGridView_picture.Rows[selectedRow].Cells["id"].Value);

                    MySqlConnection conn = databaseConnection();

                    String sql = "DELETE FROM picture WHERE id = '" + deleteID + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                else if (confirmdelete == DialogResult.No)
                {
                    //nothing
                }
                showvisitor_picll();
                countvisitor_pic();
            }
            else if (comboBox_select.Text == "Drawing with Ten Lee")
            {
                DialogResult confirmdelete = MessageBox.Show("Are you sure you want to delete this record?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmdelete == DialogResult.Yes)
                {
                    int selectedRow = dataGridView_picture.CurrentCell.RowIndex;
                    int deleteID = Convert.ToInt32(dataGridView_picture.Rows[selectedRow].Cells["id"].Value);

                    MySqlConnection conn = databaseConnection();

                    String sql = "DELETE FROM draw WHERE id = '" + deleteID + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                else if (confirmdelete == DialogResult.No)
                {
                    //nothing
                }
                showvisitor_draw();
                countvisitor_draw();
            }    
        }

       

        //ปุ่ม logout
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult confirmlogout = MessageBox.Show("You you want to logout?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmlogout == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Close();
            }
            else if (confirmlogout == DialogResult.No)
            {
                //nothing
            }
        }

        //ปุ่มย้อนกลับไปหน้าเลือก
        private void btn_back_Click(object sender, EventArgs e)
        {
            adminselect f2 = new adminselect();
            f2.Show();
            this.Close();
        }

       
    }
}
