using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void IntegerMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(25, calculator.Process("5x5", out _));
            Assert.AreEqual(100, calculator.Process("20x5", out _));
            Assert.AreEqual(10000, calculator.Process("1000x10", out _));
        }

        [TestMethod]
        public void IntegerMultiplicationWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(25, calculator.Process("-5x-5", out _));
            Assert.AreEqual(-100, calculator.Process("-20x5", out _));
            Assert.AreEqual(-10000, calculator.Process("1000x-10", out _));
        }

        [TestMethod]
        public void DoubleMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(6.0, calculator.Process("1.0+5.0", out _));
            Assert.AreEqual(555555561.111, calculator.Process("5.55555555555+555555555.55555", out _));
            Assert.AreEqual(24.299249829, calculator.Process("11.999+12.3002498290", out _));

        }

        [TestMethod]
        public void DoubleMultiplicationWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(4.0, calculator.Process("-1.0 + -5.0", out _));
            Assert.AreEqual(-0.555, calculator.Process("-5.555 + 5.0", out _));
            Assert.AreEqual(-0.301249829, calculator.Process("11.999 + -12.3002498290", out _));
        }

        [TestMethod]
        public void DecimalMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(725.14M, calculator.Process("475.05 + 250.09", out _));
            Assert.AreEqual(100.05M, calculator.Process("45.15 + 54.9", out _));
            Assert.AreEqual(1.25M, calculator.Process("0.50 + 0.75", out _));
        }

        [TestMethod]
        public void DecimalMultiplicationWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-725.14M, calculator.Process("-475.05 + -250.09", out _));
            Assert.AreEqual(9.75M, calculator.Process("-45.15M + 54.9", out _));
            Assert.AreEqual(-0.25M, calculator.Process("0.50M + -0.75", out _));
        }


        [TestMethod]
        public void FloatMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(725.14F, calculator.Process("475.05 + 250.09", out _));
            Assert.AreEqual(100.05F, calculator.Process("45.15 + 54.9", out _));
            Assert.AreEqual(1.25F, calculator.Process("0.50 + 0.75", out _));
        }

        public void FloatMultiplicationWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-725.14F, calculator.Process("-475.05 + -250.09", out _));
            Assert.AreEqual(9.75F, calculator.Process("-45.15 + 54.9", out _));
            Assert.AreEqual(-0.25F, calculator.Process("0.50 + -0.75", out _));
        }
    }
}
