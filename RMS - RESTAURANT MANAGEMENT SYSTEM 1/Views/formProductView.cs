using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formProductView : viewTemplate
    {
        public formProductView()
        {
            InitializeComponent();
        }

        private void formProductView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        //Loads products from DB and displays them in DataGridView
        public void GetData()
        {
            //Select products with category, filter by search text, show only not deleted
            string qry = @"SELECT p.ID, p.prodName, p.Price, c.categoryName, c.ID 
                FROM products p 
                JOIN categories c ON p.CategoryID = c.ID 
                WHERE p.prodName like '%" + txtSearch.Text + "%' AND p.deleted_at IS NULL";

            //ListBox is used as a column mapper
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvCategory);
            lb.Items.Add(dgvCatID);

            //Load data to grid
            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }

        //Add new product
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //open Add Product form with blurred background
            MainClass.BgBlured(new formProductAdd());

            //refresh grid after adding
            GetData();
        }

        //if search text changed, reload grid with filter
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }


        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Edit button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formProductAdd form = new formProductAdd();

                //Send selected product ID and category ID to edit form
                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.cID = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvCatID"].Value);

                //Fill edit form fields using selected row values
                form.txtName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
                form.txtPrice.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvPrice"].Value);
                form.cbCategory.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvCategory"].Value);

                //open edit form with blured background
                MainClass.BgBlured(form);
                GetData();

            }
            //Delete button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);

                //Deletion check
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //set deleted_at
                    string qry = @"
                        UPDATE products
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
