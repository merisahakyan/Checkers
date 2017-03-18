using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class GameBoard
    {
        byte[,] board = new byte[8, 8];
        public byte this[int i,int j]
        {
            set
            {
                board[i, j] = value;
            }
            get
            {
                return board[i, j];
            }
        }
        public GameBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (j < 3 && (i + j) % 2 == 1)
                        board[i, j] = 1;
                    else if (j > 4 && (i + j) % 2 == 1)
                        board[i, j] = 2;
                    else board[i, j] = 0;
        }
            
    }
}
