using System;
using System.Windows.Forms;

/*
 * Player puzzle answer dialog for Fortune Wheel game
 * Authors: Anthony Merante & James Kidd
 * Date: April 1 - 2021
 */

namespace FortuneWheel
{
    public partial class AnswerDialog : Form
    {
        public string Answer;

        public AnswerDialog()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            Answer = txt_Answer.Text.Trim();
            Close();
        }

        private void txt_Answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_Submit.PerformClick();
            }
        }
    }
}
