namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls
{
    partial class ucOrderKitchen
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblWaiter = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDone = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.header.Controls.Add(this.lblOrderStatus);
            this.header.Controls.Add(this.lblTime);
            this.header.Controls.Add(this.lblWaiter);
            this.header.Controls.Add(this.lblTable);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(338, 145);
            this.header.TabIndex = 0;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOrderStatus.Location = new System.Drawing.Point(22, 5);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(94, 37);
            this.lblOrderStatus.TabIndex = 3;
            this.lblOrderStatus.Text = "status";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTime.Location = new System.Drawing.Point(14, 102);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(118, 30);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Order time:";
            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWaiter.Location = new System.Drawing.Point(14, 72);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(79, 30);
            this.lblWaiter.TabIndex = 1;
            this.lblWaiter.Text = "Waiter:";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTable.Location = new System.Drawing.Point(14, 42);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(66, 30);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Table:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.btnDone);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 173);
            this.panel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(338, 123);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnDone
            // 
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDone.Location = new System.Drawing.Point(0, 123);
            this.btnDone.MaximumSize = new System.Drawing.Size(0, 50);
            this.btnDone.Name = "btnDone";
            this.btnDone.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.Size = new System.Drawing.Size(338, 50);
            this.btnDone.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnDone.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDone.StateCommon.Border.Rounding = 20;
            this.btnDone.StateCommon.Border.Width = 1;
            this.btnDone.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnDone.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDone.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDone.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnDone.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(240)))));
            this.btnDone.TabIndex = 1;
            this.btnDone.Values.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // ucOrderKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header);
            this.Name = "ucOrderKitchen";
            this.Size = new System.Drawing.Size(338, 318);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblOrderStatus;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnDone;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
