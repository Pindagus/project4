﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Grass : BaseTile
    {
        public int getTileInt
        {
            get
            {
                return TileInt;
            }
        }

        public Grass()
            : base(2)
        {

        }
    }
}
