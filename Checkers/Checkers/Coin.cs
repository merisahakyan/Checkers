using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface Coin
    {
        bool Right(int i, int j);
        bool Left(int i, int j);
        bool BackRight(int i, int j);
        bool BackLeft(int i, int j);
    }
}
