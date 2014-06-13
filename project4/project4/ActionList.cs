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
        public ScreenElement TalkButton;
        public ScreenElement BridgeButton;

        public float posX;

        //list will be loaded on creating, only visibile when one of the interactors is clicked
        public static float posOutsideScreenX = 1500;
        public float visiblePosX = 890;

        private Vector2 listPosition;

        public ActionList(Game game, String interactor)
            : base(game)
        {
            game.Components.Add(this);

            listPosition = new Vector2(posOutsideScreenX, 0);

            //set start position outside screen
            posX = posOutsideScreenX;

            //creates background of action list
            background = new ScreenElement(game, @"img\GameObjects\ActionList\background", listPosition, 0.8f);

            // create list of specific interactor
            if(interactor == "Cheese"){
                //creates JumpButton
                JumpButton = new ScreenElement(game, @"img\GameObjects\ActionList\jumpButton", new Vector2(posOutsideScreenX, listPosition.Y), 0.9f);
                BridgeButton = new ScreenElement(game, @"img\GameObjects\ActionList\bridgeButton", new Vector2(posOutsideScreenX, listPosition.Y), 0.9f);
            }

            if(interactor == "Bob"){
                //creates TalkButton
                TalkButton = new ScreenElement(game, @"img\GameObjects\ActionList\talkButton.png", new Vector2(posOutsideScreenX, listPosition.Y), 0.9f);
            }
        }

    }
}
