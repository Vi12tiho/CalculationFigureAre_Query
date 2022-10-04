using System;

namespace FigureAreaLib
{
    public class FigureArea     // Внешним пользователям доступен перегруженный метод Calc() для вычисления: площади круга, треугольников
    {
        private const double Pi = 3.14159;
        private enum FigureType : int
        {
            /// <summary>
            /// Неизвестный тип фугуры
            /// </summary>
            Unknow = 0,
            /// <summary>
            /// Круг
            /// </summary>
            Circle = 1,
            /// <summary>
            /// Равносторонний треугольник
            /// </summary>
            EquilateralTriangle = 2,
            /// <summary>
            /// Равнобедренный
            /// </summary>
            IsoscelesTriangle = 3,
            /// <summary>
            /// Разносторонний треугольник
            /// </summary>
            ScaleneTriangle = 4,
            /// <summary>
            /// Прямоугольный треугольник
            /// </summary>
            RightTriangle = 5,
        }

        /// <summary>
        /// Проверка на существование треугольника
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        private static bool CheckTriangle(double ab, double bc, double ca)
        {
            bool result = false;

            if (ab > 0 && bc > 0 && ca > 0)     // Проверка на корректность поступивших данных
            {
                if (ab + bc > ca)
                {
                    if (bc + ca > ab)
                    {
                        if (ab + ca > bc)
                        {
                            result = true;      // Треугольник реально существует
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Метод определяет тип фигуры
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        private static int DefineFigure(double ab, double bc, double ca)
        {
            int type;

            //Triangle
            if (ab == bc && bc == ca)
            {
                type = (int)FigureType.EquilateralTriangle;
                Console.WriteLine("equil");
            }
            else if (Math.Pow(ca, 2) == Math.Pow(ab, 2) + Math.Pow(bc, 2))     // Теорема Пифагора
            {
                type = (int)FigureType.RightTriangle;
                Console.WriteLine("right");
            }
            else if (ab == bc || ab == ca || bc == ca)
            {
                type = (int)FigureType.IsoscelesTriangle;
                Console.WriteLine("isol");
            }
            else
            {
                type = (int)FigureType.ScaleneTriangle;
                Console.WriteLine("scale");
            }

            return type;
        }
        /// <summary>
        /// Метод возвращает площадь круга
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double Calc(double radius)
        {
            if (radius <= 0)
            {
                //throw new ArgumentException("Method Calc() need params > 0");
                return double.NaN;
            }
            else
            {
                return Pi * radius * radius;
            }

        }

        /// <summary>
        /// Метод возвращает площадь треугольника
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        public static double Calc(double ab, double bc, double ca)
        {
            double result = double.NaN;

            double side1, side2, hyp;

            if (CheckTriangle(ab, bc, ca))
            {
                // Проверка и сортировка поступивших параметров функции для прямоугольного треугольника, в случае когда гипотенуза может быть подана не третьей позицией.
                if (ca > ab && ca > bc)
                {
                    hyp = ca;
                    side1 = ab;
                    side2 = bc;
                }
                else if (ab > ca && ab > bc)
                {
                    hyp = ab;
                    side1 = bc;
                    side2 = ca;
                }
                else
                {
                    hyp = bc;
                    side1 = ab;
                    side2 = ca;
                }

                switch (DefineFigure(side1, side2, hyp))
                {
                    case (int)FigureType.EquilateralTriangle:
                        result = (Math.Pow(ab, 2) * Math.Sqrt(3)) / 4;
                        break;
                    case (int)FigureType.IsoscelesTriangle:
                    case (int)FigureType.ScaleneTriangle:
                        double p = (ab + bc + ca) / 2;      //Полупериметр
                        result = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));     //Универсальная формула подсчёта площади треугольника любого типа
                        break;
                    case (int)FigureType.RightTriangle:
                        result = (side1 * side2) / 2;
                        break;
                }
            }

            return result;
        }
    }
}