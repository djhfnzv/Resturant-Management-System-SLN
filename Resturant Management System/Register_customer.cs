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
    public partial class Register_customer: Form
    {
        public Register_customer()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string email = this.txtEmail.Text;
            string password = this.txtPassword.Text;
            string ipassword = this.txtiPassword.Text;
            string name = this.txtName.Text;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            DateTime dob = this.dtpDOB.Value;
            var gender = this.rbtnMale.Checked ? "Male" : this.rbtnFemale.Checked ? "Female" : " ";

            if (ipassword != password)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtiPassword.Focus();
                return; // Stop further execution
            }
            else
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution
                }
            }

                SqlConnection con = null;

            try
            {
                con = new SqlConnection(@"Data Source=PREDATOR-ASIF;Initial Catalog=Resturant Management System;Integrated Security=True;TrustServerCertificate=True");
                con.Open();

                string query = "INSERT INTO Customer_Information (Name, Gender, [Date of Birth], [Mobile Number],H_Address, Email,Pass_word)" +
                    "VALUES ('"+name+ "','"+gender+"','"+dob+"','"+phone+ "','"+address+ "','"+email+"','"+password+"')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Resistered, thank you for signing up "+name, "Welcome");

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

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            this.txtPassword.PasswordChar = this.txtPassword.PasswordChar == '\0' ? '*' : '\0';
            this.txtiPassword.PasswordChar = this.txtPassword.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}

