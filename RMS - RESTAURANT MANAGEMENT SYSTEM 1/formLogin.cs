using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    public partial class formLogin : Form
    {
        public static string uRole;

        //Method checks if a user with the specified username and password exists in the database
        public static bool isValidUser(string username, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from users where username = '" + username + "' and pass = '" + pass + "' ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                uRole = dt.Rows[0]["uRole"].ToString();
            }

            return isValid;
        }

        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValidUser(txtUser.Text, txtPass.Text) == false)
            {
                MessageBox.Show("Invalid username or password, please try again!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Hide();
                formMain frm = new formMain();
                frm.Show();
            }
        }
    }
}
