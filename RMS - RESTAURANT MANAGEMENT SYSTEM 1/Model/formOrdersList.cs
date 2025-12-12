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

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class formOrdersList : Form
    {
        public formOrdersList()
        {
            InitializeComponent();
        }

        public int orderID = 0;
     
        //close
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadOrders()
        {
            kryptonDataGridView1.Rows.Clear();

            string qry = @"
            SELECT 
                o.ID,
                u.fullName      AS Waiter,
                t.tableName     AS TableName,
                o.orderTime     AS OrderTime,
                o.orderStatus   AS Status,
                o.total         AS Total
            FROM orders o
            INNER JOIN users u          ON o.waiterID = u.ID
            INNER JOIN custom_tables t  ON o.tableID  = t.ID
            
            ORDER BY o.orderTime DESC;";
            //WHERE o.orderStatus = 'Ready'
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
                        int rowIndex = kryptonDataGridView1.Rows.Add();
                        DataGridViewRow row = kryptonDataGridView1.Rows[rowIndex];

                        row.Cells["dgvSno"].Value = kryptonDataGridView1.Rows.Count;

                        row.Cells["dgvWaiter"].Value = rdr["Waiter"].ToString();
                        row.Cells["dgvTable"].Value = rdr["TableName"].ToString();
                        row.Cells["dgvDate"].Value = Convert.ToDateTime(rdr["OrderTime"]);
                        row.Cells["dgvStatus"].Value = rdr["Status"].ToString();
                        row.Cells["dgvTotal"].Value = Convert.ToDecimal(rdr["Total"]).ToString("0.00");
                        row.Cells["dgvId"].Value = Convert.ToInt32(rdr["ID"]);
                    }
                }
            }
        }

        private void formOrdersList_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        
        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                orderID = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvId"].Value);
                this.Close();
            }

            //delete button
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvDelete")
            {

            }
        }


    }
}
