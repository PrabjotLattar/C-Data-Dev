using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    /// <summary>
    /// Drows blocks that will act as walls in pacman game
    /// </summary>
   public class Block
    {
        private readonly int blockHeight = 10;
        private readonly int blockWidth = 250;

        private Rectangle blockDisplayArea;
        private Rectangle block2DisplayArea;
        private Rectangle block3DisplayArea;
        private Rectangle blockUp2DisplayArea;
        private Rectangle blockUp3DisplayArea;
        private Rectangle blockD2DisplayArea;
        private Rectangle blockH4DisplayArea;
        private Rectangle exitBlockDisplayArea;
        private Rectangle gameplayArea;

        private SolidBrush brush;

        private SolidBrush brushExit;

        Random random = new Random();

        /// <summary>
        /// Sets the width and height off each block
        /// set multiple blocks to be drawn
        /// set up the display area for blocks
        /// </summary>
        /// <param name="gameplayArea">Display area where the game will be played</param>
        public Block(Rectangle gameplayArea)
        {
            //generates random number to assign random exit location
            int randomX = random.Next(300, 612);
            int randomY = random.Next(0, 372);
            this.gameplayArea = gameplayArea;

            blockDisplayArea.Height = blockHeight;
            blockDisplayArea.Width = blockWidth;

            block2DisplayArea.Height = blockHeight;
            block2DisplayArea.Width = blockWidth;

            blockH4DisplayArea.Height = blockHeight;
            blockH4DisplayArea.Width = blockWidth;

            blockUp2DisplayArea.Height = gameplayArea.Height - 150; 
            blockUp2DisplayArea.Width = 10;

            blockUp3DisplayArea.Height = gameplayArea.Height - 150; 
            blockUp3DisplayArea.Width = 10;

            blockD2DisplayArea.Height = blockHeight;
            blockD2DisplayArea.Width = blockWidth;

            block3DisplayArea.Height = 10;
            block3DisplayArea.Width = 140;

            exitBlockDisplayArea.Height = 60;
            exitBlockDisplayArea.Width = 40;

            //this.gameplayArea = gameplayArea;
            //first horizontal block
            blockDisplayArea.Y = gameplayArea.Top +  100;
            blockDisplayArea.X = + 100; 

            //second horizontal block
            block2DisplayArea.Y = gameplayArea.Top + 282;
            block2DisplayArea.X = +100;

            blockUp2DisplayArea.Y = gameplayArea.Top;
            blockUp2DisplayArea.X = 207;

            //horizontal block3
            blockD2DisplayArea.Y = gameplayArea.Height / 2;
            blockD2DisplayArea.X = gameplayArea.Width - 300;

            //horizontal block4
            blockH4DisplayArea.Y = gameplayArea.Bottom - 90; 
            blockH4DisplayArea.X = gameplayArea.Width - 300;

            blockUp3DisplayArea.Y = gameplayArea.Bottom - 282;
            blockUp3DisplayArea.X = gameplayArea.Width - 207;

            block3DisplayArea.Y = gameplayArea.Height / 2;
            block3DisplayArea.X = +1;

            exitBlockDisplayArea.Y = randomY;
            exitBlockDisplayArea.X = randomX;

            brush = new SolidBrush(Color.Black);
            brushExit = new SolidBrush(Color.Red);
        }

        /// <summary>
        /// Draws all the blocks
        /// </summary>
        /// <param name="graphics">gets graphics from form</param>
        public void Draw(Graphics graphics)
        {

            graphics.FillRectangle(brush, blockDisplayArea);

            graphics.FillRectangle(brush, block2DisplayArea);

            graphics.FillRectangle(brush, block3DisplayArea);

            Bitmap myBitmap = new Bitmap(@"image\Door.bmp");
            graphics.DrawImage(myBitmap, exitBlockDisplayArea);

           // graphics.FillRectangle(brushExit, exitBlockDisplayArea);

            graphics.FillRectangle(brush, blockUp2DisplayArea);

            graphics.FillRectangle(brush, blockUp3DisplayArea);

            graphics.FillRectangle(brush, blockD2DisplayArea);

            graphics.FillRectangle(brush, blockH4DisplayArea);

        }

        public Rectangle DisplayArea
        {
            get { return blockDisplayArea; }
            
        }

        public Rectangle DisplayArea2
        {
            get  { return block2DisplayArea; }
        }

        public Rectangle DisplayArea3
        {
            get { return block3DisplayArea; }
        }

        public Rectangle DisplayArea4
        {
            get { return blockD2DisplayArea; }
        }

        public Rectangle DisplayArea5
        {
            get { return blockUp2DisplayArea; }
        }

        public Rectangle DisplayArea6
        {
            get { return blockUp3DisplayArea; }
        }

        public Rectangle DisplayAreaExit
        {
            get { return exitBlockDisplayArea; }
        }

        public Rectangle DisplayArea7
        {
            get { return blockH4DisplayArea; }
        }
        


        /// <summary>
        /// Assigns new point to the exit block for new level
        /// </summary>
        public void ChangeExit()
        {
            int randomX = random.Next(10, 642);
            int randomY = random.Next(0, 372);
            exitBlockDisplayArea.Y = randomY;//gameplayArea.Bottom - 60;
            exitBlockDisplayArea.X = randomX;

        }




    }
}
