using System;
using System.Collections.Generic;
using System.Linq;

namespace FSM_Games.SwitchLocks
{
    public class GameField
    {
        public enum SetCellResult
        {
            WaitMove,
            PlayerWon
        }

        private readonly Dictionary<int, Figure> _cells;
        public IReadOnlyDictionary<int, Figure> Cells { get; }
        private readonly Dictionary<int, Figure> _locks;
        public IReadOnlyDictionary<int, Figure> Locks { get; }
        private readonly Dictionary<int, int[]> _dependentCellsForCells;
        private readonly Dictionary<int, int[]> _dependentCellsForLocks;

        internal GameField()
        {
            _cells = new Dictionary<int, Figure>
            {
                {1, Figure.On},
                {2, Figure.On},
                {3, Figure.On},
                {4, Figure.On},
                {5, Figure.On},
                {6, Figure.On},
                {7, Figure.On},
                {8, Figure.On},
                {9, Figure.On},
                {10, Figure.On},
                {11, Figure.On},
                {12, Figure.On},
                {13, Figure.On},
                {14, Figure.On},
                {15, Figure.On},
                {16, Figure.On}
            };

            Cells = _cells;

            _locks = new Dictionary<int, Figure>
            {
                {1, Figure.On},
                {2, Figure.On},
                {3, Figure.On},
                {4, Figure.On}
            };

            Locks = _locks;

            _dependentCellsForCells = new Dictionary<int, int[]>
            {
                {1, new[] {2, 3, 4, 5, 9, 13}},
                {2, new[] {1, 3, 4, 6, 10, 14}},
                {3, new[] {1, 2, 4, 7, 11, 15}},
                {4, new[] {1, 2, 3, 8, 12, 16}},
                {5, new[] {1, 6, 7, 8, 9, 13}},
                {6, new[] {2, 5, 7, 8, 10, 14}},
                {7, new[] {3, 5, 6, 8, 11, 15}},
                {8, new[] {4, 5, 6, 7, 12, 16}},
                {9, new[] {1, 5, 10, 11, 12, 13}},
                {10, new[] {2, 6, 9, 11, 12, 14}},
                {11, new[] {3, 7, 9, 10, 12, 15}},
                {12, new[] {4, 8, 9, 10, 11, 16}},
                {13, new[] {1, 5, 9, 14, 15, 16}},
                {14, new[] {2, 6, 10, 13, 15, 16}},
                {15, new[] {3, 7, 11, 13, 14, 16}},
                {16, new[] {4, 8, 12, 13, 14, 15}},
            };

            _dependentCellsForLocks = new Dictionary<int, int[]>
            {
                {1, new[] {1, 2, 3, 4}},
                {2, new[] {5, 6, 7, 8}},
                {3, new[] {9, 10, 11, 12}},
                {4, new[] {13, 14, 15, 16}},
            };
        }

        internal void Mix()
        {
            var random = new Random();
            for (var index = 1; index <= _cells.Count; index++)
            {
                var cellState = random.Next(2);
                _cells[index] = (Figure)cellState;
            }

            ChangeLocks();
        }

        private void ChangeLocks()
        {
            for (var index = 1; index <= _locks.Count; index++)
            {
                _locks[index] = _dependentCellsForLocks[index].All(x => _cells[x] == Figure.On)
                    ? Figure.On
                    : Figure.Off;
            }
        }

        internal SetCellResult SetCellFigure(int cellIndex)
        {
            _cells[cellIndex] = _cells[cellIndex].GetOpponentsFigure();

            foreach (var index in _dependentCellsForCells[cellIndex])
            {
                _cells[index] = _cells[index].GetOpponentsFigure();
            }

            ChangeLocks();

            return IsGameStateWin ? SetCellResult.PlayerWon : SetCellResult.WaitMove;
        }

        private bool IsGameStateWin
        {
            get
            {
                var result = _locks.All(x => x.Value == Figure.On);
                return result;
            }
        }
    }
}