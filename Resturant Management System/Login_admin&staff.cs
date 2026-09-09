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
    public static class SessionAdmin
    {
        public static string UserID { get; set; }
    }
    public partial class Login_admin_staff: Form
    {
        public Login_admin_staff()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string userId = txtID.Text.ToString();
                string password = txtPassword.Text.ToString();

                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both ID and Password.");
                    return;
                }

                if (userId.StartsWith("001-") || userId.StartsWith("010-") || userId.StartsWith("011-") || userId.StartsWith("100-"))
                {
                    string query = $"SELECT * FROM Manager WHERE manager_id = '{userId}' AND password = '{password}'";
                    DataTable dt = DataAccess.GetData(query);

                    if (dt.Rows.Count == 1)
                    {
                        SessionAdmin.UserID = userId;
                        string role = dt.Rows[0]["role"].ToString().ToLower();

                        this.Hide();

                        if (role == "general manager")
                        {
                            GM_View gm = new GM_View();
                            gm.Show();
                        }
                        else if (role == "assistant manager")
                        {
                            AM_View am = new AM_View();
                            am.Show();
                        }
                        else if (role == "kitchen manager")
                        {
                            KM_View km = new KM_View();
                            km.Show();
                        }
                        else if (role == "floor manager")
                        {
                            FM_View fm = new FM_View();
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role assigned.");
                            this.Show();
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Manager ID or Password.");
                        return;
                    }
                }

                
                else if (userId.StartsWith("002-"))
                {
                    string query = $"SELECT * FROM Staff WHERE staff_id = '{userId}' AND password = '{password}'";
                    DataTable dt = DataAccess.GetData(query);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Staff accounts are currently inactive.");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Staff ID or Password.");
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid ID format.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
