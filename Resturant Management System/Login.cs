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
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Successful", "Welcome");
            this.Hide(); // hides the current form
            Customer_View_Menu h = new Customer_View_Menu();
            h.Show();

        }
    }
}
