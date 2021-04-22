using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void IntegerAddition()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5, calculator.Process("1+4", out _));
            Assert.AreEqual(32879283 + 32879283, calculator.Process("32879283 + 32879283", out _));
            Assert.AreEqual(10 + 1000, calculator.Process("10+1000", out _));

        }

        [TestMethod]
        public void IntegerAdditionWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-5 + -1, calculator.Process("-5 + -1", out _));
            Assert.AreEqual(-999 + -52324, calculator.Process("-999 + -52324", out _));
            Assert.AreEqual(-999 + -999, calculator.Process("-999 + -999", out _));
        }

        [TestMethod]
        public void DoubleAddition()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(1.0 + 5.0, calculator.Process("1.0+5.0", out _));
            Assert.AreEqual(5.55555555555 + 555555555.55555, calculator.Process("5.55555555555+555555555.55555", out _));
            Assert.AreEqual(11.999 + 12.3002498290, calculator.Process("11.999+12.3002498290", out _));
        }

        [TestMethod]
        public void DoubleAdditionWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-1.0 + -5.0, calculator.Process("-1.0 + -5.0", out _));
            Assert.AreEqual(-5.555 + 5.0, calculator.Process("-5.555 + 5.0", out _));
            Assert.AreEqual(11.999 + -12.3002498290, calculator.Process("11.999 + -12.3002498290", out _));
        }

        [TestMethod]
        public void ExtraSpaces()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(6 + 2, calculator.Process(" 6+2", out _));
            Assert.AreEqual(6 + 2, calculator.Process("6+2 ", out _));
            Assert.AreEqual(6 + 2, calculator.Process(" 6+2 ", out _));
            Assert.AreEqual(6 + 2, calculator.Process(" 6 +  2 ", out _));
            Assert.AreEqual(6 + 2, calculator.Process(" 6  + 2 ", out _));
        }
    }
}
