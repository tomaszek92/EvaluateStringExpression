using EvaluateStringExpression.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateStringExpression.UnitTests
{
    [TestClass]
    public class StringExpressionCheckerUnitTests
    {
        [TestMethod]
        public void StringExpressionChecker_OneDigit_ShouldPass()
        {
            // Arrange
            const string expression = "4";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_OneMathOperation_ShouldFail()
        {
            // Arrange
            const string expression = "+";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_OneDigitAndOneMathOperation_ShouldFail()
        {
            // Arrange
            const string expression = "4+";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_CorrectExpression_ShouldPass()
        {
            // Arrange
            const string expression = "4+4/2";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_TwoMathOperationsNextToEachOther_ShouldFail()
        {
            // Arrange
            const string expression = "4++4";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_LastIsMathOperation_ShouldFail()
        {
            // Arrange
            const string expression = "4+4+";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StringExpressionChecker_DivisionByZero_ShouldFail()
        {
            // Arrange
            const string expression = "4+4/0+2";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}