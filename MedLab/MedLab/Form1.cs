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
    public partial class MedLab : Form
    {
        public MedLab()
        {
            InitializeComponent();
        }

        private void Enter_button_Click(object sender, EventArgs e)
        {
            Laborant_Auth la = new Laborant_Auth();
            la.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Laborant_Auth la = new Laborant_Auth();
            la.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Buhgalter_Auth ba = new Buhgalter_Auth();
            ba.ShowDialog();
        }

        private void Enter_button_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible= false;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void Enter_button_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }
    }
}
