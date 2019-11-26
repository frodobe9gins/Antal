using System;

namespace Antal.Lib
{
    public class Circle : AbstractFigure
    {
        private readonly double _radius;

        public Circle(double rarius)
        {
            _radius = rarius;
        }

        public override double Square=>Math.PI*Math.Pow(_radius,2);

    }
}
