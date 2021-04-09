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
        public void IntegerAdditionWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(-6, calculator.Process("-5 + -1", out _));
        }
    }
}
