using System;

public class SearchCats
{
    public static void Run(string[,] ourAnimals, ref string? readResult, int maxPets)
    {
        string[] catCharacteristics = { };

        while (catCharacteristics == null || catCharacteristics.Length == 0 || catCharacteristics[0] == "")
        {
            Console.WriteLine($"\nEnter cat characteristics to search for separated by commas");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                catCharacteristics = readResult.ToLower().Split(",");
                for (int i = 0; i < catCharacteristics.Length; i++)
                {
                    catCharacteristics[i] = catCharacteristics[i].Trim();
                }
            }
        }

        bool anyCatMatch = false;
        string[] searchingIcons = { ".  ", ".. ", "..." };

        for (int i = 0; i < maxPets; i++)
        {
            bool catMatch = false;
            if (ourAnimals[i, 1].Contains("cat"))
            {
                string searchString = ourAnimals[i, 3] + " " + ourAnimals[i, 4];
                searchString = searchString.Replace("Physical description: ", "");
                searchString = searchString.Replace("Personality: ", "");
                searchString = searchString.ToLower();
                string[] nickname = ourAnimals[i, 5].Split(" ");

                for (int j = 5; j > -1; j--)
                {
                    foreach (string icon in searchingIcons)
                    {
                        Console.Write($"\rsearching our cat {nickname[1]} for {string.Join(", ", catCharacteristics)} {icon}");
                        Thread.Sleep(200);
                    }

                    Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                }

                for (int j = 0; j < catCharacteristics.Length; j++)
                {
                    if (searchString.Contains(catCharacteristics[j]))
                    {
                        Console.WriteLine($"Our cat {nickname[1]} matches your search for {catCharacteristics[j]}.");
                        anyCatMatch = true;
                        catMatch = true;
                    }
                }
            }

            if (catMatch == true)
            {
                Console.WriteLine($"{ourAnimals[i, 5]} ({ourAnimals[i, 0]})");
                Console.WriteLine($"{ourAnimals[i, 3]}");
                Console.WriteLine($"{ourAnimals[i, 4]}");
            }
        }
        Console.WriteLine();

        if (anyCatMatch == false)
        {
            Console.WriteLine($"None of our cats are a match found for: {string.Join(", ", catCharacteristics)}\n");
        }

        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
    }
}