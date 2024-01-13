using System;

public class SearchDogs
{
    public static void Run(string[,] ourAnimals, ref string? readResult, int maxPets)
    {
        string[] dogCharacteristics = { };

        while (dogCharacteristics == null || dogCharacteristics.Length == 0 || dogCharacteristics[0] == "")
        {
            Console.WriteLine($"\nEnter dog characteristics to search for separated by commas");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                dogCharacteristics = readResult.ToLower().Split(",");
                for (int i = 0; i < dogCharacteristics.Length; i++)
                {
                    dogCharacteristics[i] = dogCharacteristics[i].Trim();
                }
            }
        }

        bool anyDogMatch = false;
        string[] searchingDogIcons = { ".  ", ".. ", "..." };

        for (int i = 0; i < maxPets; i++)
        {
            bool dogMatch = false;
            if (ourAnimals[i, 1].Contains("dog"))
            {
                string searchString = ourAnimals[i, 3] + " " + ourAnimals[i, 4];
                searchString = searchString.Replace("Physical description: ", "");
                searchString = searchString.Replace("Personality: ", "");
                searchString = searchString.ToLower();
                string[] nickname = ourAnimals[i, 5].Split(" ");

                for (int j = 2; j > -1; j--)
                {
                    foreach (string icon in searchingDogIcons)
                    {
                        Console.Write($"\rsearching our dog {nickname[1]} for {string.Join(", ", dogCharacteristics)} {icon}");
                        Thread.Sleep(200);
                    }

                    Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                }

                for (int j = 0; j < dogCharacteristics.Length; j++)
                {
                    if (searchString.Contains(dogCharacteristics[j]))
                    {
                        Console.WriteLine($"Our dog {nickname[1]} matches your search for {dogCharacteristics[j]}.");
                        anyDogMatch = true;
                        dogMatch = true;
                    }
                }
            }

            if (dogMatch == true)
            {
                Console.WriteLine($"{ourAnimals[i, 5]} ({ourAnimals[i, 0]})");
                Console.WriteLine($"{ourAnimals[i, 3]}");
                Console.WriteLine($"{ourAnimals[i, 4]}");
            }
        }
        Console.WriteLine();

        if (anyDogMatch == false)
        {
            Console.WriteLine($"None of our dogs are a match found for: {string.Join(", ", dogCharacteristics)}\n");
        }

        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
    }
}