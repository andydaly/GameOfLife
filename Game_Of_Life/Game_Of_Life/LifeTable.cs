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
    public class LifeTable : Entity
    {

        //Prints life table
        int Size; 
        int DistX, DistY = 0;
        
        

        public LifeTable(int NumX, int NumY, int X, int Y, int Size, bool[,] Switch)
        {
            this.NumX = NumX;
            this.NumY = NumY;
            this.PosX = X;
            this.PosY = Y;
            this.SwitchArray = Switch;
            this.Size = Size;


        }

        public override void LoadContent()
        {
            for (int i = 0; i < Game1.Instance.ScreenObjects.Count(); i++)
            {
                Game1.Instance.ScreenObjects.Remove(Game1.Instance.ScreenObjects[i]);
            }

            for (int j = 0; j < NumY; j++)
            {
                for (int i = 0; i < NumX; i++)
                {
                    Pixel Dot = new Pixel(PosX + DistX, PosY + DistY, Size, SwitchArray[i, j]);
                    Dot.LoadContent();
                    Game1.Instance.ScreenObjects.Add(Dot);

                    DistX += Size;
                }
                DistX = 0;
                DistY += Size;
            }
            DistY = 0;
        }






        public override void Update(GameTime gameTime)
        {


        }

        public override void Draw(GameTime gameTime)
        {

        }
    }
}
