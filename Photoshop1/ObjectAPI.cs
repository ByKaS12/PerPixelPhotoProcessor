using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Photoshop1
{
   public struct  RGB_Gist
    {
        public int[] R;
        public int[] G;
        public int[] B;
    }
   public class ObjectAPI: ICloneable
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public RGB_Double[,] matrix;
        public byte[,] Rmatrix;
        public int[,] RmatrixSum;
        public byte MinPix;
        public byte MaxPix;
        public int[,] RmatrixMulti;
        public RGB_Gist GistRGB;
        public int[] GistI;
        public Bitmap pic;
        public ObjectAPI(string filename)
        {
            FileName = filename;
            pic = new Bitmap(FileName);
            Width = pic.Width;
            Height = pic.Height;
            matrix = new RGB_Double[Width, Height];
            Rmatrix = new byte[Width, Height];
            RmatrixSum = new int[Width, Height];
            RmatrixMulti = new int[Width, Height];
            GistI = new int[256];
            GistRGB.R = new int[256];
            GistRGB.G = new int[256];
            GistRGB.B = new int[256];
            MaxPix = 0;
            MinPix = 0;
            int[,] sum = new int[Width, Height];
            int[,] multi = new int[Width, Height];
            for (int i = 0; i < pic.Height; i++)
            {
                
                for (int j = 0; j < pic.Width; j++)
                {
                    var pix = pic.GetPixel(j, i);
                    
                    matrix[j, i].R = pix.R;
                    matrix[j, i].G = pix.G;
                    matrix[j, i].B = pix.B;
                    Rmatrix[j,i]= (byte)(int)((0.2125 * matrix[j, i].R + 0.7154 * matrix[j, i].G + 0.0721 * matrix[j, i].B));
                    if (MaxPix < Rmatrix[j, i])
                        MaxPix = (byte)Rmatrix[j, i];
                    if (MinPix > Rmatrix[j, i])
                        MinPix = (byte)Rmatrix[j, i];
                    ++GistI[Rmatrix[j, i]];
                    ++GistRGB.R[pix.R];
                    ++GistRGB.G[pix.G];
                    ++GistRGB.B[pix.B];

                    if (j - 1 >= 0)
                    {
                        sum[j, i] = sum[j - 1, i] + Rmatrix[j, i];
                        multi[j,i] = multi[j - 1, i] + Rmatrix[j, i]*Rmatrix[j,i];
                    }

                    else
                    {
                        sum[j, i] = Rmatrix[j, i];
                        multi[j, i] = Rmatrix[j, i] * Rmatrix[j, i];
                    }
                        
                    if (i - 1 >= 0)
                    {
                        RmatrixSum[j, i] = RmatrixSum[j, i - 1] + sum[j, i];
                        RmatrixMulti[j, i] = RmatrixMulti[j, i - 1] + multi[j, i];
                    }

                    else
                    {
                        RmatrixSum[j, i] = sum[j, i];
                        RmatrixMulti[j, i] =multi[j, i];
                    }
                        




                }

            }

        }
        
        public ObjectAPI()
        {

        }

        public Image Show()
        {
           
            Bitmap pic = new Bitmap(Width,Height);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    Color pix = Color.FromArgb(Rmatrix[j,i], Rmatrix[j, i], Rmatrix[j, i]);
                    pic.SetPixel(j, i, pix);

                }
                
            }
            return pic;

        }
        
       
        public Image ShowRGB()
        {

            Bitmap pic = new Bitmap(Width, Height);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    Color pix = Color.FromArgb((int)matrix[j, i].R, (int)matrix[j, i].G, (int)matrix[j, i].B);
                    pic.SetPixel(j, i, pix);

                }

            }
            return pic;

        }
        public void ChangeGist(Chart MainChart,string str)
        {
            var mass = MainChart.Series[str].Points;
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
            if(str == "Func")
            {
                var mass1 = MainChart.Series["RedStream"].Points;
                var mass2 = MainChart.Series["GreenStream"].Points;
                var mass3 = MainChart.Series["BlueStream"].Points;
                var m1 = mass.ToArray();
                var m2 = mass.ToArray();
                var m3 = mass.ToArray();
                double[] ChartX1 = new double[m1.Count()];
                double[] ChartY1 = new double[m1.Count()];
                double[] ChartX2 = new double[m2.Count()];
                double[] ChartY2 = new double[m2.Count()];
                double[] ChartX3 = new double[m3.Count()];
                double[] ChartY3 = new double[m3.Count()];
                for (int i = 0; i < m.Count(); i++)
                {
                    ChartX1[i] = m1[i].XValue;
                    ChartY1[i] = m1[i].YValues[0];
                    ChartX2[i] = m2[i].XValue;
                    ChartY2[i] = m2[i].YValues[0];
                    ChartX3[i] = m3[i].XValue;
                    ChartY3[i] = m3[i].YValues[0];

                }
                CubicSpline spline1 = new CubicSpline();
                CubicSpline spline2 = new CubicSpline();
                CubicSpline spline3 = new CubicSpline();
                GistI = new int[256];
                GistRGB.R = new int[256];
                GistRGB.G = new int[256];
                GistRGB.B = new int[256];
                spline1.BuildSpline(ChartX1, ChartY1, m1.Count());
                spline2.BuildSpline(ChartX2, ChartY2, m2.Count());
                spline3.BuildSpline(ChartX3, ChartY3, m3.Count());
                for (int i = 0; i < Height; i++)
                {

                    for (int j = 0; j < Width; j++)
                    {
                        Rmatrix[j, i] = (byte)spline.Interpolate(Rmatrix[j, i]);
                        matrix[j, i].R = (byte)spline1.Interpolate(matrix[j, i].R);
                        matrix[j, i].G = (byte)spline2.Interpolate(matrix[j, i].G);
                        matrix[j, i].B = (byte)spline3.Interpolate(matrix[j, i].B);
                        ++GistI[Rmatrix[j, i]];
                        ++GistRGB.R[(int)matrix[j, i].R];
                        ++GistRGB.G[(int)matrix[j, i].G];
                        ++GistRGB.B[(int)matrix[j, i].B];


                    }
                }
            }
            if (str == "RedStream")
            {
                GistRGB.R = new int[256];
                for (int i = 0; i < Height; i++)
                {

                    for (int j = 0; j < Width; j++)
                    {
                        matrix[j, i].R = (byte)spline.Interpolate(matrix[j,i].R); ;
                        ++GistRGB.R[(int)matrix[j, i].R];


                    }
                }
            }
            if (str == "GreenStream")
            {
                GistRGB.G = new int[256];
                for (int i = 0; i < Height; i++)
                {

                    for (int j = 0; j < Width; j++)
                    {
                        matrix[j, i].G = (byte)spline.Interpolate(matrix[j, i].G); ;
                        ++GistRGB.G[(int)matrix[j, i].G];


                    }
                }
            }
            if (str == "BlueStream")
            {
                GistRGB.B = new int[256];
                for (int i = 0; i < Height; i++)
                {

                    for (int j = 0; j < Width; j++)
                    {
                        matrix[j, i].B = (byte)spline.Interpolate(matrix[j, i].B); ;
                        ++GistRGB.B[(int)matrix[j, i].B];


                    }
                }
            }




        }
        public object Clone()
        {
            ObjectAPI aPI = new ObjectAPI();
            aPI.Height = Height;
            aPI.Width = Width;
            aPI.FileName = FileName;
            aPI.MaxPix = MaxPix;
            aPI.MinPix = MinPix;
            aPI.matrix = matrix.Clone() as RGB_Double[,];
            aPI.Rmatrix = Rmatrix.Clone() as byte[,];
            aPI.RmatrixSum = RmatrixSum.Clone() as int[,];
            aPI.RmatrixMulti = RmatrixMulti.Clone() as int[,];
            aPI.GistI = GistI.Clone() as int[];
            aPI.GistRGB.R = GistRGB.R.Clone() as int[];
            aPI.GistRGB.G = GistRGB.G.Clone() as int[];
            aPI.GistRGB.B = GistRGB.B.Clone() as int[];
            return aPI;
        }
    }
}
