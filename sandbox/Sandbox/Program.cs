using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //function to display the correct symbol on the board
    static char CharDisplay(int index, List<int> board)
    {
        //Use Switch case/ Match case to returnt the proper Char
        switch (board[index])
        {
            case 0:
                return ' ';
            case 1:
                return 'X';
            case 2:
                return 'O';
            default:
                return ' ';
        }
    }
    static Tuple<bool, int> LookForWinningMoves(List<int> board)
 {
     List<List<int>> winningMoves = new List<List<int>> { new List<int> { 0, 1, 2 }, new List<int> { 3, 4, 5 }, new List<int> { 6, 7, 8 }, new List<int> { 0, 3, 6 }, new List<int> { 1, 4, 7 }, new List<int> { 2, 5, 8 }, new List<int> {0, 4, 8 }, new List<int> { 2, 4, 6 } };
     // iterate through winningMoves and check if any of the winning moves are on the board
     foreach (List<int> list in winningMoves)
     {
         int numOs = 0; // Number of '2's (Os)
         int numEmpty = 0; // Number of '0's (empty)
         int emptySpot = -1; // Initialize emptySpot to an invalid index

         foreach (int spot in list)
         {
             if (board[spot] == 2) numOs++;
             else if (board[spot] == 0)
             {
                 numEmpty++;
                 emptySpot = spot;
             }
         }

         if (numOs == 2 && numEmpty == 1)
         {
             // We found a winning move: two '2's (Os) and one '0' (empty)
             return Tuple.Create(true, emptySpot);
         }
     }

     // No winning move was found
     return Tuple.Create(false, -1);
 } 
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.WriteLine("I have changed this file!");

        // Initialize the Tic Tac Toe board
        List<int> board = new List<int> {0,0,0,0,0,0,0,0,0};
        // Initialize the game state
        bool turn = true;
        const int X = 1;
        const int O = 2;
        void DisplayBoard()
        {
            Console.WriteLine($"{CharDisplay(0, board)} | {CharDisplay(1, board)} | {CharDisplay(2, board)}\n---------\n{CharDisplay(3, board)} | {CharDisplay(4, board)} | {CharDisplay(5, board)}\n---------\n{CharDisplay(6, board)} | {CharDisplay(7, board)} | {CharDisplay(8, board)}");
        }
        bool CheckWin()
        {
            List<List<int>> winningMoves = new List<List<int>>
            {
                new() { 0, 1, 2 },
                new() { 3, 4, 5 },
                new() { 6, 7, 8 },
                new() { 0, 3, 6 },
                new() { 1, 4, 7 },
                new() { 2, 5, 8 },
                new() { 0, 4, 8 },
                new() { 2, 4, 6 }
            };            
            // iterate through winningMoves and check if any of the winning moves are on the board
            foreach (List<int> list in winningMoves)
            {
                int numOs = 0; // Number of '2's (Os)
                int numXs = 0; // Number of '1's (Xs)

            foreach (int spot in list)
            {
                if (board[spot] == 2) numOs++;
                else if (board[spot] == 1) numXs++;
            }

            if (numOs == 3 | numXs == 3)
            {
                // We found a winning move: three '2's (Os) or three '1's (Xs)
                return true;
            }
            }
            return false;
        }
        


    
        // Game loop
        Console.WriteLine("Welcome to Tic Tac Toe!");
        Console.WriteLine("Player 1 is X, Player 2 is O");
        while (CheckWin() == false)
        {
            System.Console.WriteLine($"Win state: {CheckWin()}");
            while (turn == true)
            {
                DisplayBoard();
                // Ask user for input
                Console.WriteLine("Player 1, please enter a number between 1 and 9");
                int input = Convert.ToInt32(Console.ReadLine());
                // Check if input is valid
                if (input.GetType() == typeof(int) && input > 0 && input < 10)
                {
                    // Check if space is available
                    if (board[input - 1] == 0)
                    {
                        // Place X on board
                        board[input - 1] = X;
                        // Switch turn
                        turn = false;
                    }
                    else
                    {
                        Console.WriteLine("That space is already taken!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number!");
                }

            }
            while (turn == false && CheckWin() == false)
            {
                if (LookForWinningMoves(board).Item1 == false)
                {
                    Random rand = new Random();
                    int randBotMove = rand.Next(0, 9);
                    if (board[randBotMove] == 0)
                    {
                        board[randBotMove] = O;
                        DisplayBoard();
                        turn = true;
                    }
                }
                else
                {
                    board[LookForWinningMoves(board).Item2] = O;
                    DisplayBoard();
                    turn = true;
                }
            }
        }
        DisplayBoard();
        System.Console.WriteLine("Game Over!");
    }
}