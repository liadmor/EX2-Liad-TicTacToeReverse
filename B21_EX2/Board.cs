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
        Cell[,] m_Board;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            initBoard();
        }

        private void initBoard()
        {
            m_Board = new Cell[m_BoardSize, m_BoardSize];

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_Board[i, j] = new Cell(i, j, Cell.eCellMark.Mark_Empty);
                }
            }
        }

        public static int IsValidSize(string i_SizeBoard)
        {
            int sizeOfBoard;

            if (Int32.TryParse(i_SizeBoard, out sizeOfBoard))
            {
                if ((sizeOfBoard > 9) || (sizeOfBoard < 3))
                {
                    sizeOfBoard = -1;
                }
            }
            else
            {
                sizeOfBoard = -1;
            }

            return sizeOfBoard;
        }

        public static void PrintBoard(Board i_Board)
        {
            StringBuilder printBoard = new StringBuilder();

            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                printBoard.Append("  " + (i + 1) + " ");
            }

            printBoard.Append(Environment.NewLine);
            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                printBoard.Append((i + 1) + "| ");
                for (int j = 0; j < i_Board.m_BoardSize; j++)
                {
                    printBoard.Append((char)((i_Board.m_Board[i, j]).GetCellMark()) + " | ");
                }

                printBoard.Append(Environment.NewLine);
                printBoard.Append(" =");
                for (int k = 1; k < 4 * i_Board.m_BoardSize; k++)
                {
                    printBoard.Append("=");
                }

                printBoard.Append(Environment.NewLine);
            }

            Console.WriteLine(printBoard);
        }

        public static Cell GetCellBoard(Board i_board, int i_row, int i_col)
        {
            return i_board.m_Board[i_row, i_col];
        }

        public static bool ThereIsWinner(Board i_Board, Cell i_Cell)
        {
            return checkColSequence(i_Board, i_Cell) || checkDiagonalSequence(i_Board, i_Cell) || checkRowSequence(i_Board, i_Cell);
        }

        private static bool checkRowSequence(Board i_Board, Cell i_Cell)
        {
            bool thereIsSequence = true;
            char cellMark;

            cellMark = (char)i_Cell.GetCellMark();
            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                if ((char)Board.GetCellBoard(i_Board, Cell.GetRow(i_Cell), i).GetCellMark() != cellMark)
                {
                    thereIsSequence = false;
                }
            }

            return thereIsSequence;
        }

        private static bool checkColSequence(Board i_Board, Cell i_Cell)
        {
            bool thereIsSequence = true;
            char cellMark;

            cellMark = (char)i_Cell.GetCellMark();
            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                if ((char)Board.GetCellBoard(i_Board, i, Cell.GetCol(i_Cell)).GetCellMark() != cellMark)
                {
                    thereIsSequence = false;
                }
            }

            return thereIsSequence;
        }

        private static bool checkDiagonalSequence(Board i_Board, Cell i_Cell)
        {
            bool thereIsSequence = true;
            char cellMark;

            cellMark = (char)i_Cell.GetCellMark();
            if ((Cell.GetCol(i_Cell) != Cell.GetRow(i_Cell)) && (Cell.GetCol(i_Cell) != (i_Board.m_BoardSize - Cell.GetRow(i_Cell) - 1)))
            {
                thereIsSequence = false;
            }
            else
            {
                if (Cell.GetCol(i_Cell) == Cell.GetRow(i_Cell))
                {
                    for (int i = 0; i < i_Board.m_BoardSize; i++)
                    {
                        if ((char)Board.GetCellBoard(i_Board, i, i).GetCellMark() != cellMark)
                        {
                            thereIsSequence = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < i_Board.m_BoardSize; i++)
                    {
                        if ((char)Board.GetCellBoard(i_Board, i, i_Board.m_BoardSize - i - 1).GetCellMark() != cellMark)
                        {
                            thereIsSequence = false;
                        }
                    }
                }
            }

            return thereIsSequence;
        }

        public static bool CheckIfTheBoardIsFull(Board i_Board)
        {
            bool isFull = true;

            for (int i = 0; i < i_Board.m_BoardSize; i++)
            {
                for (int j = 0; j < i_Board.m_BoardSize; j++)
                {
                    if (Cell.IsEmpty(Board.GetCellBoard(i_Board, i, j)))
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        public static int FindNumberAxis(int i_boardsize, string i_whichAxis, Player i_NowPlaying)
        {
            bool stillCheck = true;
            int ans = 0;
            string axisNumberStr;
            int axisNumberInt;

            axisNumberStr = TicTacToeReverse.AskAxisNumber(i_boardsize, i_whichAxis, i_NowPlaying);
            axisNumberInt = Cell.ValidInputAxis(axisNumberStr, i_boardsize);
            while (stillCheck)
            {
                if (axisNumberInt == -1)
                {
                    if (axisNumberStr == "Q")
                    {
                        stillCheck = false;
                        ans = -1;
                        break;
                    }
                    else
                    {
                        axisNumberStr = TicTacToeReverse.AskAxisNumber(i_boardsize, i_whichAxis, i_NowPlaying);
                        axisNumberInt = Cell.ValidInputAxis(axisNumberStr, i_boardsize);
                    }
                }
                else
                {
                    stillCheck = false;
                    ans = axisNumberInt;
                    break;
                }
            }

            return ans;
        }

        public static int GetBoardSize(Board i_Board)
        {
            return i_Board.m_BoardSize;
        }
    }
}