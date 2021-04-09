using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    public class SubtractionTests
    {
        [TestMethod]
        public void IntegerSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(4, calculator.Process("5-1", out _));
            Assert.AreEqual(-6, calculator.Process("-5-1", out _));
            Assert.AreEqual(-4, calculator.Process("-5 - -1", out _));
            Assert.AreEqual(-4, calculator.Process("-5--1", out _));
        }

        [TestMethod]
        public void DoubleSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(4.0, calculator.Process("5.0-1.0", out _));
        }
    }
}
