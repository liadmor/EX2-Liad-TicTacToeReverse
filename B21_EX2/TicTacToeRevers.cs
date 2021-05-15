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

        public static string AskAsixNumber(int m_boardSize, string m_whichAxis, Player i_NowPlaying)
        {
            Console.WriteLine("Player {0} please enter {1} number (a number between 1 to {2})", (char)Player.GetMark(i_NowPlaying), m_whichAxis, m_boardSize);
            string m_RowNumberInput = Console.ReadLine();
            return m_RowNumberInput;
        }

        public static Cell FindCell(Player i_NowPlaying, Board i_Board)
        {
            int m_RowNumber, m_ColNumber, m_BoardSize;
            Cell m_ValidCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);

            m_BoardSize = Board.GetBoardSize(i_Board);
            if (Player.GetPlayerType(i_NowPlaying) == "p")
            {
                m_RowNumber = Board.TempFindAxis(m_BoardSize, "row", i_NowPlaying);
                if (m_RowNumber == -1)
                {
                    m_ValidCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);
                }
                else
                {
                    m_ColNumber = Board.TempFindAxis(m_BoardSize, "col", i_NowPlaying);
                    if (m_ColNumber == -1)
                    {
                        m_ValidCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);
                    }
                    else
                    {
                        m_ValidCell = Board.GetCellBoard(i_Board, m_RowNumber - 1, m_ColNumber - 1);
                    }
                }
            }
            else
            {
                Random RndNumber = new Random();
                m_RowNumber = RndNumber.Next(1, m_BoardSize + 1);
                m_ColNumber = RndNumber.Next(1, m_BoardSize + 1);
                m_ValidCell = Board.GetCellBoard(i_Board, m_RowNumber - 1, m_ColNumber - 1);
            }

            return m_ValidCell;
        }

        public static bool AskForAnotherRound(ref Board i_Board)
        {
            bool AnotherRound = false;

            Console.WriteLine("If you want another round please enter Y. else enter N");
            string m_AnotherRound = Console.ReadLine();
            if (m_AnotherRound == "Y")
            {
                i_Board = new Board(Board.GetBoardSize(i_Board));
                Board.PrintBoard(i_Board);
                AnotherRound = true;
            }
            else
            {
                if (m_AnotherRound == "N")
                {
                    Console.WriteLine("GAME OVER! hope you like the app");
                    AnotherRound = false;
                }
                else
                {
                    Console.WriteLine("please enter Y for paly another round and N to Quit the Game");
                    m_AnotherRound = Console.ReadLine();
                }
            }

            return AnotherRound;
        }

        public static void PrintStatusRound(string i_StatusRound, Player i_NowPlaying, Player i_waitingPlayer)
        {
            if (i_StatusRound == "win")
            {
                Console.WriteLine("The winner is {0} ", (char)Player.GetMark(i_waitingPlayer));
                Player.AddPoints(i_waitingPlayer);
                Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(i_waitingPlayer), Player.GetPoints(i_waitingPlayer));
                Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(i_NowPlaying), Player.GetPoints(i_NowPlaying));
            }
            else
            {
                Console.WriteLine("There is a Tie");
                Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(i_waitingPlayer), Player.GetPoints(i_waitingPlayer));
                Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(i_NowPlaying), Player.GetPoints(i_NowPlaying));
            }
            

        }

        public static int AskForBoardSize()
        {
            int BoardSize;
            string m_BoardSizeInput;

            Console.WriteLine("please enter the board's size (number between 3 to 9)");
            m_BoardSizeInput = Console.ReadLine();
            BoardSize = Board.IsValidSize(m_BoardSizeInput);
            while (BoardSize == -1)
            {
                Console.WriteLine("please enter the board's size (number between 3 to 9)");
                m_BoardSizeInput = Console.ReadLine();
                BoardSize = Board.IsValidSize(m_BoardSizeInput);
            }

            return BoardSize;
        }

        public static string AskWhoToPlayWith()
        {
            string PlayWith;
            bool CheckInput;

            Console.WriteLine("do you want to play vs. another player? if yes - press p else, press c to play vs. computer");
            PlayWith = Console.ReadLine();
            CheckInput = Player.IsValidPlayer(PlayWith);
            while (!CheckInput)
            {
                Console.WriteLine("please enter vs. who you want to play. if with another player - press p. else, press c ");
                PlayWith = Console.ReadLine();
                CheckInput = Player.IsValidPlayer(PlayWith);
            }

            return PlayWith;
        }
        public static void Game()
        {
            bool m_Game = true, m_Round = true;
            string m_playWith;
            int m_BoardSize;
            Player m_PlayerX, m_PlayerO, m_NowPlaying, m_waitingPlayer;
            Board m_Board;

            m_BoardSize = AskForBoardSize();
            m_playWith = AskWhoToPlayWith();
            m_PlayerX = new Player("p", Cell.eCellMark.Mark_X);
            m_PlayerO = new Player(m_playWith, Cell.eCellMark.Mark_O);
            m_Board = new Board(m_BoardSize);
            Board.PrintBoard(m_Board);
            m_NowPlaying = m_PlayerX;
            m_waitingPlayer = m_PlayerO;
            while (m_Game)
            {
                while (m_Round)
                {
                    Cell m_ValidCell;
                    bool m_ThereIsWinner, m_CheckIfBoardFull;

                    m_ValidCell = Cell.FindValidCell(m_NowPlaying, m_Board);
                    if ((Cell.GetCol(m_ValidCell) == -1) && (Cell.GetRow(m_ValidCell) == -1))
                    {
                        m_Round = false;
                        break;
                    }

                    Cell.SetCell(m_ValidCell, Player.GetMark(m_NowPlaying));
                    Console.Clear();
                    Board.PrintBoard(m_Board);
                    m_ThereIsWinner = Board.ThereIsWinner(m_Board, m_ValidCell); 
                    if (m_ThereIsWinner)
                    {
                        PrintStatusRound("win", m_NowPlaying, m_waitingPlayer);
                        m_Round = false;
                        break;
                    }
                    else
                    {
                        m_CheckIfBoardFull = Board.CheckIfTheBoardIsFull(m_Board);
                        if (m_CheckIfBoardFull)
                        {
                            PrintStatusRound("tie", m_NowPlaying, m_waitingPlayer);
                            m_Round = false;
                            break;
                        }
                        else
                        {
                            Player.ChengePlayer(ref m_waitingPlayer, ref m_NowPlaying);
                        }
                    }
                }

                if (AskForAnotherRound(ref m_Board))
                {
                    m_Round = true;
                }
                else
                {
                    m_Game = false;
                }
            }
        }
    }
}