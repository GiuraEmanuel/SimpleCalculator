using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class MemoryCalculator : ICalculator
    {
        private ICalculator _calculator;

        private Dictionary<UInt32, double> savedValues = new Dictionary<UInt32, double>();

        public MemoryCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public double Process(string input, out string message)
        {
            if (input.StartsWith("save M", StringComparison.OrdinalIgnoreCase))
            {
                
            }
            var result = _calculator.Process(input, out message);
            return result;
        }
    }
}
