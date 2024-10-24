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
    public partial class Drink : Form
    {
      
        public Drink()
        {
            InitializeComponent();
            label2.Click += new EventHandler(label2_Click);
            label3.Click += new EventHandler(label3_Click);
            label7.Click += new EventHandler(label7_Click);
            label4.Click += new EventHandler(label4_Click);
            label6.Click += new EventHandler(label6_Click);
            label5.Click += new EventHandler(label5_Click);
            label8.Click += new EventHandler(label8_Click);
            label9.Click += new EventHandler(label9_Click);
            label10.Click += new EventHandler(label10_Click);
            label11.Click += new EventHandler(label11_Click);
            label12.Click += new EventHandler(label12_Click);
            label13.Click += new EventHandler(label13_Click);
            
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
        private void Drink_Load(object sender, EventArgs e)
        {
            label2.Click += new EventHandler(label2_Click);
            label3.Click += new EventHandler(label3_Click);
            label7.Click += new EventHandler(label7_Click);
            label4.Click += new EventHandler(label4_Click);
            label6.Click += new EventHandler(label6_Click);
            label5.Click += new EventHandler(label5_Click);
            label8.Click += new EventHandler(label8_Click);
            label9.Click += new EventHandler(label9_Click);
            label10.Click += new EventHandler(label10_Click);
            label11.Click += new EventHandler(label11_Click);
            label12.Click += new EventHandler(label12_Click);
            label13.Click += new EventHandler(label13_Click);
            
        }
        


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox12_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdatePOS("thumbs up", 30);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UpdatePOS("Coca Cola ", 60);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdatePOS("Pepsy ", 60);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            UpdatePOS("thumbs up can", 60);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            UpdatePOS("sprite", 40);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            UpdatePOS("MountainDew", 50);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdatePOS("Limka", 50);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdatePOS("Soft Drink", 90);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            UpdatePOS("Red Sting", 30);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            UpdatePOS("Blue Sting", 30);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            UpdatePOS("Red bull", 40);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            UpdatePOS("Red bull plus", 380);
        }
    }
}
