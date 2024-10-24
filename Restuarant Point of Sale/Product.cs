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
    public partial class Product : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        int IndexRow, SelectedRow;

        String S = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Restuarant Point of Sale\Restuarant Point of Sale\RM.mdf ;Integrated Security=True";
        
        public Product()
        {
            InitializeComponent();
        }
        void Connection()
        {
            con = new SqlConnection(S);
            con.Open();
        }
        void fillg()
        {
            using (SqlConnection con = new SqlConnection(S)) // Use 'using' to ensure the connection is closed
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from TableFirst", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           

        }

        private void Product_Load(object sender, EventArgs e)
        {
            Connection();
            fillg();
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {

        }
        private void displayProduct()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Product";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                dataGridView2.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);

                using (SqlConnection con = new SqlConnection(S)) // Use 'using' to ensure connection is closed
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE id=@id", con);
                        cmd.Parameters.AddWithValue("@id", selectedid);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully");
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. No record found with the provided ID.");
                        }

                        fillg(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(S)) // Use 'using' to ensure connection is closed
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Product (PName, PPrice, PCategory) VALUES (@PName, @PPrice, @PCategory)", con);
                    cmd.Parameters.AddWithValue("@PName", pn.Text);
                    cmd.Parameters.AddWithValue("@PPrice", pp.Text);
                    cmd.Parameters.AddWithValue("@PCategory", pc.Text);
                    cmd.ExecuteNonQuery();

                    pn.Text = "";
                    pp.Text = "";
                    pc.Text = "";

                    MessageBox.Show("Record inserted successfully");

                    fillg(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                int selectedid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);


                if (string.IsNullOrEmpty(pn.Text) || string.IsNullOrEmpty(pp.Text) || string.IsNullOrEmpty(pc.Text))
                {
                    MessageBox.Show("Please fill all the fields before updating.");
                    return;
                }


                using (SqlConnection con = new SqlConnection(S))
                {
                    try
                    {
                        con.Open();


                        string query = "UPDATE Product SET PName=@PName, PPrice=@PPrice, PCategory=@PCategory WHERE id=@id";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@PName", pn.Text);
                        cmd.Parameters.AddWithValue("@PPrice", pp.Text);
                        cmd.Parameters.AddWithValue("@PCategory",pc.Text);
                        cmd.Parameters.AddWithValue("@id", selectedid);


                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No records updated. Please check the ID and try again.");
                        }
                        fillg();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while updating: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }
    }
}
