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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Resturant_Management_System
{
    public partial class btnJobApply: Form
    {
        public btnJobApply()
        {
            InitializeComponent();
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = this.txtEmail.Text;
            string name = this.txtName.Text;
            string age = this.txtAge.Text;
            string edu = this.txtEducation.Text ;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            DateTime dob = this.dtpDOB.Value;
            var gender = this.rbtnMale.Checked ? "Male" : this.rbtnFemale.Checked ? "Female" : " ";
            var post = cmbJobPost.SelectedItem?.ToString();


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email)  ||
                    string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(post))
                {
                    MessageBox.Show("Please fill in all fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution
                }
            

            SqlConnection con = null;

            try
            {

                string query = "INSERT INTO ApplicantList " +
    "(full_name, age, education, address, email, phone, dob, applied_category, gender) " +
    "VALUES ('" + name + "', '" + age + "', '" + edu + "', '" + address + "', '" + email + "', '" + phone + "', '" + dob.ToString("yyyy-MM-dd") + "', '" + post + "', '" + gender + "')";

                if (DataAccess.ExecuteQuery(query) == true)
                {
                    MessageBox.Show("Operation Executed");
                }

                MessageBox.Show("Resistered, thank you for signing up " + name, "Welcome");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database.\n\n" + ex.Message, "Error");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home();
            fm.Show();
        }
    }
}
