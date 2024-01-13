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
            ListAll.Run(ourAnimals, ref readResult);
            break;
        case "2":
            //  Add a new animal friend to the ourAnimals array
            CreateAnimal.Run(
                animalID,
                animalSpecies,
                animalAge,
                animalPhysicalDescription,
                animalPersonalityDescription,
                animalNickname,
                suggestedDonation,
                ourAnimals,
                ref readResult,
                maxPets
            );
            break;
        case "3":
            // Ensure animal ages and physical descriptions are complete
            PatchAgeAndPhysical.Run(ourAnimals, ref readResult);
            break;
        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            PatchNameAndPersonality.Run(ourAnimals, ref readResult);
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
            // search for cat matches with user terms input
            SearchCats.Run(ourAnimals, ref readResult, maxPets);
            break;
        case "8":
            // search for dog matches with user terms input
            SearchDogs.Run(ourAnimals, ref readResult, maxPets);
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
