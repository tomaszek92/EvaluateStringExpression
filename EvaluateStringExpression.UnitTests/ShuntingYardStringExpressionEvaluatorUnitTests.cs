using EvaluateStringExpression.ConsoleApp.StringExpressionEvaluators.ShuntingYard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateStringExpression.UnitTests
{
    [TestClass]
    public class ShuntingYardStringExpressionEvaluatorUnitTests
    {
        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test9_ShouldPass()
        {
            // Arrange
            const string expression = "(10-5)*(2+3)";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(25m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test8_ShouldPass()
        {
            // Arrange
            const string expression = "12-5*4/2+1";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(3m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test6_ShouldPass()
        {
            // Arrange
            const string expression = "8+7+6+5*4-3-2-1";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(35m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test7_ShouldPass()
        {
            // Arrange
            const string expression = "4*5-2";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(18m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test1_ShouldPass()
        {
            // Arrange
            const string expression = "4+5*2";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(14m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test2_ShouldPass()
        {
            // Arrange
            const string expression = "4+5/2";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(6.5m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test3_ShouldPass()
        {
            // Arrange
            const string expression = "4+5/2-1";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(5.5m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test4_ShouldPass()
        {
            // Arrange
            const string expression = "44+5-6/3*10-8";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(21m, result);
        }

        [TestMethod]
        public void ShuntingYardStringExpressionEvaluator_Test5_ShouldPass()
        {
            // Arrange
            const string expression = "0*2+5*1/5-5";

            // Act
            decimal result = new ShuntingYardStringExpressionEvaluator().Evaluate(expression);

            // Assert
            Assert.AreEqual(-4m, result);
        }
    }
}