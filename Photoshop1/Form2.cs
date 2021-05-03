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
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            switch (comboBox1.SelectedItem)
            {
                case "Критерий Гаврилова":
                    {
                        pictureBox1.Image = BinMethods.Gavr(pic, ref st2);
                        st.Stop();
                        time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
                        InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
                        break;
                    }
                case "Критерий Отсу":
                    {
                        pictureBox1.Image = BinMethods.Otcu(pic, ref st2);
                        st.Stop();
                        time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
                        InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
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
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            if (k.Text!="" && a.Text!="")
            pictureBox1.Image = BinMethods.Niblek(pic,Convert.ToDouble(k.Text), Convert.ToInt32(a.Text), ref st2);
            else
                pictureBox1.Image = BinMethods.Niblek(pic, -0.2, 4, ref st2);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() +"  " + "секунд(ы)";
            InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Sayvol(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text), ref st2);
            else
                pictureBox1.Image = BinMethods.Sayvol(pic, 0.25, 4, ref st2);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
            InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Vylf(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text), ref st2);
            else
                pictureBox1.Image = BinMethods.Vylf(pic, 0.5, 4, ref st2);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
            InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            if (k.Text != "" && a.Text != "")
                pictureBox1.Image = BinMethods.Bredly(pic, Convert.ToDouble(k.Text), Convert.ToInt32(a.Text),ref st2);
            else
                pictureBox1.Image = BinMethods.Bredly(pic, 0.15, 4,ref  st2);
            st.Stop();
            time.Text = st.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";
            InTime.Text = st2.Elapsed.TotalSeconds.ToString() + "  " + "секунд(ы)";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

