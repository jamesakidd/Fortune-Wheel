using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Windows.Threading;
using FortuneWheelLibrary;


/*
 * Main game window for Fortune Wheel game
 * Authors: Anthony Merante & James Kidd
 * Date: April 1 - 2021
 */

namespace FortuneWheel
{
    public partial class GamePanel : Form, ICallback
    {
        private Dispatcher thread = Dispatcher.CurrentDispatcher;
        private IWheel wheel;
        private Player user;
        private bool isUsersTurn;
        private bool isSpinning;
        private List<Player> players;
        private SoundPlayer wrongSound;
        private SoundPlayer rightSound;
        private SoundPlayer winnerSound;
        private List<Label> playerLabels;
        private List<Label> playerScoreLabels;

        /*                                                                                                                            
           88               88              88b           d88                       88                                 88             
           88               ""    ,d        888b         d888                ,d     88                                 88             
           88                     88        88`8b       d8'88                88     88                                 88             
           88  8b,dPPYba,   88  MM88MMM     88 `8b     d8' 88   ,adPPYba,  MM88MMM  88,dPPYba,    ,adPPYba,    ,adPPYb,88  ,adPPYba,  
           88  88P'   `"8a  88    88        88  `8b   d8'  88  a8P_____88    88     88P'    "8a  a8"     "8a  a8"    `Y88  I8[    ""  
           88  88       88  88    88        88   `8b d8'   88  8PP"""""""    88     88       88  8b       d8  8b       88   `"Y8ba,   
           88  88       88  88    88,       88    `888'    88  "8b,   ,aa    88,    88       88  "8a,   ,a8"  "8a,   ,d88  aa    ]8I  
           88  88       88  88    "Y888     88     `8'     88   `"Ybbd8"'    "Y888  88       88   `"YbbdP"'    `"8bbdP"Y8  `"YbbdP"' 
         */

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
            MaximizeBox = false;
            wrongSound = new SoundPlayer(@"../../../wheel/wrong_buzzer.wav");
            rightSound = new SoundPlayer(@"../../../wheel/correct_tone.wav");
            winnerSound = new SoundPlayer(@"../../../wheel/winner.wav");
        }

