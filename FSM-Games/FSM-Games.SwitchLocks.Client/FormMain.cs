using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FSM_Games.SwitchLocks.Client
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<int, PictureBox> _cells = new Dictionary<int, PictureBox>();
        private readonly Dictionary<Figure, Image> _cellStateImages = new Dictionary<Figure, Image>();
        private readonly Dictionary<int, PictureBox> _locks = new Dictionary<int, PictureBox>();
        private readonly Dictionary<Figure, Image> _lockStateImages = new Dictionary<Figure, Image>();
        private readonly Game _game = new Game();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var onImage = GetImageByNameFromResource("FSM_Games.SwitchLocks.Client.Resources.Graphics.On.bmp");
            var offImage = GetImageByNameFromResource("FSM_Games.SwitchLocks.Client.Resources.Graphics.Off.bmp");

            _cellStateImages.Add(Figure.On, onImage);
            _cellStateImages.Add(Figure.Off, offImage);

            _cells.Add(1, Cell_1);
            _cells.Add(2, Cell_2);
            _cells.Add(3, Cell_3);
            _cells.Add(4, Cell_4);
            _cells.Add(5, Cell_5);
            _cells.Add(6, Cell_6);
            _cells.Add(7, Cell_7);
            _cells.Add(8, Cell_8);
            _cells.Add(9, Cell_9);
            _cells.Add(10, Cell_10);
            _cells.Add(11, Cell_11);
            _cells.Add(12, Cell_12);
            _cells.Add(13, Cell_13);
            _cells.Add(14, Cell_14);
            _cells.Add(15, Cell_15);
            _cells.Add(16, Cell_16);

            var openedImage = GetImageByNameFromResource("FSM_Games.SwitchLocks.Client.Resources.Graphics.Opened.bmp");
            var closedImage = GetImageByNameFromResource("FSM_Games.SwitchLocks.Client.Resources.Graphics.Closed.bmp");

            _lockStateImages.Add(Figure.On, openedImage);
            _lockStateImages.Add(Figure.Off, closedImage);

            _locks.Add(1, Lock_1);
            _locks.Add(2, Lock_2);
            _locks.Add(3, Lock_3);
            _locks.Add(4, Lock_4);

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
            var cellIndex = Convert.ToInt32(((PictureBox)sender).Tag);
            _game.DoMove(cellIndex);
        }

        private void OnGameStateChanged(object sender, Game.StateChangedEventArgs e)
        {
            RenderGameField();
            ProcessGameState(e.GameState);
        }

        private void RenderGameField()
        {
            DrawCells();
            DrawLocks();
        }

        private void ProcessGameState(Game.State state)
        {
            switch (state)
            {
                case Game.State.StartNewGame:
                case Game.State.PlayerMoved:
                case Game.State.WaitingMove:
                    break;
                case Game.State.PlayerWon:
                    MessageBox.Show(@"The door is open!");
                    _game.StartNewGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, @"Unknown game state!");
            }
        }

        private void DrawCells()
        {
            foreach (var cell in _game.GameField.Cells)
            {
                _cells[cell.Key].Image = _cellStateImages[cell.Value];
                Refresh();
            }

            MediaPlayer.BeginPlaySound(101);
        }

        private void DrawLocks()
        {
            foreach (var @lock in _game.GameField.Locks)
            {
                var otkr1 = _locks[@lock.Key].Image == _lockStateImages[Figure.On];

                _locks[@lock.Key].Image = _lockStateImages[@lock.Value];

                var otkr2 = _locks[@lock.Key].Image == _lockStateImages[Figure.On];

                Refresh();
                if (otkr1 != otkr2)
                {
                    MediaPlayer.BeginPlaySound(102);
                }
            }
        }

        private void MenuItemGameNewGame_Click(object sender, EventArgs e)
        {
            _game.StartNewGame();
        }

        private void MenuItemGameExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Игра ""Замки"" © Денис Батурин, 2019");
        }
    }
}