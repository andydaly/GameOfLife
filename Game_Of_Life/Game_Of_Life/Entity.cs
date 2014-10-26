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
    
    public abstract class Entity
    {
        // each game of life class inherits from entity
        public bool Altered = false;
        public int NumX, NumY, PosX, PosY;
        public bool[,] SwitchArray;
        public Texture2D Sprite;
        public int Width = Game1.Instance.Width;
        public int Height = Game1.Instance.Height;
        public float Scale = 1.5f;
        public Vector2 Position;
        public Vector2 Center;

        public Entity()
        {

        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
