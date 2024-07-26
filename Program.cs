using System;
using System.Security.Cryptography.X509Certificates;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        //global 2D array
        static char[,] playField =
        {
            {'1','2','3'},//row 0
            {'4','5','6'},//row 1
            {'7','8','9'},//row 2
        };
        static int turns = 0;

    static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = false;    
            do
            {
                if (player == 2)
                {
                    player = 1;
                    enterXorO(player,input);
                }
                else if (player == 1)
                {
                    player = 2;
                    enterXorO(player,input);
                }
                setField();

                //checking winning condition
                char[] playerChar = { 'O', 'X' };
                foreach(char playerChars in playerChar )
                {
                    if (((playField[0, 0] == playerChars) && (playField[0,1]==playerChars) && (playField[0,2]==playerChars) 
                        || (playField[1, 0] == playerChars) && (playField[1, 1] == playerChars) && (playField[1, 2] == playerChars)
                        || (playField[2, 0] == playerChars) && (playField[2, 1] == playerChars) && (playField[2, 2] == playerChars)
                        || (playField[0, 0] == playerChars) && (playField[1, 1] == playerChars) && (playField[2, 2] == playerChars)
                        || (playField[0, 2] == playerChars) && (playField[1, 1] == playerChars) && (playField[2, 0] == playerChars)
                        || (playField[0, 0] == playerChars) && (playField[1, 0] == playerChars) && (playField[2, 0] == playerChars)
                        || (playField[0, 1] == playerChars) && (playField[1, 1] == playerChars) && (playField[2, 1] == playerChars)
                        || (playField[0, 2] == playerChars) && (playField[1, 2] == playerChars) && (playField[2, 2] == playerChars)))
                    {
                        if(playerChars == 'X')
                        {
                            Console.WriteLine("Player 2 is a ***WINNER***");
                        }
                        else
                        {
                            Console.WriteLine("player 1 is a ***WINNER***");
                        }
                        //Resetting Field
                        Console.WriteLine("*** Press Any Key To Play Again ***");
                        Console.ReadKey();
                        resetField();
                        break;
                    }
                    else if(turns == 10)
                    {
                        Console.WriteLine("*** --DRAW-- ***");
                        Console.WriteLine("*** Press Any Key To Play Again ***");
                        Console.ReadKey();
                        resetField();
                        break;
                    }
                    

                }

                do
                {
                    Console.Write("\n Player {0} : choose your field : ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }catch{
                        Console.WriteLine("Please enter a valid number !");
                    }
                    if ((input == 1) && (playField[0, 0] == '1')) inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2')) inputCorrect = true;
                    else if((input == 3) && (playField[0, 2] == '3')) inputCorrect = true;
                    else if((input == 4) && (playField[1, 0] == '4')) inputCorrect = true;
                    else if((input == 5) && (playField[1, 1] == '5')) inputCorrect = true;
                    else if((input == 6) && (playField[1, 2] == '6')) inputCorrect = true;
                    else if((input == 7) && (playField[2, 0] == '7')) inputCorrect = true;
                    else if((input == 8) && (playField[2, 1] == '8')) inputCorrect = true;
                    else if((input == 9) && (playField[2, 2] == '9')) inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n incorrect input please choose another field");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
            }
            while (true);
        }

        public static void resetField()
        {
            char[,] playFieldReset =
        {
            {'1','2','3'},//row 0
            {'4','5','6'},//row 1
            {'7','8','9'},//row 2
        };
            playField = playFieldReset;
            setField();
            turns = 0;
        }
        public static void setField()
        {
            Console.Clear();
            Console.WriteLine("_________________");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____"); Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("_________________");
            turns++;
        }
        public static void enterXorO(int player, int input)
        {
            
            char playerSign = ' ';
            if(player == 1)
            {
                playerSign = 'X';
                
            }
            else if(player == 2)
            {
                playerSign = 'O';
                

            }
            switch (input)
            {
                
                case 1:
                    playField[0, 0] = playerSign; break;
                case 2:
                    playField[0, 1] = playerSign; break;
                case 3:
                    playField[0, 2] = playerSign; break;
                case 4:
                    playField[1, 0] = playerSign; break;
                case 5:
                    playField[1, 1] = playerSign; break;
                case 6:
                    playField[1, 2] = playerSign; break;
                case 7:
                    playField[2, 0] = playerSign; break;
                case 8:
                    playField[2, 1] = playerSign; break;
                case 9:
                    playField[2, 2] = playerSign; break;
            }
        }
    } 
}
