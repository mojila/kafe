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

namespace Kafe_POS
{
    public partial class Distributor : Form
    {
        private static string connectionString = @"Data Source=DESKTOP-LUG65OK\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public Distributor()
        {
            InitializeComponent();
        }

        private void loadDistributor()
        {
            sqlConnection.Open();

            string query = "SELECT * FROM distributor";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataSet.Tables[0];

            sqlConnection.Close();
            return;
        }

        private void createDistributor(string nama, string telepon)
        {

            string query = "INSERT INTO distributor (nama, telepon) VALUES ('" + nama + "', '" + telepon +"')";

            using (SqlCommand sqlCommand = new SqlCommand(query))
            {
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }

            return;
        }

        private void Distributor_Load(object sender, EventArgs e)
        {
            loadDistributor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createDistributor(textBox1.Text, textBox2.Text);
            loadDistributor();
        }
    }
}
