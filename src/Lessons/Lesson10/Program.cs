namespace Task
{
    public class Course
    {
        public string Name { get; set; }
        public int Duration { get; set; }

        public Course(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"Курс: {Name}, Тривалість: {Duration} год.";
        }
    }

    public class OnlineCourse : Course
    {
        public string Platform {get; set;}

        public OnlineCourse(string name, int duration, string platforn) : base(name, duration)
        {
            Platform = platforn;
        }

        public override string ToString()
        {
            return base.ToString()+ $", Платформа: {Platform}";
        }
    }

    public abstract class Worker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            Name = name;
        }

        public abstract void Print(); 
    }

    
    public class President : Worker
    {
        public President(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"[Президент] {Name}: Керує компанією та ухвалює стратегічні рішення.");
        }
    }

    public class Security : Worker
    {
        public Security(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"[Охоронец] {Name}: Слідкує за  компанією та слідкує за беспекою.");
        }
    }

    public class Menager : Worker
    {
        public Menager(string name) : base(name) {}

        public override void Print()
        {
            Console.WriteLine($"[Менеджер] {Name}: Слідкує за працвниками.");
        }
    }

    public class Engineer : Worker
    {
        public Engineer(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"[Інжинер] {Name}: Створує нові продукти.");
        }
    }
}