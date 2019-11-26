namespace Antal.Lib.First
{
    public class Figure
    {
        private IFigure _figure;
        public Figure(IFigure figure)
        {
            _figure = figure;
        }

        public double GetSquare()
        {
            return _figure.Square;
        }
    }
}
