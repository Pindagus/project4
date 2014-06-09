using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class GameObject : DrawableGameComponent
    {
        public Texture2D texture;
        public int TileX;
        public int TileY;

        public int widthOffset;
        public int heightOffset;

        public float layerDepth;
        public float scale;

        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle(
                        (int)ComputePos.X,
                        (int)ComputePos.Y - texture.Height + BaseTile.TileHeight,
                        (int)texture.Width,
                        (int)texture.Height
                    );
            }
        }

        //get origin
        public Vector2 Origin
        {
            get
            {
                return new Vector2(
                    widthOffset,
                    texture.Height - BaseTile.TileHeight + heightOffset
                    );
            }
        }

        //computes vector2 position of tile X and Y in pixels
        public Vector2 ComputePos
        {
            get
            {
                return new Vector2(TileX * BaseTile.TileWidth, TileY * BaseTile.TileHeight);
            }
        }

        public GameObject(Game game)
            : base (game)
        {
            game.Components.Add(this);

        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(
                    texture,
                    ComputePos,
                    null,
                    Color.White,
                    0,
                    Origin, //TODO origin zero for now, change this later on
                    scale,
                    SpriteEffects.None,
                    layerDepth
                );

            base.Draw(gameTime);
        }


    }
}
