using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deliveries deliveries = new Deliveries();
            deliveries.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            In_stock in_Stock = new In_stock();
            in_Stock.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Produced_by produced_By = new Produced_by();
            produced_By.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product_release product_release = new Product_release();
            product_release.Show();
            this.Hide();
        }
    }
}
