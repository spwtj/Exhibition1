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
    public partial class register_onsite : Form
    {
        public register_onsite()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=exhibition;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        //ปุ่มบันทึกข้อมูล
        public static string dateshow, nameshow, phoneshow;

        private void btn_regisos_Click(object sender, EventArgs e)
        {
            
            dateshow = comboBox_Day.Text;
            nameshow = text_nameos.Text;
            phoneshow = text_phoneos.Text;
            string mergemail = text_emailos.Text + comboBox_email.Text;
            if (text_nameos.Text == "" || text_ageos.Text == "" || text_phoneos.Text == "" || text_emailos.Text == "" || comboBox_email.Text == "" || comboBox_Day.Text == "")
            {
                MessageBox.Show("Fill the entry field!", "Warning");
            }
            else if (text_phoneos.Text.Length != 10)
            {
                MessageBox.Show("Phone : Please enter a valid phone number.", "Warning");
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                String sql = "INSERT INTO stars (name,age,phone,email,date) VALUES('" + text_nameos.Text + "', '" + text_ageos.Text + "', '" + text_phoneos.Text + "', '" + mergemail + "', '" + comboBox_Day.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Stored successfully", "Success");

                    donate f1 = new donate();
                    f1.Show();
                    this.Close();
                }
            }
        }

        //กลับไปหน้าguide
        private void btn_backos_Click(object sender, EventArgs e)
        {
            onsite_guide f2 = new onsite_guide();
            f2.Show();
            this.Close();
        }
        //เช็คการกรอกข้อมูล
        //ชื่อ
        private void text_nameos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Do not enter spaces!", "Warning");
            }
            else
            {
                e.Handled = false;
            }
        }

        //อายุ
        private void text_ageos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Do not enter spaces!", "Warning");
            }
            else
            {
                e.Handled = false;
            }
        }

        //เบอร์
        private void text_phoneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Do not enter spaces!", "Warning");
            }
            else
            {
                e.Handled = false;
            }
        }

        //email
        private void text_emailos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Do not enter spaces!", "Warning");
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
