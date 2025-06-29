using System;
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
    public partial class GM_View: Form
    {
        string table;
        public GM_View()
        {
            InitializeComponent();

            dgvTable.CellClick += dgvTable_CellClick;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }


        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabStaff; // 👈 this hides the panel
            table = "Staff";
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabMenu;
            table = "Menu";
        }

        private void managersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabManager; 
            table = "Manager";
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Hide(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Hide(true);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var query = $"select * from {table}";
            var data = DataAccess.GetData(query);
            if (data == null)
                return;

            dgvTable.AutoGenerateColumns = true;
            dgvTable.DataSource = data;
            dgvTable.Refresh();
            dgvTable.ClearSelection();
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
            else if(table == "Menu")
            {
                txtItemId.Text = row.Cells[1].Value?.ToString();
                txtFCatagory.Text = row.Cells[2].Value?.ToString();
                txtIname.Text = row.Cells[3].Value?.ToString();
                txtPrice.Text = row.Cells[4].Value?.ToString();
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
        }

        
    }
}
