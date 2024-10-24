using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Restuarant_Point_of_Sale
{
    public partial class Category : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String S = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Restuarant Point of Sale\Restuarant Point of Sale\RM.mdf ;Integrated Security=True";
        

        void Connection()
        {
            con = new SqlConnection(S);
            con.Open();
        }
        void fillg()
        {
            Connection();
            da = new SqlDataAdapter("select * from Category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            Connection();
            fillg();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                Connection();
                if (!string.IsNullOrEmpty(cn.Text))
                {
                    cmd = new SqlCommand("insert into Category (CName) values (@CName)", con);
                    cmd.Parameters.AddWithValue("@CName", cn.Text);
                    cmd.ExecuteNonQuery();

                    cn.Text = "";
                    MessageBox.Show("Record inserted successfully");

                    fillg();  // Refresh the grid
                }
                else
                {
                    MessageBox.Show("Please enter a category name");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection();
            if (!string.IsNullOrEmpty(cn.Text) && dataGridView2.SelectedRows.Count > 0)
            {
                // Get the selected name from the DataGridView
                string selectedName = dataGridView2.SelectedRows[0].Cells["CName"].Value.ToString();

                // Update the selected name to the new name
                cmd = new SqlCommand("update Category set CName = @NewCName where CName = @SelectedCName", con);
                cmd.Parameters.AddWithValue("@NewCName", cn.Text);  // New category name
                cmd.Parameters.AddWithValue("@SelectedCName", selectedName);  // Selected category name from grid
                cmd.ExecuteNonQuery();

                cn.Text = "";
                MessageBox.Show("Record updated successfully");

                fillg();  // Refresh the grid after updating
            }
            else
            {
                MessageBox.Show("Please select a category and enter the new name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection();
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the selected name from the DataGridView
                string selectedName = dataGridView2.SelectedRows[0].Cells["CName"].Value.ToString();

                cmd = new SqlCommand("delete from Category where CName = @CName", con);
                cmd.Parameters.AddWithValue("@CName", selectedName);
                cmd.ExecuteNonQuery();

                cn.Text = "";
                MessageBox.Show("Record deleted successfully");

                fillg();  // Refresh the grid after deletion
            }
            else
            {
                MessageBox.Show("Please select a category to delete");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                cn.Text = row.Cells["CName"].Value.ToString();  // Fill the selected category name in the textbox for editing
            }
        }
    }
}
