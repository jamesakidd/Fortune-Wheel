using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using FortuneWheelLibrary;

/*
 * Prize Wheel form for Fortune Wheel game
 * Authors: Anthony Merante & James Kidd
 * Date: April 1 - 2021
 */

namespace FortuneWheel
{
    public partial class PrizeWheel : Form
    {
        private IWheel wheel;
        private LinkedList<Image> wheelStates = new();
        private SoundPlayer wheelSound;
        private List<string> prizeValues;


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

        public PrizeWheel(IWheel w)
        {

            try
            {

                for (int i = 1; i <= 8; i++)
                {
                    wheelStates.AddLast(Image.FromFile($"../../../wheel/Slot {i} active.png"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"ERROR loading wheel backgrounds: {ex.Message}");
            }

            try
            {
                wheelSound = new SoundPlayer(@"../../../wheel/singlePeg.wav");
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"ERROR loading wheel sound: {ex.Message}");
            }

            wheel = w;
            InitializeComponent();
            LoadPrizeValues();
            MaximizeBox = false;
        }

        /// <summary>
        /// Loads local string list with prize values from library.
        /// </summary>
        private void LoadPrizeValues()
        {
            prizeValues = new List<string>();
            foreach (int i in wheel.GetPrizes())
            {
                prizeValues.Add($"{i:C0}");
            }
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
        /// Spins the wheel
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            SpinWheel();
            Close();
        }

        /// <summary>
        /// Draws prize labels on wheel
        /// </summary>
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
        /// Draw labels on a given angle. Sourced from: http://csharphelper.com/blog/2017/01/easily-draw-rotated-text-on-a-form-in-c/
        /// </summary>
        /// <param name="gr">Graphics object used to paint</param>
        /// <param name="font">font for the label</param>
        /// <param name="brush">color brush</param>
        /// <param name="bounds">bounding box of the label to draw</param>
        /// <param name="string_format">String format</param>
        /// <param name="txt">The text for the Label</param>
        /// <param name="angle">The angle to rotate the label on</param>
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

        /// <summary>
        /// Moves the active prize a random number of times, playing a sound and changing the form Background for each move
        /// </summary>
        private void SpinWheel()
        {

            var rand = new Random(DateTime.Now.Millisecond);
            var spins = rand.Next(22, 30);
            double speed = rand.Next(41, 51);
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
                    Thread.Sleep((int)Math.Ceiling(speed *= 1.08));
            }

            int wheelPosition = spins % 8;
            wheel.SetPrize(wheelPosition == 0
                ? wheel.GetPrizes()[wheelPosition]
                : wheel.GetPrizes()[wheelPosition - 1]);
            Thread.Sleep(1200);
            e.Dispose();


        }

    }
}
