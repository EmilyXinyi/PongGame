using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{

    public partial class FormPong : Form
    {
        //All global variables are here
        public Random rnd = new Random();
        public int LPx, LPy, RPx, RPy, LScore, RScore, LPvel, RPvel;
        public bool RightWins;

        //the ball that will appear on the screen
        ball GameBall = new ball();
        
        public FormPong()
        {
            InitializeComponent();

            //initial values
            GameTimer.Start();
            GameBall.xpos = pbBackGround.Width / 2;
            GameBall.ypos = pbBackGround.Height / 2;
            GameBall.xvel = rnd.Next(-3,3);
            //to prevent xvel=0, if it assigned to be 0 by rnd, it will be reassigned 3
            if (GameBall.xvel ==0)
            {
                GameBall.xvel = 3; 
            }
            //pythagorean theorem to calculate yvel 
            //total speed is always 9
            GameBall.yvel = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(Math.Pow(9, 2) - Math.Pow(GameBall.xvel, 2))));
            //initial position of paddles
            LPx = pbBackGround.Width / 6;
            LPy = pbBackGround.Height / 2;
            RPx = (pbBackGround.Width / 6) * 5;
            RPy = pbBackGround.Height / 2;
            //initial scores
            LScore = 0;
            RScore = 0;
            //transparent background for scoreboard
            lblLeftScore.Parent = pbBackGround;
            lblRightsScore.Parent = pbBackGround;
        }

        //KeyDown, controls movements of the paddles
        private void FormPong_KeyDown(object sender, KeyEventArgs e)
        {
            //left paddle
            if (e.KeyCode == Keys.W)
            {
                LPvel = -10;
            }
            else if (e.KeyCode == Keys.S)
            {
                LPvel = 10;
            }
            //right paddle 
            if (e.KeyCode == Keys.Up)
            {
                RPvel = -10;
            }
            else if (e.KeyCode == Keys.Down)
            {
                RPvel = 10;
            }
           
        }

        //when a key is released, the paddle velocity is zero
        private void FormPong_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    RPvel = 0;
                    break;

                case Keys.Up:
                    RPvel = 0;
                    break;

                case Keys.W:
                    LPvel = 0;
                    break;

                case Keys.S:
                    LPvel = 0;
                    break;
            }
        }
        public class ball
        {
            //velocity and position
            public int xvel;
            public int yvel;
            public int xpos;
            public int ypos;

            //Rebound method (for borders)
            public void rebound(int minHeight, int maxHeight)
            {
                //border rebounds
                if (ypos < minHeight || ypos > maxHeight - 10)
                {
                    yvel = yvel * (-1);
                }
            }

            //Draw ball method
            public void drawball(Graphics g, int xpos, int ypos)
            {
                SolidBrush ballbrush = new SolidBrush(Color.White);
                g.FillRectangle(ballbrush, xpos, ypos, 10, 10);
            }
        }
        //Draw paddle method
        public void DrawPaddles(Graphics g)
        {
            SolidBrush PaddleBrush = new SolidBrush(Color.White);
            g.FillRectangle(PaddleBrush, LPx, LPy, 10, 30);
            g.FillRectangle(PaddleBrush, RPx, RPy, 10,30);
        }

        //Win method
        //Updates the scoreboard and resets the game
        public void Win()
        {
            GameTimer.Stop();
            lblLeftScore.Text = LScore.ToString();
            lblRightsScore.Text = RScore.ToString();
            if (RightWins == true)
            {
                GameBall.xpos = pbBackGround.Width / 2;
                GameBall.ypos = pbBackGround.Height / 2;
                GameBall.xvel = rnd.Next(-5, -2);
                GameBall.yvel = rnd.Next(-1, 1) * Convert.ToInt32(Math.Sqrt(Convert.ToDouble(Math.Pow(9, 2) - Math.Pow(GameBall.xvel, 2))));
            }
            else if (RightWins == false)
            {
                GameBall.xpos = pbBackGround.Width / 2;
                GameBall.ypos = pbBackGround.Height / 2;
                GameBall.xvel = rnd.Next(2, 5);
                GameBall.yvel = rnd .Next(-1, 1)*Convert.ToInt32(Math.Sqrt(Convert.ToDouble(Math.Pow(9, 2) - Math.Pow(GameBall.xvel, 2))));
            }
            LPvel = 0;
            RPvel = 0;
            GameTimer.Start(); 
        }

        //collision method
        public void Collision()
        {
            //left paddle
            if (GameBall.xpos <= LPx + 10 && GameBall.ypos + 10 > LPy && GameBall.ypos < LPy + 30)
            {
                GameBall.xvel = GameBall.xvel * (-1);
                GameBall.yvel = GameBall.yvel + LPvel;
            }
            //right paddle
            else if (GameBall.xpos >= RPx - 10 && GameBall.ypos + 10 > RPy && GameBall.ypos < RPy + 30)
            {
                GameBall.xvel = GameBall.xvel * -1;
                GameBall.yvel = GameBall.yvel + RPvel;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Updating ball's position
            GameBall.xpos += GameBall.xvel;
            GameBall.ypos += GameBall.yvel;

            // move the paddles
            LPy += LPvel;
            RPy += RPvel;

            //Upper and lower limits so the paddles don't go out of frame
            //left paddle
            if (0 > LPy)
            {
                LPy = 0;
            }
            else if (LPy > pbBackGround.Height - 30)
            {
                LPy = pbBackGround.Height - 30;
            }
            //right paddle
            if (0 > RPy)
            {
                RPy = 0;
            }
            else if (RPy > pbBackGround.Height - 30)
            {
                RPy = pbBackGround.Height - 30;
            }

            //if the ball rebounds along the top or bottom of the picturebox
            GameBall.rebound(0, pbBackGround.Height);

            //if the ball collides with one of the paddles
            Collision(); 

            //Checking to see if the game meets winning conditions
            //if winning conditions are met, the score and previous win is updated, and the win method is called
            if (GameBall.xpos > RPx+10)
            {
                LScore++;
                RightWins = false;
                Win();
            }
            else if (GameBall.xpos < LPx-10)
            {
                RScore++;
                RightWins = true;
                Win();
            }
            //updating graphics
            pbBackGround.Invalidate();
        }

        //drawing everything in the background picturebox
        private void pbBackGround_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush myBrush = new SolidBrush(Color.White);
            //dotted white line down the middle
            for (int i= 1; i<pbBackGround.Height; i=i+30)
            {
                g.FillRectangle(myBrush, (pbBackGround.Width / 2) - 10, i, 10, 20);
            }
            //ball and paddle
            GameBall.drawball(g, GameBall.xpos, GameBall.ypos);
            DrawPaddles(g);
        }
    }
}
