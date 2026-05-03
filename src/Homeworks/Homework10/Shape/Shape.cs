using System.Drawing;

namespace Task
{
    public abstract class Shape
    {
        public abstract void Show();
        public abstract double Area();
        public abstract string Save();
        public abstract void Load(string data);
    }

    public class Triangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }

        public Triangle()
        {
            Console.WriteLine("Введіть довжину трикунтника ->");
            width = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть ширину трикунтика ->");
            length = double.Parse(Console.ReadLine());
        }

        public Triangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override void Show()
        {
            Console.WriteLine("Довжина: {0}, Ширина: {1}", width, length);
        }

        public override double Area()
        {
            double result = (length * width) / 2;
            return result;
        }

        public override string Save()
        {
            return "";
        }

        public override void Load(string data)
        {
            
        }
    }

    public class Reactangle : Shape
    {
        public double length { set; get; }
        public double width { set; get; }

        public Reactangle()
        {
            Console.WriteLine("Введіть довжину прямокутника ->");
            width = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть ширину прямокутника ->");
            length = double.Parse(Console.ReadLine());
        }

        public Reactangle(double lenght, double widht)
        {
            this.length = lenght;
            this.width = widht;
        }

        public override void Show()
        {
            Console.WriteLine("Ширина: {0}, Довжина{1}", width, length);
        }

        public override double Area()
        {
            double result = length * width;
            return result;
        }

        public override string Save()
        {
            return "";
        }

        public override void Load(string data)
        {
            
        }
    }

    public class Circle : Shape
    {
        public double radius { set; get; }

        public Circle()
        {
            Console.WriteLine("Введіть радіус кола ->");
            radius = double.Parse(Console.ReadLine());
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override void Show()
        {
            Console.WriteLine("Радіус кола: {0}", radius);
        }

        public override double Area()
        {
            double result = Math.PI * (radius * radius);
            return result;
        }

        public override string Save()
        {
            return "";
        }

        public override void Load(string data)
        {
            
        }
    }
}
