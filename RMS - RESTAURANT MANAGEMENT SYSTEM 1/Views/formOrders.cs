using ComponentFactory.Krypton.Toolkit;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formOrders : Form
    {
        public formOrders()
        {
            InitializeComponent();
        }

        //Current order identifier
        public int orderID = 0;

        //Total sum of all items in the grid
        public decimal total = 0;

        //Discount value (absolute amount, not percent)
        public decimal discountValue = 0;

        public string orderStatus = "";
        public string paymentStatus = "";

        //Selected waiter and table for the order
        public int waiterID = 0;
        public int tableID = 0;

        private void formOrders_Load(object sender, EventArgs e)
        {
            //Configure the products/categories container
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;

            //Configure table label: fixed width with ellipsis for long text
            lblTableNr.Text = "";
            lblTableNr.AutoSize = false;
            lblTableNr.AutoEllipsis = true;
            lblTableNr.Width = 220;

            //Configure waiter label: fixed width with ellipsis for long text
            lblWaiterName.Text = "";
            lblWaiterName.AutoSize = false;
            lblWaiterName.AutoEllipsis = true;
            lblWaiterName.Width = 220;

            //Details button is visible when creating a new order
            LoadCategoryButtons();
            btnDetails.Visible = true;
        }

        private void LoadCategoryButtons()
        {
            //Rebuild the panel content (categories list)
            flowLayoutPanel1.SuspendLayout();

            //Dispose existing controls to prevent memory leaks
            foreach (Control c in flowLayoutPanel1.Controls.Cast<Control>().ToList())
            {
                flowLayoutPanel1.Controls.Remove(c);
                c.Dispose(); 
            }
            flowLayoutPanel1.ResumeLayout();


            //"Show All" button loads all products (categoryId = -1)
            var allButton = new KryptonButton();
            allButton.Text = "Show All";
            allButton.Size = new Size(150, 96);
            allButton.StateCommon.Content.ShortText.Font = new Font("Nirmala UI", 16F, FontStyle.Regular);

            //Show all products
            allButton.Click += (s, e) => LoadProducts(-1);

            flowLayoutPanel1.Controls.Add(allButton);

            string sql = "SELECT * FROM categories WHERE deleted_at IS NULL";

            using (var cmd = new SqlCommand(sql, MainClass.con))
            {
                //Ensure SQL connection is open
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                //Read categories and create a button for each
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var catButton = new KryptonButton();
                        catButton.Size = new Size(150, 96);
                        catButton.StateCommon.Content.ShortText.Font = new Font("Nirmala UI", 16F, FontStyle.Regular);
                        catButton.Text = rdr["categoryName"].ToString();
                        catButton.Tag = rdr["ID"];

                        //load products by this category
                        catButton.Click += CategoryButton_Click;

                        flowLayoutPanel1.Controls.Add(catButton);
                    }
                }
            }
            //Resume layout updates
            flowLayoutPanel1.ResumeLayout();
        }

        private void LoadReturnButton()
        {
            //Add a "Back" button that returns to categories view
            var returnButton = new KryptonButton();
            returnButton.Size = new Size(150, 96);
            returnButton.StateCommon.Content.ShortText.Font = new Font("Nirmala UI", 16F, FontStyle.Regular);
            returnButton.Text = "<- Back";
            flowLayoutPanel1.Controls.Add(returnButton);

            //Go back to category buttons
            returnButton.Click += (s,e) => LoadCategoryButtons();
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            //Cast sender to the clicked category button
            var btn = (KryptonButton)sender;

            //Read category id stored in Tag
            int categoryId = Convert.ToInt32(btn.Tag);

            //Load products for selected category
            LoadProducts(categoryId);
        }

        private void LoadProducts(int categoryId)
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            string qry = @"
            SELECT ID, prodName, Price, CategoryID
            FROM products
            WHERE deleted_at IS NULL
            ORDER BY prodName";

            using (var cmd = new SqlCommand(qry, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                //Always add Back button at the top
                LoadReturnButton();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        //Show product if matches selected category or if "Show All"(categoryId == -1)
                        if (categoryId == Convert.ToInt32(rdr["CategoryID"]) || categoryId== -1) {

                            //Create a UI product card (custom user control)
                            var card = new ucProduct();
                            card.productId = Convert.ToInt32(rdr["ID"]);
                            card.productName = rdr["prodName"].ToString();
                            card.productPrice = string.Format("{0:0.00}", rdr["Price"]);

                            //When user clicks product card -> add product to order grid
                            card.OnProductClick += (s, e) => AddProduct(card.productId, card.productName, Convert.ToDecimal(card.productPrice));

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            flowLayoutPanel1.ResumeLayout();
        }

        private void AddProduct(int productId, string productName, decimal productPrice)
        {
            //Target grid where order items are listed
            DataGridView TargetGrid = kryptonDataGridView1;

            //If product already exists in grid -> increment quantity
            foreach (DataGridViewRow row in TargetGrid.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvProductID"].Value) == productId)
                {
                    int qty = Convert.ToInt32(row.Cells["dgvQty"].Value) + 1;
                    row.Cells["dgvQty"].Value = qty;
                    row.Cells["dgvPrice"].Value = productPrice;
                    row.Cells["dgvName"].Value = productName;
                    row.Cells["dgvSubtotal"].Value = qty * productPrice;

                    RecalcTotalFromGrid();
                    RefreshMinusIcons();
                    return;
                }
            }

            //If product is not in grid->add a new row
            TargetGrid.Rows.Add(
                0,
                productId,
                TargetGrid.Rows.Count + 1,
                productName,
                1,
                productPrice,
                productPrice
            );

            RecalcTotalFromGrid();
            RefreshMinusIcons();

        }

        //button - details : open order settings dialog (table/waiter assignment)
        private void btnDetails_Click(object sender, EventArgs e)
        {
            formDetailsSettings details = new formDetailsSettings(this);
            MainClass.BgBlured(details);
        }

        //button - ordersList : open existing orders list and load selected order for editing/payment
        private void btnOrdersList_Click(object sender, EventArgs e)
        {
            formOrdersList ordersList = new formOrdersList();
            MainClass.BgBlured(ordersList);

            if (ordersList.orderID > 0)
            {
                orderID = ordersList.orderID;

                //canPay controls whether we allow payment & discount editing
                btnPay.Visible = ordersList.canPay;
                txtDiscount.ReadOnly = !ordersList.canPay;

                LoadOrder();
            }
        }

        //Stores product quantities as they were loaded from DB for an existing order
        //This is used to prevent removing items that already existed in DB
        private Dictionary<int, int> loadedQty = new Dictionary<int, int>();

        //Load selected order
        private void LoadOrder()
        {
            kryptonDataGridView1.Rows.Clear();
            loadedQty.Clear();

            //Header query: order + waiter name + table name
            string qryHeader = @"
                SELECT o.ID, o.waiterID, o.tableID, o.total, o.discountValue, o.orderStatus, o.paymentStatus, u.fullName, t.tableName
                FROM orders o
                LEFT JOIN users u ON u.ID = o.waiterID
                LEFT JOIN custom_tables t ON t.ID = o.tableID
                WHERE o.ID = @orderID;";

            //Items query: group order_products by product and count how many rows => qty
            string qryItems = @"
                SELECT op.productID, p.prodName, COUNT(*) AS qty, MAX(op.price) AS price, COUNT(*) * MAX(op.price) AS subtotal
                FROM order_products op
                INNER JOIN products p ON p.ID = op.productID
                WHERE op.orderID = @orderID
                GROUP BY op.productID, p.prodName
                ORDER BY p.prodName;";

            if (MainClass.con.State != ConnectionState.Open)
            {
                MainClass.con.Open();
            }

            //Load header data
            using (var cmd = new SqlCommand(qryHeader, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        waiterID = Convert.ToInt32(rdr["waiterID"]);
                        tableID = Convert.ToInt32(rdr["tableID"]);
                        total = Convert.ToDecimal(rdr["total"]);

                        //Discount can be NULL
                        if (rdr["discountValue"] == DBNull.Value)
                        {
                            discountValue = 0;
                            txtDiscount.Text = "";
                        }
                        else
                        {
                            discountValue = Convert.ToDecimal(rdr["discountValue"]);
                            txtDiscount.Text = discountValue.ToString("0.00");
                        }

                        orderStatus = rdr["orderStatus"].ToString();
                        paymentStatus = rdr["paymentStatus"].ToString();

                        lblWaiterName.Text = rdr["fullName"].ToString();
                        lblTableNr.Text = rdr["tableName"].ToString();

                        //If order is closed/canceled/paid, do not allow sending to kitchen and change details
                        if (orderStatus == "Closed" || orderStatus == "Canceled" || paymentStatus == "Paid")
                        {
                            btnToKitchen.Visible = false;
                            btnDetails.Visible = false;
                        }
                        else
                        {
                            btnToKitchen.Visible = true;
                            btnDetails.Visible = true;
                        }
                    }
                }
            }

            //Load item rows into grid
            using (var cmd2 = new SqlCommand(qryItems, MainClass.con))
            {
                cmd2.Parameters.AddWithValue("@orderID", orderID);
                using (var rdr = cmd2.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        //Add a new row to grid and fill its cells
                        int rowIndex = kryptonDataGridView1.Rows.Add();
                        var row = kryptonDataGridView1.Rows[rowIndex];

                        int productID = Convert.ToInt32(rdr["productID"]);
                        string prodName = rdr["prodName"].ToString();
                        int quantity = Convert.ToInt32(rdr["qty"]);
                        decimal price = Convert.ToDecimal(rdr["price"]);
                        decimal subtotal = Convert.ToDecimal(rdr["subtotal"]);

                        row.Cells["dgvProductID"].Value = productID;
                        row.Cells["dgvSno"].Value = rowIndex + 1;
                        row.Cells["dgvName"].Value = prodName;
                        row.Cells["dgvQty"].Value = quantity;
                        row.Cells["dgvPrice"].Value = price;
                        row.Cells["dgvSubtotal"].Value = subtotal;

                        loadedQty[productID] = quantity;

                    }
                }
            }

            //Close connection
            if (MainClass.con.State == ConnectionState.Open)
            {
                MainClass.con.Close();
            }

            RecalcTotalFromGrid();
            RefreshMinusIcons();
        }


        //button - clear : reset current order draft
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear items grid
            kryptonDataGridView1.Rows.Clear();

            //Reset all state fields
            total = 0;
            discountValue = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;

            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";
            txtDiscount.Text = "";

            //default buttons visibility
            btnPay.Visible = false;
            btnDetails.Visible = true;
            btnToKitchen.Visible = true;
            RefreshMinusIcons();
        }

        //Send order to Kitchen : save or update order and insert new order_products rows
        private void btnToKitchen_Click(object sender, EventArgs e)
        {
            //Cannot send empty order
            if (kryptonDataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("The order is empty.");
                return;
            }

            //must have waiter and table selected in details
            if (waiterID == 0 || tableID == 0)
            {
                MessageBox.Show("There is no waiter or table assigned to this order.");
                return;
            }

            if (MainClass.con.State != ConnectionState.Open)
            {
               MainClass.con.Open();
            }

            //Insert item row in order_products
            string qryOrderProducts = @"
                INSERT INTO order_products (orderID, productID, price)
                VALUES (@orderID, @productID, @price)";

            if (orderID == 0)
            {
                //Insert into orders, then return the generated ID
                string qryOrders = @"
                INSERT INTO orders (waiterID, tableID, total, orderStatus, paymentStatus)
                VALUES (@waiterID, @tableID, @total, @orderStatus, @paymentStatus);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(qryOrders, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@waiterID", waiterID);
                    cmd.Parameters.AddWithValue("@tableID", tableID);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@orderStatus", "New");
                    cmd.Parameters.AddWithValue("@paymentStatus", "Unpaid");

                    //Read generated ID for the new order
                    orderID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //Insert each product qty into order_products
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    int productID = Convert.ToInt32(row.Cells["dgvProductID"].Value);
                    int qtyGrid = Convert.ToInt32(row.Cells["dgvQty"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);

                    for (int i = 0; i < qtyGrid; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(qryOrderProducts, MainClass.con))
                        {
                            cmd.Parameters.AddWithValue("@orderID", orderID);
                            cmd.Parameters.AddWithValue("@productID", productID);
                            cmd.Parameters.AddWithValue("@price", price);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (MainClass.con.State == ConnectionState.Open)
                {
                   MainClass.con.Close();
                }
            } 
            else {

                //EXISTING ORDER: only add new items(qty in grid - qty loaded from DB)
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    int productID = Convert.ToInt32(row.Cells["dgvProductID"].Value);
                    int qtyGrid = Convert.ToInt32(row.Cells["dgvQty"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);

                    //Previously loaded qty from DB (0 if product was not in original order)
                    int qtyLoaded = 0;
                    if (loadedQty.ContainsKey(productID))
                    {
                        qtyLoaded = loadedQty[productID];
                    }

                    //Insert only additional units
                    int toAdd = qtyGrid - qtyLoaded;

                    for (int i = 0; i < toAdd; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(qryOrderProducts, MainClass.con))
                        {
                            cmd.Parameters.AddWithValue("@orderID", orderID);
                            cmd.Parameters.AddWithValue("@productID", productID);
                            cmd.Parameters.AddWithValue("@price", price);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                //Update order header totals and mark as "Changed"
                string updOrder = @"
                UPDATE orders
                SET total = @total, orderStatus = 'Changed', updated_at = GETDATE()
                WHERE ID = @orderID;";

                using (SqlCommand cmd = new SqlCommand(updOrder, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    
                    cmd.ExecuteNonQuery();
                }

                loadedQty.Clear();
            }

            MessageBox.Show("Order has been sent to kitchen!");

            //Reset form to default state
            kryptonDataGridView1.Rows.Clear();

            total = 0;
            discountValue = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;
            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";
            txtDiscount.Text = "";

            
            btnPay.Visible = false;
            btnDetails.Visible = true;
            btnToKitchen.Visible = true;
        }

        //Pay button : mark order as paid and store discount value
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (discountValue < 0)
            {
                MessageBox.Show(
                    "Discount value is invalid.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (discountValue > total)
            {
                MessageBox.Show(
                    "Discount cannot be greater than total amount.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            //Update payment status and discount
            string qry = "UPDATE orders SET paymentStatus = 'Paid', discountValue = @disc WHERE ID = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@id", orderID);
            ht.Add("@disc", discountValue);

            //Execute SQL command
            MainClass.SQL(qry, ht);
            MessageBox.Show("Order paid successfully");

            //Reset form to default state after payment
            kryptonDataGridView1.Rows.Clear();

            total = 0;
            discountValue = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;
            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";
            txtDiscount.Text = "";

            
            btnPay.Visible = false;
            btnDetails.Visible = true;
            btnToKitchen.Visible = true;
        }

        //Handles click on grid cells (used for remove icon column)
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            //Only handle clicks on the remove column
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvRemove")
            {
                if (kryptonDataGridView1.Rows.Count == 0) return;

                var row = kryptonDataGridView1.Rows[e.RowIndex];

                int productID = Convert.ToInt32(row.Cells["dgvProductID"].Value);
                int qty = Convert.ToInt32(row.Cells["dgvQty"].Value);
                decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);

                //Quantity in grid update
                if (orderID == 0)
                {
                    if (qty > 1)
                    {
                        qty--;
                        row.Cells["dgvQty"].Value = qty;
                        row.Cells["dgvSubtotal"].Value = qty * price;
                    }
                    else
                    {
                        //Remove row if qty becomes 0
                        kryptonDataGridView1.Rows.RemoveAt(e.RowIndex);
                    }

                    RecalcTotalFromGrid();
                }
                else
                {
                    int loaded = 0;
                    if (loadedQty.ContainsKey(productID)) 
                    { 
                        loaded = loadedQty[productID];
                    }

                    //Only allow decrement if current qty is greater than loaded qty
                    if (qty > loaded)
                    {
                        if (qty > 1)
                        {
                            qty--;
                            row.Cells["dgvQty"].Value = qty;
                            row.Cells["dgvSubtotal"].Value = qty * price;
                        }
                        else
                        {
                            kryptonDataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                        RecalcTotalFromGrid();
                    }
                }
                RefreshMinusIcons();
            }
        }

        //Update the remove icon depending on whether removal is allowed
        private void RefreshMinusIcons()
        {
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int qty = Convert.ToInt32(row.Cells["dgvQty"].Value);

                    bool canRemove;

                    //For a new order, always allow removal
                    if (orderID == 0)
                    {
                        canRemove = true;
                    }
                    else
                    {
                        //For existing order, allow removal only if qty > loaded qty
                        int productID = Convert.ToInt32(row.Cells["dgvProductID"].Value);

                        int loaded = 0;
                        if (loadedQty.ContainsKey(productID))
                            loaded = loadedQty[productID];

                        canRemove = qty > loaded;
                    }

                    if (canRemove)
                    {
                        row.Cells["dgvRemove"].Value = Properties.Resources.minus;
                    }
                    else
                    {
                        row.Cells["dgvRemove"].Value = Properties.Resources.empty;
                    }
                }
            }
        }

        //Sum all row subtotals from the grid
        private void RecalcTotalFromGrid()
        {
            decimal sum = 0;
            foreach (DataGridViewRow r in kryptonDataGridView1.Rows)
            {
                if (!r.IsNewRow)
                {
                    sum += Convert.ToDecimal(r.Cells["dgvSubtotal"].Value);
                }
            }

            //Store total and show total with discount in label
            total = sum;
            lblTotal.Text = (total - discountValue).ToString("0.00");
        }

        //Discount
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //Discount is only editable/used when Pay button is visible
            if (btnPay.Visible)
            {
                if (txtDiscount.Text == "")
                {
                    discountValue = 0;
                }
                else
                {
                    //Parse discount value (handles dot decimal separator)
                    //Also replaces comma with dot to support user typing comma.
                    if (decimal.TryParse(
                        txtDiscount.Text.Replace(',', '.'),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                    out decimal value))
                    {
                        discountValue = value; //If parse fails, discountValue stays unchanged
                    }
                }
                //Update total label with the new discount value
                RecalcTotalFromGrid();
            }
        }
    }
}
