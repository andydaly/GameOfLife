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
    public class EraseButton : Entity
    {
        // sets the cursor in tableinterface to erase cell
        bool Pressed;
        public bool Erase, OptionsOn;

        public EraseButton(int PosX, int PosY, bool Erase)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.Erase = Erase;
        }

        public override void LoadContent()
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>("erasebutton");
            Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            Position = new Vector2((float)PosX, (float)PosY);
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
                Erase = !Erase;
                OptionsOn = false;
                Pressed = true;
                Altered = true;
            }

        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);



        }
    }
}
