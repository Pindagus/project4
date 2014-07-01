using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace project4
{
    class Bob : Interactor
    {
        public String ConsoleName = "Bob";

        public bool MovingAllowed = true;

        public ActionList actionList;
        
        //private Texture2D debug;

        //constructor
        public Bob(Game game, int X, int Y)
            : base (game)
        {

            TileX = X;
            TileY = Y;

            //creates action list for bob, second parameter is name of class this will make clear which list to create
            actionList = new ActionList(game, this.GetType().Name);

            layerDepth = ComputeDepth;
            scale = 1.5f;

            widthOffset = 17;
            heightOffset = 20;

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

            texture = Game.Content.Load<Texture2D>(@"img\GameObjects\bob");

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

        public Rectangle hoverBox
        {
            get
            {
                return new Rectangle(
                        (int)ComputePos.X,
                        (int)ComputePos.Y + BaseTile.TileHeight - texture.Height - 50,
                        (int)BaseTile.TileWidth,
                        (int)texture.Height + 15
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
