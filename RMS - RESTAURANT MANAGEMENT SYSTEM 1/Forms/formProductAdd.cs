using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formProductAdd : addTemplate
    {
        public formProductAdd()
        {
            InitializeComponent();
        }

        //Product ID(0 = new product, >0 = edit existing)
        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Product fields validation
        private bool ValidateProduct()
        {
            string name = "";
            string priceText = "";
            decimal price = 0;

            //read and trim name
            if (txtName.Text != null)
            {
                name = txtName.Text.Trim();
            }

            //read and trim price text
            if (txtPrice.Text != null)
            {
                priceText = txtPrice.Text.Trim();
            }

            //required fields check
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText) || cbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("All required fields must be filled.");
                txtName.Focus();
                return false;
            }
            else if (name.Length > 50)  //name length check
            {
                MessageBox.Show("Product name cannot exceed 50 symbols.");
                txtName.Focus();
                return false;
            }
            else if (!decimal.TryParse(priceText, out price) || price < 0)  //price must be a decimal number and cannot be negative
            {                                                               //TryParse returns false if text is not a number
                MessageBox.Show("Invalid price value.");
                txtPrice.Focus();
                return false;
            }
       

            return true;
        }


        public int cID = 0;

        private void formProductAdd_Load(object sender, EventArgs e)
        {
            //load categories for ComboBox
            string qry = "SELECT ID 'id', categoryName 'name' FROM categories ";
            MainClass.CBFill(qry, cbCategory);

            //set category in ComboBox (when edit product)
            if (cID > 0)
            {
                cbCategory.SelectedValue = cID;
            }

        }

        //insert new product or update existing
        public override void btnSave_Click(object sender, EventArgs e)
        {
            //Stop if validation fails
            if (!ValidateProduct())
                return;

            string qry = "";

            //parameters for SQL query
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Price", Convert.ToDecimal(txtPrice.Text));
            ht.Add("@CategoryID", Convert.ToInt32(cbCategory.SelectedValue));

            //Insert new product
            if (id == 0)
            {
                qry = "INSERT INTO products VALUES(@Name, @Price, @CategoryID, NULL)";
            }
            else //Update existing product
            {
                qry = "UPDATE products SET prodName = @Name, Price = @Price, CategoryID = @CategoryID WHERE ID = @id";
            }

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                txtName.Text = "";
                txtPrice.Text = "";
                cbCategory.SelectedIndex = -1;
                this.Close();
            }
        }
    }
}
