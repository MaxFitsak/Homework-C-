namespace Fiopl
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ПРАЦІВНИКИ ===");
            
            Employee emp1 = new Employee("Олександр");
            
            var result1 = emp1.CalculateSalary(200m, 40); 
            Console.WriteLine($"Працівник {emp1.Name}: {result1.Salary} грн. ({result1.Note})");

            var result2 = emp1.CalculateSalary(15000m, 20m);
            Console.WriteLine($"Працівник {emp1.Name}: {result2.Salary} грн. ({result2.Note})");



            Console.WriteLine("\n=== БАНКІВСЬКИЙ РАХУНОК ===");
            
            BankAcount acc1 = new BankAcount("Марія", 1000);
            
            acc1.Deposit(500);
            
            acc1.Withdraw(300);

            // acc1.Withdraw(5000); 
        }
    }
}