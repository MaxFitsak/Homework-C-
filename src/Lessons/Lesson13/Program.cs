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

namespace Lesson13_2
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
}