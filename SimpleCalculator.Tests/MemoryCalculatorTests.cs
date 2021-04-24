using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual(5, calculator.Process("save M125332323", out string message));
            Assert.AreEqual("Saved value 5 into memory slot 125332323.", message);
            Assert.AreEqual(5, calculator.Process("M125332323", out _));

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
