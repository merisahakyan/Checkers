using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public class Player
    {
        int removedi = 0, removedj = 0;
        int mini, maxi, j;
        int m = 0, n = 0;

        public virtual bool  Eating(char cur, int curi, int curj, int previ, int prevj, GameBoard board, byte a) 
        {
            if ((cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && (board[previ - 1, prevj + 1] == a || board[previ - 1, prevj + 1] == a * 10))
                            || (curi == previ - 2 && curj == prevj - 2 && (board[previ - 1, prevj - 1] == a || board[previ - 1, prevj - 1] == a * 10))
                            || (curi == previ + 2 && curj == prevj + 2 && (board[previ + 1, prevj + 1] == a || board[previ + 1, prevj + 1] == a * 10))
                            || (curi == previ + 2 && curj == prevj - 2 && (board[previ + 1, prevj - 1] == a || board[previ + 1, prevj - 1] == a * 10)))))

                return true;
            else return false;
        }

        public  bool Step(char turn, char prev, int cur, int curi, int curj, int previ, int prevj)
        {
            if (turn == 'c' && prev == 'c' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj + 1)
                || (turn == 't' && prev == 't' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj - 1)))
                return
                    true;
            else
                return false;
        }
        public virtual int[,] Huff(GameBoard board, byte a, byte b) 
        {
            int[,] point = { { -1, -1 }, { -1, -1 }, { -1,-1} };
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == a && (board[i + 1, j + 1] == b || board[i + 1, j + 1] == b * 10) && board[i + 2, j + 2] == 0)
                    {
                        point[0,0] = i;
                        point[0,1] = j;
                        point[1, 0] = i+1;
                        point[1, 1] = j+1;
                        point[2, 0] = i + 2;
                        point[2, 1] = j + 2;
                        return point;
                    }
                    if (board[i, j] == a * 10)
                    {
                        m = i+1;
                        n = j+1;
                        while (board[m, n] == 0 && m < 7 && n < 7)
                        {
                            m++;
                            n++;
                        }
                        if((board[m,n]==b|| board[m, n] == b*10)&&board[m+1,n+1]==0)
                        {
                            point[0, 0] = i;
                            point[0, 1] = j;
                            point[1, 0] = m;
                            point[1, 1] = n;
                            point[2, 0] = m + 1;
                            point[2, 1] = n + 1;
                            return point;
                        }

                    }
                }
            for (int i = 2; i < 8; i++)
                for (int j = 2; j < 8; j++)
                {
                    if (board[i, j] == a && (board[i - 1, j - 1] == b || board[i - 1, j - 1] == b * 10) && board[i - 2, j - 2] == 0)
                    {
                        point[0, 0] = i;
                        point[0, 1] = j;
                        point[1, 0] = i - 1;
                        point[1,1] = j - 1;
                        point[2, 0] = i - 2;
                        point[2, 1] = j -2;
                        return point;
                    }
                    if (board[i, j] == a * 10)
                    {
                        m = i-1;
                        n = j-1;
                        while (board[m, n] == 0 && m > 0 && n >0)
                        {
                            m--;
                            n--;
                        }
                        if ((board[m, n] == b || board[m, n] == b * 10) && board[m - 1, n - 1] == 0)
                        {
                            point[0, 0] = i;
                            point[0, 1] = j;
                            point[1, 0] = m;
                            point[1, 1] =n;
                            point[2, 0] = m-1;
                            point[2, 1] = n-1;
                            return point;
                        }

                    }
                }
            for (int i = 0; i < 6; i++)
                for (int j = 2; j < 8; j++)
                {
                    if (board[i, j] == a && (board[i + 1, j - 1] == b || board[i + 1, j - 1] == b * 10) && board[i + 2, j - 2] == 0)
                    {
                        point[0, 0] = i;
                        point[0, 1] = j;
                        point[1, 0] = i + 1;
                        point[1, 1] = j - 1;
                        point[2, 0] = i + 2;
                        point[2, 1] = j -2;
                        return point;
                    }
                    if (board[i, j] == a * 10)
                    {
                        m = i+1;
                        n = j-1;
                        while (board[m, n] == 0 && m < 7 && n > 0)
                        {
                            m++;
                            n--;
                        }
                        if ((board[m, n] == b || board[m, n] == b * 10) && board[m + 1, n - 1] == 0)
                        {
                            point[0, 0] = i;
                            point[0, 1] = j;
                            point[1, 0] = m;
                            point[1, 1] = n;
                            point[2, 0] = m+1;
                            point[2, 1] = n-1;
                            return point;
                        }

                    }
                }
            for (int i = 2; i < 8; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == a && (board[i - 1, j + 1] == b || board[i - 1, j + 1] == b * 10) && board[i - 2, j + 2] == 0)
                    {
                        point[0, 0] = i;
                        point[0, 1] = j;
                        point[1, 0] = i - 1;
                        point[1, 1] = j + 1;
                        point[2, 0] = i -2;
                        point[2, 1] = j + 2;
                        return point;
                    }
                    if (board[i, j] == a * 10)
                    {
                        m = i-1;
                        n = j+1;
                        while (board[m, n] == 0 && m >0 && n < 7)
                        {
                            m--;
                            n++;
                        }
                        if ((board[m, n] == b || board[m, n] == b * 10) && board[m - 1, n + 1] == 0)
                        {
                            point[0, 0] = i;
                            point[0, 1] = j;
                            point[1, 0] = m;
                            point[1, 1] = n;
                            point[2, 0] = m-1;
                            point[2, 1] = n+1;
                            return point;
                        }

                    }
                }
            return point;
        }

        public virtual bool DamaEat(int curi, int curj, int previ, int prevj, GameBoard board, byte a, byte b) 
        {

            byte count1 = 0;
            byte count2 = 0;
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
                if (board[i, j] == a)
                {
                    count1++;
                    removedi = i;
                    removedj = j;
                }
                if (board[i, j] == b)
                {
                    count2++;
                }

            }
            if (count1 == 0 && count2 == 1)
                return true;
            else return false;
        }

        public virtual bool Clean(int curi, int curj, int previ, int prevj, GameBoard board) 
        {

            byte count = 0;
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
                if (board[i, j] != 0)
                {
                    count++;
                    removedi = i;
                    removedj = j;
                }
            }
            if (count == 0)
                return true;
            else return false;
        }
        public virtual void RemoveCoin(GameBoard board, ref Button[,] buttons)
        {
            buttons[removedi, removedj].BackgroundImage = null;
            board[removedi, removedj] = 0;
        }

    }
}
