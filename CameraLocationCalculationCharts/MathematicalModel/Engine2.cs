using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Engine2 : CalculationBase
    {
        public Engine2( InputData inputData, int pointsCount, bool doStepInPower = true ) : base( inputData, pointsCount, doStepInPower )
        {
        }

        protected override double GetForceForCurrent( double t )
        {
            var a = g + accel.Z - vars.O * cables.CosB + vars.S * cables.CosA;
            var b = vars.P * vars.I - vars.M * vars.J + vars.K;
            var c = vars.P * cables.CosA + vars.M * cables.CosB + cables.CosD;
            var d = vars.O * vars.J + vars.S * vars.I;
            var e = vars.R * cables.CosA + vars.N * cables.CosB + cables.CosD;
            var f = vars.R * vars.I - vars.N * vars.J + vars.L;

            var dif = e * b - c * f;
            if ( Math.Abs( dif ) <= 0.0001 )
                return inputdata.M * g / 4 * cables.CosD;
            return inputdata.M * ( a * b - c * d ) / dif;
        }

        protected override double GetPowerForCurrent( double t )
        {
            var v = ( cables.DD - prevCables.DD ) / DeltaT;
            return GetForceForCurrent( t ) * v;
        }
    }
}