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
        public Texture2D _mouseCursorTexture;
        public Texture2D _mousePointerTexture;
        public Texture2D _currentMouseTexture;
        public int _mousePointerXOffset;

        public Vector2 mousePos;
        public Cheese _cheese;

        private Vector2 _origin
        {
            get
            {
                return new Vector2(0 + _mousePointerXOffset, 0);
            }
        }            

        public Player(Game game)
            : base (game)
        {
            game.Components.Add(this);

            base.Initialize();

            //after base initialize so the texture is available in constructor
            _currentMouseTexture = _mouseCursorTexture;

            _mousePointerXOffset = 0;
        }

        protected override void LoadContent()
        {
            //loads mouse cursor texture
            _mouseCursorTexture = Game.Content.Load<Texture2D>(@"img\mouse");
            _mousePointerTexture = Game.Content.Load<Texture2D>(@"img\pointer");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //draws mouse cursor texture on screen with current mouse position
            Game1.spriteBatch.Draw(
                _currentMouseTexture,
                mousePos,
                null,
                Color.White,
                0f,
                _origin,
                0.3f,
                SpriteEffects.None,
                1f
                );

            base.Draw(gameTime);
        }
                              
    }
}
