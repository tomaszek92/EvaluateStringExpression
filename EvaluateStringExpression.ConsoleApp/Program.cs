using System;

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
                    decimal result = StringExpressionEvaluator.Evaluate(expression);
                    Console.WriteLine($"Result: {result}");
                }

                Console.WriteLine("----------------------------");
            }
        }
    }
}