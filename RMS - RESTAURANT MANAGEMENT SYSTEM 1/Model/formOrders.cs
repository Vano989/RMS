using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class formOrders : Form
    {
        public formOrders()
        {
            InitializeComponent();
            
        }

        public int orderID = 0;
        public decimal total = 0;
        public string orderStatus = "";

        public int waiterID = 0;
        public int tableID = 0;

        private void formOrders_Load(object sender, EventArgs e)
        {
            //string qry = "SELECT ID 'id', categoryName 'name' FROM categories ";

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;

            lblTableNr.Text = "";
            lblWaiterName.Text = "";

            LoadCategoryButtons();
            //LoadProducts();
        }

        private void LoadCategoryButtons()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();


            var allButton = new KryptonButton();
            allButton.Text = "Show All";
            allButton.Size = new Size(150, 96);

            allButton.Click += (s, e) => LoadProducts(-1);

            flowLayoutPanel1.Controls.Add(allButton);

            string sql = "SELECT * FROM categories";

            using (var cmd = new SqlCommand(sql, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                    MainClass.con.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var catButton = new KryptonButton();
                        catButton.Size = new Size(150, 96);
                        catButton.Text = rdr["categoryName"].ToString();
                        catButton.Tag = rdr["ID"];

                        catButton.Click += CategoryButton_Click;

                        flowLayoutPanel1.Controls.Add(catButton);
                    }
                    
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private void LoadReturnButton()
        {
            var returnButton = new KryptonButton();
            returnButton.Size = new Size(150, 96);
            returnButton.Text = "<- Back";
            flowLayoutPanel1.Controls.Add(returnButton);

            returnButton.Click += (s,e) => LoadCategoryButtons();
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var btn = (KryptonButton)sender;
            int categoryId = Convert.ToInt32(btn.Tag);
            LoadProducts(categoryId);
        }

        private void LoadProducts(int categoryId)
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            string qry = @"
            SELECT ID, prodName, Price, CategoryID
            FROM products
            ORDER BY prodName";

            using (var cmd = new SqlCommand(qry, MainClass.con))
            {
                if (MainClass.con.State != ConnectionState.Open)
                {
                    MainClass.con.Open();
                }

                LoadReturnButton();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (categoryId == Convert.ToInt32(rdr["CategoryID"]) || categoryId== -1) {
                            var card = new ucProduct();
                            card.productId = Convert.ToInt32(rdr["ID"]);
                            card.productName = rdr["prodName"].ToString();
                            card.productPrice = string.Format("{0:0.00}", rdr["Price"]);

                            card.onProductClick += (s, e) => AddProduct(card.productId, card.productName, Convert.ToDecimal(card.productPrice));

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            flowLayoutPanel1.ResumeLayout();
        }

        private void AddProduct(int productId, string productName, decimal productPrice)
        {
            bool found = false;
            DataGridView TargetGrid = kryptonDataGridView1;

            //string name = productName;
            //decimal price = Convert.ToDecimal(productPrice);

            foreach (DataGridViewRow row in TargetGrid.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvProductID"].Value) == productId)
                {
                    row.Cells["dgvQty"].Value = Convert.ToInt32(row.Cells["dgvQty"].Value) + 1;
                    row.Cells["dgvSubtotal"].Value = Convert.ToDecimal(row.Cells["dgvQty"].Value) * Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                    row.Cells["dgvPrice"].Value = productPrice;
                    row.Cells["dgvName"].Value = productName;
                    found = true;

                    total += Convert.ToDecimal(row.Cells["dgvSubtotal"].Value);

                    break;
                }
            }

            if (!found)
            {
                TargetGrid.Rows.Add(
                    0,
                    productId,
                    TargetGrid.Rows.Count + 1,
                    productName,
                    1,
                    productPrice,
                    productPrice
                );

                total += productPrice;
            }

            lblTotal.Text = total.ToString();
        }

        //search on products
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //TODO - Search on products excluding product categories
        }

        //button - details
        private void btnDetails_Click(object sender, EventArgs e)
        {
            formDetailsSettings details = new formDetailsSettings(this);
            MainClass.BgBlured(details);
        }

        //button - ordersList
        private void btnOrdersList_Click(object sender, EventArgs e)
        {
            formOrdersList ordersList = new formOrdersList();
            MainClass.BgBlured(ordersList);

            if (ordersList.orderID > 0)
            {
                orderID = ordersList.orderID;
                LoadOrder();
            }

        }

        //load selected order
        private void LoadOrder()
        {
            kryptonDataGridView1.Rows.Clear();

            string qry = @"SELECT * FROM orders o
                           INNER JOIN order_products op on o.ID = op.orderID
                           INNER JOIN products p ON p.ID = op.productID
                           INNER JOIN users u ON u.ID = o.waiterID
                           INNER JOIN custom_tables t ON t.ID = o.tableID
                           WHERE o.ID = " + orderID + "";

            using (var cmd = new SqlCommand(qry, MainClass.con))
            {

                if (MainClass.con.State != ConnectionState.Open)
                    MainClass.con.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    bool detailsLoaded = false;
                    while (rdr.Read())
                    {

                        if (!detailsLoaded)
                        {
                            waiterID = Convert.ToInt32(rdr["waiterID"]);
                            tableID = Convert.ToInt32(rdr["tableID"]);
                            total = Convert.ToDecimal(rdr["total"]);

                            lblWaiterName.Text = rdr["fullName"].ToString();
                            lblTableNr.Text = rdr["tableName"].ToString();
                            lblTotal.Text = total.ToString("0.00");

                            btnPay.Visible = true;

                            detailsLoaded = true;
                        }

                        /*
                        int productId = Convert.ToInt32(rdr["productID"]);
                        string productName = rdr["prodName"].ToString();
                        int qty = Convert.ToInt32(rdr["quantity"]);
                        decimal price = Convert.ToDecimal(rdr["price"]);
                        decimal subtotal = Convert.ToDecimal(rdr["subtotal"]);*/
                        
                        int rowIndex = kryptonDataGridView1.Rows.Add();
                        var row = kryptonDataGridView1.Rows[rowIndex];

                        row.Cells["dgvProductID"].Value = Convert.ToInt32(rdr["productID"]);
                        row.Cells["dgvSno"].Value = kryptonDataGridView1.Rows.Count;
                        row.Cells["dgvName"].Value = rdr["prodName"].ToString();
                        row.Cells["dgvQty"].Value = Convert.ToInt32(rdr["quantity"]);
                        row.Cells["dgvPrice"].Value = Convert.ToDecimal(rdr["price"]);
                        row.Cells["dgvSubtotal"].Value = Convert.ToDecimal(rdr["subtotal"]);
                    }
                }
            }
        }

        //button - clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            total = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;

            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";

            kryptonDataGridView1.Rows.Clear();

        }

        //send order to Kitchen tasks
        private void btnToKitchen_Click(object sender, EventArgs e)
        {

            if (kryptonDataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("The order is empty.");
                return;
            }

            if (waiterID == 0 || tableID == 0)
            {
                MessageBox.Show("There is no waiter or table assigned to this order.");
                return;
            }

            string qryOrders = "";
            string qryOrderProducts = "";
            orderStatus = "InProgress";

            if (orderID == 0)   //Insert
            {
                qryOrders = @"
                INSERT INTO orders (waiterID, tableID, total, orderStatus)
                VALUES (@waiterID, @tableID, @total, @orderStatus);

                SELECT SCOPE_IDENTITY();";
            }
            else                //Update
            {
                qryOrders = @"
                UPDATE orders
                SET total = total + @total
                WHERE ID = @orderID;

                SELECT @orderID;";

            }

            using (SqlCommand cmd = new SqlCommand(qryOrders, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@waiterID", waiterID);
                cmd.Parameters.AddWithValue("@tableID", tableID);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@orderStatus", orderStatus);

                orderID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            DataGridView TargetGrid = kryptonDataGridView1;
            int orderProductsID = 0;

            foreach (DataGridViewRow row in TargetGrid.Rows)
            {
                //orderProductsID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (orderProductsID == 0)
                {
                    qryOrderProducts = @"
                    INSERT INTO order_products (orderID, productID, quantity, price, subtotal)
                    VALUES (@orderID, @productID, @quantity, @price, @subtotal);";
                }
                else
                {

                }

                int productId = Convert.ToInt32(row.Cells["dgvProductID"].Value);
                int qty = Convert.ToInt32(row.Cells["dgvQty"].Value);
                decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                decimal subtotal = Convert.ToDecimal(row.Cells["dgvSubtotal"].Value);

                using (SqlCommand cmdProducts = new SqlCommand(qryOrderProducts, MainClass.con))
                {
                    cmdProducts.Parameters.AddWithValue("@orderID", orderID);
                    cmdProducts.Parameters.AddWithValue("@productID", productId);
                    cmdProducts.Parameters.AddWithValue("@quantity", qty);
                    cmdProducts.Parameters.AddWithValue("@price", price);
                    cmdProducts.Parameters.AddWithValue("@subtotal", subtotal);

                    cmdProducts.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Order is sent to kitchen!");

            total = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;

            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";

            kryptonDataGridView1.Rows.Clear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string qry = "UPDATE orders SET orderStatus = 'Paid' WHERE ID = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@id", orderID);

            MainClass.SQL(qry, ht);
            MessageBox.Show("Order paid successfully");

            total = 0;
            waiterID = 0;
            tableID = 0;
            orderID = 0;

            lblTotal.Text = "0.0";
            lblTableNr.Text = "";
            lblWaiterName.Text = "";

            kryptonDataGridView1.Rows.Clear();
            btnPay.Visible = false;
        }
    }
}
