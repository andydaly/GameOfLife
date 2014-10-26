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
    public class TitleScreen : Entity
    {
        // Title Screen holds all Starting screen objects

        Shape Shapes;
        Title GameTitle;
        StartButton GameStart;
        TextOptions GameOptions;
        public bool Commence;
        Random RandOperator;
        int Display = 0;
        int DistX, DistY;
        public bool WaitSwitch = false;
        Song song;

        public TitleScreen(int NumX, int NumY, bool[,] Switch)
        {

            this.NumX = NumX;
            this.NumY = NumY;
            this.SwitchArray = Switch;
        }

        public override void LoadContent()
        {
            song = Game1.Instance.Content.Load<Song>("Omnitica");
            MediaPlayer.Play(song);
            RandOperator = new Random();
            Shapes = new Shape(NumX, NumY, SwitchArray);

            GameTitle = new Title(Width / 2, 80);
            GameStart = new StartButton(Width / 2, (Height / 2)+10);
            GameOptions = new TextOptions(Width - 80, Height - 80);

            GameTitle.LoadContent();
            GameStart.LoadContent();
            GameOptions.LoadContent();

            // Random Shapes chosen for opening display
            Display = RandOperator.Next(1, 8);

            if (Display == 1)
            {
                Shapes.Exploder(1, 7);
                Shapes.Exploder(11, 7);
                Shapes.Exploder(21, 7);
            }
            else if (Display == 2)
            {
                for (int j = 0; j < (NumY / 5); j++)
                {
                    for (int i = 0; i < (NumX / 5); i++)
                    {
                        Shapes.Blinker(i+DistX+1, j+DistY+2);
                        DistX += 4;
                    }
                    DistX = 0;
                    DistY += 4;
                }
   
            }
            else if (Display == 3)
            {
                Shapes.SpaceShipRight(0, 2);
                Shapes.SpaceShipLeft(20, 2);
            }
            else if (Display == 4)
            {
                Shapes.GliderRightDown(0, 0);
                Shapes.GliderLeftDown(22, 0);
                Shapes.Exploder(11, 6);
                Shapes.GliderRightUp(0, 12);
                Shapes.GliderLeftUp(22, 12);
            }
            else if (Display == 5)
            {
                Shapes.GliderRightDown(0, 0);
                Shapes.GliderLeftDown(22, 0);
                Shapes.GliderRightDown(5, 0);
                Shapes.GliderLeftDown(17, 0);
                Shapes.GliderRightUp(0, 12);
                Shapes.GliderLeftUp(22, 12);
                Shapes.GliderRightUp(5, 12);
                Shapes.GliderLeftUp(17, 12);
            }
            else if (Display == 6)
            {
                int Pentomino = RandOperator.Next(1, 3);

                if (Pentomino == 1)
                    Shapes.PentominoLeft(16, 6);
                else
                    Shapes.PentominoRight(5, 6);
            }

            
        }

        public override void Update(GameTime gameTime)
        {
            
            GameStart.Update(gameTime);
            Commence = GameStart.Commence;
            WaitSwitch = GameStart.WaitSwitch;
            if (Commence)
            {
                for (int j = 0; j < NumY; j++)
                {
                    for (int i = 0; i < NumX; i++)
                    {
                        SwitchArray[i, j] = false;
                    }
                }
                Altered = true;
            }
        }


        public override void Draw(GameTime gameTime)
        {
            GameTitle.Draw(gameTime);
            GameStart.Draw(gameTime);
            GameOptions.Draw(gameTime);
        }
    }
}
