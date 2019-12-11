namespace Antal.Lib.Figure
{
    public interface IFigure
    {
        double Square { get;  }
    }

   abstract class BaseFigure: IFigure
    {
        public double Square { get; protected set; }
    }
}
