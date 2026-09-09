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
    public static class Session
    {
        public static string CustomerName { get; set; }
    }
    public partial class Login_Cstomer: Form
    {
        public Login_Cstomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            try
            {
                string name = txtName.Text;
                string password = txtiPassword.Text;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both Name and Password.", "Validation Error");
                    return;
                }

                string query = $"SELECT * FROM Customer_Information WHERE Name = '{name}' AND Pass_word = '{password}'";

                var data = DataAccess.GetData(query);


                if (data != null && data.Rows.Count > 0)
                {
                    Session.CustomerName = name;
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Customer_View_Menu menu = new Customer_View_Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
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
