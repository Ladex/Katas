using System.Linq;

namespace StringCalculatorSOLID_Kata
{

    public class StringCalculator
    {
        private readonly ICalculatorStringParser stringParser;

        public StringCalculator(ICalculatorStringParser parser)
        {
            stringParser = parser;
        }

        internal int Add(string numberString)
        {
            var numbers = stringParser.Parse(numberString);
            return numbers.Sum();
        }
    }
}
