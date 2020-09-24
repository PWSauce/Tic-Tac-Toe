using System;
using System.Linq;

namespace Tic_Tac_Toe
{
    class Program
    {
        static readonly char[,] board = new char[,] { { '-', '-', '-', },
                                                      { '-', '-', '-', },
                                                      { '-', '-', '-', } };
        static char playerID;

        static void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //starts game
            Console.WriteLine("Player 1 = x   Player 2 = o \n");
            int flag = 0;
            for (int player = 0; flag != 1 || flag != -1; player = (player+1) % 2)
            {
                if (player == 0)
                {
                    playerID = 'x';
                }
                else
                {
                    playerID = 'o';
                }
                PrintBoard();
                //takes input from the players
                Console.WriteLine($"Choose column and then row.   Player {(player % 2) + 1} turn");
                string[] inputstr = Console.ReadLine().Split(' ');
                int[] input = Array.ConvertAll(inputstr, int.Parse);
                input[1]--;
                input[0]--;


                //takes input and puts an x or o on the board
                if (board[input[1], input[0]] == '-')
                {
                    board[input[1], input[0]] = playerID;
                }
                else
                {
                    Console.WriteLine("Already taken, shame on you");
                }
                flag = CheckWin();
            }
            if (flag == 1)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Player " + (player + 1) + " has won");
            }
            else if (flag == -1)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Draw");
            }
        }

        static int CheckWin()
        {
            //checks win for player 2
            if (board[0, 0] == playerID && board[0, 1] == playerID && board[0, 2] == playerID)
                return 1;
            else if (board[1, 0] == playerID && board[1, 1] == playerID && board[1, 2] == playerID)
                return 1;
            else if (board[2, 0] == playerID && board[2, 1] == playerID && board[2, 2] == playerID)
                return 1;
            else if (board[0, 0] == playerID && board[1, 1] == playerID && board[2, 2] == playerID)
                return 1;
            else if (board[2, 0] == playerID && board[1, 1] == playerID && board[0, 2] == playerID)
                return 1;
            else if (board[0, 1] == playerID && board[1, 1] == playerID && board[2, 1] == playerID)
                return 1;
          else if (board.Cast<char>().Any(c => c == '-'))
                return -1;
            else
                return 0;

        }

    }
}
