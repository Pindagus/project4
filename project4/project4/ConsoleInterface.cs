using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class ConsoleInterface : GameComponent
    {
        public String currentObject = "";
        public String currentMethod = "";

        public ScreenElement console;
        public ScreenElement RunButton;
        public float posX;

        //console will also be loaded, only visibile when one of the computers is clicked
        public float posOutsideScreenX = 1500;
        public float visiblePosX = 890;

        public ConsoleInterface(Game game)
            : base(game)
        {
            game.Components.Add(this);

            //set start position outside screen
            posX = posOutsideScreenX;

            //creates background    
            console = new ScreenElement(game, @"img\GameObjects\Console\console.png", new Vector2(posX, 30), 0.8f);

            //creates Startbutton
            RunButton = new ScreenElement(game, @"img\GameObjects\Console\runbutton.png", new Vector2(posX, 330), 0.5f);
        }

    }
}
