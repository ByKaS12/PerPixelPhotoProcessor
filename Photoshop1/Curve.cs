using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoshop1
{
 public   static class Curve
    {
      public  static double BezierCurvePoint(double P0, double P1, double P2, double P3, double t)
        {
            return (Math.Pow((1 - t), 3) * P0) + (3 * t * Math.Pow((1 - t), 2) * P1) + (3 * t * t * (1 - t) * P2) + (t * t * t * P3);
        }

    }
}
