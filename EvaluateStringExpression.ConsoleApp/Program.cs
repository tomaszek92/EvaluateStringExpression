using System;
using EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators;
using EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard;
using EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.Simple;

namespace EvaluateStringExpression.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type expression: ");
                string expression = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(expression))
                {
                    Console.WriteLine("Expresion cannot be empty.");
                    Console.WriteLine("----------------------------");
                    continue;
                }

                expression = expression.Replace(" ", "");
                if (StringExpressionChecker.IsValid(expression))
                {
                    //IStringExpressionEvaluator stringExpressionEvaluator = new SimpleStringExpressionEvaluator();
                    IStringExpressionEvaluator stringExpressionEvaluator = new ShuntingYardStringExpressionEvaluator();
                    decimal result = stringExpressionEvaluator.Evaluate(expression);
                    Console.WriteLine($"Result: {result}");
                }

                Console.WriteLine("----------------------------");
            }
        }
    }
}