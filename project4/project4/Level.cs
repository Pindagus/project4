using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Level : GameComponent
    {
        private int _currentLevel;
        private TileMap _levelMap;

        public Level(Game game, int currentLevel)
            : base(game)
        {
            game.Components.Add(this);

            _currentLevel = currentLevel;
            setLevel(game);
        }

        public void setLevel(Game game)
        {
            switch (_currentLevel)
            {
                case 1:
                    _levelMap = new FirstLevelMap(game);
                    break;

                    //TDO create object of level here

                case 2:
                    _levelMap = new LevelMap2(game);
                    break;
                case 3:
                    _levelMap = new LastLevelMap(game);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //TODO level update

            base.Update(gameTime);
        }
    }
}
