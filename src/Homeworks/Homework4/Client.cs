namespace F1opl
{
    class Program
    {
        static void Main(string[] args)
        {
            Date dateDefault = new Date();
            Console.Write("First date -> ");
            dateDefault.Print();

            Date dateCustom = new Date(25, 2, 2024); 
            Console.Write("Second Date -> ");
            dateCustom.Print();

            dateCustom.AddDays(10); 
            Console.Write("Second date -> ");
            dateCustom.Print();

            Date dateToday = new Date(29, 3, 2026);
            Date datePast = new Date(1, 1, 2026);
            
            int diff = dateToday.Difference(datePast);
            
            Console.Write("First date -> ");
            dateToday.Print();
            Console.Write("Second date -> ");
            datePast.Print();
            Console.WriteLine($"Differnce date-> {diff}");
        }
    }
}