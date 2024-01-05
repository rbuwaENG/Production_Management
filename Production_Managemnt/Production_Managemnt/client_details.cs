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
    public partial class client_details : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        public client_details()
        {
            InitializeComponent();
            ShowClients();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            details ddetails = new details();
            ddetails.Show();
        }

        private void ShowClients()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Client";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                UPDATE Client
                SET ClientName = @ClientName, 
                    ContactInfo = @ContactInfo, 
                    LocationID = @LocationID,
                    username = @username,
                    password = @password
                WHERE ClientID = @ClientID;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", textBox3.Text);
                        command.Parameters.AddWithValue("@ClientName", textBox1.Text);
                        command.Parameters.AddWithValue("@ContactInfo", textBox2.Text);
                        command.Parameters.AddWithValue("@LocationID", textBox4.Text);
                        command.Parameters.AddWithValue("@username", textBox6.Text);
                        command.Parameters.AddWithValue("@password", textBox5.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating client: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Client WHERE ClientID = @ClientID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", textBox3.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting client: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO Client (ClientName, ContactInfo, ClientID,username,password,LocationID)
                VALUES (@ClientName, @ContactInfo, @ClientID,@username,@password,@LocationID);
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientName", textBox1.Text);
                        command.Parameters.AddWithValue("@ContactInfo", textBox2.Text);
                        command.Parameters.AddWithValue("@ClientID", textBox3.Text);
                        command.Parameters.AddWithValue("@username", textBox6.Text);
                        command.Parameters.AddWithValue("@password", textBox5.Text);
                        command.Parameters.AddWithValue("@LocationID", textBox4.Text);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding client: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowClients();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
