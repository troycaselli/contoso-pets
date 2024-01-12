// the ourAnimals array will store the following: 
string animalID = "";
string animalSpecies = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalID = "d1";
            animalSpecies = "dog";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalID = "d2";
            animalSpecies = "dog";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalID = "c3";
            animalSpecies = "cat";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalID = "c4";
            animalSpecies = "cat";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        default:
            animalID = "";
            animalSpecies = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }


    if (!decimal.TryParse(suggestedDonation, out decimal decimalDonation))
    {
        decimalDonation = 45.00m;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 4] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 5] = "Nickname: " + animalNickname;
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal personality descriptions and nicknames are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
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
            break;
        case "2":
            //  Add a new animal friend to the ourAnimals array
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

                // store new pet in ourAnimals array
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 4] = "Personality: " + animalPersonalityDescription;
                ourAnimals[petCount, 5] = "Nickname: " + animalNickname;

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
            break;
        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    // check for valid age
                    if (ourAnimals[i, 2] == "Age: ?")
                    {
                        bool validAge = false;
                        do
                        {
                            Console.WriteLine($"Enter an age for ID #: {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                if (int.TryParse(readResult, out int petAge))
                                {
                                    ourAnimals[i, 2] = "Age: " + readResult;
                                    validAge = true;
                                }
                            }
                        } while (validAge == false);

                    }

                    // check for valid physical description
                    if (ourAnimals[i, 3] == "Physical description: ")
                    {
                        bool validPhysicalDesc = false;
                        do
                        {
                            Console.WriteLine($"Enter a physical description for ID #: {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();
                            if (readResult?.Length >= 1)
                            {
                                ourAnimals[i, 3] = "Physical description: " + readResult;
                                validPhysicalDesc = true;
                            }
                        } while (validPhysicalDesc == false);
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            // Ensure animal nicknames and personality descriptions are complete
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
                            Console.WriteLine($"Enter a nickname for ID #: {ourAnimals[i, 0]}");
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
                            Console.WriteLine($"Enter a personality description for ID #: {ourAnimals[i, 0]}");
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
            break;
        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
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
            break;
        case "8":
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
            break;
        case "exit":
            Console.WriteLine("Press the Enter key to exit.");
            readResult = Console.ReadLine();
            break;
        default:
            Console.WriteLine("select a valid option.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
    }

} while (menuSelection != "exit");
