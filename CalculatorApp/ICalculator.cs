using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public interface ICalculator
    {
        double? Process(string input, out string message);
    }
}
