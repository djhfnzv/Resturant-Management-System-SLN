using Resturant_Management_System;
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
    public partial class Home: Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide(); // hides the current form
            Register_customer h = new Register_customer();
            h.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); // hides the current form
            Login_Cstomer h = new Login_Cstomer();
            h.Show();
        }
    }
}

