using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Resturant_Management_System
{
    public partial class Customer_View_Menu : Form
    {
        // At the top of your class (GM_View)
        private decimal totalAmount = 0;
        private string sessionCustomerName = "Mr/Ms Anonymous"; // default fallback
        


        public Customer_View_Menu()
        {
            InitializeComponent();
            this.btnLoad_Click(null, null);

        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string price;
        private string cmbOrderType;
        private ComboBox cmbPaymentMethod;

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTable.Rows[e.RowIndex];
                txtItemID.Text = row.Cells["Item ID"].Value?.ToString();      // Use actual column name
                txtItemName.Text = row.Cells["Item Name"].Value?.ToString();  // Use actual column name
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var query = @"
                        SELECT 
                            item_id AS [Item ID],
                            category AS [Item Category],
                            item_name AS [Item Name],
                            price AS [Item Price]
                        FROM Menu";

            var data = DataAccess.GetData(query);
            if (data == null)
                return;

            dgvTable.AutoGenerateColumns = true;
            dgvTable.DataSource = data;
            dgvTable.Refresh();
            dgvTable.ClearSelection();
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            var cartQuery = "SELECT * FROM Cart";
            var cartData = DataAccess.GetData(cartQuery);

            if (cartData == null || cartData.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add items first.");
                return;
            }

            string customerName = Session.CustomerName ?? "Mr/Ms Anonymous";

            DateTime orderTime = DateTime.Now;
            string orderType = "";
            string paymentMethod = "";
            decimal totalAmount = 0;

            foreach (DataRow row in cartData.Rows)
            {
                string itemId = row["item_id"].ToString();
                string itemName = row["item_name"].ToString();
                int quantity = Convert.ToInt32(row["quantity"]);
                decimal price = Convert.ToDecimal(row["price"]);
                string type = row["seviceType"].ToString();
                string payment = row["paymentTypr"].ToString();

                totalAmount += price;

                // Assign once (from the first row)
                if (string.IsNullOrEmpty(orderType)) orderType = type;
                if (string.IsNullOrEmpty(paymentMethod)) paymentMethod = payment;

                string insertOrder = $@"
                                        INSERT INTO Orders 
                                        (order_datetime, customer_name, item_id, item_name, quantity, total_price, order_type, payment_method)
                                        VALUES 
                                        ('{orderTime}', '{customerName}', '{itemId}', '{itemName}', {quantity}, {price}, '{orderType}', '{paymentMethod}');
                                      ";

                DataAccess.ExecuteQuery(insertOrder);
            }

            MessageBox.Show("Order placed successfully!");

            // Optionally clear cart
            DataAccess.ExecuteQuery("DELETE FROM Cart;");
            txtTotalAmount.Text = "0.00";
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.CustomerName = null;
            this.Hide();
            Login_Cstomer fm = new Login_Cstomer();
            fm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text) ||
        string.IsNullOrWhiteSpace(txtItemName.Text) ||
        string.IsNullOrWhiteSpace(txtQuantity.Text) ||
        cmbService.SelectedItem == null ||
        cmbPayment.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            string itemId = txtItemID.Text;
            string itemName = txtItemName.Text;
            decimal qnt = quantity;
            string serviceType = cmbService.SelectedItem.ToString();
            string paymentMethod = cmbPayment.SelectedItem.ToString();
            string customerName = Session.CustomerName ?? "Mr/Ms Anonymous";



            // Fetch price from dgvTable
            decimal price = 0;
            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                if (row.Cells["Item ID"].Value?.ToString() == itemId)
                {
                    price = Convert.ToDecimal(row.Cells["Item Price"].Value);
                    break;
                }
            }

            // Calculate total for this item and update overall total
            decimal lineTotal = price * qnt;
            totalAmount += lineTotal;
            txtTotalAmount.Text = totalAmount.ToString("0.00");

            // Prepare and execute query
            string query = $@"
        INSERT INTO Cart(item_id, item_name, quantity, price, seviceType, paymentTypr) 
        VALUES ('{itemId}', '{itemName}', {qnt}, {lineTotal}, '{serviceType}', '{paymentMethod}');
    ";

            try
            {
                DataAccess.ExecuteQuery(query);
                MessageBox.Show("Item added to cart.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.CustomerName = null;
            Home home = new Home();
            this.Hide(); // hides the current form
            home.Show();
        }
    }
}

