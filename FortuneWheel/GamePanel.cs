using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using FortuneWheelLibrary;

namespace FortuneWheel
{
    public partial class GamePanel : Form, ICallback
    {
        Dispatcher thread = Dispatcher.CurrentDispatcher;
        private IWheel wheel;
        Player user;
        bool isUsersTurn;
        bool isSpinning = false;
        List<Player> players;
        private List<Label> playerLabels;
        private List<Label> playerScoreLabels;

        public GamePanel(IWheel wheel, List<Player> p, Player u)
        {
            user = u;
            players = p;
            this.wheel = wheel;
            isUsersTurn = false;
            InitializeComponent();
            LoadPlayerNameArray();
            LoadPlayerScoreArray();
            GetCurrentPlayer();
            this.Text = u.Name;
        }

        private void GetCurrentPlayer()
        {
            Player p = wheel.GetCurrentPlayer();
            foreach (var play in players)
            {
                if (play.Name == p.Name)
                {
                    playerLabels[players.FindIndex(i => i.Name == play.Name)].ForeColor = Color.Red;
                }
                else
                {
                    playerLabels[players.FindIndex(i => i.Name == play.Name)].ForeColor = Color.Black;
                }
            }
            if (p.Name == user.Name)
            {
                isUsersTurn = true;
                isSpinning = true;
                PrizeWheel pw = new PrizeWheel(wheel);
                Hide();
                pw.ShowDialog();
                lbl_CurrentPrize.Text = wheel.CurrentPrize().ToString("C0");
                Show();
                isSpinning = false;
            }
            else
            {
                isUsersTurn = false;
            }
        }
        private void LoadPlayerScoreArray()
        {
            playerScoreLabels = new List<Label>
                {lbl_Player1Score, lbl_Player2Score, lbl_Player3Score, lbl_Player4Score};
        }
        private void LoadPlayerNameArray()
        {
            playerLabels = new List<Label> {lbl_Player1, lbl_Player2, lbl_Player3, lbl_Player4};
        }



        private void GamePanel_Load(object sender, EventArgs e)
        {
            lbl_PuzzleDisplay.Text = wheel.GetCurrentState();
            lbl_Category.Text = wheel.GetCurrentCategory();
            lbl_CurrentPrize.Text = wheel.CurrentPrize().ToString("C0");
            
            for (int i = 0; i < players.Count; i++)
            {
                playerLabels[i].Visible = true;
                playerLabels[i].Text = players[i].Name;

                playerScoreLabels[i].Visible = true;
                playerScoreLabels[i].Text = players[i].Score.ToString("C0");
            }
        }

        private void Letter_Click(object sender, EventArgs e)
        {
            if (isUsersTurn)
            {
                var btn = sender as Button;
                char c = btn.Text.First();
                btn.Enabled = false;
                wheel.MakeGuess(c);
                lbl_PuzzleDisplay.Text = wheel.GetCurrentState();
                UpdatePlayerScores();
                Refresh();
                wheel.NextPlayer();
            }
        }

        private void UpdatePlayerScores() //Will need to be made dynamic for number of players in game.
        {
            for (int i = 0; i < players.Count; i++)
            {
                playerScoreLabels[i].Text = players[i].Score.ToString("C0");
            }
        }

        private void btn_answer_MouseClick(object sender, MouseEventArgs e)
        {
            if (isUsersTurn)
            {
                using (AnswerDialog answerDiag = new AnswerDialog())
                {
                    answerDiag.ShowDialog();
                    wheel.GuessAnswer(answerDiag.Answer);
                }
            }
        }
        private delegate void GuiUpdateDelegate(Player[] messages);
        // Do updates and such here
        public void PlayersUpdated(Player[] messages)
        {

            if (thread.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    if (wheel.GameOver())
                    {
                        MessageBox.Show($"Game over. {wheel.GetCurrentPlayer()} Won!");
                        Close();
                    }
                    if (!isSpinning)
                        GetCurrentPlayer();
                    players = messages.ToList();
                    UpdatePlayerScores();
                    lbl_PuzzleDisplay.Text = wheel.GetCurrentState();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                this.BeginInvoke(new GuiUpdateDelegate(PlayersUpdated), new object[] { messages });
        }
    }
}
