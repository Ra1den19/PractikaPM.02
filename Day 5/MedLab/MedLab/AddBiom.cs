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
    public partial class AddBiom : Form
    {
        public AddBiom()
        {
            InitializeComponent();
        }

        private void show_analiz_button_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select [ID анализатора], [дата поступления заказа на анализатор], [время поступления заказа на анализатор], [дата выполнения услуги на анализаторе], [время выполнения услуги на анализаторе], [кем выполнена услуга], [ID биоматериала], ФИО from [Данные о работе анализатора] inner join [Данные лаборантов] on [Данные о работе анализатора].[кем выполнена услуга] = [Данные лаборантов].[ID лаборанта]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void show_bio_button_Click(object sender, EventArgs e)
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

        private void addbiom_button_Click(object sender, EventArgs e)
        {
            string AN = an.Text;
            string BIO = bio.Text;
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"update [Данные о работе анализатора] set [ID биоматериала] = '{BIO}' where [ID анализатора] = '{AN}'; select [ID анализатора], [дата поступления заказа на анализатор], [время поступления заказа на анализатор], [дата выполнения услуги на анализаторе], [время выполнения услуги на анализаторе], [кем выполнена услуга], [Данные лаборантов].ФИО, db_owner.[Биоматериалы].[ID биоматериала], [код пробирки], [наименование], [количество] from [Данные о работе анализатора] inner join db_owner.Биоматериалы on [Данные о работе анализатора].[ID биоматериала] = db_owner.Биоматериалы.[ID биоматериала] inner join [Данные лаборантов] on [Данные о работе анализатора].[кем выполнена услуга] = [Данные лаборантов].[ID лаборанта]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
                MessageBox.Show("Данные успешно внесены");
            }
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void add_an_button_Click(object sender, EventArgs e)
        {
            string LAB = lab.Text;
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"insert into [Данные о работе анализатора] ([дата поступления заказа на анализатор], [время поступления заказа на анализатор], [дата выполнения услуги на анализаторе], [время выполнения услуги на анализаторе], [кем выполнена услуга], [ID биоматериала]) values (getdate(), getdate(), dateadd(day, 2, getdate()), dateadd(day, 2, getdate()), '{LAB}', NULL); select * from [Данные о работе анализатора]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
                MessageBox.Show("Данные успешно внесены");
            }
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label9.Visible = true;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label10.Visible = true;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label10.Visible = false;
        }
    }
}
