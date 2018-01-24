using System;
using System.Collections.Generic;
using System.Text;
using EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard.Tokens;

namespace EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard
{
    public class ShuntingYardStringExpressionEvaluator : BaseStringExpressionEvaluator
    {
        public override decimal Evaluate(string expression)
        {
            List<Token> tokens = ConvertToTokens(expression);
            List<Token> outputTokens = new List<Token>();
            Stack<Token> stack = new Stack<Token>();

            foreach (Token token in tokens)
            {
                if (token is OperationToken)
                {
                    OperationToken operationToken = token as OperationToken;
                    while (stack.Count > 0 && stack.Peek() is OperationToken)
                    {
                        OperationToken peek = stack.Peek() as OperationToken;
                        int i = operationToken.GetPrecedence() - peek.GetPrecedence();
                        if (i <= 0)
                        {
                            outputTokens.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack.Push(operationToken);
                }
                else if (token is BracketToken)
                {
                    if ((token as BracketToken).BracketType == BracketType.Left)
                    {
                        stack.Push(token);
                    }
                    else
                    {
                        while (stack.Count > 0)
                        {
                            Token top = stack.Pop();
                            if (!(top is BracketToken) || (top as BracketToken).BracketType != BracketType.Left)
                            {
                                outputTokens.Add(top);
                            }
                        }
                    }
                }
                else
                {
                    outputTokens.Add(token);
                }
            }

            foreach (var operatorToken in stack)
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
                    string value = stringBuilder.ToString();
                    if (!String.IsNullOrWhiteSpace(value))
                    {
                        tokens.Add(new ValueToken(value));
                    }

                    if (c == '(')
                    {
                        tokens.Add(new BracketToken(BracketType.Left));
                    }
                    else if (c == ')')
                    {
                        tokens.Add(new BracketToken(BracketType.Right));
                    }
                    else
                    {
                        tokens.Add(new OperationToken(c));
                    }

                    stringBuilder = new StringBuilder();
                }
            }

            string finalValue = stringBuilder.ToString();
            if (!String.IsNullOrWhiteSpace(finalValue))
            {
                tokens.Add(new ValueToken(finalValue));
            }

            return tokens;
        }
    }
}