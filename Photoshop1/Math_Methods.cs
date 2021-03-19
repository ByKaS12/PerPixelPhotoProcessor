using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;

using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace Photoshop1
{ public struct RGB
    {
        public byte R;
        public byte G;
        public byte B;
    }
    public struct RGB_int
    {
        public int R;
        public int G;
        public int B;
    }
    static class Math_Methods
    {
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        static int FindWidth(List<ObjectAPI> pictures)
        {
            int w = pictures[0].Width;
            for (int i = 0; i < pictures.Count(); i++)
            {
                if (pictures[i].Width < w)
                    w = pictures[i].Width;

            }

            return w;
        }
        static int FindHeight(List<ObjectAPI> pictures)
        {
            int h = pictures[0].Height;
            
            for (int i = 0; i < pictures.Count(); i++)
            {
                if (pictures[i].Height < h)
                    h = pictures[i].Height;

            }

            return h;
        }
        public static Image SetImgOpacity(Image imgPic, float imgOpac)
        {
            Bitmap bmpPic = new Bitmap(imgPic.Width, imgPic.Height);
            Graphics gfxPic = Graphics.FromImage(bmpPic);
            ColorMatrix cmxPic = new ColorMatrix();
            cmxPic.Matrix33 = imgOpac/100;

            ImageAttributes iaPic = new ImageAttributes();
            iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gfxPic.DrawImage(imgPic, new Rectangle(0, 0, bmpPic.Width, bmpPic.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, iaPic);
            gfxPic.Dispose();

            return bmpPic;
        }


        public static Bitmap SumPix(List<ObjectAPI> pictures)
        {
            var result = new Bitmap(758, 695);
            ObjectAPI[] mass = new ObjectAPI[pictures.Count()];
            for (int i = 0; i < pictures.Count(); i++)
            {
                mass[i] = pictures[i].Clone() as ObjectAPI;
            }
            int w = mass[0].Width;
            int h = mass[0].Height;
            var ImgResult = new Bitmap(w, h);
            for (int k = mass.Count() - 1; k > 0; k--)
            {


                for (int i = 0; i < FindHeight(pictures); i++)
                {
                    for (int j = 0; j < FindWidth(pictures); j++)
                    {
                        mass[k - 1].matrix[j, i].R = Clamp( mass[k - 1].matrix[j, i].R + mass[k].matrix[j, i].R,0,255);
                        mass[k - 1].matrix[j, i].G = Clamp(mass[k - 1].matrix[j, i].G + mass[k].matrix[j, i].G,0,255);
                        mass[k - 1].matrix[j, i].B = Clamp(mass[k - 1].matrix[j, i].B + mass[k].matrix[j, i].B,0,255);
                    }

                }
            }
            for (int i = 0; i < mass[0].Height; i++)
            {
                for (int j = 0; j < mass[0].Width; j++)
                {
                    Color pix = Color.FromArgb(mass[0].matrix[j, i].R, mass[0].matrix[j, i].G, mass[0].matrix[j, i].B);
                    ImgResult.SetPixel(j, i, pix);

                }

            }
            //throw new Exception();
            var g = Graphics.FromImage(result);
            g.DrawImage(ImgResult, 0, 0, 758, 695);
            g.Dispose();
            ImgResult.Dispose();
            return result;
        }
        public static Bitmap CompotisionPix(List<ObjectAPI> pictures)
        {

            var result = new Bitmap(758,695);
            ObjectAPI[] mass = new ObjectAPI[pictures.Count()];
            for (int i = 0; i < pictures.Count(); i++)
            {
                mass[i] = pictures[i].Clone() as ObjectAPI ;
            }
            int w = mass[0].Width;
            int h = mass[0].Height;
            var ImgResult = new Bitmap(w, h);
            for (int k = mass.Count()-1; k > 0; k--)
            {

            
            for (int i = 0; i < FindHeight(pictures); i++)
            {
                for (int j = 0; j < FindWidth(pictures); j++)
                {
                        mass[k - 1].matrix[j, i].R = mass[k - 1].matrix[j, i].R * mass[k].matrix[j, i].R / 255;
                        mass[k - 1].matrix[j, i].G = mass[k - 1].matrix[j, i].G * mass[k].matrix[j, i].G / 255;
                        mass[k - 1].matrix[j, i].B = mass[k - 1].matrix[j, i].B * mass[k].matrix[j, i].B / 255;
                }

            }
            }
            for (int i = 0; i < mass[0].Height; i++)
            {
                for (int j = 0; j < mass[0].Width; j++)
                {
                    Color pix = Color.FromArgb(mass[0].matrix[j, i].R, mass[0].matrix[j, i].G, mass[0].matrix[j, i].B);
                    ImgResult.SetPixel(j, i, pix);

                }

            }
            //throw new Exception();
            var g = Graphics.FromImage(result);
            g.DrawImage(ImgResult, 0, 0, 758, 695);
            g.Dispose();
            ImgResult.Dispose();
            return result;
        }
        public static Bitmap AMP(List<ObjectAPI> pictures)
        {
            var result = new Bitmap(758, 695);
            ObjectAPI[] mass = new ObjectAPI[pictures.Count()];
            for (int i = 0; i < pictures.Count(); i++)
            {
                mass[i] = pictures[i].Clone() as ObjectAPI;
            }
            int w = mass[0].Width;
            int h = mass[0].Height;
            var ImgResult = new Bitmap(w, h);
            for (int k = mass.Count() - 1; k > 0; k--)
            {


                for (int i = 0; i < FindHeight(pictures); i++)
                {
                    for (int j = 0; j < FindWidth(pictures); j++)
                    {
                        mass[k - 1].matrix[j, i].R = Clamp((mass[k - 1].matrix[j, i].R + mass[k].matrix[j, i].R)/2, 0, 255);
                        mass[k - 1].matrix[j, i].G = Clamp((mass[k - 1].matrix[j, i].G + mass[k].matrix[j, i].G)/2, 0, 255);
                        mass[k - 1].matrix[j, i].B = Clamp((mass[k - 1].matrix[j, i].B + mass[k].matrix[j, i].B)/2, 0, 255);
                    }

                }
            }
            for (int i = 0; i < mass[0].Height; i++)
            {
                for (int j = 0; j < mass[0].Width; j++)
                {
                    Color pix = Color.FromArgb(mass[0].matrix[j, i].R, mass[0].matrix[j, i].G, mass[0].matrix[j, i].B);
                    ImgResult.SetPixel(j, i, pix);

                }

            }
            //throw new Exception();
            var g = Graphics.FromImage(result);
            g.DrawImage(ImgResult, 0, 0, 758, 695);
            g.Dispose();
            ImgResult.Dispose();
            return result;
        }
        public static Bitmap MinPix(List<ObjectAPI> pictures)
        {

            var result = new Bitmap(758, 695);
            ObjectAPI[] mass = new ObjectAPI[pictures.Count()];
            for (int i = 0; i < pictures.Count(); i++)
            {
                mass[i] = pictures[i].Clone() as ObjectAPI;
            }
            int w = mass[0].Width;
            int h = mass[0].Height;
            var ImgResult = new Bitmap(w, h);
            for (int k = mass.Count() - 1; k > 0; k--)
            {


                for (int i = 0; i < FindHeight(pictures); i++)
                {
                    for (int j = 0; j < FindWidth(pictures); j++)
                    {
                        if(mass[k - 1].matrix[j, i].R< mass[k].matrix[j, i].R)
                        mass[k - 1].matrix[j, i].R =mass[k].matrix[j, i].R;

                        if(mass[k - 1].matrix[j, i].G< mass[k].matrix[j, i].G)
                        mass[k - 1].matrix[j, i].G =mass[k].matrix[j, i].G;

                        if(mass[k - 1].matrix[j, i].B< mass[k].matrix[j, i].B)
                        mass[k - 1].matrix[j, i].B =mass[k].matrix[j, i].B;

                    }

                }
            }
            for (int i = 0; i < mass[0].Height; i++)
            {
                for (int j = 0; j < mass[0].Width; j++)
                {
                    Color pix = Color.FromArgb(mass[0].matrix[j, i].R, mass[0].matrix[j, i].G, mass[0].matrix[j, i].B);
                    ImgResult.SetPixel(j, i, pix);

                }

            }
            //throw new Exception();
            var g = Graphics.FromImage(result);
            g.DrawImage(ImgResult, 0, 0, 758, 695);
            g.Dispose();
            ImgResult.Dispose();
            return result;
        }
        public static Bitmap MaxPix(List<ObjectAPI> pictures)
        {

            var result = new Bitmap(758, 695);
            ObjectAPI[] mass = new ObjectAPI[pictures.Count()];
            for (int i = 0; i < pictures.Count(); i++)
            {
                mass[i] = pictures[i].Clone() as ObjectAPI;
            }
            int w = mass[0].Width;
            int h = mass[0].Height;
            var ImgResult = new Bitmap(w, h);
            for (int k = mass.Count() - 1; k > 0; k--)
            {


                for (int i = 0; i < FindHeight(pictures); i++)
                {
                    for (int j = 0; j < FindWidth(pictures); j++)
                    {
                        if (mass[k - 1].matrix[j, i].R > mass[k].matrix[j, i].R)
                            mass[k - 1].matrix[j, i].R = mass[k].matrix[j, i].R;

                        if (mass[k - 1].matrix[j, i].G > mass[k].matrix[j, i].G)
                            mass[k - 1].matrix[j, i].G = mass[k].matrix[j, i].G;

                        if (mass[k - 1].matrix[j, i].B > mass[k].matrix[j, i].B)
                            mass[k - 1].matrix[j, i].B = mass[k].matrix[j, i].B;

                    }

                }
            }
            for (int i = 0; i < mass[0].Height; i++)
            {
                for (int j = 0; j < mass[0].Width; j++)
                {
                    Color pix = Color.FromArgb(mass[0].matrix[j, i].R, mass[0].matrix[j, i].G, mass[0].matrix[j, i].B);
                    ImgResult.SetPixel(j, i, pix);

                }

            }
            //throw new Exception();
            var g = Graphics.FromImage(result);
            g.DrawImage(ImgResult, 0, 0, 758, 695);
            g.Dispose();
            ImgResult.Dispose();
            return result;
        }
    }

}
