﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Cheese : DrawableGameComponent
    {
        public Texture2D _texture;
        public int _TileX;
        public int _TileY;
        private float _layerDepth;
        private Vector2 _origin;
        private int widthOffset = 7;

        public Texture2D _frontTexture;
        public Texture2D _backTexture;
        public Texture2D _leftTexture;
        public Texture2D _rightTexture;
        private float _scale;
        private Texture2D debug;

        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle(
                        (int)ComputePos.X,
                        (int)ComputePos.Y,
                        (int)BaseTile.TileWidth,
                        (int)BaseTile.TileHeight
                    );
            }
        }

        //get origin
        public Vector2 Origin
        {
            get
            {
                return new Vector2(
                    widthOffset,
                    _texture.Height - BaseTile.TileHeight
                    );
            }
        }

        //computes vector2 position of tile X and Y in pixels
        public Vector2 ComputePos
        {
            get
            {
                return new Vector2(_TileX * BaseTile.TileWidth, _TileY * BaseTile.TileHeight);
            }
        }

        //constructor
        public Cheese(Game game, int TileX, int TileY)
            : base (game)
        {
            game.Components.Add(this);

            _TileX = TileX;
            _TileY = TileY;
            _layerDepth = 0.4f;
            _scale = 0.8f;

            base.Initialize();

            //after base initialize so the texture is available in the constructor
            _texture = _frontTexture;
            _origin = Origin;
        }

        protected override void LoadContent()
        {
            //debug boundingbox
            debug = new Texture2D(GraphicsDevice, 1, 1);
            debug.SetData(new Color[] { Color.White });

            _frontTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\front_view");
            _backTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\back_view");
            _leftTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\left_view");
            _rightTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\right_view");

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime){

            Game1.spriteBatch.Draw(
                debug,
                boundingBox,
                Color.White
                );

            Game1.spriteBatch.Draw(
                    _texture,
                    ComputePos,
                    null,
                    Color.White,
                    0,
                    _origin,
                    _scale,
                    SpriteEffects.None,
                    _layerDepth
                );

            base.Draw(gameTime);
        }

        public void Move(int X, int Y){
            _TileX += X;
            _TileY += Y;
        }        

    }
}
