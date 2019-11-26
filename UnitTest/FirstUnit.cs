using Antal.Lib;
using Antal.Lib.First;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    /// <summary>
    /// Тестируем фигуры созднанные при помощи абстрактной фабрики
    /// треугольник, круг и равносторонний треугольник
    /// </summary>
    [TestClass]
    public class FirstUnit
    {

        [TestMethod]
        public void TestTriangle()
        {
            var triangle = new Figure(new Triangle(3, 4, 5));
            Assert.AreEqual(Math.Round(triangle.GetSquare()), 6);
        }

        /// <summary>
        /// тест декорированного треугольника - равносторонний
        /// </summary>
        [TestMethod]
        public void TestEquilateralTriange()
        {
            var triangle = new Figure(new EquilateralTriange(5));
            Assert.AreEqual(Math.Round(triangle.GetSquare()), 11);
        }

        [TestMethod]
        public void TestCircle()
        {
            var circle = new Figure(new Circle(1));
            Assert.AreEqual(circle.GetSquare(), Math.PI);
        }
    }
}