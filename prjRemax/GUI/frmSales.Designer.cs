namespace prjRemax.GUI
{
    partial class frmSales
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSeller = new System.Windows.Forms.ComboBox();
            this.comboBoxBuyer = new System.Windows.Forms.ComboBox();
            this.comboBoxHouse = new System.Windows.Forms.ComboBox();
            this.comboBoxAgentName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaleHouse = new System.Windows.Forms.Button();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.comboBoxSeller);
            this.groupBox1.Controls.Add(this.comboBoxBuyer);
            this.groupBox1.Controls.Add(this.comboBoxHouse);
            this.groupBox1.Controls.Add(this.comboBoxAgentName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(49, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 172);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(386, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // comboBoxSeller
            // 
            this.comboBoxSeller.FormattingEnabled = true;
            this.comboBoxSeller.Location = new System.Drawing.Point(127, 133);
            this.comboBoxSeller.Name = "comboBoxSeller";
            this.comboBoxSeller.Size = new System.Drawing.Size(386, 24);
            this.comboBoxSeller.TabIndex = 8;
            // 
            // comboBoxBuyer
            // 
            this.comboBoxBuyer.FormattingEnabled = true;
            this.comboBoxBuyer.Location = new System.Drawing.Point(127, 96);
            this.comboBoxBuyer.Name = "comboBoxBuyer";
            this.comboBoxBuyer.Size = new System.Drawing.Size(386, 24);
            this.comboBoxBuyer.TabIndex = 7;
            // 
            // comboBoxHouse
            // 
            this.comboBoxHouse.FormattingEnabled = true;
            this.comboBoxHouse.Location = new System.Drawing.Point(127, 66);
            this.comboBoxHouse.Name = "comboBoxHouse";
            this.comboBoxHouse.Size = new System.Drawing.Size(386, 24);
            this.comboBoxHouse.TabIndex = 6;
            this.comboBoxHouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxHouse_SelectedIndexChanged);
            // 
            // comboBoxAgentName
            // 
            this.comboBoxAgentName.FormattingEnabled = true;
            this.comboBoxAgentName.Location = new System.Drawing.Point(127, 27);
            this.comboBoxAgentName.Name = "comboBoxAgentName";
            this.comboBoxAgentName.Size = new System.Drawing.Size(386, 24);
            this.comboBoxAgentName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Seller";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buyer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "House";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agent";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSell);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSaleHouse);
            this.groupBox2.Location = new System.Drawing.Point(686, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Sales";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(44, 139);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(117, 41);
            this.btnSell.TabIndex = 2;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(44, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 41);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaleHouse
            // 
            this.btnSaleHouse.Location = new System.Drawing.Point(44, 21);
            this.btnSaleHouse.Name = "btnSaleHouse";
            this.btnSaleHouse.Size = new System.Drawing.Size(117, 41);
            this.btnSaleHouse.TabIndex = 0;
            this.btnSaleHouse.Text = "Sell this House";
            this.btnSaleHouse.UseVisualStyleBackColor = true;
            this.btnSaleHouse.Click += new System.EventHandler(this.btnSaleHouse_Click);
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToOrderColumns = true;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(40, 348);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersWidth = 51;
            this.dataGridViewSales.RowTemplate.Height = 24;
            this.dataGridViewSales.Size = new System.Drawing.Size(885, 177);
            this.dataGridViewSales.TabIndex = 34;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 548);
            this.Controls.Add(this.dataGridViewSales);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSales";
            this.Text = "frmSales";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxSeller;
        private System.Windows.Forms.ComboBox comboBoxBuyer;
        private System.Windows.Forms.ComboBox comboBoxHouse;
        private System.Windows.Forms.ComboBox comboBoxAgentName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaleHouse;
        private System.Windows.Forms.DataGridView dataGridViewSales;
    }
}