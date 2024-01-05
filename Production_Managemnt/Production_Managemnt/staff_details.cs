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
    public partial class staff_details : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\productiondb.mdf;Integrated Security=True;Connect Timeout=30";
        public staff_details()
        {
            InitializeComponent();
            ShowStaff();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            details ddetails = new details();
            ddetails.Show();
        }

        public void ShowStaff()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Staff";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Assuming dataGridViewStaff is the name of your DataGridView control
                        dataGridView1.DataSource = dataTable;

                        // Optionally, you can set the DataGridViewAutoSizeColumnsMode
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading staff: " + ex.Message);
            }
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
                INSERT INTO Staff (StaffID, StaffName,type_Id)
                VALUES (@StaffID, @StaffName,@type);
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffID", textBox3.Text);
                        command.Parameters.AddWithValue("@StaffName", textBox1.Text);
                        command.Parameters.AddWithValue("@type", textBox2.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding staff: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            stype sdetails = new stype();
            sdetails.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Staff WHERE StaffID = @StaffID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffID", textBox3.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting staff: " + ex.Message);
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
                UPDATE Staff
                SET StaffName = @StaffName,
                    type_id = @type
                WHERE StaffID = @StaffID;
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffID", textBox3.Text);
                        command.Parameters.AddWithValue("@StaffName", textBox1.Text);
                        command.Parameters.AddWithValue("@type", textBox2.Text);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating staff: " + ex.Message);
            }
        }

        private void staff_details_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowStaff();
        }
    }
}
