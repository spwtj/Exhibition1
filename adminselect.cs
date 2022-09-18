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
    public partial class adminselect : Form
    {
        public adminselect()
        {
            InitializeComponent();
        }

        //ไปหน้าadmin online
        private void online_ex_Click(object sender, EventArgs e)
        {
            admin_online1 f1 = new admin_online1();
            f1.Show();
            this.Close();
        }

        //ไปหน้าadmin onsite
        private void onsite_ex_Click(object sender, EventArgs e)
        {
            admin_onsite f2 = new admin_onsite();
            f2.Show();
            this.Close();
        }

        //ปุ่มlogout
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult confirmlogout = MessageBox.Show("You want to logout?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmlogout == DialogResult.Yes)
            {
                Form1 f3 = new Form1();
                f3.Show();
                this.Close();
            }
            else if (confirmlogout == DialogResult.No)
            {
                //nothing
            }
        }
    }
}
