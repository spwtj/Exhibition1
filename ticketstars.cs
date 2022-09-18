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
    public partial class ticketstars : Form
    {
        public ticketstars()
        {
            InitializeComponent();
        }

        private void ticketstars_Shown(object sender, EventArgs e)
        {

        }

        //นำข้อมูลมาโชว์
        private void ticketstars_Load(object sender, EventArgs e)
        {
            label_date.Text = register_onsite.dateshow;
            label_name.Text = register_onsite.nameshow;
            label_phone.Text = register_onsite.phoneshow;
        }
    }
}
