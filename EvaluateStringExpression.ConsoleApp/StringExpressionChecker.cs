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
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in expression)
            {
                if (Char.IsNumber(c))
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
                    possibleNumbers.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                }
            }

            foreach (string possibleNumber in possibleNumbers)
            {
                if (Int32.TryParse(possibleNumber, out int number))
                {
                    if (number < 0)
                    {
                        Console.WriteLine($"'{possibleNumber}' is not a non-negative.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"'{possibleNumber}' is not a number.");
                    return false;
                }
            }
            return true;
        }
    }
}