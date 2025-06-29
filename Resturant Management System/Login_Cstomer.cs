using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant_Management_System
{
    public partial class Login_Cstomer: Form
    {
        public Login_Cstomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;

            try
            {
                string email = txtEmail.Text;
                string password = txtiPassword.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both Email and Password.", "Validation Error");
                    return;
                }

                string query = $"SELECT * FROM Customer_Information WHERE Email = '{email}' AND Pass_word = '{password}'";

                var data = DataAccess.GetData(query);


                if (data != null && data.Rows.Count > 0)
                {
                    // Login successful
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // You can pass user info here if needed
                    Customer_View_Menu dashboard = new Customer_View_Menu(); // You must have this form
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database.\n\n" + ex.Message, "Error");
            }


        }
    }
}
