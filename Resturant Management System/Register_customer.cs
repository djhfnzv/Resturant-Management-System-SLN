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
                return; 
            }
            else
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }

                SqlConnection con = null;

            try
            {

                string query = "INSERT INTO Customer_Information (Name, Gender, [Date of Birth], [Mobile Number],H_Address, Email,Pass_word)" +
                    "VALUES ('"+name+ "','"+gender+"','"+dob+"','"+phone+ "','"+address+ "','"+email+"','"+password+"')";

                if (DataAccess.ExecuteQuery(query)==true) 
                {
                    MessageBox.Show("Operation Executed");
                }

                MessageBox.Show("Resistered, thank you for signing up "+name, "Welcome");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database.\n\n" + ex.Message, "Error");
            }
            
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            bool isHidden = txtPassword.PasswordChar == '*';

            txtPassword.PasswordChar = isHidden ? '\0' : '*';
            txtiPassword.PasswordChar = isHidden ? '\0' : '*';
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();  
            home.Show();
        }
    }
}

