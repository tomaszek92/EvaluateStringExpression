using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluateStringExpression.ConsoleApp
{
    public static class StringExpressionEvaluator
    {
        private static readonly Dictionary<MathOperation, int> MathOperationOrder = new Dictionary<MathOperation, int>
        {
            {MathOperation.Addition, 1},
            {MathOperation.Subtraction, 1},
            {MathOperation.Multiplication, 2},
            {MathOperation.Division, 2}
        };

        public static decimal Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");

            (var mathOperations, var numbers) = PrepareData(expression);

            DoNextMathOperation(mathOperations, numbers);

            return numbers[0];
        }

        private static (List<MathOperation> mathOperations, List<decimal> number) PrepareData(string expression)
        {
            List<MathOperation> mathOperations = new List<MathOperation>();
            List<decimal> numbers = new List<decimal>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in expression)
            {
                if (Char.IsNumber(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    mathOperations.Add(Convert(c));
                    numbers.Add(Decimal.Parse(stringBuilder.ToString()));
                    stringBuilder = new StringBuilder();
                }
            }
            numbers.Add(Decimal.Parse(stringBuilder.ToString()));
            return (mathOperations, numbers);
        }

        private static void DoNextMathOperation(List<MathOperation> mathOperations, List<decimal> numbers)
        {
            if (mathOperations.Count == 0)
            {
                return;
            }

            MathOperation mathOperationWithTheHightestRank = mathOperations
                .OrderByDescending(mathOperation => MathOperationOrder[mathOperation])
                .First();

            int index = mathOperations.IndexOf(mathOperationWithTheHightestRank);
            mathOperations.RemoveAt(index);
            decimal leftNumber = numbers[index];
            decimal rightNumber = numbers[index + 1];
            decimal newNumber = DoOperation(leftNumber, rightNumber, mathOperationWithTheHightestRank);
            numbers[index] = newNumber;
            numbers.RemoveAt(index + 1);

            DoNextMathOperation(mathOperations, numbers);
        }

        private static MathOperation Convert(char c)
        {
            switch (c)
            {
                case '+': return MathOperation.Addition;
                case '-': return MathOperation.Subtraction;
                case '*': return MathOperation.Multiplication;
                case '/': return MathOperation.Division;
                default: throw new Exception("Unrecognized math operation.");
            }
        }

        private static decimal DoOperation(decimal leftNumber, decimal rightNumber, MathOperation mathOperation)
        {
            switch (mathOperation)
            {
                case MathOperation.Addition:
                    return leftNumber + rightNumber;
                case MathOperation.Subtraction:
                    return leftNumber - rightNumber;
                case MathOperation.Multiplication:
                    return leftNumber * rightNumber;
                case MathOperation.Division:
                    return leftNumber / rightNumber;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mathOperation), mathOperation, null);
            }
        }
    }
}