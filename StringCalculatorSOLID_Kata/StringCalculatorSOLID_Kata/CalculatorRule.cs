using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorSOLID_Kata
{
    public class CalculatorRule : ICalculatorRule
    {
        private readonly List<Func<int, int>> rules;
        public CalculatorRule(List<Func<int, int>> rule)
        {
            rules = rule;
        }

        public int[] ApplyRules(int[] intCollection)
        {
            return intCollection.Select(item => rules.Aggregate(item, (current, rule) => rule(current))).ToArray();
        }
    }
}
