using System;

namespace Antal.Lib
{


    public class Triangle : AbstractFigure
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;


        public Triangle(double a,double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public override double Square
        {
            get
            {
                double p = (_a + _b + _c) / 2;
                return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }
    }
}
