using ComponentFactory.Krypton.Toolkit;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formDetailsSettings : Form
    {
        //reference to parent order form
        private readonly formOrders orderData;
        public formDetailsSettings(formOrders parent)
        {
            InitializeComponent();

            orderData = parent;

            //load available waiters and tables
            LoadTables(flowLayoutPanel2);
            LoadWaiters(flowLayoutPanel1);
        }

        //exit (close form)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //load buttons for tables
        private void LoadTables(FlowLayoutPanel panel)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            //get available tables
            string qry = @"
            SELECT ID, tableName
            FROM custom_tables 
            WHERE deleted_at IS NULL
            ORDER BY tableName";

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
                        //create button for table
                        var btn = new KryptonButton();
                        btn.Size = new Size(150, 96);
                        btn.StateCommon.Content.ShortText.Font = new Font("Nirmala UI", 16F, FontStyle.Regular);
                        btn.Text = rdr["tableName"].ToString();
                        btn.Tag = rdr["ID"];

                        //assign table to order
                        btn.Click += (s, e) => {
                            orderData.tableID = Convert.ToInt32(btn.Tag);
                            orderData.lblTableNr.Text = btn.Text;
                        };

                        panel.Controls.Add(btn);
                        
                    }
                }
            }
            panel.ResumeLayout();
        }

        //load buttons for waiters
        private void LoadWaiters(FlowLayoutPanel panel)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            //get users with Waiter or Manager role
            string qry = $@"
            SELECT ID, fullName
            FROM users 
            WHERE uRole IN ('Waiter', 'Manager')
            AND deleted_at IS NULL
            ORDER BY fullName";

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
                        //create waiter button
                        var btn = new KryptonButton();
                        btn.Size = new Size(150, 96);
                        btn.StateCommon.Content.ShortText.Font = new Font("Nirmala UI", 16F, FontStyle.Regular);
                        btn.Text = rdr["fullName"].ToString();
                        btn.Tag = rdr["ID"];

                        //assign waiter to order
                        btn.Click += (s, e) => {
                            orderData.waiterID = Convert.ToInt32(btn.Tag);
                            orderData.lblWaiterName.Text = btn.Text;
                        };

                        panel.Controls.Add(btn);

                    }
                }
            }
            panel.ResumeLayout();
        }

    }
}
