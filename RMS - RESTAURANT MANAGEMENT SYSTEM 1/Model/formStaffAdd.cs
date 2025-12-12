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

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Model
{
    public partial class formStaffAdd : addTemplate
    {
        public formStaffAdd()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private bool UsernameExists(string username)
        {

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", MainClass.con))
            {
                cmd.Parameters.AddWithValue("@username", username);

                if (MainClass.con.State == ConnectionState.Closed)
                {
                    MainClass.con.Open();
                }

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private bool ValidateUser()
        {
            //remove ' ' from first and last symbol  
            txtFullName.Text = txtFullName.Text.Trim();
            txtUsername.Text = txtUsername.Text.Trim().ToLower();
            txtPass.Text = txtPass.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();

            //required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(cbRole.Text) 
                || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            // Username
            if (txtUsername.Text.Length < 3 || txtUsername.Text.Length > 32)
            {
                MessageBox.Show("Username must be 3-32 characters long.");
                return false;
            }

            if (UsernameExists(txtUsername.Text))
            {
                MessageBox.Show("This username is already taken.");
                return false;
            }

            // FullName
            if (txtFullName.Text.Length > 50)
            {
                MessageBox.Show("Full name must be 50 characters or less.");
                return false;
            }

            // Password
            if (txtPass.Text.Length < 6 || txtPass.Text.Length > 32)
            {
                MessageBox.Show("Password must be 6–32 characters long.");
                return false;
            }

            // Phone (can be NULL, but if !NULL then have to contain only '+' and numbers)
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\+?\d+$")
                && txtPhone.Text.Length > 15)
                {
                    MessageBox.Show("Phone must contain only digits and + at start.");
                    return false;
                }
            }

            return true;
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUser())
            {
                string qry = "";

                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@Username", txtUsername.Text);
                ht.Add("@Password", txtPass.Text);
                ht.Add("@Fullname", txtFullName.Text);
                ht.Add("@Role", cbRole.Text);
                ht.Add("@Phone", txtPhone.Text);

                if (id == 0)
                {
                    qry = "Insert into users values(@Username, @Password, @FullName, @Role, @Phone)";
                }
                else
                {
                    qry = "Update users set fullName = @FullName, uRole = @Role, phoneNumber = @Phone where ID = @id";
                }

                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Saved successfully");
                    id = 0;
                    txtFullName.Text = "";
                    txtUsername.Text = "";
                    txtPass.Text = "";
                    txtPhone.Text = "";
                }

                this.Close();
            }
        }

    }
}
