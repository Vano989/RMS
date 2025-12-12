using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS___RESTAURANT_MANAGEMENT_SYSTEM_1
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source=IVANPC; Initial Catalog=RMS; Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);

        //Method for executing sql commands
        public static int SQL(string qry, Hashtable ht)
        {

            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                res = cmd.ExecuteNonQuery();

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

        //For loading data from DB to DGV
        public static void LoadData(string qry, DataGridView dgv, ListBox lb)
        {
            //Serial number in GridView
            dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvCellFormatting);
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    dgv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();
                }

                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

        }

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

        //Blur effect for background
        public static void BgBlured(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = formMain.Instance.Size;
                Background.Location = formMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }


        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }
    }
}
