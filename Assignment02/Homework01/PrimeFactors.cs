namespace Homework1
{
    internal class PrimeFactors
    {
        static int[] GetAllPrimeFactors(int inputNum)
        {
            int primeFactor = 2;
            List<int> factors = new List<int>();
            while(primeFactor <= inputNum)
            {
                if(inputNum % primeFactor == 0)
                {
                    factors.Add(primeFactor);
                    inputNum = inputNum / primeFactor;
                }
                else
                {
                    primeFactor++;
                }
            }
            return factors.ToArray();
        }
        static void Main(string[] args)
        {
            int inputNum;
            Console.WriteLine("Enter a number:");
            inputNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prime factors of " + inputNum + " are:");
            int[] result = GetAllPrimeFactors(inputNum);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}
