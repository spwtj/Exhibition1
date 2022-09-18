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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ไปหน้าonline
        private void online_ex_Click(object sender, EventArgs e)
        {
            online_guide f1 = new online_guide();
            f1.Show();
            this.Hide();
        }

        //ไปหน้าonsite
        private void onsite_ex_Click(object sender, EventArgs e)
        {
            onsite_guide f2 = new onsite_guide();
            f2.Show();
            this.Hide();
        }

        //ไปหน้าadmin
        private void linkLabel_admin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            admin1 f2 = new admin1();
            f2.Show();
            this.Hide();
        }
    }
}
