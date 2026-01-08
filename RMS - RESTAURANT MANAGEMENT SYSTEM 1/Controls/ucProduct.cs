using Microsoft.Extensions.Logging;
using Microsoft.Win32;
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

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Controls
{
    public partial class ucProduct : UserControl
    {
        //Event triggered when product card is clicked
        public event EventHandler OnProductClick;

        public ucProduct()
        {
            InitializeComponent();

            
            RegisterClickEvent(this);
        }

        //ensure click is detected on any part of card
        private void RegisterClickEvent(Control parent)
        {
            parent.Click += Product_Click;

            foreach (Control child in parent.Controls)
            {
                RegisterClickEvent(child);
            }
        }

        private void Product_Click(object sender, EventArgs e)
        {
            OnProductClick?.Invoke(this, EventArgs.Empty);
        }


        public int productId { get; set; }

        //product name displayed on the card
        public string productName {
            get => lblProductName.Text; 
            set => lblProductName.Text = value;
        }

        //price displayed on the card
        public string productPrice
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }
    }
}
