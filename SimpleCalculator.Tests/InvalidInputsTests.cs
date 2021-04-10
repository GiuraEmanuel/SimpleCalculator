using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Tests
{
    public class InvalidInputsTests
    {
        [TestMethod]
        public void InvalidInputs_ThrowsFormatException()
        {
            Calculator calculator = new Calculator();

            Assert.ThrowsException<FormatException>(() => calculator.Process("a", out _));
        }
    }
}
