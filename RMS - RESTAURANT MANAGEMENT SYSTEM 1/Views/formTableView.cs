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
    public partial class formTableView : viewTemplate
    {
        public formTableView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * from custom_tables where tableName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }

        private void formTableView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BgBlured(new formTableAdd());
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Table edit
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formTableAdd form = new formTableAdd();

                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtTableName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
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
                    string qry = "Delete from custom_tables where id = @id";
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
