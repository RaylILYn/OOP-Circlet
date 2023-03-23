//  Задание 2.2 [Вариант 2]
//  
//  Создать класс «Окружность», описывающий объекты – окружности на координатной плоскости.
//  Класс должен содержать указанные ниже элементы.
//    •	Закрытые поля для хранения координат центра окружности и радиуса.
//    •	Конструктор без параметров для создания окружности с центром в начале координат и единичным радиусом.
//    •	Конструктор с параметрами для создания произвольной окружности. Предусмотреть проверку на корректность введенных данных.
//    •	Свойства для доступа к полям класса (только для чтения).
//    •	Свойства для определения длины окружности.
//    •	Метод, результатом которого является true, если окружность целиком лежит в одной координатной четверти, и false в противном случае.
//    •	Метод для перемещения окружности по вертикали вниз или по горизонтали влево(в зависимости от значения соответствующего параметра) на заданную величину.
//    •	Метод для увеличения радиуса окружности на заданную величину.
//    •	Статический метод для проверки, пересекаются ли две окружности (входные параметры – объекты класса, результат true или false).

//  Разработать программу, выполняющую следующие действия:
//    •	Создает три объекта класса «Окружность» (один с помощью конструктора без параметров и два произвольных);
//    •	Выводит информацию об окружностях в виде:
//    ╔═══════╦═══════════╦═══════════╦═══════════╦═════════════════════════════════════════╗
//    ║ № п/п ║   Центр   ║   Радиус  ║   Длина   ║ Лежит ли в одной координатной плоскости ║
//    ╠═══════╬═══════════╬═══════════╬═══════════╬═════════════════════════════════════════╣
//    ║   1   ║   (0;0)   ║     1     ║    6.28   ║                   нет                   ║
//    ║   2   ║   (3;5)   ║     2     ║    12.56  ║                   да                    ║
//    ╚═══════╩═══════════╩═══════════╩═══════════╩═════════════════════════════════════════╝
//    •	Определяет, пересекаются ли какие-нибудь из данных окружностей;
//    •	Осуществляет перемещение или увеличение(по выбору пользователя) для первой окружности и выводит новую информацию о ней.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir
{
    static class Const
    {
        // ширина колонок
        public const int ONE = 7;
        public const int TWO = 11;
        public const int THREE = 11;
        public const int FOUR = 11;
        public const int FIVE = 41;
    }
    class Program
    {
        static int ShowColLeft(int COL, string str)             // Находим количество пробелов слева, печатаем их и возвращаем их количество
        {
            int spLeft = (COL - str.Length) / 2;
            Console.Write("║");
            for (int i = 0; i < spLeft; i++)
                Console.Write(" ");
            return spLeft;
        }
        static void ShowCol(int spRight, string str, int COL)   // Печатаем значение и пробелы справа
        {
            if (str.Length > COL)
                Console.Write(str.Substring(0, COL));
            else
                Console.Write(str);
            for (int i = 0; i < spRight; i++)
                Console.Write(" ");
        }
        static void ShowTable(params Circle[] circles)
        {
            int num = 1;
            string str;
            Console.WriteLine("╔═══════╦═══════════╦═══════════╦═══════════╦═════════════════════════════════════════╗");
            Console.WriteLine("║ № п/п ║   Центр   ║   Радиус  ║   Длина   ║ Лежит ли в одной координатной плоскости ║");
            Console.WriteLine("╠═══════╬═══════════╬═══════════╬═══════════╬═════════════════════════════════════════╣");
            foreach (Circle item in circles)
            {
                // печатаем первую колонку
                str = num.ToString();
                ShowCol(Const.ONE - ShowColLeft(Const.ONE, str) - str.Length, str, Const.ONE);
                num++;
                // печатаем вторую колонку
                str = "(" + item.X + ";" + item.Y + ")";
                ShowCol(Const.TWO - ShowColLeft(Const.TWO, str) - str.Length, str, Const.TWO);
                // печатаем третью колонку
                str = item.Radius.ToString();
                ShowCol(Const.THREE - ShowColLeft(Const.THREE, str) - str.Length, str, Const.THREE);
                // печатаем четвертую колонку
                str = item.lengthCircle.ToString();
                ShowCol(Const.FOUR - ShowColLeft(Const.FOUR, str) - str.Length, str, Const.FOUR);
                // печатаем пятую колонку
                if (item.circleLayInToOneQuarter())
                    str = "да";
                else
                    str = "нет";
                ShowCol(Const.FIVE - ShowColLeft(Const.FIVE, str) - str.Length, str, Const.FIVE);
                Console.WriteLine("║");
            }
            Console.WriteLine("╚═══════╩═══════════╩═══════════╩═══════════╩═════════════════════════════════════════╝");
        }

        // Чек на ввод новых данных, выбор
        static bool CheckExit()
        {
            Console.Write("\nЖелаете ввести новые данные?\n1 - да\n0 - нет\nВаш выбор: ");
            return Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
        }

        // Определяем, пересекаются ли какие-нибудь из данных окружностей 
        static void intersectionOfCircles(Circle circle1, Circle circle2, Circle circle3)
        {
            bool[] flag = new bool[] { false, false, false };
            if (flag[0] = Circle.intersectionOfCircles(circle1, circle2))
                Console.WriteLine("Окружность №1 пересекается с окружностью №2");
            if (flag[1] = Circle.intersectionOfCircles(circle2, circle3))
                Console.WriteLine("Окружность №2 пересекается с окружностью №3");
            if (flag[2] = Circle.intersectionOfCircles(circle1, circle3))
                Console.WriteLine("Окружность №1 пересекается с окружностью №3");
            if (!flag[0] && !flag[1] && !flag[2])
                Console.WriteLine("Ни одна из окружностей не пересекается");
        }

        // Создаем три объекта класса «Окружность» (один с помощью конструктора без параметров и два произвольных)
        static void Main(string[] args)
        {
            Circle circle1 = new Circle();
            Circle circle2 = new Circle(3, 5, 2d);
            Circle circle3 = new Circle(-5, 4, 3.2);
            do
            {
                // Выводим информацию об окружностях в виде таблицы
                Console.Clear();
                ShowTable(circle1, circle2, circle3);
                // Определяем, пересекаются ли какие-нибудь из данных окружностей
                intersectionOfCircles(circle1, circle2, circle3);
                // Осуществляем перемещение или увеличение(по выбору пользователя) для первой окружности и выводим новую информацию о ней.
                Console.WriteLine("\nВыберите операцию для первой окружности: ");
                Console.Write("1 - увеличить окружность\n2 - переместить вниз и(или) влево\n\nВаш выбор: ");
                int choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    Console.WriteLine("\nВведите число, на которое необходимо увеличить окружность: ");
                    Console.Write("rise = ");
                    circle1.riseRadius(Convert.ToDouble(Console.ReadLine()));
                }
                else if (choise == 2)
                {
                    Console.WriteLine("\nВведите число, на сколько нужно сместиться влево по координате X: ");
                    Console.Write("Xmove = ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nВведите число, на сколько нужно сместиться вниз по координате Y: ");
                    Console.Write("Ymove = ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    circle1.moveCircleDownOrLeft(x, y);
                }
                // Выводим информацию об окружностях в виде таблицы
                Console.Clear();
                ShowTable(circle1, circle2, circle3);
                // Определяем, пересекаются ли какие-нибудь из данных окружностей
                intersectionOfCircles(circle1, circle2, circle3);
            } while (CheckExit());
        }
    }
}