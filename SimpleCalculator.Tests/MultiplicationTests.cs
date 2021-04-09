using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    public class MultiplicationTests
    {
        [TestMethod]
        public void IntegerMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10, calculator.Process("5x2", out _));
        }

        [TestMethod]
        public void DoubleMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10.0, calculator.Process("5.0x2.0", out _));
        }

        [TestMethod]
        public void IntegerMultiplicationWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(5, calculator.Process("-5 x -1", out _));
        }
    }
}
