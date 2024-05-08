using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MedLab
{
    public partial class Biomaterials : Form
    {
        public Biomaterials()
        {
            InitializeComponent();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label8.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label9.Visible = true;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void add_order_button_Click(object sender, EventArgs e)
        {
            try
            {
                string PROB = prob.Text;
                string NAIM = naim.Text;
                string KOL = kol.Text;
                string PAT = pat.Text;
                string USL = usl.Text;
                string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = $"insert into db_owner.Биоматериалы ([код пробирки], наименование, количество, [ID пациента], услуги) values ('{PROB}', '{NAIM}', '{KOL}', '{PAT}', '{USL}'); select * from db_owner.Биоматериалы";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    dataGridView1.DataSource = table;
                    com.Connection.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Заказ успешно оформлен");
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректные данные в соответствующие поля");
            }
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label14.Visible = true;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label14.Visible = false;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label15.Visible = true;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from db_owner.Биоматериалы";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPatient ap = new AddPatient();
            ap.ShowDialog();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            add_patient_info.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            add_patient_info.Visible = false;
        }
    }
}
