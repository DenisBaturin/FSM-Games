using FSM_Games.SwitchLocks;
using NUnit.Framework;

namespace Tests
{
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

        public static TestCase[] ShouldBeGetRightOpponentFigureCases =
        {
            new TestCase
            {
                Description = "For Figure.On opponent figure should be Figure.Off",
                Figure = Figure.On,
                ExpectedOpponentFigure = Figure.Off
            },
            new TestCase
            {
                Description = "For Figure.Off opponent figure should be Figure.On",
                Figure = Figure.Off,
                ExpectedOpponentFigure = Figure.On
            }
        };

        [Test]
        [TestCaseSource(nameof(ShouldBeGetRightOpponentFigureCases))]
        public void ShouldBeGetRightOpponentFigure(TestCase testCase)
        {
            // Given
            // When
            var actualOpponentFigure = testCase.Figure.GetOpponentsFigure();
            
            // Then
            Assert.AreEqual(testCase.ExpectedOpponentFigure, actualOpponentFigure, testCase.Description);
        }
    }
}