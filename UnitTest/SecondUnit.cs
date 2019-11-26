using Antal.Lib;
using Antal.Lib.Second;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    /// <summary>
    /// Тестируем фигуры созднанные при помощи фабрики
    /// треугольник, круг 
    /// </summary>
    [TestClass]
    public class SecondUnit
    {

        [TestMethod]
        public void TestTriangle()
        {
            IFigureFactorory figureFactory = new TriangleFactory(3, 4, 5);
            IFigure figure = figureFactory.Create();
            Assert.AreEqual(Math.Round(figure.Square), 6);
        }
        
        [TestMethod]
        public void TestCircle()
        {
            IFigureFactorory figureFactory = new CircleFactory(1);
            IFigure figure = figureFactory.Create();
            Assert.AreEqual(figure.Square, Math.PI);
        }
    }
}