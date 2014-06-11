#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace project4
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public Level _currentLevel;
        public Player _player;

        public static MouseState _previousMouseState;
        public static MouseState _currentMouseState;
        public static Vector2 mousePos;
        public static KeyboardState _previousKeyboardState;
        public static KeyboardState _currentKeyboardState;

        private TitleScreen _titleScreen;

        private bool DEBUG  = false;
        public static float elapsedTimeSec;

        //audio
        SoundEffectInstance instance;
        SoundEffect tileScreenTune;

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
            graphics.IsFullScreen = false;
            //

            _player = new Player(this);

            //this will set the level immidiately instead of titlescreen, for debug purpose only
            if (DEBUG) { 
                //_cheese = new Cheese(this, 7, 3);

                //creates level, the integer determines which level will be loaded
                _currentLevel = new Level(this, _player, 1);
            }else{
                //set titleScreen
                _titleScreen = new TitleScreen(this);                
            }

            base.Initialize();

            if(!DEBUG){
                // titlescreen tune in loop
                instance = tileScreenTune.CreateInstance();
                instance.IsLooped = true;
                instance.Volume = 0.5f;
                instance.Play();
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tileScreenTune = Content.Load<SoundEffect>(@"audio\tune\titleScreenTune");
        }
       
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            elapsedTimeSec += (float)gameTime.ElapsedGameTime.TotalSeconds;

            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            //udpates mouse position, will be used for click handling
            mousePos = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            _player.mousePos = mousePos;

            if(!DEBUG){
                //check if button is clicked on start screen

                //check this only if level isn't visible
                if (_currentLevel == null){ 
                    if (_titleScreen.StartButton.IsClicked){
                        //_cheese = new Cheese(this, 7, 4);

                        //creates level, the integer determines which level will be loaded
                        _currentLevel = new Level(this, _player, 1);

                        //removes start screen's componentes
                        this.Components.Remove(_titleScreen.StartButton);
                        this.Components.Remove(_titleScreen.ExitButton);
                        this.Components.Remove(_titleScreen.Background);
                    }

                    //exit button
                    if (_titleScreen.ExitButton.IsClicked){
                        Exit();
                    }
                }
            }

            //check if level is completed and set next level
            if(_currentLevel != null){
                if (_currentLevel.diamondIsTaken)
                {
                    _currentLevel.Dispose();
                    _currentLevel.ClearLists();

                    switch (_currentLevel._currentLevelInt)
                    {
                        case 1:
                            _currentLevel = new Level(this, _player, 2);
                            break;
                        case 2:
                            _currentLevel = new Level(this, _player, 3);
                            break;
                        default:
                            Console.WriteLine("Level integer has unexpected value");
                            break;
                    }   
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            base.Draw(gameTime);
            spriteBatch.End(); 
        }

    }
}
