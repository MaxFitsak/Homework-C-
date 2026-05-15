using System.Diagnostics.Contracts;

/*namespace Lesson13_1
{
    public delegate void Action ();
    class showTask
    {
        public void ShowTime() { Console.WriteLine("Поточний час :" + DateTime.Now.ToShortTimeString()); }
        public void ShowDate() { Console.WriteLine("Поточка дата:" + DateTime.Now.ToShortDateString()); }
        public void ShowDay() { Console.WriteLine("поточкий день:" + DateTime.Now.DayOfWeek); }
        public void Client(Action action) { action(); }
    }
    class Task
    {
        static public void Main()
        {
            showTask task = new showTask();
            task.Client(task.ShowTime);
            task.Client(task.ShowDate);
            task.Client(task.ShowDay);
        }
    }
}*/

/*namespace Lesson13_2
{
    public delegate int TextDataProcessin (string text);
    class UseText
    {
        public int vowel(string text)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y'};
            int count = text.ToLower().Count(c => vowels.Contains(c));
            Console.WriteLine("Кількість голосних :" + count);
            return count;
        }

        public int adverbial(string text)
        {
            char[] adverbials = {};
            int count = text.ToLower().Count(c => adverbials.Contains(c));
            Console.WriteLine("Кількість голосних :" + count);
            return count;
        }

        public int lenhtText(string text)
        {
            int lenght = text.Length;
            Console.WriteLine("Довжина тексту" + lenght);
            return lenght;
        }

        public void Client(TextDataProcessin del, string text)
        {
            foreach (TextDataProcessin method in del.GetInvocationList())
            {
                method(text);
            } 
        }
    }

    class Task
    {
        static public void Main()
        {
            UseText ut = new UseText();

            TextDataProcessin multiDel = ut.vowel;

            multiDel += ut.adverbial;
            multiDel += ut.lenhtText;

            string myText = "Hello world";

            ut.Client(multiDel, myText);
        }
    }
}*/

/*namespace Task13_3
{
    static class Extensions
    {
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    class Program
    {
        public static void Main()
        {
            int num1 = 7;
            int num2 = 10;
            Console.WriteLine($"Число {num1} просте? {num1.IsPrime()}");
            Console.WriteLine($"Число {num2} просте? {num2.IsPrime()}");
        }
    }


}*/

namespace Task13_4
{
    static class Extensions
    {
        public static int CountVowels(this string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'а', 'е', 'є', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я' };
            
            return text.ToLower().Count(c => vowels.Contains(c));
        }
    }

    class Program
    {
        public static void Main()
        {
            string text = "Hello World! Привіт Світ!";
            Console.WriteLine($"Текст: '{text}'");
            Console.WriteLine($"Кількість голосних: {text.CountVowels()}");
        }
    }
}