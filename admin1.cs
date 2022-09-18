using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project6
{
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        //หน้าlogin
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "zhousu" && textBox_pass.Text == "111245")
            {
                adminselect f1 = new adminselect();
                f1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error");
            }
        }

        //กลับไปหน้าหลัก
        private void btn_backadmin_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Close();
        }
    }
}
