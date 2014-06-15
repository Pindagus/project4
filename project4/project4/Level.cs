using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Level : GameComponent
    {
        public int _currentLevelInt;
        private TileMap levelMap;
        private Player _player;
        private Cheese _cheese;
        public bool diamondIsTaken;
        private Diamond _diamond;
        private ConsoleInterface _consoleInterface;

        private bool correctActionWasChosen;       

        //contains only computers
        public List<Computer> _computerList = new List<Computer>();

        //list with mouse enemys
        public List<Rat> _ratList = new List<Rat>();

        //interactors have a different list, so they can be treated differently. Objects that can be clicked on.
        public List<Interactor> _interactorList = new List<Interactor>();

        //this list contains all the objects of level which doesn't allow the cheese to stand on their tile
        //use this list only for objects that restrict the cheese for standing on their tile
        public List<GameObject> _gameObjectList = new List<GameObject>();

        //list with ALL objects, mainly for removing
        public List<GameObject> _allObjects = new List<GameObject>();
        private Bob _bob;
        private Rat _rat1;
        private Rat _rat2;
        private bool bobHasAlreadyTalked;
        private bool computerIsAlreadyClicked;
        private bool cheeseHasAlreadyTalkebAboutRat;
        private MarketStall _marketStall;

        public Level(Game game, Player player, int currentLevel, int cheeseX, int cheeseY)
            : base(game)
        {
            game.Components.Add(this);

            _cheese = new Cheese(game, cheeseX, cheeseY);
            _interactorList.Add(_cheese);

            diamondIsTaken = false;

            //set _cheese in player
            _player = player;
            _player._cheese = _cheese;
            _allObjects.Add(_cheese);

            _currentLevelInt = currentLevel;

            setLevel(game); //based on int _currentLevelInt
        }

        public void setLevel(Game game)
        {
            switch (_currentLevelInt)
            {
                //each level must have at least one computer and one diamond

                case 1:
                    Game1.begin_level1.Play();

                    levelMap = new FirstLevelMap(game);

                    //set console, starting position is outside screen thus unvisible
                    _consoleInterface = new ConsoleInterface(game);

                    //each level has to have a bob present, else modify update loop through interactorlist
                    //if you want bob to be invisible set bob's position outside screen
                    _bob = new Bob(game, 5, 3);
                    _interactorList.Add(_bob);
                    _gameObjectList.Add(_bob);
                    _allObjects.Add(_bob);

                    ///<para>
                    ///     computer takes:
                    ///     Game game,
                    ///     int tileX = the x tile that the computer will be set
                    ///     int tileY = the Y tile that the computer will be set
                    ///     String assignment = the computer's assignment
                    ///</para>
                    Computer _computer1 = new Computer(game, 3, 3, "Talk");
                    _computerList.Add(_computer1);
                    _interactorList.Add(_computer1);
                    _gameObjectList.Add(_computer1);
                    _allObjects.Add(_computer1);

                    _diamond = new Diamond(game, 7, 8);
                    _allObjects.Add(_diamond);

                    _marketStall = new MarketStall(game, 6, 3);
                    _gameObjectList.Add(_marketStall);
                    _allObjects.Add(_marketStall);

                    //sets accessibility of tiles where gameObjects are standing on to false
                    foreach (GameObject gameObject in _gameObjectList){
                        setAccessibility(gameObject);
                    }

                    break;
                case 2:
                    Game1.begin_level2.Play();

                    levelMap = new LevelMap2(game);

                    _consoleInterface = new ConsoleInterface(game);

                    _bob = new Bob(game, 9, 7);
                    _interactorList.Add(_bob);
                    _gameObjectList.Add(_bob);
                    _allObjects.Add(_bob);

                    Computer _computer3 = new Computer(game, 7, 4, "Bridge");
                    _computerList.Add(_computer3);
                    _interactorList.Add(_computer3);
                    _gameObjectList.Add(_computer3);
                    _allObjects.Add(_computer3);

                    _diamond = new Diamond(game, 12, 8);
                    _allObjects.Add(_diamond);

                    //sets accessibility of tiles where gameObjects are standing on to false
                    foreach (GameObject gameObject in _gameObjectList)
                    {
                        setAccessibility(gameObject);
                    }

                    break;
                case 3:
                    Game1.begin_level3.Play();

                    levelMap = new LastLevelMap(game);

                    _consoleInterface = new ConsoleInterface(game);

                    _bob = new Bob(game, 9, 7);
                    _interactorList.Add(_bob);
                    _gameObjectList.Add(_bob);
                    _allObjects.Add(_bob);

                    Computer _computer5 = new Computer(game, 5, 6, "Attack");
                    _computerList.Add(_computer5);
                    _interactorList.Add(_computer5);
                    _gameObjectList.Add(_computer5);
                    _allObjects.Add(_computer5);

                    _diamond = new Diamond(game, 1, 7);
                    _allObjects.Add(_diamond);

                    //rats
                    _rat1 = new Rat(game, 3, 7);
                    _ratList.Add(_rat1);
                    _allObjects.Add(_rat1);

                    _rat2 = new Rat(game, 7, 4, true);
                    _ratList.Add(_rat2);
                    _allObjects.Add(_rat2);

                    //sets accessibility of tiles where gameObjects are standing on to false
                    foreach (GameObject gameObject in _gameObjectList)
                    {
                        setAccessibility(gameObject);
                    }

                    break;
            }
        }

        private void setAccessibility(GameObject gameObject){
            levelMap.Rows[gameObject.TileY].Columns[gameObject.TileX].accessible = false;

            if (gameObject == _marketStall)
            {
                levelMap.Rows[gameObject.TileY].Columns[gameObject.TileX + 1].accessible = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //for audio
            if (bobSelectionRange() && !bobHasAlreadyTalked && _currentLevelInt == 1){
                Game1.klik_op_pc_bob.Play();
                bobHasAlreadyTalked = true;
            }

            //for audio
            if (_currentLevelInt == 3) { 
                if (ratSelectionRange() && !cheeseHasAlreadyTalkebAboutRat){
                    Game1.rat_attack.Play();
                    cheeseHasAlreadyTalkebAboutRat = true;
                }
            }

            if (Game1.begin_level1.State != SoundState.Playing
                && Game1.klik_op_pc_bob.State != SoundState.Playing
                && Game1.begin_level2.State != SoundState.Playing
                && Game1.brug_klaar.State != SoundState.Playing
                && Game1.begin_level3.State != SoundState.Playing
                && Game1.rat_attack.State != SoundState.Playing
                && Game1.rat_defeated.State != SoundState.Playing
                ){
                //levels checks if next tile is accessible for cheese
                checkAccessibilityVertical(Keys.Up, ref _cheese.TileY, -1);
                checkAccessibilityVertical(Keys.Down, ref _cheese.TileY, +1);
                checkAccessibilityHorizontal(Keys.Left, ref _cheese.TileX, -1);
                checkAccessibilityHorizontal(Keys.Right, ref _cheese.TileX, +1);
            }

            //if boolean isnt used then the last in the list will override de pointer, this isn't the wanted effect
            bool hovering = false;
            //this boolean will be used on disabling, to check if was clicked on interactor
            bool oneOfInteractorsIsClicked = false;


            //loop through interactor, they'll have a different mouse when hovering
            // console's runbutton has also a different hover texture
            // and cheese actionlist
            //bob
            //bob's actionlist
            foreach (Interactor interactor in _interactorList)
            {
                if (!oneOfInteractorsIsClicked && interactor.IsClicked){
                    oneOfInteractorsIsClicked = true;
                }

                if (!hovering){
                    if (interactor.IsHovering || _consoleInterface.RunButton.IsHovering || _cheese.actionList.background.IsHovering || _bob.actionList.background.IsHovering)
                    {
                        hovering = true;
                        _player._mousePointerXOffset = 100;
                        _player._currentMouseTexture = _player._mousePointerTexture;
                    }else{
                        hovering = false;
                        _player._mousePointerXOffset = 0;
                        _player._currentMouseTexture = _player._mouseCursorTexture;
                    }
                }
            }           
                //loop through computerlist
                foreach(Computer computer in _computerList){

                    setComputerSelectionTile(computer);


                    //bobs speech will also be present in this group below
                    if (
                        Game1.klik_op_pc_bob.State != SoundState.Playing
                        && Game1.klik_op_bob.State != SoundState.Playing
                        && Game1.actie_bob.State != SoundState.Playing
                        && Game1.klik_karakter.State != SoundState.Playing
                        && Game1.wat_doen.State != SoundState.Playing
                        && Game1.verkeerde_actie.State != SoundState.Playing
                        && Game1.verkeerde_persoon.State != SoundState.Playing
                        )
                    { 

                        //computer assignment cannot be done 2 times if player has passed computer's assignment
                        if(!computer.assignmentPassed){

                            if(computer.IsClicked && ComputerSelectionRange(computer)){
                                computer.isSelected = true;
                                _cheese.MovingAllowed = false;                    

                                //set console and runbutton visible
                                _consoleInterface.console._position.X = (float)_consoleInterface.visiblePosX;
                                _consoleInterface.RunButton._position.X = (float)_consoleInterface.visiblePosX;

                                Console.WriteLine("Computer was clicked");
                            }

                            if(computer.isSelected){

                                if(_currentLevelInt == 1 && !computerIsAlreadyClicked){
                                    Game1.klik_op_bob.Play();
                                    computerIsAlreadyClicked = true;
                                }

                                if (_currentLevelInt == 2 && !computerIsAlreadyClicked)
                                {
                                    Game1.klik_karakter.Play();
                                    computerIsAlreadyClicked = true;
                                }

                                if (_currentLevelInt == 3 && !computerIsAlreadyClicked)
                                {
                                    Game1.klik_karakter.Play();
                                    computerIsAlreadyClicked = true;
                                }


                                if (_cheese.IsClicked)
                                {
                                    //for audio
                                    if (computer.Assignment == "Talk"){
                                        Game1.verkeerde_persoon.Play();            
                                    }

                                    //for audio
                                    if(computer.Assignment != "Talk"){
                                        Game1.wat_doen.Play();                   
                                    }

                                    correctActionWasChosen = false;

                                    resetActionLists();

                                    //cheese clicked after computer was selected
                                    //set cheese as currentConsoleObject, because it has to be displayed in the console
                                    _consoleInterface.currentObject = _cheese.ConsoleName;

                                    //reset console method
                                    _consoleInterface.currentMethod = "";

                                    //set background of action list of cheese visible
                                    _cheese.actionList.background._position.X = _cheese.ComputePos.X;
                                    _cheese.actionList.background._position.Y = _cheese.ComputePos.Y;

                                    //set jumpbutton
                                    _cheese.actionList.JumpButton._position.X = _cheese.ComputePos.X;
                                    _cheese.actionList.JumpButton._position.Y = _cheese.ComputePos.Y;

                                    //set bridgebutton
                                    _cheese.actionList.BridgeButton._position.X = _cheese.ComputePos.X;
                                    _cheese.actionList.BridgeButton._position.Y = _cheese.ComputePos.Y + _cheese.actionList.BridgeButton._texture.Height + 10;

                                    //set attackbutton
                                    _cheese.actionList.AttackButton._position.X = _cheese.ComputePos.X;
                                    _cheese.actionList.AttackButton._position.Y = _cheese.ComputePos.Y + (_cheese.actionList.AttackButton._texture.Height + 10) * 2;
                                }

                                if(_bob.IsClicked){

                                    //for audio
                                    if (computer.Assignment != "Talk")
                                    {
                                        Game1.verkeerde_persoon.Play();
                                    }

                                    if (_currentLevelInt == 1)
                                    {
                                        Game1.actie_bob.Play();
                                    }

                                    correctActionWasChosen = false;

                                    resetActionLists();

                                    //set bob as currentConsoleObject, because it has to be displayed in the console
                                    _consoleInterface.currentObject = _bob.ConsoleName;

                                    //reset console method
                                    _consoleInterface.currentMethod = "";

                                    //set background of action list of cheese visible
                                    _bob.actionList.background._position.X = _bob.ComputePos.X;
                                    _bob.actionList.background._position.Y = _bob.ComputePos.Y;

                                    //set talkbutton
                                    _bob.actionList.TalkButton._position.X = _bob.ComputePos.X;
                                    _bob.actionList.TalkButton._position.Y = _bob.ComputePos.Y;
                                }

                                //check if chosen action is the right one of that computer

                                //check buttons of cheese's action list
                                if (_cheese.actionList.BridgeButton.IsClicked)
                                {

                                    Console.WriteLine("BridgeButton clicked");
                                    if (computer.Assignment == "Bridge")
                                    {

                                        correctActionWasChosen = true;

                                        //set current method in console
                                        _consoleInterface.currentMethod = "BouwBrug()";

                                        Console.WriteLine("Rigth action was chosen");
                                    }
                                    else
                                    {
                                        correctActionWasChosen = false;
                                        _consoleInterface.currentMethod = "BouwBrug()";

                                        Console.WriteLine("Rigth action was NOT chosen");
                                    }
                                }


                                //check buttons of cheese's action list
                                if (_bob.actionList.TalkButton.IsClicked)
                                {

                                    Console.WriteLine("TalkButton clicked");
                                    if (computer.Assignment == "Talk")
                                    {

                                        correctActionWasChosen = true;

                                        //set current method in console
                                        _consoleInterface.currentMethod = "Praat()";

                                        Console.WriteLine("Rigth action was chosen");
                                    }
                                    else
                                    {

                                        //TODO show the player that their answer was uncorrect

                                        correctActionWasChosen = false;
                                        _consoleInterface.currentMethod = "Praat()";

                                        Console.WriteLine("Rigth action was NOT chosen");
                                    }
                                }

                                if (_cheese.actionList.AttackButton.IsClicked)
                                {

                                    Console.WriteLine("Attack clicked");
                                    if (computer.Assignment == "Attack")
                                    {

                                        correctActionWasChosen = true;

                                        //set current method in console
                                        _consoleInterface.currentMethod = "ValAan()";

                                        Console.WriteLine("Rigth action was chosen");
                                    }
                                    else
                                    {
                                        //TODO show the player that their answer was uncorrect

                                        correctActionWasChosen = false;
                                        _consoleInterface.currentMethod = "ValAan()";

                                        Console.WriteLine("Rigth action was NOT chosen");
                                    }
                                }


                                //assignment passed if runbutton is clicked and if right action was chosen
                                if (_consoleInterface.RunButton.IsClicked)
                                {
                                    if (correctActionWasChosen)
                                    {                
                                        computer.assignmentPassed = true;

                                        disableSelection(computer);

                                        resetProgrammingTools();

                                        if(computer.Assignment == "Talk"){
                                            //play audio
                                        }

                                        if(computer.Assignment == "Bridge"){

                                            //for audio
                                            Game1.brug_klaar.Play();

                                            //set bridge
                                            levelMap.Rows[5].Columns[6] = new Stone();
                                            levelMap.Rows[6].Columns[6] = new Stone();
                                        }

                                        if (computer.Assignment == "Attack")
                                        {
                                            //for audio
                                            Game1.rat_defeated.Play();

                                            //set rat outside screen so it is unvisible
                                            _rat1.TileX = 20;
                                            _rat2.TileX = 20;
                                        }

                                        correctActionWasChosen = false;
                                    }
                                    else
                                    {
                                        //for audio
                                        Game1.verkeerde_actie.Play();

                                        Console.WriteLine("This answer is uncorrect");
                                    }
                                }
                            }

                            //disable computer blinking selection after clicking next to computer 
                            //and next to the console with its runbutton, 
                            //don't disable if interactor was clicked
                            //don't disable if cheese's actionlist was clicked
                            // and if bob's actionlist was clicked
                            if (Game1._previousMouseState.LeftButton == ButtonState.Released && Game1._currentMouseState.LeftButton == ButtonState.Pressed && !computer.IsClicked && computer.isSelected
                                && !_consoleInterface.RunButton.IsClicked
                                && !_consoleInterface.console.IsClicked
                                && !oneOfInteractorsIsClicked
                                && !_cheese.actionList.background.IsClicked
                                && !_bob.actionList.background.IsClicked
                                )
                            {
                                disableSelection(computer);
                                resetProgrammingTools();
                            }
                        }
                        else
                        {
                            computer.selectionTransparency = 1;
                        }

                    }

                }
/////
            //check if player has grabbed diamond, set true if all computer assignments are passed also
            if (_cheese.boundingBox.Intersects(_diamond.boundingBox))
            {
                bool AllComputerAssignmentsPassed = true;

                //check if computer's assignment has been completed
                foreach (Computer computer in _computerList){
                    if (!computer.assignmentPassed){
                        AllComputerAssignmentsPassed = false;
                        break;    
                    }
                }

                if (AllComputerAssignmentsPassed){
                    diamondIsTaken = true;
                }
            }

            foreach(Rat rat in _ratList){
                if(_cheese.boundingBox.Intersects(rat.boundingBox)){
///
                    Console.WriteLine("collide with rat");

                    //respawn cheese to its starting tile
                    _cheese.TileX = _cheese.startingTileX;
                    _cheese.TileY = _cheese.startingTileY;
                    _cheese.texture = _cheese._frontTexture;
                }

                //reverse mouse when encountering non-accessible tile
                if (!levelMap.Rows[rat.TileY].Columns[rat.TileX + rat.direction].accessible && rat.MovingAllowed)
                {
                    rat.direction *= -1;
                }
            }

            base.Update(gameTime);
        }

        public void disableSelection(Computer computer)
        {
            //for audio
            computerIsAlreadyClicked = false;

            _cheese.MovingAllowed = true;
            computer.isSelected = false;
            computer.selectionTransparency = computer.blingTransparency;
        }

        //returns true if player stands on tiles next to computer
        private bool ComputerSelectionRange(Computer computer){
            
            if(
                //row 1
                computer.TileX - 1 == _cheese.TileX && computer.TileY - 1 == _cheese.TileY ||
                computer.TileX == _cheese.TileX && computer.TileY - 1 == _cheese.TileY ||
                computer.TileX + 1 == _cheese.TileX && computer.TileY - 1 == _cheese.TileY ||

                //row2
                computer.TileX - 1 == _cheese.TileX && computer.TileY == _cheese.TileY ||
                computer.TileX + 1 == _cheese.TileX && computer.TileY == _cheese.TileY ||

                //row3
                computer.TileX - 1 == _cheese.TileX && computer.TileY + 1 == _cheese.TileY ||
                computer.TileX == _cheese.TileX && computer.TileY + 1 == _cheese.TileY ||
                computer.TileX + 1 == _cheese.TileX && computer.TileY + 1 == _cheese.TileY
                )
            {
                return true;
            }
            return false;
        }

        private bool bobSelectionRange(){
            if (
                //row 1
                _bob.TileX - 1 == _cheese.TileX && _bob.TileY - 1 == _cheese.TileY ||
                _bob.TileX == _cheese.TileX && _bob.TileY - 1 == _cheese.TileY ||
                _bob.TileX + 1 == _cheese.TileX && _bob.TileY - 1 == _cheese.TileY ||

                //row2
                _bob.TileX - 1 == _cheese.TileX && _bob.TileY == _cheese.TileY ||
                _bob.TileX + 1 == _cheese.TileX && _bob.TileY == _cheese.TileY ||

                //row3
                _bob.TileX - 1 == _cheese.TileX && _bob.TileY + 1 == _cheese.TileY ||
                _bob.TileX == _cheese.TileX && _bob.TileY + 1 == _cheese.TileY ||
                _bob.TileX + 1 == _cheese.TileX && _bob.TileY + 1 == _cheese.TileY
                )
            {
                return true;
            }
            return false;
        }

        private bool ratSelectionRange()
        {
            if (
                _rat2.TileY - 1 == _cheese.TileY
                )                
            {
                return true;
            }
            return false;
        }

        //hide console and run button, resets containing words
        public void resetProgrammingTools()
        {
            //set console and runbutton unvisible and outside screen
            _consoleInterface.console._position.X = (float)_consoleInterface.posOutsideScreenX;
            _consoleInterface.RunButton._position.X = (float)_consoleInterface.posOutsideScreenX;

            resetActionLists();

            //empty all console strings
            _consoleInterface.currentObject = "";
            _consoleInterface.currentMethod = "";

            Console.WriteLine("Disable selection");
        }

        public void resetActionLists()
        {
            //disable action list of cheese
            _cheese.actionList.background._position.X = ActionList.posOutsideScreenX;
            _bob.actionList.background._position.X = ActionList.posOutsideScreenX;

            //set button position ouside of screen
            _cheese.actionList.JumpButton._position.X = ActionList.posOutsideScreenX;
            _cheese.actionList.BridgeButton._position.X = ActionList.posOutsideScreenX;
            _cheese.actionList.AttackButton._position.X = ActionList.posOutsideScreenX;

            //set TalkButton outside screen
            _bob.actionList.TalkButton._position.X = ActionList.posOutsideScreenX;
        }

        //set selection tiles around computer a little transparent, after clicking the computer these selection tiles will blink
        private void setComputerSelectionTile(Computer computer){
            //row1
            levelMap.Rows[computer.TileY - 1].Columns[computer.TileX - 1].transparency = computer.selectionTransparency;
            levelMap.Rows[computer.TileY - 1].Columns[computer.TileX].transparency = computer.selectionTransparency;
            levelMap.Rows[computer.TileY - 1].Columns[computer.TileX + 1].transparency = computer.selectionTransparency;

            //row2
            levelMap.Rows[computer.TileY].Columns[computer.TileX - 1].transparency = computer.selectionTransparency;
            levelMap.Rows[computer.TileY].Columns[computer.TileX + 1].transparency = computer.selectionTransparency;

            //row3
            levelMap.Rows[computer.TileY + 1].Columns[computer.TileX - 1].transparency = computer.selectionTransparency;
            levelMap.Rows[computer.TileY + 1].Columns[computer.TileX].transparency = computer.selectionTransparency;
            levelMap.Rows[computer.TileY + 1].Columns[computer.TileX + 1].transparency = computer.selectionTransparency;
        }

        //NOT IMPLEMENTED YET this will set the location of tile which will be blink on selection of interactor
        private void setInteractorSelectionTile(Interactor interactor)
        {
            levelMap.Rows[interactor.TileY].Columns[interactor.TileX].transparency = interactor.selectionTransparency;
        }

        public void checkAccessibilityVertical(Keys key, ref int tile, int direction){
            if (Game1._currentKeyboardState.IsKeyDown(key)){
                if (!Game1._previousKeyboardState.IsKeyDown(key)){

                    if (key == Keys.Up){
                        _cheese.texture= _cheese._backTexture;
                    }

                    if (key == Keys.Down){
                        _cheese.texture = _cheese._frontTexture;
                    }

                    if (levelMap.Rows[_cheese.TileY + direction].Columns[_cheese.TileX].accessible){
                        _cheese.Move(0, direction);
                    }
                }
            }
        }

        public void checkAccessibilityHorizontal(Keys key, ref int tile, int direction){
            if (Game1._currentKeyboardState.IsKeyDown(key)){

                if (!Game1._previousKeyboardState.IsKeyDown(key)){
                    if (key == Keys.Left){
                        _cheese.texture = _cheese._leftTexture;
                    }

                    if(key == Keys.Right){
                        _cheese.texture = _cheese._rightTexture;
                    }

                    if (levelMap.Rows[_cheese.TileY].Columns[_cheese.TileX + direction].accessible){
                        _cheese.Move(direction, 0);
                    }
                }
            }
        }

        public void ClearLists()
        {
            _computerList.Clear();
            _interactorList.Clear();
            _gameObjectList.Clear();
            _allObjects.Clear();
        }

        internal new void Dispose()
        {
            //deletes this on its own, it doesn't fits in the _allObjectsList due to its different type 
            Game.Components.Remove(levelMap);
            Game.Components.Remove(_consoleInterface);

            //delete all other game object
            foreach (GameObject gameobject in _allObjects){
                Game.Components.Remove(gameobject);   
            }

            //removes actionlists per level below
            // cheese actionlist
            Game.Components.Remove(_cheese.actionList.background);
            Game.Components.Remove(_cheese.actionList.JumpButton);

            Game.Components.Remove(_bob.actionList.background);
            Game.Components.Remove(_bob.actionList.JumpButton); 
        }
    }
}
