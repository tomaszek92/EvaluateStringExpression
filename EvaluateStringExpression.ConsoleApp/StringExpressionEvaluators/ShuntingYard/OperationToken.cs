namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard
{
    public class OperationToken : Token
    {
        public MathOperation Operation { get; set; }

        public OperationToken(char c)
        {
            Operation = MathOperationHelper.ConvertCharToMathOperation(c);
        }

        public int GetPrecedence() => MathOperationHelper.MathOperationOrder[Operation];
    }
}