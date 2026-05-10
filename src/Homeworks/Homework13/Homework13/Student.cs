using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Task
{
    public class Student : Person
    {
        public double GPA { get; set; }
        public string GroupName { set; get; }

        public Student(string name, string surname, int age, int phone, double gpa, string groupname) : base(name, surname, age, phone)
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
    }

}
