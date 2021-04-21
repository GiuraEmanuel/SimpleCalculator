using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public class MemoryCalculator : ICalculator
    {
        private ICalculator _calculator;
        public MemoryCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public double Process(string input, out string message)
        {
            throw new NotImplementedException();
        }
    }
}
