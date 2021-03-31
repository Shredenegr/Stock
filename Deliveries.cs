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
    public partial class Deliveries : Form
    {
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Stock.accdb;";
        private OleDbConnection myConnection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        DataSet dataSet;
        public Deliveries()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            dataSet = new DataSet();
            myConnection.Open();
        }

        private void Deliveries_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button7.Hide();
            button8.Hide();
            label3.Hide();
            textBox3.Hide();
            textBox6.Hide();
            label6.Hide();
            label11.Hide();
            textBox11.Hide();
            string sql = "SELECT Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount FROM Deliveries";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void Deliveries_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sql_1 = "UPDATE In_stock INNER JOIN Deliveries ON In_stock.Title = Deliveries.Title" + 
                " SET In_stock.[Quantity/kg] = [In_stock].[Quantity/kg]+[Deliveries].[Quantity/kg], Deliveries.In_stock = True" + 
                " WHERE(((Deliveries.In_stock) = False))";
            command = new OleDbCommand(sql_1, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            string sql_2 = "INSERT INTO In_stock ( Title, Type, [Quantity/kg] ) " + 
                        "SELECT Deliveries.Title, Deliveries.Type, Deliveries.[Quantity/kg]" +
                        "FROM Deliveries WHERE((Deliveries.In_stock) = False)";
            command = new OleDbCommand(sql_2, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            string sql_3 = "UPDATE In_stock INNER JOIN Deliveries ON In_stock.Title = Deliveries.Title" + 
                " SET Deliveries.In_stock = True";
            command = new OleDbCommand(sql_3, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "In_stock");

            myConnection.Close();
            Main main = new Main();
            main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Семена");
            DGV_1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button5.Hide();
            button6.Show();
            label6.Hide();
            label7.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            textBox6.Hide();
            textBox7.Show();
            textBox8.Show();
            textBox9.Show();
            textBox10.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Удобрения");
            DGV_2.DataSource = dataSet.Tables["Deliveries"].DefaultView;
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Show();
            label11.Hide();
            label12.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            textBox11.Hide();
            textBox12.Show();
            textBox13.Show();
            textBox14.Show();
            textBox15.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Химикаты");
            DGV_3.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void LoadData(string nameOfType )
        {
            
            string sql = "SELECT Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount FROM Deliveries WHERE Type LIKE '%" + nameOfType+"%'";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
            

        }

        private void LoadDataCgange(string nameOfType)
        {
            string sql = "SELECT №, Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount FROM Deliveries WHERE Type = '"+ nameOfType +"' AND In_stock = false";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
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

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Семена");
            DGV_1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Deliveries ( Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount)" +
                "VALUES('" + textBox1.Text + "', 'Семена', '" + textBox2.Text + "', " + Convert.ToInt32(textBox4.Text) + ", " + Convert.ToInt32(textBox5.Text) + ", "+ Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text) + ") ";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Семена");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            dataSet.Tables["Deliveries"].Clear();
            string sql = "SELECT Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount FROM Deliveries";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Deliveries] SET" +
                " Deliveries.Title = '" + textBox1.Text + "', " +
                " Deliveries.[Date_entered] = '" + textBox2.Text + "', " +
                " Deliveries.[Quantity/kg] = " + Convert.ToInt32(textBox4.Text) + ", " +
                " Deliveries.[Price/kg] = " + Convert.ToInt32(textBox5.Text) + ", " +
                " Deliveries.Amount = " + Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text) + " " +
                " WHERE(((Deliveries.[№]) = " + textBox3.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
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

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Семена");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Deliveries].* FROM Deliveries WHERE(((Deliveries.[№]) = " + textBox3.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e) 
        {
            // Изменить - Удобрения
            button4.Hide();
            button5.Show();
            button6.Hide();
            label6.Show();
            label7.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            textBox6.Show();
            textBox7.Show();
            textBox8.Show();
            textBox9.Show();
            textBox10.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Удобрения");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button5.Hide();
            button6.Show();
            label6.Hide();
            label7.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            textBox6.Hide();
            textBox7.Show();
            textBox8.Show();
            textBox9.Show();
            textBox10.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Удобрения");
            DGV_2.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            // Удалить - Удобрения
            button4.Show();
            button5.Hide();
            button6.Hide();
            label6.Show();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            textBox6.Show();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Удобрения");
            dataGridView1.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Deliveries ( Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount)" +
                "VALUES('" + textBox7.Text + "', 'Удобрения', '" + textBox8.Text + "', " + Convert.ToInt32(textBox9.Text) + ", " + Convert.ToInt32(textBox10.Text) + ", " + Convert.ToInt32(textBox9.Text) * Convert.ToInt32(textBox10.Text) + ") ";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Deliveries] SET" +
                " Deliveries.Title = '" + textBox7.Text + "', " +
                " Deliveries.[Date_entered] = '" + textBox8.Text + "', " +
                " Deliveries.[Quantity/kg] = " + Convert.ToInt32(textBox9.Text) + ", " +
                " Deliveries.[Price/kg] = " + Convert.ToInt32(textBox10.Text) + ", " +
                " Deliveries.Amount = " + Convert.ToInt32(textBox9.Text) * Convert.ToInt32(textBox10.Text) + " " +
                " WHERE(((Deliveries.[№]) = " + textBox6.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Deliveries].* FROM Deliveries WHERE(((Deliveries.[№]) = " + textBox6.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Show();
            label11.Hide();
            label12.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            textBox11.Hide();
            textBox12.Show();
            textBox13.Show();
            textBox14.Show();
            textBox15.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadData("Химикаты");
            DGV_3.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Show();
            button9.Hide();
            label11.Show();
            label12.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            textBox11.Show();
            textBox12.Show();
            textBox13.Show();
            textBox14.Show();
            textBox15.Show();

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Химикаты");
            DGV_3.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            button7.Show();
            button8.Hide();
            button9.Hide();
            label11.Show();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            textBox11.Show();
            textBox12.Hide();
            textBox13.Hide();
            textBox14.Hide();
            textBox15.Hide();

            dataSet.Tables["Deliveries"].Clear();
            LoadDataCgange("Химикаты");
            DGV_3.DataSource = dataSet.Tables["Deliveries"].DefaultView;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Deliveries ( Title, Type, [Date_entered], [Quantity/kg], [Price/kg], Amount)" +
                "VALUES('" + textBox12.Text + "', 'Химикаты', '" + textBox13.Text + "', " + Convert.ToInt32(textBox14.Text) + ", " + Convert.ToInt32(textBox15.Text) + ", " + Convert.ToInt32(textBox14.Text) * Convert.ToInt32(textBox15.Text) + ") ";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [Deliveries] SET" +
                " Deliveries.Title = '" + textBox12.Text + "', " +
                " Deliveries.[Date_entered] = '" + textBox13.Text + "', " +
                " Deliveries.[Quantity/kg] = " + Convert.ToInt32(textBox14.Text) + ", " +
                " Deliveries.[Price/kg] = " + Convert.ToInt32(textBox15.Text) + ", " +
                " Deliveries.Amount = " + Convert.ToInt32(textBox14.Text) * Convert.ToInt32(textBox15.Text) + " " +
                " WHERE(((Deliveries.[№]) = " + textBox11.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "DELETE [Deliveries].* FROM Deliveries WHERE(((Deliveries.[№]) = " + textBox11.Text + "))";
            command = new OleDbCommand(sql, myConnection);
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataSet, "Deliveries");
        }
    }
}
