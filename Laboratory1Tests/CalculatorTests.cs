using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratory1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void EvaluateTestDiv()
        {
            Calculator calculator = new Calculator(new DataGridView());
            Assert.AreEqual(calculator.Evaluate("0 div 200"), 0);
            Assert.AreEqual(calculator.Evaluate("200 div 5"), 40);
            Assert.AreEqual(calculator.Evaluate("10 div 8"), 1);
            Assert.AreEqual(calculator.Evaluate("10 div -2"), -5);
            Assert.AreEqual(calculator.Evaluate("10 div 3"), 3);
        }

        [TestMethod()]
        public void EvaluateTest()
        {
            Calculator calculator = new Calculator(new DataGridView());

            Assert.IsTrue(calculator.Evaluate("13 = 13") == 1);
            Assert.IsTrue(calculator.Evaluate("13 > 12") == 1);
            Assert.IsTrue(calculator.Evaluate("12 < 13") == 1);
            Assert.IsTrue(calculator.Evaluate("(13 = 13) > (13 < 12)") == 1);
        }
        [TestMethod()]
        public void EvaluateTestMod()
        {
            Calculator calculator = new Calculator(new DataGridView());
            Assert.AreEqual(calculator.Evaluate("12 mod 2"), 0);
            Assert.AreEqual(calculator.Evaluate("13 mod 2"), 1);
            Assert.IsTrue(Math.Abs(calculator.Evaluate("13.1 mod 2") - 1.1) < 0.1);
            Assert.AreEqual(calculator.Evaluate("0 mod 2"), 0);
            Assert.AreEqual(calculator.Evaluate("13 mod -2"), 1);
        }
    }
}