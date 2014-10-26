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
    public class TimeConfig : Entity
    {
        // configure the games generation movement time
        public float UpdateTime = 0.0f;
        bool Pressed;
        Texture2D Sprite2;
        Vector2 Position2, Position3;
        Vector2 Center2;
        SpriteFont TimeFont;
        string Display = "";

        public TimeConfig(int PosX, int PosY, float UpdateTime)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.UpdateTime = UpdateTime;
            
        }

        public override void LoadContent()
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>("minusbutton");
            Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            Position = new Vector2((float)PosX - Sprite.Width, (float)PosY + Sprite.Height);

            Sprite2 = Game1.Instance.Content.Load<Texture2D>("plusbutton");
            Center2 = new Vector2(Sprite2.Width / 2, Sprite2.Height / 2);
            Position2 = new Vector2((float)PosX + Sprite2.Width, (float)PosY + Sprite2.Height);


            TimeFont = Game1.Instance.Content.Load<SpriteFont>("Timer");
            Position3 = new Vector2((float)PosX-55, (float)PosY - Sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mousepos = Mouse.GetState();
            
          
            if (mousepos.LeftButton != ButtonState.Pressed)
                Pressed = false;
            if ((!Pressed) && (mousepos.LeftButton == ButtonState.Pressed) &&
                ((mousepos.X > (Position.X - ((Sprite.Width / 2) * Scale))) && (mousepos.X < (Position.X + ((Sprite.Width / 2) * Scale))) &&
                (mousepos.Y > (Position.Y - ((Sprite.Height / 2) * Scale))) && (mousepos.Y < (Position.Y + ((Sprite.Height / 2) * Scale)))))
            {
                if (UpdateTime > 0.1f)
                    UpdateTime -= 0.1f;

                Pressed = true;

            }

            if ((!Pressed) && (mousepos.LeftButton == ButtonState.Pressed) &&
                ((mousepos.X > (Position2.X - ((Sprite2.Width / 2) * Scale))) && (mousepos.X < (Position2.X + ((Sprite2.Width / 2) * Scale))) &&
                (mousepos.Y > (Position2.Y - ((Sprite2.Height / 2) * Scale))) && (mousepos.Y < (Position2.Y + ((Sprite2.Height / 2) * Scale)))))
            {
                if (UpdateTime < 4.9f)
                    UpdateTime += 0.1f;

                Pressed = true;

            }

            Display = string.Format("{0:0.#}", UpdateTime);
        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);
            Game1.Instance.spriteBatch.Draw(Sprite2, Position2, null, Color.White, 0, Center2, Scale, SpriteEffects.None, 0);
            Game1.Instance.spriteBatch.DrawString(TimeFont, Display, Position3, Color.White);
               


        }
    }
}
