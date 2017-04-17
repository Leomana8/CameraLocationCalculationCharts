using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Acceleration
    {
        public Acceleration( Coordinates start, Coordinates finish, double t1, double t2, double as_, double af )
        {
            this.t1 = t1;
            this.t2 = t2;
            this.as_ = as_;
            this.af = af;

            x = finish.X - start.X;
            y = finish.Y - start.Y;
            z = finish.Z - start.Z;
        }

        private readonly double af;
        private readonly double as_;
        private readonly double t1;
        private readonly double t2;
        private readonly double x;
        private readonly double y;
        private readonly double z;

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public void Set( double currentT )
        {
            double a;
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