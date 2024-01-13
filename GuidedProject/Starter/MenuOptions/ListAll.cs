using System;

public class ListAll
{
    public static void Run(string[,] ourAnimals, ref string? readResult)
    {
        for (int i = 0; i < ourAnimals.GetLength(0); i++)
        {
            if (ourAnimals[i, 0] != "ID #: ")
            {
                Console.WriteLine();
                for (int j = 0; j < ourAnimals.GetLength(1); j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
            }
        }
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
    }
}