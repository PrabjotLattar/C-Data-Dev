using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
   public class Ball
    {
        

        private readonly int ballSize = 32;

        private Rectangle ballDisplayArea;
        private Rectangle gameplayArea;
        private SolidBrush brush;
      //  private Boolean left;

        public string Face { get; set; }
        public Boolean XLocation { get; set; }

        /// <summary>
        /// Drows the pacman
        /// gets the image from the folder in documents
        /// </summary>
        /// <param name="graphics">gets the graphics from form</param>
        public void Draw(Graphics graphics)
        {
           
            Bitmap myBitmap = new Bitmap(@"image\pacmanBmp.bmp");
            switch (Face)
                {
                case "Left":
                    {                       
                        myBitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;
                    }
                case "Right":
                    {
                        break;
                    }
                case "Up":
                    {                       
                        myBitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    }
                case "Down":
                    {                       
                        myBitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
                        break;
                    }
            }                        
            graphics.DrawImage(myBitmap, ballDisplayArea);
        }

        /// <summary>
        /// Assign the size of pacman
        /// Set up the location of the pacman to start with
        /// </summary>
        /// <param name="gameplayArea">Area of the display screen</param>
        public Ball(Rectangle gameplayArea)
        {
            ballDisplayArea.Height = ballSize;
            ballDisplayArea.Width = ballSize;
            this.gameplayArea = gameplayArea;

            //this gives the location for the pacman to start with 
            ballDisplayArea.Y = gameplayArea.Top + 5;
            ballDisplayArea.X = 2; 

            brush = new SolidBrush(Color.Yellow);

        }

        public enum Direction { Left, Right, Up, Down };

        /// <summary>
        /// Gets the direction from form and then  move the packman as per direction
        /// Vlidates if packman is in the display area
        /// if (XLocation) is true then it reverses the move
        /// </summary>
        /// <param name="direction">Gets Direction to move; like Left Right Up Down</param>
        public void Move(Direction direction)
        {
            
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (XLocation)
                        {
                            if (ballDisplayArea.X > gameplayArea.Left)
                            {
                                ballDisplayArea.X -= 5;
                            }
                        }
                        else
                        {
                            ballDisplayArea.X += 5;
                        }

                        break;
                    }
                case Direction.Right:
                    {
                        if (XLocation)
                        {
                            if (ballDisplayArea.X + ballSize < gameplayArea.Right && XLocation)
                            {
                                ballDisplayArea.X += 5;
                                
                            }
                            else
                            {
                                ballDisplayArea.X = gameplayArea.Right - ballSize;
                            }
                        }
                        else
                        {
                            ballDisplayArea.X -= 5;
                        }

                        break;
                    }

                case Direction.Up:
                    {
                        if (XLocation)
                        {
                            if (ballDisplayArea.Y > gameplayArea.Top)
                            {
                                ballDisplayArea.Y -= 5;
                            }
                        }
                        else
                        {
                            ballDisplayArea.Y += 5;
                        }

                        break;
                    }

                case Direction.Down:
                    {
                        if (XLocation)
                        {
                            if (ballDisplayArea.Y < gameplayArea.Height - ballSize)
                            {
                                ballDisplayArea.Y += 5;
                            }
                            else
                            {
                                ballDisplayArea.Y = gameplayArea.Height - ballSize;
                            }
                        }
                        else
                        {
                            ballDisplayArea.Y -= 5;
                        }

                        break;
                    }


            }


        }

        /// <summary>
        /// returns the display area of pacman
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return ballDisplayArea; }
        }

        /// <summary>
        /// Sends the packman to home to start again
        /// </summary>
        public void GoHome()
        {
            
            ballDisplayArea.Y = gameplayArea.Top + 5;
            ballDisplayArea.X = 2;
        }

    }
}
