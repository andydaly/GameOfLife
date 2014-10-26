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
    public class TableInterface : Entity
    {
        // turn on cells on table, turns off cells if erase is on
        int Size;
        int DistX, DistY = 0;
        public bool Erase;
        

        public TableInterface(int NumX, int NumY, int X, int Y, int Size, bool[,] Switch, bool Erase)
        {
            this.NumX = NumX;
            this.NumY = NumY;
            this.PosX = X;
            this.PosY = Y;
            this.SwitchArray = Switch;
            this.Size = Size;
            this.Erase = Erase;
        }

        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mousepos = Mouse.GetState();
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;


            for (int j = 0; j < NumY; j++)
            {
                for (int i = 0; i < NumX; i++)
                {
                    if ((mousepos.X > PosX + DistX) && (mousepos.X < PosX + DistX + Size) &&
                    (mousepos.Y > PosY + DistY) && (mousepos.Y < PosY + DistY + Size))
                    {
                        if (mousepos.LeftButton == ButtonState.Pressed)
                        {   
                            if (!Erase)
                                SwitchArray[i, j] = true;
                            else if (Erase)
                                SwitchArray[i, j] = false;
                            Altered = true;
                        }
                    }
                    DistX += Size;
                }
                DistX = 0;
                DistY += Size;
            }
            DistY = 0;

        }

        public override void Draw(GameTime gameTime)
        {

        }
    }
}
