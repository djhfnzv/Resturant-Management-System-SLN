using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Resturant_Management_System
{
    public partial class Customer_View_Menu : Form
    {

        public Customer_View_Menu()
        {
            InitializeComponent();


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
                txtItemID.Text = row.Cells["item_id"].Value?.ToString();      // Use actual column name
                txtItemName.Text = row.Cells["item_name"].Value?.ToString();  // Use actual column name
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItemID.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Please select an item and enter quantity.");
                    return;
                }

                var itemID = txtItemID.Text;
                var itemName = txtItemName.Text;
                var quantity = Convert.ToInt32(txtQuantity.Text);

                // get price from Menu (correct column name!)
                var priceQuery = $"SELECT price FROM Menu WHERE item_id = '{itemID}'";
                var priceData = DataAccess.GetData(priceQuery);

                if (priceData == null || priceData.Rows.Count == 0)
                {
                    MessageBox.Show("Item not found in Menu.");
                    return;
                }

                var price = Convert.ToDecimal(priceData.Rows[0]["price"]);

                // default customer name
                var customerName = "Mr/Ms Anonymous";

                // insert into cart
                var query = $@"
            INSERT INTO Cart (item_id, item_name, quantity, price, customer_name)
            VALUES ('{itemID}', '{itemName}', {quantity}, {price}, '{customerName}')
        ";

                var result = DataAccess.ExecuteQuery(query);

                if (result == true)
                {
                    MessageBox.Show("Item added to cart!");
                }
                else
                {
                    MessageBox.Show("Failed to add item to cart.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure cmbOrderType and cmbPaymentMethod are ComboBox objects
                if (cmbService is ComboBox orderTypeComboBox && cmbPayment is ComboBox paymentMethodComboBox)
                {
                    string orderType = orderTypeComboBox.SelectedItem?.ToString() ?? "Dine-in";
                    string paymentMethod = paymentMethodComboBox.SelectedItem?.ToString() ?? "Cash";

                    var cartQuery = "SELECT * FROM Cart";
                    var cartData = DataAccess.GetData(cartQuery);

                    if (cartData == null || cartData.Rows.Count == 0)
                    {
                        MessageBox.Show("Cart is empty!");
                        return;
                    }

                    int insertedRows = 0;

                    foreach (DataRow row in cartData.Rows)
                    {
                        var itemID = row["item_id"].ToString();
                        var quantity = Convert.ToInt32(row["quantity"]);
                        var customerName = row["customer_name"].ToString();
                        var itemName = row["item_name"].ToString();

                        var insertQuery = $@"
                        INSERT INTO Orders (item_id, quantity, customer_name, order_type, payment_method, item_name)
                        VALUES ('{itemID}', {quantity}, '{customerName}', '{orderType}', '{paymentMethod}', '{itemName}')
                    ";

                        var result = DataAccess.ExecuteQuery(insertQuery);

                        if (result == true)
                        {
                            insertedRows++;
                        }
                    }

                    // clear the cart
                    var clearQuery = "DELETE FROM Cart";
                    DataAccess.ExecuteQuery(clearQuery);

                    MessageBox.Show($"{insertedRows} order(s) placed successfully!");
                }
                else
                {
                    MessageBox.Show("Order type or payment method selection is invalid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

