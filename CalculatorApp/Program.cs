using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            while (true)
            {
                Console.WriteLine("Input: ");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                Console.WriteLine(calculator.ProcessInput(input));
            }
        }
    }
}
