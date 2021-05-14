using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new MemoryCalculator(new Calculator());
            while (true)
            {
                try
                {
                    Console.Write("Input: ");
                    var input = Console.ReadLine();
                    if (input == "exit")
                    {
                        break;
                    }

                    var result = calculator.Process(input, out string message);
                    if (message != null)
                    {
                        Console.WriteLine($"Message: {message}");
                    }
                    else
                    {
                        Console.WriteLine($"Result: {result}");
                    }
                    
                    calculator.DisplaySlots();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine();
            }
            
        }
    }
}
