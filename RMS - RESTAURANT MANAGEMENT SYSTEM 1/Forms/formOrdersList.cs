using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formOrdersList : Form
    {
        public formOrdersList()
        {
            InitializeComponent();
        }

        //selected order ID
        public int orderID = 0;

        //indicates if payment can be made for selected order
        public bool canPay = false;

        //close
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //loads orders into the DataGridView
        private void LoadOrders()
        {
            //Clear grid
            kryptonDataGridView1.Rows.Clear();

            string qry = "";

            //if "Show Closed" is enabled -> load only closed orders
            if (cbShowClosed.Checked)
            {
                qry = @"
                SELECT 
                    o.ID,
                    u.fullName      AS Waiter,
                    t.tableName     AS TableName,
                    o.created_at     AS Created_at,
                    o.orderStatus   AS OrderStatus,
                    o.paymentStatus AS PaymentStatus,
                    o.total         AS Total
                FROM orders o
                INNER JOIN users u          ON o.waiterID = u.ID
                INNER JOIN custom_tables t  ON o.tableID  = t.ID
                WHERE o.orderStatus = 'Closed'
                ORDER BY
                    CASE 
                        WHEN o.orderStatus = 'Ready' AND o.paymentStatus = 'Paid' THEN 0
                        ELSE 1
                    END,
                o.created_at DESC;";
            }
            else if (cbShowCanceled.Checked) //If "Show Canceled" is enabled -> load only canceled orders
            {
                qry = @"
                SELECT 
                    o.ID,
                    u.fullName      AS Waiter,
                    t.tableName     AS TableName,
                    o.created_at     AS Created_at,
                    o.orderStatus   AS OrderStatus,
                    o.paymentStatus AS PaymentStatus,
                    o.total         AS Total
                FROM orders o
                INNER JOIN users u          ON o.waiterID = u.ID
                INNER JOIN custom_tables t  ON o.tableID  = t.ID
                WHERE o.orderStatus = 'Canceled'
                ORDER BY
                    CASE 
                        WHEN o.orderStatus = 'Ready' AND o.paymentStatus = 'Paid' THEN 0
                        ELSE 1
                    END,
                o.created_at DESC;";
            }
            else //show active orders (not closed and not canceled)
            {
                qry = @"
                SELECT 
                    o.ID,
                    u.fullName      AS Waiter,
                    t.tableName     AS TableName,
                    o.created_at     AS Created_at,
                    o.orderStatus   AS OrderStatus,
                    o.paymentStatus AS PaymentStatus,
                    o.total         AS Total
                FROM orders o
                INNER JOIN users u          ON o.waiterID = u.ID
                INNER JOIN custom_tables t  ON o.tableID  = t.ID
                WHERE o.orderStatus <> 'Canceled' AND o.orderStatus <> 'Closed'
                ORDER BY
                    CASE 
                        WHEN o.orderStatus = 'Ready' AND o.paymentStatus = 'Paid' THEN 0
                        ELSE 1
                    END,
                o.created_at DESC;";
            }

            //execute query and fill grid
            using (var cmd = new SqlCommand(qry, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        //Add a new row to the grid
                        int rowIndex = kryptonDataGridView1.Rows.Add();
                        DataGridViewRow row = kryptonDataGridView1.Rows[rowIndex];

                        //row serial number
                        row.Cells["dgvSno"].Value = kryptonDataGridView1.Rows.Count;

                        //display data
                        row.Cells["dgvWaiter"].Value = rdr["Waiter"].ToString();
                        row.Cells["dgvTable"].Value = rdr["TableName"].ToString();
                        row.Cells["dgvDate"].Value = Convert.ToDateTime(rdr["Created_at"]);
                        row.Cells["dgvOrderStatus"].Value = rdr["OrderStatus"].ToString();
                        row.Cells["dgvPaymentStatus"].Value = rdr["PaymentStatus"].ToString();
                        row.Cells["dgvTotal"].Value = Convert.ToDecimal(rdr["Total"]).ToString("0.00");

                        //hidden ID column
                        row.Cells["dgvId"].Value = Convert.ToInt32(rdr["ID"]);

                        //show check icon only when order is Ready AND Paid
                        if (rdr["PaymentStatus"].ToString() == "Paid" && rdr["OrderStatus"].ToString() == "Ready")
                        {
                            row.Cells["dgvClose"].Value = Properties.Resources.check;
                        }
                        else
                        {
                            row.Cells["dgvClose"].Value = Properties.Resources.empty;
                        }

                    }
                }
            }
        }

        //load orders when form opens
        private void formOrdersList_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        //handles clicks on grid buttons Edit / Cancel / Close
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //edit button
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                
                //selected order ID
                orderID = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvId"].Value);

                string paymentStatus = kryptonDataGridView1.CurrentRow.Cells["dgvPaymentStatus"].Value.ToString();
                string orderStatus = kryptonDataGridView1.CurrentRow.Cells["dgvOrderStatus"].Value.ToString();

                //Payment is allowed only for active unpaid orders
                if (paymentStatus == "Unpaid" && orderStatus != "Canceled" && orderStatus != "Closed")
                {
                    canPay = true;
                }

                this.Close();
            }

            //delete button
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                var result = MessageBox.Show(
                    "Are you sure you want to cancel this order?",
                    "Cancel order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                //set orderStatus = 'Canceled'
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvId"].Value);

                    string sql = "UPDATE orders SET orderStatus = 'Canceled' WHERE ID = @id";

                    using (var cmd = new SqlCommand(sql, MainClass.con))
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                        }

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        if (MainClass.con.State == ConnectionState.Open)
                        {
                            MainClass.con.Close();
                        }
                    }

                    //Refresh list
                    LoadOrders();
                }
            }


            //close order button
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvClose")
            {
                string paymentStatus = kryptonDataGridView1.CurrentRow.Cells["dgvPaymentStatus"].Value.ToString();
                string orderStatus = kryptonDataGridView1.CurrentRow.Cells["dgvOrderStatus"].Value.ToString();

                //only paid and ready orders can be closed
                if (orderStatus == "Ready" && paymentStatus == "Paid")
                {
                    int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvId"].Value);

                    //set orderStatus = 'Closed'
                    string sql = "UPDATE orders SET orderStatus = 'Closed' WHERE ID = @id";

                    using (var cmd = new SqlCommand(sql, MainClass.con))
                    {
                        if (MainClass.con.State != ConnectionState.Open)
                        {
                            MainClass.con.Open();
                        }

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        if (MainClass.con.State == ConnectionState.Open)
                        {
                            MainClass.con.Close();
                        }
                    }

                    LoadOrders();
                }
            }
        }

        //Checkbox: show closed orders
        private void cbShowClosed_CheckedChanged(object sender, EventArgs e)
        {
            //only one filter can be active at a time
            if (cbShowClosed.Checked)
            {
                cbShowCanceled.Checked = false;
            }
            LoadOrders();
        }

        //Checkbox: show canceled orders
        private void cbShowCanceled_CheckedChanged(object sender, EventArgs e)
        {
            //only one filter can be active at a time
            if (cbShowCanceled.Checked)
            {
                cbShowClosed.Checked = false;
            }
            LoadOrders();
        }
    }
}
