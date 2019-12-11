using System.Collections.Generic;

namespace Antal.Lib.Figure
{
    public static class FigureMathFactory
    {

        /// <summary>
        /// Получить площадь произвольной фигуры
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        /// <param name="p">перечень параметров</param>
        /// <returns>Если фигура не найдена, то NULL</returns>
        public static double? GetSquere(string type, params double[] p)
        {
           return FigureFactory.GetFigure(type, p)?.Square;
        }

        /// <summary>
        /// Не уверен что это хорошо, но еще один синглтон делать неохота
        /// </summary>
        /// <returns></returns>
        private static FigureFactory FigureFactory =>FigureFactory.CreateInstance();


        /// <summary>
        /// Получить названия фигур
        /// </summary>
        public static IEnumerable<string> Figures=> FigureFactory.GetTypes();


    }
}
