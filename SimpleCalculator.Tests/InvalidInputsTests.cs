using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    public class InvalidInputsTests
    {
        [TestMethod]
        public void InvalidInputs_ThrowsFormatException()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-6, calculator.Process("-5 + -1", out _));
        }
    }
}
