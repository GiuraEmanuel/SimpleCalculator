using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    class Calculator
    {
        public string ProcessInput(string input)
        {
            var enteredInput = int.Parse(input);

            return (enteredInput + enteredInput).ToString();
        }
    }
}
