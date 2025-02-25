using System;

namespace Homework1
{
    internal class ConsoleCalculator
    {
        static void Main(string[] args)
        {
            // Ask the user to enter the first number
            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            // Ask the user to enter the operator
            Console.WriteLine("Enter the operator:");
            string? operatorChoice = Console.ReadLine();
            if (operatorChoice == null)
            {
                Console.WriteLine("Invalid operator");
                return;
            }
            // Ask the user to enter the second number
            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            // Calculate the result
            switch (operatorChoice)
            {
                case "+":
                    Console.WriteLine("The result is " + (num1 + num2));
                    break;
                case "-":
                    Console.WriteLine("The result is " + (num1 - num2));
                    break;
                case "*":
                    Console.WriteLine("The result is " + (num1 * num2));
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero");
                    }
                    else
                    {
                        Console.WriteLine("The result is " + (num1 / num2));
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
        }
    }
}
