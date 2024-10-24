using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restuarant_Point_of_Sale
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
            guna2DataGridView1.Columns.Add("ProductName", "Product Name");
            guna2DataGridView1.Columns.Add("ProductPrice", "Price");

            // Optional: Adjust column properties (like setting format for the price column)
            guna2DataGridView1.Columns["ProductPrice"].DefaultCellStyle.Format = "C2";

        }
        public void AddPriceToGrid(string productName, decimal productPrice)
        {
            guna2DataGridView1.Rows.Add(productName, productPrice);
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           Drink d = new Drink();
            d.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Meals m = new Meals();
            m.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Pizza p = new Pizza();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            
        }
    }
}
