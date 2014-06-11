using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Interactor : GameObject
    {
        public bool isSelected = false;
        public float selectionTransparency;
        public float blingTransparency = 0.8f;

        public virtual bool IsHovering
        {
            get
            {
                return (boundingBox.Contains(Game1.mousePos.X, Game1.mousePos.Y));
            }
        }

        public bool IsClicked
        {
            get
            {
                return (IsHovering && Game1._previousMouseState.LeftButton == ButtonState.Released && Game1._currentMouseState.LeftButton == ButtonState.Pressed);
            }
        }

        //constructor
        public Interactor(Game game)
            : base (game)
        {


        }

        public override void Update(GameTime gameTime)
        {
            if (isSelected)
            {
                if (Game1.elapsedTimeSec >= 2)
                {
                    Game1.elapsedTimeSec = 0;
                }

                if (Game1.elapsedTimeSec > 1)
                {
                    selectionTransparency = blingTransparency;
                }
                else
                {
                    selectionTransparency = 1;
                }
            }

            base.Update(gameTime);
        }

    }
}
