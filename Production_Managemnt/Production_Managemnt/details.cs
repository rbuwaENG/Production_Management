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
    public partial class details : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        public details()
        {
            InitializeComponent();
            LoadProductionData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            client_details cdetails = new client_details();
            cdetails.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            location ldetails = new location();
            ldetails.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            property pdetails = new property();
            pdetails.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            staff_details sdetails = new staff_details();
            sdetails.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            production_details prdetails = new production_details();
            prdetails.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadProductionData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Replace "YourProductionTable" with your actual production table name
                    string query = @"
            SELECT
                P.ProductionID,
                P.ProductionName,
                C.ClientName,
                L.LocationName,
                S.StaffName,
                Pr.PropertyName
            FROM
                Production AS P
            JOIN
                client AS C ON P.ClientID = C.ClientID
            JOIN
                productlocat AS PLR ON P.ProductionID = PLR.ProductionID
            JOIN
                Location AS L ON PLR.LocationID = L.LocationID
            JOIN
                ProductStaff AS PSR ON P.ProductionID = PSR.ProductionID
            JOIN
                staff AS S ON PSR.StaffID = S.StaffID
            JOIN
                Productproperty AS PPR ON P.ProductionID = PPR.ProductionID
            JOIN
                property AS Pr ON PPR.PropertyID = Pr.PropertyID;
        ";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Optionally, you can use a BindingSource
                        // BindingSource bindingSource = new BindingSource();
                        // bindingSource.DataSource = dataTable;

                        // Set the DataGridView data source
                        dataGridView1.DataSource = dataTable;
                        // Optionally, you can set the BindingSource as the data source
                        // dataGridViewProduction.DataSource = bindingSource;

                        // Automatically resize the columns to fit the content
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading production data: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProductionData();
        }
    }
}
