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
    public class TimeButton : Entity
    {
        // if game is paused, can skip generations, if not paused turns on time configuration
        public bool Paused;
        public bool Skip;
        public bool Pressed;
        public bool TimeControls;

        public TimeButton(int PosX, int PosY, bool Paused, bool Skip, bool TimeControls,  bool Pressed)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.Paused = Paused;
            this.Skip = Skip;
            this.TimeControls = TimeControls;
            this.Pressed = Pressed;
        }

        public override void LoadContent()
        {
            if (Paused)
            {
                Sprite = Game1.Instance.Content.Load<Texture2D>("skipbutton");
                Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
                Position = new Vector2((float)PosX, (float)PosY);
            }
            else
            {
                Sprite = Game1.Instance.Content.Load<Texture2D>("timebutton");
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
                ((mousepos.X > (Position.X - (((Sprite.Width / 2) * Scale) - 20))) && (mousepos.X < (Position.X + (((Sprite.Width / 2) * Scale) - 20))) &&
                (mousepos.Y > (Position.Y - (((Sprite.Height / 2) * Scale) - 20))) && (mousepos.Y < (Position.Y + (((Sprite.Height / 2) * Scale) - 20)))))
            {
                if (Paused)
                {
                    Skip = true;
                }
                else
                {
                    if (TimeControls)
                        TimeControls = false;
                    else if (!TimeControls)
                        TimeControls = true;
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
