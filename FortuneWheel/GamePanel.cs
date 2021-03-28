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

        public GamePanel(Wheel wheel)
        {

            this.wheel = wheel;
            //CurrentPuzzle = currentPuzzle;
            //CurrentCategory = currentCategory;
            //PuzzleState = puzzleState;
            InitializeComponent();
        }

        private void GamePanel_Load(object sender, EventArgs e)
        {
            lbl_PuzzleDisplay.Text = wheel.PuzzleState;
            lbl_Category.Text = wheel.CurrentCategory;


        }

        private void Letter_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            char c = btn.Text.First();
            btn.Enabled = false;
            wheel.MakeGuess(c);
            lbl_PuzzleDisplay.Text = wheel.PuzzleState;
            Refresh();
        }
    }
}
