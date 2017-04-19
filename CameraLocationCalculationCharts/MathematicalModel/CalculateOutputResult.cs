﻿using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    internal class CalculateOutputResult : CalculationBase
    {
        {
            engine1 = new Engine1( input, pointCount );
            engine2 = new Engine2( input, pointCount );
            engine3 = new Engine3( input, pointCount );
            engine4 = new Engine4( input, pointCount );
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
                res.F2Min = Math.Max( res.F2Min, f2 );
                res.F3Min = Math.Max( res.F3Min, f3 );
                res.F4Min = Math.Max( res.F4Min, f4 );

                res.P1Max = Math.Max( res.P1Max, engine1.GetPower( t ) );
                res.P2Max = Math.Max( res.P2Max, engine2.GetPower( t ) );
                res.P3Max = Math.Max( res.P3Max, engine3.GetPower( t ) );
                res.P4Max = Math.Max( res.P4Max, engine4.GetPower( t ) );
            }
            return res;
        }
    }
}
