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

            SqlConnection con = null;

            try
            {
                con = new SqlConnection(@"Data Source=PREDATOR-ASIF;Initial Catalog=Resturant Management System;Integrated Security=True;TrustServerCertificate=True");
                con.Open();

                

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

