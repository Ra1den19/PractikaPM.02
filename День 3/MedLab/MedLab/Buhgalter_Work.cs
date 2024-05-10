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
using Newtonsoft;
using Newtonsoft.Json;

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
    }
}
