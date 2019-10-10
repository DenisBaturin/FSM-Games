using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FSM_Games.TicTacToe.Tests
{
    [TestClass]
    public class TicTacToeTests
    {

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void ShouldGameStateBeCrossesWinsIfCrossesWinsAfterMove()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(4);
            game.DoMove(2);
            game.DoMove(5);

            game.DoMove(3);
            var actualPlayerFigure = game.CurrentFigure;

            Assert.AreEqual(Game.State.PlayerWon, actualGameState);
            Assert.AreEqual(Figure.Cross, actualPlayerFigure);
        }

        [TestMethod]
        public void ShouldGameStateBeToesWinsIfToesWinsAfterMove()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(5);
            game.DoMove(2);
            game.DoMove(3);
            game.DoMove(6);

            game.DoMove(7);
            var actualPlayerFigure = game.CurrentFigure;

            Assert.AreEqual(Game.State.PlayerWon, actualGameState);
            Assert.AreEqual(Figure.Toe, actualPlayerFigure);
        }

        [TestMethod]
        public void ShouldGameStateBeWaitingMoveIfNobodyWinAfterMove_1()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(4);
            game.DoMove(2);
            game.DoMove(5);

            game.DoMove(7);

            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [TestMethod]
        public void ShouldGameStateBeWaitingMoveIfNobodyWinAfterMove_2()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(2);
            game.DoMove(3);
            game.DoMove(4);
            game.DoMove(5);
            game.DoMove(7);
            game.DoMove(6);

            game.DoMove(8);

            Assert.AreEqual(Game.State.WaitingMove, actualGameState);
        }

        [TestMethod]
        public void ShouldGameStateBeDrawAfterMoveForOneEmptyCellWithNobodyWins()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(2);
            game.DoMove(3);
            game.DoMove(4);
            game.DoMove(6);
            game.DoMove(7);
            game.DoMove(8);
            game.DoMove(9);

            game.DoMove(5);

            Assert.AreEqual(Game.State.Draw, actualGameState);
        }

        [TestMethod]
        public void ShouldGameStateBeDrawAfterAutoMoveForOneEmptyCellWithNobodyWins()
        {
            var game = new Game();
            var actualGameState = Game.State.StartNewGame;
            game.StateChanged += (sender, e) => { actualGameState = e.GameState; };

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(2);
            game.DoMove(4);
            game.DoMove(5);
            game.DoMove(3);
            game.DoMove(6);
            game.DoMove(8);
            game.DoMove(7);

            game.DoAutoMove();

            Assert.AreEqual(Game.State.Draw, actualGameState);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfRequestAutoMoveForFullField()
        {
            var game = new Game();

            game.StartNewGame();

            game.DoMove(1);
            game.DoMove(2);
            game.DoMove(3);
            game.DoMove(5);
            game.DoMove(4);
            game.DoMove(6);
            game.DoMove(8);
            game.DoMove(7);
            game.DoMove(9);

            var expectedException = Assert.ThrowsException<InvalidOperationException>(() => game.DoAutoMove());
            Assert.AreEqual(expectedException.Message, "There are no empty cells on the field!");
        }
    }
}