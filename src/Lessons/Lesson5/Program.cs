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
    public string[] Books{ get; set; }
    int count;

    public int Count{get {return count;} }

    public ReadBooks()
    {
        Books = new string[0];
        count = 0;
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < Books.Length)
            {
                return Books[index];
            }
            else
            {
                throw new Exception("\nНекоректний індекс " + index);
            }
        }
        set
        {
            if (index >= 0 && index < Books.Length)
            {
                Books[index] = value;
            }
            else
            {
                throw new Exception("\nНекоректний індекс " + index);
            }
        }
    }

    public bool Content(string bookName)
    {
        for (int i = 0; i < count; i++)
        {
            if(Books[i] == bookName) return true;
        }
        return false;
    }

    public static ReadBooks operator +(ReadBooks list, string bookName)
    {
        Array.Resize(ref list.Books, list.count + 1);
        list.Books[list.count] = bookName;
        list.count++;
        return list;
    }

    public static ReadBooks operator -(ReadBooks list, string bookName)
    {
        int index = Array.FindIndex(list.Books, b => b == bookName);
        if(index != -1)
        {
            for (int i = index; i < list.count -1 ; i++)
            {
                list.Books[i] = list.Books[i + 1];
            }

            list.count--;
            Array.Resize(ref list.Books, list.count);
        }
        return list;
    }

    public void Print()
    {
        Console.WriteLine("\n\nСписок книг");
        if (count == 0 ) Console.WriteLine("Список пустий");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("{0}. {1}",i, Books[i]);
        }
    }
}