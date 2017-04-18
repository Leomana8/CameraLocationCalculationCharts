namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Engine4 : CalculationBase
    {
        public Engine4( InputData inputData, int pointsCount ) : base( inputData, pointsCount )
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
            return -inputdata.Fn + inputdata.k * f1 * vars.M + inputdata.k * f2 * vars.N - inputdata.k * vars.M * vars.O;
        }

        protected override double GetPowerForCurrent( double t )
        {
            var v = ( ( cables.BB - prevCables.BB ) / DeltaT + ( cables.DD - prevCables.DD ) / DeltaT ) / inputdata.k;
            return GetForceForCurrent( t ) * v;
        }
    }
}