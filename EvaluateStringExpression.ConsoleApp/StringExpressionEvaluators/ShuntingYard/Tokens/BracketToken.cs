namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard.Tokens
{
    public class BracketToken : Token
    {
        public BracketType BracketType { get; }

        public BracketToken(BracketType bracketType)
        {
            BracketType = bracketType;
        }
    }
}