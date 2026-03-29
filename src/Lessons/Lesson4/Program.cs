namespace F1opl
{
    class City
    {
        string name;
        string country;
        int popularityCity;
        int numberPhoneCity;
        string[] areas = new string[0];

        public string Name{
            get
            {
            return name;   
            }
            set
            {
                name = value;
            }
        }
        public string County{
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        public int PopularityCity
        {
            get
            {
                return popularityCity;    
            } 
            set
            {
                popularityCity = value;
            }
        }
        public int NumberPhoneCity
        {
            get
            {
                return numberPhoneCity;    
            }
            set
            {
                numberPhoneCity = value;
            }
        }
        public string[] Areas
        {
            get
            {
                return areas;
            }
            set
            {
                if(value != null){
                    areas = value;
                }
            }
        }
        public City()
        {
            Console.WriteLine("Enter city -> ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter countr -> ");
            County = Console.ReadLine();
            Console.WriteLine("Enter Popularity your city -> ");
            PopularityCity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Nubmer Phone City -> ");
            NumberPhoneCity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter areas in your country ->");
            Areas = new string[] {Console.ReadLine()};
        }

        public void AddArea()
        {
            Console.WriteLine("Enter areas in your country ->");
            Areas = new string[] {Console.ReadLine()};
        }

        public void PrintFullClass()
        {
            Console.WriteLine("City name '{0}'. Country '{1}'. Popylarity {2}. Number Phone City {3}.\t Areas {4}", 
            Name, County, PopularityCity, NumberPhoneCity, areas);
        }
    }

    class Employeer
    {
        public string Name{ get; set; }
        public int Birthday{ get; set; }
        public int NumberPhone{ get; set; }
        public string Email{ get; set; }
        public string Level{ get; set; }
        public string Work{ get; set; }

        public Employeer()
        {
            Console.WriteLine("Enter name, surname and fathername -> ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Email -> ");
            Email = Console.ReadLine();
            Console.WriteLine("Enter Level working -> ");
            Level = Console.ReadLine();
            Console.WriteLine("Enter Birthday ->");
            Birthday = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number phone ->");
            NumberPhone = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter work ->");
            Work = Console.ReadLine();

        }

        public void Edit()
        {
            Console.WriteLine("Enter for edit his Level ->");
            Name = Console.ReadLine();
        }

        public void PrintFullClass()
        {
            Console.WriteLine("Phone -> {0}\n Name -> {1} \nEmail -> {2} Birtday -> {3}\n Level -> {4} Work -> {5}, ",
            NumberPhone, Name, Email, Birthday, Level, Work);
        }
    }
}