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
using Microsoft.Xna.Framework.Input.Touch;


namespace Game_Of_Life
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StartButton : Entity
    {
        // button commences gamee of life
        public bool Commence = false;
        public bool WaitSwitch = false;

        public StartButton(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
        }

        public override void LoadContent()
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>("startbutton");
            Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            Position = new Vector2((float)PosX, (float)PosY);

        }

        public override void Update(GameTime gameTime)
        {
            // Experimenting with touch for start button, mouse used in other classes as more accessible
            TouchCollection touches = TouchPanel.GetState();
            foreach (TouchLocation touch in touches)
            {
                if ((touch.State == TouchLocationState.Pressed) &&
                ((touch.Position.X > (Position.X - ((Sprite.Width / 2) * Scale))) && (touch.Position.X < (Position.X + ((Sprite.Width / 2) * Scale))) &&
                (touch.Position.Y > (Position.Y - ((Sprite.Height / 2) * Scale))) && (touch.Position.Y < (Position.Y + ((Sprite.Height / 2)) * Scale))))
                {
                    WaitSwitch = true;
                    Commence = true;
                    MediaPlayer.Stop(); // music switched off on game startup
                }
            }
        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);

        }
    }
}
