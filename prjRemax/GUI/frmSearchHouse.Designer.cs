namespace prjRemax.GUI
{
    partial class frmSearchHouse
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
            this.comboBoxHouseID = new System.Windows.Forms.ComboBox();
            this.chkHouseRef = new System.Windows.Forms.CheckBox();
            this.dataGridViewHouse = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxHouseID);
            this.groupBox1.Controls.Add(this.chkHouseRef);
            this.groupBox1.Location = new System.Drawing.Point(258, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // comboBoxHouseID
            // 
            this.comboBoxHouseID.FormattingEnabled = true;
            this.comboBoxHouseID.Location = new System.Drawing.Point(157, 39);
            this.comboBoxHouseID.Name = "comboBoxHouseID";
            this.comboBoxHouseID.Size = new System.Drawing.Size(277, 24);
            this.comboBoxHouseID.TabIndex = 3;
            this.comboBoxHouseID.SelectedIndexChanged += new System.EventHandler(this.comboBoxHouseID_SelectedIndexChanged);
            // 
            // chkHouseRef
            // 
            this.chkHouseRef.AutoSize = true;
            this.chkHouseRef.Location = new System.Drawing.Point(42, 41);
            this.chkHouseRef.Name = "chkHouseRef";
            this.chkHouseRef.Size = new System.Drawing.Size(114, 21);
            this.chkHouseRef.TabIndex = 1;
            this.chkHouseRef.Text = "House Ref ID";
            this.chkHouseRef.UseVisualStyleBackColor = true;
            this.chkHouseRef.CheckedChanged += new System.EventHandler(this.chkHouseRef_CheckedChanged);
            // 
            // dataGridViewHouse
            // 
            this.dataGridViewHouse.AllowUserToAddRows = false;
            this.dataGridViewHouse.AllowUserToDeleteRows = false;
            this.dataGridViewHouse.AllowUserToOrderColumns = true;
            this.dataGridViewHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHouse.Location = new System.Drawing.Point(12, 231);
            this.dataGridViewHouse.Name = "dataGridViewHouse";
            this.dataGridViewHouse.ReadOnly = true;
            this.dataGridViewHouse.RowHeadersWidth = 51;
            this.dataGridViewHouse.RowTemplate.Height = 24;
            this.dataGridViewHouse.Size = new System.Drawing.Size(1110, 177);
            this.dataGridViewHouse.TabIndex = 34;
            // 
            // frmSearchHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 520);
            this.Controls.Add(this.dataGridViewHouse);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearchHouse";
            this.Text = "frmSearchHouse";
            this.Load += new System.EventHandler(this.frmSearchHouse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxHouseID;
        private System.Windows.Forms.CheckBox chkHouseRef;
        private System.Windows.Forms.DataGridView dataGridViewHouse;
    }
}