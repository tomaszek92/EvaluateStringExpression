using System;
using EvaluateStringExpression.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateStringExpression.UnitTests
{
    [TestClass]
    public class StringExpressionCheckerUnitTests
    {
        [TestMethod]
        public void IsValid()
        {
            // Arrange
            const string expression = "";

            // Act
            bool isValid = StringExpressionChecker.IsValid(expression);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}