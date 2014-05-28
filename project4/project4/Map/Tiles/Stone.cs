using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Stone : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Stone()
            : base(6)
        {

        }
    }
}
