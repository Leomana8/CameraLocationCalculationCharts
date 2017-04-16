using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Acceleration
    {
        private double af;
        private double as_;
        private Coordinates finish;
        private double t1;
        private double t2;
        private double x;
        private double y;
        private double z;

        public Acceleration( Coordinates start, Coordinates finish, double t1, double t2, double as_, double af )
        {
            this.finish = finish;
            this.t1 = t1;
            this.t2 = t2;
            this.as_ = as_;
            this.af = af;

            x = finish.X - start.X;
            y = finish.Y - start.Y;
            z = finish.Z - start.Z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public void Set( double currentT )
        {
            double a = 0;
            if ( currentT <= t1 )
                a = as_;
            else if ( currentT > t2 )
                a = af;
            else
            {
                X = Y = Z = 0;
                return;
            }

            X = a * x / Math.Sqrt( x.Squared() + z.Squared() );
            Y = a * y / Math.Sqrt( x.Squared() + y.Squared() );
            Z = a * z / Math.Sqrt( x.Squared() + z.Squared() );
        }

    }
}
