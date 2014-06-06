using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class LastLevelMap : TileMap
    {
        public LastLevelMap(Game game)
            : base(game)
        {
            //this will set the default tile, check variable defaultTile in the TileMap class to check which Tiles are available
            defaultTile = new  Dirt();

            createDefaultMap();
            createMapStructure();
        }

        public void createMapStructure()
        {
            //------------------------ CREATE tiles, Rows is for y and Columns for x coordinates--------------------------------
            Rows[0].Columns[0] = new Brown();
            Rows[0].Columns[1] = new Brown();
            Rows[0].Columns[2] = new Brown();
            Rows[0].Columns[3] = new Brown();
            Rows[0].Columns[4] = new Brown();
            Rows[0].Columns[5] = new Brown();
            Rows[0].Columns[6] = new Brown();
            Rows[0].Columns[7] = new Brown();
            Rows[0].Columns[8] = new Brown();
            Rows[0].Columns[9] = new Brown();
            Rows[0].Columns[10] = new Brown();
            Rows[0].Columns[11] = new Brown();

            Rows[1].Columns[0] = new Brown();
            Rows[1].Columns[1] = new Brown();
            Rows[1].Columns[2] = new Brown();
            Rows[1].Columns[3] = new Brown();
            Rows[1].Columns[4] = new Brown();
            Rows[1].Columns[10] = new Brown();
            Rows[1].Columns[11] = new Brown();

            Rows[2].Columns[0] = new Brown();
            Rows[2].Columns[1] = new Brown();
            Rows[2].Columns[2] = new Brown();
            Rows[2].Columns[3] = new Brown();
            Rows[2].Columns[6] = new Stone();
            Rows[2].Columns[7] = new Stone();
            Rows[2].Columns[8] = new Stone();
            Rows[2].Columns[11] = new Brown();

            Rows[3].Columns[0] = new Brown();
            Rows[3].Columns[1] = new Brown();
            Rows[3].Columns[2] = new Brown();
            Rows[3].Columns[3] = new Brown();
            Rows[3].Columns[4] = new Brown();
            Rows[3].Columns[8] = new Stone();
            Rows[3].Columns[11] = new Brown();

            Rows[4].Columns[0] = new Brown();
            Rows[4].Columns[1] = new Brown();
            Rows[4].Columns[2] = new Brown();
            Rows[4].Columns[3] = new Brown();
            Rows[4].Columns[4] = new Brown();
            Rows[4].Columns[5] = new Brown();
            Rows[4].Columns[6] = new Brown();
            Rows[4].Columns[8] = new Stone();
            Rows[4].Columns[11] = new Brown();

            Rows[5].Columns[0] = new Brown();
            Rows[5].Columns[1] = new Brown();
            Rows[5].Columns[2] = new Brown();
            Rows[5].Columns[3] = new Brown();
            Rows[5].Columns[4] = new Brown();
            Rows[5].Columns[5] = new Brown();
            Rows[5].Columns[8] = new Stone();
            Rows[5].Columns[11] = new Brown();

            Rows[6].Columns[0] = new Brown();
            Rows[6].Columns[1] = new Brown();
            Rows[6].Columns[2] = new Brown();
            Rows[6].Columns[3] = new Brown();
            Rows[6].Columns[7] = new Stone();
            Rows[6].Columns[11] = new Brown();

            Rows[7].Columns[0] = new Brown();
            Rows[7].Columns[1] = new Stone();
            Rows[7].Columns[2] = new Stone();
            Rows[7].Columns[3] = new Stone();
            Rows[7].Columns[4] = new Stone();
            Rows[7].Columns[5] = new Stone();
            Rows[7].Columns[6] = new Stone();
            Rows[7].Columns[10] = new Brown();
            Rows[7].Columns[11] = new Brown();

            Rows[8].Columns[0] = new Brown();
            Rows[8].Columns[1] = new Brown();
            Rows[8].Columns[2] = new Brown();
            Rows[8].Columns[3] = new Brown();
            Rows[8].Columns[4] = new Brown();
            Rows[8].Columns[5] = new Brown();
            Rows[8].Columns[6] = new Brown();
            Rows[8].Columns[7] = new Brown();
            Rows[8].Columns[8] = new Brown();
            Rows[8].Columns[9] = new Brown();
            Rows[8].Columns[10] = new Brown();
            Rows[8].Columns[11] = new Brown();
            

            //-------------------------------------------------------------------------------------------------------------------
        }

    }
}
