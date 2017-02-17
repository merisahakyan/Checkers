using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface ICoin
    {
        bool Right(int i, int j, object obj);
        bool Left(int i, int j, object obj);
        bool BackRight(int i, int j, object obj);
        bool BackLeft(int i, int j, object obj);
        bool Right1(int i, int j,object obj);
        bool Left1(int i, int j, object obj);
        bool BackRight1(int i, int j, object obj);
        bool BackLeft1(int i, int j, object obj);
    }
}
