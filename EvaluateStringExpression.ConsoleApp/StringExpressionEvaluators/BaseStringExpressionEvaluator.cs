using System;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators
{
    public abstract class BaseStringExpressionEvaluator : IStringExpressionEvaluator
    {
        public abstract decimal Evaluate(string expression);

        protected decimal DoOperation(decimal leftNumber, decimal rightNumber, MathOperation mathOperation)
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