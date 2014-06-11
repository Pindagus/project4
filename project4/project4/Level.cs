using Microsoft.Xna.Framework;
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

        //interactors have a different list, so they can be treated differently. Objects that can be clicked on.
        public List<Interactor> _interactorList = new List<Interactor>();

        //this list contains all the objects of level which doesn't allow the cheese to stand on their tile
        //use this list only for objects that restrict the cheese for standing on their tile
        public List<GameObject> _gameObjectList = new List<GameObject>();

        //list with ALL objects, mainly for removing
        public List<GameObject> _allObjects = new List<GameObject>();

        public Level(Game game, Player player, int currentLevel)
            : base(game)
        {
            game.Components.Add(this);

            _cheese = new Cheese(game, 7, 4);
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
                    levelMap = new FirstLevelMap(game);

                    //set console, starting position is outside screen thus unvisible
                    _consoleInterface = new ConsoleInterface(game);

                    Computer _computer1 = new Computer(game, 3, 4, "Jump");
                    _computerList.Add(_computer1);
                    _interactorList.Add(_computer1);
                    _gameObjectList.Add(_computer1);
                    _allObjects.Add(_computer1);

                    Computer _computer2 = new Computer(game, 6, 6, "Jump");
                    _computerList.Add(_computer2);
                    _interactorList.Add(_computer2);
                    _gameObjectList.Add(_computer2);
                    _allObjects.Add(_computer2);

                    _diamond = new Diamond(game, 2, 2);
                    _allObjects.Add(_diamond);

                    //sets accessibility of tiles where gameObjects are standing on to false
                    foreach (GameObject gameObject in _gameObjectList){
                        setAccessibility(gameObject);
                    }

                    break;
                case 2:
                    levelMap = new LevelMap2(game);

                    _consoleInterface = new ConsoleInterface(game);

                    Computer _computer3 = new Computer(game, 4, 4, "Jump");
                    _computerList.Add(_computer3);
                    _interactorList.Add(_computer3);
                    _gameObjectList.Add(_computer3);
                    _allObjects.Add(_computer3);

                    Computer _computer4 = new Computer(game, 9, 4, "Jump");
                    _computerList.Add(_computer4);
                    _interactorList.Add(_computer4);
                    _gameObjectList.Add(_computer4);
                    _allObjects.Add(_computer4);

                    _diamond = new Diamond(game, 5, 2);
                    _allObjects.Add(_diamond);

                    //sets accessibility of tiles where gameObjects are standing on to false
                    foreach (GameObject gameObject in _gameObjectList)
                    {
                        setAccessibility(gameObject);
                    }

                    break;
                case 3:
                    levelMap = new LastLevelMap(game);

                    _consoleInterface = new ConsoleInterface(game);

                    Computer _computer5 = new Computer(game, 6, 6, "Jump");
                    _computerList.Add(_computer5);
                    _interactorList.Add(_computer5);
                    _gameObjectList.Add(_computer5);
                    _allObjects.Add(_computer5);

                    Computer _computer6 = new Computer(game, 6, 2, "Jump");
                    _computerList.Add(_computer6);
                    _interactorList.Add(_computer6);
                    _gameObjectList.Add(_computer6);
                    _allObjects.Add(_computer6);

                    _diamond = new Diamond(game, 9, 4);
                    _allObjects.Add(_diamond);

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
        }

        public override void Update(GameTime gameTime)
        {
            //levels checks if next tile is accessible for cheese
            checkAccessibilityVertical(Keys.Up, ref _cheese.TileY, -1);
            checkAccessibilityVertical(Keys.Down, ref _cheese.TileY, +1);
            checkAccessibilityHorizontal(Keys.Left, ref _cheese.TileX, -1);
            checkAccessibilityHorizontal(Keys.Right, ref _cheese.TileX, +1);

            //if boolean isnt used then the last in the list will override de pointer, this isn't the wanted effect
            bool hovering = false;
            //this boolean will be used on disabling, to check if was clicked on interactor
            bool oneOfInteractorsIsClicked = false;


            //loop through interactor, they'll have a different mouse when hovering
            // console's runbutton has also a different hover texture
            // and cheese actionlist
            foreach (Interactor interactor in _interactorList)
            {
                if (!oneOfInteractorsIsClicked && interactor.IsClicked){
                    oneOfInteractorsIsClicked = true;
                }

                if (!hovering){
                    if (interactor.IsHovering || _consoleInterface.RunButton.IsHovering || _cheese.actionList.background.IsHovering){
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

                if(computer.IsClicked && ComputerSelectionRange(computer)){

                    computer.isSelected = true;
                    _cheese.MovingAllowed = false;                    

                    //set console and runbutton visible
                    _consoleInterface.console._position.X = (float)_consoleInterface.visiblePosX;
                    _consoleInterface.RunButton._position.X = (float)_consoleInterface.visiblePosX;

                    Console.WriteLine("Computer was clicked");
                }

                if(computer.isSelected){
                    if (_cheese.IsClicked)
                    {
                        //cheese clicked after computer was selected
                        //set cheese as currentConsoleObject, because it has to be displayed in the console
                        _consoleInterface.currentObject = _cheese.ConsoleName;

                        //set background of action list of cheese visible
                        _cheese.actionList.background._position.X = _cheese.ComputePos.X;
                        _cheese.actionList.background._position.Y = _cheese.ComputePos.Y;

                        //set jumpbutton
                        _cheese.actionList.JumpButton._position.X = _cheese.ComputePos.X;
                        _cheese.actionList.JumpButton._position.Y = _cheese.ComputePos.Y;

                        Console.WriteLine(_consoleInterface.currentObject);

                        Console.WriteLine("Cheese was clicked after clicking computer");
                    }

                    //check if chosen action is the right one of that computer

                    //check buttons of cheese's action list
                    if(_cheese.actionList.JumpButton.IsClicked){
                        
                        Console.WriteLine("JumpButton clicked");
                        if(computer.Assignment == "Jump"){

                            correctActionWasChosen = true;

                            //set current method in console
                            _consoleInterface.currentMethod = "spring()";

                            Console.WriteLine("Rigth action was chosen");
                        }else{

                            //TODO show the player that their answer was uncorrect

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

                            correctActionWasChosen = false;
                            Console.WriteLine("Console Runbutton was clicked and chose action was right");
                        }
                        else
                        {
                            Console.WriteLine("This answer is uncorrect");
                        }
                    }
                }

                //disable computer blinking selection after clicking next to computer 
                //and next to the console with its runbutton, 
                //don't disable if interactor was clicked
                //don't disable if cheese's actionlist was clicked
                if (Game1._previousMouseState.LeftButton == ButtonState.Released && Game1._currentMouseState.LeftButton == ButtonState.Pressed && !computer.IsClicked && computer.isSelected
                    && !_consoleInterface.RunButton.IsClicked
                    && !_consoleInterface.console.IsClicked
                    && !oneOfInteractorsIsClicked
                    && !_cheese.actionList.background.IsClicked
                    )
                {
                    disableSelection(computer);

                    resetProgrammingTools();
                }
            }

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

            base.Update(gameTime);
        }

        public void disableSelection(Computer computer)
        {
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

        //hide console and run button, resets containing words
        public void resetProgrammingTools()
        {
            //set console and runbutton unvisible and outside screen
            _consoleInterface.console._position.X = (float)_consoleInterface.posOutsideScreenX;
            _consoleInterface.RunButton._position.X = (float)_consoleInterface.posOutsideScreenX;

            //disable action list of cheese
            _cheese.actionList.background._position.X = ActionList.posOutsideScreenX;

            //set jumpbutton
            _cheese.actionList.JumpButton._position.X = ActionList.posOutsideScreenX;

            //empty all console strings
            _consoleInterface.currentObject = "";
            _consoleInterface.currentMethod = "";

            Console.WriteLine("Disable selection");
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
        }
    }
}
