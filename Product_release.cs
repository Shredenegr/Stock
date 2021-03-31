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
    public partial class Product_release : Form
    {
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb;";
        private OleDbConnection myConnection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        DataSet dataSet;
        public Product_release()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            dataSet = new DataSet();
            myConnection.Open();
        }

        private void Product_release_Load(object sender, EventArgs e)
        {
            button1.Show();
            button2.Hide();
            button3.Hide();
            label1.Hide();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox1.Hide();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();

            string sql = "SELECT Title, [Date_sold], [Quantity/kg], [Price/kg], Amount FROM Product_sold";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
            dataGridView1.DataSource = dataSet.Tables["Product_sold"].DefaultView;

            string sql_1 = "SELECT Title, [Quantity/kg] FROM In_stock WHERE Type LIKE '%Культура%'";
            command = new OleDbCommand(sql_1, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");
            dataGridView2.DataSource = dataSet.Tables["In_stock"].DefaultView;
        }

        private void Product_release_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sql = "UPDATE In_stock INNER JOIN Expenses ON In_stock.Title = Expenses.Title" +
                " SET In_stock.[Quantity/kg] = [In_stock].[Quantity/kg]-[Expenses].[Quantity/kg], Expenses.In_stock = True WHERE(((Expenses.In_stock) = False))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            myConnection.Close();
            Main main = new Main();
            main.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Hide();
            button3.Hide();
            label1.Hide();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox1.Hide();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();

            dataSet.Tables["Expenses"].Clear();
            string sql = "SELECT Title, [Date_sold], [Quantity/kg], [Price/kg], Amount FROM Product_sold";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
            dataGridView1.DataSource = dataSet.Tables["Product_sold"].DefaultView;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Hide();
            button3.Hide();
            label1.Hide();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox1.Hide();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();

            dataSet.Tables["Expenses"].Clear();
            string sql = "SELECT Title, [Date_sold], [Quantity/kg], [Price/kg], Amount FROM Product_sold";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
            dataGridView1.DataSource = dataSet.Tables["Product_sold"].DefaultView;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Show();
            button3.Hide();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();

            dataSet.Tables["Expenses"].Clear();
            string sql = "SELECT №, Title, [Date_sold], [Quantity/kg], [Price/kg], Amount FROM Product_sold WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
            dataGridView1.DataSource = dataSet.Tables["Product_sold"].DefaultView;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Show();
            label1.Show();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            textBox1.Show();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();

            dataSet.Tables["Expenses"].Clear();
            string sql = "SELECT №, Title, [Date_sold], [Quantity/kg], [Price/kg], Amount FROM Product_sold WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
            dataGridView1.DataSource = dataSet.Tables["Product_sold"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Product_sold ( Title, [Date_sold], [Quantity/kg], [Price/kg], Amount)" +
                "VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', " + Convert.ToInt32(textBox4.Text) + ", " + Convert.ToInt32(textBox5.Text) + ", " + Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text) + ") ";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Product_sold] SET" +
                " Product_sold.Title = '" + textBox2.Text + "', " +
                " Product_sold.[Date_sold] = '" + textBox3.Text + "', " +
                " Product_sold.[Quantity/kg] = " + Convert.ToInt32(textBox4.Text) + ", " +
                " Product_sold.[Price/kg] = " + Convert.ToInt32(textBox5.Text) + ", " +
                " Product_sold.Amount = " + Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text) + " " +
                " WHERE(((Product_sold.[№]) = " + textBox1.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Product_sold].* FROM Product_sold WHERE(((Product_sold.[№]) = " + textBox3.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Product_sold");
        }
    }
}
