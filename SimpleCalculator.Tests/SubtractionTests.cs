using CalculatorApp;
using CalculatorApp.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void IntegerSubtraction()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5 - 5, calculator.Process("5-5", out _));
            Assert.AreEqual(25 - 15, calculator.Process("25-15", out _));
            Assert.AreEqual(1000 - 10, calculator.Process("1000-10", out _));
        }

        [TestMethod]
        public void IntegerSubtractionWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-5 - -5, calculator.Process("-5 - -5", out _));
            Assert.AreEqual(-25 - 15, calculator.Process("-25-15", out _));
            Assert.AreEqual(1000 - -10, calculator.Process("1000 - -10", out _));
        }

        [TestMethod]
        public void DoubleSubtraction()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(1.0 - 5.0, calculator.Process("1.0-5.0", out _));
            Assert.AreEqual(2.535 - 1.345, calculator.Process("2.535-1.345", out _));
            Assert.AreEqual(15.2357 - 10.5336, calculator.Process("15.2357-10.5336", out _));

        }

        [TestMethod]
        public void DoubleSubtractionWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-1.0 - -5.0, calculator.Process("-1.0 - -5.0", out _));
            Assert.AreEqual(-2.535 - 1.345, calculator.Process("-2.535-1.345", out _));
            Assert.AreEqual(15.2357 - -10.5336, calculator.Process("15.2357 - -10.5336", out _));
        }
    }
}
