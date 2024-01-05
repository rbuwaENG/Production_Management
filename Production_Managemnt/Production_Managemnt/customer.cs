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
    public partial class customer : Form
    {
        private readonly int clientId = 1;
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        public customer()
        {
            InitializeComponent();
            LoadClientDetails();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login lldetails = new login();
            lldetails.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Succeeded!", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public customer(int clientId)
        {
            InitializeComponent();
           // this.clientId = clientId;

            // Load client details when the form is created
            LoadClientDetails();
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }


        private void LoadClientDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("YourConnectionString"))
                {
                    connection.Open();

                    string query = @"
                        SELECT p.ProductionID, p.ProductionName, s.StaffTypeName, DATEDIFF(day, GETDATE(), p.[Date]) AS NumberOfDays
                        FROM Production p
                        JOIN StaffType s ON p.ClientID = @ClientID AND p.StaffTypeID = s.StaffTypeID;
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Assuming dataGridViewProductDetails is the name of your DataGridView control
                            dataGridView1.DataSource = dataTable;

                            // Optionally, you can set the DataGridViewAutoSizeColumnsMode
                            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("YourConnectionString"))
                {
                    connection.Open();

                    string query = @"
                        SELECT p.ProductionID, p.ProductionName, s.StaffTypeName, DATEDIFF(day, GETDATE(), p.[Date]) AS NumberOfDays
                        FROM Production p
                        JOIN StaffType s ON p.ClientID = @ClientID AND p.StaffTypeID = s.StaffTypeID
                        WHERE p.ProductionID = @ProductionID;
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.Parameters.AddWithValue("@ProductionID", textBox3.Text);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Assuming dataGridViewProductDetails is the name of your DataGridView control
                            dataGridView1.DataSource = dataTable;

                            // Optionally, you can set the DataGridViewAutoSizeColumnsMode
                            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching by Production ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact Admin", "Update Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadClientDetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
    

