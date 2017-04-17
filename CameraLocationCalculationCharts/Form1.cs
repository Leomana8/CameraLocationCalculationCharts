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
            var savedInput = JsonConvert.DeserializeObject< InputData >( Settings.Default.InputData );
            inputData = savedInput ?? new InputData();
            propertyGridInputData.SelectedObject = inputData;
        }

        private readonly InputData inputData;

        private void button1_Click( object sender, EventArgs e )
        {
            Settings.Default.InputData = JsonConvert.SerializeObject( inputData );
            Settings.Default.Save();
            var charts = new Charts { Text = button1.Text };
            charts.Draw< Engine1 >( inputData );
            charts.Show();
        }
    }
}