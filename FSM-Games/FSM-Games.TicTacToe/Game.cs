using System;
using System.Diagnostics;
using Stateless;
using Stateless.Graph;

namespace FSM_Games.TicTacToe
{
    public class Game
    {
        private enum Trigger
        {
            StartNewGame,
            PlayerMoved,
            PlayerWon,
            Draw,
            ChangePlayer,
            WaitMove
        }

        public enum State
        {
            StartNewGame,
            WaitingMove,
            PlayerMoved,
            PlayerWon,
            Draw,
            ChangePlayer
        }
        
        private readonly StateMachine<State, Trigger> _gameFlow;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<int> _playerMovedTrigger;
        public GameField GameField { get; } = new GameField();
        public Figure CurrentFigure { get; private set; } = Figure.Cross;
        public event EventHandler<StateChangedEventArgs> StateChanged;

        public Game()
        {
            #region Initialize readonly fields

            _gameFlow = new StateMachine<State, Trigger>(State.StartNewGame);
            _playerMovedTrigger = _gameFlow.SetTriggerParameters<int>(Trigger.PlayerMoved);

            #endregion

            ConfigureGameFlow();
        }

        private void ConfigureGameFlow()
        {
            _gameFlow.Configure(State.StartNewGame)
                .PermitReentry(Trigger.StartNewGame)
                .OnEntry(OnStartNewGame)
                .Permit(Trigger.WaitMove, State.WaitingMove);

            _gameFlow.Configure(State.WaitingMove)
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame)
                .Permit(Trigger.PlayerMoved, State.PlayerMoved);

            _gameFlow.Configure(State.PlayerMoved)
                .OnEntryFrom(_playerMovedTrigger, cellIndex => OnPlayerMoved(cellIndex))
                .Permit(Trigger.StartNewGame, State.StartNewGame)
                .Permit(Trigger.WaitMove, State.WaitingMove)
                .Permit(Trigger.ChangePlayer, State.ChangePlayer)
                .Permit(Trigger.PlayerWon, State.PlayerWon)
                .Permit(Trigger.Draw, State.Draw);

            _gameFlow.Configure(State.ChangePlayer)
                .OnEntry(ChangePlayer)
                .Permit(Trigger.WaitMove, State.WaitingMove);

            _gameFlow.Configure(State.PlayerWon)
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame);

            _gameFlow.Configure(State.Draw)
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame);
        }

        protected void OnStateChanged(StateChangedEventArgs eventArgs)
        {
            var handler = StateChanged;
            handler?.Invoke(this, eventArgs);
            //Debug.WriteLine(UmlDotGraph.Format(_gameFlow.GetInfo()));
        }

        private void OnStartNewGame()
        {
            GameField.Clear();
            CurrentFigure = Figure.Cross;
            _gameFlow.Fire(Trigger.WaitMove);
        }

        public void StartNewGame()
        {
            _gameFlow.Fire(Trigger.StartNewGame);
        }

        public void DoMove(int cellIndex)
        {
            _gameFlow.Fire(_playerMovedTrigger, cellIndex);
        }

        public void DoAutoMove()
        {
            var cellIndex = GameField.ReturnBestMove(CurrentFigure);
            DoMove(cellIndex);
        }

        private void ChangePlayer()
        {
            CurrentFigure = CurrentFigure.GetOpponentsFigure();
        }

        private void OnPlayerMoved(int cellIndex)
        {
            var setCellResult = GameField.SetCellFigure(cellIndex, CurrentFigure);

            switch (setCellResult)
            {
                case GameField.SetCellResult.InvalidMove:
                    _gameFlow.Fire(Trigger.WaitMove);
                    break;
                case GameField.SetCellResult.WaitMove:
                    _gameFlow.Fire(Trigger.ChangePlayer);
                    _gameFlow.Fire(Trigger.WaitMove);
                    break;
                case GameField.SetCellResult.PlayerWon:
                    _gameFlow.Fire(Trigger.PlayerWon);
                    break;
                case GameField.SetCellResult.Draw:
                    _gameFlow.Fire(Trigger.Draw);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public class StateChangedEventArgs : EventArgs
        {
            public StateChangedEventArgs(State state)
            {
                GameState = state;
            }

            public State GameState { get; }
        }
    }
}