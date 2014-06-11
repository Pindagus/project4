using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class ConsoleInterface : DrawableGameComponent
    {
        public String currentObject = "";
        public String currentMethod = "";
        public String insertionPoint = "";

        public ScreenElement console;
        public ScreenElement RunButton;
        public float posX;

        //console will also be loaded, only visibile when one of the computers is clicked
        public float posOutsideScreenX = 1500;
        public float visiblePosX = 890;
        private SpriteFont _spriteFont;

        public ConsoleInterface(Game game)
            : base(game)
        {
            game.Components.Add(this);

            //set start position outside screen
            posX = posOutsideScreenX;

            //creates background    
            console = new ScreenElement(game, @"img\GameObjects\Console\console", new Vector2(posX, 30), 0.8f);

            //creates Startbutton
            RunButton = new ScreenElement(game, @"img\GameObjects\Console\runbutton", new Vector2(posX, 330), 0.5f);
        }

        protected override void LoadContent()
        {
            _spriteFont = Game.Content.Load<SpriteFont>(@"Fonts\Verdana");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (currentObject != String.Empty)
            {
                insertionPoint = " . ";         
            }else{
                insertionPoint = "";
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.DrawString(
                _spriteFont,
                currentObject + insertionPoint + currentMethod,
                new Vector2(console._position.X + 100, console._position.Y + 100),
                Color.White,
                0f,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                1
                );

            base.Draw(gameTime);
        }

    }
}
