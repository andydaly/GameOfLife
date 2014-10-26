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
    public class Pixel : Entity
    {
        // Individual life pixel

        int Size;
        bool Switch;
        Rectangle Point;

        public Pixel(int X, int Y, int Size, bool Switch)
        {
            this.PosX = X;
            this.PosY = Y;
            this.Size = Size;
            this.Switch = Switch;

        }



        public override void LoadContent()
        {

            Point = new Rectangle(PosX, PosY, Size, Size);
            Sprite = Game1.Instance.Content.Load<Texture2D>("Pixel");
        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void Draw(GameTime gameTime)
        {

            if (Switch)
                Game1.Instance.spriteBatch.Draw(Sprite, Point, Color.Yellow);
            else
                Game1.Instance.spriteBatch.Draw(Sprite, Point, Color.Purple);
        }
    }
}
