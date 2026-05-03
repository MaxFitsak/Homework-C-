using System.Diagnostics;
using System.Reflection.Metadata;

namespace Task
{
    public class CollectionOfFigures
    {
        Shape[] shapes;

        public void AddShapes()
        {
            Console.WriteLine("Яку фігуру добавити треба вам?");
            Console.WriteLine("1. Трикунтник, 2. Прямокутник, 3. Коло");
            int Selenct = int.Parse(Console.ReadLine());
            switch (Selenct)
            {
                case 1:
                    shapes.Append(new Triangle());
                    break;
                case 2:
                    shapes.Append(new Reactangle());
                    break;
                case 3:
                    shapes.Append(new Circle());
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
            if (select > shapes.Length || select < 0)
            {
                Console.WriteLine("Число не вірно ");
                return;
            }
            else
            {
                Shape[] newShapes = new Shape[shapes.Length -1];
                Array.Copy(shapes, 0, newShapes, 0, select);
                Array.Copy(shapes, select + 1, newShapes, select, shapes.Length, select);
                shapes = newShapes;
                Console.WriteLine("Фігуру успішно видалено");
            }
        }

        public void Print()
        {
            foreach (var item in shapes)
            {
                shapes.Show(item);
            }
        }
        
        public void PrintFigure()
        {
            
        }

        public void AreaFigures()
        {
            int ResultArea = 0;
            foreach (var item in shapes)
            {
                ResultArea += shapes.Area(item);
            }
            Console.WriteLine("Площя всіх фігур: {0}", ResultArea);
        }

        public void FigureArea()
        {
            
        }

        public void Save()
        {
            string saveFile = "save.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                    for (int i = 0; i < shapes.Length; i++)
                    {
                        sw.WriteLine(shapes[i].Show);
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
