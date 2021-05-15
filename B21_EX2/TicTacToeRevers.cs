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
            game();
        }

        public static string AskAxisNumber(int i_BoardSize, string i_WhichAxis, Player i_NowPlaying)
        {
            string rowNumberInput;

            Console.WriteLine("Player {0} please enter {1} number (a number between 1 to {2})", (char)Player.GetMark(i_NowPlaying), i_WhichAxis, i_BoardSize);
            rowNumberInput = Console.ReadLine();

            return rowNumberInput;
        }

        public static Cell FindCell(Player i_NowPlaying, Board i_Board)
        {
            int rowNumber, colNumber, boardSize;
            Cell validCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);

            boardSize = Board.GetBoardSize(i_Board);
            if (Player.GetPlayerType(i_NowPlaying) == "p")
            {
                rowNumber = Board.FindNumberAxis(boardSize, "row", i_NowPlaying);
                if (rowNumber == -1)
                {
                    validCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);
                }
                else
                {
                    colNumber = Board.FindNumberAxis(boardSize, "col", i_NowPlaying);
                    if (colNumber == -1)
                    {
                        validCell = new Cell(-1, -1, Cell.eCellMark.Mark_Empty);
                    }
                    else
                    {
                        validCell = Board.GetCellBoard(i_Board, rowNumber - 1, colNumber - 1);
                    }
                }
            }
            else
            {
                Random RndNumber = new Random();
                rowNumber = RndNumber.Next(1, boardSize + 1);
                colNumber = RndNumber.Next(1, boardSize + 1);
                validCell = Board.GetCellBoard(i_Board, rowNumber - 1, colNumber - 1);
            }

            return validCell;
        }

        private static bool askForAnotherRound(ref Board io_Board)
        {
            bool anotherRound = false;
            string wantAnotherRound;

            Console.WriteLine("If you want another round please enter Y. else enter N");
            wantAnotherRound = Console.ReadLine();
            if (wantAnotherRound == "Y")
            {
                io_Board = new Board(Board.GetBoardSize(io_Board));
                Board.PrintBoard(io_Board);
                anotherRound = true;
            }
            else
            {
                if (wantAnotherRound == "N")
                {
                    Console.WriteLine("GAME OVER! hope you like the app");
                    anotherRound = false;
                }
                else
                {
                    Console.WriteLine("please enter Y for paly another round and N to Quit the Game");
                    wantAnotherRound = Console.ReadLine();
                }
            }

            return anotherRound;
        }

        private static void printStatusRound(string i_StatusRound, Player i_NowPlaying, Player i_waitingPlayer)
        {
            StringBuilder statusRound = new StringBuilder();

            if (i_StatusRound == "win")
            {
                statusRound.AppendFormat("The winner is {0} ", (char)Player.GetMark(i_waitingPlayer));
                statusRound.Append(Environment.NewLine);
                Player.AddPoints(i_waitingPlayer);
                statusRound.AppendFormat("Player {0} have {1} points ", (char)Player.GetMark(i_waitingPlayer), Player.GetPoints(i_waitingPlayer));
                statusRound.Append(Environment.NewLine);
                statusRound.AppendFormat("Player {0} have {1} points ", (char)Player.GetMark(i_NowPlaying), Player.GetPoints(i_NowPlaying));
                
            }
            else
            {
                statusRound.Append("There is a Tie");
                statusRound.Append(Environment.NewLine);
                statusRound.AppendFormat("Player {0} have {1} points ", (char)Player.GetMark(i_waitingPlayer), Player.GetPoints(i_waitingPlayer));
                statusRound.Append(Environment.NewLine);
                statusRound.AppendFormat("Player {0} have {1} points ", (char)Player.GetMark(i_NowPlaying), Player.GetPoints(i_NowPlaying));
            }

            Console.WriteLine(statusRound);
        }

        private static int askForBoardSize()
        {
            int boardSize;
            string boardSizeInput;

            Console.WriteLine("please enter the board's size (number between 3 to 9)");
            boardSizeInput = Console.ReadLine();
            boardSize = Board.IsValidSize(boardSizeInput);
            while (boardSize == -1)
            {
                Console.WriteLine("please enter the board's size (number between 3 to 9)");
                boardSizeInput = Console.ReadLine();
                boardSize = Board.IsValidSize(boardSizeInput);
            }

            return boardSize;
        }

        private static string askWhoToPlayWith()
        {
            string playWith;
            bool checkInput;

            Console.WriteLine("do you want to play vs. another player? if yes - press p else, press c to play vs. computer");
            playWith = Console.ReadLine();
            checkInput = Player.IsValidPlayer(playWith);
            while (!checkInput)
            {
                Console.WriteLine("please enter vs. who you want to play. if with another player - press p. else, press c ");
                playWith = Console.ReadLine();
                checkInput = Player.IsValidPlayer(playWith);
            }

            return playWith;
        }

        private static void game()
        {
            bool game = true, round = true;
            string playWith;
            int boardSize;
            Player playerX, playerO, nowPlaying, waitingPlayer;
            Board board;

            boardSize = askForBoardSize();
            playWith = askWhoToPlayWith();
            playerX = new Player("p", Cell.eCellMark.Mark_X);
            playerO = new Player(playWith, Cell.eCellMark.Mark_O);
            board = new Board(boardSize);
            Board.PrintBoard(board);
            nowPlaying = playerX;
            waitingPlayer = playerO;
            while (game)
            {
                while (round)
                {
                    Cell validCell;
                    bool thereIsWinner, checkIfBoardFull;

                    validCell = Cell.FindValidCell(nowPlaying, board);
                    if ((Cell.GetCol(validCell) == -1) && (Cell.GetRow(validCell) == -1))
                    {
                        round = false;
                        break;
                    }

                    Cell.SetCell(validCell, Player.GetMark(nowPlaying));
                    Console.Clear();
                    Board.PrintBoard(board);
                    thereIsWinner = Board.ThereIsWinner(board, validCell); 
                    if (thereIsWinner)
                    {
                        printStatusRound("win", nowPlaying, waitingPlayer);
                        round = false;
                        break;
                    }
                    else
                    {
                        checkIfBoardFull = Board.CheckIfTheBoardIsFull(board);
                        if (checkIfBoardFull)
                        {
                            printStatusRound("tie", nowPlaying, waitingPlayer);
                            round = false;
                            break;
                        }
                        else
                        {
                            Player.ChengePlayers(ref waitingPlayer, ref nowPlaying);
                        }
                    }
                }

                if (askForAnotherRound(ref board))
                {
                    round = true;
                }
                else
                {
                    game = false;
                }
            }
        }
    }
}