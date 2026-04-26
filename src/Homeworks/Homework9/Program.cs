using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Task
{
    class Person
    {
        protected string name;
        protected string surname;
        protected int age;
        protected string phone;

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public int Age { get { return age; } set { age = value; } }

        public Person()
        {
            name = "Unklow";
            surname = "Unklow";
            age = 0;
            Phone = "Unklow";
        }

        public Person(string _name, string _surname, string _phone, int _age)
        {
            name = _name;
            surname = _surname;
            age = _age;
            phone = _phone;
        }

        virtual public void Print()
        {
            Console.WriteLine("Інформація про людину");
            Console.WriteLine("Ім'я: {0}   Фамілія: {1}   Вік: {2}     Телефон: {3}", name,surname,age,phone);
        }
    }

    class Student : Person
    {
        protected double grade_point_avarage;
        protected string group_name;

        public double GPA { get { return grade_point_avarage; } set { grade_point_avarage = value; } }
        public string GroupName { get { return group_name; } set { group_name = value; } }

        public Student () : base()
        {
            grade_point_avarage = 0.0;
            group_name = "Unklow";
        }

        public Student (string _name, string _surname, int _age, string _phone, double _grade_point_avarage, string _group_name) : 
            base(_name, _surname, _phone, _age)
        {
            grade_point_avarage = _grade_point_avarage;
            group_name = _group_name;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Група: {0}, Средній бал: {1}", group_name, grade_point_avarage);
        }
    }

    class Academy_Group
    {
        private Student[] students;
        private int count;

        public Academy_Group()
        {
            students = new Student[10];
            count = 0;
        }

        public void Add(Student student)
        {
            if (count == students.Length)
            {
                Array.Resize(ref students, count * 2);
            }
            students[count] = student;
            count++;
        }

        public void Remove()
        {
            Student search = Search();

            if (search == null)
            {
                Console.WriteLine("Студента не знайдено, редагування неможливе.");
                return;
            }

            students = students.Where(x => x != search || x == null).ToArray(); count--;

            Console.WriteLine("Студент видалений");
        }

        public void Edit()
        {
            Student studentToEdit = Search();

            if (studentToEdit == null)
            {
                Console.WriteLine("Студента не знайдено, редагування неможливе.");
                return;
            }

            Console.WriteLine("Що бажаєте змінити?");
            Console.WriteLine("1. Ім'я \n2. Прізвище \n3. Середній бал");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть нове ім'я: ");
                    studentToEdit.Name = Console.ReadLine();
                    Console.WriteLine("Ім'я успішно змінено!");
                    break;
                case "2":
                    Console.Write("Введіть нове прізвище: ");
                    studentToEdit.Surname = Console.ReadLine();
                    Console.WriteLine("Прізвище успішно змінено!");
                    break;
                case "3":
                    Console.Write("Введіть новий бал: ");
                    studentToEdit.GPA = double.Parse(Console.ReadLine());
                    Console.WriteLine("Бал успішно змінено!");
                    break;
                default:
                    Console.WriteLine("Помилка.");
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine("Кількусть в группі: {0}", count);
            Console.WriteLine("Студенти: ");
            for (int i = 0; i < count; i++)
            {
                students[i].Print();
            }
        }

       public void Save()
        {
            string saveFile = "save.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                    for (int i = 0; i < count; i++)
                    {
                        sw.WriteLine($"{students[i].Name}|{students[i].Surname}|{students[i].Age}|{students[i].Phone}|{students[i].GPA}|{students[i].GroupName}");
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
                    count = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length == 6)
                        {
                            Student loadedStudent = new Student(
                                parts[0],                   // Name
                                parts[1],                   // Surname
                                int.Parse(parts[2]),        // Age
                                parts[3],                   // Phone
                                double.Parse(parts[4]),     // GPA
                                parts[5]                    // GroupName
                            );

                            Add(loadedStudent);
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

        public Student Search()
        {
            Console.WriteLine("За яким критєром бдуем шукати студента? \n1.Імя 2.Фамілая 3.Телефон");
            int search = int.Parse(Console.ReadLine());

            switch (search)
            {
                case 1:
                    Console.WriteLine("Введіть імя студента для пошуку: ");
                    string searchName = Console.ReadLine();
                    for (int i = 0; i < count; i++)
                    {
                        if(students[i].Name == searchName)
                        {
                            Console.WriteLine("Студент найшовся");
                            students[i].Print();
                            return students[i];
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Введіть фамілію студента для пошуку");
                    string searchSurname = Console.ReadLine();
                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].Surname == searchSurname)
                        {
                            Console.WriteLine("Студент знайшовся");
                            students[i].Print();
                            return students[i];
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Введіть номер телефона для пошуку: ");
                    string searchPhone = Console.ReadLine();
                    for (int i = 0; i < count; i++)
                    {
                        if(students[i].Phone == searchPhone)
                        {
                            Console.WriteLine("Студент знайшовся");
                            students[i].Print();
                            return students[i];
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Помилка");
                    return null;
            }
            return null;
        }

    }
}