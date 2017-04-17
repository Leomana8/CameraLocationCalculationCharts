using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class AuxiliaryVariables
    {
        public AuxiliaryVariables( double L1, double L2, double l1, double l2 )
        {
            this.L1 = L1;
            this.L2 = L2;
            this.l1 = l1;
            this.l2 = l2;
        }

        private readonly double l1;
        private readonly double L1;
        private readonly double l2;
        private readonly double L2;
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double D { get; private set; }
        public double E { get; private set; }
        public double F { get; private set; }
        public double G { get; private set; }
        public double H { get; private set; }
        public double I { get; private set; }
        public double J { get; private set; }
        public double K { get; private set; }
        public double L { get; private set; }

        public double M { get; private set; }
        public double N { get; private set; }
        public double O { get; private set; }
        public double P { get; private set; }
        public double R { get; private set; }
        public double S { get; private set; }

        public void Set( Cables cables, Points points, Acceleration a )
        {
            A = cables.SinA * DivSqrt( points.A.X, points.A.X.Squared() + points.A.Y.Squared() );
            B = cables.SinB * DivSqrt( points.B.X, points.B.X.Squared() + MyMath.SD( L1, points.B.Y ) );
            C = cables.SinC * DivSqrt( L2 - points.C.X, MyMath.SD( L2, points.C.X ) + MyMath.SD( L1, points.C.Y ) );
            D = cables.SinD * DivSqrt( L2 - points.D.X, points.D.Y.Squared() + MyMath.SD( L2, points.D.X ) );

            E = cables.SinA * DivSqrt( points.A.Y, points.A.X.Squared() + points.A.Y.Squared() );
            F = cables.SinB * DivSqrt( points.B.Y, points.B.X.Squared() + MyMath.SD( L1, points.B.Y ) );
            G = cables.SinC * DivSqrt( L1 - points.C.Y, MyMath.SD( L2, points.C.X ) + MyMath.SD( L1, points.C.Y ) );
            H = cables.SinD * DivSqrt( points.D.Y, points.D.Y.Squared() + MyMath.SD( L2, points.D.X ) );

            I = cables.SinA * DivSqrt( points.A.X * l1 - points.A.Y * l2, points.A.X.Squared() + points.A.Y.Squared() ) * 0.5;
            J = cables.SinB * DivSqrt( points.B.X * l1 - points.B.Y * l2, points.B.X.Squared() + MyMath.SD( L1, points.B.Y ) ) * 0.5;
            var k1 = ( L1 - points.C.Y ) * l2 - ( L2 - points.C.X ) * l1;
            K = cables.SinC * DivSqrt( k1, MyMath.SD( L2, points.C.X ) + MyMath.SD( L1, points.C.Y ) ) * 0.5;
            var l = ( L2 - points.D.X ) * l1 + points.D.Y * l2;
            L = cables.SinD * DivSqrt( l, points.D.Y.Squared() + MyMath.SD( L2, points.D.X ) ) * 0.5;

            var div = B * E + A * F;
            M = ( C * E - A * G ) / div;
            N = ( D * E + A * H ) / div;
            O = ( a.X * E - a.Y * A ) / div;
            P = ( C * F + G * B ) / div;
            R = ( D * F - H * B ) / div;
            S = ( a.X * F + a.Y * B ) / div;
        }

        private static double DivSqrt( double a, double b )
        {
            return a / Math.Sqrt( b );
        }
    }
}