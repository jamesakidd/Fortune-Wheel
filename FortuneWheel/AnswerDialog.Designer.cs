
namespace FortuneWheel
{
    partial class AnswerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnswerDialog));
            this.txt_Answer = new System.Windows.Forms.TextBox();
            this.lbl_AnswerInstructions = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Answer
            // 
            this.txt_Answer.Location = new System.Drawing.Point(12, 94);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(451, 20);
            this.txt_Answer.TabIndex = 0;
            this.txt_Answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Answer_KeyDown);
            // 
            // lbl_AnswerInstructions
            // 
            this.lbl_AnswerInstructions.AutoSize = true;
            this.lbl_AnswerInstructions.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_AnswerInstructions.Location = new System.Drawing.Point(118, 8);
            this.lbl_AnswerInstructions.Name = "lbl_AnswerInstructions";
            this.lbl_AnswerInstructions.Size = new System.Drawing.Size(238, 38);
            this.lbl_AnswerInstructions.TabIndex = 1;
            this.lbl_AnswerInstructions.Text = "Enter Your Guess";
            // 
            // btn_Submit
            // 
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Submit.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.Location = new System.Drawing.Point(168, 132);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(136, 42);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "SUBMIT";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Correct answer = Spin X remaining blank letters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnswerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 186);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_AnswerInstructions);
            this.Controls.Add(this.txt_Answer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnswerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Answer;
        private System.Windows.Forms.Label lbl_AnswerInstructions;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label label1;
    }
}