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

namespace Restuarant_Point_of_Sale
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String S= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Restuarant Point of Sale\Restuarant Point of Sale\RM.mdf;Integrated Security=True";
      
        public Form1()
        {
            InitializeComponent();
            
        }
        void Connection()
        {
            con = new SqlConnection(S);
            con.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /* Connection();
             cmd = new SqlCommand("insert into Users(username,uPass)values('" + txtUser + "','" + txtPass + "')",con);
             cmd.ExecuteNonQuery();

             MessageBox.Show("User successfully added.");
             MainForm newForm = new MainForm();
             newForm.Show();
             this.Hide();*/
            string username = txtUser.Text;
            string password = txtPass.Text;
            if (ValidateCredentials(username, password))
            {
                MessageBox.Show("Login successful!");
                MainForm newForm = new MainForm();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("check your username or password!");
            }
            

        }
        private bool ValidateCredentials(string username, string password)
        {
            
            return username == "krisha" && password == "krisha@007"; // Example hardcoded check
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
