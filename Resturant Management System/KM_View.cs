using System;
using System.Collections;
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
    public partial class KM_View: Form
    {
        string table;
        public KM_View()
        {
            InitializeComponent();
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

            
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_admin_staff fm = new Login_admin_staff();
            fm.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide(true); 
            tabRecomonded.SelectedTab = tabStaff; 
            table = "Staff";
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide(true);
            tabRecomonded.SelectedTab = tabInventory; // 👈 this hides the panel
            table = "Inventory";
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide(true);
            tabRecomonded.SelectedTab = tabOrder; // 👈 this hides the panel
            table = "Orders";
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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query;
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
            else if (table == "Staff")
            {
                query = @"
            SELECT s.*
            FROM Staff s
            INNER JOIN Manager m ON s.manager_id = m.manager_id
            WHERE LOWER(m.role) = 'kitchen manager'
              AND s.manager_id LIKE '011-%';";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_admin_staff fm = new Login_admin_staff();
            fm.Show();
        }
    }
}
