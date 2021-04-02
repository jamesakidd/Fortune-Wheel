using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FortuneWheelLibrary;

namespace FortuneWheel
{
    public partial class EndGameDialog : Form
    {
        public EndGameDialog(IWheel wheel)
        {
            InitializeComponent();
            lbl_Outcome.Text =
                $@"{wheel.GetCurrentPlayer()} successfully solved the phrase:""{wheel.GetCurrentPhrase()}""";

            var sortedPlayers = wheel.GetAllPlayers().ToList().OrderByDescending(p => p.Score).ToList();

            for (int i = 1; i <= sortedPlayers.Count; i++)
            {
                switch (i)
                {
                    case 1:
                        lbl_Player1.Text = $@"Winner: {sortedPlayers[i-1]} - {sortedPlayers[i-1].Score:C0}";
                        lbl_Player1.Visible = true;
                        break;
                    case 2:
                        lbl_Player2.Text = $@"2nd Place: {sortedPlayers[i-1]} - {sortedPlayers[i-1].Score:C0}";
                        lbl_Player2.Visible = true;
                        break;
                    case 3:
                        lbl_Player3.Text = $@"3rd Place: {sortedPlayers[i-1]} - {sortedPlayers[i-1].Score:C0}";
                        lbl_Player3.Visible = true;
                        break;
                    case 4:
                        lbl_Player4.Text = $@"4th Place: {sortedPlayers[i-1]} - {sortedPlayers[i-1].Score:C0}";
                        lbl_Player4.Visible = true;
                        break;
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
