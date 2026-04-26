namespace Task
{
    class Main_Class
    {
        public static void Main()
        {
            Academy_Group group = new Academy_Group();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("  МЕНЮ АКАДЕМІЧНОЇ ГРУПИ");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Показати всіх студентів");
                Console.WriteLine("2. Додати нового студента");
                Console.WriteLine("3. Редагувати студента");
                Console.WriteLine("4. Видалити студента");
                Console.WriteLine("5. Знайти студента");
                Console.WriteLine("6. Зберегти дані у файл");
                Console.WriteLine("7. Завантажити дані з файлу");
                Console.WriteLine("0. Вийти з програми");
                Console.Write("\nЗробіть ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        group.Print();
                        break;
                        
                    case "2":
                        try
                        {
                            Console.Write("Введіть ім'я: "); 
                            string name = Console.ReadLine();
                            
                            Console.Write("Введіть прізвище: "); 
                            string surname = Console.ReadLine();
                            
                            Console.Write("Введіть вік: "); 
                            int age = int.Parse(Console.ReadLine());
                            
                            Console.Write("Введіть телефон: "); 
                            string phone = Console.ReadLine();
                            
                            Console.Write("Введіть середній бал: "); 
                            double gpa = double.Parse(Console.ReadLine());
                            
                            Console.Write("Введіть номер групи: "); 
                            string groupName = Console.ReadLine();

                            Student newStudent = new Student(name, surname, age, phone, gpa, groupName);
                            group.Add(newStudent);
                            
                            Console.WriteLine("Студента успішно додано!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Помилка! Вік та бал повинні бути числами.");
                        }
                        break;

                    case "3":
                        group.Edit();
                        break;

                    case "4":
                        group.Remove();
                        break;

                    case "5":
                        group.Search();
                        break;

                    case "6":
                        group.Save();
                        break;

                    case "7":
                        group.Load();
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("Роботу завершено. Гарного дня!");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
