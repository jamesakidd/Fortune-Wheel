
namespace FortuneWheel
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.button_join = new System.Windows.Forms.Button();
            this.button_Ready = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Player1 = new System.Windows.Forms.Label();
            this.label_Player2 = new System.Windows.Forms.Label();
            this.label_Player3 = new System.Windows.Forms.Label();
            this.label_Player4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserName.Location = new System.Drawing.Point(138, 23);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(198, 29);
            this.textBox_UserName.TabIndex = 1;
            // 
            // button_join
            // 
            this.button_join.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_join.Location = new System.Drawing.Point(138, 69);
            this.button_join.Name = "button_join";
            this.button_join.Size = new System.Drawing.Size(96, 31);
            this.button_join.TabIndex = 2;
            this.button_join.Text = "Join";
            this.button_join.UseVisualStyleBackColor = true;
            this.button_join.Click += new System.EventHandler(this.button_join_Click);
            // 
            // button_Ready
            // 
            this.button_Ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ready.Location = new System.Drawing.Point(240, 69);
            this.button_Ready.Name = "button_Ready";
            this.button_Ready.Size = new System.Drawing.Size(96, 31);
            this.button_Ready.TabIndex = 4;
            this.button_Ready.Text = "Ready";
            this.button_Ready.UseVisualStyleBackColor = true;
            this.button_Ready.Click += new System.EventHandler(this.button_Ready_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_Player4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Player3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Player2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Player1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 127);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label_Player1
            // 
            this.label_Player1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Player1.AutoSize = true;
            this.label_Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player1.Location = new System.Drawing.Point(3, 0);
            this.label_Player1.Name = "label_Player1";
            this.label_Player1.Size = new System.Drawing.Size(156, 50);
            this.label_Player1.TabIndex = 0;
            this.label_Player1.Text = "Player1 (Not Ready)";
            this.label_Player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Player2
            // 
            this.label_Player2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Player2.AutoSize = true;
            this.label_Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player2.Location = new System.Drawing.Point(165, 0);
            this.label_Player2.Name = "label_Player2";
            this.label_Player2.Size = new System.Drawing.Size(156, 50);
            this.label_Player2.TabIndex = 1;
            this.label_Player2.Text = "Player2 (Not Ready)";
            this.label_Player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Player3
            // 
            this.label_Player3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Player3.AutoSize = true;
            this.label_Player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player3.Location = new System.Drawing.Point(3, 50);
            this.label_Player3.Name = "label_Player3";
            this.label_Player3.Size = new System.Drawing.Size(156, 50);
            this.label_Player3.TabIndex = 2;
            this.label_Player3.Text = "Player3 (Not Ready)";
            this.label_Player3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Player4
            // 
            this.label_Player4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Player4.AutoSize = true;
            this.label_Player4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player4.Location = new System.Drawing.Point(165, 50);
            this.label_Player4.Name = "label_Player4";
            this.label_Player4.Size = new System.Drawing.Size(156, 50);
            this.label_Player4.TabIndex = 3;
            this.label_Player4.Text = "Player4 (Not Ready)";
            this.label_Player4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 239);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_Ready);
            this.Controls.Add(this.button_join);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Button button_join;
        private System.Windows.Forms.Button button_Ready;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Player4;
        private System.Windows.Forms.Label label_Player3;
        private System.Windows.Forms.Label label_Player2;
        private System.Windows.Forms.Label label_Player1;
    }
}