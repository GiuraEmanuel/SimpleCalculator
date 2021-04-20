using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class MemorySaveFeatureTests
    {
        [TestMethod]
        public void SaveToMemory()
        {
            
        }

        [TestMethod]
        public void SingleValueWithNoOperator()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(1, calculator.Process("1", out _));
            Assert.AreEqual(-1, calculator.Process("-1", out _));
        }
    }
}
