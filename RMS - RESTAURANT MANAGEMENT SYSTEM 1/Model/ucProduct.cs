using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class ucProduct : UserControl
    {

        public event EventHandler onProductClick = null;

        public ucProduct()
        {
            InitializeComponent();

            //onProductClicked?.Invoke(this, EventArgs.Empty);

            this.Click += (s, e) => onProductClick?.Invoke(this, e);
            foreach (Control c in Controls)
            {
                c.Click += (s, e) => onProductClick?.Invoke(this, e);
            }
        }
        public DataGridView TargetGrid { get; set; }

        public int productId { get; set; }
        public string productName {
            get => lblProductName.Text; 
            set => lblProductName.Text = value;
        }

        public string productPrice
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;                 //$"{Convert.ToDecimal(value):0.00}"
        }

        public string productCategory { get; set; }


        /*private void HandleClick()
        {
            if (TargetGrid == null) return;

            bool found = false;

            //string name = productName;
            //decimal price = Convert.ToDecimal(productPrice);

            foreach (DataGridViewRow row in TargetGrid.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvid"].Value) == productId)
                {
                    row.Cells["dgvQty"].Value = Convert.ToInt32(row.Cells["dgvQty"].Value)+ 1;
                    row.Cells["dgvSubtotal"].Value = Convert.ToInt32(row.Cells["dgvQty"].Value) * Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                    row.Cells["dgvPrice"].Value = productPrice;
                    row.Cells["dgvName"].Value = productName;
                    found = true;
                }
            }
            if(!found) {
                TargetGrid.Rows.Add(
                productId,
                TargetGrid.Rows.Count + 1,
                productName,
                1,
                productPrice,
                productPrice
            );
            }


        }*/
    }
}
