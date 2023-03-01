using System;

class Program
{

    static int HareMove(Random rnd)
    {

        int n = rnd.Next(1, 10);
        if (n <= 2) return 0; // sleep
        else if (n <= 4) return 9; // large hop
        else if (n <= 5) return -12; // large slip
        else if (n <= 8) return 1; // small hop
        else return -2; // small slip

    }
    static int TortoiseMove(Random rnd)
    {

        int n = rnd.Next(1, 10);
        if (n <= 5) return 3; // dash
        else if (n <= 7) return -6; // slip
        else return 1; // walk

    }

    static void Main(string[] args)
    {
        const int WINNING_MARK = 70;
        Random random = new Random();
        int harePosition = 1;
        int tortoisePosition = 1;

        while (harePosition < WINNING_MARK && tortoisePosition < WINNING_MARK)
        {
            harePosition += TortoiseMove(random);
            tortoisePosition += TortoiseMove(random);
            if (harePosition < 0) harePosition = 1;
            if (harePosition > WINNING_MARK) harePosition = WINNING_MARK;

            if (tortoisePosition < 0) tortoisePosition = 1;
            if (tortoisePosition > WINNING_MARK) tortoisePosition = WINNING_MARK;
            for (int pos = 1; pos <= WINNING_MARK; pos++)
            {
                if (pos == harePosition)
                    Console.Write("H");
                else
                    Console.Write("-");
            }
            Console.WriteLine("\n");
            for (int pos = 1; pos <= WINNING_MARK; pos++)
            {
                if (pos == tortoisePosition)
                    Console.Write("T");
                else
                    Console.Write("-");
            }
            Console.WriteLine("\n\n");


        }
        if (harePosition > tortoisePosition)
            Console.WriteLine("Hare is the winner!");
        else
            Console.WriteLine("Tortoise is the winner!");


    }
}