using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class Program
    {
        static int _turnCount = 1;
        static int[] gameBoard = new int[9];
        static int playerThatWon = 0;
        static void Main(string[] args)
        {

            //display gameboard
            gameBoard[0] = 0;
            gameBoard[1] = 0;
            gameBoard[2] = 0;
            gameBoard[3] = 0;
            gameBoard[4] = 0;
            gameBoard[5] = 0;
            gameBoard[6] = 0;
            gameBoard[7] = 0;
            gameBoard[8] = 0;

            int playerOne;
            int playerTwo;           

            //creat list

            List<int> selected = new List<int>();
            displayGameBoard();
            while (whoWon() == 0)
            {                
                Console.WriteLine("player one, enter a number from 0-8: ");
                playerOne = int.Parse(Console.ReadLine());
              
                if (selected.Contains(playerOne))
                {
                    bool validSelection = false;
                    while (!validSelection)
                    {
                        Console.WriteLine("this spot is taken. try agin!");
                        playerOne = int.Parse(Console.ReadLine());
                        if (!selected.Contains(playerOne)) validSelection = true;
                    }
                }
                Console.WriteLine("you chose " + playerOne);

                gameBoard[playerOne] = 1;
                selected.Add(playerOne);
                if (whoWon() == 1)
                {

                    playerThatWon = 1;
                    break;
                }
                _turnCount++;
                displayGameBoard();

                //compTurn = randy.Next(8);
                Console.WriteLine("player two enter a number from 0-8: ");
                playerTwo = int.Parse(Console.ReadLine());
                if (selected.Contains(playerTwo))
                {
                    bool validSelection = false;
                    while (!validSelection)
                    {
                        Console.WriteLine("this spot is taken. try agin!");
                        playerTwo = int.Parse(Console.ReadLine());
                        if (!selected.Contains(playerTwo)) validSelection = true;
                    }
                }
                gameBoard[playerTwo] = 2;
                selected.Add(playerTwo);
                Console.WriteLine("player Two chose " + playerTwo);
                if (whoWon() == 2)
                {
                    playerThatWon = 2;
                    break;

                }
                _turnCount++;

                displayGameBoard();
                
            }
            displayGameBoard();
            if (playerThatWon == 1 || playerThatWon == 2)
            {
                Console.WriteLine("Player " + playerThatWon + " is the winner!\n press enter to end");
            }
            else
            {
                Console.WriteLine("their was no winner\n press enter to end");
            }
            Console.ReadLine();

        }
        private static void displayGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {//mark x or o for each player
             //0 is empty, player 1 =1, player 2= 2
                if (gameBoard[i] == 0)
                {
                    Console.Write("[]");
                }
                if (gameBoard[i] == 1)
                {
                    Console.Write("X");
                }
                if (gameBoard[i] == 2)
                {
                    Console.Write("O");
                }
                //print a line every 3rd char
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }

        }    


        private static int whoWon()
        {
            // return 0 if no winner. return player number if they won.
            // top row
            if (gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2])
            {
                return gameBoard[0];
            }
            // middle
            if (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5])
            {
                return gameBoard[3];
            }
            // bodum 
            if (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8])
            {
                return gameBoard[6];
            }
            // left column
            if (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6])
            {
                return gameBoard[0];
            }
            // center
            if (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7])
            {
                return gameBoard[1];
            }
            // right
            if (gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8])
            {
                return gameBoard[2];
            }
            //left to right diagonal
            if (gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8])
            {
                return gameBoard[1];
            }
            //right to left diagonal
            if (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6])
            {
                return gameBoard[2];
            }
            if(_turnCount == 9)
            {
                return 3;
            }       
            return 0;

        }
    }

}





