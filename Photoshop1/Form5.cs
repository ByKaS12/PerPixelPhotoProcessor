using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photoshop1
{
    public partial class CreateMatrix : Form
    {
        public int a;
        public Form4 f4;
        public CreateMatrix()
        {
            InitializeComponent();


        }

        double[,] matrix_Gayss;
        private void CreateMatrix_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < 2*a+1; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn(new DataGridViewTextBoxCell());
                Matrix.Columns.Add(column);
            }

            Matrix.Rows.Add((2 * a) + 1);
            Matrix.AllowUserToAddRows = false;
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            //get Lin Filter
        }
       
        private void Gauss_Click(object sender, EventArgs e)
        {
            double Sigma = Convert.ToDouble(this.Sigma.Text);
            double Sum = 0;
            matrix_Gayss = Math_Methods.GaussMatrix(a, Sigma, ref Sum);
            for (int i = 0; i < Matrix.Rows.Count; i++)
            {
                for (int j = 0; j < Matrix.Columns.Count; j++)
                {
                    Matrix.Rows[i].Cells[j].Value = Math.Round(matrix_Gayss[i, j],8);
                }

            }
            label2.Text = Convert.ToString(Math.Round(Sum,4));
        }
    }
}
