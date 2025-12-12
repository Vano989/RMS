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
    public partial class formTableAdd : addTemplate
    {
        public formTableAdd()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtTableName.Text);


            if (id == 0)
            {
                qry = "Insert into custom_tables values(@Name)";
            }
            else
            {
                qry = "Update custom_tables set tableName = @Name where ID = @id";
            }

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                txtTableName.Focus();
                txtTableName.Text = "";
            }
        }
    }
}
