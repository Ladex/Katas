using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace StringCalculatorKata
{
    [TestClass]
    public class StringCalculator_Kata
    {
        private StringCalculator sc = null;
        [TestInitialize]
        public void SetUp()
        {
            sc = new StringCalculator();
        }

        [TestMethod]
        public void Add_EmptyString_ReturnZero()
        {
            Assert.AreEqual(0, sc.Add(string.Empty));
        }


        [TestMethod]
        public void Add_OneNumber_ReturnsSum()
        {
            Assert.AreEqual(1, sc.Add("1"));
        }

        [TestMethod]
        public void Add_OneTwo_ReturnSum()
        {
            Assert.AreEqual(3, sc.Add("1,2"));
        }

        [TestMethod]
        public void Add_MultipleNumbersWithNewLineDelimiter_ReturnsSum()
        {
            Assert.AreEqual(10, sc.Add("1\n2\n3\n4"));
        }

        [TestMethod]
        public void Add_MultipleNumbersWithDelimiterIndicator_ReturnsSum()
        {
            Assert.AreEqual(15, sc.Add("//;\n1;2;3;4;5"));
        }

        [TestMethod]
        public void Add_MultipleNumbersWithMultipleDelimiters_ReturnSums()
        {
            Assert.AreEqual(15, sc.Add("//;;;\n1;;;2;;;3;;;4;;;5"));
        }


        [TestMethod]
        public void Add_IgnoreNumberOverAThousand_ReturnSum()
        {
            Assert.AreEqual(15, sc.Add("//;;;\n1;;;2;;;3;;;4;;;5;;;2000"));
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_NegativeNumbersNotAllowed_ThrowException()
        {
            Assert.AreEqual(15, sc.Add("//;;;\n1;;;2;;;3;;;4;;;5;;;-2000"));
        }
    }
}
