namespace Task
{
    class Program
    {
        static void Client(ICalc calcObject)
        {   
            Console.WriteLine(calcObject.CountDistinct());
        }

        static void Main()
        {
            int[] myNumbers = { 1, 2, 2, 3, 4, 4, 4, 5 };

            ArrayInteger myCalc = new ArrayInteger(myNumbers);

            Client(myCalc);
        }
    }
}   