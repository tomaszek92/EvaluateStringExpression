using System;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard.Tokens
{
    public class ValueToken : Token
    {
        public decimal Value { get; set; }

        public ValueToken(string value)
        {
            Value = Decimal.Parse(value);
        }
    }
}