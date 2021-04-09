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
            DataPoint dp = new DataPoint(0,0);
            DataPoint dp2 = new DataPoint(255,255);
            dp.MarkerStyle = MarkerStyle.Square;
            dp2.MarkerStyle = MarkerStyle.Square;
            dp.MarkerColor = Color.DarkGreen;
            dp2.MarkerColor = Color.DarkGreen;
            InitializeComponent();
            MainChart.ChartAreas["Func"].AxisX.Enabled = AxisEnabled.False;
            MainChart.ChartAreas["Func"].AxisY.Enabled = AxisEnabled.False;
            MainChart.ChartAreas["Func"].BorderWidth = 1;
            MainChart.ChartAreas["Func"].BorderColor = Color.Black;
            MainChart.ChartAreas["Func"].BorderDashStyle = ChartDashStyle.Solid;
            MainChart.Series["Func"].Points.Add(dp);
            MainChart.Series["Func"].Points.Add(dp2);
            MainChart.GetToolTipText += MainChart_GetToolTipText;
            MainChart.MouseClick += MainChart_MouseClick;
            MainChart.MouseUp += MainChart_MouseUp;
            MainChart.MouseMove += MainChart_MouseMove;
            

        }

        private void MainChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right))
            {
                double X = Convert.ToDouble(Lx.Text);
                double Y = Convert.ToDouble(Ly.Text);
                DataPoint dp = new DataPoint(X, Y);
                dp.MarkerStyle = MarkerStyle.Square;
                dp.MarkerColor = Color.Red;
                MainChart.Series["Func"].Points.Add(dp);
                MainChart.Series["Func"].Sort(PointSortOrder.Ascending);
                
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


                if (curPoint != null)
                {
                    Series s = hit.Series;
                    double dx = ax.PixelPositionToValue(e.X);
                    double dy = ay.PixelPositionToValue(e.Y);

                    curPoint.XValue = dx;
                    curPoint.YValues[0] = dy;
                }
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

                    points = MainChart.Series["Func"].Points;
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
    }
}
