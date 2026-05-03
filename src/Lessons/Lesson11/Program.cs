namespace Task
{
    public interface ICalc
    {
        int CountDistinct();
        int EqualToValue(int valueToCompare);
    }

    public class ArrayInteger : ICalc
    {
        private int[] _array;

        public ArrayInteger(int[] array)
        {
            _array = array;
        }

        public int CountDistinct()
        {
            int uniqueCount = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < i; j++)
                {
                    if (_array[i] == _array[j])
                    {
                        isDuplicate = true;
                        break;         
                    }
                }

                if (!isDuplicate)
                {
                    uniqueCount++;
                }
            }

            return uniqueCount;
        }

            public int EqualToValue(int valueToCompare)
            {
                    int count = 0;
            
                    for (int i = 0; i < _array.Length; i++)
                    {
                        if (_array[i] == valueToCompare)
                        {
                            count++;
                        }
                    }
            
                return count;
            }
    }
}
