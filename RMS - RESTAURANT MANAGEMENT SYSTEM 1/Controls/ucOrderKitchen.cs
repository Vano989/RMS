using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls
{
    public partial class ucOrderKitchen : UserControl
    {
        public ucOrderKitchen()
        {
            InitializeComponent();

            this.Padding = new Padding(8);
            this.Margin = new Padding(8);
        }

        //Order ID related to this kitchen card
        public int OrderId { get; set; }

        //Event that notifies parent form when the order is marked as done
        public event Action<int> OnOrderDone;

        //triggered when Done button is clicked
        private void btnDone_Click(object sender, EventArgs e)
        {
            //Invoke event and pass the Order ID to the parent form
            OnOrderDone?.Invoke(OrderId);
        }

        //Sets order header information
        public void SetHeader(string waiterName, string tableName, DateTime orderTime)
        {
            lblWaiter.Text = $"Waiter: {waiterName}";
            lblTable.Text = $"Table: {tableName}";
            lblTime.Text = $"Order time: {orderTime.ToString("HH:mm")}"; // shows time without date
        }

        //Adds order product to the kitchen list
        public void AddItem(string productName, int quantity, string status)
        {
            var lbl = new Label();
            lbl.AutoSize = true;

            lbl.Text = $"{quantity} X {productName}  -  {status}";
            lbl.Font = new Font("Nirmala UI", 14f, FontStyle.Regular);

            //Order product status
            if (status == "Done")
            {
                lbl.ForeColor = Color.DimGray;
            }
            else
            {
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            }

            //Add item to Panel
            flowLayoutPanel1.Controls.Add(lbl);

            //dynamic card height
            RecalculateHeight();
        }

        //Recalculates card height
        public void RecalculateHeight()
        {
            int internalHeight = flowLayoutPanel1.PreferredSize.Height;
            int headerHeight = header.Height;
            int buttonHeight = btnDone.Height;
            int padding = 35;

            //total height
            this.Height = headerHeight + internalHeight + buttonHeight + padding;
        }

        //sets order status and header color
        public void SetOrderStatus(string orderStatus)
        {
            lblOrderStatus.Text = orderStatus;

            if (orderStatus == "New")
            {
                header.BackColor = Color.FromArgb(200, 230, 201);
            }
            else if (orderStatus == "Changed")
            {
                header.BackColor = Color.FromArgb(255, 224, 178);
            }
        }
    }
}
