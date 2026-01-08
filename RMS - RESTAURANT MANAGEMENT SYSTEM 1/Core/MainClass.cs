using ComponentFactory.Krypton.Toolkit;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    internal class MainClass
    {
        //connection string to SQL server database
        public static readonly string con_string = "Data Source=IVANPC; Initial Catalog=RMS; Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);

        //Method for executing sql commands INSERT / UPDATE / DELETE
        public static int SQL(string qry, Hashtable ht)
        {

            int res = 0;

            try
            {
                //prepare SQL command
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                //add parameters from hashtable
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                //Open connection
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //execute command and get number of affected rows
                res = cmd.ExecuteNonQuery();

                //Close connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;
        }

        //load data from database into a DataGridView
        //lb defines which DataGridView columns bind to which DB columns
        public static void LoadData(string qry, DataGridView dgv, ListBox lb)
        {
            //Serial number in DataGridView first column
            dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvCellFormatting);
            try
            {
                //Prepare SELECT command
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                //Fill DataTable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Map dt.Columns[i] to DataGridView columns
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    dgv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();
                }

                //bind DataTable to DataGridView
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        //adds serial number in the first column of the grid
        private static void dgvCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgv = (ComponentFactory.Krypton.Toolkit.KryptonDataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        //Blur effect for background behind a window
        public static void BgBlured(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;

                //match main form size and position
                Background.Size = formMain.Instance.Size;
                Background.Location = formMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);

                //close and dispose background overlay
                Background.Dispose();
            }
        }

        //Fills ComboBox 
        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;

            //Fill DataTable
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //text shown to user
            cb.DisplayMember = "name";

            //internal value
            cb.ValueMember = "id";
            cb.DataSource = dt;

            //no item selected by default
            cb.SelectedIndex = -1;
        }
    }
}
