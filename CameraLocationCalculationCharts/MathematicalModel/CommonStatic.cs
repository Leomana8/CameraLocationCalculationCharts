using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public static class MyMath
    {
        public static double SD( double a, double b ) // SquareDifference
        {
            return ( a - b ).Squared();
        }

        public static double Squared( this double a )
        {
            return Math.Pow( a, 2 );
        }

    }
}
