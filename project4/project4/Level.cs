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
                    levelMap = new FirstLevelMap(game);

                    //TODO create objects of level here
                    break;
                case 2:
                    levelMap = new LevelMap2(game);
                    break;
                case 3:
                    levelMap = new LastLevelMap(game);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //levels checks if next tile is accessible for cheese
            checkAccessibilityVertical(Keys.Up, ref _cheese._TileY, -1);
            checkAccessibilityVertical(Keys.Down, ref _cheese._TileY, +1);
            checkAccessibilityHorizontal(Keys.Left, ref _cheese._TileX, -1);
            checkAccessibilityHorizontal(Keys.Right, ref _cheese._TileX, +1);   


            base.Update(gameTime);
        }

        public void checkAccessibilityVertical(Keys key, ref int tile, int direction){
            if (Game1._currentKeyboardState.IsKeyDown(key)){
                if (!Game1._previousKeyboardState.IsKeyDown(key)){
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
                    if (levelMap.Rows[_cheese._TileY].Columns[_cheese._TileX + direction].accessible){
                        _cheese.Move(direction, 0);
                    }
                }
            }
        }
    }
}
