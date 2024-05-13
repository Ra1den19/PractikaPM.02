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
    public partial class Change_laborant_role : Form
    {
        public Change_laborant_role()
        {
            InitializeComponent();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (log.Text == "" || par.Text == "" || role.Text == "") 
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                string LOGIN = log.Text;
                string PASSWORD = par.Text;
                string ROLE = role.Text;
                string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; User ID = MedLab_Admin; Initial Catalog = MedicalLaboratory; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = $"update [Данные лаборантов] set роль = '{ROLE}' where логин = '{LOGIN}' and пароль = '{PASSWORD}'; select * from [Данные лаборантов]";
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable tab = new DataTable();
                    ad.Fill(tab);
                    dataGridView1.DataSource = tab;
                    MessageBox.Show("Роль была успешно изменена");
                }
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; User ID = MedLab_Admin; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"select * from [Данные лаборантов]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable tab = new DataTable();
                ad.Fill(tab);
                dataGridView1.DataSource = tab;
            }
        }
    }
}
