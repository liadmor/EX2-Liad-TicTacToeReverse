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

        public static void PrintBoard(Board i_Board)
        {
            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                Console.Write((i + 1) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                Console.Write((i + 1) + "|");
                for (int j = 0; j < i_Board.m_BoardSize; j++)
                {
                    Console.Write((char)((i_Board.board[i, j]).GetCellMark()) + "|") ;
                }

                Console.WriteLine();
                for (int k = 0; k < 3 * i_Board.m_BoardSize; k++)
                {
                    Console.Write("=");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static Cell GetCellBoard(Board i_board, int i_row, int i_col)
        {
            return i_board.board[i_row, i_col];

        }

        public static bool CheckRowSequence(Board i_Board, Cell i_Cell)
        {
            bool ThereIsSequence = true;
            char CellMark = (char)i_Cell.GetCellMark();


            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                if ((char)Board.GetCellBoard(i_Board, Cell.GetRow(i_Cell), i).GetCellMark() != CellMark)//בודק שורה
                {
                    ThereIsSequence = false;
                }
            }
            return ThereIsSequence;
        }

        public static bool CheckColSequence(Board i_Board, Cell i_Cell)
        {
            bool ThereIsSequence = true;
            char CellMark = (char)i_Cell.GetCellMark();

            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                if ((char)Board.GetCellBoard(i_Board, i, Cell.GetCol(i_Cell)).GetCellMark() != CellMark)//בודק עמודה
                {
                    ThereIsSequence = false;
                }
            }
            return ThereIsSequence;
        }

        public static bool CheckDiagonalSequence(Board i_Board, Cell i_Cell) //בודק אלכסון
        {
            bool ThereIsSequence = true;
            char CellMark = (char)i_Cell.GetCellMark();

            if ((Cell.GetCol(i_Cell) != Cell.GetRow(i_Cell)) && (Cell.GetCol(i_Cell) != (i_Board.m_BoardSize - Cell.GetRow(i_Cell) - 1))) //בדיקה האם התא נמצא על האלכסון ראשי
            {
                ThereIsSequence = false;
            }
            else
            {
                if (Cell.GetCol(i_Cell) == Cell.GetRow(i_Cell))//אם זה אלכסון ראשי
                {
                    for (int i = 0; i < i_Board.m_BoardSize; i++)
                    {
                        if ((char)Board.GetCellBoard(i_Board, i, i).GetCellMark() != CellMark)
                        {
                            ThereIsSequence = false;
                        }
                    }
                    Console.WriteLine("in the main diagnal");
                }
                else
                {
                    for (int i = 0; i < i_Board.m_BoardSize; i++)
                    {
                        if ((char)Board.GetCellBoard(i_Board, i, i_Board.m_BoardSize - i - 1).GetCellMark() != CellMark)
                        {
                            ThereIsSequence = false;
                        }
                    }
                }
            }

            return ThereIsSequence;
        }

        public static bool CheckIfTheBoardIsFull(Board i_Board)
        {
            bool IsFull = true;
            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                for (int j = 0; j < i_Board.m_BoardSize; j++)
                {
                    if (Cell.IsEmpty(Board.GetCellBoard(i_Board, i, j)))
                    {
                        IsFull = false;
                    }
                }
            }

            return IsFull;
        }
    }
}
