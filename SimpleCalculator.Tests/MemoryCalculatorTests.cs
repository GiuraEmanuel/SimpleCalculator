using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class MemoryCalculatorTests
    {
        [TestMethod]
        public void StoreAndRecallLastResult()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5, calculator.Process("5", out _));
            Assert.AreEqual(5, calculator.Process("save M1", out string message));
            Assert.AreEqual("Saved value 5 into memory slot 1.", message);
            Assert.AreEqual(6, calculator.Process("6", out _)); 
            Assert.AreEqual(5, calculator.Process("M1", out _));
            Assert.AreEqual(0, calculator.Process("clear M1", out message));
            Assert.AreEqual("Slot M1 has been cleared.", message);
            Assert.AreEqual(0, calculator.Process("clear all", out _));
            Assert.AreEqual("Cleared all memory slots.", message);
        }

        [TestMethod]
        public void SingleValueWithNoOperator()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(1, calculator.Process("1", out _));
            Assert.AreEqual(-1, calculator.Process("-1", out _));
        }
    }
}
