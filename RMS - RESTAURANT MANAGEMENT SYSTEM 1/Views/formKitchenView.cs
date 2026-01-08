using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formKitchenView : Form
    {
        //Timer to periodically check for new/changed orders
        private Timer kitchenTimer = new Timer();

        //Last known time used to detect changes
        private DateTime lastCreatedAt = DateTime.MinValue;
        private DateTime lastChangedAt = DateTime.MinValue;

        public formKitchenView()
        {
            InitializeComponent();

            //screen refresh interval
            kitchenTimer.Interval = 3000;
            //runs each 3 seconds
            kitchenTimer.Tick += KitchenTimerTick;
            //Start periodic refresh checks
            kitchenTimer.Start();
        }

        private void formKitchenView_Load(object sender, EventArgs e)
        {
            LoadKitchenOrders();
        }

        private void LoadKitchenOrders()
        {
            //Pause layout while rebuilding cards
            flowLayoutPanel1.SuspendLayout();

            //Remove and dispose existing cards to prevent memory leaks
            foreach (Control c in flowLayoutPanel1.Controls.Cast<Control>().ToList())
            {
                flowLayoutPanel1.Controls.Remove(c);
                c.Dispose();
            }

            //Load all active kitchen orders (New/Changed)
            string sql = @"
            SELECT
                o.ID AS OrderID,
                w.fullName,
                t.tableName,
                o.created_at,
                o.updated_at,
                o.orderStatus,
                p.ID AS ProductID,
                p.prodName,
                op.kitchenStatus,
                COUNT(*) AS qty
            FROM orders o
            JOIN users w ON o.waiterID = w.ID
            JOIN custom_tables t ON o.tableID = t.ID
            JOIN order_products op ON op.orderID = o.ID
            JOIN products p ON op.productID = p.ID
            WHERE o.orderStatus IN ('New','Changed')
            GROUP BY
                o.ID,
                w.fullName,
                t.tableName,
                o.created_at,
                o.updated_at,
                o.orderStatus,
                p.ID,
                p.prodName,
                op.kitchenStatus
            ORDER BY
                o.created_at,
                o.ID,
                CASE WHEN op.kitchenStatus = 'Done' THEN 0 ELSE 1 END,
                p.prodName;";

            //Temporary cache to ensure one card per order
            var cards = new Dictionary<int, ucOrderKitchen>();

            using (var cmd = new SqlCommand(sql, MainClass.con))
            {
                //Open connection
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int orderId = Convert.ToInt32(rdr["OrderID"]);
                        string orderStatus = rdr["orderStatus"].ToString();

                        //Create a card only once per orderId
                        if (!cards.TryGetValue(orderId, out var card))
                        {
                            card = new ucOrderKitchen();
                            card.OrderId = orderId;

                            //New -> show created_at, Changed -> show updated_at
                            if (orderStatus=="New")
                            {
                                card.SetHeader(
                                    rdr["fullName"].ToString(),
                                    rdr["tableName"].ToString(),
                                    Convert.ToDateTime(rdr["created_at"])
                                );
                            }
                            else
                            {
                                card.SetHeader(
                                    rdr["fullName"].ToString(),
                                    rdr["tableName"].ToString(),
                                    Convert.ToDateTime(rdr["updated_at"])
                                );
                            }

                            //when order done button clicked
                            card.OnOrderDone += Card_OnOrderDone;
                            cards.Add(orderId, card);
                        }

                        //Read item details for this order card
                        string prodName = rdr["prodName"].ToString();
                        string kitchenStatus = rdr["kitchenStatus"].ToString();   // New / Done
                        int qty = Convert.ToInt32(rdr["qty"]);

                        //update order status on the card
                        card.SetOrderStatus(rdr["orderStatus"].ToString());
                        //add product to the card
                        card.AddItem(prodName, qty, kitchenStatus);
                    }
                }
                //Close connection
                if (MainClass.con.State == ConnectionState.Open)
                {
                    MainClass.con.Close();
                }
            }

            //render the cards into the flow panel
            foreach (var card in cards.Values)
            {
                card.Width = 340;
                flowLayoutPanel1.Controls.Add(card);
            }

            //resume layout updates
            flowLayoutPanel1.ResumeLayout();
        }

        //when order done button clicked
        private void Card_OnOrderDone(int orderId)
        {
            //Mark all "New" kitchen items as "Done"
            string sqlItems = @"
            UPDATE op
            SET kitchenStatus = 'Done'
            FROM order_products op
            JOIN orders o ON o.ID = op.orderID
            WHERE op.orderID = @id AND op.kitchenStatus = 'New' AND o.orderStatus <> 'Canceled';";

            Hashtable ht = new Hashtable();
            ht.Add("@id", orderId);

            //Execute sql command
            MainClass.SQL(sqlItems, ht);

            //Mark the whole order as "Ready"
            string sqlReady = @"
            UPDATE orders
            SET orderStatus = 'Ready'
            WHERE ID = @id AND orderStatus <> 'Canceled'";

            MainClass.SQL(sqlReady, ht);

            //reload kitchen orders
            LoadKitchenOrders();
        }

        private bool NeedReloadKitchen()
        {
            //keep previous timestamps
            DateTime dbCreated = lastCreatedAt;
            DateTime dbChanged = lastChangedAt;

            //check latest timestamps among active kitchen orders
            string sql = @"
            SELECT MAX(created_at) AS maxCreated, MAX(updated_at) AS maxChanged
            FROM orders
            WHERE orderStatus IN ('New','Changed');";

            using (SqlCommand cmd = new SqlCommand(sql, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();


                    //If result is null, keep previous values
                    if (rdr["maxCreated"] != DBNull.Value)
                    {
                        dbCreated = Convert.ToDateTime(rdr["maxCreated"]);
                    }

                    if (rdr["maxChanged"] != DBNull.Value)
                    {
                        dbChanged = Convert.ToDateTime(rdr["maxChanged"]);
                    }
                }

                if (MainClass.con.State == ConnectionState.Open)
                {
                    MainClass.con.Close();
                }
            }

            //if created_at and updated_at is not newer than last change, no reload is needed
            if (dbCreated <= lastCreatedAt && dbChanged <= lastChangedAt)
            {
                return false;
            }

            //save current timestamps for next comparison
            lastCreatedAt = dbCreated;
            lastChangedAt = dbChanged;

            return true;
        }

        private void KitchenTimerTick(object sender, EventArgs e)
        {
            
            //check if there are any new orders or changes in the database
            bool needReload = NeedReloadKitchen();

            //If something changed -> reload kitchen orders
            if (needReload)
            {
                
                LoadKitchenOrders();
            }
        }
    }
}
