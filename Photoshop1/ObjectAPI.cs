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
        public RGB_int[,] matrix;
        public ObjectAPI(string filename)
        {
            FileName = filename;
            Bitmap pic = new Bitmap(FileName);
            Width = pic.Width;
            Height = pic.Height;
            matrix = new RGB_int[Width, Height];
            
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
        public object Clone()
        {
            ObjectAPI aPI = new ObjectAPI();
            aPI.Height = Height;
            aPI.Width = Width;
            aPI.FileName = FileName;
            aPI.matrix = matrix.Clone() as RGB_int[,];
            return aPI;
        }
    }
}
