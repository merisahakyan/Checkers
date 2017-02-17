using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Trump : ICoin
    {
        bool[,] bar = new bool[8, 8];
        public Trump()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    bar[i, j] = false;
        }
        public bool this[int i,int j]
        {
            get
            {
                return bar[i, j];
            }
            set
            {
                bar[i, j] = value;
            }
        }
        public bool BackLeft(int i, int j)
        {
            throw new NotImplementedException();
        }

        public bool BackRight(int i, int j)
        {
            throw new NotImplementedException();
        }

        public bool Left(int i, int j)
        {
            throw new NotImplementedException();
        }

        public bool Right(int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
