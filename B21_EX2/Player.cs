using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX2
{
    class Player
    {
        string m_PlayerType;
        Cell.eCellMark m_PlayerMark;
        int m_NumberOfPoinf;

        public Player(string i_PlayerType, Cell.eCellMark i_PlayerMark)
        {
            m_PlayerType = i_PlayerType;
            m_PlayerMark = i_PlayerMark;
            m_NumberOfPoinf = 0;
        }

        public static void ChengePlayers(ref Player io_waitingPlayer, ref Player io_NowPlaying)
        {

            Player tempPlayer;
            
            tempPlayer= io_waitingPlayer;
            io_waitingPlayer = io_NowPlaying;
            io_NowPlaying = tempPlayer;
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

        public static string GetPlayerType(Player i_Player)
        {
            return i_Player.m_PlayerType;
        }

        public static Cell.eCellMark GetMark(Player i_Player)
        {
            return i_Player.m_PlayerMark;
        }

        public static void AddPoints(Player i_Player)
        {
            i_Player.m_NumberOfPoinf++;
        }

        public static int GetPoints(Player i_Player)
        {
            return i_Player.m_NumberOfPoinf;
        }
    }
}
