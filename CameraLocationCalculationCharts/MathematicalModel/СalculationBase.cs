using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public abstract class СalculationBase
    {
        protected const double g = 9.8;
        protected InputData inputdata;

        public double tf { get; private set; }
        public double DeltaT { get; private set; }
        protected double S;
        protected double t1;
        protected double t2;
        protected double t3;
        protected Coordinates deltaCoord;

        protected Coordinates start;
        protected Coordinates finish;
        protected Coordinates current;

        protected Acceleration accel;
        protected Points points;
        protected Cables cables;
        protected AuxiliaryVariables vars;

        protected double lastForce;


        public СalculationBase( InputData inputdata, int pointsCount )
        {
            this.inputdata = inputdata;
            if ( inputdata.af > 0 )
                inputdata.af = -inputdata.af;

            S = Math.Sqrt( MyMath.SD( inputdata.Xf, inputdata.Xs ) + MyMath.SD( inputdata.Yf, inputdata.Ys ) + MyMath.SD( inputdata.Zf, inputdata.Zs ) );
            tf = S / inputdata.Vm + inputdata.Vm / ( 2 * inputdata.as_ ) + inputdata.Vm / ( 2 * inputdata.af );
            DeltaT = tf / pointsCount;
           
            t1 = inputdata.Vm / inputdata.as_;
            t2 = S / inputdata.Vm + 3 * inputdata.Vm / 2 * inputdata.af - inputdata.Vm / 2 * inputdata.as_;
            t3 = -inputdata.Vm / inputdata.af;

            start = new Coordinates( inputdata.Xs, inputdata.Ys, inputdata.Zs );
            finish = new Coordinates( inputdata.Xf, inputdata.Yf, inputdata.Zf );
            deltaCoord = new Coordinates() { X = ( finish.X - start.X ) / pointsCount, Y = ( finish.Y - start.Y ) / pointsCount, Z = ( finish.Z - start.Z ) / pointsCount };

            cables = new Cables( inputdata.L1, inputdata.L2, inputdata.l1, inputdata.l2, inputdata.H );
            accel = new Acceleration( start, finish, t1, t2, t3, inputdata.af );
            points = new Points( inputdata.l1, inputdata.l2 );
            vars = new AuxiliaryVariables( inputdata.L1, inputdata.L2, inputdata.l1, inputdata.l2 );
        }

        public double GetForce( double t )
        {
            NextPosition();
            points.Set( current );
            accel.Set( t );
            cables.Set( current );
            vars.Set( cables, points, accel );
            return GetForce();
        }

        protected abstract double GetForce();


        private void NextPosition()
        {
            if ( current == null )
            {
                current = new Coordinates( start.X, start.Y, start.Z );
                return;
            }
            current.X = current.X + deltaCoord.X;
            current.Y = current.Y + deltaCoord.Y;
            current.Z = current.Z + deltaCoord.Z;
        }
    }
}
