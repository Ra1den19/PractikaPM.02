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
    public partial class Buhgalter_Auth : Form
    {
        public Buhgalter_Auth()
        {
            InitializeComponent();
        }

        private void Enter_button_Click(object sender, EventArgs e)
        {
            string login = log.Text;
            string password = par.Text;
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = $"select * from [Бухгалтер] where логин = @login and пароль = @password; update [Бухгалтер] set [последняя дата входа] = getdate(), [последнее время входа] = getdate() where логин = '{login}' and пароль = '{password}'";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@login", login);
            com.Parameters.AddWithValue("@password", password);
            con.Open();

            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                MessageBox.Show($"Вы успешно авторизованы, здравствуйте, {login}");
                Buhgalter_Work bw = new Buhgalter_Work();
                bw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private bool isColor = true;
        private void pass_Click(object sender, EventArgs e)
        {
            par.UseSystemPasswordChar = !par.UseSystemPasswordChar;
            if (isColor)
            {
                pass.BackColor = Color.IndianRed;
            }
            else
            {
                pass.BackColor = Color.Green;
            }
            isColor = !isColor;
        }
    }
}
