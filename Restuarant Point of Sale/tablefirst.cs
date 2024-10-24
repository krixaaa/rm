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
    public partial class tablefirst : Form
    {
        public tablefirst()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table t = new Table();
            t.Show();
        }

        private void tablefirst_Load(object sender, EventArgs e)
        {

        }
    }
}
