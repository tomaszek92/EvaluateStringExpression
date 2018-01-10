using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluateStringExpression.ConsoleApp
{
    public static class StringExpressionChecker
    {
        private static readonly IReadOnlyCollection<char> AllowedMathematicOperations =
            new List<char> {'+', '-', '/', '*'};

        public static bool IsValid(string expression)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                Console.WriteLine("Expression cannot be empty.");
                return false;
            }

            List<string> possibleNumbers = new List<string>();
            List<char> mathOperations = new List<char>();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (i == 0 || i == expression.Length - 1)
                {
                    if (Char.IsDigit(c))
                    {
                        stringBuilder.Append(c);
                        continue;
                    }

                    Console.WriteLine("Expresssion has to start and end with digit.");
                    return false;
                }

                if (Char.IsDigit(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    if (!AllowedMathematicOperations.Contains(c) && c != ' ')
                    {
                        Console.WriteLine($"'{c}' is not a allowed sign.");
                        return false;
                    }

                    mathOperations.Add(c);
                    var possibleNumber = stringBuilder.ToString();
                    if (!String.IsNullOrWhiteSpace(possibleNumber))
                    {
                        possibleNumbers.Add(possibleNumber);
                    }

                    stringBuilder = new StringBuilder();
                }
            }

            possibleNumbers.Add(stringBuilder.ToString());

            if (possibleNumbers.Count != mathOperations.Count + 1)
            {
                Console.WriteLine("Wrong count of numbers and math operations.");
                return false;
            }

            if (!CheckDivisionByZero(possibleNumbers, mathOperations))
            {
                Console.WriteLine("You are trying to divide by zero. This is not allowed.");
                return false;
            }

            return true;
        }

        private static bool CheckDivisionByZero(IEnumerable<string> possibleNumbers, IReadOnlyList<char> mathOperations)
        {
            List<decimal> numbers = possibleNumbers
                .Select(Decimal.Parse)
                .ToList();

            var zeroNumberCount = numbers.Count(number => number == Decimal.Zero);

            if (zeroNumberCount > 0)
            {
                IEnumerable<int> divisionIndexes = Enumerable
                    .Range(0, mathOperations.Count)
                    .Where(i => mathOperations[i] == '/');
                foreach (int divisionIndex in divisionIndexes)
                {
                    if (numbers[divisionIndex + 1] == Decimal.Zero)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}