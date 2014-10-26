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
    public class Options : Entity
    {
        // Options class, holds all options subclasses, and performs some option functions
        public bool Skip=false;
        public bool Paused=false;
        PlayButton PlayPause;
        TimeButton TimeSkip;
        ClearButton Clear;
        EraseButton Eraser;
        TimeConfig TimerChange;
        public bool OptionsOn = false;
        public bool WaitSwitch = false;
        public bool Pressed = false;
        public bool Erase=false;
        bool TimeControls = false;
        int TimeX, TimeY, EraserX, EraserY, ClearX, ClearY, TimerCX, TimerCY;
        public float UpdateTime = 0.0f;

        public Options(int NumX, int NumY, bool[,] Switch, float UpdateTime)
        {
            this.NumX = NumX;
            this.NumY = NumY;
            this.SwitchArray = Switch;
            this.UpdateTime = UpdateTime;
            TimeX = Width - 245;
            TimeY = Height - 235;
            ClearX = Width - 128;
            ClearY = 47;
            EraserX = Width - 128;
            EraserY = 134;
            TimerCX = Width - 128;
            TimerCY = 75;
        }

        public override void LoadContent()
        {
            PlayPause = new PlayButton(Width - 115, Height - 115);
            TimeSkip = new TimeButton(TimeX, TimeY, Paused, Skip, TimeControls, Pressed);
            Clear = new ClearButton(ClearX, ClearY, NumX, NumY, SwitchArray);
            Eraser = new EraseButton(EraserX, EraserY, Erase);
            TimerChange = new TimeConfig(TimerCX, TimerCY, UpdateTime);


            PlayPause.LoadContent();
            TimeSkip.LoadContent();
            Clear.LoadContent();
            Eraser.LoadContent();
            TimerChange.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mousepos = Mouse.GetState();

            PlayPause.Update(gameTime);

            if (!TimeControls)
            {
                Clear.Update(gameTime);
                Eraser.Update(gameTime);
            }
            else if (TimeControls)
            {
                TimerChange.Update(gameTime);
            }



            if ((PlayPause.Altered) || (TimeSkip.Altered) || (Eraser.Altered) || (Clear.Altered))
            {
                
                Paused = PlayPause.Paused;
                
                if (PlayPause.Altered)
                    TimeSkip.TimeControls = false;
                TimeControls = TimeSkip.TimeControls;
                PlayPause.LoadContent();
                TimeSkip = new TimeButton(TimeX, TimeY, Paused, Skip, TimeControls, Pressed);
                TimeSkip.LoadContent();
                if (Eraser.Altered)
                {
                    Erase = Eraser.Erase;
                    OptionsOn = false;
                    WaitSwitch = true;
                }
                Eraser = new EraseButton(EraserX, EraserY, Erase);
                Eraser.LoadContent();
                Clear.Altered = false;
                Eraser.Altered = false;
                Altered = true;
            }
            TimeSkip.Update(gameTime);
            Skip = TimeSkip.Skip;
            Pressed = TimeSkip.Pressed;
            UpdateTime = TimerChange.UpdateTime;
            
            if ((mousepos.LeftButton == ButtonState.Pressed) &&
                ((mousepos.X > 0) && (mousepos.X < ((Width/2)+80)) &&
                (mousepos.Y > 0) && (mousepos.Y < Height)))
            {
                OptionsOn = false;
                WaitSwitch = true;
            }
        }


        public override void Draw(GameTime gameTime)
        {
            PlayPause.Draw(gameTime);
            TimeSkip.Draw(gameTime);
            if (!TimeControls)
            {
                Clear.Draw(gameTime);
                Eraser.Draw(gameTime);
            }
            else if (TimeControls)
            {
                TimerChange.Draw(gameTime);
            }

        }
    }
}
