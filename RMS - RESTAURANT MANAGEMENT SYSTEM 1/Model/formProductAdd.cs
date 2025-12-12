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

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class formProductAdd : addTemplate
    {
        public formProductAdd()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int cID = 0;

        private void formProductAdd_Load(object sender, EventArgs e)
        {
            string qry = "SELECT ID 'id', categoryName 'name' FROM categories ";

            MainClass.CBFill(qry, cbCategory);

            if(cID > 0)
            {
                cbCategory.SelectedValue = cID;
            }

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Price", txtPrice.Text);
            ht.Add("@CategoryID", Convert.ToInt32(cbCategory.SelectedValue));

            if (id == 0)
            {
                qry = "Insert into products values(@Name, @Price, @CategoryID)";
            }
            else
            {
                qry = "Update products set prodName = @Name, Price = @Price, CategoryID = @CategoryID where ID = @id";
            }

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                txtName.Text = "";
                txtPrice.Text = "";
                cbCategory.SelectedIndex = -1;
            }
        }
    }
}
