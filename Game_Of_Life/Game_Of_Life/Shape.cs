using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Game_Of_Life
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Shape : Entity
    {
        // Shape class, not completed, more to come in update

        public Shape(int NumX, int NumY, bool[,] Switch)
        {
            this.NumX = NumX;
            this.NumY = NumY;
            this.SwitchArray = Switch;
        }

        public override void LoadContent()
        {


        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void Draw(GameTime gameTime)
        {


        }

        public void Block(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            
            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX+1, PosY] = !SwitchArray[PosX+1, PosY];
            SwitchArray[PosX, PosY+1] = !SwitchArray[PosX, PosY+1];
            SwitchArray[PosX+1, PosY+1] = !SwitchArray[PosX+1, PosY+1];

        }

        public void Beehive(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX+1, PosY] = !SwitchArray[PosX+1, PosY];
            SwitchArray[PosX, PosY+1] = !SwitchArray[PosX, PosY+1];
            SwitchArray[PosX+2, PosY] = !SwitchArray[PosX+2, PosY];
            SwitchArray[PosX+3, PosY+1] = !SwitchArray[PosX+3, PosY+1];
            SwitchArray[PosX+1, PosY+2] = !SwitchArray[PosX+1, PosY+2];
            SwitchArray[PosX+2, PosY+2] = !SwitchArray[PosX+2, PosY+2];
        }

        public void LoafRightUp(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];
            SwitchArray[PosX + 3, PosY + 1] = !SwitchArray[PosX + 3, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
            SwitchArray[PosX + 2, PosY + 3] = !SwitchArray[PosX + 2, PosY + 3];
            SwitchArray[PosX + 3, PosY + 2] = !SwitchArray[PosX + 3, PosY + 2];
        }

        public void BoatLeftUp(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX+1, PosY] = !SwitchArray[PosX+1, PosY];
            SwitchArray[PosX, PosY+1] = !SwitchArray[PosX, PosY+1];
            SwitchArray[PosX + 2, PosY + 1] = !SwitchArray[PosX + 2, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
        }

        public void Blinker(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];    
        }

        public void Toad(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];
            SwitchArray[PosX + 3, PosY] = !SwitchArray[PosX + 3, PosY];
            SwitchArray[PosX, PosY+1] = !SwitchArray[PosX, PosY+1];
            SwitchArray[PosX + 1, PosY+1] = !SwitchArray[PosX + 1, PosY+1];
            SwitchArray[PosX + 2, PosY+1] = !SwitchArray[PosX + 2, PosY+1];
        }

        public void BeaconLeft(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX , PosY+1] = !SwitchArray[PosX , PosY+1];
            SwitchArray[PosX+3, PosY + 2] = !SwitchArray[PosX+3, PosY + 2];
            SwitchArray[PosX + 2, PosY + 3] = !SwitchArray[PosX + 2, PosY + 3];
            SwitchArray[PosX + 3, PosY + 3] = !SwitchArray[PosX + 3, PosY + 3];
        }

        public void GliderRightDown(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX+1, PosY] = !SwitchArray[PosX+1, PosY];
            SwitchArray[PosX + 2, PosY+1] = !SwitchArray[PosX + 2, PosY+1];
            SwitchArray[PosX, PosY+2] = !SwitchArray[PosX, PosY+2];
            SwitchArray[PosX + 1, PosY+2] = !SwitchArray[PosX + 1, PosY+2];
            SwitchArray[PosX + 2, PosY + 2] = !SwitchArray[PosX + 2, PosY + 2];
        
        }

        public void GliderLeftDown(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;


            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX, PosY + 2] = !SwitchArray[PosX, PosY + 2];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
            SwitchArray[PosX + 2, PosY + 2] = !SwitchArray[PosX + 2, PosY + 2];

        }

        public void GliderRightUp(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;


            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 2, PosY + 1] = !SwitchArray[PosX + 2, PosY + 1];
            SwitchArray[PosX+1, PosY + 2] = !SwitchArray[PosX+1, PosY + 2];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];

        }

        public void GliderLeftUp(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;


            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];

        }

        public void Exploder(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            

            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX, PosY + 2] = !SwitchArray[PosX, PosY + 2];
            SwitchArray[PosX + 2, PosY + 1] = !SwitchArray[PosX + 2, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
            SwitchArray[PosX + 2, PosY + 2] = !SwitchArray[PosX + 2, PosY + 2];
        }

        public void SpaceShipRight(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;


            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 3, PosY] = !SwitchArray[PosX + 3, PosY];
            SwitchArray[PosX, PosY + 2] = !SwitchArray[PosX, PosY + 2];
            SwitchArray[PosX + 4, PosY + 1] = !SwitchArray[PosX + 4, PosY + 1];
            SwitchArray[PosX + 4, PosY + 2] = !SwitchArray[PosX + 4, PosY + 2];
            SwitchArray[PosX + 4, PosY + 3] = !SwitchArray[PosX + 4, PosY + 3];
            SwitchArray[PosX + 3, PosY + 3] = !SwitchArray[PosX + 3, PosY + 3];
            SwitchArray[PosX + 2, PosY + 3] = !SwitchArray[PosX + 2, PosY + 3];
            SwitchArray[PosX + 1, PosY + 3] = !SwitchArray[PosX + 1, PosY + 3];
        }

        public void SpaceShipLeft(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;


            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 4, PosY] = !SwitchArray[PosX + 4, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX, PosY + 2] = !SwitchArray[PosX, PosY + 2];
            SwitchArray[PosX, PosY + 3] = !SwitchArray[PosX, PosY + 3];
            SwitchArray[PosX + 4, PosY + 2] = !SwitchArray[PosX + 4, PosY + 2];
            SwitchArray[PosX + 3, PosY + 3] = !SwitchArray[PosX + 3, PosY + 3];
            SwitchArray[PosX + 2, PosY + 3] = !SwitchArray[PosX + 2, PosY + 3];
            SwitchArray[PosX + 1, PosY + 3] = !SwitchArray[PosX + 1, PosY + 3];
        }

        public void PentominoLeft(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX + 2, PosY] = !SwitchArray[PosX + 2, PosY];
            SwitchArray[PosX, PosY + 1] = !SwitchArray[PosX, PosY + 1];
            SwitchArray[PosX + 1, PosY + 1] = !SwitchArray[PosX + 1, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
        }

        public void PentominoRight(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            SwitchArray[PosX, PosY] = !SwitchArray[PosX, PosY];
            SwitchArray[PosX + 1, PosY] = !SwitchArray[PosX + 1, PosY];
            SwitchArray[PosX+2, PosY + 1] = !SwitchArray[PosX+2, PosY + 1];
            SwitchArray[PosX + 1, PosY + 1] = !SwitchArray[PosX + 1, PosY + 1];
            SwitchArray[PosX + 1, PosY + 2] = !SwitchArray[PosX + 1, PosY + 2];
        }

    }
}
