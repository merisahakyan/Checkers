using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Clinton : ICoin
    {
        bool[,] bar = new bool[8, 8];
        public Clinton()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    bar[i, j] = false;
        }
        public bool this[int i, int j]
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
        public bool BackLeft(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j > 0 && i > 0)
            {
                if (trump[i - 1, j - 1] == false)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool BackLeft1(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j > 1 && i > 1)
            {
                if (trump[i - 2, j - 2] == false)
                    return true;
                else return false;
            }
            return false;
        }

        public bool BackRight(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j > 0 && i < 7)
            {
                if (trump[i + 1, j - 1] == false)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool BackRight1(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j > 1 && i < 6)
            {
                if (trump[i - 2, j + 2] == false)
                    return true;
                else return false;
            }
            return false;
        }

        public bool Left(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j < 7 && i > 0)
            {
                if (trump[i - 1, j + 1] == false)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool Left1(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j < 6 && i > 1)
            {
                if (trump[i - 2, j + 2] == false)
                    return true;
                else return false;
            }
            return false;
        }

        public bool Right(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j < 7 && i < 7)
            {
                if (trump[i + 1, j + 1] == false)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool Right1(int i, int j, object obj)
        {
            Trump trump = obj as Trump;
            if (j < 6 && i <6)
            {
                if (trump[i + 2, j + 2] == false)
                    return true;
                else return false;
            }
            return false;
        }
        
    }
}
