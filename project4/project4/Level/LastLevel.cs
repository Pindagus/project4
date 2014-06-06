using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class LastLevel : BaseLevel
    {
        private LastLevelMap _lastLevelMap;

        public LastLevel(Game game)
            : base(game)
        {
            _lastLevelMap = new LastLevelMap(game);     
        }
    }
}
