namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators
{
    public interface IStringExpressionEvaluator
    {
        decimal Evaluate(string expression);
    }
}