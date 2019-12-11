using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


namespace Antal.Lib.Figure
{
    /// <summary>
    /// фабрика фигур сиглтон
    /// </summary>
    class FigureFactory
    {
        private static FigureFactory _factory = null;
        private static Dictionary<string, Type> _figuresTypes = null;

        /// <summary>
        /// читаем рефлексией неймспейс и создаем перечень реализаций фигур 
        /// </summary>
        private FigureFactory()
        {
            _figuresTypes = new Dictionary<string, Type>();
            Assembly asm = Assembly.GetExecutingAssembly();
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == "Antal.Lib.Figure.Types"))
            {
                _figuresTypes.Add(t.Name, t);
            }
        }

        /// <summary>
        /// Синглтон нужен чтобы наполить перечень типов фигур
        /// </summary>
        /// <returns></returns>
        public static FigureFactory CreateInstance()
        {
            if (_factory == null)
            {
                _factory = new FigureFactory();
            }
            return _factory;
        }

        /// <summary>
        /// пробуем вытащить реализацию из перечня типов фигур
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IFigure GetFigure(string typeName, double[] p)
        {
            if (_figuresTypes.TryGetValue(typeName, out Type type))
            {
                try
                {
                    return CreateFigure(type, p);
                }
                catch (Exception)
                {
                    ///тут можно было бы как-то покрасивее, но хочется оставить возможность для логирования
                }
            }
            return null;
        }


        public IEnumerable<string> GetTypes()
        {
            return _figuresTypes.Keys;
        }


        /// <summary>
        /// дорогостоящая операция возможно лучше заменить активатор на invoke функции, создающей класс
        /// прямо в фигуре.
        /// </summary>
        /// <param name="T"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static IFigure CreateFigure(Type T, params double[] p)
        {
            return (IFigure)Activator.CreateInstance(T, args: p.Select(x => (object)x).ToArray());
        }        
    }
}
