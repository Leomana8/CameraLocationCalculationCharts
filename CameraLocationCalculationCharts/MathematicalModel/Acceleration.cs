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

            var x = finish.X - start.X;
            var y = finish.Y - start.Y;
            var z = finish.Z - start.Z;
            var dif = Math.Sqrt( x.Squared() + y.Squared() + z.Squared() );
            xMltpl = x / dif;
            yMltpl = y / dif;
            zMltpl = z / dif;
        }

        private readonly double af;
        private readonly double as_;
        private readonly double t1;
        private readonly double t2;
        private readonly double xMltpl;
        private readonly double yMltpl;
        private readonly double zMltpl;

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

            X = a * xMltpl;
            Y = a * yMltpl;
            Z = a * zMltpl;
        }
    }
}