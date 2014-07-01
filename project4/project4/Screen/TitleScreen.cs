using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            //Background = new ScreenElement(game, @"img\ScreenElements\background", new Vector2(0, 0), 0);
            Background = new ScreenElement(game, @"img\ScreenElements\whitepaper_and_logo", new Vector2(0, 0), 0);

        //creates Startbutton
            StartButton = new ScreenElement(game, @"img\ScreenElements\start", new Vector2(game.GraphicsDevice.Viewport.Width / 2 + 180, 280), 0.2f);

        //creates ExitButton
            ExitButton = new ScreenElement(game, @"img\ScreenElements\stop", new Vector2(game.GraphicsDevice.Viewport.Width / 2 + 180, 380), 0.2f);

        }
    }
}
