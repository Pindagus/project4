using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class LevelMap1 : TileMap
    {
        public LevelMap1(Game game)
            : base(game)
        {
            //this will set the default tile, check variable defaultTile in the TileMap class to check which Tiles are available
            defaultTile = new Grass();

            createDefaultMap();
            createMapStructure();
        }

        public void createMapStructure()
        {
            //------------------------ CREATE tiles, Rows is for y and Columns for x coordinates--------------------------------
            //bomen boven
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
            Rows[0].Columns[12] = new Brown();
            Rows[0].Columns[13] = new Brown();

            Rows[1].Columns[1] = new Brown();
            Rows[1].Columns[2] = new Brown();
            Rows[1].Columns[3] = new Brown();
            Rows[1].Columns[4] = new Brown();
            Rows[1].Columns[5] = new Brown();
            Rows[1].Columns[6] = new Brown();
            Rows[1].Columns[7] = new Brown();
            Rows[1].Columns[8] = new Brown();
            Rows[1].Columns[9] = new Brown();
            Rows[1].Columns[10] = new Brown();
            Rows[1].Columns[11] = new Brown();
            Rows[1].Columns[12] = new Brown();
            Rows[1].Columns[13] = new Brown();

            Rows[2].Columns[10] = new Brown();
            Rows[2].Columns[11] = new Brown();
            Rows[2].Columns[12] = new Brown();
            Rows[2].Columns[13] = new Brown();
            Rows[3].Columns[10] = new Brown();
            Rows[3].Columns[11] = new Brown();
            Rows[3].Columns[12] = new Brown();
            Rows[3].Columns[13] = new Brown();
            Rows[4].Columns[11] = new Brown();
            Rows[4].Columns[12] = new Brown();
            Rows[4].Columns[13] = new Brown();
            Rows[5].Columns[11] = new Brown();
            Rows[5].Columns[12] = new Brown();
            Rows[5].Columns[13] = new Brown();
            Rows[6].Columns[11] = new Brown();
            Rows[6].Columns[12] = new Brown();
            Rows[6].Columns[13] = new Brown();
            Rows[7].Columns[11] = new Brown();
            Rows[7].Columns[12] = new Brown();
            Rows[7].Columns[13] = new Brown();
            Rows[8].Columns[11] = new Brown();
            Rows[8].Columns[12] = new Brown();
            Rows[8].Columns[13] = new Brown();
            Rows[9].Columns[11] = new Brown();
            Rows[9].Columns[12] = new Brown();
            Rows[9].Columns[13] = new Brown();
            //bomen links
            Rows[1].Columns[0] = new Brown();
            Rows[2].Columns[0] = new Brown();
            Rows[3].Columns[0] = new Brown();
            Rows[4].Columns[0] = new Brown();
            Rows[5].Columns[0] = new Brown();
            Rows[6].Columns[0] = new Brown();

            //water linksonder
            Rows[7].Columns[0] = new Water();
            Rows[7].Columns[1] = new Water();
            Rows[7].Columns[2] = new Water();
            Rows[7].Columns[3] = new Water();
            Rows[7].Columns[4] = new Water();
            Rows[8].Columns[0] = new Water();
            Rows[8].Columns[1] = new Water();
            Rows[8].Columns[2] = new Water();
            Rows[8].Columns[3] = new Water();
            Rows[8].Columns[4] = new Water();
            Rows[9].Columns[0] = new Water();
            Rows[9].Columns[1] = new Water();
            Rows[9].Columns[2] = new Water();
            Rows[9].Columns[3] = new Water();
            Rows[9].Columns[4] = new Water();

            //bomen onder
            Rows[8].Columns[5] = new Brown();
            Rows[8].Columns[6] = new Brown();
            Rows[8].Columns[8] = new Brown();
            Rows[8].Columns[9] = new Brown();
            Rows[8].Columns[10] = new Brown();
            Rows[9].Columns[5] = new Brown();
            Rows[9].Columns[6] = new Brown();
            Rows[9].Columns[7] = new Brown();
            Rows[9].Columns[8] = new Brown();
            Rows[9].Columns[9] = new Brown();
            Rows[9].Columns[10] = new Brown();


            //pad
            Rows[4].Columns[4] = new Stone();
            Rows[4].Columns[5] = new Stone();
            Rows[4].Columns[6] = new Stone();
            Rows[4].Columns[7] = new Stone();
            Rows[5].Columns[7] = new Stone();
            Rows[6].Columns[7] = new Stone();
            Rows[7].Columns[7] = new Stone();
            Rows[8].Columns[7] = new Stone();
            //-------------------------------------------------------------------------------------------------------------------
        }

    }
}