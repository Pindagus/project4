using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Player : DrawableGameComponent
    {
        private Texture2D _mouseCursorTexture;
        public Vector2 mousePos;

        public Player(Game game)
            : base (game)
        {
            game.Components.Add(this);
        }

        protected override void LoadContent()
        {
            //loads mouse cursor texture
            _mouseCursorTexture = Game.Content.Load<Texture2D>(@"img\mouse");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //draws mouse with current mouse position
            Game1.spriteBatch.Draw(
                _mouseCursorTexture,
                mousePos,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                0.3f,
                SpriteEffects.None,
                0.5f
                );

            base.Draw(gameTime);
        }
                              
    }
}
