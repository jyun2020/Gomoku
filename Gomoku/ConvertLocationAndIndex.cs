using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public static class Extension
    {
        public static int ConvertToArrayIndex(this int parameter)
        {
            int index = ((int)parameter / 75) - 1;

            if (parameter % 75 > 37.5)
                index++;

            return index;
        }
        public static int ConvertToLocation(this int parameter)
        {
            return ((parameter + 1) * 75) - 26;
        }
    }
}
