using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RomanNumeralKata
{
    [TestClass]
    public class RomanNumeralKata
    {
        RomanNumeralConverter rc = null;
        [TestInitialize]
        public void SetUp()
        {
            rc = new RomanNumeralConverter();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Convert_EmptyString_ThrowsException()
        {
            Assert.AreEqual(0, rc.Convert(""));
        }

        [TestMethod]
        public void Convert_One_ToArabic()
        {
            Assert.AreEqual(1, rc.Convert("I"));
        }


        [TestMethod]
        public void Convert_Two_ToArabic()
        {
            Assert.AreEqual(2, rc.Convert("II"));
        }


        [TestMethod]
        public void Convert_Four_ToArabic()
        {
            Assert.AreEqual(4, rc.Convert("IV"));
        }

        [TestMethod]
        public void Convert_Ten_ToArabic()
        {
            Assert.AreEqual(10, rc.Convert("X"));
        }

        [TestMethod]
        public void Convert_Nine_ToArabic()
        {
            Assert.AreEqual(9, rc.Convert("IX"));
        }

        [TestMethod]
        public void Convert_FourtyNine_ToArabic()
        {
            Assert.AreEqual(49, rc.Convert("XLIX"));
        }
    }




    public class RomanNumeralConverter
    {
        Dictionary<char, int> map = new Dictionary<char, int>() 
        {{ 'I', 1 }, 
        { 'V', 5 }, 
        { 'X', 10 }, 
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 }, 
        { 'M', 1000 }};

        public int Convert(string numerals)
        {
            if (IsNullOrEmpty(numerals)) HandleNullArgments();

            int total = 0;
            int minus = 0;
            var charaters = numerals.ToCharArray();

            //XLIX

            for (int i = 0; i < charaters.Length; i++)
            {
                int thisNumeral = map[charaters[i]] - minus;

                if (IsLastCharacterInString(charaters, i) || IsCurrentNumeralGreaterThanOrEqualTheNext(minus, charaters, i, thisNumeral))
                {
                    total = AddCurrentToTotal(total, thisNumeral);
                    minus = ResetMinus(minus);
                }
                else
                {
                    minus = thisNumeral;
                }
            }

            return total;

           
        }

        private static int ResetMinus(int minus)
        {
            minus = 0;
            return minus;
        }

        private static int AddCurrentToTotal(int total, int thisNumeral)
        {
            total += thisNumeral;
            return total;
        }

        private bool IsCurrentNumeralGreaterThanOrEqualTheNext(int minus, char[] charaters, int i, int thisNumeral)
        {
            return thisNumeral + minus >= map[charaters[i + 1]];
        }

        private static bool IsLastCharacterInString(char[] charaters, int i)
        {
            return i >= charaters.Length - 1;
        }

        private static void HandleNullArgments()
        {
            throw new ArgumentNullException("numerals");
        }

        private static bool IsNullOrEmpty(string numerals)
        {
            return string.IsNullOrWhiteSpace(numerals);
        }
    }
}
