using System;
using System.Windows.Forms;
using CameraLocationCalculationCharts.MathematicalModel;
using CameraLocationCalculationCharts.Properties;
using Newtonsoft.Json;

namespace CameraLocationCalculationCharts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                var savedInput = JsonConvert.DeserializeObject< InputData >( Settings.Default.InputData );
                inputData = savedInput ?? new InputData();
            }
            catch ( Exception )
            {
                inputData = new InputData();
            }
            propertyGridInputData.SelectedObject = inputData;
        }

        private readonly InputData inputData;

        private void CreateCharts< T >( string text ) where T : CalculationBase
        {
            Settings.Default.InputData = JsonConvert.SerializeObject( inputData );
            Settings.Default.Save();
            var charts = new Charts { Text = text };
            charts.Draw< T >( inputData );
            charts.Show();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            CreateCharts< Engine1 >( button1.Text );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            CreateCharts< Engine2 >( button2.Text );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            CreateCharts< Engine3 >( button3.Text );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            CreateCharts< Engine4 >( button4.Text );
        }
    }
}