using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Engine1 : СalculationBase
    {
        public Engine1( InputData inputData, int pointsCount ) : base( inputData, pointsCount )
        {
        }
        protected override double GetForce()
        {
            var a = vars.R * cables.CosA + vars.N * cables.CosB + cables.CosD;
            var b = vars.O * vars.J + vars.S * vars.I;
            var c = ( g + accel.Z - vars.O * cables.CosB + vars.S * cables.CosA );
            var d = vars.R * vars.I - vars.N * vars.J + vars.L;
            var e = vars.P * vars.I - vars.M * vars.J + vars.K;
            var f = vars.P * cables.CosA + vars.M * cables.CosB + cables.CosD;
            var dif = ( a * e - f * d );
            if ( Math.Abs( dif ) <= 0.0001 )
                return inputdata.M * g / 4 * cables.CosC;
            return inputdata.M * ( a * b - c * d ) / dif;
        }
    }
}
