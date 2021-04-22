using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void IntegerMultiplication()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5*5, calculator.Process("5x5", out _));
            Assert.AreEqual(20*5, calculator.Process("20x5", out _));
            Assert.AreEqual(1000*10, calculator.Process("1000x10", out _));
        }

        [TestMethod]
        public void IntegerMultiplicationWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-5* - 5, calculator.Process("-5x-5", out _));
            Assert.AreEqual(-20*5, calculator.Process("-20x5", out _));
            Assert.AreEqual(1000* - 10, calculator.Process("1000x-10", out _));
        }

        [TestMethod]
        public void DoubleMultiplication()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(1.0 * 5.0, calculator.Process("1.0x5.0", out _));
            Assert.AreEqual(5.55555555555 * 555555555.55555, calculator.Process("5.55555555555x555555555.55555", out _));
            Assert.AreEqual(11.999 * 12.3002498290, calculator.Process("11.999x12.3002498290", out _));

        }

        [TestMethod]
        public void DoubleMultiplicationWithNegativeNumbers()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(-1.0 * - 5.0, calculator.Process("-1.0 x -5.0", out _));
            Assert.AreEqual(-5.555 * 5.0, calculator.Process("-5.555 x 5.0", out _));
            Assert.AreEqual(11.999 * - 12.3002498290, calculator.Process("11.999 x -12.3002498290", out _));
        }

        [TestMethod]
        public void ExtraSpaces()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(6 * 2, calculator.Process(" 6*2", out _));
            Assert.AreEqual(6 * 2, calculator.Process("6*2 ", out _));
            Assert.AreEqual(6 * 2, calculator.Process(" 6*2 ", out _));
            Assert.AreEqual(6 * 2, calculator.Process(" 6 *  2 ", out _));
            Assert.AreEqual(6 * 2, calculator.Process(" 6  * 2 ", out _));
        }

    }
}
