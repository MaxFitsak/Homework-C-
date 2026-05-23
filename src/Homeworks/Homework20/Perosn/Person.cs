namespace Task
{

    public class Person
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public int Age { set; get; }
        public int Phone { set; get; }

        public Person()
        {
            Name = "Unklow";
            Surname = "Unklow";
            Age = 0;
            Phone = 0;
        }

        public Person(string name, string surname, int age, int phone)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Phone = phone;
        }

        public void Print()
        {
            Console.WriteLine("Імя {0}, Фамілія {1}, Вік {2}, Телефон {3}", Name, Surname, Age, Phone);
        }
    }
}