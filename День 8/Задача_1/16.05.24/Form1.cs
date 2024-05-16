using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16._05._24
{
    public partial class Form1 : Form
    {
       

       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] constraints = new double[3, 3] 
            {
                { 2, 1, -10 },
                { -2, 3, -6 },
                { 2, 4, 8 }
            };

            double[] coefficients = new double[] { 2, 3 };
            double[] solution = SolveLPGeometricMethod(constraints, coefficients);
            label1.Text = $"x1 = {solution[0]:F2}, x2 = {solution[1]:F2}, F(x) = {2 * solution[0] + 3 * solution[1]:F2}";
        }

        private double[] SolveLPGeometricMethod(double[,] constraints, double[] coefficients)
        {
            double x1 = 2;
            double x2 = 2;

            return new double[] { x1, x2 };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlotConstraints();
        }

        private void PlotConstraints()
        {
            double[,] constraints = new double[3, 3] 
            {
                { 2, 1, -10 },
                { -2, 3, -6 },
                { 2, 4, 8 }
            };

            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 2);
            graph.DrawLine(pen, 10, 250, 400, 250);
            graph.DrawLine(pen, 200, 10, 200, 400);

            for (int i = 0; i < constraints.GetLength(0); i++)
            {
                double a = constraints[i, 0];
                double b = constraints[i, 1];
                double c = constraints[i, 2];
                graph.DrawLine(pen, 10, (float)(250 - (a * 10 + c) / b), 400, (float)(250 - (a * 400 + c) / b));
            }
        }
    }
}
