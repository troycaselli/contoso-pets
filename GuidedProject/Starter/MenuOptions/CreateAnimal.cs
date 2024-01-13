using System;

public class CreateAnimal
{
    public static void Run(
        string animalID,
        string animalSpecies,
        string animalAge,
        string animalPhysicalDescription,
        string animalPersonalityDescription,
        string animalNickname,
        string suggestedDonation,
        string[,] ourAnimals,
        ref string? readResult,
        int maxPets
    )
    {
        string anotherPet = "y";
        int petCount = 0;
        for (int i = 0; i < ourAnimals.GetLength(0); i++)
        {
            if (ourAnimals[i, 0] != "ID #: ")
            {
                petCount++;
            }
        }

        if (petCount < maxPets)
        {
            Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
        }

        while (anotherPet == "y" && petCount < maxPets)
        {
            petCount++;

            // add a new pet
            bool validEntry = false;
            // pet species
            do
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies == "dog" || animalSpecies == "cat")
                        validEntry = true;
                }
            } while (validEntry == false);

            // pet ID
            animalID = $"{animalSpecies[0]}{petCount}";

            // pet age
            do
            {
                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult;
                }
                if (animalAge != "?")
                {
                    validEntry = int.TryParse(animalAge, out int petAge);
                }
                else
                {
                    validEntry = true;
                }
            } while (validEntry == false);

            // pet physical description
            do
            {
                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                }
                if (animalPhysicalDescription == "")
                {
                    animalPhysicalDescription = "tbd";
                }
            } while (animalPhysicalDescription == "");

            // pet personality description
            do
            {
                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPersonalityDescription = readResult.ToLower();
                }
                if (animalPersonalityDescription == "")
                {
                    animalPersonalityDescription = "tbd";
                }
            } while (animalPersonalityDescription == "");

            // pet nickname
            do
            {
                Console.WriteLine("Enter a nickname for the pet");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();
                }
                if (animalNickname == "")
                {
                    animalNickname = "tbd";
                }
            } while (animalNickname == "");

            // suggested donation
            decimal decimalDonation = 45.00m;
            do
            {
                Console.WriteLine("Enter the suggested donation for this pet");
                readResult = Console.ReadLine();
                if (readResult == null || readResult == "")
                {
                    validEntry = true;
                }
                else if (decimal.TryParse(readResult, out decimalDonation))
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine("Invalid donation value.");
                    validEntry = false;
                    decimalDonation = 45.00m;
                }
            } while (validEntry == false);

            // store new pet in ourAnimals array
            ourAnimals[petCount, 0] = "ID #: " + animalID;
            ourAnimals[petCount, 1] = "Species: " + animalSpecies;
            ourAnimals[petCount, 2] = "Age: " + animalAge;
            ourAnimals[petCount, 3] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[petCount, 4] = "Personality: " + animalPersonalityDescription;
            ourAnimals[petCount, 5] = "Nickname: " + animalNickname;
            ourAnimals[petCount, 6] = $"Suggested Donation: {decimalDonation:C2}";

            // ask if user wants to add another pet
            if (petCount < maxPets)
            {
                Console.WriteLine("Do you want to enter info for another pet (y/n)");
                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        anotherPet = readResult.ToLower();
                    }
                } while (anotherPet != "y" && anotherPet != "n");
            }
        }

        // final notice output
        if (petCount >= maxPets)
        {
            Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}