        private void GamePanel_Load(object sender, EventArgs e)
        {
            Text = user.Name;
            btn_answer.BackgroundImage = Image.FromFile("../../../wheel/gold_button.png");
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

        /// <summary>
        /// Enables the current player's turn
        /// </summary>
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
                pw.ShowDialog(this);
                lbl_CurrentPrize.Text = wheel.CurrentPrize().ToString("C0");
                Show();
                isSpinning = false;
            }
            else
            {
                isUsersTurn = false;
            }
        }

        /// <summary>
        /// loads a list of player score labels
        /// </summary>
        private void LoadPlayerScoreArray()
        {
            playerScoreLabels = new List<Label>
                {lbl_Player1Score, lbl_Player2Score, lbl_Player3Score, lbl_Player4Score};
        }
        /// <summary>
        /// loads a list of player name labels
        /// </summary>
        private void LoadPlayerNameArray()
        {
            playerLabels = new List<Label> { lbl_Player1, lbl_Player2, lbl_Player3, lbl_Player4 };
        }

        /*
                                                                                                ,,   ,,                          
        `7MM"""YMM                             mm       `7MMF'  `7MMF'                        `7MM `7MM                          
          MM    `7                             MM         MM      MM                            MM   MM                          
          MM   d `7M'   `MF'.gP"Ya `7MMpMMMb.mmMMmm       MM      MM   ,6"Yb. `7MMpMMMb.   ,M""bMM   MM  .gP"Ya `7Mb,od8 ,pP"Ybd 
          MMmmMM   VA   ,V ,M'   Yb  MM    MM  MM         MMmmmmmmMM  8)   MM   MM    MM ,AP    MM   MM ,M'   Yb  MM' "' 8I   `" 
          MM   Y  , VA ,V  8M""""""  MM    MM  MM         MM      MM   ,pm9MM   MM    MM 8MI    MM   MM 8M""""""  MM     `YMMMa. 
          MM     ,M  VVV   YM.    ,  MM    MM  MM         MM      MM  8M   MM   MM    MM `Mb    MM   MM YM.    ,  MM     L.   I8 
        .JMMmmmmMMM   W     `Mbmmd'.JMML  JMML.`Mbmo    .JMML.  .JMML.`Moo9^Yo.JMML  JMML.`Wbmd"MML.JMML.`Mbmmd'.JMML.   M9mmmP' 
         */

        /// <summary>
        /// Checks if the guessed letter exists in the current puzzle
        /// </summary>
        private void Letter_Click(object sender, EventArgs e)
        {
            if (!isUsersTurn) return;
            var btn = sender as Button;
            char c = btn.Text.First();
            btn.Enabled = false;

            if (wheel.MakeGuess(c))
            {
                rightSound.Play();
            }
            else
            {
                wrongSound.Play();
            }

            lbl_PuzzleDisplay.Text = wheel.GetCurrentState();
            UpdatePlayerScores();
            Refresh();
            wheel.NextPlayer();
        }

        /// <summary>
        /// Pops dialog for user to enter solution to current puzzle
        /// </summary>
        private void btn_answer_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isUsersTurn) return;
            using AnswerDialog answerDiag = new AnswerDialog();
            answerDiag.ShowDialog();
            wheel.GuessAnswer(answerDiag.Answer);
        }

        /*
                                 ,,                                     
          `7MMF'  `7MMF'       `7MM                                     
            MM      MM           MM                                     
            MM      MM  .gP"Ya   MM `7MMpdMAo.  .gP"Ya `7Mb,od8 ,pP"Ybd 
            MMmmmmmmMM ,M'   Yb  MM   MM   `Wb ,M'   Yb  MM' "' 8I   `" 
            MM      MM 8M""""""  MM   MM    M8 8M""""""  MM     `YMMMa. 
            MM      MM YM.    ,  MM   MM   ,AP YM.    ,  MM     L.   I8 
          .JMML.  .JMML.`Mbmmd'.JMML. MMbmmd'   `Mbmmd'.JMML.   M9mmmP' 
                                      MM                                
                                    .JMML.                              
          */

        /// <summary>
        /// Updates all letter button's enabled state
        /// </summary>
        private void UpdateLetters()
        {
            Dictionary<char, bool> letters = wheel.GetLetters();
            foreach (Button control in tableLayoutPanel1.Controls)
            {
                control.Enabled = letters[control.Text[0]];
            }
        }

        /// <summary>
        /// Updates all player score labels
        /// </summary>
        private void UpdatePlayerScores()
        {
            for (int i = 0; i < players.Count; i++)
            {
                playerScoreLabels[i].Text = players[i].Score.ToString("C0");
            }
        }

        private delegate void GuiUpdateDelegate(Player[] messages);
        /// <summary>
        /// Callback method that updates the players UI and declares a winner if applicable
        /// </summary>
        /// <param name="messages">Contains updated player info</param>
        public void PlayersUpdated(Player[] messages)
        {
            if (thread.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    // If game is over
                    if (wheel.GameOver())
                    {
                        try
                        {
                            Player winner = wheel.GetAllPlayers().OrderByDescending(p => p.Score).FirstOrDefault();
                            winnerSound.Play();
                            //MessageBox.Show($@"Game over. {winner} won with {winner.Score:C0}!");

                            EndGameDialog endDialog = new EndGameDialog(wheel);
                            endDialog.ShowDialog(this);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($@"Error getting winner: {ex.Message}");
                        }

                        Close();
                    }
                    // if the wheel is spinning do not update the current player
                    // otherwise the GUI will attempt to make additional threads and display errors
                    if (!isSpinning)
                        GetCurrentPlayer();
                    players = messages.ToList();
                    UpdatePlayerScores();
                    lbl_PuzzleDisplay.Text = wheel.GetCurrentState();
                    btn_answer.Enabled = isUsersTurn;
                    UpdateLetters();
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
