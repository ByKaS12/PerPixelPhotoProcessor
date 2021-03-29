using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoshop1
{
   public class ObjectAPI: ICloneable
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public RGB_Double[,] matrix;
        public ObjectAPI(string filename)
        {
            FileName = filename;
            Bitmap pic = new Bitmap(FileName);
            Width = pic.Width;
            Height = pic.Height;
            matrix = new RGB_Double[Width, Height];
            
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var pix = pic.GetPixel(j, i);
                    matrix[j, i].R = pix.R;
                    matrix[j, i].G = pix.G;
                    matrix[j, i].B = pix.B;
                }

            }

        }
        public ObjectAPI(Image image)
        {
            FileName = null;
            Bitmap pic = (Bitmap)image;
            Width = pic.Width;
            Height = pic.Height;
            matrix = new RGB_Double[Width, Height];

            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    var pix = pic.GetPixel(j, i);
                    matrix[j, i].R = pix.R;
                    matrix[j, i].G = pix.G;
                    matrix[j, i].B = pix.B;
                }

            }

        }
        public ObjectAPI()
        {

        }
        public void ToBlackWhite(ObjectAPI pic)
        {
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    pic.matrix[j, i].R = pic.matrix[j, i].G = pic.matrix[j, i].B = (0.2125*pic.matrix[j, i].R + 0.7154*pic.matrix[j, i].G + 0.0721*pic.matrix[j, i].B) / 3;
                }

            }

            
        }
        public Image Show()
        {
           
            Bitmap pic = new Bitmap(Width,Height);
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
            aPI.matrix = matrix.Clone() as RGB_Double[,];
            return aPI;
        }
    }
}
