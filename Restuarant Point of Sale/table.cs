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
    public partial class Table : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String S = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Restuarant Point of Sale\Restuarant Point of Sale\RM.mdf ;Integrated Security=True";
        int IndexRow, SelectedRow;

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
        public Table()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(S)) // Use 'using' to ensure connection is closed
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO TableFirst (TName, TType, TTime) VALUES (@TName, @TType, @TTime)", con);
                    cmd.Parameters.AddWithValue("@TName", tn.Text);
                    cmd.Parameters.AddWithValue("@TType", tt.Text);
                    cmd.Parameters.AddWithValue("@TTime", ttime.Text);
                    cmd.ExecuteNonQuery();

                    tn.Text = "";
                    tt.Text = "";
                    ttime.Text = "";

                    MessageBox.Show("Record inserted successfully");

                    fillg(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void table_Load(object sender, EventArgs e)
        {
            Connection();
            fillg();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
               
                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                
                if (string.IsNullOrEmpty(tn.Text) || string.IsNullOrEmpty(tt.Text) || string.IsNullOrEmpty(ttime.Text))
                {
                    MessageBox.Show("Please fill all the fields before updating.");
                    return;
                }

               
                using (SqlConnection con = new SqlConnection(S))
                {
                    try
                    {
                        con.Open(); 

                       
                        string query = "UPDATE TableFirst SET TName=@TName, TType=@TType, TTime=@TTime WHERE ID=@ID";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@TName", tn.Text); 
                        cmd.Parameters.AddWithValue("@TType", tt.Text); 
                        cmd.Parameters.AddWithValue("@TTime", ttime.Text); 
                        cmd.Parameters.AddWithValue("@ID", selectedID); 

                       
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
        private void displayTableFirst()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM TableFirst";
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


        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection con = new SqlConnection(S)) // Use 'using' to ensure connection is closed
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM TableFirst WHERE ID=@ID", con);
                        cmd.Parameters.AddWithValue("@ID", selectedID);
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
