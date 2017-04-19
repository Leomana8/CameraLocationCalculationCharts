namespace CameraLocationCalculationCharts.MathematicalModel
{
    public class Points
    {
        public Points( double l1, double l2 )
        {
            this.l1 = l1;
            this.l2 = l2;
            A = new Coordinates();
            B = new Coordinates();
            C = new Coordinates();
            D = new Coordinates();
        }

        private readonly double l1;
        private readonly double l2;
        public Coordinates A { get; set; }
        public Coordinates B { get; set; }
        public Coordinates C { get; set; }
        public Coordinates D { get; set; }

        public void Set( Coordinates current )
        {
            A.X = current.X - l2 / 2;
            A.Y = current.Y - l1 / 2;
            A.Z = current.Z;

            B.X = current.X - l2 / 2;
            B.Y = current.Y + l1 / 2;
            B.Z = current.Z;

            C.X = current.X + l2 / 2;
            C.Y = current.Y + l1 / 2;
            C.Z = current.Z;

            D.X = current.X + l2 / 2;
            D.Y = current.Y - l1 / 2;
            D.Z = current.Z;
        }
    }
}