using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class FirstLevel : BaseLevel
    {
        private FirstLevelMap _firstLevelMap;

        public FirstLevel(Game game)
            : base (game)
        {
            //creates new map, to create new map with new structure you have to make new class in Map/Structure directory
            //check code of the two example maps
            _firstLevelMap = new FirstLevelMap(game);
        }
    }
}
