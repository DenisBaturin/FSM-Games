using System;
using NUnit.Framework;

namespace FSM_Games.TowerOfHanoi.Tests
{
    [TestFixture]
    public class TowerOfHanoiTests
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
            game.DoMove(1);

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
            game.DoMove(1);
            game.DoMove(2);

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
            game.DoMove(1);
            game.DoMove(1);

            // Then
            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [Test]
        public void ShouldThrowExceptionForWrongStick()
        {
            // Given
            var game = new Game();

            // When
            game.StartNewGame();
            var expectedException = Assert.Throws<ArgumentException>(() => game.DoMove(0));

            // Then
            Assert.That(expectedException.Message,
                Is.EqualTo("Stick index must be in [1-3] range! (Parameter 'stickIndex')"));

        }
    }
}