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
            Assert.AreEqual(5, calculator.Process("clear M1", out message));
            Assert.AreEqual("Memory slot 1 has been cleared.", message);
            Assert.AreEqual(null, calculator.Process("clear all", out message));
            Assert.AreEqual("Cleared all memory slots.", message);

        }

        [TestMethod]
        public void OveriddingValues()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5, calculator.Process("5", out _));
            Assert.AreEqual(5, calculator.Process("save M1", out string message));
            Assert.AreEqual("Saved value 5 into memory slot 1.", message);
            Assert.AreEqual(6, calculator.Process("6", out _));
            Assert.AreEqual(6, calculator.Process("save M1", out message));
            Assert.AreEqual("Saved value 6 into memory slot 1.", message);

        }

        [TestMethod]
        public void SlotClearing()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5, calculator.Process("5", out _));
            Assert.AreEqual(5, calculator.Process("save M1", out string message));
            Assert.AreEqual("Saved value 5 into memory slot 1.", message);
            Assert.AreEqual(6, calculator.Process("6", out _));
            Assert.AreEqual(5, calculator.Process("clear M1", out message));
            Assert.AreEqual("Memory slot 1 has been cleared.", message);

        }

        [TestMethod]
        public void SingleValueWithNoOperator()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(1, calculator.Process("1", out _));
            Assert.AreEqual(-1, calculator.Process("-1", out _));
        }

        [TestMethod]
        public void CalculationsWithRecalledValues()
        {
            var calculator = TestHelper.CreateFullCalculator();

            Assert.AreEqual(5, calculator.Process("5", out _));
            Assert.AreEqual(5, calculator.Process("save M1", out string message));
            Assert.AreEqual("Saved value 5 into memory slot 1.", message);
            Assert.AreEqual(7, calculator.Process("7", out _));
            Assert.AreEqual(7, calculator.Process("save M2", out message));
            Assert.AreEqual("Saved value 7 into memory slot 2.", message);
            Assert.AreEqual(11, calculator.Process("M1 + 6", out _));
            Assert.AreEqual(15, calculator.Process("8 + M2", out _));
            Assert.AreEqual(12, calculator.Process("M1 + M2", out _));
        }
    }
}
