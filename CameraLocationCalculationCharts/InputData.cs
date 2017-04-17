using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace CameraLocationCalculationCharts
{
    [Serializable]
    public class InputData
    {
        private const string StrucureConfiguration = "\t\tКонфигурация конструкции";
        private const string StartCoordinates = "\tКоординаты точек старта";
        private const string FinishCoordinates = "\tКоординаты точек финиша";
        private const string DynamicParameters = "Динамические параметры";

        [Category( StrucureConfiguration )]
        public double H { get; set; }

        [Category( StrucureConfiguration )]
        public double L1 { get; set; }

        [Category( StrucureConfiguration )]
        public double L2 { get; set; }

        [Category( StrucureConfiguration )]
        public double l1 { get; set; }

        [Category( StrucureConfiguration )]
        public double l2 { get; set; }

        [Category( StartCoordinates )]
        public double Xs { get; set; }

        [Category( StartCoordinates )]
        public double Ys { get; set; }

        [Category( StartCoordinates )]
        public double Zs { get; set; }

        [Category( FinishCoordinates )]
        public double Xf { get; set; }

        [Category( FinishCoordinates )]
        public double Yf { get; set; }

        [Category( FinishCoordinates )]
        public double Zf { get; set; }

        [Category( DynamicParameters )]
        public double M { get; set; }

        [Category( DynamicParameters )]
        public double as_ { get; set; }

        [Category( DynamicParameters )]
        public double af { get; set; }

        [Category( DynamicParameters )]
        public double Vm { get; set; }

        [Category( DynamicParameters )]
        public double Fn { get; set; }

        [Category( DynamicParameters )]
        public double k { get; set; }

        public MathematicalModel.InputData ToModelData()
        {
            return JsonConvert.DeserializeObject< MathematicalModel.InputData >( JsonConvert.SerializeObject( this ) );
        }
    }
}