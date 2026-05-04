using System.Text;

namespace Task
{
    public class Task
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            ArrayInteger arr = new ArrayInteger();
            Client myClient = new Client();

            arr.Print();

            myClient.MarhOperation(arr);
            Console.ReadKey();
        }
    }
}