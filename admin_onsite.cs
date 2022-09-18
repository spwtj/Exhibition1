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
    public partial class admin_onsite : Form
    {
        public admin_onsite()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=exhibition;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        //โชว์ข้อมูล
        private void showvisitor_onsite()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stars";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView_onsite.DataSource = ds.Tables[0].DefaultView;
            
        }

        //นับจำนวนผู้เข้าชม
        private void countvisitor()
        {
            MySqlConnection conn = databaseConnection();
            String sql = "SELECT * FROM stars";
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
        //เรียกใช้ฟังก์ชัน
        private void admin_onsite_Load(object sender, EventArgs e)
        {
            showvisitor_onsite();
            countvisitor();
        }

        //ค้นหาข้อมูล
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (textBox_search.Text != "")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();

                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM stars WHERE name LIKE '" + "%" + textBox_search.Text.Trim() + "%" + "'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                conn.Close();

                dataGridView_onsite.DataSource = ds.Tables[0].DefaultView;
            }           
        }

        //โชว์ข้อมูลทั้งหมด
        private void btn_viewall_Click(object sender, EventArgs e)
        {
            showvisitor_onsite();
        }

        //ลบข้อมูล
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult confirmdelete = MessageBox.Show("Are you sure you want to delete this record?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmdelete == DialogResult.Yes)
            {
                int selectedRow = dataGridView_onsite.CurrentCell.RowIndex;
                int deleteID = Convert.ToInt32(dataGridView_onsite.Rows[selectedRow].Cells["id"].Value);

                MySqlConnection conn = databaseConnection();

                String sql = "DELETE FROM stars WHERE id = '" + deleteID + "' ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();
            }
            else if (confirmdelete == DialogResult.No)
            {
                //nothing
            }
            showvisitor_onsite();
            countvisitor();
        }
        
        //ออกจากระบบ
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
