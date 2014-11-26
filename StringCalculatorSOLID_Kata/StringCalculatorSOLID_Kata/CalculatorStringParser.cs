using System;
using System.Collections.Generic;

namespace StringCalculatorSOLID_Kata
{
    public class CalculatorStringParser : ICalculatorStringParser
    {
        private const int DefaultValue = 0;

        public CalculatorStringParser() { }

        private readonly ICalculatorRule calculatorRule;
        public CalculatorStringParser(ICalculatorRule ruleFactory)
        {
            calculatorRule = ruleFactory;
        }

        public int[] Parse(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString)) return new int[] { DefaultValue };

            var delimiters = new List<string>() { ",", ";", "\n" };

            if (HasDelimiterIndicator(numberString))
            {
                var newDelimiter = numberString.Substring(StartOfDelimiter(numberString), DelimiterLength(numberString));

                if (!delimiters.Contains(newDelimiter))
                    delimiters.Add(newDelimiter);

                numberString = RetrieveNumberString(numberString);
            }

            var stringCollection = numberString.Split(delimiters.ToArray(), StringSplitOptions.None);

            var intCollection = Array.ConvertAll(stringCollection, Convert.ToInt32);

            var numbers = calculatorRule.ApplyRules(intCollection);

            return numbers;
        }

        private static int DelimiterLength(string numberString)
        {
            return numberString.IndexOf('\n') - (numberString.LastIndexOf('/') + 1);
        }

        private static int StartOfDelimiter(string numberString)
        {
            return numberString.LastIndexOf('/') + 1;
        }

        private static string RetrieveNumberString(string numberString)
        {
            numberString = numberString.Substring(numberString.IndexOf('\n') + 1);
            return numberString;
        }

        private static bool HasDelimiterIndicator(string numberString)
        {
            return numberString.StartsWith("//");
        }

    }
}
