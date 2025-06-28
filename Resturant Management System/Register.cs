using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant_Management_System
{
    public partial class Register: Form
    {
        public Register()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Data Saved", "Continue");
            this.Hide(); // hides the current form
            Home h = new Home();
            h.Show();
        }
    }
}
