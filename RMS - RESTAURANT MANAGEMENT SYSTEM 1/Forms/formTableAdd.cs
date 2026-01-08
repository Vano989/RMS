using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formTableAdd : addTemplate
    {
        public formTableAdd()
        {
            InitializeComponent();
        }

        //Table ID
        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Checks if table with the same name already exists
        private bool TableExists(string tableName)
        {
            try
            {
                string sql = @"
                SELECT COUNT(*)
                FROM custom_tables
                WHERE tableName = @tableName
                    AND deleted_at IS NULL";

                using (SqlCommand cmd = new SqlCommand(sql, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@tableName", tableName);

                    if (MainClass.con.State == ConnectionState.Closed)
                        MainClass.con.Open();

                    //returns a single value from the query COUNT(*)
                    int count = (int)cmd.ExecuteScalar();

                    //if count >= 1 -> table already exists
                    return count > 0;
                }
            }
            finally
            {
                if (MainClass.con.State == ConnectionState.Open)
                    MainClass.con.Close();
            }
        }

        //Validates table input
        private bool ValidateTable()
        {
            string name = "";

            //Read and trim table name
            if (txtTableName.Text != null)
            {
                name = txtTableName.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Table name is required.");
                txtTableName.Focus();
                return false;
            }
            else if (name.Length > 50)
            {
                MessageBox.Show("Table name cannot exceed 50 symbols.");
                txtTableName.Focus();
                return false;
            }
            else if (TableExists(name)) //Table name must be unique
            {
                MessageBox.Show("Table with this name already exists.");
                txtTableName.Focus();
                return false;
            }

            return true;
        }

        //Save button (insert new table or update existing)
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateTable())
                return;

            string qry = "";

            //parameters for SQL query
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtTableName.Text);

            //Insert new table
            if (id == 0)
            {
                qry = "INSERT INTO custom_tables (tableName) values(@Name)";
            }
            else //Update existing table
            {
                qry = "UPDATE custom_tables SET tableName = @Name where ID = @id";
            }

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                txtTableName.Focus();
                txtTableName.Text = "";
                this.Close();
            }
        }
    }
}
