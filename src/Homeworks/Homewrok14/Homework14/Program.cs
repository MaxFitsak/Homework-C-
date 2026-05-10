using System.Text;

class CreditCard
{
    public delegate void CardHandler(string message);
    public delegate void PinHandler(int newPin);

    public event CardHandler? OnDeposit;        
    public event CardHandler? OnWithdraw;      
    public event CardHandler? OnCreditStart; 
    public event CardHandler? OnGoalReached;  
    public event PinHandler? OnPinChanged;

    public string CardNumber { get; set; }
    public string OwnerName { get; set; }
    public string ExpiryDate { get; set; }
    public int Pin { get; private set; }
    public decimal CreditLimit { get; set; }
    public decimal Money { get; private set; }
    public decimal TargetAmount { get; set; }

    public CreditCard(string name, string number, string expiry, int pin, decimal limit, decimal initialMoney, decimal target)
    {
        OwnerName = name;
        CardNumber = number;
        ExpiryDate = expiry;
        Pin = pin;
        CreditLimit = limit;
        Money = initialMoney;
        TargetAmount = target;
    }

    public void Deposit(decimal amount)
    {
        Money += amount;
        OnDeposit?.Invoke(@$"Рахунок поповнено на {amount}. Поточний баланс: {Money}");

        if (Money >= TargetAmount)
        {
            OnGoalReached?.Invoke($"Вітаємо! Задану суму {TargetAmount} досягнуто. На рахунку: {Money}");
        }
    }

    public void Withdraw(decimal amount)
    {
        bool wasUsingCredit = Money < 0;
        Money -= amount;
        OnWithdraw?.Invoke($"Знято суму {amount}. Залишок: {Money}");

        if (!wasUsingCredit && Money < 0)
        {
            OnCreditStart?.Invoke($"Увага! Ви почали використовувати кредитні кошти. Баланс: {Money}");
        }
    }

    public void ChangePin(int newPin)
    {
        Pin = newPin;
        OnPinChanged?.Invoke(newPin);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        CreditCard myCard = new CreditCard("Максим", "4444-5555-6666-7777", "12/28", 1234, 5000, 1000, 2000);


        myCard.OnDeposit += (msg) => Console.WriteLine(msg);
        myCard.OnWithdraw += (msg) => Console.WriteLine(msg);
        myCard.OnCreditStart += (msg) => Console.WriteLine(msg);
        myCard.OnGoalReached += (msg) => Console.WriteLine(msg);
        myCard.OnPinChanged += (pin) => Console.WriteLine(pin);

        myCard.Deposit(1500); 

        myCard.Withdraw(3000);

        myCard.ChangePin(5555); 

        Console.ReadKey();
    }
}