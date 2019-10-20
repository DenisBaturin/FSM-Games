using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSM_Games.TicTacToe.Tests
{
    [TestClass]
    public class FigureExtensionsTests
    {
        public class TestCase
        {
            public string Description;
            public Figure Figure;
            public Figure ExpectedOpponentFigure;

            public override string ToString()
            {
                return Description;
            }
        }

        public static IEnumerable<object[]> ShouldBeGetRightOpponentFigureCases()
        {
            yield return new object[]
            {
                new TestCase
                {
                    Description = "For Figure.Cross opponent figure should be Figure.Toe",
                    Figure = Figure.Cross,
                    ExpectedOpponentFigure = Figure.Toe
                }
            };
            yield return new object[]
            {
                new TestCase
                {
                    Description = "For Figure.Toe opponent figure should be Figure.Cross",
                    Figure = Figure.Toe,
                    ExpectedOpponentFigure = Figure.Cross
                }
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(ShouldBeGetRightOpponentFigureCases), DynamicDataSourceType.Method)]
        public void ShouldBeRightOpponentFigure(TestCase testCase)
        {
            // Given
            // When
            var actualOpponentFigure = testCase.Figure.GetOpponentsFigure();

            // Then
            Assert.AreEqual(testCase.ExpectedOpponentFigure, actualOpponentFigure, testCase.Description);
        }
    }
}