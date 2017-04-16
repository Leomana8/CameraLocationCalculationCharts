using CameraLocationCalculationCharts.MathematicalModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CameraLocationCalculationCharts
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var savedInput = JsonConvert.DeserializeObject<InputData>( Properties.Settings.Default.InputData );
            inputData = savedInput ?? new InputData();
            this.propertyGridInputData.SelectedObject = inputData;
        }

        InputData inputData;

        private void button1_Click( object sender, EventArgs e )
        {
            Properties.Settings.Default.InputData = JsonConvert.SerializeObject( inputData );
            Properties.Settings.Default.Save();
            new Charts( inputData, button1.Text ).Show();
        }
    }
}
