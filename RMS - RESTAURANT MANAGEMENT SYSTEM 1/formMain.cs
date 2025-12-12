using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }
        
        //
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

        public void Navigate(Form f)
        {
            mPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            mPanel.Controls.Add(f);
            f.Show();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            labelUsername.Text = formLogin.uRole;
            _obj = this;
        }

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

        private void btnPOS_Click(object sender, EventArgs e)
        {
            Navigate(new Model.formOrders());
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            Navigate(new Views.formKitchenView());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Navigate(new pnlReports());
        }

    }
}
