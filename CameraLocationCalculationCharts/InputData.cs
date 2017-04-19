using System;
using System.ComponentModel;
using System.Globalization;
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
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        [DisplayName( "\tH" )]
        public double H { get; set; }

        [Category( StrucureConfiguration )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        [DisplayName( "\tL1" )]
        public double L1 { get; set; }

        [Category( StrucureConfiguration )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        [DisplayName( "\tL2" )]
        public double L2 { get; set; }

        [Category( StrucureConfiguration )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double l1 { get; set; }

        [Category( StrucureConfiguration )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double l2 { get; set; }

        [Category( StartCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Xs { get; set; }

        [Category( StartCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Ys { get; set; }

        [Category( StartCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Zs { get; set; }

        [Category( FinishCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Xf { get; set; }

        [Category( FinishCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Yf { get; set; }

        [Category( FinishCoordinates )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Zf { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double M { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double as_ { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double af { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Vm { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double Fn { get; set; }

        [Category( DynamicParameters )]
        [TypeConverter( typeof( CustomNumberTypeConverter ) )]
        public double k { get; set; }

        public MathematicalModel.InputData ToModelData()
        {
            return JsonConvert.DeserializeObject< MathematicalModel.InputData >( JsonConvert.SerializeObject( this ) );
        }
    }

    public sealed class CustomNumberTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
        {
            return sourceType == typeof( string );
        }

        public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
        {
            var str = value as string;
            if ( str != null )
            {
                var s = str.Replace( ".", "," );
                return double.Parse( s, culture );
            }

            return base.ConvertFrom( context, culture, value );
        }

        public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
        {
            return destinationType == typeof( string ) ? ( ( double ) value ).ToString( culture ) : base.ConvertTo( context, culture, value, destinationType );
        }
    }
}