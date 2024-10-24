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
    public partial class sf : Form
    {
       
        public sf()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staff st = new staff();
            st.Show();
        }

        private void sf_Load(object sender, EventArgs e)
        {
            
        }
    }
}
