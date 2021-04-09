using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    public class DivisionTests
    {
        [TestMethod]
        public void IntegerDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(3, calculator.Process("6/2", out _));
        }

        [TestMethod]
        public void DoubleDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(2.0, calculator.Process("6.0/3.0", out _));
        }

        [TestMethod]
        public void IntegerDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(5, calculator.Process("-5 / -1", out _));
        }
    }
}
