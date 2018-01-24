namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard.Tokens
{
    public class OperationToken : Token
    {
        public MathOperation Operation { get; }

        public OperationToken(char c)
        {
            Operation = MathOperationHelper.ConvertCharToMathOperation(c);
        }

        public int GetPrecedence() => MathOperationHelper.MathOperationOrder[Operation];
    }
}