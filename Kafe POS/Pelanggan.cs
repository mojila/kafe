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
    public partial class Pelanggan : Form
    {
        private static string connectionString = @"Data Source=MOJIA-PC\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public Pelanggan()
        {
            InitializeComponent();
        }

        private void loadPelanggan()
        {
            sqlConnection.Open();

            string query = "SELECT * FROM pelanggan";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataSet.Tables[0];

            sqlConnection.Close();
            return;
        }

        private void createPelanggan(string nama, string alamat, string telepon)
        {

            string query = "INSERT INTO pelanggan (nama, alamat, telepon) VALUES ('" + nama + "', '" + alamat + "', '" + telepon + "')";

            using (SqlCommand sqlCommand = new SqlCommand(query))
            {
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }

            return;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pelanggan_Load(object sender, EventArgs e)
        {
            loadPelanggan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createPelanggan(textBox1.Text, textBox2.Text, textBox3.Text);
            loadPelanggan();
        }
    }
}
