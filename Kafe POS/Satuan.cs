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
    public partial class Satuan : Form
    {
        private static string connectionString = @"Data Source=DESKTOP-LUG65OK\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        private void loadSatuan()
        {
            sqlConnection.Open();

            string query = "SELECT * FROM satuan";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dataSet.Tables[0];

            sqlConnection.Close();
            return;
        }

        public Satuan()
        {
            InitializeComponent();
        }

        private void Satuan_Load(object sender, EventArgs e)
        {
            loadSatuan();
        }

        private void createSatuan(string satuan)
        {

            string query = "INSERT INTO satuan (satuan) VALUES ('"+satuan+"')";

            using (SqlCommand sqlCommand = new SqlCommand(query))
            {
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string satuan = textBox1.Text;

            createSatuan(satuan);
            loadSatuan();
        }
    }
}
