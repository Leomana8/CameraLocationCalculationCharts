using System;
using System.Windows.Forms;
using CameraLocationCalculationCharts.MathematicalModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace CameraLocationCalculationCharts
{
    public partial class Charts : Form
    {
        private const int PointCount = 100;

        public Charts()
        {
            InitializeComponent();
        }

        public void Draw< T >( InputData data ) where T : CalculationBase
        {
            var modelF = new PlotModel { Title = "Сила" };
            var engine = ( T ) Activator.CreateInstance( typeof( T ), data.ToModelData(), PointCount );
            var funcF = new FunctionSeries( engine.GetForce, 0, engine.tf, engine.DeltaT, Text );
            modelF.Axes.Add( new LinearAxis { Position = AxisPosition.Bottom, Title = "Время, с" } );
            modelF.Axes.Add( new LinearAxis { Position = AxisPosition.Left, Title = "Сила, Н" } );
            modelF.Series.Add( funcF );
            plotViewF.Model = modelF;

            engine.Reset();
            var modelN = new PlotModel { Title = "Мощность" };
            var funcN = new FunctionSeries( engine.GetPower, 0, engine.tf, engine.DeltaT, Text ) { Color = OxyColor.FromRgb( 0, 0, 250 ) };
            modelN.Axes.Add( new LinearAxis { Position = AxisPosition.Bottom, Title = "Время, с" } );
            modelN.Axes.Add( new LinearAxis { Position = AxisPosition.Left, Title = "Мощность, Вт" } );
            modelN.Series.Add( funcN );
            plotViewN.Model = modelN;
        }
    }
}