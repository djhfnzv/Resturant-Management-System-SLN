using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Resturant_Management_System
{
    public partial class GM_View : Form
    {
        string currentManagerID = SessionAdmin.UserID;

       
        string table;
        public GM_View()
        {
            InitializeComponent();
            btnClear.Click += btnClear_Click;
            dgvTable.CellClick += dgvTable_CellClick;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }


        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabRecomonded.SelectedTab = tabStaff;
            table = "Staff";
            this.btnLoad_Click(null, null);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabMenu;
            table = "Menu";
            this.btnLoad_Click(null, null);
        }

        private void managersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabManager;
            table = "Manager";
            this.btnLoad_Click(null, null);
        }
        private void recomondationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabRecomondation;
            table = "Recommended";
            this.btnLoad_Click(null, null);
        }
        private void orderSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabSales;
            table = "Orders";
            this.btnLoad_Click(null, null);
        }

        private void Hide(bool x)
        {
            txtStaffID.ReadOnly = true;
            txtName.ReadOnly = x;
            txtAge.ReadOnly = x;
            txtEducation.ReadOnly = x;
            txtAddress.ReadOnly = x;
            txtEmail.ReadOnly = x;
            txtPhone.ReadOnly = x;
            txtDob.ReadOnly = x;
            txtCatagory.ReadOnly = x;
            txtPassword.ReadOnly = x;
            txtM_id.ReadOnly = x;
            txtSalary.ReadOnly = x;
            txtItemId.ReadOnly = x;
            txtIname.ReadOnly = x;
            txtFCatagory.ReadOnly = x;
            txtPrice.ReadOnly = x;

            txtMid.ReadOnly = x;
            txtMname.ReadOnly = x;
            txtMage.ReadOnly = x;
            txtMeducation.ReadOnly = x;
            txtMaddress.ReadOnly = x;
            txtMemail.ReadOnly = x;
            txtMphone.ReadOnly = x;
            txtMdob.ReadOnly = x;
            txtMrole.ReadOnly = x;
            txtMpassword.ReadOnly = x;

            txtRname.ReadOnly = x;
            txtReducation.ReadOnly = x;
            txtRaddress.ReadOnly = x;
            txtRemail.ReadOnly = x;
            txtRphone.ReadOnly = x;
            txtRdob.ReadOnly = x;
            txtRappliedcatagory.ReadOnly = x;
            txtRapplicationdate.ReadOnly = x;
            txtRrecommendedby.ReadOnly = x;
            txtGender.ReadOnly = x;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Hide(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Hide(true);

            try
            {
                string updateQuery = "";

                if (table == "Staff")
                {
                    string staffId = txtStaffID.Text;
                    string name = txtName.Text;
                    string age = txtAge.Text;
                    string education = txtEducation.Text;
                    string address = txtAddress.Text;
                    string email = txtEmail.Text;
                    string phone = txtPhone.Text;
                    string dob = txtDob.Text;
                    string category = txtCatagory.Text;
                    string password = txtPassword.Text;
                    string managerId = txtM_id.Text;
                    string salary = txtSalary.Text;

                    // ✅ Validate number fields
                    if (!int.TryParse(age, out _) || !decimal.TryParse(salary, out _))
                    {
                        MessageBox.Show("Invalid age or salary.");
                        return;
                    }

                    updateQuery = $@"
                                    UPDATE Staff SET
                                        name = '{name}',
                                        age = {age},
                                        education = '{education}',
                                        address = '{address}',
                                        email = '{email}',
                                        phone = '{phone}',
                                        dob = '{dob}',
                                        Catagory = '{category}',
                                        password = '{password}',
                                        manager_id = '{managerId}',
                                        salary = {salary}
                                    WHERE staff_id = '{staffId}';";
                }
                else if (table == "Menu")
                {
                    string itemId = txtItemId.Text;
                    string category = txtFCatagory.Text;
                    string itemName = txtIname.Text;
                    string priceText = txtPrice.Text;

                    // ✅ Validate price
                    if (!decimal.TryParse(priceText, out decimal price))
                    {
                        MessageBox.Show("Invalid price.");
                        return;
                    }

                    updateQuery = $@"
                                    UPDATE Menu SET
                                        category = '{category}',
                                        item_name = '{itemName}',
                                        price = {price.ToString()}
                                    WHERE item_id = '{itemId}';";
                }
                else if (table == "Manager")
                {
                    string managerId = txtMid.Text;
                    string name = txtMname.Text;
                    string age = txtMage.Text;
                    string education = txtMeducation.Text;
                    string address = txtMaddress.Text;
                    string email = txtMemail.Text;
                    string phone = txtMphone.Text;
                    string dob = txtMdob.Text;
                    string role = txtMrole.Text;
                    string password = txtMpassword.Text;

                    // ✅ Validate age
                    if (!int.TryParse(age, out _))
                    {
                        MessageBox.Show("Invalid age.");
                        return;
                    }

                    updateQuery = $@"
                                    UPDATE Manager SET
                                        name = '{name}',
                                        age = {age},
                                        education = '{education}',
                                        address = '{address}',
                                        email = '{email}',
                                        phone = '{phone}',
                                        dob = '{dob}',
                                        role = '{role}',
                                        password = '{password}'
                                    WHERE manager_id = '{managerId}';";
                }
                else
                {
                    MessageBox.Show("Update is not supported for this table.");
                    return;
                }

                bool updated = DataAccess.ExecuteQuery(updateQuery);

                if (updated)
                {
                    MessageBox.Show("Data updated successfully.");
                    btnLoad_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to update data."); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query;

            if (table == "Orders")
            {
                query = "SELECT order_datetime AS [Date], total_price AS [Sales] FROM Orders";
            }
            else
            {
                query = $"SELECT * FROM {table}";
            }

            var data = DataAccess.GetData(query);
            if (data == null)
                return;

            dgvTable.AutoGenerateColumns = true;
            dgvTable.DataSource = data;
            btnRefresh_Click(null, null);
            dgvTable.Refresh();
            dgvTable.ClearSelection();
            
            if (table == "Orders") 
            {
                decimal totalSales = 0;
                foreach (DataGridViewRow row in dgvTable.Rows)
                {
                    if (row.Cells["Sales"].Value != null &&
                        decimal.TryParse(row.Cells["Sales"].Value.ToString(), out decimal sales))
                    {
                        totalSales += sales;
                    }
                }
                txtTotalSales.Text = totalSales.ToString("0.00");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvTable.CurrentRow == null)
                return;

            var row = dgvTable.Rows[e.RowIndex];

            if (table == "Staff")
            {
                txtStaffID.Text = row.Cells["staff_id"].Value?.ToString();
                txtName.Text = row.Cells["name"].Value?.ToString();
                txtAge.Text = row.Cells["age"].Value?.ToString();
                txtEducation.Text = row.Cells["education"].Value?.ToString();
                txtAddress.Text = row.Cells["address"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                txtPhone.Text = row.Cells["phone"].Value?.ToString();
                txtDob.Text = row.Cells["dob"].Value?.ToString();
                txtCatagory.Text = row.Cells["Catagory"].Value?.ToString();
                txtPassword.Text = row.Cells["password"].Value?.ToString();
                txtM_id.Text = row.Cells["manager_id"].Value?.ToString();
                txtSalary.Text = row.Cells["salary"].Value?.ToString();

                
            }
            else if (table == "Menu")
            {
                txtItemId.Text = row.Cells[1].Value?.ToString();
                txtFCatagory.Text = row.Cells[2].Value?.ToString();
                txtIname.Text = row.Cells[5].Value?.ToString();
                txtPrice.Text = row.Cells[3].Value?.ToString();
            }
            else if (table == "Manager")
            {
                txtMid.Text = row.Cells["manager_id"].Value?.ToString();
                txtMname.Text = row.Cells["name"].Value?.ToString();
                txtMage.Text = row.Cells["age"].Value?.ToString();
                txtMeducation.Text = row.Cells["education"].Value?.ToString();
                txtMaddress.Text = row.Cells["address"].Value?.ToString();
                txtMemail.Text = row.Cells["email"].Value?.ToString();
                txtMphone.Text = row.Cells["phone"].Value?.ToString();
                txtMdob.Text = row.Cells["dob"].Value?.ToString();
                txtMrole.Text = row.Cells["role"].Value?.ToString();
                txtMpassword.Text = row.Cells["password"].Value?.ToString();
            }
            else if (table == "Recommended")
            {

                Hide(true); 

                txtRname.Text = row.Cells["full_name"].Value?.ToString();
                txtGender.Text = row.Cells["gender"].Value?.ToString();
                txtRage.Text = row.Cells["age"].Value?.ToString();
                txtReducation.Text = row.Cells["education"].Value?.ToString();
                txtRaddress.Text = row.Cells["address"].Value?.ToString();
                txtRemail.Text = row.Cells["email"].Value?.ToString();
                txtRphone.Text = row.Cells["phone"].Value?.ToString();
                txtRdob.Text = row.Cells["dob"].Value?.ToString();
                txtRappliedcatagory.Text = row.Cells["applied_category"].Value?.ToString();
                txtRapplicationdate.Text = row.Cells["application_date"].Value?.ToString();
                txtRrecommendedby.Text = row.Cells["recommended_by"].Value?.ToString();
                txtRecommendationDate.Text = row.Cells["recommendation_date"].Value?.ToString(); 
            }
         

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvTable.SelectedRows[0].Cells["recommend_id"].Value.ToString();

                string insertQuery = $@"
            INSERT INTO Staff (name, age, education, address, email, phone, dob, Catagory)
            SELECT full_name, age, education, address, email, phone, dob, applied_category 
            FROM Recommended WHERE recommend_id = {id} ";

                string deleteQuery = $"DELETE FROM Recommended WHERE recommend_id = {id}";

                if (DataAccess.ExecuteQuery(insertQuery) && DataAccess.ExecuteQuery(deleteQuery))
                {
                    MessageBox.Show("Staff confirmed and moved to Staff table.");
                    btnLoad_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to confirm staff.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string updateSalaryQuery = @"
        UPDATE Staff
        SET salary = CASE 
            WHEN LOWER(Catagory) = 'head chef' THEN 55000.00
            WHEN LOWER(Catagory) = 'station chef' THEN 45000.00
            WHEN LOWER(Catagory) = 'junior chef' THEN 32000.00
            WHEN LOWER(Catagory) = 'waiter' THEN 22000.00
            WHEN LOWER(Catagory) = 'cleaner' THEN 18000.00
            WHEN LOWER(Catagory) = 'security' THEN 20000.00
            ELSE 15000.00
        END;
    ";

            bool updated = DataAccess.ExecuteQuery(updateSalaryQuery);
            dgvTable.Refresh();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide(); // hides the current form
            Login_admin_staff h = new Login_admin_staff();
            h.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (table != "Menu")
                {
                    MessageBox.Show("Adding new item is only allowed in the Menu tab.");
                    return;
                }

                string category = txtFCatagory.Text.Trim();
                string itemName = txtIname.Text.Trim();
                string priceText = txtPrice.Text.Trim();

                if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(priceText))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Invalid price format.");
                    return;
                }

                string insertQuery = $@"
            INSERT INTO Menu (category, item_name, price)
            VALUES ('{category}', '{itemName}', {price});";

                bool inserted = DataAccess.ExecuteQuery(insertQuery);

                if (inserted)
                {
                    MessageBox.Show("Menu item added successfully.");
                    btnLoad_Click(null, null); // Reload table
                }
                else
                {
                    MessageBox.Show("Failed to add menu item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
        }
        private void ClearTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c.HasChildren)
                {
                    ClearTextBoxes(c); // Recursively clear inside panels, groupboxes, tabpages, etc.
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row first");
                    return;
                }

                string deleteQuery = "";
                string id = "";

                if (table == "Staff")
                {
                    id = dgvTable.SelectedRows[0].Cells["staff_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM Staff WHERE staff_id = '{id}'";
                }
                else if (table == "Menu")
                {
                    id = dgvTable.SelectedRows[0].Cells[1].Value.ToString(); 
                    
                    deleteQuery = $"DELETE FROM Menu WHERE item_id = '{id}'";
                }
                else if (table == "Manager")
                {
                    id = dgvTable.SelectedRows[0].Cells["manager_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM Manager WHERE manager_id = '{id}'";
                }
                else if (table == "Recommended")
                {
                    id = dgvTable.SelectedRows[0].Cells["recommend_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM Recommended WHERE recommend_id = '{id}'";
                }
                else
                {
                    MessageBox.Show("Delete is not supported for this table.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure you want to delete ID: {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool deleted = DataAccess.ExecuteQuery(deleteQuery);

                    if (deleted)
                    {
                        MessageBox.Show("Record deleted successfully.");
                        btnLoad_Click(null, null); // Reload the data grid
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }
    }
}
