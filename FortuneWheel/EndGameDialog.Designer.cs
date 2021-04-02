
namespace FortuneWheel
{
    partial class EndGameDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Player1 = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Outcome = new System.Windows.Forms.Label();
            this.lbl_Player2 = new System.Windows.Forms.Label();
            this.lbl_Player3 = new System.Windows.Forms.Label();
            this.lbl_Player4 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Player1
            // 
            this.lbl_Player1.AutoSize = true;
            this.lbl_Player1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player1.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_Player1.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Player1.Location = new System.Drawing.Point(262, 237);
            this.lbl_Player1.Name = "lbl_Player1";
            this.lbl_Player1.Size = new System.Drawing.Size(240, 38);
            this.lbl_Player1.TabIndex = 0;
            this.lbl_Player1.Text = "Winner: $00,000";
            this.lbl_Player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Player1.Visible = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Bernard MT Condensed", 32F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Title.Location = new System.Drawing.Point(295, 66);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(211, 50);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Game Over";
            // 
            // lbl_Outcome
            // 
            this.lbl_Outcome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Outcome.Font = new System.Drawing.Font("Bernard MT Condensed", 18F);
            this.lbl_Outcome.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Outcome.Location = new System.Drawing.Point(172, 131);
            this.lbl_Outcome.Name = "lbl_Outcome";
            this.lbl_Outcome.Size = new System.Drawing.Size(464, 106);
            this.lbl_Outcome.TabIndex = 2;
            this.lbl_Outcome.Text = "Player# successfully answered \"A puzzle phrase here\"";
            this.lbl_Outcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Outcome.UseMnemonic = false;
            // 
            // lbl_Player2
            // 
            this.lbl_Player2.AutoSize = true;
            this.lbl_Player2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player2.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_Player2.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Player2.Location = new System.Drawing.Point(262, 275);
            this.lbl_Player2.Name = "lbl_Player2";
            this.lbl_Player2.Size = new System.Drawing.Size(277, 38);
            this.lbl_Player2.TabIndex = 3;
            this.lbl_Player2.Text = "2nd Place: $00,000";
            this.lbl_Player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Player2.Visible = false;
            // 
            // lbl_Player3
            // 
            this.lbl_Player3.AutoSize = true;
            this.lbl_Player3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player3.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_Player3.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Player3.Location = new System.Drawing.Point(262, 313);
            this.lbl_Player3.Name = "lbl_Player3";
            this.lbl_Player3.Size = new System.Drawing.Size(272, 38);
            this.lbl_Player3.TabIndex = 4;
            this.lbl_Player3.Text = "3rd Place: $00,000";
            this.lbl_Player3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Player3.Visible = false;
            // 
            // lbl_Player4
            // 
            this.lbl_Player4.AutoSize = true;
            this.lbl_Player4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Player4.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_Player4.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Player4.Location = new System.Drawing.Point(262, 351);
            this.lbl_Player4.Name = "lbl_Player4";
            this.lbl_Player4.Size = new System.Drawing.Size(270, 38);
            this.lbl_Player4.TabIndex = 5;
            this.lbl_Player4.Text = "4th Place: $00,000";
            this.lbl_Player4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Player4.Visible = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImage = global::FortuneWheel.Properties.Resources.gold_button;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.Location = new System.Drawing.Point(269, 384);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(263, 67);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "EXIT";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // EndGameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FortuneWheel.Properties.Resources.endgameBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_Player4);
            this.Controls.Add(this.lbl_Player3);
            this.Controls.Add(this.lbl_Player2);
            this.Controls.Add(this.lbl_Outcome);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_Player1);
            this.Name = "EndGameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EndGameDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Player1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Outcome;
        private System.Windows.Forms.Label lbl_Player2;
        private System.Windows.Forms.Label lbl_Player3;
        private System.Windows.Forms.Label lbl_Player4;
        private System.Windows.Forms.Button btn_Exit;
    }
}