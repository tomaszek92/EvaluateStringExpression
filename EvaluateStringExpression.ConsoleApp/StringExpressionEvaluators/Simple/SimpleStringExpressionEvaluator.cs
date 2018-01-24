using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.Simple
{
    public class SimpleStringExpressionEvaluator : BaseStringExpressionEvaluator
    {
        public override decimal Evaluate(string expression)
        {
            (var mathOperations, var values) = PrepareData(expression);

            DoNextMathOperation(mathOperations, values);

            return values[0];
        }

        private (List<MathOperation> mathOperations, List<decimal> values) PrepareData(string expression)
        {
            List<MathOperation> mathOperations = new List<MathOperation>();
            List<decimal> values = new List<decimal>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in expression)
            {
                if (Char.IsDigit(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    mathOperations.Add(MathOperationHelper.ConvertCharToMathOperation(c));
                    values.Add(Decimal.Parse(stringBuilder.ToString()));
                    stringBuilder = new StringBuilder();
                }
            }

            values.Add(Decimal.Parse(stringBuilder.ToString()));
            return (mathOperations, values);
        }

        private void DoNextMathOperation(List<MathOperation> mathOperations, List<decimal> values)
        {
            if (mathOperations.Count == 0)
            {
                return;
            }

            MathOperation mathOperationWithTheHightestRank = mathOperations
                .OrderByDescending(mathOperation => MathOperationHelper.MathOperationOrder[mathOperation])
                .First();

            int index = mathOperations.IndexOf(mathOperationWithTheHightestRank);
            mathOperations.RemoveAt(index);
            decimal leftNumber = values[index];
            decimal rightNumber = values[index + 1];
            decimal newNumber = DoOperation(leftNumber, rightNumber, mathOperationWithTheHightestRank);
            values[index] = newNumber;
            values.RemoveAt(index + 1);

            DoNextMathOperation(mathOperations, values);
        }
    }
}