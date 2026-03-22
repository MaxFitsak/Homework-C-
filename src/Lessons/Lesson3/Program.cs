using System.Threading.Tasks.Dataflow;

class Lesson3
{
    static void Main()
    {
        //task 1
        try
        {
        Console.WriteLine("Enter Arifmetic nubmer -> ");
        string ArifmeticNUmber = Console.ReadLine();
        
        int result = 0;
        string currentNumber = "";


        for (int i = 0; i < ArifmeticNUmber.Length; i++)
        {
            char memory = ArifmeticNUmber[i];

            if (char.IsDigit(memory))
            {
                currentNumber += memory;
            }
            if (memory == '+' || memory == '-' || i == ArifmeticNUmber.Length - 1)
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    result += int.Parse(currentNumber);
                }
                currentNumber = memory.ToString();
            }
        }

        Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }


        //task 2
        try
        {
        Console.WriteLine("Enter text -> ");
        string text = Console.ReadLine();
        string resultText = "";
        bool isDot = true;

        for (int i = 0; i < text.Length; i++)
        {
            char memory = text[i];

            if (isDot && char.IsLetter(memory))
            {
                resultText += char.ToUpper(memory);
                isDot = false;
            }
            else
            {
                resultText += memory;
            }

            if(memory == '.')
            {
                isDot = true;
            }

        }

        Console.WriteLine(resultText);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}