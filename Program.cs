using System;

namespace BattleshipME
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WELCOME TO BATTLESHIP"); //heading
            Console.WriteLine(); //space
            int rowLen = 8;
            int colLen = 8;
            //row/columnn length variable can be used in place of single int throughout(value changes only once)
            int shipsLeft = 5; //how many ships are on the board; also value for while loop
            int[,] map = new int[rowLen, colLen]; //2-D array forms grid and sets size of playing board
            map[2, 3] = 1;
            map[5, 4] = 1;
            map[7, 7] = 1;
            map[6, 0] = 1;
            map[1, 2] = 1; //ship placement



            while (shipsLeft > 0)
            //game doesn't end until all the ships are found
            {
                Console.WriteLine($"There are {shipsLeft} ship(s) left!");
                //lets player know how many ships are left
                Console.WriteLine();
                //space

                for (int i = 0; i < rowLen; i++)
                {
                    for (int j = 0; j < colLen; j++)
                    //populates the grid
                    {
                        if (map[i, j] <= 1) //0 is the default value of grid
                        {
                            Console.Write("[~]"); //default square on screen
                        }
                        else if (map[i, j] == 2) //2 is the value of a miss
                        {
                            Console.Write("[O]"); //miss square on screen
                        }
                        else //3 is the value of a hit
                        {
                            Console.Write("[X]"); //hit square on screen
                        }
                    }
                    Console.WriteLine();
                    //sets up the way the grid looks on the screen
                }
                Console.WriteLine();
                Console.WriteLine("Choose a row number.");
                int row;
                bool success1 = int.TryParse(Console.ReadLine(), out row);
                //insures the user input is a number
                Console.WriteLine("Choose a column number.");
                int column;
                bool success2 = int.TryParse(Console.ReadLine(), out column);
                //insures the user input is a number

                if (success1 && success2) //if user inputs numbers
                {
                    row -= 1;
                    column -= 1;
                    //allows user to input 1-8(intuitive values), not 0-7(array values)
                    if (row >= rowLen || row < 0 || column >= colLen || column < 0)
                    //insures user inputs numbers between 1-8
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Entry. Please use numbers between 1 and 8.");
                        //error message 
                    }
                    else if (map[row, column] == 0) //no ship present
                    {
                        Console.WriteLine();
                        Console.WriteLine("Miss! Try again!");
                        map[row, column] = 2;
                        //changes value to allow user to see the miss on screen
                    }
                    else if (map[row, column] == 1) //ship present
                    {
                        Console.WriteLine();
                        Console.WriteLine("HIT!!");
                        map[row, column] = 3;
                        shipsLeft -= 1;
                        //changes value to allow user to see the hit on screen
                        //takes the number of ships down by 1; eventually terminates loop
                    }
                    else //if (map[row, column] == 2 || map[row, column] == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You tried there already! Pick again!");
                        //error message insures user doesn't choose a square they already shose
                    }
                }
                else //if (success1 == false || success2 == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Entry. Please use numbers between 1 and 8.");
                    //error message if input is not an integer
                }

                Console.WriteLine();

            }
            Console.WriteLine("YOU SUNK ALL MY BATTLESHIPS!");
            Console.WriteLine("YOU WIN!");
            //message telling the user they won

        }
    }
}
