using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;

namespace Photoshop1
{
    public partial class ImageControl : UserControl
    {
        public ImageControl()
        {
            InitializeComponent();

            //Pictures = new List<ObjectAPI>();
        }

        public List<ObjectAPI> Pictures;
        public Bitmap image;
        public int ControlIndex;
        private void pictureBox1_Click(object sender, EventArgs e) //Add pictures from program
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PictureBox> pictures = new List<PictureBox>();
            switch (Convert.ToString(comboBox1.SelectedItem))
            {
                case "Sum Pix":
                    {
                        var CollectControl = Form.ActiveForm.Controls.Find("ImageControl", true).ToList();

                        foreach (var item in CollectControl)
                        {
                            var img = item.Parent.Controls.Find("pictureBox1", true);
                            PictureBox PicBox = img[0] as PictureBox;
                            if (PicBox != null)
                            {
                                pictures.Add(PicBox);
                            }
                        }
                        var FindPic = Form.ActiveForm.Controls.Find("mainPic", true);
                        if (FindPic != null)
                            foreach (var item in FindPic)
                            {
                                PictureBox pictureBox = item as PictureBox;
                                Form1 form1 = Form.ActiveForm as Form1;
                                if (pictureBox != null)
                                    pictureBox.Image = Math_Methods.SumPix(form1.Pictures);

                            }

                        pictures.RemoveRange(0, pictures.Count);
                        break;


                    }

                case "Composition Pix":
                    {
                        var FindPic = Form.ActiveForm.Controls.Find("mainPic", true);
                        if (FindPic != null)
                            foreach (var item in FindPic)
                            {
                                PictureBox pictureBox = item as PictureBox;
                                Form1 form1 = Form.ActiveForm as Form1;
                                if (pictureBox != null)
                                    pictureBox.Image = Math_Methods.CompotisionPix(form1.Pictures);

                            }
                        break;
                    }
                case "Arithmetic mean Pix":
                    {
                        var FindPic = Form.ActiveForm.Controls.Find("mainPic", true);
                        if (FindPic != null)
                            foreach (var item in FindPic)
                            {
                                PictureBox pictureBox = item as PictureBox;
                                Form1 form1 = Form.ActiveForm as Form1;
                                if (pictureBox != null)
                                    pictureBox.Image = Math_Methods.AMP(form1.Pictures);

                            }
                        break;
                    }
                case "Min Pix":
                    {
                        var FindPic = Form.ActiveForm.Controls.Find("mainPic", true);
                        if (FindPic != null)
                            foreach (var item in FindPic)
                            {
                                PictureBox pictureBox = item as PictureBox;
                                Form1 form1 = Form.ActiveForm as Form1;
                                if (pictureBox != null)
                                    pictureBox.Image = Math_Methods.MinPix(form1.Pictures);

                            }
                        break;
                    }
                case "Max Pix":
                    {
                        var FindPic = Form.ActiveForm.Controls.Find("mainPic", true);
                        if (FindPic != null)
                            foreach (var item in FindPic)
                            {
                                PictureBox pictureBox = item as PictureBox;
                                Form1 form1 = Form.ActiveForm as Form1;
                                if (pictureBox != null)
                                    pictureBox.Image = Math_Methods.MaxPix(form1.Pictures);

                            }
                        break;
                    }

            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Image image = this.pictureBox1.Image;
            Image imageOpacity = Math_Methods.SetImgOpacity(image, trackBar1.Value);
            var mainPic = this.Parent.Parent.Controls.Find("mainPic", true);
            foreach (var item in mainPic)
            {
                PictureBox picture = item as PictureBox;
                var img_out = new Bitmap(picture.Width, picture.Height);
                var g = Graphics.FromImage(img_out);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(imageOpacity, 0, 0, picture.Width, picture.Height);
                picture.Image = (Image)img_out;
                g.Dispose();
            }

            //throw new Exception();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = this.ControlIndex;
            Form1 form1 = Form.ActiveForm as Form1;

            form1.Pictures.RemoveAt(count);
            form1.ControlIndex--;
            Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = this.ControlIndex;
            Form2 f2 = new Form2();
            f2.f1 = (Form1)Form.ActiveForm;
            Form.ActiveForm.Hide();
            f2.pic = Pictures[count];
            f2.pictureBox1.Image = f2.pic.Show();
            f2.ShowDialog();

        }

        private void ImageControl_Load(object sender, EventArgs e)
        {

        }
        public Chart loadGist( Chart chart,ObjectAPI pic,int flag)
        {
            Chart chart1 = chart;

            if (flag == 0)
            {
                int max = pic.GistRGB.R.Max();
                //  chart1.ChartAreas["GR"].AxisY.Maximum = max;
                chart1.ChartAreas["GR"].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas["GR"].AxisY.Enabled = AxisEnabled.False;
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GR"].Points.AddXY(i, pic.GistRGB.R[i]);
                }
            }
            if (flag == 1)
            {
                int max = pic.GistRGB.G.Max();
                // chart1.ChartAreas["GG"].AxisY.Maximum = max;
                chart1.ChartAreas["GG"].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas["GG"].AxisY.Enabled = AxisEnabled.False;
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GG"].Points.AddXY(i, pic.GistRGB.G[i]);
                }
            }
            if (flag == 2)
            {
                int max = pic.GistRGB.B.Max();
                //  chart1.ChartAreas["GB"].AxisY.Maximum = max;
                chart1.ChartAreas["GB"].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas["GB"].AxisY.Enabled = AxisEnabled.False;
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GB"].Points.AddXY(i, pic.GistRGB.B[i]);
                }
            }
            if (flag == 3)
            {
                int max = pic.GistI.Max();
                //  chart1.ChartAreas["GI"].AxisY.Maximum = max;
                chart1.ChartAreas["GI"].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas["GI"].AxisY.Enabled = AxisEnabled.False;
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GI"].Points.AddXY(i, pic.GistI[i]);
                }
            }

            return chart1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int count = this.ControlIndex;
            Form3 f3 = new Form3();
            f3.f1 = (Form1)Form.ActiveForm;
            Form.ActiveForm.Hide();
            f3.pic = Pictures[count];
            f3.MainPic.Image = f3.pic.ShowRGB();
            f3.GR = loadGist(f3.GR,f3.pic,0);
            f3.GG = loadGist(f3.GG,f3.pic,1);
            f3.GB = loadGist(f3.GB,f3.pic,2);
            f3.GI = loadGist(f3.GI, f3.pic,3);
 
            
            f3.ShowDialog();
        }
    }
}
