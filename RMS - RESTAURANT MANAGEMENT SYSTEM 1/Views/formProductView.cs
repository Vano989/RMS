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

        public void GetData()
        {
            //string qry = "Select ID, prodName, , Price from users where fullName like '%" + txtSearch.Text + "%' and uRole != 'Admin' ";
            string qry = "SELECT p.ID, p.prodName, p.Price, c.categoryName, c.ID FROM products p JOIN categories c ON p.CategoryID = c.ID WHERE p.prodName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvCategory);
            lb.Items.Add(dgvCatID);
            

            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }


        public override void btnAdd_Click(object sender, EventArgs e)
        {

            MainClass.BgBlured(new formProductAdd());

            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }


        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Edit
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formProductAdd form = new formProductAdd();

                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.cID = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvCatID"].Value);

                form.txtName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
                form.txtPrice.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvPrice"].Value);
                form.cbCategory.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvCategory"].Value);
                MainClass.BgBlured(form);
                GetData();

            }
            //Delete
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
                    string qry = "Delete from products where id = @id";
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
