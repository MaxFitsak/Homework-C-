using System;
using System.Reflection;
using System.Text;

namespace Task
{
    class MainClass
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string dllPath = @"C:\Users\chupchushka\source\repos\MaxFitsak\Homework-C-\src\Homeworks\Homework19\AcademuGroup\bin\Debug\net10.0\AcademuGroup.dll";

            Assembly assembly = Assembly.LoadFrom(dllPath);

            Type academyGroupType = assembly.GetType("Task.AcademyGroup");

            if (academyGroupType == null)
            {
                Console.WriteLine("Класс AcademyGroup не найден в DLL!");
                return;
            }

            object academyGroupInstance = Activator.CreateInstance(academyGroupType);

            MethodInfo addMethod = academyGroupType.GetMethod("Add");
            MethodInfo removeMethod = academyGroupType.GetMethod("Remove");
            MethodInfo editMethod = academyGroupType.GetMethod("Edit");
            MethodInfo printMethod = academyGroupType.GetMethod("Print");
            MethodInfo saveMethod = academyGroupType.GetMethod("Save");
            MethodInfo loadMethod = academyGroupType.GetMethod("Load");
            MethodInfo searchMethod = academyGroupType.GetMethod("Search");

            while (true)
            {
                Console.WriteLine("\n1. Add 2. Remove 3. Edit 4. Print 5. Save 6. Load 7. Search 9. Exit");
                Console.Write("Виберіть дію: ");

                if (!int.TryParse(Console.ReadLine(), out int select)) continue;

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Введіть Ім'я, Прізвище, вік, телефон, середній бал, Назву групи:");
                        string name = Console.ReadLine();
                        string surname = Console.ReadLine();
                        int age = int.Parse(Console.ReadLine());
                        int phone = int.Parse(Console.ReadLine());
                        double gpa = double.Parse(Console.ReadLine());
                        string groupName = Console.ReadLine();

                        if (addMethod != null)
                        {
                            object[] parameters = new object[] { name, surname, age, phone, gpa, groupName };
                            addMethod.Invoke(academyGroupInstance, parameters);
                        }
                        break;

                    case 2:
                        removeMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 3:
                        editMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 4:
                        printMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 5:
                        saveMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 6:
                        loadMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 7:
                        searchMethod?.Invoke(academyGroupInstance, null);
                        break;

                    case 9:
                        return;

                    default:
                        Console.WriteLine("Error: Невірний вибір.");
                        break;
                }
            }
        }
    }
}