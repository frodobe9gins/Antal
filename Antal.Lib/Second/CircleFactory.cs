namespace Antal.Lib.Second
{
    public class CircleFactory : FigureFactorory
    {
        private readonly double _radius;

        public CircleFactory(double radius)
        {
            _radius=radius;
        }

        public override IFigure Create()
        {
            return new Circle(_radius);
        }

    }

}
