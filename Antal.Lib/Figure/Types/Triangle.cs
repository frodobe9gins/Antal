using System;

namespace Antal.Lib.Figure.Types
{
    class Triangle:BaseFigure
    {
        /// <summary>
        /// Равносторонний треугольник
        /// </summary>
        /// <param name="a"></param>
        public Triangle(double a)
        {
            Square = -1;
            //Square = Math.Pow(a, 2) * Math.Sqrt(3) / 4;
        }

        public Triangle(double a, double h)
        {
            Square = -2;
        }

        /// <summary>
        /// поиск площади по трем сторонам
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(double a, double b, double c)
        {
            Square = -3;
            //var p = (a + b + c) / 2;
            //Square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

    }

}
