using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Calculations
    {
        public static int CoinsCount<T>(T bars) where T : ICoin
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (bars[i, j] == true)
                        count++;
            return count;
        }
    }
}
