﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Water : BaseTile
    {

        public Water()
        {
            accessible = false;
        }

        override public int getTileInt
        {
            get
            {
                return 4;
            }
        }
    }
}
