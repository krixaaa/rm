using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restuarant_Point_of_Sale
{
    public partial class staff : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String S = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Restuarant Point of Sale\Restuarant Point of Sale\RM.mdf ;Integrated Security=True";
        


        public staff()
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
            Connection();
            da = new SqlDataAdapter("select * from Staff", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Connection();
            if (!string.IsNullOrEmpty(sn.Text) && !string.IsNullOrEmpty(sp.Text) && !string.IsNullOrEmpty(sr.Text))
            {
                cmd = new SqlCommand("insert into Staff (SName, SPhone, SRole) values (@SName, @SPhone, @SRole)", con);
                cmd.Parameters.AddWithValue("@SName", sn.Text);
                cmd.Parameters.AddWithValue("@SPhone", sp.Text);
                cmd.Parameters.AddWithValue("@SRole", sr.Text);

                cmd.ExecuteNonQuery();

                sn.Text = "";
                sp.Text = "";
                sr.Text = "";

                MessageBox.Show("Record inserted successfully");

                fillg();  // Refresh the grid after inserting
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }

        }

        private void staff_Load(object sender, EventArgs e)
        {
            Connection();
            fillg();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection();

            cmd = new SqlCommand("update Staff set SName = '" + sn.Text + "',SPhone='"+sp.Text+"',SRole = '"+sr.Text+"' Where Id = '"+key+"' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record updated successfully");
            fillg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection();

            if (key == 0)
            {
                MessageBox.Show("Select Data");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("delete from Staff where Id = '" + key + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Details Deleted");
                    fillg();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            
    }

        int key = 0;
        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            sn.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            sp.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            sr.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            if(sn.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
