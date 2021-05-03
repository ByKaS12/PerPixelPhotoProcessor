using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Photoshop1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Gist.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            Gist.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            Gist.ChartAreas[0].BorderWidth = 1;
            Gist.ChartAreas[0].BorderColor = Color.Black;
            Gist.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
            Gist.Series["GI"].Enabled = true;
            Gist.Series["GR"].Enabled = false;
            Gist.Series["GG"].Enabled = false;
            Gist.Series["GB"].Enabled = false;
            DataPoint dp = new DataPoint(0,0);
            DataPoint dp2 = new DataPoint(255,255);
            dp.MarkerStyle = MarkerStyle.Square;
            dp2.MarkerStyle = MarkerStyle.Square;
            dp.MarkerColor = Color.DarkGreen;
            dp2.MarkerColor = Color.DarkGreen;
            MainChart.ChartAreas["Func"].AxisX.Enabled = AxisEnabled.False;
            MainChart.ChartAreas["Func"].AxisY.Enabled = AxisEnabled.False;
            MainChart.ChartAreas["Func"].BorderWidth = 1;
            MainChart.ChartAreas["Func"].BorderColor = Color.Black;
            MainChart.ChartAreas["Func"].BorderDashStyle = ChartDashStyle.Solid;
            MainChart.Series["Func"].Enabled = true;
            MainChart.Series["RedStream"].Enabled = false;
            MainChart.Series["GreenStream"].Enabled = false;
            MainChart.Series["BlueStream"].Enabled = false;
            MainChart.Series["Func"].Points.Add(dp);
            MainChart.Series["Func"].Points.Add(dp2);
            MainChart.Series["RedStream"].Points.Add(dp);
            MainChart.Series["RedStream"].Points.Add(dp2);
            MainChart.Series["GreenStream"].Points.Add(dp);
            MainChart.Series["GreenStream"].Points.Add(dp2);
            MainChart.Series["BlueStream"].Points.Add(dp);
            MainChart.Series["BlueStream"].Points.Add(dp2);
            MainChart.GetToolTipText += MainChart_GetToolTipText;
            MainChart.MouseClick += MainChart_MouseClick;
            MainChart.MouseUp += MainChart_MouseUp;
            MainChart.MouseMove += MainChart_MouseMove;
            
            

        }


        public string str = "Func";
        public string str2 = "GI";
        public bool flag = false;
        private void MainChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right))
            {
                double X = Convert.ToDouble(Lx.Text);
                double Y = Convert.ToDouble(Ly.Text);
                DataPoint dp = new DataPoint(X, Y);
                
                dp.MarkerStyle = MarkerStyle.Square;
                dp.MarkerColor = Color.Red;

                var mass = MainChart.Series[str].Points.ToArray();
                for (int i = 0; i < mass.Count(); i++)
                {
                    if ((int)X == (int)mass[i].XValue)
                        return;
                }
                MainChart.Series[str].Points.Add(dp);
                MainChart.Series[str].Sort(PointSortOrder.Ascending);
                ObjectAPI pic2 = pic.Clone() as ObjectAPI;
                //pic2.ChangeGist(MainChart,str);
                Gist.Series[str2].Points.Clear();
                
                if (flag == false)
                    Parallel.Invoke(() => Gist = Curve.loadGist(Gist, pic2, str2),() => pic2.ChangeGist(MainChart, str), () => MainPic.Image = pic2.ShowRGB());
                //MainPic.Image = pic2.ShowRGB();
                else
                    Parallel.Invoke(() => Gist = Curve.loadGist(Gist, pic2, str2), () => pic2.ChangeGist(MainChart, str), () => MainPic.Image = pic2.Show());
                //MainPic.Image = pic2.Show();
                //Gist = Curve.loadGist(Gist, pic2, str2);
                MainPic.Refresh();


            }
            
        }

        private void MainChart_MouseUp(object sender, MouseEventArgs e)
        {
            curPoint = null;
        }

        DataPoint curPoint = null;
        private void MainChart_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button.HasFlag(MouseButtons.Left))
            {
                ChartArea ca = MainChart.ChartAreas[0];
                Axis ax = ca.AxisX;
                Axis ay = ca.AxisY;
                int X= e.X, Y = e.Y;
                HitTestResult hit = MainChart.HitTest(e.X, e.Y);
                if (hit.PointIndex > 0)
                    curPoint = hit.Series.Points[hit.PointIndex];

                //if (curPoint != null)
                //{
                //    if (curPoint.XValue == 255 && curPoint.YValues[0] == 255) curPoint = null;
                //    if (curPoint.XValue == 0 && curPoint.YValues[0] == 0) curPoint = null;
                //    if (MainChart.Series[0].Points[MainChart.Series[0].Points.Count() - 1] == curPoint) curPoint = null;
                //    if (MainChart.Series[0].Points[0] == curPoint) curPoint = null;

                //}
                if (curPoint != null)
                {
                    Series s = hit.Series;
                    double dx = ax.PixelPositionToValue(e.X);
                    double dy = ay.PixelPositionToValue(e.Y);
                    
                    curPoint.XValue = dx;
                    curPoint.YValues[0] = dy;
                }


                ObjectAPI pic2 = pic.Clone() as ObjectAPI;
                //pic2.ChangeGist(MainChart,str);
                Gist.Series[str2].Points.Clear();
               
                if (flag == false)
                    Parallel.Invoke(() => Gist = Curve.loadGist(Gist, pic2, str2), () => pic2.ChangeGist(MainChart, str), () => MainPic.Image = pic2.ShowRGB());
                //MainPic.Image = pic2.ShowRGB();
                else
                    Parallel.Invoke(() => Gist = Curve.loadGist(Gist, pic2, str2),() => pic2.ChangeGist(MainChart, str), () => MainPic.Image = pic2.Show());
                //MainPic.Image = pic2.Show();
                MainPic.Refresh();
                Gist = Curve.loadGist(Gist, pic2, str2);
            }
        }
        public DataPointCollection points;
        private void MainChart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Если текст в подсказке уже есть, то ничего не меняем.
            if (!String.IsNullOrWhiteSpace(e.Text))
                return;

            Console.WriteLine(e.HitTestResult.ChartElementType);

            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
                case ChartElementType.Gridlines:
                case ChartElementType.Axis:
                case ChartElementType.TickMarks:
                case ChartElementType.PlottingArea:
                    // Первый ChartArea
                    var area = MainChart.ChartAreas[0];

                    // Его относительные координаты (в процентах от размеров Chart)
                    var areaPosition = area.Position;

                    // Переводим в абсолютные
                    var areaRect = new RectangleF(areaPosition.X * MainChart.Width / 100, areaPosition.Y * MainChart.Height / 100,
                        areaPosition.Width * MainChart.Width / 100, areaPosition.Height * MainChart.Height / 100);

                    // Область построения (в процентах от размеров area)
                    var innerPlot = area.InnerPlotPosition;
                    var innerRect = new RectangleF(innerPlot.X * MainChart.Width / 100, innerPlot.Y * MainChart.Height / 100,
                        innerPlot.Width * MainChart.Width / 100, innerPlot.Height * MainChart.Height / 100);
                    
                    double x = area.AxisX.Minimum +
                                (area.AxisX.Maximum - area.AxisX.Minimum) * (e.X - areaRect.Left - innerPlot.X * areaRect.Width / 100) /
                                (innerPlot.Width * areaRect.Width / 100);
                    double y = area.AxisY.Maximum -
                                (area.AxisY.Maximum - area.AxisY.Minimum) * (e.Y - areaRect.Top - innerPlot.Y * areaRect.Height / 100) /
                                (innerPlot.Height * areaRect.Height / 100);

                    points = MainChart.Series[str].Points;
                    if(x<=0)
                    Lx.Text = Convert.ToString(0);
                    else
                        Lx.Text = Convert.ToString(Math.Round(x, 3));
                    if (x >= 255)
                        Lx.Text = Convert.ToString(255);
                    else
                        Lx.Text = Convert.ToString(Math.Round(x, 3));
                    if (y <= 0)
                        Ly.Text = Convert.ToString(0);
                    else
                        Ly.Text = Convert.ToString(Math.Round(y, 3));
                    if (y >= 255)
                        Ly.Text = Convert.ToString(255);
                    else
                        Ly.Text = Convert.ToString(Math.Round(y, 3));

                    break;
            }
            }

        public ObjectAPI pic;
        public Form1 f1;
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            f1.Show();

        }

        private void GR_Click(object sender, EventArgs e)
        {

        }

        private void pLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainChart_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                
        }

        private void Stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (Stream.SelectedItem)
            {
                case "Яркость":
                    {
                        MainPic.Refresh();
                        str = "Func";
                        str2 = "GI";
                        MainChart.Series["Func"].Enabled = true;
                        MainChart.Series["RedStream"].Enabled = false;
                        MainChart.Series["GreenStream"].Enabled = false;
                        MainChart.Series["BlueStream"].Enabled = false;
                        Gist.Series["GI"].Enabled = true;
                        Gist.Series["GR"].Enabled = false;
                        Gist.Series["GG"].Enabled = false;
                        Gist.Series["GB"].Enabled = false;
                        flag = false;
                        break;
                    }
                case "Серый канал":
                    {
                        MainPic.Refresh();
                        str = "Func";
                        str2 = "GI";
                        MainChart.Series["Func"].Enabled = true;
                        MainChart.Series["RedStream"].Enabled = false;
                        MainChart.Series["GreenStream"].Enabled = false;
                        MainChart.Series["BlueStream"].Enabled = false;
                        Gist.Series["GI"].Enabled = true;
                        Gist.Series["GR"].Enabled = false;
                        Gist.Series["GG"].Enabled = false;
                        Gist.Series["GB"].Enabled = false;
                        flag = true;
                        break;
                    }
                case "Красный канал":
                    {
                        MainPic.Refresh();
                        str = "RedStream";
                        str2 = "GR";
                        MainChart.Series["Func"].Enabled = false;
                        MainChart.Series["RedStream"].Enabled = true;
                        MainChart.Series["GreenStream"].Enabled = false;
                        MainChart.Series["BlueStream"].Enabled = false;
                        Gist.Series["GI"].Enabled = false;
                        Gist.Series["GR"].Enabled = true;
                        Gist.Series["GG"].Enabled = false;
                        Gist.Series["GB"].Enabled = false;
                        flag = false;
                        break;
                    }
                case "Зеленый канал":
                    {
                        MainPic.Refresh();
                        str = "GreenStream";
                        str2 = "GG";
                        MainChart.Series["Func"].Enabled = false;
                        MainChart.Series["RedStream"].Enabled = false;
                        MainChart.Series["GreenStream"].Enabled = true;
                        MainChart.Series["BlueStream"].Enabled = false;
                        Gist.Series["GI"].Enabled = false;
                        Gist.Series["GR"].Enabled = false;
                        Gist.Series["GG"].Enabled = true;
                        Gist.Series["GB"].Enabled = false;
                        flag = false;
                        break;
                    }
                case "Синий канал":
                    {
                        MainPic.Refresh();
                        str = "BlueStream";
                        str2 = "GB";
                        MainChart.Series["Func"].Enabled = false;
                        MainChart.Series["RedStream"].Enabled = false;
                        MainChart.Series["GreenStream"].Enabled = false;
                        MainChart.Series["BlueStream"].Enabled = true;
                        Gist.Series["GI"].Enabled = false;
                        Gist.Series["GR"].Enabled = false;
                        Gist.Series["GG"].Enabled = false;
                        Gist.Series["GB"].Enabled = true;
                        flag = false;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
