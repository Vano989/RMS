using Microsoft.AspNetCore.Identity;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    public partial class formLogin : Form
    {
        //Logged-in user role Manager / Waiter / Cook
        public static string uRole;
        //Logged-in user ID
        public static int uId;

        //Checks if username exists and verifies password hash
        public static bool isValidUser(string username, string pass)
        {
            bool isValid = false;

            //Select user data by username
            string qry = "SELECT ID, pass, uRole FROM users WHERE username = @user";

            using (SqlCommand cmd = new SqlCommand(qry, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@user", username.Trim());

                //Load result into DataTable
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                //If at least one row returned -> user exists
                if (dt.Rows.Count != 0)
                {
                    //Read stored hash and user role from DB
                    string storedHash = dt.Rows[0]["Pass"].ToString();
                    string role = dt.Rows[0]["uRole"].ToString();
                    int userId = Convert.ToInt32(dt.Rows[0]["ID"]);

                    //Verify entered password against stored hash (using ASP.NET Identity)
                    var hasher = new PasswordHasher<object>();
                    var passwordVerificationResult = hasher.VerifyHashedPassword(null, storedHash, pass);

                    //If password matches -> login success
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        isValid = true;
                        uRole = role;
                        uId = userId;
                    }
                }
            }
            return isValid;
        }

        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValidUser(txtUser.Text, txtPass.Text))
            {
                //Clear input fields after successful login
                txtUser.Text = "";
                txtPass.Text = "";

                //Hide login form and open main window
                this.Hide();
                formMain main = new formMain();
                main.Show();
                main.LoginForm = this;
            }
            else
            {
                //Show error message when login fails
                MessageBox.Show(
                    "Invalid username or password, please try again!", 
                    "Login Failed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
}
