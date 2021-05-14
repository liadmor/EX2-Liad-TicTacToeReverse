using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_EX2
{
    class TicTacToeRevers
    {
        public TicTacToeRevers()
        {
            Game();
        }

        public static void Game()
        {
            
            Console.WriteLine("please enter the board's size (number between 3 to 9)");
            string m_BoardSizeInput = Console.ReadLine();
            int m_BoardSize = Board.IsValidSize(m_BoardSizeInput);
            while(m_BoardSize == -1)
            {
                Console.WriteLine("please enter the board's size (number between 3 to 9)");
                m_BoardSizeInput = Console.ReadLine();
            }

            Console.WriteLine("do you want to play vs. another player? if yes - press p else, press c to play vs. computer");
            string m_playWithInput = Console.ReadLine();
            bool m_PlayWith = Player.IsValidPlayer(m_playWithInput);
            while (!m_PlayWith)
            {
                Console.WriteLine("please enter vs. who you want to play. if with another player - press p. else, press c ");
                m_playWithInput = Console.ReadLine();
                m_PlayWith = Player.IsValidPlayer(m_playWithInput);
            }

            Player m_PlayerX = new Player("p", Cell.eCellMark.Mark_X);
            Player m_PlayerO = new Player(m_playWithInput, Cell.eCellMark.Mark_O);
            Board m_Board = new Board(m_BoardSize);


        }


    }
}
