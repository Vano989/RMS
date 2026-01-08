using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1.Forms
{
    public partial class formStaffAdd : addTemplate
    {
        public formStaffAdd()
        {
            InitializeComponent();
        }

        //User ID
        private int _id = 0;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Checks if username already exists
        private bool UsernameExists(string username)
        {
            try
            {
                string sql = @"
                SELECT COUNT(*) 
                FROM users 
                WHERE username = @username 
                    AND deleted_at IS NULL";

                using (SqlCommand cmd = new SqlCommand(sql, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    if (MainClass.con.State == ConnectionState.Closed)
                        MainClass.con.Open();

                    //returns a single value from the query COUNT(*)
                    int count = (int)cmd.ExecuteScalar();
                    //if count >= 1 -> username already exists
                    return count > 0;
                }
            }
            finally
            {
                if (MainClass.con.State == ConnectionState.Open)
                    MainClass.con.Close();
            }
        }

        //user input validation
        private bool ValidateUser()
        {
            //remove ' ' from start/end  
            txtFullName.Text = txtFullName.Text.Trim();
            txtUsername.Text = txtUsername.Text.Trim().ToLower();
            txtPass.Text = txtPass.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();

            //required fields
            if (id == 0) //ADD mode -> username and password are required
            {
                //Required fields for new user
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(cbRole.Text)
                || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return false;
                }

                //Username
                if (txtUsername.Text.Length < 3 || txtUsername.Text.Length > 32)
                {
                    MessageBox.Show("Username must be 3-32 characters long.");
                    return false;
                }
                //Username must be unique
                if (UsernameExists(txtUsername.Text))
                {
                    MessageBox.Show("This username is already taken.");
                    return false;
                }

                //Password
                if (txtPass.Text.Length < 6 || txtPass.Text.Length > 32)
                {
                    MessageBox.Show("Password must be 6–32 characters long.");
                    return false;
                }
            }
            else //EDIT mode -> username and password are not required
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(cbRole.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return false;
                }
            }

            //FullName
            if (txtFullName.Text.Length > 50)
            {
                MessageBox.Show("Full name must be less than 50 symbols.");
                return false;
            }

            //Phone (can be NULL, have to contain only numbers)
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                //only digits
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d+$"))
                {
                    MessageBox.Show("Phone number must contain digits only.");
                    return false;
                }

                //length check
                if (txtPhone.Text.Length > 15)
                {
                    MessageBox.Show("Phone number must be 15 digits or less.");
                    return false;
                }
            }
            return true;
        }

        //Save button (insert new user or update existing)
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUser())
            {
                string qry = "";

                //Parameters for SQL query
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                
                ht.Add("@Fullname", txtFullName.Text);
                ht.Add("@Role", cbRole.Text);
                ht.Add("@Phone", txtPhone.Text);

                //INSERT new user
                if (id == 0)
                {
                    //Store password hash (using ASP.NET Identity)
                    var hasher = new PasswordHasher<object>();
                    string hashedPassword = hasher.HashPassword(null, txtPass.Text);

                    ht.Add("@Username", txtUsername.Text);
                    ht.Add("@Password", hashedPassword);

                    qry = @"
                    INSERT INTO users (username, pass, fullName, uRole, phoneNumber, deleted_at)
                    VALUES (@Username, @Password, @FullName, @Role, @Phone, NULL)";
                }
                else //UPDATE existing user
                {
                    qry = "Update users set fullName = @FullName, uRole = @Role, phoneNumber = @Phone where ID = @id";
                }

                //execute query
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
