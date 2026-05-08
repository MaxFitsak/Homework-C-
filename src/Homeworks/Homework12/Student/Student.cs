using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Task 
{
    public class Student : Person, IComparer
    {
        public double GPA { get; set; }
        public string GroupName { set; get; }

        public Student(string name, string surname, int age, int phone, double gpa, string groupname) : base(name,surname,age,phone)
        {
            this.GPA = gpa;
            this.GroupName = groupname;
        }

        public Student() : base()
        {
            GPA = 0.0;
            GroupName = "Unklow";
        }

        public void Print()
        {
            base.Print();
            Console.WriteLine("Средній бал {0}, Назва групи {1}", GPA, GroupName);
        }

        public int Compare(object student1, object student2)
        {
            Student s1 = student1 as Student;
            Student s2 = student2 as Student;

            if (s1.Age < s2.Age) return -1;
            if (s1.Age > s2.Age) return 1;
            return 0;
        }

        public object Clone()
        {
            return new Student(this.Name, this.Surname, this.Age, this.Phone, this.GPA, this.GroupName);
        }

        public class SurnameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null || y == null) return 0;

                return string.Compare(x.Surname, y.Surname);
            }
        }

        public class GPAComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null || y == null) return 0;

                return x.GPA.CompareTo(y.GPA);
            }
        }


    }

}
