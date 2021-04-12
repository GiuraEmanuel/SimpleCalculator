using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void IntegerDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1, calculator.Process("5/5", out _));
            Assert.AreEqual(4, calculator.Process("-1/5", out _));
            Assert.AreEqual(100, calculator.Process("1000/10", out _));
        }

        [TestMethod]
        public void DoubleDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(0.2, calculator.Process("1.0/5.0", out _));
            Assert.AreEqual(0.09999000999, calculator.Process("5.555/55.55555", out _));
            Assert.AreEqual(3, calculator.Process("0.999/0.333", out _));

        }

        [TestMethod]
        public void IntegerDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(5, calculator.Process("-5 / -1", out _));
            Assert.AreEqual(-333, calculator.Process("-999 / 3", out _));
            Assert.AreEqual(-8, calculator.Process("32/-4", out _));
        }

        [TestMethod]
        public void DecimalDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1.07M, calculator.Process("0.535 / 0.5", out _));
            Assert.AreEqual(8.57894736842M, calculator.Process("81.5/9.5", out _));
            Assert.AreEqual(2.05174545455M, calculator.Process("5.6423 / 2.75", out _));
        }

        [TestMethod]
        public void DecimalDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1.07M, calculator.Process("-0.535 / -0.5", out _));
            Assert.AreEqual(-8.57894736842M, calculator.Process("-81.5/9.5", out _));
            Assert.AreEqual(-2.05174545455M, calculator.Process("5.6423 / -2.75", out _));
        }


        [TestMethod]
        public void FloatDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1.4F, calculator.Process("3.5/2.5", out _));
            Assert.AreEqual(4.73684210526F, calculator.Process("45.0/9.5", out _));
            Assert.AreEqual(4.67791411043F, calculator.Process("15.25/3.26", out _));
        }

        public void FloatDivisionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1.4F, calculator.Process("-3.5/-2.5", out _));
            Assert.AreEqual(-4.73684210526F, calculator.Process("-45.0/9.5", out _));
            Assert.AreEqual(-4.67791411043F, calculator.Process("15.25/-3.26", out _));
        }
    }
}
