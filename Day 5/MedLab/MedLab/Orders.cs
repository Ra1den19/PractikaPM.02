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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Show_Orders_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select distinct [ID заказа], [наименование заказа], [дата создания], [статус заказа], услуги, [время выполнения заказа], Заказы.[ID пациента], ФИО, наименование, стоимость from Заказы inner join [Данные пациентов] on [Данные пациентов].[ID пациента] = Заказы.[ID пациента] inner join [Услуги лаборатории] on Заказы.услуги = [Услуги лаборатории].[ID услуги лаборатории]";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable table= new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void Show_Orders_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void Show_Orders_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Biomaterials bm = new Biomaterials();
            bm.ShowDialog();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditOrders eo = new EditOrders();
            eo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditPat ep = new EditPat();
            ep.ShowDialog();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
