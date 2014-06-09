using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Computer : Interactor
    {

        public override Rectangle boundingBox
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

        //constructor
        public Computer(Game game, int X, int Y)
            : base (game)
        {
            scale = 1.2f;
            widthOffset = 28;
            heightOffset = 18;
            layerDepth = 0.3f;

            TileX = X;
            TileY = Y;

            base.Initialize();

            Origin = new Vector2(
                    widthOffset,
                    texture.Height - BaseTile.TileHeight + heightOffset
                    );
        }

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(@"img\GameObjects\computer");

            base.LoadContent();
        }
    }
}
