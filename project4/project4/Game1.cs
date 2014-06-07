#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace project4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        private Level _currentLevel;
        public Player _player;

        public static MouseState _previousMouseState;
        public static MouseState _currentMouseState;
        public static Vector2 mousePos;
        private TitleScreen _titleScreen;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //set screen
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics.IsFullScreen = true;
            //

            _player = new Player(this);

            //set titleScreen
            _titleScreen = new TitleScreen(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);   
        }
       
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //udpates mouse position
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            mousePos = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            _player.mousePos = mousePos;

            //check if button is clicked on start screen
            if (_titleScreen.StartButton.IsClicked){
                //creates level, the integer determines which level will be loaded
                _currentLevel = new Level(this, 1);

                //removes start screen
                this.Components.Remove(_titleScreen.StartButton);
                this.Components.Remove(_titleScreen.ExitButton);
                this.Components.Remove(_titleScreen.Background);
            }

            //exit button
            if (_titleScreen.ExitButton.IsClicked){
                Exit();
            }

            //TODO check if level is completed and set next level, probably with boolean
            // new level(this,2)

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
