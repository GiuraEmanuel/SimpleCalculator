using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class InvalidInputsTests
    {
        [TestMethod]
        public void InvalidInputs_ThrowsFormatException()
        {
            Calculator calculator = new Calculator();

            Assert.ThrowsException<FormatException>(() => calculator.Process("a + 1", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("a + a", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("a1 + 5", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("a1 + a2", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process(" + ", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("+ + +", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("2 + X", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("2 5 + 3X5", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("9+ ", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("+ 9", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("", out _));
        }
    }


}
