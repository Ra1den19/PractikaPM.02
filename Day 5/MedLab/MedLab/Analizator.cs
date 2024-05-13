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

namespace MedLab
{
    public partial class Analizator : Form
    {
        public Analizator()
        {
            InitializeComponent();
        }

        private void show_uslugi_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from [Услуги лаборатории] where [статус услуги] = 'активна'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBiom ab = new AddBiom();
            ab.ShowDialog();
        }

        private void show_uslugi_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void show_uslugi_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}
