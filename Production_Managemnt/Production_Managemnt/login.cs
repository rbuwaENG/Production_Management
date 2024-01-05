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
    public partial class login : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        int index;
        
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(username.Text, password.Text, "admin"))
            {
                MessageBox.Show("Admin login successful!");
                // Hide the current login form
                this.Hide();

                // Show the new form (replace MainForm with the actual form you want to show)
                details dForm = new details();
                dForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials for admin.");
            }
        }

        private bool AuthenticateUser(string username, string password, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string tableName = (role == "admin") ? "Admin" : "client";

                string query = $"SELECT * FROM {tableName} WHERE username=@Username AND password=@Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(username.Text, password.Text, "Customer"))
            {
                LoadClientDetails();
                MessageBox.Show("Customer login successful!");
                // Hide the current login form
                this.Hide();

                // Show the new form (replace MainForm with the actual form you want to show)
                
                customer clientDetailsForm = new customer(index);
                customer cForm = new customer();
                cForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials for customer.");
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }


        private void LoadClientDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Replace "YourTableName" with the actual table name in your database
                    string query = @"
                SELECT ClientID
                FROM client
                WHERE Username = @Username AND Password = @Password;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username.Text); // Replace with the actual username input
                        command.Parameters.AddWithValue("@Password", password.Text); // Replace with the actual password input

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Username and password are valid, fetch the client details
                            int fetchedClientId = (int)result;

                            // Continue fetching other client details based on the client ID
                            // ...

                            // Display the client details in the form
                            index = fetchedClientId; 
                            // Fetch and display other details as needed
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
