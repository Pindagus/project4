using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Wood : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Wood()
            : base(5)
        {

        }
    }
}
