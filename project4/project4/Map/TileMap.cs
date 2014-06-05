using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class MapRow
    {
        public List<BaseTile> Columns = new List<BaseTile>();
    }

    class TileMap : DrawableGameComponent
    {
        public static Texture2D _tileSetTexture;

        public List<MapRow> Rows = new List<MapRow>();

        //the actual size of the entire map
        protected int MapWidth = 30;
        protected int MapHeight = 30;

        //part that will be visible of the map
        protected int squaresAcross = 15;
        protected int squaresDown = 15;

        //offset of whole map
        protected int baseOffsetX = 0;
        protected int baseOffsetY = 0;

        //default tile
        protected defaultTiles defaultTile;

        public enum defaultTiles
        {
            Brown,
            Concrete,
            Dirt,
            Grass,
            Water,
            Wood,
            Stone
        }

        //constructor
        public TileMap(Game game)
            : base(game)
        {
            Game.Components.Add(this);
        }

        //creates map
        protected void createDefaultMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {

                    //firstly this wil create a map which will contain only the default tiles
                    BaseTile currentTile;

                    switch (defaultTile)
                    {
                        case defaultTiles.Brown:
                            currentTile = new Brown();
                            break;
                        case defaultTiles.Concrete:
                            currentTile = new Concrete();
                            break;
                        case defaultTiles.Dirt:
                            currentTile = new Dirt();
                            break;
                        case defaultTiles.Grass:
                            currentTile = new Grass();
                            break;
                        case defaultTiles.Water:
                            currentTile = new Water();
                            break;
                        case defaultTiles.Wood:
                            currentTile = new Wood();
                            break;
                        case defaultTiles.Stone:
                            currentTile = new Stone();
                            break;
                        default:
                            currentTile = new Water();
                            break;
                    }
                    thisRow.Columns.Add(currentTile);
                }
                Rows.Add(thisRow);
            }
        }

        protected override void LoadContent()
        {
            _tileSetTexture = Game.Content.Load<Texture2D>(@"Textures\TileSet\TileSet");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    BaseTile currentTile = Rows[y].Columns[x];

                    Game1.spriteBatch.Draw(
                    _tileSetTexture,
                        new Rectangle((x * currentTile.getTileWidth) - baseOffsetX, (y * currentTile.getTileHeight) + baseOffsetY, currentTile.getTileWidth, currentTile.getTileHeight),
                        currentTile.GetSourceRectangle(currentTile.getTileInt),
                    Color.White);
                }
            }

            base.Draw(gameTime);
        }  
    }
}
