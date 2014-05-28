using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Concrete : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Concrete()
            : base(3)
        {

        }
    }
}
