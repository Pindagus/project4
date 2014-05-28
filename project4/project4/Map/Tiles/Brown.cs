using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Brown : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Brown()
            : base(0)
        {

        }
    }
}
