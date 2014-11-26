using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const string newLineDelimiter = "\n";
        private const string commaDelimiter = ",";
        private const int ZERO = 0;
        internal int Add(string numbers)
        {

            if (IsEmpty(numbers)) return ZERO;

            List<string> delimiters = new List<string> { commaDelimiter, newLineDelimiter };

            if (HasDelimiterIndicator(numbers))
            {
                var customDeleimiter = GetDelimiter(numbers);
                AddDelimiter(delimiters, customDeleimiter);
                numbers = GetNumberString(numbers);
            }

            var values = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            int total = CalculateTotal(values);

            return total;
        }

        private static string GetNumberString(string numbers)
        {
            numbers = numbers.Substring(numbers.IndexOf(newLineDelimiter) + 1);
            return numbers;
        }

        private static bool HasDelimiterIndicator(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static void AddDelimiter(List<string> delimiters, string customDeleimiter)
        {
            if (!delimiters.Contains(customDeleimiter))
                delimiters.Add(customDeleimiter);
        }

        private static string GetDelimiter(string numbers)
        {
            var customDeleimiter = numbers.Substring(numbers.LastIndexOf('/') + 1, numbers.LastIndexOf('\n') - (numbers.LastIndexOf('/') + 1));
            return customDeleimiter;
        }

        private static int CalculateTotal(string[] values)
        {
            int total = 0;
            foreach (var item in values)
            {
                var number = int.Parse(item);
                if (IsNegativeNumber(number)) HandleNegativeNumbers();
                if (GreaterThanOneThousand(number)) continue;
                total += number;
            }
            return total;
        }

        private static void HandleNegativeNumbers()
        {
            throw new InvalidOperationException("Negative numbers not allowed");
        }

        private static bool IsNegativeNumber(int number)
        {
            return number < 0;
        }

        private static bool GreaterThanOneThousand(int number)
        {
            return number > 1000;
        }

        private static bool IsEmpty(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }
    }
}
