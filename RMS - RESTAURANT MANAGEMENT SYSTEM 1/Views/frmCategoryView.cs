using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms;
using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class frmCategoryView : viewTemplate
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }

        //Loads category list from DB to DataGridView
        public void GetData()
        {
            //Select active categories and filter by search text
            string qry = @"
                SELECT ID, categoryName
                FROM categories 
                WHERE categoryName like '%" + txtSearch.Text + @"%'
                AND deleted_at IS NULL";

            //ListBox is used as a column mapper
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            //Load data into grid
            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }


        //Add new category
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BgBlured(new formCategoryAdd());

            GetData();
        }

        //Search text changed
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Category edit button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formCategoryAdd form = new formCategoryAdd();

                //Send selected category ID and fill edit form
                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtCategoryName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);

                //Open edit form with blurred background
                MainClass.BgBlured(form);
                GetData();
            }

            //Category delete
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);

                //Deletion check
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //set deleted_at
                    string qry = @"
                        UPDATE categories
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
