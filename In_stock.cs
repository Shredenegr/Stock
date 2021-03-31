using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class In_stock : Form
    {
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb;";
        private OleDbConnection myConnection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        DataSet dataSet;
        public In_stock()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            dataSet = new DataSet();
            myConnection.Open();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Title, Type, [Quantity/kg] FROM In_stock WHERE Title NOT LIKE '%Тестовое%'";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");
            dataGridView1.DataSource = dataSet.Tables["In_stock"].DefaultView;
        }

        private void In_stock_Load(object sender, EventArgs e)
        {

        }

        private void In_stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
            Main main = new Main();
            main.Show();
        }
    }
}
