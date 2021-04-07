using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoshop1
{
  static public  class BinMethods
    {
        static public double ConvertMatrixNiblek(ObjectAPI pic, int a, int ii, int jj,double k)
        {
            int x1 = jj - a;
            int x2 = jj + a;
            int y1 = ii - a;
            int y2 = ii + a;
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;

            if (x1 <= 0)
                x1 = 1;
            if (x2 >= pic.Width)
                x2 = pic.Width - 1;
            if (y1 <= 0)
                y1 = 1;
            if (y2 >= pic.Height)
                y2 = pic.Height - 1;
            S4 = pic.RmatrixSum[x2, y1 - 1];
            S3 = pic.RmatrixSum[x1 - 1, y2];
            S2 = pic.RmatrixSum[x1 - 1, y1 - 1];
            S1 = pic.RmatrixSum[x2, y2];

            int SS1 = 0;
            int SS2 = 0;
            int SS3 = 0;
            int SS4 = 0;

                SS1 = pic.RmatrixMulti[x2, y2];

                SS2 = pic.RmatrixMulti[x1 - 1, y1 - 1];

                SS3 = pic.RmatrixMulti[x1 - 1, y2];

                SS4 = pic.RmatrixMulti[x2, y1 - 1];

            var Mx  = S1 + S2 - S3 - S4;
            var Mx2 = SS1 + SS2 - SS3 - SS4;

            int Size = (int)Math.Pow((2 * a) + 1, 2);
            Mx /= Size;
            Mx2 /= Size;
            double D = Mx2 - (Mx * Mx);
            var sigma = Math.Sqrt(D);
            var t = Mx + (k * sigma);
            
            return t;
        }
        static public double[] ConvertMatrixBredly(ObjectAPI pic, int a, int ii, int jj)
        {

            int Size = (int)Math.Pow((2 * a) + 1, 2);
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;
            int x1 = jj-a;
            int x2 = jj+a;
            int y1 = ii-a;
            int y2 =ii+a;
            if (x1 <= 0)
                x1 = 1;
            if (x2 >= pic.Width)
                x2 = pic.Width - 1;
            if (y1 <= 0)
                y1 = 1;
            if (y2 >= pic.Height)
                y2 = pic.Height - 1;
            S4 = pic.RmatrixSum[x2, y1 - 1];
            S3 = pic.RmatrixSum[x1 - 1, y2];
            S2 = pic.RmatrixSum[x1 - 1, y1 - 1];
            S1 = pic.RmatrixSum[x2, y2];
            var sum = S1 + S2 - S3 - S4;

            double[] result = new double[2];
            result[0] = sum;
            result[1] = Size;
            return result;
        }
        static public double ConvertMatrixSayvol(ObjectAPI pic, int a, int ii, int jj, double k)
        {

            int x1 = jj - a;
            int x2 = jj + a;
            int y1 = ii - a;
            int y2 = ii + a;
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;

            if (x1 <= 0)
                x1 = 1;
            if (x2 >= pic.Width)
                x2 = pic.Width - 1;
            if (y1 <= 0)
                y1 = 1;
            if (y2 >= pic.Height)
                y2 = pic.Height - 1;
            S4 = pic.RmatrixSum[x2, y1 - 1];
            S3 = pic.RmatrixSum[x1 - 1, y2];
            S2 = pic.RmatrixSum[x1 - 1, y1 - 1];
            S1 = pic.RmatrixSum[x2, y2];

            int SS1 = 0;
            int SS2 = 0;
            int SS3 = 0;
            int SS4 = 0;

            SS1 = pic.RmatrixMulti[x2, y2];

            SS2 = pic.RmatrixMulti[x1 - 1, y1 - 1];

            SS3 = pic.RmatrixMulti[x1 - 1, y2];

            SS4 = pic.RmatrixMulti[x2, y1 - 1];

            var Mx = S1 + S2 - S3 - S4;
            var Mx2 = SS1 + SS2 - SS3 - SS4;
            int Size = (int)Math.Pow((2 * a) + 1, 2);
            Mx /= Size;
            Mx2 /= Size;
            double D = Mx2 - (Mx * Mx);
            var sigma = Math.Sqrt(D);
            int R = 128;
            var t = Mx*(1 + k*((sigma/R)-1));
            return t;
        }
        static public double ConvertMatrixVylf(ObjectAPI pic, int a, int ii, int jj, double k,int m, double R)
        {

            int x1 = jj - a;
            int x2 = jj + a;
            int y1 = ii - a;
            int y2 = ii + a;
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;

            if (x1 <= 0)
                x1 = 1;
            if (x2 >= pic.Width)
                x2 = pic.Width - 1;
            if (y1 <= 0)
                y1 = 1;
            if (y2 >= pic.Height)
                y2 = pic.Height - 1;
            S4 = pic.RmatrixSum[x2, y1 - 1];
            S3 = pic.RmatrixSum[x1 - 1, y2];
            S2 = pic.RmatrixSum[x1 - 1, y1 - 1];
            S1 = pic.RmatrixSum[x2, y2];

            int SS1 = 0;
            int SS2 = 0;
            int SS3 = 0;
            int SS4 = 0;

            SS1 = pic.RmatrixMulti[x2, y2];

            SS2 = pic.RmatrixMulti[x1 - 1, y1 - 1];

            SS3 = pic.RmatrixMulti[x1 - 1, y2];

            SS4 = pic.RmatrixMulti[x2, y1 - 1];

            var Mx = S1 + S2 - S3 - S4;
            var Mx2 = SS1 + SS2 - SS3 - SS4;
            int Size = (int)Math.Pow((2 * a) + 1, 2);
            Mx /= Size;
            Mx2 /= Size;
            double D = Mx2 - (Mx * Mx);
            var sigma = Math.Sqrt(D);
            var t = (1 - k) * Mx + k * m + k * (sigma / R) * (Mx - m);
            return t;
        }
        static public double ConvertMatrixVylf2(ObjectAPI pic, int a, int ii, int jj)
        {

            int x1 = jj - a;
            int x2 = jj + a;
            int y1 = ii - a;
            int y2 = ii + a;
            int S1 = 0;
            int S2 = 0;
            int S3 = 0;
            int S4 = 0;

            if (x1 <= 0)
                x1 = 1;
            if (x2 >= pic.Width)
                x2 = pic.Width - 1;
            if (y1 <= 0)
                y1 = 1;
            if (y2 >= pic.Height)
                y2 = pic.Height - 1;
            S4 = pic.RmatrixSum[x2, y1 - 1];
            S3 = pic.RmatrixSum[x1 - 1, y2];
            S2 = pic.RmatrixSum[x1 - 1, y1 - 1];
            S1 = pic.RmatrixSum[x2, y2];

            int SS1 = 0;
            int SS2 = 0;
            int SS3 = 0;
            int SS4 = 0;

            SS1 = pic.RmatrixMulti[x2, y2];

            SS2 = pic.RmatrixMulti[x1 - 1, y1 - 1];

            SS3 = pic.RmatrixMulti[x1 - 1, y2];

            SS4 = pic.RmatrixMulti[x2, y1 - 1];

            var Mx = S1 + S2 - S3 - S4;
            var Mx2 = SS1 + SS2 - SS3 - SS4;
            int Size = (int)Math.Pow((2 * a) + 1, 2);
            Mx /= Size;
            Mx2 /= Size;
            double D = Mx2 - (Mx * Mx);
            var sigma = Math.Sqrt(D);

            return sigma;
        }
        static public void CalcOtcu(double[] I,int t,int max,ref double deltaDef,ref int tDef)
        {
            
            
            double omega1 = 0;
            double calc = 0;
            double calcMax = 0;
            for (int i = 0; i < t-1; i++)
            {
                omega1 += I[i];
            }
            for (int i = 0; i < t - 1; i++)
            {
                calc += i*I[i];
            }
            for (int i = 0; i < max; i++)
            {
                calcMax += i * I[i];
            }
            double omega2 = 1 - omega1;
            double sigma1 = calc / omega1;
            
            double sigma2 = (calcMax - (sigma1*omega1)) / omega2;
            double delta = omega1 * omega2 * Math.Pow((sigma1-sigma2),2);
            if (delta > deltaDef)
            {
                deltaDef = delta;
                tDef = t;
            }
        }
        static public Image Gavr(ObjectAPI picture, ref Stopwatch st2)
        {
            ObjectAPI pic = new ObjectAPI();
            pic = picture.Clone() as ObjectAPI;
            double sum = 0;
            var w = pic.Width;
            var h = pic.Height;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                   sum+= pic.Rmatrix[j,i] ;
                }
            }
            var t = sum / (w * h);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    if(pic.Rmatrix[j, i] <= t)
                        pic.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] > t)
                        pic.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic.Show();
        }
        static public Image Otcu(ObjectAPI picture, ref Stopwatch st2)
        {
            ObjectAPI pic = new ObjectAPI();
            pic = picture.Clone() as ObjectAPI;
            var w = pic.Width;
            var h = pic.Height;
            double[] I = new double[256];
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    ++I[pic.Rmatrix[j, i]];

                }
            }
            for (int i = 0; i < I.Count(); i++)
            {
                I[i] = I[i] / (w * h);
            }
            double deltaDef = 0;
            int tDef = 0;
            for (int t = 0; t < pic.MaxPix; t++)
            {
                CalcOtcu(I, t, pic.MaxPix, ref deltaDef, ref tDef);

            }
            //throw new Exception();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    if (pic.Rmatrix[j, i] <= tDef)
                        pic.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] > tDef)
                        pic.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic.Show();
        }
        static public Image Niblek(ObjectAPI picture,double k,int a, ref Stopwatch st2)
        {
            ObjectAPI pic = new ObjectAPI();
            pic = picture.Clone() as ObjectAPI;
            ObjectAPI pic2 = new ObjectAPI();
            pic2 = picture.Clone() as ObjectAPI;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var t = ConvertMatrixNiblek(pic, a, i, j, k);
                    if (pic.Rmatrix[j, i] <= t)
                        pic2.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] > t)
                        pic2.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic2.Show();
        }
        static public Image Sayvol(ObjectAPI picture, double k, int a, ref Stopwatch st2)
        {
            
            ObjectAPI pic = picture.Clone() as ObjectAPI;
            ObjectAPI pic2 = picture.Clone() as ObjectAPI;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var t = ConvertMatrixSayvol(pic, a, i, j, k);
                    if (pic.Rmatrix[j, i] <= t)
                        pic2.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] > t)
                        pic2.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic2.Show();
        }
        static public Image Vylf(ObjectAPI picture, double k, int a, ref Stopwatch st2)
        {
            ObjectAPI pic = picture.Clone() as ObjectAPI;
            ObjectAPI pic2 = picture.Clone() as ObjectAPI;
            double R = 0;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var r = ConvertMatrixVylf2(pic, a, i, j);
                    if (R < r)
                        R = r;
                }
            }
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var t = ConvertMatrixVylf(pic, a, i, j, k,pic.MinPix,R);
                    if (pic.Rmatrix[j, i] <= t)
                        pic2.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] > t)
                        pic2.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic2.Show();
        }
        static public Image Bredly(ObjectAPI picture, double k, int a,ref  Stopwatch st2)
        {

            ObjectAPI pic = picture.Clone() as ObjectAPI;
            ObjectAPI pic2 = picture.Clone() as ObjectAPI;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var t = ConvertMatrixBredly(pic, a, i, j);
                    if (pic.Rmatrix[j, i]*t[1] < t[0]*(1-k))
                        pic2.Rmatrix[j, i] = 0;
                    if (pic.Rmatrix[j, i] * t[1] >= t[0] * (1 - k))
                        pic2.Rmatrix[j, i] = 255;
                }
            }
            st2.Stop();
            return pic2.Show();
        }
    }
}
