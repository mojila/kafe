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
    public partial class Form1 : Form
    {
        private static string connectionString = @"Data Source=DESKTOP-LUG65OK\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        Kasir kasir;

        private void login(string username, string password)
        {
            sqlConnection.Open();

            string query = "SELECT id, nama_pengguna FROM kasir WHERE nama_pengguna='" 
                + username + "' AND kata_sandi='" + password + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    kasir = new Kasir(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1));
                }
                clearLogin();
                groupBox1.Hide();
                menuStrip1.Show();
            } else
            {
                MessageBox.Show("Nama Pengguna atau Kata Sandi salah.");
                clearLogin();
            }

            sqlConnection.Close();
            return;
        }

        private void clearLogin()
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasir = null;
            menuStrip1.Hide();
            groupBox1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Hide();
        }

        private void checkCredentialInput()
        {
            string username = textBox1.Text;
            string password = maskedTextBox1.Text;
            if (username != "" && password != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkCredentialInput();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login(textBox1.Text, maskedTextBox1.Text);
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            checkCredentialInput();
        }

        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void satuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satuan satuan = new Satuan();

            satuan.MdiParent = this;
            satuan.TopMost = true;
            satuan.Show();
        }

        private void distributorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void distributorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Distributor distributor = new Distributor();

            distributor.MdiParent = this;
            distributor.TopMost = true;
            distributor.Show();
        }
    }
}
