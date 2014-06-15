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
using Microsoft.Xna.Framework.Media;
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
        private bool DEBUG2 = false;

        public static float elapsedTimeSec;
        public static float overallTime;

        //audio
        SoundEffectInstance instance;
        SoundEffect Tune1;

        public static SoundEffectInstance begin_level1;
        public static SoundEffectInstance klik_karakter;
        public static SoundEffectInstance verkeerde_actie;
        public static SoundEffectInstance verkeerde_persoon;
        public static SoundEffectInstance wat_doen;
        public static SoundEffectInstance klik_op_pc_bob;
        public static SoundEffectInstance klik_op_bob;
        public static SoundEffectInstance actie_bob;
        public static SoundEffectInstance bob_succes;
        public static SoundEffectInstance help_diamanten;
        public static SoundEffectInstance begin_level2;
        public static SoundEffectInstance brug_klaar;
        public static SoundEffectInstance begin_level3;
        public static SoundEffectInstance rat_attack;
        public static SoundEffectInstance rat_defeated;
        public static SoundEffectInstance end_game;
        private bool endGameAlreadyPlayed;

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
                _currentLevel = new Level(this, _player, 1, 2, 6);
            }else{
                //set titleScreen
                _titleScreen = new TitleScreen(this);                
            }

            base.Initialize();

            if(!DEBUG){
                // titlescreen tune in loop
                instance = Tune1.CreateInstance();
                instance.IsLooped = true;
                instance.Volume = 0.1f;
                instance.Play();
            }

            Console.WriteLine(klik_op_bob.State);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tune1 = Content.Load<SoundEffect>(@"audio\tune\tune1");

            //commandprompt
            klik_karakter = Content.Load<SoundEffect>(@"audio\voice\command_prompt\klik_karakter_new.wav").CreateInstance();
            verkeerde_actie = Content.Load<SoundEffect>(@"audio\voice\command_prompt\verkeerde_actie_new.wav").CreateInstance();
            verkeerde_persoon = Content.Load<SoundEffect>(@"audio\voice\command_prompt\verkeerde_persoon_new.wav").CreateInstance();
            wat_doen = Content.Load<SoundEffect>(@"audio\voice\command_prompt\wat_doen_new.wav").CreateInstance();

            ////level1
            begin_level1 = Content.Load<SoundEffect>(@"audio\voice\level1\begin_new").CreateInstance();
            klik_op_pc_bob = Content.Load<SoundEffect>(@"audio\voice\level1\klik_op_pc_bob_new.wav").CreateInstance();
            klik_op_bob = Content.Load<SoundEffect>(@"audio\voice\level1\klik_op_bob_new.wav").CreateInstance();
            actie_bob = Content.Load<SoundEffect>(@"audio\voice\level1\actie_bob_new.wav").CreateInstance();
            bob_succes = Content.Load<SoundEffect>(@"audio\voice\level1\bob_succes_new.wav").CreateInstance();
            help_diamanten = Content.Load<SoundEffect>(@"audio\voice\level1\help_diamanten_new.wav").CreateInstance();

            ////level2
            begin_level2 = Content.Load<SoundEffect>(@"audio\voice\level2\begin_level2_new.wav").CreateInstance();
            brug_klaar = Content.Load<SoundEffect>(@"audio\voice\level2\brug_klaar_new.wav").CreateInstance();

            ////level3
            begin_level3 = Content.Load<SoundEffect>(@"audio\voice\level3\begin_level3_new.wav").CreateInstance();
            rat_attack = Content.Load<SoundEffect>(@"audio\voice\level3\rat_attack_new.wav").CreateInstance();
            rat_defeated = Content.Load<SoundEffect>(@"audio\voice\level3\rat_defeated_new.wav").CreateInstance();
            end_game = Content.Load<SoundEffect>(@"audio\voice\level3\end_game_new.wav").CreateInstance();           

        }
       
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            elapsedTimeSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
            overallTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

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
                    //show hover texture after hovering screen buttons
                    if (_titleScreen.StartButton.IsHovering || _titleScreen.ExitButton.IsHovering){
                        _player._mousePointerXOffset = 100;
                        _player._currentMouseTexture = _player._mousePointerTexture;
                    }else{
                        _player._mousePointerXOffset = 0;
                        _player._currentMouseTexture = _player._mouseCursorTexture;
                    }

                    if (_titleScreen.StartButton.IsClicked){
                        //_cheese = new Cheese(this, 7, 4);

                        //creates level, the integer determines which level will be loaded
                        
                        if (DEBUG2)
                        {
                            //start level 2 immediately
                            _currentLevel = new Level(this, _player, 2, 6, 1);
                        }
                        else
                        {
                            //level1
                            _currentLevel = new Level(this, _player, 1, 2, 6);
                        }

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
                            _currentLevel = new Level(this, _player, 2, 6, 1);
                            break;
                        case 2:
                            _currentLevel = new Level(this, _player, 3, 6, 1);
                            break;
                        default:

                            if(!endGameAlreadyPlayed){
                                end_game.Play();
                                endGameAlreadyPlayed = true;
                            }

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
