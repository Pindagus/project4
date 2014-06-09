using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Interactor : GameObject
    {

        public bool IsHovering
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

    }
}
