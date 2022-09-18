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
    public partial class online_guide : Form
    {
        public online_guide()
        {
            InitializeComponent();
        }

        //ไปหน้าสมัครออนไลน์
        private void btn_nextregis_Click(object sender, EventArgs e)
        {
            register_online f1 = new register_online();
            f1.Show();
            this.Close();
        }

        //กลับไปหน้าแรก
        private void btn_backform_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
