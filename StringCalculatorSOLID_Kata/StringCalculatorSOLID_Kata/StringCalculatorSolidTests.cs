using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace StringCalculatorSOLID_Kata
{
    [TestClass]
    public class StringCalculatorKata
    {
        private StringCalculator stringCalculator;

        [TestInitialize]
        public void SetUp()
        {
            Func<int, int> nonNegativeNumbers = x =>
            {
                if (x < 0) throw new InvalidOperationException();
                return x;
            };

            Func<int, int> ignoreGreaterThanOneThousandRule = number => number > 1000 ? 0 : number;

            ICalculatorRule rule = new CalculatorRule(new List<Func<int, int>> { nonNegativeNumbers, ignoreGreaterThanOneThousandRule });
            ICalculatorStringParser parser = new CalculatorStringParser(rule);
            stringCalculator = new StringCalculator(parser);
        }

        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, stringCalculator.Add(string.Empty));
        }


        [TestMethod]
        public void Add_One_ReturnSum()
        {
            Assert.AreEqual(1, stringCalculator.Add("1"));
        }


        [TestMethod]
        public void Add_MultipleNumber_ReturnSum()
        {
            Assert.AreEqual(2, stringCalculator.Add("1,1"));
        }

        [TestMethod]
        public void Add_MultipleNUmbers_ReturnSum()
        {
            Assert.AreEqual(5, stringCalculator.Add("1,4"));
        }

        [TestMethod]
        public void Add_MultipleNumbersIgnoreThounsands_ReturnSum()
        {
            Assert.AreEqual(10, stringCalculator.Add("1,2,3,4,1002"));
        }

        [TestMethod]
        public void Add_MultipleNumbersWithSemiColonDelimiter_ReturnSum()
        {
            Assert.AreEqual(10, stringCalculator.Add("1;2;3;4"));
        }


        [TestMethod]
        public void Add_MultipleNumbersWithNewLineDelimiter_ReturnSum()
        {
            Assert.AreEqual(10, stringCalculator.Add("1\n2\n3\n4"));
        }


        [TestMethod]
        public void Add_MultipleNUmbersWithDelimiterIndicator_ReturnSum()
        {
            Assert.AreEqual(15, stringCalculator.Add("//a\n1a2a3a4a5"));
        }

        [TestMethod]
        public void Add_MultipleNumbersWithMultipleDelimiters_ReturnSum()
        {
            Assert.AreEqual(10, stringCalculator.Add("//aaa\n1aaa2aaa3aaa4"));
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_NoNEgativeNumbersAllowed_ThrowException()
        {
            Assert.AreEqual(0, stringCalculator.Add("1;2;-3"));
        }
    }



}
