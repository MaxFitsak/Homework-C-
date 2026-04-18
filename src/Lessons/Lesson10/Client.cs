namespace Task
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Курси ---");
            Course c = new Course("It", 2);
            OnlineCourse ol = new OnlineCourse("It", 5, "ClassRoom");

            Console.WriteLine(c);
            Console.WriteLine(ol);


            Console.WriteLine("--- Список працівників ---");

            Worker p = new President("Олександр Хмарний");            
            Worker s = new Security("Олексій Який");
            Worker m = new Menager("Олег Хмурий");
            Worker e = new Engineer("Сергій Веселий");
            
            p.Print();
            s.Print();
            m.Print();
            e.Print();
        }
    }
}
