using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class BaseLevel : DrawableGameComponent
    {

        public BaseLevel(Game game)
            : base(game)
        {
            game.Components.Add(this);  
        }

        public override void Update(GameTime gameTime)
        {
            //general level update
            base.Update(gameTime);
        }
    }
}
