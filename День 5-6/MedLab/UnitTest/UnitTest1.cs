using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MedLab;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string connectionString = $@"Data Source = DESKTOP-BAT1MFP\SQLEXPRESS; Initial Catalog = MedicalLaboratory; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = $"select ФИО, [дата рождения], [серия паспорта], [номер паспорта], телефон, email, [номер страхового полиса], [тип страхового полиса], [название страховой компании] from [Данные пациентов] inner join [Данные о страховых компаниях] on [Данные пациентов].[страховая компания] = [Данные о страховых компаниях].[ID страховой компании]";
                SqlCommand com = new SqlCommand(query, con);
                Assert.IsNotNull(com);
            }
        }
    }
}
