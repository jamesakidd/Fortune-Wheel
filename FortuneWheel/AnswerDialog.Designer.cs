
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
            this.SuspendLayout();
            // 
            // txt_Answer
            // 
            this.txt_Answer.Location = new System.Drawing.Point(12, 67);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(525, 23);
            this.txt_Answer.TabIndex = 0;
            this.txt_Answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Answer_KeyDown);
            // 
            // lbl_AnswerInstructions
            // 
            this.lbl_AnswerInstructions.AutoSize = true;
            this.lbl_AnswerInstructions.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_AnswerInstructions.Location = new System.Drawing.Point(155, 9);
            this.lbl_AnswerInstructions.Name = "lbl_AnswerInstructions";
            this.lbl_AnswerInstructions.Size = new System.Drawing.Size(238, 38);
            this.lbl_AnswerInstructions.TabIndex = 1;
            this.lbl_AnswerInstructions.Text = "Enter Your Guess";
            // 
            // btn_Submit
            // 
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Submit.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Submit.Location = new System.Drawing.Point(195, 109);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(159, 48);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "SUBMIT";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // AnswerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 167);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_AnswerInstructions);
            this.Controls.Add(this.txt_Answer);
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
    }
}