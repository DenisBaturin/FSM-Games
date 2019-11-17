using NUnit.Framework;

namespace FSM_Games.BullsAndCows.Tests
{
    public class BullsAndCowsTests
    {
        [Test]
        public void ShouldGameStateBeWaitingMoveJustAfterStart()
        {
            // Given
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            // When
            game.StartNewGame();

            // Then
            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [Test]
        public void ShouldGameStateBeWaitingMoveAfterFirstMove()
        {
            // Given
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            // When
            game.StartNewGame();
            game.DoMove("1234");

            // Then
            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [Test]
        public void ShouldGameStateBeWaitingMoveAfterSecondMove()
        {
            // Given
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            // When
            game.StartNewGame();
            game.DoMove("1234");
            game.DoMove("2345");

            // Then
            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [Test]
        public void ShouldGameStateBeWaitingMoveAfterWrongMove()
        {
            // Given
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            // When
            game.StartNewGame();
            game.DoMove("1111");

            // Then
            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }
    }
}