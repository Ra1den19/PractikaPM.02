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
using static System.Windows.Forms.AxHost;

namespace MedLab
{
    public partial class EditPat : Form
    {
        public EditPat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"select ФИО, [дата рождения], [серия паспорта], [номер паспорта], телефон, email, [номер страхового полиса], [тип страхового полиса], [название страховой компании] from [Данные пациентов] inner join [Данные о страховых компаниях] on [Данные пациентов].[страховая компания] = [Данные о страховых компаниях].[ID страховой компании]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
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

        private void button1_Click(object sender, EventArgs e)
        {
            EditPatient();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label9.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        public void EditPatient()
        {
            try
            {
                if (fio.Text == "" || nomstrah.Text == "" || tipstrah.Text == "" || ser.Text == "" || nom.Text == "")
                {
                    MessageBox.Show("Введите данные");
                }
                else
                {
                    string FIO = fio.Text;
                    string NOMSTRAH = nomstrah.Text;
                    string TIPSTRAH = tipstrah.Text;
                    string SER = ser.Text;
                    string NOM = nom.Text;
                    string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = $"update [данные пациентов] set [серия паспорта] = '{SER}', [номер паспорта] = '{NOM}', [номер страхового полиса] = '{NOMSTRAH}', [тип страхового полиса] = '{TIPSTRAH}' where ФИО = '{FIO}'; select * from [Данные пациентов]";
                        SqlCommand com = new SqlCommand(query, con);
                        SqlDataAdapter ad = new SqlDataAdapter(com);
                        DataTable tab = new DataTable();
                        ad.Fill(tab);
                        dataGridView1.DataSource = tab;
                        MessageBox.Show("Данные успешно изменены");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Данные введены неверно. Проверьте правильность введённых данных");
            }
        }
    }
}
