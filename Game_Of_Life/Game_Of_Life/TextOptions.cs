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
    public class TextOptions : Entity
    {
        // just displays text on how to use options
        Vector2 Position2;
        Vector2 Center2;
        Texture2D Sprite2;

        public TextOptions(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
        }

        public override void LoadContent()
        {
            Sprite = Game1.Instance.Content.Load<Texture2D>("backbutton");
            Sprite2 = Game1.Instance.Content.Load<Texture2D>("optionstext");
            Center = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            Position = new Vector2((float)(PosX+15), (float)PosY);
            Center2 = new Vector2(Sprite2.Width / 2, Sprite2.Height / 2);
            Position2 = new Vector2((float)(PosX-150), (float)PosY);

        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(Sprite, Position, null, Color.White, 0, Center, Scale, SpriteEffects.None, 0);
            Game1.Instance.spriteBatch.Draw(Sprite2, Position2, null, Color.White, 0, Center2, Scale, SpriteEffects.None, 0);
        }
    }
}
