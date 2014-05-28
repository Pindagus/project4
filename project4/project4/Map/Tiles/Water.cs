using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Water : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Water()
            : base(4)
        {

        }

    }
}
