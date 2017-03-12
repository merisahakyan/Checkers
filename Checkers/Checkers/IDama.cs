using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface IDama
    {
        bool Step(char turn, char prev, int cur, int curi, int curj, int previ, int prevj);
    }
}
