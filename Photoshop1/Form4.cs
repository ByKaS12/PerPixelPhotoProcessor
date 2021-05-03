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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public ObjectAPI pic;
        public Form1 f1;
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        public double[,] Fill_Filter;
        public int r;
        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(LinA.Text);
            CreateMatrix f5 = new CreateMatrix();
            f5.f4 = (Form4)Form.ActiveForm;
            Form.ActiveForm.Hide();
            f5.a = a;
            f5.ShowDialog();

        }

        private void FilterPic_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4.ActiveForm.Hide();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.f1 = this.f1;
            Form.ActiveForm.Hide();
            f2.pic = new ObjectAPI((Bitmap)FilterPic.Image);
            f2.pictureBox1.Image = FilterPic.Image;
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create filter Mediana
            Stopwatch st = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            int a = Convert.ToInt32(MidA.Text);
            FilterPic.Image = Filter.MedianaFilter(pic, a, ref st2);
            st.Stop();
            TimeMethod.Text = Convert.ToString(st2.ElapsedMilliseconds);
            TimeOperation.Text = Convert.ToString(st.ElapsedMilliseconds);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LinButton_Click(object sender, EventArgs e)
        {
            //create filter Lin
            Stopwatch st = new Stopwatch();
            Stopwatch st2 = new Stopwatch();
            st.Start();
            st2.Start();
            FilterPic.Image = Filter.LinFilter(pic, r, Fill_Filter, ref st2);
            st.Stop();
            TimeMethod.Text = Convert.ToString(st2.ElapsedMilliseconds);
            TimeOperation.Text = Convert.ToString(st.ElapsedMilliseconds);
        }
    }
}
