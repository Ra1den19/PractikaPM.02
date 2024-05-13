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
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void add_patient_button_Click(object sender, EventArgs e)
        {
            string FIO = fio.Text;
            string DATA = data.Text;
            string SER = ser.Text;
            string NOM = nom.Text;
            string TEL = tel.Text;
            string NOMSTRAH = nomstrah.Text;
            string TIPSTRAH = tipstrah.Text;
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"insert into [Данные пациентов] (логин, пароль, ФИО, [дата рождения], [серия паспорта], [номер паспорта], телефон, email, [номер страхового полиса], [тип страхового полиса], [страховая компания]) values (NULL, NULL, '{FIO}', '{DATA}', '{SER}', '{NOM}', '{TEL}', NULL, '{NOMSTRAH}', '{TIPSTRAH}', NULL)";
                SqlCommand com = new SqlCommand(query, con);
                com.Connection.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Пациент успешно добавлен");  
            }
             
        }
    }
}
