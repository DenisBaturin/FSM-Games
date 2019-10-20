using FSM_Games.SwitchLocks;
using NUnit.Framework;

namespace Tests
{
    public class SwitchLocksTests
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
        public void ShouldCellSwitchBeChangedAfterMove()
        {
            // Given
            var game = new Game();

            // When
            game.StartNewGame();

            var cellSwitchState = game.GameField.Cells[1];
            var expectedCellSwitchState = cellSwitchState.GetOpponentsFigure();

            game.DoMove(1);
            var actualCellSwitchState = game.GameField.Cells[1];

            // Then
            Assert.AreEqual(expectedCellSwitchState, actualCellSwitchState);
        }

        [Test]
        public void ShouldDependentCellsSwitchBeChangedAfterMoveAndOthersDoNot()
        {
            // Given
            var game = new Game();

            // When
            game.StartNewGame();

            var cellSwitch_1_State = game.GameField.Cells[1];
            var cellSwitch_2_State = game.GameField.Cells[2];
            var cellSwitch_3_State = game.GameField.Cells[3];
            var cellSwitch_4_State = game.GameField.Cells[4];
            var cellSwitch_5_State = game.GameField.Cells[5];
            var cellSwitch_6_State = game.GameField.Cells[6];
            var cellSwitch_7_State = game.GameField.Cells[7];
            var cellSwitch_8_State = game.GameField.Cells[8];
            var cellSwitch_9_State = game.GameField.Cells[9];
            var cellSwitch_10_State = game.GameField.Cells[10];
            var cellSwitch_11_State = game.GameField.Cells[11];
            var cellSwitch_12_State = game.GameField.Cells[12];
            var cellSwitch_13_State = game.GameField.Cells[13];
            var cellSwitch_14_State = game.GameField.Cells[14];
            var cellSwitch_15_State = game.GameField.Cells[15];
            var cellSwitch_16_State = game.GameField.Cells[16];

            var expectedCellSwitch_1_State = cellSwitch_1_State.GetOpponentsFigure();
            var expectedCellSwitch_2_State = cellSwitch_2_State.GetOpponentsFigure();
            var expectedCellSwitch_3_State = cellSwitch_3_State.GetOpponentsFigure();
            var expectedCellSwitch_4_State = cellSwitch_4_State.GetOpponentsFigure();
            var expectedCellSwitch_5_State = cellSwitch_5_State.GetOpponentsFigure();
            var expectedCellSwitch_6_State = cellSwitch_6_State;
            var expectedCellSwitch_7_State = cellSwitch_7_State;
            var expectedCellSwitch_8_State = cellSwitch_8_State;
            var expectedCellSwitch_9_State = cellSwitch_9_State.GetOpponentsFigure();
            var expectedCellSwitch_10_State = cellSwitch_10_State;
            var expectedCellSwitch_11_State = cellSwitch_11_State;
            var expectedCellSwitch_12_State = cellSwitch_12_State;
            var expectedCellSwitch_13_State = cellSwitch_13_State.GetOpponentsFigure();
            var expectedCellSwitch_14_State = cellSwitch_14_State;
            var expectedCellSwitch_15_State = cellSwitch_15_State;
            var expectedCellSwitch_16_State = cellSwitch_16_State;

            game.DoMove(1);

            var actualCellSwitch_1_State = game.GameField.Cells[1];
            var actualCellSwitch_2_State = game.GameField.Cells[2];
            var actualCellSwitch_3_State = game.GameField.Cells[3];
            var actualCellSwitch_4_State = game.GameField.Cells[4];
            var actualCellSwitch_5_State = game.GameField.Cells[5];
            var actualCellSwitch_6_State = game.GameField.Cells[6];
            var actualCellSwitch_7_State = game.GameField.Cells[7];
            var actualCellSwitch_8_State = game.GameField.Cells[8];
            var actualCellSwitch_9_State = game.GameField.Cells[9];
            var actualCellSwitch_10_State = game.GameField.Cells[10];
            var actualCellSwitch_11_State = game.GameField.Cells[11];
            var actualCellSwitch_12_State = game.GameField.Cells[12];
            var actualCellSwitch_13_State = game.GameField.Cells[13];
            var actualCellSwitch_14_State = game.GameField.Cells[14];
            var actualCellSwitch_15_State = game.GameField.Cells[15];
            var actualCellSwitch_16_State = game.GameField.Cells[16];

            // Then
            Assert.AreEqual(expectedCellSwitch_1_State, actualCellSwitch_1_State);
            Assert.AreEqual(expectedCellSwitch_2_State, actualCellSwitch_2_State);
            Assert.AreEqual(expectedCellSwitch_3_State, actualCellSwitch_3_State);
            Assert.AreEqual(expectedCellSwitch_4_State, actualCellSwitch_4_State);
            Assert.AreEqual(expectedCellSwitch_5_State, actualCellSwitch_5_State);
            Assert.AreEqual(expectedCellSwitch_6_State, actualCellSwitch_6_State);
            Assert.AreEqual(expectedCellSwitch_7_State, actualCellSwitch_7_State);
            Assert.AreEqual(expectedCellSwitch_8_State, actualCellSwitch_8_State);
            Assert.AreEqual(expectedCellSwitch_9_State, actualCellSwitch_9_State);
            Assert.AreEqual(expectedCellSwitch_10_State, actualCellSwitch_10_State);
            Assert.AreEqual(expectedCellSwitch_11_State, actualCellSwitch_11_State);
            Assert.AreEqual(expectedCellSwitch_12_State, actualCellSwitch_12_State);
            Assert.AreEqual(expectedCellSwitch_13_State, actualCellSwitch_13_State);
            Assert.AreEqual(expectedCellSwitch_14_State, actualCellSwitch_14_State);
            Assert.AreEqual(expectedCellSwitch_15_State, actualCellSwitch_15_State);
            Assert.AreEqual(expectedCellSwitch_16_State, actualCellSwitch_16_State);
        }
    }
}