using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Homework01
    {
        static void Main()
        {
            //链表的初始化赋值
            GenericList<int> list = new GenericList<int>();
            Random rNum = new Random();
            for(int i = 0; i<10;i++)
                list.Add(rNum.Next(i));
            //调用链表的ForEach操作

            //调用ForEach实现打印所有数据
            list.ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            //调用ForEach实现找到最大值
            int maxValue = int.MinValue;
            list.ForEach(x => maxValue = (x > maxValue) ? x : maxValue);
            Console.WriteLine("数组最大值：{0}", maxValue);

            //调用ForEach实现找到最小值
            int minValue = int.MaxValue;
            list.ForEach(x => minValue = (x < minValue) ? x : minValue);
            Console.WriteLine("数组最小值：{0}", minValue);

            //求和
            int sum = 0;
            list.ForEach(x => sum += x);
            Console.WriteLine("数组的和：{0}", sum);

            Console.WriteLine("下面是使用多播委托的实现:");

            //下面使用多播委托尝试一次性实现上面所有操作
            int delegateMax = int.MinValue;
            int delegateMin = int.MaxValue;
            int delegateSum = 0;
            Action<int> operations = x => Console.Write(x + " "); //打印
            operations += x => delegateMax = (x > delegateMax) ? x : delegateMax; //求最大值
            operations += x => delegateMin = (x < delegateMin) ? x : delegateMin; //求最小值
            operations += x => delegateSum += x;//求和
            list.ForEach(operations);
            Console.WriteLine();
            Console.WriteLine("数组的最大值为：{0}，数组的最小值为：{1}，数组的和为：{2}", delegateMax, delegateMin, delegateSum);
            Console.ReadKey();
        }
    }
}
