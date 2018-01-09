using EvaluateStringExpression.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateStringExpression.UnitTests
{
    [TestClass]
    public class StringExpressionEvaluatorUnitTests
    {
        [TestMethod]
        public void StringExpressionEvaluatorUnitTests_Test1()
        {
            // Arrange
            const string expression = "4+5*2";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(14m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluatorUnitTests_Test2()
        {
            // Arrange
            const string expression = "4+5/2";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(6.5m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluatorUnitTests_Test3()
        {
            // Arrange
            const string expression = "4+5/2-1";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(5.5m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluatorUnitTests_Test4()
        {
            // Arrange
            const string expression = "44+5-6/3*10-8";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(21m, result);
        }
    }
}