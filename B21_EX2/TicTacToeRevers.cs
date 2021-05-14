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
            bool m_Game= true;
            bool m_Round = true, m_PlayWithCheck;
            string m_BoardSizeInput, m_playWith;
            int m_BoardSize;
            Player m_PlayerX, m_PlayerO, m_NowPlaying, m_waitingPlayer;
            Board m_Board;



            Console.WriteLine("please enter the board's size (number between 3 to 9)");
            m_BoardSizeInput = Console.ReadLine();
            m_BoardSize = Board.IsValidSize(m_BoardSizeInput);
            while(m_BoardSize == -1)
            {
                Console.WriteLine("please enter the board's size (number between 3 to 9)");
                m_BoardSizeInput = Console.ReadLine();
                m_BoardSize = Board.IsValidSize(m_BoardSizeInput);
            }

            Console.WriteLine("do you want to play vs. another player? if yes - press p else, press c to play vs. computer");
            m_playWith = Console.ReadLine();
            m_PlayWithCheck = Player.IsValidPlayer(m_playWith);
            while (!m_PlayWithCheck)
            {
                Console.WriteLine("please enter vs. who you want to play. if with another player - press p. else, press c ");
                m_playWith = Console.ReadLine();
                m_PlayWithCheck = Player.IsValidPlayer(m_playWith);
            }

            m_PlayerX = new Player("p", Cell.eCellMark.Mark_X);
            m_PlayerO = new Player(m_playWith, Cell.eCellMark.Mark_O);
            m_Board = new Board(m_BoardSize);

            Board.PrintBoard(m_Board);
            m_NowPlaying = m_PlayerX;
            m_waitingPlayer = m_PlayerO;

            while (m_Game)
            {
                string m_AnotherRound;

                while (m_Round)
                {
                    int m_RowNumber, m_ColNumber;
                    string m_RowNumberInput, m_ColNumberInput;
                    Cell m_ValidCell;
                    bool m_ThereIsWinner, m_CheckIfBoardFull;
                    Player m_TempPlayer;

                    if (Player.GetPlayerType(m_NowPlaying) == "p")
                    {
                        Console.WriteLine("Player {0} please enter your selected cell", (char)Player.GetMark(m_NowPlaying));
                        Console.WriteLine("please enter row number (a number between 1 to {0})", m_BoardSize);
                        m_RowNumberInput = Console.ReadLine();
                        m_RowNumber = Cell.IsValidInputRowAndCol(m_RowNumberInput, m_BoardSize);
                        while (m_RowNumber == -1)
                        {
                            if (m_RowNumberInput == "Q")
                            {
                                m_Round = false;
                            }
                            else
                            {
                                Console.WriteLine("please enter row number (a number between 1 to {0})", m_BoardSize);
                                m_RowNumberInput = Console.ReadLine();
                                m_RowNumber = Cell.IsValidInputRowAndCol(m_RowNumberInput, m_BoardSize);
                            }
                        }

                        Console.WriteLine("please enter col number (a number between 1 to {0})", m_BoardSize);
                        m_ColNumberInput = Console.ReadLine();
                        m_ColNumber = Cell.IsValidInputRowAndCol(m_ColNumberInput, m_BoardSize);
                        while (m_ColNumber == -1)
                        {
                            if (m_ColNumberInput == "Q")
                            {
                                m_Round = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("please enter row number (a number between 1 to {0})", m_BoardSize);
                                m_ColNumberInput = Console.ReadLine();
                                m_ColNumber = Cell.IsValidInputRowAndCol(m_ColNumberInput, m_BoardSize);
                            }
                        }
                    }
                    else
                    {
                        Random RndNumber = new Random();
                        m_RowNumber = RndNumber.Next(1, m_BoardSize + 1);
                        m_ColNumber = RndNumber.Next(1, m_BoardSize + 1);
                    }

                    m_ValidCell = Board.GetCellBoard(m_Board, m_RowNumber - 1, m_ColNumber - 1);
                    while (!Cell.IsEmpty(m_ValidCell))
                    {
                        if (Player.GetPlayerType(m_NowPlaying) == "p")
                        {
                            Console.WriteLine("The cell is not avilable");
                        }
                        // repet the num cell process.
                    }

                    Cell.SetCell(m_ValidCell, Player.GetMark(m_NowPlaying));
                    Console.Clear();
                    Board.PrintBoard(m_Board);
                    m_ThereIsWinner = Board.CheckColSequence(m_Board, m_ValidCell) || Board.CheckDiagonalSequence(m_Board, m_ValidCell) || Board.CheckRowSequence(m_Board, m_ValidCell);
                    if (m_ThereIsWinner)
                    {
                        Console.WriteLine("The winner is {0} ", (char)Player.GetMark(m_waitingPlayer));
                        Player.AddPoints(m_waitingPlayer);
                        Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(m_waitingPlayer), Player.GetPoints(m_waitingPlayer));
                        Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(m_NowPlaying), Player.GetPoints(m_NowPlaying));
                        m_Round = false;
                        break;
                    }
                    else
                    {
                        m_CheckIfBoardFull = Board.CheckIfTheBoardIsFull(m_Board);
                        if (m_CheckIfBoardFull)
                        {
                            Console.WriteLine("There is a Tie");
                            Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(m_waitingPlayer), Player.GetPoints(m_waitingPlayer));
                            Console.WriteLine("Player {0} have {1} points ", (char)Player.GetMark(m_NowPlaying), Player.GetPoints(m_NowPlaying));
                            m_Round = false;
                            break;
                        }
                        else
                        {
                            m_TempPlayer = m_waitingPlayer;
                            m_waitingPlayer = m_NowPlaying;
                            m_NowPlaying = m_TempPlayer;
                        }
                    }
                }

                Console.WriteLine("If you want another round please enter Y. else enter N");
                m_AnotherRound = Console.ReadLine();
                if (m_AnotherRound == "Y")
                {
                    m_Board = new Board(m_BoardSize);
                    Board.PrintBoard(m_Board);
                }
                else
                {
                    if (m_AnotherRound == "N")
                    {
                        Console.WriteLine("GAME OVER! hope you like the app");
                        m_Game = false;
                    }
                    else
                    {
                        Console.WriteLine("please enter Y for paly another round and N to Quit the Game");
                        m_AnotherRound = Console.ReadLine();
                    }
                }
            }
        }
    }
}
