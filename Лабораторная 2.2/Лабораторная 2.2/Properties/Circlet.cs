using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir
{
    class Circle
    {
        // Закрытые поля для хранения координат центра окружности и радиуса.
        private int x;
        private int y;
        private double radius;
        // Конструктор без параметров для создания окружности с центром в начале координат и единичным радиусом.
        public Circle() { x = 0; y = 0; radius = 1d; }
        // Конструктор с параметрами для создания произвольной окружности. Предусмотреть проверку на корректность введенных данных.
        public Circle(int x, int y, double radius)
        {
            this.x = x;
            this.y = y;
            try
            {
                if (radius <= 0)
                    throw new Exception("Ошибка! Радиус не может быть меньше либо равен нулю");
                this.radius = radius;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            };
        }
        // Свойства для доступа к полям класса (только для чтения).
        public int X { get => x; }
        public int Y { get => y; }
        public double Radius { get => radius; }
        // Свойства для определения длины окружности.
        public double lengthCircle { get => 2d * Math.PI * radius; }
        // Метод, результатом которого является true, если окружность целиком лежит в одной координатной четверти, и false в противном случае.
        public bool circleLayInToOneQuarter()
        {
            if (x > 0 && x - radius >= 0 && y > 0 && y - radius >= 0)        // 1-я четверть (+;+)
                return true;
            else if (x < 0 && x + radius <= 0 && y < 0 && y + radius <= 0)   // 3-я четверть (-;-)
                return true;
            else if (x < 0 && x + radius <= 0 && y > 0 && y - radius >= 0)   // 2-я четверть (-;+)
                return true;
            else if (x > 0 && x - radius >= 0 && y < 0 && y + radius <= 0)   // 4-я четверть (+;-)
                return true;
            else
                return false;
        }
        // Метод для перемещения окружности по вертикали вниз или по горизонтали влево 
        // (в зависимости от значения соответствующего параметра) на заданную величину.
        public void moveCircleDownOrLeft(int x, int y)
        {
            this.x -= Math.Abs(x);
            this.y -= Math.Abs(y);
        }
        // Метод для увеличения радиуса окружности на заданную величину.
        public void riseRadius(double value)
        {
            radius += Math.Abs(value);
        }
        // Статический метод для проверки, пересекаются ли две окружности (входные параметры – объекты класса, результат true или false).
        public static bool intersectionOfCircles(Circle c1, Circle c2)
        {
            return (Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2) < Math.Pow(c1.Radius + c2.Radius, 2));
        }
    }
}