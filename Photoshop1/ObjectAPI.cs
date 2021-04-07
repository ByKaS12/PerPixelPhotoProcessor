using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ObjectAPI(string filename)
        {
            FileName = filename;
            Bitmap pic = new Bitmap(FileName);
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
        public Image ShowGist(int flag)
        {
           

            if(flag == 0)
            {
                Bitmap pic = new Bitmap(Width, Height);
                int max = GistRGB.R.Max();
                double point = (double)max / Height;
                for (int i = 0; i < Width - 3; ++i)
                {
                    for (int j = Height - 1; j > Height - GistRGB.R[i / 3] / point; --j)
                    {
                        pic.SetPixel(i, j, Color.Red);
                    }
                   
                }

                    return pic;
            }
            if (flag == 1)
            {
                Bitmap pic = new Bitmap(Width, Height);
                for (int i = 0; i < pic.Height; i++)
                {
                    for (int j = 0; j < pic.Width; j++)
                    {

                        Color pix = Color.FromArgb(Rmatrix[j, i], Rmatrix[j, i], Rmatrix[j, i]);
                        pic.SetPixel(j, i, pix);

                    }

                }
                return pic;
            }
            if (flag == 2)
            {
                Bitmap pic = new Bitmap(Width, Height);
                for (int i = 0; i < pic.Height; i++)
                {
                    for (int j = 0; j < pic.Width; j++)
                    {

                        Color pix = Color.FromArgb(Rmatrix[j, i], Rmatrix[j, i], Rmatrix[j, i]);
                        pic.SetPixel(j, i, pix);

                    }

                }
                return pic;
            }
            if (flag == 3)
            {
                Bitmap pic = new Bitmap(Width, Height);
                for (int i = 0; i < pic.Height; i++)
                {
                    for (int j = 0; j < pic.Width; j++)
                    {

                        Color pix = Color.FromArgb(Rmatrix[j, i], Rmatrix[j, i], Rmatrix[j, i]);
                        pic.SetPixel(j, i, pix);

                    }

                }
                return pic;
            }

            return null;
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
