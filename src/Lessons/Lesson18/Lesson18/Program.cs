using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("1");
        string namePattern = @"^[А-ЯІЇЄҐA-Z][а-яіїєґa-z]+\s[А-ЯІЇЄҐA-Z]\.?[А-ЯІЇЄҐA-Z]\.?$";

        string[] testNames = { "Іваненко І.І.", "Іваненко ІІ.", "Петренко П", "іваненко і.і.", "Сміт А.Б." };
        foreach (var name in testNames)
        {
            bool isValid = Regex.IsMatch(name, namePattern);
            Console.WriteLine($"{name,-15}  {(isValid ? "Коректно" : "Помилка")}");
        }
        
        Console.WriteLine("2");
        string emailPattern = @"^\w{3,16}@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,3}$";

        string[] testEmails = { "user_123@mail.ua", "login@mail.odessa.ua", "ab@com.ua", "toolonglogin1234567@net.com", "test@host.c" };
        foreach (var email in testEmails)
        {
            bool isValid = Regex.IsMatch(email, emailPattern);
            Console.WriteLine($"{email,-30}  {(isValid ? "Коректно" : "Помилка")}");
        }

        Console.WriteLine("3");
        string datePattern = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

        string[] testDates = { "01-04-2015", "31-12-2023", "32-01-2020", "15-13-2022", "1-4-2015" };
        foreach (var date in testDates)
        {
            bool isValid = Regex.IsMatch(date, datePattern);
            Console.WriteLine($"{date,-15}  {(isValid ? "Коректно" : "Помилка")}");
        }
    }
}