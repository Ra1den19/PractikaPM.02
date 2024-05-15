using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace PhoneDirectory
{
    /// <summary>
    /// Логика взаимодействия для DeleteContact.xaml
    /// </summary>
    public partial class DeleteContact : Window
    {
        public DeleteContact()
        {
            InitializeComponent();
        }

        private void show_contacts_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = Телефонный справочник; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select [код контакта], фамилия, имя, отчество, [номер телефона], [e-mail], [название], [название должности], [группа контактов], [дата рождения] from [Данные о контактах] inner join Компании on [Данные о контактах].компания = Компании.[код компании] inner join Должности on [Данные о контактах].должность = Должности.[код должности]";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ad.Fill(ds, "[Данные о контактах]");
            datagrid2.ItemsSource = ds.Tables["[Данные о контактах]"].DefaultView;
        }

        private void delete_contact_Click(object sender, RoutedEventArgs e)
        {
            if (kod.Text == "")
            {
                MessageBox.Show("Введите код контакта для удаления");
            }
            else
            {
                string KOD = kod.Text;
                string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = Телефонный справочник; Integrated Security = True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = $"delete from [Данные о контактах] where [код контакта] = '{KOD}'";
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Данные успешно удалены");
            }
        }
    }
}
