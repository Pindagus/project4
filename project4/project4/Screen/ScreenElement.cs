using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class ScreenElement : DrawableGameComponent
    {
        private string _file;
        public Vector2 _position;
        private Texture2D _texture;
        private float _layerDepth;

        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle(
                        (int) _position.X,
                        (int) _position.Y,
                        (int) _texture.Width,
                        (int) _texture.Height
                    );
            }                        
        }

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

        public ScreenElement(Game game, String file, Vector2 position, float layerDepth)
            : base(game)
        {
            _file = file;
            _position = position;
            _layerDepth = layerDepth;

            game.Components.Add(this);

            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            _texture = Game.Content.Load<Texture2D>(_file);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(
                    _texture,
                    _position,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    1,
                    SpriteEffects.None,
                    _layerDepth
                );

            base.Draw(gameTime);
        }

    }
}
