using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedLab
{
    public partial class Buhgalter_Work : Form
    {
        public Buhgalter_Work()
        {
            InitializeComponent();
        }

        private void showinfo_button_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select [ID счета], [Данные о страховых компаниях].[ID страховой компании], [Данные пациентов].[ID пациента], [Оказанные услуги].[ID услуги], [название страховой компании], [адрес компании], [ИНН], [р/с], [БИК], [Данные пациентов].ФИО, [дата оказания услуги], [кем оказана услуга], [Данные лаборантов].ФИО from [Счета страховых компаний] inner join [Данные о страховых компаниях] on [Данные о страховых компаниях].[ID страховой компании] = [Счета страховых компаний].[ID страховой компании] inner join [Данные пациентов] on [Счета страховых компаний].[ID пациента] = [Данные пациентов].[ID пациента] inner join [Оказанные услуги] on [Счета страховых компаний].[ID услуги] = [Оказанные услуги].[ID услуги] inner join [Данные лаборантов] on [Оказанные услуги].[кем оказана услуга] = [Данные лаборантов].[ID лаборанта]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void saveotchet_button_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            string sqlQuery = "select [ID счета], [Данные о страховых компаниях].[ID страховой компании], [Данные пациентов].[ID пациента], [Оказанные услуги].[ID услуги], [название страховой компании], [адрес компании], [ИНН], [р/с], [БИК], [Данные пациентов].ФИО, [дата оказания услуги], [кем оказана услуга], [Данные лаборантов].ФИО from [Счета страховых компаний] inner join [Данные о страховых компаниях] on [Данные о страховых компаниях].[ID страховой компании] = [Счета страховых компаний].[ID страховой компании] inner join [Данные пациентов] on [Счета страховых компаний].[ID пациента] = [Данные пациентов].[ID пациента] inner join [Оказанные услуги] on [Счета страховых компаний].[ID услуги] = [Оказанные услуги].[ID услуги] inner join [Данные лаборантов] on [Оказанные услуги].[кем оказана услуга] = [Данные лаборантов].[ID лаборанта]";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            SaveToCSV(dataTable);
            MessageBox.Show("Отчет успешно сохранен");
        }

        public void SaveToCSV(DataTable dataTable)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\nicit\\OneDrive\\Рабочий стол\\Отчеты\\Otchet.csv", false, Encoding.UTF8))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    writer.WriteLine(string.Join(",", fields));
                }
            }

        }

        public void SaveOtchet(DataTable dataTable)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\nicit\\OneDrive\\Рабочий стол\\Отчеты\\Otchet_okaz_usl.csv", false, Encoding.UTF8))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    writer.WriteLine(string.Join(",", fields));
                }
            }
        }

        public void SaveOtchet2(DataTable dataTable)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\nicit\\OneDrive\\Рабочий стол\\Отчеты\\Otchet_quality_control.csv", false, Encoding.UTF8))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    writer.WriteLine(string.Join(",", fields));
                }
            }
        }

        private void showinfo_button_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void showinfo_button_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void saveotchet_button_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void saveotchet_button_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void otchet_okaz_usl_button_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            string sqlQuery = "select distinct count([Оказанные услуги].[ID услуги]) as [количество услуг], count([Данные пациентов].[ID пациента]) as [Количество пациентов], avg([Среднее отклонение]) as [Средний результат] from [Оказанные услуги] inner join [Счета страховых компаний] on [Оказанные услуги].[ID услуги] = [Счета страховых компаний].[ID услуги] inner join [Данные пациентов] on [Счета страховых компаний].[ID пациента] = [Данные пациентов].[ID пациента] inner join Заказы on [Оказанные услуги].[ID услуги] = Заказы.услуги inner join [Услуги лаборатории] on [Оказанные услуги].[ID услуги] = [Услуги лаборатории].[ID услуги лаборатории]";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

            SaveOtchet(dataTable);
            MessageBox.Show("Отчет успешно сохранен");
        }

        private void otchet_control_quality_button_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            string query = "select distinct [Услуги лаборатории].наименование as [наименование услуги], стоимость, [среднее отклонение], Биоматериалы.наименование as [наименование биоматериала], количество as [количество биоматериала] from [Услуги лаборатории] inner join db_owner.Биоматериалы on [Услуги лаборатории].[ID услуги лаборатории] = db_owner.Биоматериалы.[услуги]";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

            SaveOtchet2(dataTable);
            MessageBox.Show("Отчет успешно сохранен");
        }

        private void otchet_control_quality_button_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void otchet_control_quality_button_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void otchet_okaz_usl_button_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void otchet_okaz_usl_button_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
