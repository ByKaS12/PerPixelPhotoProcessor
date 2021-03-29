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

                   sum+= pic.matrix[j, i].R ;
                }
            }
            var t = sum / (w * h);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    if(pic.matrix[j, i].R<=t)
                        pic.matrix[j, i].R = pic.matrix[j, i].G = pic.matrix[j, i].B = 0;
                    if (pic.matrix[j, i].R > t)
                        pic.matrix[j, i].R = pic.matrix[j, i].G = pic.matrix[j, i].B = 255;
                }
            }
            return pic.Show();
        }
        static public Image Otcu(ObjectAPI picture)
        {
            ObjectAPI pic = new ObjectAPI();
            pic = picture.Clone() as ObjectAPI;
            int max = 0;
            var w = pic.Width;
            var h = pic.Height;
            double[] I = new double[256];
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    ++I[(int)pic.matrix[j, i].R];
                    if (max<(int)pic.matrix[j,i].R)
                    {
                        max =(int) pic.matrix[j, i].R;
                    }
                }
            }
            for (int i = 0; i < I.Count(); i++)
            {
                I[i] = I[i] / (w * h);
            }
            double deltaDef = 0;
            int tDef = 0;
            for (int t = 0; t < max; t++)
            {
                CalcOtcu(I, t, max, ref deltaDef, ref tDef);

            }
            //throw new Exception();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    if (pic.matrix[j, i].R <= tDef)
                        pic.matrix[j, i].R = pic.matrix[j, i].G = pic.matrix[j, i].B = 0;
                    if (pic.matrix[j, i].R > tDef)
                        pic.matrix[j, i].R = pic.matrix[j, i].G = pic.matrix[j, i].B = 255;
                }
            }
            
            return pic.Show();
        }
    }
}
