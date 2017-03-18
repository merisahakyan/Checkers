using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Calculations
    {
        public static void CoinsCount(GameBoard bars, out byte count1, out byte count2)
        {
            count1 = 0;
            count2 = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (bars[i, j] == 1)
                        count1++;
                    else if (bars[i, j] == 2)
                        count2++;
        }
    }
}
