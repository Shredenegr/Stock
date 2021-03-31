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
    public partial class Expenses : Form
    {
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb;";
        private OleDbConnection myConnection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        DataSet dataSet;
        public Expenses()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            dataSet = new DataSet();
            myConnection.Open();
        }

        private void Expenses_Load(object sender, EventArgs e)
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

            string sql = "SELECT Title, Task, [Date_expenses], [Quantity/kg] FROM Expenses";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
            dataGridView1.DataSource = dataSet.Tables["Expenses"].DefaultView;

            string sql_1 = "SELECT Title, [Quantity/kg] FROM In_stock WHERE Type NOT LIKE '%Культура%'";
            command = new OleDbCommand(sql_1, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");
            dataGridView2.DataSource = dataSet.Tables["In_stock"].DefaultView;
        }

        private void Expenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sql = "UPDATE In_stock INNER JOIN Expenses ON In_stock.Title = Expenses.Title SET In_stock.[Quantity/kg] = [In_stock].[Quantity/kg]-[Expenses].[Quantity/kg], Expenses.In_stock = True WHERE(((Expenses.In_stock) = False))";
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
            string sql = "SELECT Title, Task, [Date_expenses], [Quantity/kg] FROM Expenses";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
            dataGridView1.DataSource = dataSet.Tables["Expenses"].DefaultView;
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
            string sql = "SELECT Title, Task, [Date_expenses], [Quantity/kg] FROM Expenses";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
            dataGridView1.DataSource = dataSet.Tables["Expenses"].DefaultView;
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
            string sql = "SELECT №, Title, Task, [Date_expenses], [Quantity/kg] FROM Expenses WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
            dataGridView1.DataSource = dataSet.Tables["Expenses"].DefaultView;
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
            string sql = "SELECT №, Title, Task, [Date_expenses], [Quantity/kg] FROM Expenses WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
            dataGridView1.DataSource = dataSet.Tables["Expenses"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Expenses (Title, Task, Date_expenses, [Quantity/kg]) " + 
                "VALUES('"+ textBox2.Text +"', '"+ textBox3.Text +"', '"+ textBox4.Text +"', "+Convert.ToInt32(textBox5.Text)+")";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Expenses] SET" +
                " Expenses.Title = '" + textBox2.Text + "', " +
                " Expenses.Task = '" + textBox3.Text + "', " +
                " Expenses.[Date_expenses] = '" + textBox4.Text + "', " +
                " Expenses.[Quantity/kg] = " + Convert.ToInt32(textBox5.Text) + " " +
                " WHERE(((Expenses.[№]) = " + textBox1.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Expenses].* FROM Expenses WHERE(((Expenses.[№]) = " + textBox1.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Expenses");
        }
    }
}
