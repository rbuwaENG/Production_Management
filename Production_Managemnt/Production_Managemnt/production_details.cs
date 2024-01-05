using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Production_Managemnt
{
    public partial class production_details : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        public production_details()
        {
            InitializeComponent();
            ShowProductions();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            details ddetails = new details();
            ddetails.Show();
        }

        public void ShowProductions()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM production";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Assuming dataGridViewProductions is the name of your DataGridView control
                        dataGridView1.DataSource = dataTable;

                        // Optionally, you can set the DataGridViewAutoSizeColumnsMode
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading productions: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO production (ProductionID, ProductionName, [Date], ClientID)
                VALUES (@ProductionID, @ProductionName, @Date, @ClientID);
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductionID", textBox3.Text);
                        command.Parameters.AddWithValue("@ProductionName", textBox1.Text);
                        DateTime selectedDate = dateTimePicker1.Value;
                        command.Parameters.AddWithValue("@Date", selectedDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@ClientID", numericUpDown1);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding production: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowProductions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM production WHERE ProductionID = @ProductionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductionID", textBox3.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting production: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                UPDATE Production
                SET ProductionName = @ProductionName, [Date] = @Date, ClientID = @ClientID
                WHERE ProductionID = @ProductionID;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductionID", textBox3.Text);
                        command.Parameters.AddWithValue("@ProductionName", textBox1.Text);
                        command.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                        command.Parameters.AddWithValue("@ClientID", numericUpDown1);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating production: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
