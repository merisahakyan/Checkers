using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Clinton : ICoin
    {
        bool[,] bar = new bool[8, 8];

        int mini, minj, maxi, maxj;
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
        public bool Eating<T>(char prev, char cur, int curi, int curj, int previ, int prevj, T obj) where T : ICoin
        {
            if (prev == 'c' && cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && obj[previ - 1, prevj + 1] == true)
                            || (curi == previ - 2 && curj == prevj - 2 && obj[previ - 1, prevj - 1] == true)
                            || (curi == previ + 2 && curj == prevj + 2 && obj[previ + 1, prevj + 1] == true)
                            || (curi == previ + 2 && curj == prevj - 2 && obj[previ + 1, prevj - 1] == true)))
                return true;
            else return false;
        }

        public bool Step(char turn, int prev, int cur, int curi, int curj, int previ, int prevj)
        {
            if (turn == 'c' && prev == 'c' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj + 1))
                return
                    true;
            else
                return false;
        }
        public int[] Huff<T>(T trumps) where T : ICoin
        {
            int[] point = { -1, -1 };
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && trumps[i + 1, j + 1] && !bar[i + 2, j + 2] && !trumps[i + 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && trumps[i - 1, j - 1] && !bar[i - 2, j - 2] && !trumps[i - 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 0; i < 6; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && trumps[i + 1, j - 1] && !bar[i + 2, j - 2] && !trumps[i + 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && trumps[i - 1, j + 1] && !bar[i - 2, j + 2] && !trumps[i - 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            return point;
        }
        public bool Clean<T>(T ob, int curi, int curj, int previ, int prevj) where T : ICoin
        {
            bool isclean = true;
            if (curi < previ && curj < prevj)
            {
                prevj = curj;
                mini = curi;
                maxi = previ;
            }
            else if (curi > previ && curj > prevj)
            {
                mini = previ;
                maxi = curi;
            }
            else if (curi > previ && curj < prevj)
            {
                mini = previ;
                maxi = curi;
                prevj = curj;
            }
            else if (curi < previ && curj > prevj)
            {
                mini = curi;
                maxi = previ;
            }


            for (int i = mini + 1; i < maxi; i++)
            {
                if (ob[i, prevj + 1] || bar[i, prevj + 1])
                {
                    isclean = false;
                    break;
                }
                prevj++;
            }
            return isclean;

        }


    }
}
