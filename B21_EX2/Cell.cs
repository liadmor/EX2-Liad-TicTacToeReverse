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

    }
}
