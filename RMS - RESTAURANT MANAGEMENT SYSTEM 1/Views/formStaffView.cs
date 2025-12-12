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
    public partial class formStaffView : viewTemplate
    {
        public formStaffView()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "Select ID, fullName, phoneNumber, uRole from users where fullName like '%" + txtSearch.Text + "%' and uRole != 'Admin' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);

            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }


        public override void btnAdd_Click(object sender, EventArgs e)
        {

            MainClass.BgBlured(new formStaffAdd());

            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }


        private void formStaffView_Load(object sender, EventArgs e)
        {
            GetData();
        }


        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //User edit
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formStaffAdd form = new formStaffAdd();

                form.txtUsername.Visible = false;
                form.lblUsername.Visible = false;
                form.txtPass.Visible = false;
                form.lblPass.Visible = false;

                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtFullName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
                form.txtPhone.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                form.cbRole.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvRole"].Value);
                MainClass.BgBlured(form);
                GetData();

            }
            //User delete
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
                    string qry = "Delete from users where id = @id";
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
