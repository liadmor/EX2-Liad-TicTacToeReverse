using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX2
{
    class Player
    {
        string m_PlayerType; //c\p
        Cell.eCellMark m_PlayerMark; // X\O
        int m_NumberOfPoinf;

        public Player(string i_PlayerType, Cell.eCellMark i_PlayerMark)
        {
            m_PlayerType = i_PlayerType;
            m_PlayerMark = i_PlayerMark;
            m_NumberOfPoinf = 0;
        }

        public static bool IsValidPlayer(string i_player)
        {
            bool isValid = true;

            if ((i_player != "c") && (i_player != "p"))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
