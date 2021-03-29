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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public ObjectAPI pic;
        public Form1 f1;
        private void button1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            f1.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Критерий Гаврилова":
                    {
                        pictureBox1.Image = BinMethods.Gavr(pic);
                        break;
                    }
                case "Критерий Отсу":
                    {
                        pictureBox1.Image = BinMethods.Otcu(pic);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
