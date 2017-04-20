using System;
using System.Diagnostics;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Engine1 : CalculationBase
    {
        public Engine1( InputData inputData, int pointsCount, bool doStepInPower = true ) : base( inputData, pointsCount, doStepInPower )
        {
        }

        protected override double GetForceForCurrent( double t )
        {
            var a = vars.R * cables.CosA + vars.N * cables.CosB + cables.CosD;
            var b = vars.O * vars.J + vars.S * vars.I;
            var c = g + accel.Z - vars.O * cables.CosB + vars.S * cables.CosA;
            var d = vars.R * vars.I - vars.N * vars.J + vars.L;
            var e = vars.P * vars.I - vars.M * vars.J + vars.K;
            var f = vars.P * cables.CosA + vars.M * cables.CosB + cables.CosD;
            var dif = a * e - f * d;
            if ( Math.Abs( dif ) <= 0.0001 )
                return inputdata.M * g / 4 * cables.CosC;
            return inputdata.M * ( a * b - c * d ) / dif;
        }

        protected override double GetPowerForCurrent( double t )
        {
            var v = ( cables.CC - prevCables.CC ) / DeltaT;
            return GetForceForCurrent( t ) * v;
        }
    }
}