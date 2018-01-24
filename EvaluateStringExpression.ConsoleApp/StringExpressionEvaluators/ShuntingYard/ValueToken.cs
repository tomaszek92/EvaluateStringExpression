using System;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard
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