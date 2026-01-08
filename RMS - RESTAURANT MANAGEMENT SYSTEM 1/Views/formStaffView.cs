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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Views
{
    public partial class formStaffView : viewTemplate
    {
        public formStaffView()
        {
            InitializeComponent();
        }

        //Loads users list from DB to DataGridView
        public void GetData()
        {
            //Select active users and filter by search text
            string qry = @"
                SELECT ID, fullName, phoneNumber, uRole
                FROM users 
                WHERE fullName like '%" + txtSearch.Text + "%' AND deleted_at IS NULL ";

            //ListBox is used as a column mapper
            ListBox lb = new ListBox(); 
            lb.Items.Add(dgvid); 
            lb.Items.Add(dgvName); 
            lb.Items.Add(dgvPhone); 
            lb.Items.Add(dgvRole);

            //Load data into grid
            MainClass.LoadData(qry, kryptonDataGridView1, lb);
        }

        //Add new user
        public override void btnAdd_Click(object sender, EventArgs e)
        {

            //Open Add form with blurred background
            MainClass.BgBlured(new formStaffAdd());

            GetData();
        }

        //Search text changed
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

            //User edit button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                formStaffAdd form = new formStaffAdd();

                //Hide username and password fields in edit mode
                form.txtUsername.Visible = false;
                form.lblUsername.Visible = false;
                form.txtPass.Visible = false;
                form.lblPass.Visible = false;

                //Pass selected user ID and fill form fields from current row
                form.id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);
                form.txtFullName.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvName"].Value);
                form.txtPhone.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                form.cbRole.Text = Convert.ToString(kryptonDataGridView1.CurrentRow.Cells["dgvRole"].Value);

                //Open edit form with blured background
                MainClass.BgBlured(form);
                GetData();
            }

            //User delete button clicked
            if (kryptonDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                int id = Convert.ToInt32(kryptonDataGridView1.CurrentRow.Cells["dgvid"].Value);

                //Prevent user from deleting themselves
                if (id == formLogin.uId)
                {
                    MessageBox.Show(
                        "You cannot delete the account you are currently logged in with.",
                        "Action not allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

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
                        UPDATE users
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
