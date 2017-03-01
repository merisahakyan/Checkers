﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Trump :ICoin
    { 
        bool[,] bar = new bool[8, 8];
        public Trump()
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

        public bool Eating<T>(char prev, char cur, int curi, int curj, int previ, int prevj, T obj) where T : ICoin
        {
            if (prev == 't' && cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && obj[previ - 1, prevj + 1] == true)
                            || (curi == previ - 2 && curj == prevj - 2 && obj[previ - 1, prevj - 1] == true)
                            || (curi == previ + 2 && curj == prevj + 2 && obj[previ + 1, prevj + 1] == true)
                            || (curi == previ + 2 && curj == prevj - 2 && obj[previ + 1, prevj - 1] == true)))
                return true;
            else
                return false;

        }

        public int[] Huff<T>(T clintons) where T : ICoin
        {
            int[] point = { -1, -1 };
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && clintons[i + 1, j + 1] && !bar[i + 2, j + 2] && !clintons[i + 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && clintons[i - 1, j - 1] && !bar[i - 2, j - 2] && !clintons[i - 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 0; i < 6; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && clintons[i + 1, j - 1] && !bar[i + 2, j - 2] && !clintons[i + 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && clintons[i - 1, j + 1] && !bar[i - 2, j + 2] && !clintons[i - 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            return point;
        }

        public bool Step(char turn, int prev, int cur, int curi, int curj, int previ, int prevj)
        {
            if (turn == 't' && prev == 't' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj - 1))
                return true;
            else
                return false;
        }
    }
}
