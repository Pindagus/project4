using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class BaseTile
    {
        private int TileWidth = 101;
        private int TileHeight = 84;

        public int TileInt;

        public int getTileWidth
        {
            get
            {
                return TileWidth;
            }
        }

        public int getTileHeight
        {
            get
            {
                return TileHeight;
            }
        }

        public Rectangle GetSourceRectangle(int TileInt)
        {
            int tileY = TileInt / (TileMap._tileSetTexture.Width / TileWidth);
            int tileX = TileInt % (TileMap._tileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }

        //constructor
        public BaseTile(int _TileInt)
        {
            TileInt = _TileInt;
        }
    }
}
