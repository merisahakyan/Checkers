using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    class MyCoin
    {
        public int x;
        public int y;

        public int? leftrisk;
        public int? rightrisk;
        public static List<int?> RightSort(List<MyCoin> list)
        {
            List<int?> right = new List<int?>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].rightrisk != null)
                {
                    right.Add(list[i].rightrisk);
                }
            }
            right.Sort();
            return right;
        }
        public static List<int?> LeftSort(List<MyCoin> list)
        {
            List<int?> left = new List<int?>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].leftrisk != null)
                {
                    left.Add(list[i].leftrisk);
                }
            }
            left.Sort();
            return left;
        }
        public static MyCoin FindByLeftRisk(int? risk, List<MyCoin> list)
        {
            foreach (var m in list)
                if (risk == m.leftrisk)
                    return m;
            return null;
        }
        public static MyCoin FindByRightRisk(int? risk, List<MyCoin> list)
        {
            foreach (var m in list)
                if (risk == m.rightrisk)
                    return m;
            return null;
        }
    }


    public class AutoPlayer : Player
    {
        public override bool Clean(int curi, int curj, int previ, int prevj, GameBoard board)
        {
            return base.Clean(curi, curj, previ, prevj, board);
        }
        public override bool DamaEat(int curi, int curj, int previ, int prevj, GameBoard board, byte a, byte b)
        {
            return base.DamaEat(curi, curj, previ, prevj, board, a, b);
        }
        public override bool Eating(char cur, int curi, int curj, int previ, int prevj, GameBoard board, byte a)
        {
            return base.Eating(cur, curi, curj, previ, prevj, board, a);
        }
        public override int[,] Huff(GameBoard board, byte a, byte b)
        {
            return base.Huff(board, a, b);
        }
        public override void RemoveCoin(GameBoard board, ref Button[,] buttons)
        {
            base.RemoveCoin(board, ref buttons);
        }



        int[,] point = { { -1, -1 }, { -1, -1 } };
        GameBoard newboard;
        //Random r = new Random(6);
        //int random;
        int ii, jj;

        public int[,] Step(GameBoard board)
        {
            List<MyCoin> mycoins = new List<MyCoin>();
            newboard = board;
            for (int j = 0; j < 7; j++)
                for (int i = 0; i <= 7; i++)
                {
                    if (newboard[i, j] == 1)
                    {
                        MyCoin mycoin = new MyCoin();
                        mycoin.x = i;
                        mycoin.y = j;
                        mycoin.leftrisk = 0;
                        mycoin.rightrisk = 0;
                        if (i == 0)
                        {
                            mycoin.leftrisk = null;
                            ii = i + 1;
                            jj = j + 1;
                            if (board[ii, jj] != 0)
                                mycoin.rightrisk = null;
                            else if (jj != 7)
                            {
                                newboard[i, j] = 0;
                                newboard[ii, jj] = 1;
                                if (newboard[ii + 1, jj + 1] == 2 && newboard[ii - 1, jj - 1] == 0)
                                {
                                    mycoin.rightrisk++;
                                }
                                if (newboard[ii - 1, jj + 1] == 2 && newboard[ii + 1, jj - 1] == 0)
                                {
                                    mycoin.rightrisk++;
                                }
                                if (newboard[ii + 1, jj - 1] == 2 && newboard[ii - 1, jj + 1] == 0)
                                {
                                    mycoin.rightrisk++;
                                }
                                newboard[i, j] = 1;
                                newboard[ii, jj] = 0;
                            }
                        }
                        else if (i == 7)
                        {
                            mycoin.rightrisk = null;

                            ii = i - 1;
                            jj = j + 1;
                            if (board[ii, jj] != 0)
                                mycoin.leftrisk = null;
                            else if (jj != 7)
                            {
                                newboard[i, j] = 0;
                                newboard[ii, jj] = 1;
                                if (newboard[ii + 1, jj + 1] == 2 && newboard[ii - 1, jj - 1] == 0)
                                {
                                    mycoin.leftrisk++;
                                }
                                if (newboard[ii - 1, jj - 1] == 2 && newboard[ii + 1, jj + 1] == 0)
                                {
                                    mycoin.leftrisk++;
                                }
                                if (newboard[ii - 1, jj + 1] == 2 && newboard[ii + 1, jj - 1] == 0)
                                {
                                    mycoin.leftrisk++;
                                }
                                newboard[i, j] = 1;
                                newboard[ii, jj] = 0;
                            }
                        }
                        else
                        {
                            //left

                            ii = i - 1;
                            jj = j + 1;
                            if (board[ii, jj] != 0)
                                mycoin.leftrisk = null;
                            else
                            if (ii != 0 && jj != 7)
                            {
                                newboard[i, j] = 0;
                                newboard[ii, jj] = 1;
                                if (newboard[ii + 1, jj + 1] == 2 && newboard[ii - 1, jj - 1] == 0)
                                    mycoin.leftrisk++;
                                if (newboard[ii + 1, jj - 1] == 2 && newboard[ii - 1, jj + 1] == 0)
                                    mycoin.leftrisk++;
                                if (newboard[ii - 1, jj - 1] == 2 && newboard[ii + 1, jj + 1] == 0)
                                    mycoin.leftrisk++;
                                if (newboard[ii - 1, jj + 1] == 2 && newboard[ii + 1, jj - 1] == 0)
                                    mycoin.leftrisk++;
                                newboard[i, j] = 1;
                                newboard[ii, jj] = 0;
                            }



                            //right

                            ii = i + 1;
                            jj = j + 1;
                            if (board[ii, jj] != 0)
                                mycoin.rightrisk = null;
                            else
                            if (ii != 7 && jj != 7)
                            {
                                newboard[i, j] = 0;
                                newboard[ii, jj] = 1;
                                if (newboard[ii - 1, jj - 1] == 2 && newboard[ii + 1, jj + 1] == 0)
                                    mycoin.rightrisk++;
                                if (newboard[ii - 1, jj + 1] == 2 && newboard[ii + 1, jj - 1] == 0)
                                    mycoin.rightrisk++;
                                if (newboard[ii + 1, jj + 1] == 2 && newboard[ii - 1, jj - 1] == 0)
                                    mycoin.rightrisk++;
                                if (newboard[ii + 1, jj - 1] == 2 && newboard[ii - 1, jj + 1] == 0)
                                    mycoin.rightrisk++;
                                newboard[i, j] = 1;
                                newboard[ii, jj] = 0;
                            }

                        }

                        mycoins.Add(mycoin);
                    }
                }

            List<int?> right = MyCoin.RightSort(mycoins);
            List<int?> left = MyCoin.LeftSort(mycoins);
            if (right != null && left != null)
            {
                MyCoin rcoin = MyCoin.FindByRightRisk(right[0], mycoins);
                MyCoin lcoin = MyCoin.FindByLeftRisk(left[0], mycoins);
                if (right[0] <= left[0])
                {
                    point[0, 0] = rcoin.x;
                    point[0, 1] = rcoin.y;
                    point[1, 0] = rcoin.x + 1;
                    point[1, 1] = rcoin.y + 1;
                }
                else
                {
                    point[0, 0] = lcoin.x;
                    point[0, 1] = lcoin.y;
                    point[1, 0] = lcoin.x - 1;
                    point[1, 1] = lcoin.y + 1;
                }
            }
            else
            {
                if (right == null && left != null)
                {
                    MyCoin lcoin = MyCoin.FindByLeftRisk(left[0], mycoins);
                    point[0, 0] = lcoin.x;
                    point[0, 1] = lcoin.y;
                    point[1, 0] = lcoin.x - 1;
                    point[1, 1] = lcoin.y + 1;
                }
                else
                    if (right != null && left == null)
                {
                    MyCoin rcoin = MyCoin.FindByRightRisk(right[0], mycoins);
                    point[0, 0] = rcoin.x;
                    point[0, 1] = rcoin.y;
                    point[1, 0] = rcoin.x + 1;
                    point[1, 1] = rcoin.y + 1;
                }
            }
            return point;
        }





        public void AutoStep(AutoPlayer clintons, int[,] point, ref char turn, ref GameBoard gameboard, ref Button[,] buttons, out bool message)
        {
            message = false;
            point = clintons.Huff(gameboard, 1, 2);
            if (point[0, 0] == -1 && point[0, 1] == -1)
            {
                turn = 't';
                int[,] coins = clintons.Step(gameboard);

                //gameboard[coins[0, 0], coins[0, 1]] = 0;
                //gameboard[coins[1, 0], coins[1, 1]] = 1;

                buttons[coins[0, 0], coins[0, 1]].BackgroundImage = null;
                //buttons[coins[1, 0], coins[1, 1]].BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                if (coins[1, 1] == 7 && gameboard[coins[0, 0], coins[0, 1]] == 1)
                {
                    gameboard[coins[0, 0], coins[0, 1]] = 0;
                    gameboard[coins[1, 0], coins[1, 1]] = 10;
                    buttons[coins[1, 0], coins[1, 1]].BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                }
                else
                {
                    gameboard[coins[0, 0], coins[0, 1]] = 0;
                    gameboard[coins[1, 0], coins[1, 1]] = 1;
                    buttons[coins[1, 0], coins[1, 1]].BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                }
            }
            else
            {
                turn = 't';

                if ((point[1, 1] == 6 && gameboard[point[0, 0], point[0, 1]] == 1) || gameboard[point[0, 0], point[0, 1]]==10)
                {
                    gameboard[point[0, 0], point[0, 1]] = 0;
                    gameboard[point[1, 0], point[1, 1]] = 0;
                    gameboard[point[0, 0] + 2 * (point[1, 0] - point[0, 0]), point[0, 1] + 2 * (point[1, 1] - point[0, 1])] = 10;

                    buttons[point[0, 0], point[0, 1]].BackgroundImage = null;
                    buttons[point[1, 0], point[1, 1]].BackgroundImage = null;
                    buttons[point[0, 0] + 2 * (point[1, 0] - point[0, 0]), point[0, 1] + 2 * (point[1, 1] - point[0, 1])].BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                }
                else
                {
                    gameboard[point[0, 0], point[0, 1]] = 0;
                    gameboard[point[1, 0], point[1, 1]] = 0;
                    gameboard[point[0, 0] + 2 * (point[1, 0] - point[0, 0]), point[0, 1] + 2 * (point[1, 1] - point[0, 1])] = 1;

                    buttons[point[0, 0], point[0, 1]].BackgroundImage = null;
                    buttons[point[1, 0], point[1, 1]].BackgroundImage = null;
                    buttons[point[0, 0] + 2 * (point[1, 0] - point[0, 0]), point[0, 1] + 2 * (point[1, 1] - point[0, 1])].BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                }
            }
        }
    }
}
