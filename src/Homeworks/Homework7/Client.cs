namespace FractionMath
{
    class Program
    {
        static void Main()
        {
            Fraction d1 = new Fraction(1, 2);
            Fraction d2 = new Fraction(3, 4);

            Console.Write("Дріб 1: "); d1.Print();
            Console.Write("Дріб 2: "); d2.Print();
            Console.WriteLine("----------------");

            Fraction multResult = FractionCalculator.Multiply(d1, d2);
            Console.Write("Множення: ");
            multResult.Print();

            Fraction divResult = FractionCalculator.Divide(d1, d2);
            Console.Write("Ділення: ");
            divResult.Print();

            Fraction addResult = FractionCalculator.Add(d1, d2);
            Console.Write("Додавання: ");
            addResult.Print();
            
            Fraction subResult = FractionCalculator.Subtract(d1, d2);
            Console.Write("Віднімання: ");
            subResult.Print();

        }
    }
}