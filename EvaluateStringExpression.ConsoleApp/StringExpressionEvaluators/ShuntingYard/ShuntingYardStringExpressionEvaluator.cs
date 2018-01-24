using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard
{
    public class ShuntingYardStringExpressionEvaluator : BaseStringExpressionEvaluator
    {
        public override decimal Evaluate(string expression)
        {
            List<Token> tokens = ConvertToTokens(expression);
            List<Token> outputTokens = new List<Token>();
            Stack<OperationToken> operationTokens = new Stack<OperationToken>();

            foreach (Token token in tokens)
            {
                if (token is OperationToken)
                {
                    OperationToken operationToken = token as OperationToken;
                    while (operationTokens.Count > 0)
                    {
                        OperationToken peek = operationTokens.Peek();
                        int i = operationToken.GetPrecedence() - peek.GetPrecedence();
                        if (i <= 0)
                        {
                            outputTokens.Add(operationTokens.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    operationTokens.Push(operationToken);
                }
                else
                {
                    outputTokens.Add(token);
                }
            }

            foreach (var operatorToken in operationTokens)
            {
                outputTokens.Add(operatorToken);
            }

            return CalculateTokens(outputTokens);
        }

        private decimal CalculateTokens(List<Token> outputTokens)
        {
            while (outputTokens.Count > 1)
            {
                int operatorIndex = outputTokens.FindIndex(token => token is OperationToken);
                OperationToken operationToken = outputTokens[operatorIndex] as OperationToken;
                ValueToken leftValueToken = outputTokens[operatorIndex - 2] as ValueToken;
                ValueToken rightValueToken = outputTokens[operatorIndex - 1] as ValueToken;

                outputTokens.RemoveAt(operatorIndex);
                outputTokens.RemoveAt(operatorIndex - 1);

                decimal result = DoOperation(leftValueToken.Value, rightValueToken.Value, operationToken.Operation);
                leftValueToken.Value = result;
            }

            return (outputTokens[0] as ValueToken).Value;
        }

        private List<Token> ConvertToTokens(string expression)
        {
            List<Token> tokens = new List<Token>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in expression)
            {
                if (Char.IsDigit(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    tokens.Add(new ValueToken(stringBuilder.ToString()));
                    tokens.Add(new OperationToken(c));
                    stringBuilder = new StringBuilder();
                }
            }

            tokens.Add(new ValueToken(stringBuilder.ToString()));
            return tokens;
        }
    }
}