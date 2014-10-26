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
    public class Rules : Entity
    {
        // Struct used to keep record of nodes to change
        struct NodeChange
        {
            public int x, y; // cell to be altered location
            public bool kill; // if true kill cell
        }
        // List to keep record of all changes to be made in table
        List<NodeChange> TableChanges;

        NodeChange Change;

        public Rules(int NumX, int NumY, bool[,] SwitchArr)
        {
            this.NumX = NumX;
            this.NumY = NumY;
            this.SwitchArray = SwitchArr;
        }



        public override void LoadContent()
        {

            TableChanges = new List<NodeChange>();
            
            // Loops to check cell neighbours on table, 
            for (int j = 0; j < NumY; j++)
            {
                for (int i = 0; i < NumX; i++)
                {
                    // Counts up number of neighbours a cell has, which then determines which rule will be set
                    int Counter = 0;

                    // cell on Left?
                    if (i != 0) // Used so bounds of 2d array not overwritten
                        if (SwitchArray[i - 1, j])
                            Counter++;

                    // cell on right?
                    if (i != NumX - 1)
                        if (SwitchArray[i + 1, j])
                            Counter++;

                    // cell on top?
                    if (j != 0)
                        if (SwitchArray[i, j - 1])
                            Counter++;

                    // cell on bottom?
                    if (j != NumY - 1)
                        if (SwitchArray[i, j + 1])
                            Counter++;

                    // cell on Top Left?
                    if ((i != 0) && (j != 0))
                        if (SwitchArray[i - 1, j - 1])
                            Counter++;

                    // cell on Topright?
                    if ((i != NumX - 1) && (j != 0))
                        if (SwitchArray[i + 1, j - 1])
                            Counter++;

                    // cell on bottom left?
                    if ((i != 0) && (j != NumY - 1))
                        if (SwitchArray[i - 1, j + 1])
                            Counter++;

                    // cell on bottom right?
                    if ((i != NumX - 1) && (j != NumY - 1))
                        if (SwitchArray[i + 1, j + 1])
                            Counter++;



                    if ((SwitchArray[i, j]) && (Counter < 2)) // Loniless rule
                        AddChange(i, j, true);
                    else if ((!SwitchArray[i, j]) && (Counter == 3)) // birth rule
                        AddChange(i, j, false);
                    else if ((SwitchArray[i, j]) && (Counter >= 4)) // overcrowding rule
                        AddChange(i, j, true);
                    else if ((SwitchArray[i, j]) && ((Counter == 2) || (Counter == 3))) // live on rule
                        AddChange(i, j, false);
                }
            }

            for (int i = 0; i < TableChanges.Count(); i++)
            {
                if (TableChanges[i].kill)
                {
                    SwitchArray[TableChanges[i].x, TableChanges[i].y] = false;
                    Altered = true;
                }
                else if (!TableChanges[i].kill)
                {
                    SwitchArray[TableChanges[i].x, TableChanges[i].y] = true;
                    Altered = true;
                }
            }


        }

        public override void Update(GameTime gameTime)
        {


        }


        public override void Draw(GameTime gameTime)
        {

        }

        // method which adds change to the table
        void AddChange(int X, int Y, bool Kill)
        {
            Change = new NodeChange();
            Change.x = X;
            Change.y = Y;
            Change.kill = Kill;
            TableChanges.Add(Change);
        }

    }
}
