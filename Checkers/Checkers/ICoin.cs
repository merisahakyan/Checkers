using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface ICoin
    {
        bool this[int i, int j] { get; set; }
        bool Eating<T>(char prev,char cur,int curi,int curj,int previ,int prevj,T obj)where T:ICoin;
        bool Step(char turn, int prev, int cur, int curi, int curj, int previ, int prevj);
        
    }
}
