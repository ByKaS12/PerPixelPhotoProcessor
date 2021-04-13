using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Photoshop1
{
 public   static class Curve
    {
        public static double CubInterp(double[] arrY,double[] arrX,double mX)
        {
            int intIndex = 0;
            int m = arrX.Count();
            double CubInterp = 0;
            while (intIndex!=m)
            {
                if (mX < arrX[intIndex])
                    break;
                else
                intIndex++;
            }
            if (intIndex < 2) intIndex = 2;
            if (intIndex > m - 2) intIndex = m - 2;
            for (int i = intIndex-1; i != intIndex+2; i++)
            {
                double dbiProd = 1;
                for (int j = intIndex-1; j != intIndex+2; j++)
                {
                    if (i != j)
                        dbiProd *= (mX - arrX[j]) / (arrX[i] - arrX[j]);
                }
                CubInterp += (dbiProd * arrY[i]);
            }
            return CubInterp;

        }
      public  static double BezierCurvePoint(double P0, double P1, double P2, double P3, double t)
        {
            return (Math.Pow((1 - t), 3) * P0) + (3 * t * Math.Pow((1 - t), 2) * P1) + (3 * t * t * (1 - t) * P2) + (t * t * t * P3);
        }
       static public int[] Interp(Chart MainChart)
        {
            var mass = MainChart.Series[0].Points;
            var m = mass.ToArray();
            double[] ChartX = new double[m.Count()];
            double[] ChartY = new double[m.Count()];
            for (int i = 0; i < m.Count(); i++)
            {
                ChartX[i] = m[i].XValue;
                ChartY[i] = m[i].YValues[0];

            }
            CubicSpline spline = new CubicSpline();
            spline.BuildSpline(ChartX, ChartY, m.Count());

            int[] Y = new int[256];
            for (int i = 0; i < 256; i++)
            {
                Y[i] = (int)spline.Interpolate(i);
            }
            return Y;
        }
       static public Chart loadGist(Chart chart, ObjectAPI pic, string flag)
        {
            Chart chart1 = chart;

            if (flag == "GR")
            {
                int max = pic.GistRGB.R.Max();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GR"].Points.AddXY(i, pic.GistRGB.R[i]);
                }
            }
            if (flag == "GG")
            {
                int max = pic.GistRGB.G.Max();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GG"].Points.AddXY(i, pic.GistRGB.G[i]);
                }
            }
            if (flag == "GB")
            {
                int max = pic.GistRGB.B.Max();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GB"].Points.AddXY(i, pic.GistRGB.B[i]);
                }
            }
            if (flag == "GI")
            {
                int max = pic.GistI.Max();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series["GI"].Points.AddXY(i, pic.GistI[i]);
                }
            }

            return chart1;
        }
    }
}
