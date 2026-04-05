using System.Diagnostics;
using System.Net;

class Employeer
    {
        public string Name{ get; set; }
        public int Birthday{ get; set; }
        public int NumberPhone{ get; set; }
        public string Email{ get; set; }
        public string Level{ get; set; }
        public string Work{ get; set; }
        public int Solary{ get; set; }

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
            Console.WriteLine("Enter solary ->");
            Solary = int.Parse(Console.ReadLine());
        }

        public static Employeer operator +(Employeer solary, int number)
        {   
            solary.Solary += number;
            return solary;
        }

        public static Employeer operator -(Employeer solary, int number)
        {
            solary.Solary -= number;
            return solary;
        }

        public static bool operator ==(Employeer op1, Employeer op2)
        {
            return op1.Solary == op2.Solary;
        }

        public static bool operator !=(Employeer op1, Employeer op2)
        {
            return !(op1 == op2);
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
    class ReadBooks
    {
        private string[] books = new string[0];

        public string this[int index]
        {
            get 
            {
                if (index < 0 || index >= books.Length) throw new IndexOutOfRangeException();
                return books[index];
            }
            set 
            {
                if (index < 0 || index >= books.Length) throw new IndexOutOfRangeException();
                books[index] = value;
            }
        }

        public static ReadBooks operator +(ReadBooks list, string bookName)
        {
            Array.Resize(ref list.books, list.books.Length + 1);
            list.books[list.books.Length - 1] = bookName;
            return list;
        }

        public static ReadBooks operator -(ReadBooks list, string bookName)
        {
            list.books = list.books.Where(b => b != bookName).ToArray();
            return list;
        }

        public void Print()
        {
            Console.WriteLine("\nСписок книг:");
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i}. {books[i]}");
            }
        }
}