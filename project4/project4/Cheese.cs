using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Cheese : Interactor
    {
        public Texture2D _frontTexture;
        public Texture2D _backTexture;
        public Texture2D _leftTexture;
        public Texture2D _rightTexture;

        public bool MovingAllowed = true;


        
        //private Texture2D debug;

        //constructor
        public Cheese(Game game, int X, int Y)
            : base (game)
        {
            TileX = X;
            TileY = Y;

            layerDepth = ComputeDepth;
            scale = 0.8f;

            widthOffset = 7;

            base.Initialize();

            //after base initialize so the texture is available in the constructor
            texture = _frontTexture;
            Origin = new Vector2(
                    widthOffset,
                    texture.Height - BaseTile.TileHeight
                    );
        }

        protected override void LoadContent()
        {
            //debug boundingbox
            //debug = new Texture2D(GraphicsDevice, 1, 1);
            //debug.SetData(new Color[] { Color.White });

            _frontTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\front_view");
            _backTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\back_view");
            _leftTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\left_view");
            _rightTexture = Game.Content.Load<Texture2D>(@"img\GameObjects\Cheese\right_view");

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime){
            
            //draw debug boundingbox
            //Game1.spriteBatch.Draw(
            //    debug,
            //    hoverBox,
            //    Color.White
            //    );

            base.Draw(gameTime);
        }

        public void Move(int X, int Y){

            if (MovingAllowed) { 
                TileX += X;
                TileY += Y;
            }

            //calculate depth of cheese, so that cheese wil be obscurred by computer for example
            layerDepth = ComputeDepth;
        }

        public Rectangle hoverBox
        {
            get
            {
                return new Rectangle(
                        (int)ComputePos.X,
                        (int)ComputePos.Y + BaseTile.TileHeight - texture.Height + 20,
                        (int)BaseTile.TileWidth,
                        (int)texture.Height - 60
                    );
            }    
        }

        public override bool IsHovering
        {
            get
            {
                return (hoverBox.Contains(Game1.mousePos.X, Game1.mousePos.Y));
            }
        }

    }
}
