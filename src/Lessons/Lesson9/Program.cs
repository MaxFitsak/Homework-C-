namespace Task
{
public class Passport
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }

         public Passport(string firstName, string lastName, string documentNumber, DateTime birthDate, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            DocumentNumber = documentNumber;
            BirthDate = birthDate;
            Country = country;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Паспорт: {FirstName} {LastName}");
            Console.WriteLine("№: {0}, Країна: {1}", DocumentNumber, Country);
        }
    }

    public class ForeignPassport : Passport
    {
        public string ForeignNumber { get; set; }
        private string[] visas;
        private int visaCount;

        public ForeignPassport(string firstName, string lastName, string documentNumber, 
                               DateTime birthDate, string country, string foreignNumber, int maxVisas = 10) 
            : base(firstName, lastName, documentNumber, birthDate, country)
        {
            ForeignNumber = foreignNumber;
            visas = new string[maxVisas];
            visaCount = 0;
        }

        public void AddVisa(string visa)
        {
            if (visaCount < visas.Length)
            {
                visas[visaCount] = visa;
                visaCount++;
            }
            else
            {
                Console.WriteLine("Помилка немає місця для нової візи!");
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Закордоний поспорт №: {0}", ForeignNumber);
            Console.WriteLine("Список віз:");
            
            if (visaCount == 0)
            {
                Console.WriteLine("- Візи відсутні");
            }
            else
            {
                for (int i = 0; i < visaCount; i++)
                {
                    Console.WriteLine("- {0}", visas[i]);
                }
            }
            Console.WriteLine(new string('-', 20));
        }
    }

    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} робить якусь звичайну людську роботу.");
        }
    }

    public class Builder : Human
    {
        public string Tool { get; set; }

        public Builder(string name, int age, string tool) : base(name, age)
        {
            Tool = tool;
        }

        public override void Work()
        {
            Console.WriteLine($"Будівельник {Name} (вік: {Age}) будує хмарочос, використовуючи {Tool}.");
        }
    }

    // --- ТВОЯ ЗАДАЧА 1: Створи клас Sailor (Моряк) ---
    // 1. Успадкуй його від Human
    // 2. Додай властивість, наприклад, string ShipName (Назва корабля)
    // 3. Напиши конструктор з використанням : base(...)
    // 4. Перевизнач метод Work() (override)
    public class Sailor : Human
    {
        public string ShipName {get; set;}

        public Sailor (string name, int age, string shipname) : base(name, age)
        {
            ShipName = shipname;
        }

        public override void Work()
        {
            Console.WriteLine($"Моряк {Name} (вік: {Age}) пливе в Тихому Океані, використовуючи {ShipName}.");
        }
    }

    // --- ТВОЯ ЗАДАЧА 2: Створи клас Pilot (Пілот) ---
    // 1. Успадкуй його від Human
    // 2. Додай властивість, наприклад, string AircraftType (Тип літака)
    // 3. Напиши конструктор з використанням : base(...)
    // 4. Перевизнач метод Work() (override)
    public class Pilot : Human
    {
        public string AircraftType {get; set;}

        public Pilot(string name, int age, string aircraftType) : base(name, age)
        {
            AircraftType = aircraftType;
        }

        public override void Work()
        {
            Console.WriteLine($"Пілот {Name} (вік: {Age}) Летить рейс, використовуючи {AircraftType}.");
        }
    }
}