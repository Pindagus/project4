using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Rat : Interactor
    {
        public String ConsoleName = "Rat";

        public bool MovingAllowed;
        public int direction = 1;
        private int prevTime;
        private int currentTime;
        
        //private Texture2D debug;

        //constructor
        public Rat(Game game, int X, int Y,bool movingAllowed = false)
            : base (game)
        {
            MovingAllowed = movingAllowed;

            TileX = X;
            TileY = Y;

            layerDepth = ComputeDepth;
            scale = 0.4f;

            widthOffset = 65;
            heightOffset = -120;

            base.Initialize();

            //after base initialize so the texture is available in the constructor
            Origin = new Vector2(
                    widthOffset,
                    texture.Height - BaseTile.TileHeight + heightOffset
                    );
        }

        protected override void LoadContent()
        {
            //debug boundingbox
            //debug = new Texture2D(GraphicsDevice, 1, 1);
            //debug.SetData(new Color[] { Color.White });

            texture = Game.Content.Load<Texture2D>(@"img\GameObjects\rat");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            prevTime = currentTime;
            currentTime = (int)Math.Floor(Game1.overallTime % 2);

            if (currentTime != prevTime)
            {
                Move(direction, 0);                       
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime){
            
            //draw debug boundingbox
            //Game1.spriteBatch.Draw(
            //    debug,
            //    boundingBox,
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
