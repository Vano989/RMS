using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formCategoryAdd : addTemplate
    {
        public formCategoryAdd()
        {
            InitializeComponent();
        }

        //category ID (0 = new category, >0 = edit existing)
        private int _id = 0; 
        public int id        
        {
            get { return _id; }
            set { _id = value; }
        }

        //checks if a category with the same name already exists
        private bool CategoryExists(string categoryName)
        {
            try
            {
                string sql = @"
                SELECT COUNT(*)
                FROM categories
                WHERE categoryName = @categoryName
                    AND deleted_at IS NULL";

                using (SqlCommand cmd = new SqlCommand(sql, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@categoryName", categoryName);

                    if (MainClass.con.State == ConnectionState.Closed)
                    {
                        MainClass.con.Open();
                    }

                    //returns a single value from the query COUNT(*)
                    int count = (int)cmd.ExecuteScalar();

                    //if count >= 1 -> category already exists
                    return count > 0;
                }
            }
            finally
            {
                if (MainClass.con.State == ConnectionState.Open)
                {
                    MainClass.con.Close();
                }
            }
        }

        //validates category input
        private bool ValidateCategory()
        {
            string name = "";

            if (txtCategoryName.Text != null)
            {
                name = txtCategoryName.Text.Trim();
            }

            //Validation rules
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Category name is required.");
                txtCategoryName.Focus();
                return false;
            }
            else if (name.Length > 50)
            {
                MessageBox.Show("Category name cannot exceed 50 symbols.");
                txtCategoryName.Focus();
                return false;
            }
            else if (CategoryExists(name))
            {
                MessageBox.Show("Category with this name already exists.");
                txtCategoryName.Focus();
                return false;
            }

            return true;
        }

        //insert or update category
        public override void btnSave_Click(object sender, EventArgs e)
        {

            //Validate input before saving
            if (!ValidateCategory()) return;

            string qry = "";

            //parameters for SQL query
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtCategoryName.Text);

            //Insert new category
            if (id == 0)
            {
                qry = "INSERT INTO categories (categoryName) VALUES(@Name)";
            }
            else   //Update existing category
            {
                qry = "UPDATE categories SET categoryName = @Name WHERE ID = @id";
            }

            //Execute query and check result
            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                txtCategoryName.Focus();
                txtCategoryName.Text = "";

                //Close form after successful save
                this.Close();
            }
        }
    }
}
