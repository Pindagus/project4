using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class TitleScreen : Screen
    {
        public ScreenElement Background;
        public ScreenElement StartButton;
        public ScreenElement ExitButton;

        public TitleScreen(Game game) { 

        //creates background    
            Background = new ScreenElement(game, @"img\ScreenElements\background.jpg", new Vector2(0, 0), 0);

        //creates Startbutton
            StartButton = new ScreenElement(game, @"img\ScreenElements\start", new Vector2(450, 280), 0.2f);

        //creates ExitButton
            ExitButton = new ScreenElement(game, @"img\ScreenElements\stop", new Vector2(450, 380), 0.2f);

        }
    }
}
