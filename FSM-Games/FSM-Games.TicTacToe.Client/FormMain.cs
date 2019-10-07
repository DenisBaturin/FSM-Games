using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FSM_Games.TicTacToe.Client
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<int, PictureBox> _cells = new Dictionary<int, PictureBox>();
        private readonly Dictionary<Figure, Image> _cellStateImages = new Dictionary<Figure, Image>();
        private readonly Game _game = new Game();
        private bool _player2IsComputer = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var crossImage = GetImageByNameFromResource("FSM_Games.TicTacToe.Client.Resources.Graphics.Cross.bmp");
            var toeImage = GetImageByNameFromResource("FSM_Games.TicTacToe.Client.Resources.Graphics.Toe.bmp");

            _cellStateImages.Add(Figure.Cross, crossImage);
            _cellStateImages.Add(Figure.Toe, toeImage);

            _cells.Add(1, Cell_1);
            _cells.Add(2, Cell_2);
            _cells.Add(3, Cell_3);
            _cells.Add(4, Cell_4);
            _cells.Add(5, Cell_5);
            _cells.Add(6, Cell_6);
            _cells.Add(7, Cell_7);
            _cells.Add(8, Cell_8);
            _cells.Add(9, Cell_9);

            _game.StateChanged += OnGameStateChanged;
            _game.StartNewGame();
        }

        private static Image GetImageByNameFromResource(string resourceName)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var resourceStream = executingAssembly.GetManifestResourceStream(resourceName);
            Image image = new Bitmap(resourceStream ??
                                     throw new ArgumentNullException(nameof(resourceStream),
                                         $@"Resource from [{resourceName}] is null!"));
            return image;
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            var cellIndex = Convert.ToInt32(((PictureBox) sender).Tag);
            _game.DoMove(cellIndex);
        }

        private void OnGameStateChanged(object sender, Game.StateChangedEventArgs e)
        {
            RenderGameField();
            ProcessGameState(e.GameState);
        }

        private void RenderGameField()
        {
            foreach (var cell in _game.GameField.Cells)
            {
                _cells[cell.Key].Image = cell.Value != null ? _cellStateImages[cell.Value.Value] : null;
            }
        }

        private void ProcessGameState(Game.State state)
        {
            switch (state)
            {
                case Game.State.StartNewGame:
                case Game.State.PlayerMoved:
                case Game.State.ChangePlayer:
                    break;
                case Game.State.WaitingMove:
                    if (_player2IsComputer && _game.CurrentFigure == Figure.Toe)
                    {
                        _game.DoAutoMove();
                    }

                    break;
                case Game.State.Draw:
                    MessageBox.Show(@"Ничья!");
                    _game.StartNewGame();
                    break;
                case Game.State.PlayerWon:
                    MessageBox.Show(
                        _game.CurrentFigure == Figure.Cross ? @"Крестики выиграли!" : @"Нолики выиграли!");
                    _game.StartNewGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, @"Unknown game state!");
            }
        }

        private void MenuItemGameNewGame_Click(object sender, EventArgs e)
        {
            _game.StartNewGame();
        }

        private void MenuItemGamePlayer2IsComputer_Click(object sender, EventArgs e)
        {
            MenuItemGamePlayer2IsComputer.Checked = !MenuItemGamePlayer2IsComputer.Checked;
            _player2IsComputer = MenuItemGamePlayer2IsComputer.Checked;
            _game.StartNewGame();
        }

        private void MenuItemGameExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Игра ""Крестики-Нолики"" © Денис Батурин, 2019");
        }
    }
}