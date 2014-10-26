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
    public class PlayButton : Entity
    {
        // Pauses / Plays generation movement
        public bool Paused;
        bool Pressed;

        public PlayButton(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            //this.Paused = Paused;

        }

        public override void LoadContent()
        {
            if (Paused)
            {
                Sprite = Game1.Instance.Content.Load<Texture2D>("playbutton");
                Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
                Position = new Vector2((float)PosX, (float)PosY);
            }
            else
            {
                Sprite = Game1.Instance.Content.Load<Texture2D>("pausebutton");
                Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
                Position = new Vector2((float)PosX, (float)PosY);
            }
            Altered = false;
        }

        public override void Update(GameTime gameTime)
        {
            


            MouseState mousepos = Mouse.GetState();
            if (mousepos.LeftButton != ButtonState.Pressed)
                Pressed = false;

            if ((!Pressed) && (mousepos.LeftButton == ButtonState.Pressed) &&
                ((mousepos.X > (Position.X - (((Sprite.Width / 2) * Scale) - 25))) && (mousepos.X < (Position.X + (((Sprite.Width / 2) * Scale) - 25))) &&
                (mousepos.Y > (Position.Y - (((Sprite.Height / 2) * Scale)-25))) && (mousepos.Y < (Position.Y + (((Sprite.Height / 2) * Scale)-25))) ))
            {
                if (Paused)
                {
                    Paused = false;
                }
                else
                {
                    Paused = true;
                }
                Altered = true;
                Pressed = true;
            }
            
            
            
        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);


        }
    }
}
