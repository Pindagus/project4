using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Diamond : GameObject
    {
        //private Texture2D debug;

        public Diamond(Game game, int X, int Y)
            : base(game)
        {
            TileX = X;
            TileY = Y;

            layerDepth = ComputeDepth -0.01;

            scale = 1;

            base.Initialize();

            Origin = new Vector2(
                    widthOffset,
                    texture.Height - BaseTile.TileHeight
                    );
        }

        protected override void LoadContent()
        {
            //debug boundingbox
            //debug = new Texture2D(GraphicsDevice, 1, 1);
            //debug.SetData(new Color[] { Color.White });

            texture = Game.Content.Load<Texture2D>(@"img\GameObjects\diamond");

            base.LoadContent();
        }

        //delete after debugging
        public override void Draw(GameTime gameTime)
        {
            //debug draw boundingbox
            //Game1.spriteBatch.Draw(
            //    debug,
            //    boundingBox,
            //    Color.Green
            //    );

            base.Draw(gameTime);
        }


    }
}
