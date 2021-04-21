using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Tests
{
    public static class TestHelper
    {
        public static ICalculator CreateFullCalculator() => new MemoryCalculator(new Calculator());
    }
}
