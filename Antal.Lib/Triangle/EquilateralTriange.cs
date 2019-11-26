namespace Antal.Lib
{
    /// <summary>
    /// Дальнейшее декорирование класса не имеет смысла
    /// </summary>
    public sealed class EquilateralTriange : Triangle
    {
        public EquilateralTriange(double a) : base(a, a, a)
        {
        }
    }
}
