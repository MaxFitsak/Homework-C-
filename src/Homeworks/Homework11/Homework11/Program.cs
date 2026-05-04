namespace Task
{
    public interface IMath
    {
        int Max();
        int Min();
        double Avg();
        bool Search(int valueToSearch);
    }

    public class ArrayInteger : IMath
    {
        int[] Arr = new int[20];
        Random r = new Random();
        
        public ArrayInteger()
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = r.Next(100);
            }
        }

        public void Print()
        {
            foreach (var item in Arr)
            {
                Console.Write(item + " | ");
            }
        }

        public int Max()
        {
            int result = 0;
            foreach (var item in Arr)
            {
                if (item > result)
                {
                    result = item;
                }
            }
            return result;
        }

        public int Min()
        {
            int result = 100;
            foreach (var item in Arr)
            {
                if (item < result)
                {
                    result = item;
                }
            }
            return result;
        }

        public double Avg()
        {
            int result = 0;
            foreach (var item in Arr)
            {
                    result += item;
            }
            return result / Arr.Length;
        }

        public bool Search(int valueToSearch)
        {
            foreach (var item in Arr)
            {
                if (item == valueToSearch)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Client
    {
        public void MarhOperation(IMath mObject)
        {
            int max = mObject.Max();
            int min = mObject.Min();
            double avg = mObject.Avg();
            Console.WriteLine("Яке число найти?");
            bool search = mObject.Search(int.Parse(Console.ReadLine()));

            Console.WriteLine("Максимальне число -> {0}, мінімальне чилос -> {1}, средне чилос -> {2},Вийшо найти? -> {3}", max, min, avg, search);
            Console.ReadKey();
        }
    }

}