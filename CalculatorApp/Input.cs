using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public static class Input
    {
        public static string RemoveExtraSpaces(string input)
        {
            input = input.Trim();

            while (input.Contains("  "))
                input = input.Replace("  ", " ");
            return input;
        }
    }
}
