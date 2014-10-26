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
    public class ClearButton : Entity
    {
        // Options button to clear screen
        bool Pressed;


        public ClearButton(int PosX, int PosY, int NumX, int NumY, bool[,] Switch)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.NumX = NumX;
            this.NumY = NumY;
            this.SwitchArray = Switch;
        }

        public override void LoadContent()
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>("clearbutton");
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
                for (int j = 0; j < NumY; j++)
                {
                    for (int i = 0; i < NumX; i++)
                    {
                        SwitchArray[i, j] = false;
                    }
                    Altered = true;
                }

                Pressed = true;
            
            }
        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);



        }
    }
}
