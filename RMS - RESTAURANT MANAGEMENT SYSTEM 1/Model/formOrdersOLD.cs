using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class formOrders : Form
    {
        public formOrders()
        {
            InitializeComponent();
        }

       
    private void formOrders_Load(object sender, EventArgs e)
        {
            string qry = "SELECT ID 'id', categoryName 'name' FROM categories ";

            MainClass.CBFill(qry, cbCategory);
        }

        private void ucProduct4_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Header_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
