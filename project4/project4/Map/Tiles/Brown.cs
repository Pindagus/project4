using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4
{
    class Brown : BaseTile
    {

        public Brown()
        {
            accessible = false;
        }

        public override int getTileInt
        {
            get {
                return 0;    
            }
        }

    }
}
