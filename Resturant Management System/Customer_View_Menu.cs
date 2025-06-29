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
    public partial class Customer_View_Menu: Form
    {
        public Customer_View_Menu()
        {
            InitializeComponent();
        }
        
        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public string price;
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtItemID.Text = dgvTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtItemName.Text = dgvTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var query = $"select * from Menu";
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

                // get price from Menu
                var priceQuery = $"SELECT price FROM Menu WHERE item_id = '{itemID}'";
                var priceData = DataAccess.GetData(priceQuery);

                if (priceData.Rows.Count == 0)
                {
                    MessageBox.Show("Item not found in Menu.");
                    return;
                }

                var price = Convert.ToDecimal(priceData.Rows[0]["price"]);

                // insert into cart
                var query = $@"
            INSERT INTO Cart (item_id, item_name, quantity, price, customer_name)
            VALUES ('{itemID}', '{itemName}', {quantity}, {price})
        ";

                var result = DataAccess.ExecuteQuery(query);

                if (result > 0)
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
