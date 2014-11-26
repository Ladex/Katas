using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzTests
    {
        FizzBuzz fb;

        [TestInitialize]
        public void SetUp()
        {
            fb = new FizzBuzz();
        }


        [TestMethod]
        public void Generate_WithZero_ReturnZero()
        {
            Assert.AreEqual(string.Empty, fb.Generate(0));
        }

        [TestMethod]
        public void Generate_WithTwo_ReturnText()
        {
            Assert.AreEqual("1 2", fb.Generate(2));
        }

        [TestMethod]
        public void Generate_WithThree_ReturnText()
        {
            Assert.AreEqual("1 2 Fizz", fb.Generate(3));
        }

        [TestMethod]
        public void Generate_WithSix_ReturnText()
        {
            Assert.AreEqual("1 2 Fizz 4 Buzz Fizz", fb.Generate(6));
        }

        [TestMethod]
        public void Generate_WithSixteen_ReturnText()
        {
            Assert.AreEqual("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16", fb.Generate(16));
        }
    }

    class FizzBuzz
    {
        internal string Generate(int p)
        {
            string str = string.Empty;
            if (IsZero(p)) return string.Empty;

            for (int i = 1; i < p + 1; i++)
            {
                if (IsDivisibleByFive(i) && IsDivisibleByThree(i))
                {
                    str = AppendFizzBuzz(str);
                }
                else if (IsDivisibleByThree(i))
                {
                    str = AppendFizz(str);
                }
                else if (IsDivisibleByFive(i))
                {
                    str = AppendBuzz(str);
                }
                else
                {
                    str = Append(str, i);
                }
            }

            return str.TrimEnd();
        }

        private static string AppendFizzBuzz(string str)
        {
            str += "FizzBuzz";
            str += " ";
            return str;
        }

        private static string Append(string str, int i)
        {
            str += i.ToString();
            str += " ";
            return str;
        }

        private static string AppendBuzz(string str)
        {
            str += "Buzz";
            str += " ";
            return str;
        }

        private static string AppendFizz(string str)
        {
            str += "Fizz";
            str += " ";
            return str;
        }

        private static bool IsDivisibleByFive(int i)
        {
            return i % 5 == 0;
        }

        private static bool IsDivisibleByThree(int i)
        {
            return i % 3 == 0;
        }

        private static bool IsZero(int p)
        {
            return p <= 0;
        }
    }
}
