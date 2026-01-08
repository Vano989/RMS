using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.formMain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        //Role names for access control
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string Manager = "Manager";
            public const string Waiter = "Waiter";
            public const string Cook = "Cook";
        }

        //Reference to login form(used for logout)
        public formLogin LoginForm { get; set; }

        //instance of main form
        static formMain _obj;
        public static formMain Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new formMain();
                }
                return _obj;
            }
        }

        //Loads a child form into the main panel
        public void Navigate(Form f)
        {
            //Clear previous content
            mPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;

            //Add and show form inside panel
            mPanel.Controls.Add(f);
            f.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            //Display current user role in header
            labelUsername.Text = formLogin.uRole;
            _obj = this;
            //Apply access rules based on user role
            ApplyRoleAccess();
        }

        //Navigation buttons
        private void btnCategories_Click(object sender, EventArgs e)
        {
            Navigate(new Views.frmCategoryView());
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formTableView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formStaffView());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formProductView());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formOrders());
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formKitchenView());
        }

        //Logout button
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Confirm logout
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?", 
                "Log out", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                //clear user role
                formLogin.uRole = null;

                //show login form
                LoginForm.Show();

                //close main form
                this.Close();
            }
        }

        //Enables or disables UI buttons based on user role
        private void ApplyRoleAccess()
        {
            string role = formLogin.uRole;
           
            btnCategories.Enabled = false;
            btnTables.Enabled = false;
            btnStaff.Enabled = false;
            btnProducts.Enabled = false;
            btnOrders.Enabled = false;
            btnKitchen.Enabled = false;

            if (role == Roles.Manager) //Manager - Full access
            {
                btnCategories.Enabled = true;
                btnTables.Enabled = true;
                btnStaff.Enabled = true;
                btnProducts.Enabled = true;
                btnOrders.Enabled = true;
                btnKitchen.Enabled = true;
            }
            else if (role == Roles.Waiter)  //Waiter - only "Orders" page
            {
                btnOrders.Enabled = true;
            }
            else if (role == Roles.Cook) //Cook - only "Kitchen" page
            {
                btnKitchen.Enabled = true;
            }
            else
            {
                MessageBox.Show("Access denied: unknown role.");
            }
        }
    }
}
