using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class ucOrderKitchen : UserControl
    {
        public ucOrderKitchen()
        {
            InitializeComponent();

            this.Padding = new Padding(8);
            this.Margin = new Padding(8);
        }

        public int OrderId { get; set; }

        public event Action<int> OnOrderDone;

        private void btnDone_Click(object sender, EventArgs e)
        {
            OnOrderDone?.Invoke(OrderId);
        }

        public void SetHeader(string waiterName, string tableName, DateTime orderTime)
        {
            lblWaiter.Text = $"Waiter: {waiterName}";
            lblTable.Text = $"Table: {tableName}";
            lblTime.Text = $"Order time: {orderTime.ToString("HH:mm")}"; // shows time without date
        }
         
        public void AddItem(string productName, int quantity)
        {
            var lbl = new Label();
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(flowLayoutPanel1.Width - 20, 0);

            string text = $"{quantity} x {productName}";

            lbl.Text = text;

            flowLayoutPanel1.Controls.Add(lbl);
        }

    }
}
