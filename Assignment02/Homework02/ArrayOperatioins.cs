using System.ComponentModel;

namespace Homework2
{
    internal class ArrayOperatioins
    {
        static int GetMax(int[] Array)
        {
            int max = Array[0];
            for(int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > max)
                    max = Array[i];
            }
            return max;
        }
        static int GetMin(int[] Array)
        {
            int min = Array[0];
            for(int i = 0; i < Array.Length; i++)
            {
                if (Array[i] < min)
                    min = Array[i];
            }
            return min;
        }
        static double GetAverage(int[] Array)
        {
            int sum = 0;
            for(int i = 0; i< Array.Length; i++)
            {
                sum += Array[i];
            }
            double length = Array.Length;
            return sum / length;
        }
        static int GetSum(int[] Array)
        {
            int sum = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                sum += Array[i];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] Array = { 1, 2, 3, 9, 8, 7 };
            Console.WriteLine("Max: " + GetMax(Array));
            Console.WriteLine("Min: " + GetMin(Array));
            Console.WriteLine("Average: " + GetAverage(Array));
            Console.WriteLine("Sum: " + GetSum(Array));
        }
    }
}
