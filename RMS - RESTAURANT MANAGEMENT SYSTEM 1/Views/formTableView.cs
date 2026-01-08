using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formTableView : viewTemplate
    {
        public formTableView()
        {
            InitializeComponent();
        }

        //Loads tables list from DB to DataGridView
        public void GetData()
        {
            //Select active tables and filter by search text
            string qry = @"SELECT ID, tableName 
                FROM custom_tables 
                WHERE tableName like '%" + txtSearch.Text + "%' AND deleted_at IS NULL";

            //ListBox is used as a column mapper
            ListBox lb = new ListBox(); 
            lb.Items.Add(dgvid); 
            lb.Items.Add(dgvName);

            //Load data into grid
            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }


        private void formTableView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        //Add new table
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //Open Add Table form with blurred background
            MainClass.BgBlured(new formTableAdd());
            GetData();
        }

        //Search text changed
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Table edit button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formTableAdd form = new formTableAdd();

                //Send selected table ID and fill edit form
                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtTableName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);

                //Open edit form with blurred background
                MainClass.BgBlured(form);
                GetData();
            }

            //Table delete
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);

                //Deletion check
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this table?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //set deleted_at
                    string qry = @"
                        UPDATE custom_tables
                        SET deleted_at = GETDATE()
                        WHERE ID = @id";

                    Hashtable ht = new Hashtable();
                    ht.Add("@id", id);
                    MainClass.SQL(qry, ht);

                    MessageBox.Show("Deleted successfully");
                    GetData();
                }
            }
        }
    }
}
