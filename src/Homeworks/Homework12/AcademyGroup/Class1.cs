using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task
{
    public class AcademyGroup : ICloneable
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
            Console.WriteLine("Введіть фамілію для видалення");
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
            foreach (var s in students)
            {
                s.Print();
            }
        }


        public void Sort()
        {
            Console.WriteLine("1. Сорутвання за фамілею 2. Сорутвання за среднім баллом");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                students.Sort(new Student.SurnameComparer());
            else
                students.Sort(new Student.GPAComparer());

            Console.WriteLine("Сортування завершено.");
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

                Console.Write("Новий вік: ");
                student.Age = int.Parse(Console.ReadLine());

                Console.Write("Новий телефон: ");
                student.Phone = int.Parse(Console.ReadLine());

                Console.Write("Новий середній бал: ");
                student.GPA = double.Parse(Console.ReadLine());

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
            using (StreamWriter sw = new StreamWriter("save.txt"))
            {
                foreach (var s in students)
                {
                    sw.WriteLine($"{s.Name},{s.Surname},{s.Age},{s.Phone},{s.GPA},{s.GroupName}");
                }
            }
            Console.WriteLine($"Дані збережено. Студентів у списку: {students.Count}");
        }

        public void Load()
        {
            if (!File.Exists("save.txt")) return;

            students.Clear();
            using (StreamReader sr = new StreamReader("save.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] p = line.Split(',');
                    students.Add(new Student(p[0], p[1], int.Parse(p[2]), int.Parse(p[3]), double.Parse(p[4]), p[5]));
                }
            }
            Console.WriteLine("Дані завантажено.");
        }


        public void Search()
        {
            Console.WriteLine("Введіть фамілію для пошуку студента");
            string surname = Console.ReadLine();

            var found = students.Find(s => s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
            if (found != null) found.Print();
            else Console.WriteLine("Нікого не знайдено.");
        }

        public object Clone()
        {
            AcademyGroup newGroup = new AcademyGroup();
            foreach (var s in this.students)
            {
                newGroup.Add((Student)s.Clone());
            }
            return newGroup;
        }
    }
}