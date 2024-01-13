using System;

public class PatchAgeAndPhysical
{
    public static void Run(string[,] ourAnimals, ref string? readResult)
    {
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
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
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
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]}");
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
    }
}