using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Cables
    {
        public Cables( double L1, double L2, double l1, double l2, double H )
        {
            this.L1 = L1;
            this.L2 = L2;
            this.l1 = l1;
            this.l2 = l2;
            this.H = H;
        }

        private readonly double H;
        private readonly double l1;
        private readonly double L1;
        private readonly double l2;
        private readonly double L2;
        private double currentZ;

        public double AA { get; set; }
        public double BB { get; set; }
        public double CC { get; set; }
        public double DD { get; set; }

        public double CosA => GetCos( AA );

        public double CosB => GetCos( BB );

        public double CosC => GetCos( CC );

        public double CosD => GetCos( DD );

        public double SinA => GetSin( AA );

        public double SinB => GetSin( BB );

        public double SinC => GetSin( CC );

        public double SinD => GetSin( DD );

        public void Set( Coordinates current )
        {
            AA = Math.Sqrt( MyMath.SD( l2 / 2, current.X ) + MyMath.SD( l1 / 2, current.Y ) + MyMath.SD( H, current.Z ) );
            BB = Math.Sqrt( MyMath.SD( l2 / 2, current.X ) + MyMath.SD( L1 - current.Y, l1 / 2 ) + MyMath.SD( H, current.Z ) );
            CC = Math.Sqrt( MyMath.SD( L2 - current.X, l2 / 2 ) + MyMath.SD( L1 - current.Y, l1 / 2 ) + MyMath.SD( H, current.Z ) );
            DD = Math.Sqrt( MyMath.SD( L2 - current.X, l2 / 2 ) + MyMath.SD( l1 / 2, current.Y ) + MyMath.SD( H, current.Z ) );

            currentZ = current.Z;
        }

        public double GetCos( double length )
        {
            return ( H - currentZ ) / length;
        }

        public double GetSin( double length )
        {
            return Math.Sqrt( 1 - GetCos( length ).Squared() );
        }
    }
}