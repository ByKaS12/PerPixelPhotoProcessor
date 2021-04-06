using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Stopwatch st = new Stopwatch();
            st.Start();
            switch (comboBox1.SelectedItem)
            {
                case "Критерий Гаврилова":
                    {
                        pictureBox1.Image = BinMethods.Gavr(pic);
                        st.Stop();
                        time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
                        break;
                    }
                case "Критерий Отсу":
                    {
                        pictureBox1.Image = BinMethods.Otcu(pic);
                        st.Stop();
                        time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
                        break;
                    }
                default:
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            if(k.Text!="" && a.Text!="")
            pictureBox1.Image = BinMethods.Niblek(pic,Convert.ToDouble(k.Text), Convert.ToInt32(a.Text));
            else
                pictureBox1.Image = BinMethods.Niblek(pic, -0.2, 4);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() +"  " + "секунд(ы)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Sayvol(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text));
            else
                pictureBox1.Image = BinMethods.Sayvol(pic, 0.25, 4);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Vylf(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text));
            else
                pictureBox1.Image = BinMethods.Vylf(pic, 0.5, 4);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Bredly(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text));
            else
                pictureBox1.Image = BinMethods.Bredly(pic, 0.15, 4);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";

        }
    }
    }

