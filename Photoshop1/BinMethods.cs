using System;
using System.Collections.Generic;
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

            int[] copy = new int[(int)Math.Pow((2*a)+1,2)];
            int ci = 0;
            
            for (int i = ii-a; i <= ii + a; i++)
            {
                for (int j = jj - a; j <= jj + a; j++)
                {
                    if (i >= 0 && j >= 0 && i < pic.Height && j < pic.Width)
                        copy[ci] = pic.Rmatrix[j, i];
                    else
                        copy[ci] = -1;
                    ci++;
                }
                
            }
            double Mx = 0;
            double Mx2 = 0;
            int iii = copy.Count();
            
            for (int i = 0; i < copy.Count(); i++)
            {
                if (copy[i] != -1)
                {
                    Mx += copy[i];
                    Mx2 += copy[i] * copy[i];
                }
                else
                    iii--;
            }
           //Mx = copy.Where(u => u != -1).Sum() / iii;
            Mx /= iii;
            Mx2 /= iii;
            double D = Mx2 - Mx * Mx;
            
            var sigma = Math.Sqrt(D);
            var t = Mx + k * sigma;
            
            return t;
        }
        static public double ConvertMatrixSayvol(ObjectAPI pic, int a, int ii, int jj, double k)
        {

            int[] copy = new int[(int)Math.Pow((2 * a) + 1, 2)];
            int ci = 0;

            for (int i = ii - a; i < ii + a; i++)
            {
                for (int j = jj - a; j < jj + a; j++)
                {
                    if (i >= 0 && j >= 0 && i < pic.Height && j < pic.Width)
                        copy[ci] = pic.Rmatrix[j, i];
                    else
                        copy[ci] = -1;
                    ci++;
                }

            }
            int Mx = 0;
            int Mx2 = 0;
            int iii = copy.Count();
            for (int i = 0; i < copy.Count(); i++)
            {
                if (copy[i] != -1)
                {
                    Mx += copy[i];
                    Mx2 += copy[i] * copy[i];
                }
                else
                    iii--;
            }
            Mx /= iii;
            Mx2 /= iii;
            int R = 128;
            double D = Mx2 - Math.Pow(Mx, 2);
            var sigma = Math.Sqrt(D);
            var t = Mx*(1 + k*((sigma/R)-1));
            return t;
        }
        static public double ConvertMatrixVylf(ObjectAPI pic, int a, int ii, int jj, double k,int m, double R)
        {

            int[] copy = new int[(int)Math.Pow((2 * a) + 1, 2)];
            int ci = 0;

            for (int i = ii - a; i < ii + a; i++)
            {
                for (int j = jj - a; j < jj + a; j++)
                {
                    if (i >= 0 && j >= 0 && i < pic.Height && j < pic.Width)
                        copy[ci] = pic.Rmatrix[j, i];
                    else
                        copy[ci] = -1;
                    ci++;
                }

            }
            int Mx = 0;
            int Mx2 = 0;
            int iii = copy.Count();
            for (int i = 0; i < copy.Count(); i++)
            {
                if (copy[i] != -1)
                {
                    Mx += copy[i];
                    Mx2 += copy[i] * copy[i];
                    
                }
                else
                    iii--;
            }
            Mx /= iii;
            Mx2 /= iii;
            
            double D = Mx2 - Math.Pow(Mx, 2);
            var sigma = Math.Sqrt(D);
            var t = (1 - k) * Mx + k * m + k * (sigma / R) * (Mx - m);
            return t;
        }
        static public double ConvertMatrixVylf2(ObjectAPI pic, int a, int ii, int jj)
        {

            int[] copy = new int[(int)Math.Pow((2 * a) + 1, 2)];
            int ci = 0;

            for (int i = ii - a; i < ii + a; i++)
            {
                for (int j = jj - a; j < jj + a; j++)
                {
                    if (i >= 0 && j >= 0 && i < pic.Height && j < pic.Width)
                        copy[ci] = pic.Rmatrix[j, i];
                    else
                        copy[ci] = -1;
                    ci++;
                }

            }
            int Mx = 0;
            int Mx2 = 0;
            int iii = copy.Count();
            for (int i = 0; i < copy.Count(); i++)
            {
                if (copy[i] != -1)
                {
                    Mx += copy[i];
                    Mx2 += copy[i] * copy[i];

                }
                else
                    iii--;
            }
            Mx /= iii;
            Mx2 /= iii;

            double D = Mx2 - Math.Pow(Mx, 2);
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
        static public Image Gavr(ObjectAPI picture)
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
            return pic.Show();
        }
        static public Image Otcu(ObjectAPI picture)
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
            
            return pic.Show();
        }
        static public Image Niblek(ObjectAPI picture,double k,int a)
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
            
            return pic2.Show();
        }
        static public Image Sayvol(ObjectAPI picture, double k, int a)
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

            return pic2.Show();
        }
        static public Image Vylf(ObjectAPI picture, double k, int a)
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

            return pic2.Show();
        }
    }
}
