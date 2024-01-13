using System;

public class PatchNameAndPersonality
{
    public static void Run(string[,] ourAnimals, ref string? readResult)
    {
        for (int i = 0; i < ourAnimals.GetLength(0); i++)
        {
            if (ourAnimals[i, 0] != "ID #: ")
            {
                // check for valid nickname
                if (ourAnimals[i, 5] == "Nickname: ")
                {
                    bool validNickname = false;
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult?.Length >= 1)
                        {
                            ourAnimals[i, 5] = "Nickname: " + readResult;
                            validNickname = true;
                        }
                    } while (validNickname == false);
                }

                // check for valid personality description
                if (ourAnimals[i, 4] == "Personality: ")
                {
                    bool validPersonality = false;
                    do
                    {
                        Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult?.Length >= 1)
                        {
                            ourAnimals[i, 4] = "Personality: " + readResult;
                            validPersonality = true;
                        }
                    } while (validPersonality == false);
                }
            }
        }
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
    }
}