using EvaluateStringExpression.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateStringExpression.UnitTests
{
    [TestClass]
    public class StringExpressionEvaluatorUnitTests
    {
        [TestMethod]
        public void StringExpressionEvaluator_Test1_ShouldPass()
        {
            // Arrange
            const string expression = "4+5*2";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(14m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluator_Test2_ShouldPass()
        {
            // Arrange
            const string expression = "4+5/2";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(6.5m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluator_Test3_ShouldPass()
        {
            // Arrange
            const string expression = "4+5/2-1";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(5.5m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluatorTest4_ShouldPass()
        {
            // Arrange
            const string expression = "44+5-6/3*10-8";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(21m, result);
        }

        [TestMethod]
        public void StringExpressionEvaluatorTest5_ShouldPass()
        {
            // Arrange
            const string expression = "0*2+5*1/5-5";

            // Act
            decimal result = StringExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.AreEqual(-4m, result);
        }
    }
}