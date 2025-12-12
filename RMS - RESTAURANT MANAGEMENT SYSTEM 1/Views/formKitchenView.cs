using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formKitchenView : Form
    {
        private Timer kitchenTimer = new Timer();

        public formKitchenView()
        {
            InitializeComponent();

            kitchenTimer.Interval = 3000; // update each 3 seconds
            kitchenTimer.Tick += KitchenTimerTick;
            kitchenTimer.Start();
        }

        private void KitchenTimerTick(object sender, EventArgs e)
        {
            LoadKitchenOrders();
        }


        private void formKitchenView_Load(object sender, EventArgs e)
        {
            LoadKitchenOrders();
        }

        private void Card_OnOrderDone(int orderId)
        {
            // Status update
            string sql = "UPDATE orders SET orderStatus='Ready' WHERE ID=@id";

            using (var cmd = new SqlCommand(sql, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                    MainClass.con.Open();

                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
            }

            // Update kitchen screen
            LoadKitchenOrders();
        }


        private void LoadKitchenOrders()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            string sql = @"SELECT
            o.ID AS OrderID,
            w.fullName,
            t.tableName,
            o.orderTime,
            p.prodName,
            op.quantity
            FROM orders o
            JOIN users w ON o.waiterID = w.ID
            JOIN custom_tables t ON o.tableID = t.ID
            JOIN order_products op ON op.orderID = o.ID
            JOIN products p ON op.productID = p.ID
            WHERE o.orderStatus = 'InProgress'
            ORDER BY o.orderTime, o.ID;";

            var cards = new Dictionary<int, ucOrderKitchen>();

            using (var cmd = new SqlCommand(sql, MainClass.con))
            {

                if (MainClass.con.State != ConnectionState.Open) 
                {
                    MainClass.con.Open();
                }
                
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int orderId = (int)rdr["OrderID"];
                        ucOrderKitchen card;

                        bool cardExists = cards.TryGetValue(orderId, out card);

                        if (!cardExists)
                        {
                            card = new ucOrderKitchen();
                            card.OrderId = orderId;

                            card.SetHeader(rdr["fullName"].ToString(), rdr["tableName"].ToString(), (DateTime)rdr["orderTime"]);
                            card.OnOrderDone += Card_OnOrderDone;

                            flowLayoutPanel1.Controls.Add(card);

                            cards.Add(orderId, card);
                        }

                        card.AddItem(rdr["prodName"].ToString(), Convert.ToInt32(rdr["quantity"]));
                    }
                }
            }

            // add cards to layout
            foreach (var card in cards.Values)
            {
                card.Width = flowLayoutPanel1.ClientSize.Width - 25;
                flowLayoutPanel1.Controls.Add(card);
            }

            flowLayoutPanel1.ResumeLayout();
        }

    }
}
