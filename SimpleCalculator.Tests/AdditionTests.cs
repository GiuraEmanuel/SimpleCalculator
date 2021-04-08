using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void IntegerAddition()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10, calculator.Process("5+5", out _));
            Assert.AreEqual(4, calculator.Process("-1+5", out _));
            Assert.AreEqual(1010, calculator.Process("10+1000", out _));
        }

        [TestMethod]
        public void DoubleAddition()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(6.0, calculator.Process("1.0+5.0", out _));
        }

        [TestMethod]
        public void IntegerSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(4, calculator.Process("5~1", out _));
        }

        [TestMethod]
        public void DoubleSubtraction()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(4.0, calculator.Process("5.0~1.0", out _));
        }

        [TestMethod]
        public void IntegerDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(3, calculator.Process("6/2", out _));
        }

        [TestMethod]
        public void DoubleDivision()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(2.0, calculator.Process("6.0/3.0", out _));
        }

        [TestMethod]
        public void IntegerMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10, calculator.Process("5x2", out _));
        }

        [TestMethod]
        public void DoubleMultiplication()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(10.0, calculator.Process("5.0x2.0", out _));
        }
    }
}
