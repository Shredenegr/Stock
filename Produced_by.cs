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
    public partial class Produced_by : Form
    {
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb;";
        private OleDbConnection myConnection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        DataSet dataSet;
        public Produced_by()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            dataSet = new DataSet();
            myConnection.Open();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Hide();
            button3.Hide();
            label1.Show();
            label2.Show();
            label3.Hide();
            label4.Show();
            label5.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Hide();
            textBox4.Show();
            textBox5.Show();

            dataSet.Tables["Produced_by"].Clear();
            string sql = "SELECT №, Title, Type, Date_by, [Quantity/kg], Farm№ FROM Produced_by";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
            dataGridView1.DataSource = dataSet.Tables["Produced_by"].DefaultView;         
        }

        private void Produced_by_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            label3.Hide();
            textBox3.Hide();
            string sql = "SELECT №, Title, Type, Date_by, [Quantity/kg], Farm№ FROM Produced_by";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
            dataGridView1.DataSource = dataSet.Tables["Produced_by"].DefaultView;
        }

        private void Produced_by_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sql_1 = "UPDATE In_stock INNER JOIN Produced_by ON In_stock.Title = Produced_by.Title" +
                " SET In_stock.[Quantity/kg] = [In_stock].[Quantity/kg]+[Produced_by].[Quantity/kg], Produced_by.In_stock = True " +
                " WHERE(((Produced_by.In_stock) = False))";
            command = new OleDbCommand(sql_1, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            string sql_2 = "INSERT INTO In_stock ( Title, Type, [Quantity/kg] )" + 
                    " SELECT Produced_by.Title, Produced_by.Type, Produced_by.[Quantity/kg] " +
                    " FROM Produced_by WHERE(((Produced_by.In_stock) = False))";
            command = new OleDbCommand(sql_2, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            string sql_3 = "UPDATE In_stock INNER JOIN Produced_by ON In_stock.Title = Produced_by.Title" + 
                " SET Produced_by.In_stock = True";
            command = new OleDbCommand(sql_3, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            myConnection.Close();
            Main main = new Main();
            main.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Hide();
            button3.Hide();
            label1.Show();
            label2.Show();
            label3.Hide();
            label4.Show();
            label5.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Hide();
            textBox4.Show();
            textBox5.Show();

            dataSet.Tables["Produced_by"].Clear();
            string sql = "SELECT №, Title, Type, Date_by, [Quantity/kg], Farm№ FROM Produced_by";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
            dataGridView1.DataSource = dataSet.Tables["Produced_by"].DefaultView;
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

            dataSet.Tables["Produced_by"].Clear();
            string sql = "SELECT №, Title, Type, Date_by, [Quantity/kg], Farm№ FROM Produced_by WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
            dataGridView1.DataSource = dataSet.Tables["Produced_by"].DefaultView;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Show();
            label1.Hide();
            label2.Hide();
            label3.Show();
            label4.Hide();
            label5.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Show();
            textBox4.Hide();
            textBox5.Hide();

            dataSet.Tables["Produced_by"].Clear();
            string sql = "SELECT №, Title, Type, Date_by, [Quantity/kg], Farm№ FROM Produced_by WHERE In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
            dataGridView1.DataSource = dataSet.Tables["Produced_by"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO [Produced_by] ( Title, Type, [Date_by], [Quantity/kg], Farm№)" + 
                "VALUES('"+textBox1.Text+"', 'Культура', '"+textBox2.Text+"', "+Convert.ToInt32(textBox4.Text)+", "+Convert.ToInt32(textBox5.Text)+ ") ";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Produced_by] SET" +
                " Produced_by.Title = '"+ textBox1.Text +"', "+
                " Produced_by.Date_by = '"+ textBox2.Text +"', "+
                " Produced_by.[Quantity/kg] = "+ textBox4.Text +", "+
                " Produced_by.Farm№ = "+ textBox5.Text +" "+
                " WHERE(((Produced_by.[№]) = "+ textBox3.Text +"))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Produced_by].* FROM Produced_by WHERE(((Produced_by.[№]) = " + textBox3.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Produced_by");
        }
    }
}
