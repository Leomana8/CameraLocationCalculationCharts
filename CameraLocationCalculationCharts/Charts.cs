using System.Windows.Forms;
using CameraLocationCalculationCharts.MathematicalModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace CameraLocationCalculationCharts
{
    public partial class Charts : Form
    {
        public Charts( InputData data, string title )
        {
            InitializeComponent();
            Name = title;
            const int pointCount = 80;
            var myModel = new PlotModel { Title = "Силы: " + title };
            var engine1 = new Engine1( data.ToModelData(), pointCount );
            var func = new FunctionSeries( engine1.GetForce, 0, engine1.tf, engine1.DeltaT, title );
            myModel.Axes.Add( new LinearAxis { Position = AxisPosition.Bottom, Title = "Время, с" } );
            myModel.Axes.Add( new LinearAxis { Position = AxisPosition.Left, Title = "Сила, Н" } );
            myModel.Series.Add( func );
            plotViewF.Model = myModel;
        }
    }
}