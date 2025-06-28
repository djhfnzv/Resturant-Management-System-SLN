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
                con = new SqlConnection(@"Data Source=PREDATOR-ASIF;Initial Catalog=Resturant Management System;Integrated Security=True;TrustServerCertificate=True");
                con.Open();

                string query = "SELECT * FROM Customer_Information WHERE Email = @Email AND Pass_word = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtiPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Login successful
                    MessageBox.Show("Login Successful", "Welcome");
                    this.Hide(); // Hide login form
                    Customer_View_Menu h = new Customer_View_Menu();
                    h.Show();
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Incorrect email or password", "Login Failed");
                    txtEmail.Clear();
                    txtiPassword.Clear();
                    txtEmail.Focus(); // Optionally set focus back to email input
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database.\n\n" + ex.Message, "Error");
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }
    }
}
