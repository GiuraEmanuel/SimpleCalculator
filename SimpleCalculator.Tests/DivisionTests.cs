﻿using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void IntegerDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(5 / 5, calculator.Process("5/5", out _));
            Assert.AreEqual(1.0 / 5, calculator.Process("1/5", out _));
            Assert.AreEqual(1000 / 10, calculator.Process("1000/10", out _));
        }

        [TestMethod]
        public void IntegerDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-5 / -1, calculator.Process("-5 / -1", out _));
            Assert.AreEqual(-999 / 3, calculator.Process("-999 / 3", out _));
            Assert.AreEqual(32 / -4, calculator.Process("32/-4", out _));
        }

        [TestMethod]
        public void DoubleDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1.0 / 5.0, calculator.Process("1.0/5.0", out _));
            Assert.AreEqual(5.555 / 55.55555, calculator.Process("5.555/55.55555", out _));
            Assert.AreEqual(0.999 / 0.333, calculator.Process("0.999/0.333", out _));

        }

        [TestMethod]
        public void DoubleDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-1.0 / -5.0, calculator.Process("-1.0/-5.0", out _));
            Assert.AreEqual(-5.555 / 55.55555, calculator.Process("-5.555/55.55555", out _));
            Assert.AreEqual(0.999 / -0.333, calculator.Process("0.999/-0.333", out _));

        }


        [TestMethod]
        public void DivisionByZero()
        {
            Calculator calculator = new Calculator();

            Assert.ThrowsException<DivideByZeroException>(() => calculator.Process("1/0", out _));
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Process("1.0/0.0", out _));
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Process("1.000/0.000", out _));
        }
    }
}
