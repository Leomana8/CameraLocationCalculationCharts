namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Engine3 : CalculationBase
    {
        public Engine3( InputData inputData, int pointsCount ) : base( inputData, pointsCount )
        {
            engine1 = new Engine1( inputData, pointsCount );
            engine2 = new Engine2( inputData, pointsCount );
        }

        private readonly Engine1 engine1;
        private readonly Engine2 engine2;

        protected override double GetForceForCurrent( double t )
        {
            var f1 = engine1.GetForce( t );
            var f2 = engine2.GetForce( t );
            return -inputdata.Fn + inputdata.k * f1 * vars.P + inputdata.k * f2 * vars.R - inputdata.k * vars.M * vars.S;
        }

        protected override double GetPowerForCurrent( double t )
        {
            var v = ( ( cables.AA - prevCables.AA ) / DeltaT + ( cables.CC - prevCables.CC ) / DeltaT ) / inputdata.k;
            return GetForceForCurrent( t ) * v;
        }
    }
}