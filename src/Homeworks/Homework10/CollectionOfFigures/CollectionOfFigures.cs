using System.Drawing;

namespace Task
{
    public class CollectionOfFigures
    {
        public List<Shape> shapes { get; set; } = new List<Shape>();

        public void AddShapes()
        {
            Console.WriteLine("Яку фігуру добавити треба вам?");
            Console.WriteLine("1. Трикунтник, 2. Прямокутник, 3. Коло");
            int Selenct = int.Parse(Console.ReadLine());
            switch (Selenct)
            {
                case 1:
                    shapes.Add(new Triangle());
                    break;
                case 2:
                    shapes.Add(new Reactangle());
                    break;
                case 3:
                    shapes.Add(new Circle());
                    break;
                default:
                    Console.WriteLine("Не вірний вибір номера");
                    break;
            }
        }

        public void DeleteShape()
        {
            Print();
            Console.WriteLine("Яку фігуру терба видалити?");
            int select = int.Parse(Console.ReadLine());
            if (select > shapes.Count || select < 0)
            {
                Console.WriteLine("Число не вірно ");
                return;
            }
            else
            {
                shapes.RemoveAt(select);
                Console.WriteLine("Фігуру успішно видалено");
            }
        }

        public void Print()
        {
            shapes.ForEach(s => s.Show());
        }
        
        public void PrintFigure()
        {
            Console.WriteLine("Які фігури вам треба вивести? 1. Трикунтник 2. Прямокутник 3. Коло ->");
            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    foreach (var shape in shapes)
                    {
                        if (shape is Triangle)
                        {
                            shape.Show();
                        }
                    }
                    break;
                case 2:
                    foreach (var shape in shapes)
                    {
                        if (shape is Reactangle)
                        {
                            shape.Show();
                        }
                    }
                    break;
                case 3:
                    foreach (var shape in shapes)
                    {
                        if (shape is Circle)
                        {
                            shape.Show();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Помилка вибору");
                    break;
            }
        }

        public void AreaFigures()
        {
            double ResultArea = 0;
            shapes.ForEach(s => ResultArea += s.Area());
            Console.WriteLine("Площя всіх фігур: {0}", ResultArea);
        }

        public void FigureArea()
        {
            Console.WriteLine("Які фігури вам треба їх площю? 1. Трикунтник 2. Прямокутник 3. Коло ->");
            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    foreach (var shape in shapes)
                    {
                        if (shape is Triangle)
                        {
                            shape.Area();
                        }
                    }
                    break;
                case 2:
                    foreach (var shape in shapes)
                    {
                        if (shape is Reactangle)
                        {
                            shape.Area();
                        }
                    }
                    break;
                case 3:
                    foreach (var shape in shapes)
                    {
                        if (shape is Circle)
                        {
                            shape.Area();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Помилка вибору");
                    break;
            }
            }

        public void Save()
        {
            string saveFile = "save.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                { 
                        foreach (var shape in shapes)
                        {
                            if (shape is Circle c)
                                sw.WriteLine($"Circle;{c.radius}");
                            else if (shape is Reactangle r)
                                sw.WriteLine($"Rectangle;{r.width};{r.length}");
                            else if (shape is Triangle t)
                                sw.WriteLine($"Triangle;{t.width};{t.length}");
                        }
                }
                Console.WriteLine("Дані успішно збережені");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Load()
        {
            string saveFile = "save.txt";
            if (!File.Exists(saveFile)) return;

            try
            {
                using (StreamReader sr = new StreamReader(saveFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string type = parts[0];

                        if (type == "Circle")
                        {
                            double r = double.Parse(parts[1]);
                            shapes.Add(new Circle(r));
                        }
                        else if (type == "Rectangle")
                        {
                            double w = double.Parse(parts[1]);
                            double h = double.Parse(parts[2]);
                            shapes.Add(new Reactangle(w, h));
                        }
                        else if (type == "Triangle")
                        {
                            double b = double.Parse(parts[1]);
                            double h = double.Parse(parts[2]);
                            shapes.Add(new Triangle(b, h));
                        }
                    }
                }
                Console.WriteLine("Дані успішно завантажені!");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
