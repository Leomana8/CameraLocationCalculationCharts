using System.ComponentModel;

namespace CameraLocationCalculationCharts.MathematicalModel
{
    class InputData
    {
        const string StrucureConfiguration = "\t\tКонфигурация конструкции";
        const string StartCoordinates = "\tКоординаты точек старта";
        const string FinishCoordinates = "\tКоординаты точек финиша";
        const string DynamicParameters = "Динамические параметры";

        [Category(StrucureConfiguration)]
        public decimal H { get; set; }
        [Category(StrucureConfiguration)]
        public decimal L1 { get; set; }
        [Category(StrucureConfiguration)]
        public decimal L2 { get; set; }
        [Category(StrucureConfiguration)]
        public decimal l1 { get; set; }
        [Category(StrucureConfiguration)]
        public decimal l2 { get; set; }

        [Category(StartCoordinates)]
        public decimal Xs { get; set; }
        [Category(StartCoordinates)]
        public decimal Ys { get; set; }
        [Category(StartCoordinates)]
        public decimal Zs { get; set; }

        [Category(FinishCoordinates)]
        public decimal Xf { get; set; }
        [Category(FinishCoordinates)]
        public decimal Yf { get; set; }
        [Category(FinishCoordinates)]
        public decimal Zf { get; set; }

        [Category(DynamicParameters)]
        public decimal M { get; set; }
        [Category(DynamicParameters)]
        public decimal as_ { get; set; }
        [Category(DynamicParameters)]
        public decimal af { get; set; }
        [Category(DynamicParameters)]
        public decimal Vm { get; set; }
        [Category(DynamicParameters)]
        public decimal Fn { get; set; }
        [Category(DynamicParameters)]
        public decimal k { get; set; }

    }
}
