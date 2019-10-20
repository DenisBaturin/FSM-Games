using System;
using System.Collections.Generic;
using System.Linq;

namespace FSM_Games.TicTacToe
{
    public class GameField
    {
        public enum SetCellResult
        {
            InvalidMove,
            WaitMove,
            PlayerWon,
            Draw
        }

        private readonly Dictionary<int, Figure?> _cells;
        public IReadOnlyDictionary<int, Figure?> Cells { get; }

        internal GameField()
        {
            _cells = new Dictionary<int, Figure?>()
            {
                {1, null},
                {2, null},
                {3, null},
                {4, null},
                {5, null},
                {6, null},
                {7, null},
                {8, null},
                {9, null}
            };

            Cells = _cells;
        }

        internal void Clear()
        {
            for (var index = 1; index <= _cells.Count; index++)
            {
                _cells[index] = null;
            }
        }

        internal SetCellResult SetCellFigure(int cellIndex, Figure figure)
        {
            if (cellIndex < 1 || cellIndex > 9)
            {
                throw new ArgumentException("Cell index must be in [1-9] range!", nameof(cellIndex));
            }

            if (_cells[cellIndex] != null)
            {
                //throw new InvalidOperationException("Invalid move! The cell isn't empty.");
                return SetCellResult.InvalidMove;
            }

            _cells[cellIndex] = figure;

            if (IsWinningMove(cellIndex, figure))
            {
                return SetCellResult.PlayerWon;
            }

            return IsNoEmptyCells() ? SetCellResult.Draw : SetCellResult.WaitMove;
        }

        private bool IsWinningMove(int cellIndex, Figure figure)
        {
            if (cellIndex < 1 || cellIndex > 9)
            {
                throw new ArgumentException("Cell index must be in [1-9] range!", nameof(cellIndex));
            }

            bool result;

            switch (cellIndex)
            {
                case 1:
                    result = _cells[2] == figure & _cells[3] == figure
                             || _cells[4] == figure & _cells[7] == figure
                             || _cells[5] == figure & _cells[9] == figure;

                    break;
                case 2:
                    result = _cells[1] == figure & _cells[3] == figure
                             || _cells[5] == figure & _cells[8] == figure;

                    break;
                case 3:
                    result = _cells[1] == figure & _cells[2] == figure
                             || _cells[5] == figure & _cells[7] == figure
                             || _cells[6] == figure & _cells[9] == figure;

                    break;
                case 4:
                    result = _cells[1] == figure & _cells[7] == figure
                             || _cells[5] == figure & _cells[6] == figure;

                    break;
                case 5:
                    result = _cells[1] == figure & _cells[9] == figure
                             || _cells[2] == figure & _cells[8] == figure
                             || _cells[3] == figure & _cells[7] == figure
                             || _cells[4] == figure & _cells[6] == figure;

                    break;
                case 6:
                    result = _cells[3] == figure & _cells[9] == figure
                             || _cells[4] == figure & _cells[5] == figure;

                    break;
                case 7:
                    result = _cells[1] == figure & _cells[4] == figure
                             || _cells[3] == figure & _cells[5] == figure
                             || _cells[8] == figure & _cells[9] == figure;

                    break;
                case 8:
                    result = _cells[2] == figure & _cells[5] == figure
                             || _cells[7] == figure & _cells[9] == figure;

                    break;
                case 9:
                    result = _cells[1] == figure & _cells[5] == figure
                             || _cells[3] == figure & _cells[6] == figure
                             || _cells[7] == figure & _cells[8] == figure;

                    break;
                default:
                    throw new IndexOutOfRangeException("Cell index must be in [1-9] range!");
            }

            return result;
        }

        private bool IsNoEmptyCells()
        {
            return _cells.All(x => x.Value != null);
        }

        internal int ReturnBestMove(Figure figure)
        {
            if (_cells.All(x => x.Value != null))
            {
                throw new InvalidOperationException("There are no empty cells on the field!");
            }

            // get win
            foreach (var cell in _cells)
            {
                if (cell.Value == null && IsWinningMove(cell.Key, figure))
                {
                    return cell.Key;
                }
            }

            // block opponent win
            var opponentsFigure = figure.GetOpponentsFigure();
            foreach (var cell in _cells)
            {
                if (cell.Value == null && IsWinningMove(cell.Key, opponentsFigure))
                {
                    return cell.Key;
                }
            }

            // get center cell
            if (_cells[5] == null)
            {
                return 5;
            }

            // get best corners cell
            if (_cells[1] == opponentsFigure && _cells[9] == null)
            {
                return 9;
            }
            if (_cells[3] == opponentsFigure && _cells[7] == null)
            {
                return 7;
            }
            if (_cells[9] == opponentsFigure && _cells[1] == null)
            {
                return 1;
            }
            if (_cells[7] == opponentsFigure && _cells[3] == null)
            {
                return 3;
            }

            if (_cells[2] == opponentsFigure && _cells[4] == opponentsFigure && _cells[1] == null)
            {
                return 1;
            }
            if (_cells[2] == opponentsFigure && _cells[6] == opponentsFigure && _cells[3] == null)
            {
                return 3;
            }
            if (_cells[6] == opponentsFigure && _cells[8] == opponentsFigure && _cells[9] == null)
            {
                return 9;
            }
            if (_cells[4] == opponentsFigure && _cells[8] == opponentsFigure && _cells[7] == null)
            {
                return 7;
            }

            if (_cells[1] == null)
            {
                return 1;
            }
            if (_cells[3] == null)
            {
                return 3;
            }
            if (_cells[9] == null)
            {
                return 9;
            }
            if (_cells[7] == null)
            {
                return 7;
            }

            // get any empty cell
            int cellIndex;
            do
            {
                var random = new Random();
                cellIndex = random.Next(1, 10);
            } while (_cells[cellIndex] != null);

            return cellIndex;
        }
    }
}