using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX2
{
    class Cell
    {
        int m_RowNumber;
        int m_ColNumber;
        eCellMark m_Mark;

        public Cell(int i_RowNumber, int i_ColNumber, eCellMark i_Mark)
        {
            m_RowNumber = i_RowNumber;
            m_ColNumber = i_ColNumber;
            m_Mark = i_Mark;
        }
        public enum eCellMark
        {
            Mark_Empty = ' ',
            Mark_X = 'X',
            Mark_O = 'O',
        }

        public static int IsValidInputRowAndCol(string RowInput, int BoardSize)
        {
            int NumberRow;

            if (Int32.TryParse(RowInput, out NumberRow))
            {
                if ((NumberRow > BoardSize) || (NumberRow < 1))
                {
                    NumberRow = -1;
                }
            }
            else
            {
                NumberRow = -1;
            }

            return NumberRow;
        }

        public static bool IsEmpty(Cell i_Cell)
        {
            bool CellIsEmpty = true;

            if ((char)i_Cell.m_Mark != (char)eCellMark.Mark_Empty)
            {
                CellIsEmpty = false;
            }

            return CellIsEmpty;
        }

        public static void SetCell(Cell i_Cell, eCellMark i_CellMark)
        {
            i_Cell.m_Mark = i_CellMark;
        }

        public eCellMark GetCellMark()
        {
            return m_Mark;
        }

        public static int GetRow(Cell i_Cell)
        {
            return i_Cell.m_RowNumber;
        }

        public static int GetCol(Cell i_Cell)
        {
            return i_Cell.m_ColNumber;
        }

    }
}
