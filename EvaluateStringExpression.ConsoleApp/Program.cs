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

                bool isValid = StringExpressionChecker.IsValid(expression);

                if (isValid)
                {
                    decimal result = StringExpressionEvaluator.Evaluate(expression);
                    Console.WriteLine(result);
                }
                Console.ReadKey();
            }
        }
    }
}