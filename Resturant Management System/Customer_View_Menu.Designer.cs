namespace Resturant_Management_System
{
    partial class Customer_View_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.26057F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.73943F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.819295F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.1807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 653);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvTable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 610);
            this.panel3.TabIndex = 2;
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(656, 608);
            this.dgvTable.TabIndex = 0;
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            this.dgvTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnOrder);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(667, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 31);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(414, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 27);
            this.button1.TabIndex = 27;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnOrder.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(191, 3);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(132, 27);
            this.btnOrder.TabIndex = 26;
            this.btnOrder.Text = "Place Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(76, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 27);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add to Cart";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(67, 27);
            this.btnLoad.TabIndex = 25;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 31);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtQuantity);
            this.panel4.Controls.Add(this.cmbPayment);
            this.panel4.Controls.Add(this.cmbService);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.txtItemName);
            this.panel4.Controls.Add(this.txtItemID);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(667, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(512, 610);
            this.panel4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Payment Method :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(238, 247);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(189, 22);
            this.txtQuantity.TabIndex = 18;
            // 
            // cmbPayment
            // 
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Items.AddRange(new object[] {
            "Cash",
            "Nagad",
            "Bkash",
            "Rocket",
            "Card"});
            this.cmbPayment.Location = new System.Drawing.Point(237, 371);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(191, 24);
            this.cmbPayment.TabIndex = 17;
            // 
            // cmbService
            // 
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Items.AddRange(new object[] {
            "Dine in",
            "Take Away",
            "Home Delivery"});
            this.cmbService.Location = new System.Drawing.Point(237, 283);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(191, 24);
            this.cmbService.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(239, 414);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(187, 22);
            this.textBox2.TabIndex = 15;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(239, 208);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(187, 22);
            this.txtItemName.TabIndex = 14;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(239, 167);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(187, 22);
            this.txtItemID.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Ammount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Service :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item ID:";
            // 
            // Customer_View_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Customer_View_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnAdd;
    }
}