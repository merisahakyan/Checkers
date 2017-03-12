using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Player : ICoin, IDama
    {
        bool[,] bar = new bool[8, 8];
        public bool[,] isdama = new bool[8, 8];

        int mini, maxi,j;
        public Player()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    bar[i, j] = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    isdama[i, j] = false;
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
        public bool Eating<T>(char cur, int curi, int curj, int previ, int prevj, T player) where T : ICoin
        {
            if (cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && player[previ - 1, prevj + 1] == true)
                            || (curi == previ - 2 && curj == prevj - 2 && player[previ - 1, prevj - 1] == true)
                            || (curi == previ + 2 && curj == prevj + 2 && player[previ + 1, prevj + 1] == true)
                            || (curi == previ + 2 && curj == prevj - 2 && player[previ + 1, prevj - 1] == true)))
                return true;
            else return false;
        }

        public bool Step(char turn, char prev, int cur, int curi, int curj, int previ, int prevj)
        {
            if (turn == 'c' && prev == 'c' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj + 1)
                || (turn == 't' && prev == 't' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj - 1)))
                return
                    true;
            else
                return false;
        }
        public int[] Huff<T>(T player) where T : ICoin
        {
            int[] point = { -1, -1 };
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && player[i + 1, j + 1] && !bar[i + 2, j + 2] && !player[i + 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && player[i - 1, j - 1] && !bar[i - 2, j - 2] && !player[i - 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 0; i < 6; i++)
                for (int j = 2; j < 8; j++)
                    if (bar[i, j] && player[i + 1, j - 1] && !bar[i + 2, j - 2] && !player[i + 2, j - 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            for (int i = 2; i < 8; i++)
                for (int j = 0; j < 6; j++)
                    if (bar[i, j] && player[i - 1, j + 1] && !bar[i - 2, j + 2] && !player[i - 2, j + 2])
                    {
                        point[0] = i;
                        point[1] = j;
                        return point;
                    }
            return point;
        }
        public bool Clean<T>(T player, int curi, int curj, int previ, int prevj) where T : ICoin
        {
            bool isclean = true;
            if (curi < previ && curj < prevj)
            {
                j = curj;
                mini = curi;
                maxi = previ;
            }
            else if (curi > previ && curj > prevj)
            {
                j = prevj;
                mini = previ;
                maxi = curi;
            }
            else if (curi > previ && curj < prevj)
            {
                j = prevj;
                mini = previ;
                maxi = curi;
                //bug prevj--
            }
            else if (curi < previ && curj > prevj)
            {
                mini = curi;
                maxi = previ;
                j = curj;
                //bug prevj--
            }


            for (int i = mini + 1; i < maxi; i++)
            {
                if ((curi < previ && curj < prevj) || (curi > previ && curj > prevj))
                    j++;
                else if ((curi > previ && curj < prevj) || (curi < previ && curj > prevj))
                    j--;
                if (player[i, j] || bar[i, j])
                {
                    isclean = false;
                    break;
                }

            }
            return isclean;
        }
    }
}
