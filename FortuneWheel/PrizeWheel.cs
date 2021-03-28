﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using FortuneWheelLibrary;

namespace FortuneWheel
{
    public partial class PrizeWheel : Form
    {
        private Wheel wheel = null;
        private LinkedList<Image> wheelStates = new();
        private SoundPlayer wheelSound;
        private List<string> prizeValues;
        private GamePanel gamePanel;

        public PrizeWheel()
        {

            InitializeComponent();

            wheel = new Wheel(); // **************will need to be changed to create a Duplex channel instead ***********************
            wheel.AddPlayer(new Player("Player 1")); // probably move this somewhere else and certainly not hardcode it.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_section2.Visible = false;


            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 1 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 2 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 3 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 4 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 5 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 6 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 7 active.png"));
            wheelStates.AddLast(Image.FromFile("../../../wheel/Slot 8 active.png"));
            wheelSound = new SoundPlayer(@"../../../wheel/singlePeg.wav");

            LoadPrizeValues();


        }

        private void LoadPrizeValues()
        {
            prizeValues = new List<string>();
            foreach (int i in wheel.WheelPrizes)
            {
                prizeValues.Add($"{i:C0}");
            }
        }

        private void SpinWheel()
        {
            var rand = new Random();
            var spins = rand.Next(30,38); 
            double speed = rand.Next(8,15);
            IEnumerator<Image> e = wheelStates.GetEnumerator();

            for (int i = 0; i < spins; i++)
            {
                
                if (e.MoveNext())
                {
                    BackgroundImage = e.Current;
                    Refresh();
                }
                else
                {
                    e.Reset();
                    e.MoveNext();
                    BackgroundImage = e.Current;
                    Refresh();
                }
                wheelSound.Play();
                if (speed >= 500)
                    Thread.Sleep((int)Math.Ceiling(speed));

                else
                    Thread.Sleep((int)Math.Ceiling(speed *= 1.11));
            }

            int wheelPosition  = spins % 8;
            wheel.CurrentPrize = wheelPosition == 0 ? wheel.WheelPrizes[wheelPosition] : wheel.WheelPrizes[wheelPosition - 1]; 


           e.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpinWheel();
            gamePanel ??= new GamePanel(wheel);
            Hide();
            gamePanel.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                DrawSidewaysText(e.Graphics, lbl_section2.Font, Brushes.Black, lbl_section1.Bounds, string_format, prizeValues[0], -55);
                DrawSidewaysText(e.Graphics, lbl_section2.Font, Brushes.Black, lbl_section2.Bounds, string_format, prizeValues[1], -22);
                DrawSidewaysText(e.Graphics, lbl_section3.Font, Brushes.Black, lbl_section3.Bounds, string_format, prizeValues[2], 27);
                DrawSidewaysText(e.Graphics, lbl_section4.Font, Brushes.Black, lbl_section4.Bounds, string_format, prizeValues[3], 68);
                DrawSidewaysText(e.Graphics, lbl_section5.Font, Brushes.Black, lbl_section5.Bounds, string_format, prizeValues[4], -55);
                DrawSidewaysText(e.Graphics, lbl_section6.Font, Brushes.Black, lbl_section6.Bounds, string_format, prizeValues[5], -22);
                DrawSidewaysText(e.Graphics, lbl_section7.Font, Brushes.Black, lbl_section7.Bounds, string_format, prizeValues[6], 27);
                DrawSidewaysText(e.Graphics, lbl_section8.Font, Brushes.Black, lbl_section8.Bounds, string_format, prizeValues[7], 55);

            }
        }

        // Draw sideways text in the indicated rectangle.
        private void DrawSidewaysText(Graphics gr, Font font,
            Brush brush, Rectangle bounds, StringFormat string_format,
            string txt, int angle)
        {
            // Make a rotated rectangle at the origin.
            Rectangle rotated_bounds = new Rectangle(
                0, 0, bounds.Height, bounds.Width);

            // Rotate.
            gr.ResetTransform();
            gr.RotateTransform(angle);

            // Translate to move the rectangle to the correct position.
            gr.TranslateTransform(bounds.Left, bounds.Bottom,
                MatrixOrder.Append);

            // Draw the text.
            gr.DrawString(txt, font, brush, rotated_bounds, string_format);
        }
    }
}
