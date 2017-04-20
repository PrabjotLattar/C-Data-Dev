using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    
    /// <summary>
    /// For for maze game
    /// </summary>
    public partial class Form1 : Form
    {
        Ball ball;
        // Block block;
        Font font;
        SolidBrush textBrush;
        Point NextLavel;
        int counter;
        int level;
        HashSet<Block> blocks = new HashSet<Block>();

       

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs when the programe is started and Form gets loaded
        /// Maximizes the screen
        /// creats packman(ball)
        /// creats blocks in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
                ball = new Ball(this.DisplayRectangle);
                blocks.Add(new Block(this.DisplayRectangle));
            counter = 1;
            level = 1;

        }


       /// <summary>
       /// paint to draw blocks pacman and message
       /// On collission with exit block it let go 15 point move using counter
       /// then puts thread on sleep for 5 sec
       /// and then moves pacman to start and random move the exit door
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
            // block.Draw(e.Graphics);
            foreach (Block block in blocks)
            {
                block.Draw(e.Graphics);
                DisplayLevel(e.Graphics);
                //checkss if the packman is at exit and displays message 
                if (ball.DisplayArea.IntersectsWith(block.DisplayAreaExit))
                {
                    DisplayMessage(e.Graphics);
                    // timer.Start();                               
                    if (counter == 6)
                    {
                        Thread.Sleep(5000);
                        ball.GoHome();
                        block.ChangeExit();
                        block.Draw(e.Graphics);
                        counter = 1;
                        level += 1;
                    }
                    
                    counter += 1;                    
                }                
            }            
        }

        /// <summary>
        /// Key stroke event handler
        /// gets activated on press of up down left or right arrow key
        /// Switch checks for the key type and runs Move Method in Balls class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        ball.Face = "Left";
                        ball.XLocation = true;
                        ball.Move(Ball.Direction.Left);
                        CheckForCollisions("Left");
                        Invalidate();
                        break;
                    }
                case Keys.Right:
                    {
                        ball.Face = "Right";
                        ball.XLocation = true;
                        ball.Move(Ball.Direction.Right);
                        Invalidate();
                        CheckForCollisions("Right");
                        
                        break;
                    }
                case Keys.Up:
                    {
                        ball.Face = "Up";
                        ball.XLocation = true;
                        ball.Move(Ball.Direction.Up);
                        Invalidate();
                        CheckForCollisions("Up");
                        break;
                    }
                case Keys.Down:
                    {
                        ball.Face = "Down";
                        ball.XLocation = true;
                        ball.Move(Ball.Direction.Down);
                        Invalidate();
                        CheckForCollisions("Down");
                        break;
                    }
            }
        }//end key down 





        private void timer_Tick_1(object sender, EventArgs e)
        {
            //ball.GoHome();
            //foreach (Block block in blocks)
            //{
            //    block.ChangeExit();
            //    //block.Draw(e.Graphics);
            //}
            //    Invalidate();
        }

        /// <summary>
        /// Checks for collission of pacman with side walls
        /// and with blocks in the game
        /// on Collission turns the XLocation bool to true
        /// calls Move method in Balls class and reverse the move 
        /// </summary>
        /// <param name="Direction">gets the Key press direction</param>
        private void CheckForCollisions(String Direction)
        {

            //check ball collision with blocks
            foreach (Block block in blocks)
            {
                //checks if pacman is at exit
                //if (ball.DisplayArea.IntersectsWith(block.DisplayAreaExit))
                //{
                //    // ball.GoHome();
                //    //message
                //    level += 1;
                //}

                if (ball.DisplayArea.IntersectsWith(block.DisplayArea) ||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea2) ||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea3) ||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea4)||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea5)||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea6)||
                    ball.DisplayArea.IntersectsWith(block.DisplayArea7))
                {
                    switch (Direction)
                    {
                        case "Right":
                            {
                                ball.XLocation = false;
                                ball.Move(Ball.Direction.Right);
                                break;
                            }

                        case "Down":
                            {
                                ball.XLocation = false;
                                ball.Move(Ball.Direction.Down);
                                break;
                            }
                        case "Left":
                            {
                                ball.XLocation = false;
                                ball.Move(Ball.Direction.Left);
                                break;
                            }
                        case "Up":
                            {
                                ball.XLocation = false;
                                ball.Move(Ball.Direction.Up);
                                break;
                            }
                    }//end switch

                }//end if 
            }

        }


        private void DisplayMessage(Graphics graphics)
        {

            font = new Font("Arial Unicode MS", 20);
            textBrush = new SolidBrush(Color.White);
            NextLavel = new Point(326, 216);
            string message = string.Format("Next Level");

            //do the draw
            graphics.DrawString(message, font, textBrush, NextLavel);
        }

        private void DisplayLevel(Graphics graphics)
        {

            font = new Font("Arial Unicode MS", 13);
            textBrush = new SolidBrush(Color.White);
            NextLavel = new Point(580, 400);

            string message = string.Format("Level: {0}",level);

            //do the draw
            graphics.DrawString(message, font, textBrush, NextLavel);
        }



    }
}
