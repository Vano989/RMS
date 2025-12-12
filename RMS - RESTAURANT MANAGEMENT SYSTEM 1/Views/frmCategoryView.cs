using RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model;
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

        public void GetData()
        {
            string qry = "Select * from categories where categoryName like '%"+ txtSearch.Text +"%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }


        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BgBlured(new formCategoryAdd());

            GetData();
        }

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

            //Category edit
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formCategoryAdd form = new formCategoryAdd();

                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtCategoryName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
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
                    string qry = "Delete from categories where id = @id";
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
