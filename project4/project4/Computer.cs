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

        public Computer(Game game, int X, int Y)
            : base (game)
        {
            scale = 1.2f;
            widthOffset = 28;
            heightOffset = 18;
            layerDepth = 0.3f;

            TileX = X;
            TileY = Y;
        }

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(@"img\GameObjects\computer1.png");

            base.LoadContent();
        }
    }
}
