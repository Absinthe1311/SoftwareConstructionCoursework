using System.ComponentModel;

namespace Homework3
{
    internal class PrimeFiltering
    {
        static void PrimeFilter(int[] Array)
        {
            for(int i = 2; i < 101; i++)
            {
                if (Array[i] == 0)
                    continue;
                int multiple = 2;
                while (i * multiple <= 100)
                {
                    Array[i * multiple] = 0;
                    multiple++;
                }
            }
        }
        static void Main(string[] args)
        {
            // initialize array 2-100
            int[] Array = new int[101];
            for(int i = 2; i < 101; i++)
            {
                Array[i] = i;
            }
            PrimeFilter(Array);
            Console.WriteLine("All prime numbers between 2 and 100 are:");
            for (int i = 2;  i < 101; i++)
            {
                if (Array[i] != 0)
                    Console.WriteLine(Array[i]);
            }
        }
    }
}
