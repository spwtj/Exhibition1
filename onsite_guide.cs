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
    public partial class onsite_guide : Form
    {
        public onsite_guide()
        {
            InitializeComponent();
        }

        //ไปหน้าสมัครออนไซต์
        private void btn_regisonsite_Click_1(object sender, EventArgs e)
        {
            register_onsite f2 = new register_onsite();
            f2.Show();
            this.Close();
        }

        //กลับไปหน้าหลัก
        private void btn_backonsite_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
