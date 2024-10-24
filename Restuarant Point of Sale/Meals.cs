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
    public partial class Meals : Form
    {
        public Meals()
        {
            InitializeComponent();
            label2.Click += new EventHandler(label2_Click);
            label3.Click += new EventHandler(label3_Click);
            label7.Click += new EventHandler(label7_Click);
            label4.Click += new EventHandler(label4_Click);
            label6.Click += new EventHandler(label6_Click);
            label5.Click += new EventHandler(label7_Click);

        }
        private void UpdatePOS(string productName, decimal productPrice)
        {
            // Find the open POS form
            POS posForm = (POS)Application.OpenForms["POS"];

            if (posForm != null)
            {
                // Add the product and price to the POS grid
                posForm.AddPriceToGrid(productName, productPrice);
            }
            else
            {
                MessageBox.Show("POS form is not open.");
            }
        }
        private void Meals_Load(object sender, EventArgs e)
        {
            label2.Click += new EventHandler(label2_Click);
            label3.Click += new EventHandler(label3_Click);
            label7.Click += new EventHandler(label7_Click);
            label4.Click += new EventHandler(label4_Click);
            label6.Click += new EventHandler(label6_Click);
            label5.Click += new EventHandler(label5_Click);
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 300);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 300);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 500);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 200);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 300);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            UpdatePOS("Meal 1", 400);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
