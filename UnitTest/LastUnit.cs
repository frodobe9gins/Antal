using Antal.Lib.Figure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    /// <summary>
    /// наверное самая правильная реализация с помощью тз и самая непонятная
    /// для будущего пользователя прогарммиста.
    /// С другой стороны сама реализация как и сами фигуры скрыты
    /// фигуры вводить легко - достаточно реализовать класс в специальном неймспейсе 
    /// и определить необходимые конструкторы. Количество параметров и типы данных 
    /// в конструкторе напрямую связаны с количеством параметров для функци FigureMathFactory.
    /// Если параметров по каким-то причинам не хватает, 
    /// например как тут - реализация площади треугольника по углу и двум сторонам уже занята 
    /// под реализацию треугольника по трем сторонам, то можно ввести еще одну фигуру.
    /// К сожалению это является платой за универсальность
    /// </summary>
    [TestClass]
    public class LastUnit
    {

        /// <summary>
        /// я специально отулючил реализацию чтобы было проще проверить, 
        /// как происходит навигация к подключаемым фигурам
        /// </summary>
        [TestMethod]
        public void TestTriangle()
        {
            Assert.AreEqual(FigureMathFactory.GetSquere("Triangle",  0), -1);
            Assert.AreEqual(FigureMathFactory.GetSquere("Triangle", 0, 0), -2);
            Assert.AreEqual(FigureMathFactory.GetSquere("Triangle", 0, 0,0), -3);
            Assert.IsNull(FigureMathFactory.GetSquere("Triangle", 0, 0, 0, 0));
        }

        /// <summary>
        /// Тестируем круг. Так же реализация отключена, чтобы не нужно было считать 
        /// реальную площадь по радиусу
        /// </summary>
        [TestMethod]
        public void TestCircle()
        {
            Assert.AreEqual(FigureMathFactory.GetSquere("Circle", 0), -1);
            Assert.IsNull(FigureMathFactory.GetSquere("Circle", 0,0));
        }


        /// <summary>
        /// Ну и вишенка на торте для пользователей библиотеки - можно получить перечень фигур
        /// Не проблема рефлексий тут же получить описание параметров для создания фигуры, 
        /// как минимум названия параметров и их количество в конструкторах фигур
        /// Если добавить аттрибуты, то можно так же дописать и дополнительное расширенное
        /// описание самих фигур и их конструкторов
        /// </summary>
        [TestMethod]
        public void TestTypes()
        {
            var figureTypes=FigureMathFactory.Figures.ToArray();
            IStructuralEquatable equatable = new string[] { "Circle", "Triangle" };

            Assert.IsTrue(
                equatable.Equals(figureTypes, EqualityComparer<string>.Default));
        }


    }
}