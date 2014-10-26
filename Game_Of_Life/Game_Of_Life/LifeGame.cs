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
    public class LifeGame : Entity
    {
        //holds all main components of game of life game
        TitleScreen StartScreen;
        Options OptionsMenu;
        TableInterface TableSelect;
        LifeTable TableInstance;
        Rules AI;
        float Timecount = 0.0f;
        float Timer = 0.0f;
        int Size = 32;
        float UpdateTime = 0.5f; //Update time can be change, this is the speed of generation movement
        bool Pressed = false;
        bool Erase = false;
        
        float WaitCount = 0.0f;
        
        public LifeGame()
        {
            // number of cells allowed on screen based on given pixel size
            if ((Width % Size) == 0)
                NumX = (Width / Size);
            else
                NumX = (Width / Size)+1;

            if ((Height % Size) == 0)
                NumY = (Height / Size);
            else
                NumY = (Height / Size)+1;

            PosX = 0;
            PosY = 0;
            SwitchArray = new bool[500, 500];

        }

        public override void LoadContent()
        {
            for (int j = 0; j < NumY; j++)
            {
                for (int i = 0; i < NumX; i++)
                {
                    SwitchArray[i, j] = false;
                }
            }


            StartScreen = new TitleScreen(NumX, NumY, SwitchArray);
            OptionsMenu = new Options(NumX, NumY, SwitchArray, UpdateTime);
            TableSelect = new TableInterface(NumX, NumY, PosX, PosY, Size, SwitchArray, Erase);
            AI = new Rules(NumX, NumY, TableSelect.SwitchArray);
            TableInstance = new LifeTable(NumX, NumY, PosX, PosY, Size, SwitchArray);

            StartScreen.LoadContent();
            TableInstance.LoadContent();
            OptionsMenu.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mousepos = Mouse.GetState();
            KeyboardState keybState = Keyboard.GetState();
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((OptionsMenu.WaitSwitch) || (StartScreen.WaitSwitch))
            {
                if (WaitCount > 0.5f)
                {
                    WaitCount = 0.0f;
                    OptionsMenu.WaitSwitch = false;
                    StartScreen.WaitSwitch = false;
                }
                WaitCount += timeDelta;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back != ButtonState.Pressed)
                Pressed = false;
            
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) && (!OptionsMenu.OptionsOn) && (StartScreen.Commence))
            {
                OptionsMenu.OptionsOn = true;
                Pressed = true;
            }

            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) && ((OptionsMenu.OptionsOn) || (!StartScreen.Commence)) && (!Pressed))
                Game1.Instance.Exit();




            if ((!OptionsMenu.OptionsOn) && (!OptionsMenu.Paused))
            {
                if (Timecount > 0.5f + Timer)
                {
                    AI.LoadContent();
                    Timer += OptionsMenu.UpdateTime;
                }
                if (StartScreen.Commence)
                {
                    if (mousepos.LeftButton != ButtonState.Pressed)
                    {
                        Timecount += timeDelta;
                    }
                    else if (mousepos.LeftButton == ButtonState.Pressed)
                    {
                        Timer = 0.0f;
                        Timecount = 0.0f;
                    }
                }
                else if (!StartScreen.Commence)
                {
                    Timecount += timeDelta;
                }

            }


            if (OptionsMenu.OptionsOn)
            {
                OptionsMenu.Update(gameTime);
                if ((OptionsMenu.Skip) && (OptionsMenu.Paused))
                {
                    AI.LoadContent();
                    OptionsMenu.Skip = false;
                }
            }


            if ((StartScreen.Commence) && (!OptionsMenu.OptionsOn)) 
            {
                if ((!StartScreen.WaitSwitch) && (!OptionsMenu.WaitSwitch))
                    TableSelect.Update(gameTime);
            }
            else if (!(StartScreen.Commence))
            {
                StartScreen.Update(gameTime);
            }



            if ((TableSelect.Altered) || (AI.Altered) || (OptionsMenu.Altered) || (StartScreen.Altered))
            {
                // table refresh methods
                Erase = OptionsMenu.Erase;
                TableSelect = new TableInterface(NumX, NumY, PosX, PosY, Size, SwitchArray, Erase);
                TableInstance = new LifeTable(NumX, NumY, PosX, PosY, Size, SwitchArray);
                TableInstance.LoadContent();
                TableSelect.Altered = false;
                AI.Altered = false;
                OptionsMenu.Altered = false;
                StartScreen.Altered = false;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            if (!StartScreen.Commence)
                StartScreen.Draw(gameTime);
            if (OptionsMenu.OptionsOn)
                OptionsMenu.Draw(gameTime);
        }

    }
}
