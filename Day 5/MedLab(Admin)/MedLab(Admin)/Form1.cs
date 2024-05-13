using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedLab_Admin_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; User ID = MedLab_Admin; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from [Данные пациентов]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; User ID = MedLab_Admin; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from [Данные лаборантов]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void show_buh_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; User ID = MedLab_Admin; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from [Бухгалтер]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void change_role_for_laborant_button_Click(object sender, EventArgs e)
        {
            Change_laborant_role clr = new Change_laborant_role();
            clr.ShowDialog();
        }
    }
}
