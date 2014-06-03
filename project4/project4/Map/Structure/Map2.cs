using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Map2 : TileMap
    {
        public Map2(Game game)
            : base(game)
        {
            //this will set the default tile, check variable defaultTile in the TileMap class to check which Tiles are available
            defaultTile = defaultTiles.Grass;

            createDefaultMap();
            createMapStructure();
        }

        public void createMapStructure()
        {
            //------------------------ CREATE tiles, Rows is for y and Columns for x coordinates--------------------------------
            //bomen boven
            Rows[0].Columns[0] = new Brown();

            Rows[0].Columns[4] = new Brown();
            Rows[0].Columns[5] = new Brown();
            Rows[0].Columns[6] = new Brown();
            Rows[0].Columns[7] = new Brown();
            Rows[0].Columns[8] = new Brown();
            Rows[0].Columns[9] = new Brown();
            Rows[0].Columns[10] = new Brown();
            Rows[0].Columns[11] = new Brown();

            //rivier
            Rows[0].Columns[1] = new Water();
            Rows[0].Columns[2] = new Water();
            Rows[0].Columns[3] = new Water();
            Rows[1].Columns[1] = new Water();
            Rows[1].Columns[2] = new Water();
            Rows[1].Columns[3] = new Water();
            Rows[2].Columns[1] = new Water();
            Rows[2].Columns[2] = new Water();
            Rows[2].Columns[3] = new Water();
            Rows[3].Columns[1] = new Water();
            Rows[3].Columns[2] = new Water();
            Rows[3].Columns[3] = new Water();
            Rows[4].Columns[1] = new Water();
            Rows[4].Columns[2] = new Water();
            Rows[4].Columns[3] = new Water();
            Rows[5].Columns[1] = new Water();
            Rows[5].Columns[2] = new Water();
            Rows[5].Columns[3] = new Water();
            Rows[5].Columns[4] = new Water();
            Rows[5].Columns[6] = new Water();
            Rows[5].Columns[7] = new Water();
            Rows[5].Columns[8] = new Water();
            Rows[5].Columns[9] = new Water();
            Rows[6].Columns[10] = new Water();
            Rows[6].Columns[11] = new Water();
            Rows[6].Columns[2] = new Water();
            Rows[6].Columns[3] = new Water();
            Rows[6].Columns[4] = new Water();
            Rows[6].Columns[5] = new Water();
            Rows[6].Columns[6] = new Water();
            Rows[6].Columns[7] = new Water();
            Rows[6].Columns[8] = new Water();
            Rows[6].Columns[9] = new Water();
            Rows[6].Columns[10] = new Water();
            Rows[6].Columns[11] = new Water();
            //water die in brug verandert
            Rows[5].Columns[5] = new Water();
            Rows[6].Columns[5] = new Water();
            //-------------------------------------------------------------------------------------------------------------------
        }

    }
}
