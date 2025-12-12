namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    partial class formOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTableNr = new System.Windows.Forms.Label();
            this.lblWaiterName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetails = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblWaiter = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnOrdersList = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnToKitchen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnPay = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(170)))), ((int)(((byte)(181)))));
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.lblTableNr);
            this.panel2.Controls.Add(this.lblWaiterName);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnDetails);
            this.panel2.Controls.Add(this.lblWaiter);
            this.panel2.Controls.Add(this.lblTable);
            this.panel2.Controls.Add(this.btnOrdersList);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnToKitchen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1240, 93);
            this.panel2.TabIndex = 3;
            // 
            // lblTableNr
            // 
            this.lblTableNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTableNr.AutoSize = true;
            this.lblTableNr.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNr.Location = new System.Drawing.Point(600, 8);
            this.lblTableNr.Name = "lblTableNr";
            this.lblTableNr.Size = new System.Drawing.Size(83, 40);
            this.lblTableNr.TabIndex = 12;
            this.lblTableNr.Text = "Table";
            // 
            // lblWaiterName
            // 
            this.lblWaiterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWaiterName.AutoSize = true;
            this.lblWaiterName.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiterName.Location = new System.Drawing.Point(600, 47);
            this.lblWaiterName.Name = "lblWaiterName";
            this.lblWaiterName.Size = new System.Drawing.Size(94, 40);
            this.lblWaiterName.TabIndex = 11;
            this.lblWaiterName.Text = "Name";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(893, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(55, 40);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "0.0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(819, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 40);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total:";
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetails.Location = new System.Drawing.Point(375, 8);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.Size = new System.Drawing.Size(115, 79);
            this.btnDetails.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDetails.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDetails.StateCommon.Border.Rounding = 20;
            this.btnDetails.StateCommon.Border.Width = 1;
            this.btnDetails.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnDetails.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDetails.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDetails.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnDetails.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnDetails.TabIndex = 8;
            this.btnDetails.Values.Text = "Details";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // lblWaiter
            // 
            this.lblWaiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiter.Location = new System.Drawing.Point(496, 47);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(107, 40);
            this.lblWaiter.TabIndex = 7;
            this.lblWaiter.Text = "Waiter:";
            // 
            // lblTable
            // 
            this.lblTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(496, 8);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(89, 40);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Table:";
            // 
            // btnOrdersList
            // 
            this.btnOrdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrdersList.Location = new System.Drawing.Point(254, 8);
            this.btnOrdersList.Name = "btnOrdersList";
            this.btnOrdersList.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.Size = new System.Drawing.Size(115, 79);
            this.btnOrdersList.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnOrdersList.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOrdersList.StateCommon.Border.Rounding = 20;
            this.btnOrdersList.StateCommon.Border.Width = 1;
            this.btnOrdersList.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnOrdersList.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnOrdersList.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnOrdersList.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdersList.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnOrdersList.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnOrdersList.TabIndex = 3;
            this.btnOrdersList.Values.Text = "Bills";
            this.btnOrdersList.Click += new System.EventHandler(this.btnOrdersList_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(133, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.Size = new System.Drawing.Size(115, 79);
            this.btnClear.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnClear.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClear.StateCommon.Border.Rounding = 20;
            this.btnClear.StateCommon.Border.Width = 1;
            this.btnClear.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnClear.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnClear.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnClear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnClear.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnClear.TabIndex = 2;
            this.btnClear.Values.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnToKitchen
            // 
            this.btnToKitchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToKitchen.Location = new System.Drawing.Point(12, 8);
            this.btnToKitchen.Name = "btnToKitchen";
            this.btnToKitchen.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.Size = new System.Drawing.Size(115, 79);
            this.btnToKitchen.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnToKitchen.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnToKitchen.StateCommon.Border.Rounding = 20;
            this.btnToKitchen.StateCommon.Border.Width = 1;
            this.btnToKitchen.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnToKitchen.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnToKitchen.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnToKitchen.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToKitchen.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnToKitchen.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnToKitchen.TabIndex = 0;
            this.btnToKitchen.Values.Text = "To kitchen";
            this.btnToKitchen.Click += new System.EventHandler(this.btnToKitchen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 25);
            this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearch.StateCommon.Border.Rounding = 3;
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.kryptonDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonDataGridView1.ColumnHeadersHeight = 40;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvid,
            this.dgvProductID,
            this.dgvSno,
            this.dgvName,
            this.dgvQty,
            this.dgvPrice,
            this.dgvSubtotal});
            this.kryptonDataGridView1.HideOuterBorders = true;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(826, 69);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.kryptonDataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Nirmala UI", 14.25F);
            this.kryptonDataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.RowTemplate.Height = 40;
            this.kryptonDataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(402, 496);
            this.kryptonDataGridView1.StateNormal.Background.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateNormal.Background.Color2 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonDataGridView1.StateNormal.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonDataGridView1.TabIndex = 21;
            // 
            // dgvid
            // 
            this.dgvid.HeaderText = "id";
            this.dgvid.Name = "dgvid";
            this.dgvid.ReadOnly = true;
            this.dgvid.Visible = false;
            // 
            // dgvProductID
            // 
            this.dgvProductID.HeaderText = "Column1";
            this.dgvProductID.Name = "dgvProductID";
            this.dgvProductID.ReadOnly = true;
            this.dgvProductID.Visible = false;
            // 
            // dgvSno
            // 
            this.dgvSno.FillWeight = 70F;
            this.dgvSno.HeaderText = "Nr.";
            this.dgvSno.Name = "dgvSno";
            this.dgvSno.ReadOnly = true;
            this.dgvSno.Width = 40;
            // 
            // dgvName
            // 
            this.dgvName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvName.HeaderText = "Name";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvQty
            // 
            this.dgvQty.HeaderText = "Quantity";
            this.dgvQty.Name = "dgvQty";
            this.dgvQty.ReadOnly = true;
            this.dgvQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQty.Width = 60;
            // 
            // dgvPrice
            // 
            this.dgvPrice.HeaderText = "Price";
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            this.dgvPrice.Width = 60;
            // 
            // dgvSubtotal
            // 
            this.dgvSubtotal.HeaderText = "Subtotal";
            this.dgvSubtotal.Name = "dgvSubtotal";
            this.dgvSubtotal.ReadOnly = true;
            this.dgvSubtotal.Width = 60;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 69);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(808, 496);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.Location = new System.Drawing.Point(1113, 8);
            this.btnPay.Name = "btnPay";
            this.btnPay.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnPay.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnPay.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnPay.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnPay.Size = new System.Drawing.Size(115, 79);
            this.btnPay.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPay.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPay.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPay.StateCommon.Border.Rounding = 20;
            this.btnPay.StateCommon.Border.Width = 1;
            this.btnPay.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnPay.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnPay.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnPay.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnPay.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnPay.TabIndex = 13;
            this.btnPay.Values.Text = "Pay";
            this.btnPay.Visible = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // formOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 664);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formOrders";
            this.Text = "formOrders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formOrders_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnToKitchen;
        public System.Windows.Forms.Label label1;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnOrdersList;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnClear;
        public System.Windows.Forms.Label lblTable;
        public System.Windows.Forms.Label lblWaiter;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnDetails;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblTableNr;
        public System.Windows.Forms.Label lblWaiterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSubtotal;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnPay;
    }
}