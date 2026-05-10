using System.Text;

namespace Task
{
    class MainClass
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            AcademyGroup academyGroup = new AcademyGroup();
            while (true)
            {
                Console.WriteLine("1. Add 2. Remove 3. Edit 4. Print 5. Save 6. Load 7. Search 9. Exit");
                int select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Введіть Імя, Фамілію, вік, телефон, средній бал, Назву групи");
                        string name = Console.ReadLine();
                        string surname = Console.ReadLine();
                        int age = int.Parse(Console.ReadLine());
                        int phone = int.Parse(Console.ReadLine());
                        double gpa = double.Parse(Console.ReadLine());
                        string groupName = Console.ReadLine();
                        academyGroup.Add(new Student(name, surname, age, phone, gpa, groupName));
                        break;
                    case 2:
                        academyGroup.Remove();
                        break;
                    case 3:
                        academyGroup.Edit();
                        break;
                    case 4:
                        academyGroup.Print();
                        break;
                    case 5:
                        academyGroup.Save();
                        break;
                    case 6:
                        academyGroup.Load();
                        break;
                    case 7:
                        academyGroup.Search();
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

            }
        }
    }
}