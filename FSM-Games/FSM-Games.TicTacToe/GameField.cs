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

        private Dictionary<int, Figure?> InnerCells { get; }
        public IReadOnlyDictionary<int, Figure?> Cells { get; }

        internal GameField()
        {
            InnerCells = new Dictionary<int, Figure?>()
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

            Cells = InnerCells;
        }

        internal void Clear()
        {
            for (var index = 1; index <= Cells.Count; index++)
            {
                InnerCells[index] = null;
            }
        }

        internal SetCellResult SetCellFigure(int cellIndex, Figure figure)
        {
            if (cellIndex < 1 || cellIndex > 9)
            {
                throw new ArgumentException("Cell index must be in [1-9] range!", nameof(cellIndex));
            }

            if (Cells[cellIndex] != null)
            {
                //throw new InvalidOperationException("Invalid move! The cell isn't empty.");
                return SetCellResult.InvalidMove;
            }

            InnerCells[cellIndex] = figure;

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
                    result = Cells[2] == figure & Cells[3] == figure
                             || Cells[4] == figure & Cells[7] == figure
                             || Cells[5] == figure & Cells[9] == figure;

                    break;
                case 2:
                    result = Cells[1] == figure & Cells[3] == figure
                             || Cells[5] == figure & Cells[8] == figure;

                    break;
                case 3:
                    result = Cells[1] == figure & Cells[2] == figure
                             || Cells[5] == figure & Cells[7] == figure
                             || Cells[6] == figure & Cells[9] == figure;

                    break;
                case 4:
                    result = Cells[1] == figure & Cells[7] == figure
                             || Cells[5] == figure & Cells[6] == figure;

                    break;
                case 5:
                    result = Cells[1] == figure & Cells[9] == figure
                             || Cells[2] == figure & Cells[8] == figure
                             || Cells[3] == figure & Cells[7] == figure
                             || Cells[4] == figure & Cells[6] == figure;

                    break;
                case 6:
                    result = Cells[3] == figure & Cells[9] == figure
                             || Cells[4] == figure & Cells[5] == figure;

                    break;
                case 7:
                    result = Cells[1] == figure & Cells[4] == figure
                             || Cells[3] == figure & Cells[5] == figure
                             || Cells[8] == figure & Cells[9] == figure;

                    break;
                case 8:
                    result = Cells[2] == figure & Cells[5] == figure
                             || Cells[7] == figure & Cells[9] == figure;

                    break;
                case 9:
                    result = Cells[1] == figure & Cells[5] == figure
                             || Cells[3] == figure & Cells[6] == figure
                             || Cells[7] == figure & Cells[8] == figure;

                    break;
                default:
                    throw new IndexOutOfRangeException("Cell index must be in [1-9] range!");
            }

            return result;
        }

        private bool IsNoEmptyCells()
        {
            return Cells.All(x => x.Value != null);
        }

        internal int ReturnBestMove(Figure figure)
        {
            if (Cells.All(x => x.Value != null))
            {
                throw new InvalidOperationException("There are no empty cells on the field!");
            }

            // get win
            foreach (var cell in Cells)
            {
                if (cell.Value == null && IsWinningMove(cell.Key, figure))
                {
                    return cell.Key;
                }
            }

            // block opponent win
            var opponentsFigure = figure.GetOpponentsFigure();
            foreach (var cell in Cells)
            {
                if (cell.Value == null && IsWinningMove(cell.Key, opponentsFigure))
                {
                    return cell.Key;
                }
            }

            // get center cell
            if (Cells[5] == null)
            {
                return 5;
            }

            // get best corners cell
            if (Cells[1] == opponentsFigure && Cells[9] == null)
            {
                return 9;
            }
            if (Cells[3] == opponentsFigure && Cells[7] == null)
            {
                return 7;
            }
            if (Cells[9] == opponentsFigure && Cells[1] == null)
            {
                return 1;
            }
            if (Cells[7] == opponentsFigure && Cells[3] == null)
            {
                return 3;
            }

            if (Cells[2] == opponentsFigure && Cells[4] == opponentsFigure && Cells[1] == null)
            {
                return 1;
            }
            if (Cells[2] == opponentsFigure && Cells[6] == opponentsFigure && Cells[3] == null)
            {
                return 3;
            }
            if (Cells[6] == opponentsFigure && Cells[8] == opponentsFigure && Cells[9] == null)
            {
                return 9;
            }
            if (Cells[4] == opponentsFigure && Cells[8] == opponentsFigure && Cells[7] == null)
            {
                return 7;
            }

            if (Cells[1] == null)
            {
                return 1;
            }
            if (Cells[3] == null)
            {
                return 3;
            }
            if (Cells[9] == null)
            {
                return 9;
            }
            if (Cells[7] == null)
            {
                return 7;
            }

            // get any empty cell
            int cellIndex;
            do
            {
                var random = new Random();
                cellIndex = random.Next(1, 10);
            } while (Cells[cellIndex] != null);

            return cellIndex;
        }
    }
}