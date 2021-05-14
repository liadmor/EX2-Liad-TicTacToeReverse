using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX2
{
    class Board
    {
        int m_BoardSize;
        Cell[,] board;
        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            InitBoard();
        }

        public void InitBoard()
        {
            board = new Cell[m_BoardSize, m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    board[i, j] = new Cell(i, j, Cell.eCellMark.Mark_Empty);
                }
            }
        }

        public static int IsValidSize(string sizeBoard)
        {
            int sizeOfBoard;
            try
            {
                sizeOfBoard = Int32.Parse(sizeBoard);
                if ((sizeOfBoard > 9) || (sizeOfBoard < 3))
                {
                    sizeOfBoard = -1;
                }
            }
            catch (FormatException)
            {
                sizeOfBoard = -1;
            }

            return sizeOfBoard;
        }
    }
}
