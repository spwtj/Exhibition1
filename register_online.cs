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
    public partial class register_online : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=exhibition;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public register_online()
        {
            InitializeComponent();
            
        }

        //โชว์รูปในpicture box
        private void registeronline_Load(object sender, EventArgs e)
        {
            pictureBoxll.Image = imageListll.Images[0];
        }
       
        //ปุ่มเลื่อนภาพ
        int count = 0;
        private void button_next_Click(object sender, EventArgs e)
        {
            if (count <1 ) 
            {
                count++;
            }
            label_showcount.Text = (count + 1).ToString();
           pictureBoxll.Image = imageListll.Images[count];
        }
        private void button_backslide_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
            }
            label_showcount.Text = (count + 1).ToString();
            pictureBoxll.Image = imageListll.Images[count];
        }

        //เลือกcomboboxโชว์ภาพ
        private void comboBox_chooseexh_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox_chooseexh.Text == "Picture love & like")
            {
                pictureBoxll.Image = imageListll.Images[0];
                label_showcount.Text = "1".ToString();

            }
            else if (comboBox_chooseexh.Text == "Drawing with Ten Lee")
            {
                pictureBoxll.Image = imageListll.Images[1];
                label_showcount.Text = "2".ToString();
            }
        }

        //บันทึกข้อมูล
        private void btn_regisol_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string mergemail = text_emailol.Text + comboBox_email.Text;
            if ( text_nameol.Text == "" || text_ageol.Text == "" || text_phoneol.Text == "" || text_emailol.Text == "" || comboBox_email.Text == "" || comboBox_chooseexh.Text == "")
            {
                MessageBox.Show("Fill the entry field!", "Warning");
            }
            else if (text_phoneol.Text.Length != 10)
            {
                MessageBox.Show("Phone : Please enter the correct phone number.", "Warning");
            }
            else
            {
                //เลือนิทรรศการเพื่อเก็บข้อมูล
                if (comboBox_chooseexh.Text == "Picture love & like")
                {
                    String sql = "INSERT INTO picture (name,age,phone,email) VALUES('" + text_nameol.Text + "', '" + text_ageol.Text + "', '" + text_phoneol.Text + "', '" + mergemail + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("Stored successfully", "Success");
                        System.Diagnostics.Process.Start("https://spatial.io/s/zhousus-Virtual-Scene-62b191d04d11d70001b2ea35?share=1630357402758096445&fbclid=IwAR020VvhFyhfxJkNGqax7TaO3_lcpDApbkrwVAgAS2N-f15xLMA12PXkeWs");

                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Close();
                    }

                }
                else if (comboBox_chooseexh.Text == "Drawing with Ten Lee")
                {
                    String sql = "INSERT INTO draw (name,age,phone,email) VALUES('" + text_nameol.Text + "', '" + text_ageol.Text + "', '" + text_phoneol.Text + "', '" + mergemail + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("Stored successfully", "Success");
                        System.Diagnostics.Process.Start("https://spatial.io/s/zhousus-Lo-Fi-Scene-62bb4416233a7b00019cdf79?share=6406317368963645352");

                        Form1 f2 = new Form1();
                        f2.Show();
                        this.Close();
                    }
                }
            }
           
        }

        //กลับไปที่หน้าguide
        private void btn_backol_Click(object sender, EventArgs e)
        {
            online_guide f3 = new online_guide();
            f3.Show();
            this.Close();
        }
        //เช็คการกรอกข้อมูล
        //ชื่อ
        private void text_nameol_KeyPress(object sender, KeyPressEventArgs e)
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
        private void text_ageol_KeyPress(object sender, KeyPressEventArgs e)
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
        private void text_phoneol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
            else if(e.Handled = (e.KeyChar == (char)Keys.Space))
                {
                MessageBox.Show("Do not enter spaces!", "Warning");
            }
            else
            {
                e.Handled = false;
            }

        }

        //email
        private void text_emailol_KeyPress(object sender, KeyPressEventArgs e)
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
