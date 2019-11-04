using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FSM_Games.TowerOfHanoi.Client
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<int, Dictionary<int, PictureBox>> _images =
            new Dictionary<int, Dictionary<int, PictureBox>>();

        private readonly Dictionary<int, Button> _buttons = new Dictionary<int, Button>();
        private readonly Dictionary<int, Image> _disksImages = new Dictionary<int, Image>();
        private readonly Game _game = new Game();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _disksImages.Add(1, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.01.bmp"));
            _disksImages.Add(2, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.02.bmp"));
            _disksImages.Add(3, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.03.bmp"));
            _disksImages.Add(4, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.04.bmp"));
            _disksImages.Add(5, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.05.bmp"));
            _disksImages.Add(6, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.06.bmp"));
            _disksImages.Add(7, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.07.bmp"));
            _disksImages.Add(8, GetImageByNameFromResource("FSM_Games.TowerOfHanoi.Client.Resources.Graphics.08.bmp"));

            _buttons.Add(1, cmd_Osn_1);
            _buttons.Add(2, cmd_Osn_2);
            _buttons.Add(3, cmd_Osn_3);

            //
            _images.Add(1, new Dictionary<int, PictureBox>
                {
                    {1, img_Ring_11},
                    {2, img_Ring_12},
                    {3, img_Ring_13},
                    {4, img_Ring_14},
                    {5, img_Ring_15},
                    {6, img_Ring_16},
                    {7, img_Ring_17},
                    {8, img_Ring_18},
                }
            );
            _images.Add(2, new Dictionary<int, PictureBox>
                {
                    {1, img_Ring_21},
                    {2, img_Ring_22},
                    {3, img_Ring_23},
                    {4, img_Ring_24},
                    {5, img_Ring_25},
                    {6, img_Ring_26},
                    {7, img_Ring_27},
                    {8, img_Ring_28},
                }
            );
            _images.Add(3, new Dictionary<int, PictureBox>
                {
                    {1, img_Ring_31},
                    {2, img_Ring_32},
                    {3, img_Ring_33},
                    {4, img_Ring_34},
                    {5, img_Ring_35},
                    {6, img_Ring_36},
                    {7, img_Ring_37},
                    {8, img_Ring_38},
                }
            );
            //

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

        private void RenderGameField()
        {
            for (var x = 1; x <= 3; x++)
            {
                for (var y = 1; y <= 8; y++)
                {
                    _images[x][y].Image = null;
                }
            }

            foreach (var tower in _game.GameField.Towers)
            {
                foreach (var ring in tower.Value.Rings)
                {
                    _images[tower.Key][ring.Key].Image = _disksImages[ring.Value.Size];
                }

                _buttons[tower.Key].BackColor = tower.Value.IsSelected ? Color.Red : Color.GreenYellow;
            }
        }

        private void OnGameStateChanged(object sender, Game.StateChangedEventArgs e)
        {
            RenderGameField();
            ProcessGameState(e.GameState);
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
                    MessageBox.Show(@"Вы спасли мир!!!", @"ПОБЕДА!!!");
                    _game.StartNewGame();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, @"Unknown game state!");
            }
        }

        private void cmd_Osn_Click(object sender, EventArgs e)
        {
            var stickIndex = Convert.ToInt32(((Button) sender).Tag);
            _game.DoMove(stickIndex);
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
            MessageBox.Show(
                @"Игра ""Ханойская башня""

Цель игры: перенести все диски с первой башни на любую другую
Больший диск нельзя класть на меньший

© Денис Батурин, 2019"
                , @"О программе");
        }
    }
}