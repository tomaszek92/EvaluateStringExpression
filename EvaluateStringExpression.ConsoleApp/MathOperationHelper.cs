using System;
using System.Collections.Generic;

namespace EvaluateStringExpression.ConsoleApp
{
    public static class MathOperationHelper
    {
        public static readonly Dictionary<MathOperation, int> MathOperationOrder = new Dictionary<MathOperation, int>
        {
            {MathOperation.Addition, 1},
            {MathOperation.Subtraction, 1},
            {MathOperation.Multiplication, 2},
            {MathOperation.Division, 2}
        };

        public static MathOperation ConvertCharToMathOperation(char c)
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
    }
}