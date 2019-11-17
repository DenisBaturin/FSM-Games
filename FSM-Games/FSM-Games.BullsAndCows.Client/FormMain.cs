using System;
using System.Windows.Forms;

namespace FSM_Games.BullsAndCows.Client
{
    public partial class FormMain : Form
    {
        private readonly Game _game = new Game();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            numericUpDown1.Value = _game.ElementsCount;
            _game.StateChanged += OnGameStateChanged;
            _game.ErrorRaised += OnGameErrorRaised;
            _game.StartNewGame();
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            if (txt_Input.Text.Length >= _game.ElementsCount)
            {
                return;
            }
            var button = (Button)sender;
            var element = button.Text;
            button.Enabled = false;
            txt_Input.Text += element;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            var elements = txt_Input.Text;
            _game.DoMove(elements);
        }

        private void btn_BS_Click(object sender, EventArgs e)
        {
            if (txt_Input.Text == "")
            {
                return;
            }

            var lastElement = txt_Input.Text.Substring(txt_Input.Text.Length - 1, 1);
            txt_Input.Text = txt_Input.Text.Substring(0, txt_Input.Text.Length - 1);
            switch (lastElement)
            {
                case "1":
                    btn_1.Enabled = true;
                    break;
                case "2":
                    btn_2.Enabled = true;
                    break;
                case "3":
                    btn_3.Enabled = true;
                    break;
                case "4":
                    btn_4.Enabled = true;
                    break;
                case "5":
                    btn_5.Enabled = true;
                    break;
                case "6":
                    btn_6.Enabled = true;
                    break;
                case "7":
                    btn_7.Enabled = true;
                    break;
                case "8":
                    btn_8.Enabled = true;
                    break;
                case "9":
                    btn_9.Enabled = true;
                    break;
                case "0":
                    btn_0.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void btn_Lost_Click(object sender, EventArgs e)
        {
            MessageBox.Show($@"Коварный компьютер загадал число: {_game.ElementsAsString}", @"Подсказка");
        }

        private void OnGameErrorRaised(object sender, Game.ErrorRaisedEventArgs e1)
        {
            MessageBox.Show(e1.ErrorsText);
        }

        private void OnGameStateChanged(object sender, Game.StateChangedEventArgs e)
        {
            RenderGameField();
            ProcessGameState(e.GameState);
        }

        private void RenderGameField()
        {
            lvStat.Items.Clear();

            foreach (var move in _game.Moves)
            {
                var lviX = new ListViewItem(move.Elements);
                lviX.SubItems.Add(move.BullsCount.ToString());
                lviX.SubItems.Add(move.CowsCount.ToString());
                lvStat.Items.Add(lviX);
            }

            txt_Input.Text = "";
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            btn_7.Enabled = true;
            btn_8.Enabled = true;
            btn_9.Enabled = true;
            btn_0.Enabled = true;
        }

        private void ProcessGameState(Game.State state)
        {
            switch (state)
            {
                case Game.State.StartNewGame:
                    //numericUpDown1.Value = _game.ElementsCount;
                    break;
                case Game.State.PlayerMoved:
                    break;
                case Game.State.WaitingMove:
                    break;
                case Game.State.PlayerWon:
                    MessageBox.Show($@"Ура! Вы угадали число!{Environment.NewLine}Количество ходов: {_game.Moves.Count}", @"Победа!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, @"Unknown game state!");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var elementsCount = Convert.ToInt32(numericUpDown1.Value);
            _game.StartNewGame(elementsCount);
        }

        private void MenuItemGameNewGame_Click(object sender, EventArgs e)
        {
            var elementsCount = Convert.ToInt32(numericUpDown1.Value);
            _game.StartNewGame(elementsCount);
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemGameExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
