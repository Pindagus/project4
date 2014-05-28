using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Dirt : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Dirt()
            : base(1)
        {

        }

    }
}
