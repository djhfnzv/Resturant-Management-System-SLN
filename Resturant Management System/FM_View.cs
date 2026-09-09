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
    public partial class FM_View: Form
    {
        public FM_View()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_admin_staff fm = new Login_admin_staff();
            fm.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query = @"
                            SELECT s.*
                            FROM Staff s
                            INNER JOIN Manager m ON s.manager_id = m.manager_id
                            WHERE s.manager_id LIKE '100-%'
           OR LOWER(m.role) = 'floor manager';";

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
