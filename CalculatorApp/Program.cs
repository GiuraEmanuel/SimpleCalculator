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
                Console.WriteLine("Input");
                var input = Console.ReadLine();

                //Console.WriteLine(calculator.Process(input));
            }
        }
    }
}
