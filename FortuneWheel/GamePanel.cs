using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FortuneWheelLibrary;

namespace FortuneWheel
{
    public partial class GamePanel : Form
    {

        private Wheel wheel;
        private List<Label> playerLabels;
        private List<Label> playerScoreLabels;

        public GamePanel(Wheel wheel)
        {

            this.wheel = wheel;
            InitializeComponent();
            LoadPlayerNameArray();
            LoadPlayerScoreArray();
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
            lbl_PuzzleDisplay.Text = wheel.PuzzleState;
            lbl_Category.Text = wheel.CurrentCategory;
            lbl_CurrentPrize.Text = wheel.CurrentPrize.ToString("C0");
            

            for (int i = 0; i < wheel.Players.Count; i++)
            {
                playerLabels[i].Visible = true;
                playerLabels[i].Text = wheel.Players[i].Name;

                playerScoreLabels[i].Visible = true;
                playerScoreLabels[i].Text = wheel.Players[i].Score.ToString("C0");
            }


            




        }

        private void Letter_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            char c = btn.Text.First();
            btn.Enabled = false;
            wheel.MakeGuess(c);
            lbl_PuzzleDisplay.Text = wheel.PuzzleState;
            UpdatePlayerScores();
            Refresh();
        }

        private void UpdatePlayerScores() //Will need to be made dynamic for number of players in game.
        {
            lbl_Player1Score.Text = wheel.Players[0].Score.ToString("C0");
        }
    }
}
