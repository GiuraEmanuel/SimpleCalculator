using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void IntegerSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10, calculator.Process("5+5", out _));
            Assert.AreEqual(4, calculator.Process("-1+5", out _));
            Assert.AreEqual(1010, calculator.Process("10+1000", out _));
        }

        [TestMethod]
        public void DoubleSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(6.0, calculator.Process("1.0+5.0", out _));
            Assert.AreEqual(555555561.111, calculator.Process("5.55555555555+555555555.55555", out _));
            Assert.AreEqual(24.299249829, calculator.Process("11.999+12.3002498290", out _));

        }

        [TestMethod]
        public void IntegerSubtractionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-6, calculator.Process("-5 + -1", out _));
            Assert.AreEqual(-53323, calculator.Process("-999 + -52324", out _));
            Assert.AreEqual(-1998, calculator.Process("-999 + -999", out _));
        }

        [TestMethod]
        public void DecimalSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(725.14M, calculator.Process("475.05 + 250.09", out _));
            Assert.AreEqual(100.05M, calculator.Process("45.15 + 54.9", out _));
            Assert.AreEqual(1.25M, calculator.Process("0.50 + 0.75", out _));
        }

        [TestMethod]
        public void DecimalSubtractionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-725.14M, calculator.Process("-475.05 + -250.09", out _));
            Assert.AreEqual(9.75M, calculator.Process("-45.15M + 54.9", out _));
            Assert.AreEqual(-0.25M, calculator.Process("0.50M + -0.75", out _));
        }


        [TestMethod]
        public void FloatSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(725.14F, calculator.Process("475.05 + 250.09", out _));
            Assert.AreEqual(100.05F, calculator.Process("45.15 + 54.9", out _));
            Assert.AreEqual(1.25F, calculator.Process("0.50 + 0.75", out _));
        }

        public void FloatSubtractionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-725.14F, calculator.Process("-475.05 + -250.09", out _));
            Assert.AreEqual(9.75F, calculator.Process("-45.15 + 54.9", out _));
            Assert.AreEqual(-0.25F, calculator.Process("0.50 + -0.75", out _));
        }
    }
}
