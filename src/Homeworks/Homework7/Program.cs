namespace FractionMath
{
    public struct Fraction
    {
        public int Numerator { get; set; }  
        public int Denominator { get; set; } 

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменник не може дорівнювати нулю!");

            Numerator = numerator;
            Denominator = denominator;
            
            Simplify(); 
        }

        private void Simplify()
        {
            int gcd = GetGCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
            return;
        }

        private int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void Print() => Console.WriteLine($"{Numerator}/{Denominator}");
    }

    public static class FractionCalculator
    {
        public static Fraction Multiply(Fraction f1, Fraction f2)
        {
            int newNum = f1.Numerator * f2.Numerator;
            int newDen = f1.Denominator * f2.Denominator;
            
            return new Fraction(newNum, newDen); 
        }

        public static Fraction Divide(Fraction f1, Fraction f2)
        {
            int newNum = f1.Numerator * f2.Denominator;
            int newDen = f1.Denominator * f2.Numerator;

            return new Fraction(newNum, newDen);
        }

        public static Fraction Add(Fraction f1, Fraction f2)
        {
            int newNum = (f1.Numerator * f1.Denominator) + (f2.Numerator * f1.Denominator);
            int newDen = f1.Denominator * f2.Denominator;
            return new Fraction(newNum, newDen);
        }

        public static Fraction Subtract(Fraction f1, Fraction f2)
        {
            int newNum = (f1.Numerator * f1.Denominator) - (f2.Numerator * f2.Denominator);
            int newDen = f1.Denominator * f2.Denominator;
            return new Fraction(newNum, newDen);
        }
    }

}