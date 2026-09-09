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

    public partial class AM_View: Form
    {
        string currentManagerID = SessionAdmin.UserID;
        string table;
        public AM_View()
        {
            InitializeComponent();

            dgvTable.CellClick += dgvTable_CellClick;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_admin_staff fm = new Login_admin_staff();
            fm.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabStaff; // 👈 this hides the panel
            table = "Staff";
        }
        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabInventory; // 👈 this hides the panel
            table = "Inventory";
        }
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabOrder; // 👈 this hides the panel
            table = "Orders";
        }
        private void applicantListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabRecomonded.SelectedTab = tabApplicants; // 👈 this hides the panel
            table = "ApplicantList";
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
            else if (table == "Inventory")
            {
                txtIngredientId.Text = row.Cells["ingredient_id"].Value?.ToString();
                txtICategory.Text = row.Cells["category"].Value?.ToString();
                txtIngredientName.Text = row.Cells["ingredient_name"].Value?.ToString();
                txtIStock.Text = row.Cells["stock"].Value?.ToString();
                txtIPrice.Text = row.Cells["price"].Value?.ToString();
                txtIEntryDate.Text = row.Cells["entry_date"].Value?.ToString();

                decimal total = 0;

                foreach (DataGridViewRow inventoryRow in dgvTable.Rows)
                {
                    if (inventoryRow.Cells["total_cost"].Value != null)
                    {
                        decimal cost;
                        if (decimal.TryParse(inventoryRow.Cells["total_cost"].Value.ToString(), out cost))
                            total += cost;
                    }
                }

                txtTstock.Text = total.ToString("0.00");
            }
            else if (table == "ApplicantList")
            {

                Hide(true); // Hide all textboxes as they are read-only in this case

                txtRname.Text = row.Cells["full_name"].Value?.ToString();
                txtGender.Text = row.Cells["gender"].Value?.ToString();
                txtRage.Text = row.Cells["age"].Value?.ToString();
                txtReducation.Text = row.Cells["education"].Value?.ToString();
                txtRaddress.Text = row.Cells["address"].Value?.ToString();
                txtRemail.Text = row.Cells["email"].Value?.ToString();
                txtRphone.Text = row.Cells["phone"].Value?.ToString();
                txtRdob.Text = row.Cells["dob"].Value?.ToString();
                txtRappliedcatagory.Text = row.Cells["applied_category"].Value?.ToString();
            }

        }

        private void Hide(bool x)
        {
            // Staff Fields
            txtStaffID.ReadOnly = x; // always readonly
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

            // Inventory Fields
            txtIngredientId.ReadOnly = x;
            txtICategory.ReadOnly = x;
            txtIngredientName.ReadOnly = x;
            txtIStock.ReadOnly = x;
            txtIPrice.ReadOnly = x;
            txtIEntryDate.ReadOnly = x;

            //applicant Fields
            txtRname.ReadOnly = x;
            txtGender.ReadOnly = x;
            txtRage.ReadOnly = x;
            txtReducation.ReadOnly = x;
            txtRaddress.ReadOnly = x;
            txtRemail.ReadOnly = x;
            txtRphone.ReadOnly = x;
            txtRdob.ReadOnly = x;
            txtRappliedcatagory.ReadOnly = x;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            String query;

            if (table == "Orders")
            {
                query = @"
    SELECT 
        CONVERT(VARCHAR(10), order_datetime, 120) AS [Date],
        customer_name AS [Customer],
        item_id AS [Item ID],
        item_name AS [Item Name],
        quantity AS [Quantity],
        payment_method AS [Payment Type],
        total_price AS [Amount]
    FROM Orders;";
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
            dgvTable.Refresh();
            dgvTable.ClearSelection();
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

                // ✅ Make sure this matches the exact table name used in other parts
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
                else if (table == "Inventory")
                {
                    string ingredientId = txtIngredientId.Text;
                    string category = txtICategory.Text;
                    string name = txtIngredientName.Text;
                    string stock = txtIStock.Text;
                    string price = txtIPrice.Text;
                    string entryDate = txtIEntryDate.Text;

                    // ✅ Validate numeric values
                    if (!int.TryParse(stock, out _) || !decimal.TryParse(price, out _))
                    {
                        MessageBox.Show("Invalid stock or price.");
                        return;
                    }

                    updateQuery = $@"
UPDATE Inventory SET
    category = '{category}',
    ingredient_name = '{name}',
    stock = {stock},
    price = {price},
    entry_date = '{entryDate}'
WHERE ingredient_id = '{ingredientId}';";

                    decimal total = 0;

                    foreach (DataGridViewRow inventoryRow in dgvTable.Rows)
                    {
                        if (inventoryRow.Cells["total_cost"].Value != null)
                        {
                            decimal cost;
                            if (decimal.TryParse(inventoryRow.Cells["total_cost"].Value.ToString(), out cost))
                                total += cost;
                        }
                    }

                    txtTstock.Text = total.ToString("0.00");
                }
                

                else
                {
                    MessageBox.Show("Update is not supported for this table.");
                    return;
                }

                // ✅ Debug: show the SQL query
                Console.WriteLine(updateQuery);
                MessageBox.Show("Executing Query:\n" + updateQuery); // You can comment this later

                bool updated = DataAccess.ExecuteQuery(updateQuery);

                if (updated)
                {
                    MessageBox.Show("Data updated successfully.");
                    btnLoad_Click(null, null); // ✅ Refresh table
                }
                else
                {
                    MessageBox.Show("Failed to update data."); // ✅ Triggers if query didn't execute
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }

        private void btnRecomend_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvTable.SelectedRows[0].Cells["applicant_id"].Value.ToString();

                string insertQuery = $@"
            INSERT INTO Recommended (
                applicant_id, full_name, age, education, address, email, phone, dob,
                applied_category, application_date, recommended_by, gender
            )
            SELECT 
                applicant_id, full_name, age, education, address, email, phone, dob,
                applied_category, application_date, '{currentManagerID}' , gender
            FROM ApplicantList 
            WHERE applicant_id = '{id}'";//

                string deleteQuery = $"DELETE FROM ApplicantList WHERE applicant_id = {id}";

                if (DataAccess.ExecuteQuery(insertQuery) && DataAccess.ExecuteQuery(deleteQuery))
                {
                    MessageBox.Show("Applicant recommended successfully.");
                    btnLoad_Click(null, null); // Reload
                }
                else
                {
                    MessageBox.Show("Failed to recommend applicant.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // hides the current form
            Login_admin_staff h = new Login_admin_staff();
            h.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add New functionality is not implemented yet.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Clear();
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
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
                else if (table == "Inventory")
                {
                    id = dgvTable.SelectedRows[0].Cells["ingredient_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM Inventory WHERE ingredient_id = '{id}'";
                }
                else if (table == "ApplicantList")
                {
                    id = dgvTable.SelectedRows[0].Cells["applicant_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM ApplicantList WHERE applicant_id = '{id}'";
                }
                else if (table == "Menu")
                {
                    id = dgvTable.SelectedRows[0].Cells["item_id"].Value.ToString();
                    deleteQuery = $"DELETE FROM Menu WHERE item_id = '{id}'";
                }
                else
                {
                    MessageBox.Show("Delete not supported for this table.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure you want to delete ID: {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool deleted = DataAccess.ExecuteQuery(deleteQuery);
                    if (deleted)
                    {
                        MessageBox.Show("Record deleted successfully.");
                        btnLoad_Click(null, null);
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
