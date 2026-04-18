namespace Fiopl
{
    class BankAcount
{
    public string Owner{ get; set; }
    public double Balance{ get; set; }

    public BankAcount(string _owner, double _balance)
    {
        if (_balance < 0)
            {
                throw new ArgumentException("Початковий баланс не може буди меньше ніж нуль! ");
            }
            Owner = _owner;
            Balance = _balance;
            Console.WriteLine("Баланс відкритий. Ваш баланс {0}", Balance);
    }

    public void Deposit(double sum)
        {
            if(sum < 0)
            {
                throw new ArgumentException("Сумма попвнення не може буду відьемною");
            }

            Balance += sum;
            Console.WriteLine("Ваш баланс поповнено на {0}. Тепер на вашому рахунку {1}", sum, Balance);
        }
    
    public void Withdraw(double sum)
        {
            if(sum < 0)
            {
                throw new ArgumentException("Сумма знатя не може бути менше нуля");
            }

            if(sum > Balance)
            {
                throw new ArgumentException("Недостатьно коштів на рахунку");
            }
            
            Balance -= sum;
            Console.WriteLine("Знято з балансу {0}. Залишок на балансі {1}", sum , Balance);
        }
}

    public class Employee
    {
        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name;
        }

        public (decimal Salary, string Note) CalculateSalary(decimal fixedRate)
        {
            return (fixedRate, "Фіксована ставка");
        }

        public (decimal Salary, string Note) CalculateSalary(decimal hourlyRate, int hoursWorked)
        {
            decimal result = hourlyRate * hoursWorked;
            return (result, "За годиною ставкою"); 
        }

        public (decimal Salary, string Note) CalculateSalary(decimal fixedRate, decimal bonusPercentage)
        {
            decimal memory = fixedRate * bonusPercentage / 100;
            decimal result = fixedRate + memory;
            return (result, "Фіксована ставка з урахууванням премій");
        }
    }
}