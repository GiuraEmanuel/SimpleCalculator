using CalculatorApp;
using CalculatorApp.Tests;
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
            var calculator = TestHelper.CreateFullCalculator();

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
            Assert.ThrowsException<FormatException>(() => calculator.Process("1 2 3 + 4 5 6", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process(" 1+2", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process("1+2 ", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process(" 1+2 ", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process(" 1 +  2 ", out _));
            Assert.ThrowsException<FormatException>(() => calculator.Process(" 1  + 2 ", out _));
        }
    }


}
