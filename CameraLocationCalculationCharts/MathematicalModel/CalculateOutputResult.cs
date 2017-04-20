using System;
using System.Diagnostics;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    internal class CalculateOutputResult : CalculationBase
    {
        public CalculateOutputResult( InputData input, int pointCount ) : base( input, pointCount )
        {
            engine1 = new Engine1( input, pointCount, false );
            engine2 = new Engine2( input, pointCount, false );
            engine3 = new Engine3( input, pointCount, false );
            engine4 = new Engine4( input, pointCount, false );
        }

        private readonly Engine1 engine1;
        private readonly Engine2 engine2;
        private readonly Engine3 engine3;
        private readonly Engine4 engine4;

        protected override double GetForceForCurrent( double t )
        {
            return 0;
        }

        protected override double GetPowerForCurrent( double t )
        {
            return 0;
        }

        public OutputData GetResult()
        {
            var res = new OutputData { tf = tf, S = S };
            if ( t2 < 0 )
                res.Info = "Не успеет остановиться";
            for ( double t = 0; t < tf; t += DeltaT )
            {
                var f1 = engine1.GetForce( t );
                var f2 = engine2.GetForce( t );
                var f3 = engine3.GetForce( t );
                var f4 = engine4.GetForce( t );

                res.F1Max = Math.Max( res.F1Max, f1 );
                res.F2Max = Math.Max( res.F2Max, f2 );
                res.F3Max = Math.Max( res.F3Max, f3 );
                res.F4Max = Math.Max( res.F4Max, f4 );

                res.F1Min = Math.Min( res.F1Min, f1 );
                res.F2Min = Math.Min( res.F2Min, f2 );
                res.F3Min = Math.Min( res.F3Min, f3 );
                res.F4Min = Math.Min( res.F4Min, f4 );

                res.P1Max = Math.Max( res.P1Max, Math.Abs( engine1.GetPower( t ) ) );
                res.P2Max = Math.Max( res.P2Max, Math.Abs( engine2.GetPower( t ) ) );
                res.P3Max = Math.Max( res.P3Max, Math.Abs( engine3.GetPower( t ) ) );
                res.P4Max = Math.Max( res.P4Max, Math.Abs( engine4.GetPower( t ) ) );
            }
            res.PSum = res.P1Max + res.P2Max + res.P3Max + res.P4Max;
            return res;
        }
    }
}