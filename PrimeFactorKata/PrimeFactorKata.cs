using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PrimeFactorKata
{
    [TestClass]
    public class PrimeFactorsTest
    {
        private List<int> list(params int[] ints)
        {
            List<int> list = new List<int>();

            foreach (var item in ints)
                list.Add(item);

            return list;
        }

        [TestMethod]
        public void Generate_WithOne_ReturnPrimeFactors()
        {
            CollectionAssert.AreEqual(list(), PrimeFactors.Generate(1));
        }

        [TestMethod]
        public void Generate_WithTwo_ReturnPrimeFactors()
        {
            CollectionAssert.AreEqual(list(2), PrimeFactors.Generate(2));
        }

        [TestMethod]
        public void Generate_WithThree_ReturnPrimeFactors()
        {
            CollectionAssert.AreEqual(list(3), PrimeFactors.Generate(3));
        }

        [TestMethod]
        public void Generate_WithFour_ReturnPrimeFacors()
        {
            CollectionAssert.AreEqual(list(2, 2), PrimeFactors.Generate(4));
        }

        [TestMethod]
        public void Generate_WithSix_ReturnPrimeFactors()
        {
            CollectionAssert.AreEqual(list(2, 3), PrimeFactors.Generate(6));
        }

        [TestMethod]
        public void Generate_WithEight_ReturnPrimeFactors()
        {
            CollectionAssert.AreEqual(list(2, 2, 2), PrimeFactors.Generate(8));
        }

        [TestMethod]
        public void Generate_WithNine_ReturnPrimeFactor()
        {
            CollectionAssert.AreEqual(list(3, 3), PrimeFactors.Generate(9));
        }

        [TestMethod]
        public void Generate_WithThreeSixty_ReturnPrimeFactor()
        {
            CollectionAssert.AreEqual(list(2, 2, 2, 3, 3, 5), PrimeFactors.Generate(360));
        }
    }


    public static class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            List<int> primes = new List<int>();
            int candidate = 2;

            while (number > 1)
            {
                while (number % candidate == 0)
                {
                    primes.Add(candidate);
                    number /= candidate;
                }

                candidate++;
            }

            if (number > 1)
                primes.Add(number);
            return primes;
        }
    }
}
