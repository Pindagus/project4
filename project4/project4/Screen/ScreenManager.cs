using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public enum Gamestate
    {
        Menu,
        Play
    }

    class ScreenManager : DrawableGameComponent
    {
        public static Gamestate gamestate = Gamestate.Menu;
        public static Keyboard keyboard;
        public static SpriteFont spritefont;
        MenuScreen screen_Menu;
        GameScreen screen_Game;
        SpriteBatch spriteBatch;
        public ScreenManager(Game game)
            : base (game)
        {
            screen_Game = new GameScreen();
            screen_Menu = new MenuScreen();
            keyboard = new Keyboard();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevise);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //update screens and keyboard
            
            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            // draw screens
            base.Draw(gameTime);
        }
    }
}
