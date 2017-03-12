using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface ICoin
    {
        bool this[int i, int j] { get; set; }
        bool Eating<T>(char cur, int curi, int curj, int previ, int prevj, T player) where T : ICoin;
        int[] Huff<T>(T player) where T : ICoin;


    }
}
