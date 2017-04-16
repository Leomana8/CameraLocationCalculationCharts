using CameraLocationCalculationCharts.MathematicalModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Windows.Forms;

namespace CameraLocationCalculationCharts
{
    public partial class Charts : Form
    {
        public Charts( InputData data, string title )
        {
            InitializeComponent();
            this.Name = title;
            var pointCount = 80;
            var myModel = new PlotModel { Title = "Силы: " + title };
            var engine1 = new Engine1( data, pointCount );
            var func = new FunctionSeries( engine1.GetForce, 0, engine1.tf, engine1.DeltaT, "Fдв1" );
            myModel.Axes.Add( new LinearAxis { Position = AxisPosition.Bottom, Title = "T", MajorStep = engine1.tf / 10 } );
            myModel.Axes.Add( new LinearAxis { Position = AxisPosition.Left, Title = "F" } );

            myModel.Series.Add( func );
            plotView1.Model = myModel;
        }
    }
}
