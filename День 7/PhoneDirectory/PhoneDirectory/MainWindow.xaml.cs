using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneDirectory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void show_contacts_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = Телефонный справочник; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select фамилия, имя, отчество, [номер телефона], [e-mail], [название], [название должности], [группа контактов], [дата рождения] from [Данные о контактах] inner join Компании on [Данные о контактах].компания = Компании.[код компании] inner join Должности on [Данные о контактах].должность = Должности.[код должности]";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ad.Fill(ds, "[Данные о контактах]");
            datagrid.ItemsSource = ds.Tables["[Данные о контактах]"].DefaultView;
        }

        private void add_contact_Click(object sender, RoutedEventArgs e)
        {
            AddContact ac = new AddContact();
            ac.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditContact ec = new EditContact();
            ec.ShowDialog();
        }

        private void delete_contact_Click(object sender, RoutedEventArgs e)
        {
            DeleteContact dc = new DeleteContact();
            dc.ShowDialog();
        }

        private void sort_Click(object sender, RoutedEventArgs e)
        {
            if (sor.Text == "")
            {
                MessageBox.Show("Введите поле для сортировки");
            }
            else
            {
                string sort = sor.Text;
                string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = Телефонный справочник; Integrated Security = True";
                SqlConnection con = new SqlConnection(connectionString);
                string query = $"select фамилия, имя, отчество, [номер телефона], [e-mail], [название], [название должности], [группа контактов], [дата рождения] from [Данные о контактах]  inner join Компании on [Данные о контактах].компания = Компании.[код компании]  inner join Должности on [Данные о контактах].должность = Должности.[код должности] order by '{sort}'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                ad.Fill(ds, "[Данные о контактах]");
                datagrid.ItemsSource = ds.Tables["[Данные о контактах]"].DefaultView;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string search = sor.Text;
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = Телефонный справочник; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = $"select фамилия, имя, отчество, [номер телефона], [e-mail], [название], [название должности], [группа контактов], [дата рождения] from [Данные о контактах]  inner join Компании on [Данные о контактах].компания = Компании.[код компании]  inner join Должности on [Данные о контактах].должность = Должности.[код должности] where фамилия like '{search}' or имя like '{search}' or отчество like '{search}' or [группа контактов] like '{search}'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ad.Fill(ds, "[Данные о контактах]");
            datagrid.ItemsSource = ds.Tables["[Данные о контактах]"].DefaultView;
        }
    }
}
