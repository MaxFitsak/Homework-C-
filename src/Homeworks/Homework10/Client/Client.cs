using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Task
{
    class ApllicationInterface
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            CollectionOfFigures colletction = new CollectionOfFigures();
            Console.WriteLine("---Фігури---");
            while (true)
            {
                Console.WriteLine("1. Добавити фігуру 2. Видалити фігуру 3. Вивести всі фігури 4. Вивсти одного типу фігури 5. Площя всіх фігур 6. Площя одного типу фігур" +
                    "\n7. Зберегти 8. Завантажити 9. Вихід");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        colletction.AddShapes();
                        break;
                    case 2:
                        colletction.DeleteShape();
                        break;
                    case 3:
                        colletction.Print();
                        break;
                    case 4:
                        colletction.PrintFigure();
                        break;
                    case 5:
                        colletction.AreaFigures();
                        break;
                    case 6:
                        colletction.FigureArea();
                        break;
                    case 7:
                        colletction.Save();
                        break;
                    case 8:
                        colletction.Load();
                        break;
                    case 9:
                        Console.WriteLine("Вихід з програми");
                        return;
                    default:
                        Console.WriteLine("Помилка");
                        break;
                }
            }
        }
    }
}