using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class GameObject : DrawableGameComponent
    {
        public Texture2D texture;
        public int TileX;
        public int TileY;

        public int widthOffset;
        public int heightOffset;

        public double layerDepth;
        public float scale;

        //some classes will override this method to suit there needs
        public virtual Rectangle boundingBox
        {
            get
            {
                return new Rectangle(
                        (int)ComputePos.X,
                        (int)ComputePos.Y,
                        (int)BaseTile.TileWidth,
                        (int)BaseTile.TileHeight
                    );
            }
        }

        //get origin
        public Vector2 Origin;

        //computes vector2 position of tile X and Y in pixels
        public Vector2 ComputePos
        {
            get
            {
                return new Vector2(TileX * BaseTile.TileWidth, TileY * BaseTile.TileHeight);
            }
        }

        //computes depth of object
        public double ComputeDepth
        {
            get
            {
                //TODO compute depth
                return (double)TileY/500 + 0.100;
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
                    Origin,
                    scale,
                    SpriteEffects.None,
                    (float)layerDepth
                );

            base.Draw(gameTime);
        }


    }
}
