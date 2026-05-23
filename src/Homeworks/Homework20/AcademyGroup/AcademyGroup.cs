using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Task
{
    public class AcademyGroup : IEnumerable
    {
        private List<Student> students;

        public AcademyGroup()
        {
            students = new List<Student>();
        }

        public void Add(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                Console.WriteLine($"Студент {student.Surname} успішно доданий.");
            }
        }

        public void Remove()
        {
            Console.WriteLine("Введіть прізвище для видалення:");
            string surname = Console.ReadLine();

            Student toRemove = students.Find(s => s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
            if (toRemove != null)
            {
                students.Remove(toRemove);
                Console.WriteLine("Студента видалено.");
            }
            else Console.WriteLine("Студента не знайдено.");
        }

        public void Print()
        {
            Console.WriteLine("\n=== СПИСОК ГРУПИ ===");
            if (students.Count == 0) Console.WriteLine("Група порожня.");
            foreach (Student s in students) s.Print();
        }

        public void Edit()
        {
            Console.Write("Введіть прізвище студента, дані якого треба змінити: ");
            string surname = Console.ReadLine();

            Student student = students.Find(s => s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            if (student != null)
            {
                Console.WriteLine("Студента знайдено. Введіть нові дані:");

                Console.Write("Нове ім'я: ");
                student.Name = Console.ReadLine();

                Console.Write("Нове прізвище: ");
                student.Surname = Console.ReadLine();

                // Использование TryParse для предотвращения вылета программы
                Console.Write("Новий вік: ");
                if (int.TryParse(Console.ReadLine(), out int age)) student.Age = age;

                Console.Write("Новий телефон: ");
                if (int.TryParse(Console.ReadLine(), out int phone)) student.Phone = phone;

                Console.Write("Новий середній бал: ");
                if (double.TryParse(Console.ReadLine(), out double gpa)) student.GPA = gpa;

                Console.Write("Нова назва групи: ");
                student.GroupName = Console.ReadLine();

                Console.WriteLine("Дані успішно оновлено!");
            }
            else
            {
                Console.WriteLine("Студента з таким прізвищем не знайдено.");
            }
        }

        public void Save()
        {
            Console.WriteLine("1. Soap 2. XML 3. JSON");
            if (!int.TryParse(Console.ReadLine(), out int select)) return;

            try
            {
                switch (select)
                {
                    case 1:
                        SoapFormatter soapFormatterSave = new SoapFormatter();
                        Console.WriteLine("SOAP Серіалізація");
                        using (FileStream fs = new FileStream("students.soap", FileMode.Create))
                        {
                            soapFormatterSave.Serialize(fs, students);
                            Console.WriteLine("Список успішно збережено у students.soap");
                        }
                        break;

                    case 2:
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                        Console.WriteLine("XML Серіалізація");
                        using (FileStream fs = new FileStream("students.xml", FileMode.Create))
                        {
                            xmlSerializer.Serialize(fs, students);
                            Console.WriteLine("Список успішно збережено у students.xml");
                        }
                        break;

                    case 3:
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(students, options);
                        Console.WriteLine("JSON Серіалізація");
                        File.WriteAllText("students.json", jsonString);
                        Console.WriteLine("Список успішно збережено у students.json");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Load()
        {
            Console.WriteLine("1. Soap 2. XML 3. JSON");
            if (!int.TryParse(Console.ReadLine(), out int select)) return;

            try
            {
                switch (select)
                {
                    case 1:
                        if (!File.Exists("students.soap")) { Console.WriteLine("Файл не знайдено."); break; }
                        SoapFormatter soapFormatterLoad = new SoapFormatter();
                        using (FileStream fs = new FileStream("students.soap", FileMode.Open))
                        {
                            students = (List<Student>)soapFormatterLoad.Deserialize(fs);
                        }
                        break;

                    case 2:
                        if (!File.Exists("students.xml")) { Console.WriteLine("Файл не знайдено."); break; }
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                        using (FileStream fs = new FileStream("students.xml", FileMode.Open))
                        {
                            students = (List<Student>)xmlSerializer.Deserialize(fs);
                        }
                        break;

                    case 3:
                        if (!File.Exists("students.json")) { Console.WriteLine("Файл не знайдено."); break; }
                        string readJson = File.ReadAllText("students.json");
                        students = JsonSerializer.Deserialize<List<Student>>(readJson);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Search()
        {
            Console.WriteLine("Введіть прізвище для пошуку студента");
            string surname = Console.ReadLine();

            var found = students.Find(s => s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
            if (found != null) found.Print();
            else Console.WriteLine("Нікого не знайдено.");
        }

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
}