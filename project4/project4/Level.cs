using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    public class Level : GameComponent
    {
        private int _currentLevel;
        private TileMap levelMap;
        private Player _player;
        private Cheese _cheese;
        private Computer _computer1;

        public Level(Game game, Player player, Cheese cheese, int currentLevel)
            : base(game)
        {
            game.Components.Add(this);

            _player = player;
            _cheese = cheese;

            _currentLevel = currentLevel;
            setLevel(game); //based on int _currentLevel
        }

        public void setLevel(Game game)
        {
            switch (_currentLevel)
            {
                case 1:
                    //TODO create objects of level here
                    levelMap = new FirstLevelMap(game);

                    //TODO add all objects to list with type GameObject
                    _computer1 = new Computer(game, 4,4);

                    setAccessibility();

                    break;
                case 2:
                    levelMap = new LevelMap2(game);
                    break;
                case 3:
                    levelMap = new LastLevelMap(game);
                    break;
            }
        }

        private void setAccessibility(){
            //for now only computer!
            //TODO foreach level's objects list, and set the accessibility false where objects are standing
            levelMap.Rows[_computer1.TileY].Columns[_computer1.TileX].accessible = false;
        }

        public override void Update(GameTime gameTime)
        {
            //levels checks if next tile is accessible for cheese
            checkAccessibilityVertical(Keys.Up, ref _cheese._TileY, -1);
            checkAccessibilityVertical(Keys.Down, ref _cheese._TileY, +1);
            checkAccessibilityHorizontal(Keys.Left, ref _cheese._TileX, -1);
            checkAccessibilityHorizontal(Keys.Right, ref _cheese._TileX, +1);

            //set mouse pointer selector when hovering over computer1
            if (_computer1.IsHovering){
                _player._mousePointerXOffset = 100;
                _player._currentMouseTexture = _player._mousePointerTexture;
            }else{
                _player._mousePointerXOffset = 0;
                _player._currentMouseTexture = _player._mouseCursorTexture;
            }

            if (_computer1.IsClicked && ComputerSelectionRange()){
                //TODO handle computer actions after clicking
            }


            base.Update(gameTime);
        }

        //returns true if player stands on tiles next to computer
        private bool ComputerSelectionRange(){
            
            if(
                //row 1
                _computer1.TileX -1 == _cheese._TileX && _computer1.TileY -1 == _cheese._TileY ||
                _computer1.TileX == _cheese._TileX && _computer1.TileY - 1 == _cheese._TileY ||
                _computer1.TileX + 1 == _cheese._TileX && _computer1.TileY - 1 == _cheese._TileY ||

                //row2
                _computer1.TileX - 1 == _cheese._TileX && _computer1.TileY == _cheese._TileY ||
                _computer1.TileX + 1 == _cheese._TileX && _computer1.TileY == _cheese._TileY ||

                //row3
                _computer1.TileX - 1 == _cheese._TileX && _computer1.TileY + 1 == _cheese._TileY ||
                _computer1.TileX == _cheese._TileX && _computer1.TileY + 1 == _cheese._TileY ||
                _computer1.TileX + 1 == _cheese._TileX && _computer1.TileY + 1 == _cheese._TileY
                )
            {
                return true;
            }

            return false;
        }

        public void checkAccessibilityVertical(Keys key, ref int tile, int direction){
            if (Game1._currentKeyboardState.IsKeyDown(key)){
                if (!Game1._previousKeyboardState.IsKeyDown(key)){

                    if (key == Keys.Up){
                        _cheese._texture = _cheese._backTexture;
                    }

                    if (key == Keys.Down){
                        _cheese._texture = _cheese._frontTexture;
                    }

                    if (levelMap.Rows[_cheese._TileY + direction].Columns[_cheese._TileX].accessible){
                        //tile += direction;
                        _cheese.Move(0, direction);
                    }
                }
            }
        }

        public void checkAccessibilityHorizontal(Keys key, ref int tile, int direction){
            if (Game1._currentKeyboardState.IsKeyDown(key)){
                if (!Game1._previousKeyboardState.IsKeyDown(key)){
                    if (key == Keys.Left){
                        _cheese._texture = _cheese._leftTexture;
                    }

                    if(key == Keys.Right){
                        _cheese._texture = _cheese._rightTexture;
                    }

                    if (levelMap.Rows[_cheese._TileY].Columns[_cheese._TileX + direction].accessible){
                        _cheese.Move(direction, 0);
                    }
                }
            }
        }
    }
}
