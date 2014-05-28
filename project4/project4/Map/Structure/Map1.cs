using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Map1 : TileMap
    {
        public Map1(Game game)
            : base(game)
        {
            //this will set the default tile, check variable defaultTile in the TileMap class to check which Tiles are available
            defaultTile = defaultTiles.Stone;

            createDefaultMap();
            createMapStructure();
        }

        public void createMapStructure()
        {
            //------------------------ CREATE tiles, Rows is for y and Columns for x coordinates--------------------------------
            Rows[4].Columns[0] = new Brown();
            Rows[3].Columns[2] = new Concrete();
            Rows[1].Columns[2] = new Grass();
            Rows[2].Columns[4] = new Wood();
            Rows[5].Columns[3] = new Concrete();
            Rows[1].Columns[3] = new Water();



            //-------------------------------------------------------------------------------------------------------------------
        }

    }
}
