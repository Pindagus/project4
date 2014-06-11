using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class ActionList : GameComponent
    {
        
        public ScreenElement background;
        public ScreenElement JumpButton;
        public float posX;

        //list will be loaded on creating, only visibile when one of the interactors is clicked
        public static float posOutsideScreenX = 1500;
        public float visiblePosX = 890;

        private Vector2 listPosition;

        public ActionList(Game game)
            : base(game)
        {
            game.Components.Add(this);

            listPosition = new Vector2(posOutsideScreenX, 0);

            //set start position outside screen
            posX = posOutsideScreenX;

            //creates background
            background = new ScreenElement(game, @"img\GameObjects\ActionList\background.png", listPosition, 0.8f);

            //creates Startbutton
            JumpButton = new ScreenElement(game, @"img\GameObjects\ActionList\jumpButton.png", new Vector2(posOutsideScreenX, listPosition.Y), 0.9f);
        }

    }
}
