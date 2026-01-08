namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    partial class formOrdersList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWaiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvClose = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbShowCanceled = new System.Windows.Forms.CheckBox();
            this.cbShowClosed = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.cbShowClosed);
            this.panel1.Controls.Add(this.cbShowCanceled);
            this.panel1.Controls.Add(this.Header);
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 93);
            this.panel1.TabIndex = 1;
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(12, 12);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(170, 65);
            this.Header.TabIndex = 2;
            this.Header.Text = "Orders";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.Image = global::RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Properties.Resources.exit;
            this.pictureBoxClose.Location = new System.Drawing.Point(1094, 12);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 1;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.kryptonDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonDataGridView1.ColumnHeadersHeight = 40;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSno,
            this.dgvWaiter,
            this.dgvTable,
            this.dgvDate,
            this.dgvOrderStatus,
            this.dgvPaymentStatus,
            this.dgvTotal,
            this.dgvid,
            this.dgvClose,
            this.dgvEdit,
            this.dgvDelete});
            this.kryptonDataGridView1.HideOuterBorders = true;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(12, 109);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.kryptonDataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Nirmala UI", 14.25F);
            this.kryptonDataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.RowTemplate.Height = 40;
            this.kryptonDataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1152, 608);
            this.kryptonDataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryptonDataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.kryptonDataGridView1.StateNormal.Background.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateNormal.Background.Color2 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonDataGridView1.TabIndex = 22;
            this.kryptonDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellContentClick);
            // 
            // dgvSno
            // 
            this.dgvSno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSno.FillWeight = 70F;
            this.dgvSno.HeaderText = "Nr.";
            this.dgvSno.Name = "dgvSno";
            this.dgvSno.ReadOnly = true;
            this.dgvSno.Width = 40;
            // 
            // dgvWaiter
            // 
            this.dgvWaiter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvWaiter.HeaderText = "Waiter";
            this.dgvWaiter.Name = "dgvWaiter";
            this.dgvWaiter.ReadOnly = true;
            // 
            // dgvTable
            // 
            this.dgvTable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvTable.HeaderText = "Table";
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            // 
            // dgvDate
            // 
            this.dgvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvDate.HeaderText = "Date";
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            // 
            // dgvOrderStatus
            // 
            this.dgvOrderStatus.HeaderText = "Order status";
            this.dgvOrderStatus.Name = "dgvOrderStatus";
            this.dgvOrderStatus.ReadOnly = true;
            this.dgvOrderStatus.Width = 120;
            // 
            // dgvPaymentStatus
            // 
            this.dgvPaymentStatus.HeaderText = "Payment status";
            this.dgvPaymentStatus.Name = "dgvPaymentStatus";
            this.dgvPaymentStatus.ReadOnly = true;
            this.dgvPaymentStatus.Width = 120;
            // 
            // dgvTotal
            // 
            this.dgvTotal.HeaderText = "Total";
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.Width = 130;
            // 
            // dgvid
            // 
            this.dgvid.HeaderText = "id";
            this.dgvid.Name = "dgvid";
            this.dgvid.ReadOnly = true;
            this.dgvid.Visible = false;
            // 
            // dgvClose
            // 
            this.dgvClose.HeaderText = "";
            this.dgvClose.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvClose.Name = "dgvClose";
            this.dgvClose.ReadOnly = true;
            this.dgvClose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvClose.Width = 50;
            // 
            // dgvEdit
            // 
            this.dgvEdit.FillWeight = 50F;
            this.dgvEdit.HeaderText = "";
            this.dgvEdit.Image = global::RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Properties.Resources.edit;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvEdit.Width = 50;
            // 
            // dgvDelete
            // 
            this.dgvDelete.FillWeight = 50F;
            this.dgvDelete.HeaderText = "";
            this.dgvDelete.Image = global::RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Properties.Resources.delete;
            this.dgvDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.ReadOnly = true;
            this.dgvDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvDelete.Width = 50;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 50F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Properties.Resources.edit;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 50F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Properties.Resources.delete;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // cbShowCanceled
            // 
            this.cbShowCanceled.AutoSize = true;
            this.cbShowCanceled.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowCanceled.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbShowCanceled.Location = new System.Drawing.Point(427, 40);
            this.cbShowCanceled.Name = "cbShowCanceled";
            this.cbShowCanceled.Size = new System.Drawing.Size(157, 29);
            this.cbShowCanceled.TabIndex = 4;
            this.cbShowCanceled.Text = "Show canceled";
            this.cbShowCanceled.UseVisualStyleBackColor = true;
            this.cbShowCanceled.CheckedChanged += new System.EventHandler(this.cbShowCanceled_CheckedChanged);
            // 
            // cbShowClosed
            // 
            this.cbShowClosed.AutoSize = true;
            this.cbShowClosed.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowClosed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbShowClosed.Location = new System.Drawing.Point(234, 40);
            this.cbShowClosed.Name = "cbShowClosed";
            this.cbShowClosed.Size = new System.Drawing.Size(136, 29);
            this.cbShowClosed.TabIndex = 5;
            this.cbShowClosed.Text = "Show closed";
            this.cbShowClosed.UseVisualStyleBackColor = true;
            this.cbShowClosed.CheckedChanged += new System.EventHandler(this.cbShowClosed_CheckedChanged);
            // 
            // formOrdersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 729);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formOrdersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formOrdersList";
            this.Load += new System.EventHandler(this.formOrdersList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBoxClose;
        public System.Windows.Forms.Label Header;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWaiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvid;
        private System.Windows.Forms.DataGridViewImageColumn dgvClose;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDelete;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.CheckBox cbShowClosed;
        private System.Windows.Forms.CheckBox cbShowCanceled;
    }
}