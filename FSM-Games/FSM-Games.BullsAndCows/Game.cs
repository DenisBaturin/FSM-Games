using System;
using System.Collections.Generic;
using Stateless;

namespace FSM_Games.BullsAndCows
{
    public class Game
    {
        private enum Trigger
        {
            StartNewGame,
            PlayerMoved,
            PlayerWon,
            WaitMove,
            ShowError
        }

        public enum State
        {
            StartNewGame,
            WaitingMove,
            PlayerMoved,
            PlayerWon
        }

        public class Move
        {
            public string Elements { get; private set; }
            public int BullsCount { get; private set; }
            public int CowsCount { get; private set; }

            public Move(string elements, int bullsCount, int cowsCount)
            {
                Elements = elements;
                BullsCount = bullsCount;
                CowsCount = cowsCount;
            }
        }

        private readonly StateMachine<State, Trigger> _gameFlow;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<string> _playerMovedTrigger;
        private readonly StateMachine<State, Trigger>.TriggerWithParameters<string> _showErrorTrigger;
        public event EventHandler<StateChangedEventArgs> StateChanged;
        public event EventHandler<ErrorRaisedEventArgs> ErrorRaised;

        private List<int> Elements { get; set; }
        public int ElementsCount { get; private set; }
        public string ElementsAsString => string.Concat(Elements);
        public List<Move> Moves { get; private set; }

        public Game()
        {
            #region Initialize readonly fields

            _gameFlow = new StateMachine<State, Trigger>(State.StartNewGame);
            _playerMovedTrigger = _gameFlow.SetTriggerParameters<string>(Trigger.PlayerMoved);
            _showErrorTrigger = _gameFlow.SetTriggerParameters<string>(Trigger.ShowError);

            #endregion

            ConfigureGameFlow();

            ElementsCount = 4;
            Elements = new List<int>();
            Moves = new List<Move>();
        }

        private void ConfigureGameFlow()
        {
            _gameFlow.Configure(State.StartNewGame)
                .PermitReentry(Trigger.StartNewGame)
                //.OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .OnEntry(OnStartNewGame)
                .Permit(Trigger.WaitMove, State.WaitingMove);

            _gameFlow.Configure(State.WaitingMove)
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame)
                .Permit(Trigger.PlayerMoved, State.PlayerMoved);

            _gameFlow.Configure(State.PlayerMoved)
                .OnEntryFrom(_playerMovedTrigger, elements => OnPlayerMoved(elements))
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame)
                .Permit(Trigger.WaitMove, State.WaitingMove)
                .Permit(Trigger.PlayerWon, State.PlayerWon)
                .InternalTransition(_showErrorTrigger,
                    (errorsText, t) => OnErrorRaised(new ErrorRaisedEventArgs(errorsText)));

            _gameFlow.Configure(State.PlayerWon)
                .OnEntry(() => OnStateChanged(new StateChangedEventArgs(_gameFlow.State)))
                .Permit(Trigger.StartNewGame, State.StartNewGame);
        }

        protected void OnStateChanged(StateChangedEventArgs eventArgs)
        {
            var handler = StateChanged;
            handler?.Invoke(this, eventArgs);
        }

        protected void OnErrorRaised(ErrorRaisedEventArgs eventArgs)
        {
            var handler = ErrorRaised;
            handler?.Invoke(this, eventArgs);
        }

        private void OnStartNewGame()
        {
            Elements.Clear();

            var random = new Random();
            for (var i = 1; i <= ElementsCount; i++)
            {
                var flag = false;
                while (flag == false)
                {
                    var tempDigit = random.Next(0, 10);
                    if (Elements.Contains(tempDigit)) continue;
                    Elements.Add(tempDigit);
                    flag = true;
                }
            }

            Moves.Clear();

            _gameFlow.Fire(Trigger.WaitMove);
        }

        public void StartNewGame(int elementsCount = 4)
        {
            ElementsCount = elementsCount;
            _gameFlow.Fire(Trigger.StartNewGame);
        }

        public void DoMove(string elements)
        {
            _gameFlow.Fire(_playerMovedTrigger, elements);
        }

        private void OnPlayerMoved(string elements)
        {
            // Invalid move
            if (elements.Length != ElementsCount)
            {
                _gameFlow.Fire(_showErrorTrigger, $@"Число должно состоять из {ElementsCount} цифр!");
                _gameFlow.Fire(Trigger.WaitMove);
                return;
            }

            //
            var bullsCount = 0;
            var cowsCount = 0;

            for (var i = 0; i <= ElementsCount - 1; i++)
            {
                if (elements.Substring(i, 1) == ElementsAsString.Substring(i, 1))
                {
                    bullsCount += 1;
                }
                else
                {
                    if (ElementsAsString.Contains(elements.Substring(i, 1)))
                    {
                        cowsCount += 1;
                    }
                }
            }

            Moves.Add(new Move(elements, bullsCount, cowsCount));

            if (elements == ElementsAsString)
            {
                _gameFlow.Fire(Trigger.PlayerWon);
                return;
            }

            _gameFlow.Fire(Trigger.WaitMove);
        }

        public class StateChangedEventArgs : EventArgs
        {
            public StateChangedEventArgs(State state)
            {
                GameState = state;
            }

            public State GameState { get; }
        }

        public class ErrorRaisedEventArgs : EventArgs
        {
            public ErrorRaisedEventArgs(string errorsText)
            {
                ErrorsText = errorsText;
            }

            public string ErrorsText { get; }
        }
    }
}
