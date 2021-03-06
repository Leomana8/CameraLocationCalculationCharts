﻿using System;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    public abstract class CalculationBase
    {
        protected const double g = 9.8;

        public CalculationBase( InputData inputdata, int pointsCount, bool doStepInPower = true )
        {
            this.inputdata = inputdata;
            this.doStepInPower = doStepInPower;
            if ( inputdata.af > 0 )
                inputdata.af = -inputdata.af;

            S = Math.Sqrt( MyMath.SD( inputdata.Xf, inputdata.Xs ) + MyMath.SD( inputdata.Yf, inputdata.Ys ) + MyMath.SD( inputdata.Zf, inputdata.Zs ) );

            t1 = inputdata.Vm / inputdata.as_;
            t2 = S / inputdata.Vm - inputdata.Vm / ( 2 * inputdata.as_ ) + inputdata.Vm / ( 2 * inputdata.af );
            t3 = -inputdata.Vm / inputdata.af;
            tf = t1 + t2 + t3;
            DeltaT = tf / pointsCount;

            start = new Coordinates( inputdata.Xs, inputdata.Ys, inputdata.Zs );
            finish = new Coordinates( inputdata.Xf, inputdata.Yf, inputdata.Zf );
            deltaCoord = new Coordinates { X = ( finish.X - start.X ) / pointsCount, Y = ( finish.Y - start.Y ) / pointsCount, Z = ( finish.Z - start.Z ) / pointsCount };

            Reset();
        }

        private readonly bool doStepInPower;

        protected Acceleration accel;
        protected Cables cables;
        protected Coordinates current;
        protected Coordinates deltaCoord;
        protected Coordinates finish;
        protected InputData inputdata;

        protected double lastForce;
        protected Points points;
        protected Cables prevCables;
        protected double S;

        protected Coordinates start;
        protected double t1;
        protected double t2;
        protected double t3;
        protected AuxiliaryVariables vars;

        public double tf { get; }
        public double DeltaT { get; private set; }

        public void Reset()
        {
            current = null;
            cables = new Cables( inputdata.L1, inputdata.L2, inputdata.l1, inputdata.l2, inputdata.H );
            accel = new Acceleration( start, finish, t1, t2, inputdata.as_, inputdata.af );
            points = new Points( inputdata.l1, inputdata.l2 );
            vars = new AuxiliaryVariables( inputdata.L1, inputdata.L2, inputdata.l1, inputdata.l2 );
            prevCables = null;
        }

        public double GetForce( double t )
        {
            NextPosition( t );
            return GetForceForCurrent( t );
        }

        protected abstract double GetForceForCurrent( double t );

        private void NextPosition( double t )
        {
            if ( current == null )
            {
                current = new Coordinates( start.X, start.Y, start.Z );
            }
            else
            {
                current.X = current.X + deltaCoord.X;
                current.Y = current.Y + deltaCoord.Y;
                current.Z = current.Z + deltaCoord.Z;
            }

            points.Set( current );
            accel.Set( t );
            cables.Set( current );
            vars.Set( cables, points, accel );
        }

        public double GetPower( double t )
        {
            if ( doStepInPower )
                NextPosition( t );
            var power = prevCables == null ? 0 : GetPowerForCurrent( t );
            prevCables = cables.Copy();
            return power;
        }

        protected abstract double GetPowerForCurrent( double t );
    }
}