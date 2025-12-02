using System;

namespace exampractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rig = true;

            Random random = new Random();
            int Number = random.Next(20, 31);
            int turn;

            if (rig == true)
            {
                if ((Number - 1) % 4 == 0)
                {
                    turn = 0;
                }
                else
                {
                    turn = 1;
                }
            }
            else
            {
                turn = random.Next(0, 2);
            }

            while (Number <= 30)
            {
                Console.WriteLine($"Number = {Number}");

                if (turn % 2 == 0)
                {
                    Number = playerTurn(Number);
                }
                else
                {
                    Number = AITurn(Number, random);
                }
                turn++;
            }

            if (Number == 31)
            {
                Console.WriteLine("AI wins!");
            }
            else
            {
                Console.WriteLine("Player wins!");
            }
        }
        static int playerTurn(int Number)
        {
            int NumRemove;

            while (true)
            {
                Console.WriteLine("How many would you like to remove? (numbers 1 to 3)");
                NumRemove = Convert.ToInt32(Console.ReadLine());
                if (NumRemove > 0 && NumRemove < 4)
                {
                    Number -= NumRemove;
                    return (Number <= 0) ?  31 : Number;
                }
                else
                {
                    Console.WriteLine("Input number between 1 and 3");
                }
            }

        }
        static int AITurn (int Number, Random random)
        {
            int NumRemove = 0;

            for (int index = 2; index < 5; index++)
            {
                if ((Number - index) % 4 == 0)
                {
                    NumRemove = index - 1;
                    break;
                }
                else if (index == 4)
                {
                    NumRemove = random.Next(1, 4);
                }
            }

            Number -= NumRemove;
            Console.WriteLine($"AI removes {NumRemove}");
            return (Number <= 0) ? 32 : Number;
        }
    }
}
