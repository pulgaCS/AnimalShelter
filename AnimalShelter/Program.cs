string? animalSpecies = default;
string? animalID = default;
string? animalAge = default;
string? animalPhysicalDescription = default;
string? animalPersonalityDescription = default;
string? animalNickname = default;

int nPets = default;
bool newPet = true;
string? menuSelection = default;
string? readResult = default;
int maxPets = 10;



string[,] ourAnimals = new string[maxPets, 6];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalID = "d1";
            animalSpecies = "dog";
            animalAge = "2";
            animalNickname = "lola";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            break;
        case 1:
            animalID = "d2";
            animalSpecies = "dog";
            animalAge = "9";
            animalNickname = "loki";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            break;
        case 2:
            animalID = "c3";
            animalSpecies = "cat";
            animalAge = "1";
            animalNickname = "Puss";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            break;
        case 3:
            animalID = "c4";
            animalSpecies = "cat";
            animalAge = "7";
            animalNickname = "Gato";
            animalPhysicalDescription = "big dark brown male fat. letter box trained.";
            animalPersonalityDescription = "loves to 'meow' at night and sleep during the day";
            break;
        case 4:
            animalID = "c5";
            animalSpecies = "cat";
            animalAge = "6";
            animalNickname = "Luna";
            animalPhysicalDescription = "big white grey female. letter box traned";
            animalPersonalityDescription = "need alot of love and enjoys sleeping with people at night";
            break;
        default:
            animalID = "";
            animalSpecies = "";
            animalAge = "";
            animalNickname = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    Console.Clear();
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and nicknames are complete");
    Console.WriteLine(" 4. Ensure animal physical descriptions and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.Write("Enter your selection number (or type Exit to exit the program) ");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.ReadKey();

    switch (menuSelection)
    {
        case "1":
            //  List all of our current pet information
            Console.Clear();
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                        Console.WriteLine(ourAnimals[i, j]);
                }
            }
            Console.ReadLine();
            break;
        case "2":
            // Add a new animal friend to the ourAnimals array
            do
            {
                Console.Clear();
                int petCount = AnimalCount(maxPets, ourAnimals);

                if (petCount >= maxPets)
                {
                    newPet = false;
                    Console.WriteLine($"Unfortunately, we have reached our capacity of {petCount} out of {maxPets} pets we can take care of.");
                    Console.ReadKey();
                    continue;
                }
                else if (petCount < maxPets)
                    Console.WriteLine($"We have space to accommodate {maxPets - petCount} more pets out of a total capacity of {maxPets}.");

                Console.WriteLine("\nBefore proceeding, provide us with all the necessary information about the animal. ");
                do
                {
                    animalSpecies = TextOutput("Please specify the species of the animal (dog or cat): ", false);           // 1

                    if (animalSpecies != "dog" && animalSpecies != "cat" && animalSpecies != "tbd")
                        Console.WriteLine($"At the moment, we are unable to accommodate {animalSpecies}.");

                } while (animalSpecies != "tbd" && animalSpecies != "dog" && animalSpecies != "cat");

                animalAge = NumberOutput("Please enter the age of the animal (Use '?' for unknown age): ");                 // 2
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1);                                                  // 0
                animalNickname = TextOutput("Please provide a nickname for the animal: ");                                  // 3
                animalPhysicalDescription = TextOutput("Please provide the physical description of the animal: ");          // 4
                animalPersonalityDescription = TextOutput("Please provide a description of the animal's personality: ");    // 5

                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount++;

                Console.WriteLine();
                Console.Write("Would you like to add another animal to the shelter? (y/n): ");
                readResult = Console.ReadLine();
                if (readResult == "n")
                    newPet = false;

            } while (newPet);

            break;
        case "3":
            // Ensure animal nicknames and ages are complete
            for (int i = 0; i < maxPets; i++)
            {
                Console.Clear();

                if (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd")
                {
                    readResult = TextOutput($"{ourAnimals[i, 0]} does not have a nickname. Would you like to assign a nickname to the pet {ourAnimals[i, 0]}? (y/n) ", false);

                    if (readResult == "y" && readResult != "n")
                        ourAnimals[i, 3] = "Nickname: " + TextOutput("What is the nickname of the pet? ", false);
                    else
                        break;
                }

                if (ourAnimals[i, 2] == "Age: " || ourAnimals[i, 2] == "Age: tbd")
                {
                    readResult = TextOutput($"{ourAnimals[i, 0]} does not have an age. Would you like to assign an age to the pet? (y/n) ", false);

                    if (readResult == "y" && readResult != "n")
                        ourAnimals[i, 2] = "Age: " + NumberOutput("What is the age of the pet? ");
                    else
                        break;
                }
            }
            break;
        case "4":
            // Ensure animal physical descriptions  and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                Console.Clear();

                if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                {
                    readResult = TextOutput($"{ourAnimals[i, 0]} does not have a physical descriptions. Would you like to assign a nickname to the pet {ourAnimals[i, 0]}? (y/n) ", false);

                    if (readResult == "y" && readResult != "n")
                        ourAnimals[i, 3] = "Physical description: " + TextOutput("What is the physical descriptions of the pet? ", false);
                    else
                        break;
                }

                if (ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd")
                {
                    readResult = TextOutput($"{ourAnimals[i, 0]} does not have a personality descriptions. Would you like to assign an age to the pet? (y/n) ", false);

                    if (readResult == "y" && readResult != "n")
                        ourAnimals[i, 2] = "Personality: " + TextOutput("What is the personality descriptions of the pet? ", false);
                    else
                        break;
                }
            }

            break;
        case "5":
            //Edit an animal’s age
            while (true)
            {
                Console.Clear();
                readResult = TextOutput("Which animal's ID would you like to change the age of? (Type 'exit' to leave) ", false);

                if (readResult == "exit")
                    break;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "ID #: " + readResult)
                    {
                        ourAnimals[i, 2] = "Age: " + NumberOutput("Please enter the animal's age: ");
                    }
                }
            }
            break;
        case "6":
            //Edit an animal’s personality description

            while (true)
            {
                Console.Clear();
                readResult = TextOutput("Which animal's ID would you like to change the personality description of? (Type 'exit' to leave) ", false);

                if (readResult == "exit")
                    break;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "Personality: " + readResult)
                    {
                        Console.WriteLine($"{ourAnimals[i, 5]}");

                        ourAnimals[i, 5] = "Personality: " + TextOutput("Please enter the animal's personality: ", false);
                    }
                }
            }

            break;
        case "7":
            //  Display all cats with a specified characteristic

            while (true)
            {
                readResult = TextOutput("Specify the characteristic you are looking for in a cat: ", false);
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 1] == "Species: cat")
                    {
                        if (ourAnimals[i, 4].Contains(readResult) || ourAnimals[i, 5].Contains(readResult))
                        {
                            Console.WriteLine($"\n{ourAnimals[i, 0]} matches your description. Please contact support if you are interested in adopting our friend.");
                        }
                    }
                }
            }

            break;
        case "8":
            //  Display all dogs with a specified characteristic

            while (true)
            {
                readResult = TextOutput("Specify the characteristic you are looking for in a dog: ", false);
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 1] == "Species: dog")
                    {
                        if (ourAnimals[i, 4].Contains(readResult) || ourAnimals[i, 5].Contains(readResult))
                        {
                            Console.WriteLine($"\n{ourAnimals[i, 0]} matches your description. Please contact support if you are interested in adopting our friend.");
                        }
                    }
                }
            }

            break;
    }

}
while (menuSelection != "exit");


static string TextOutput(string prompt, bool counterAsk = true)
{
    do
    {
        Console.WriteLine();
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.ToLower();
        }
        while (counterAsk)
        {
            Console.Write("You wish to skip and let it \"tbd\"? (y/n): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input.ToLower() == "y" && input.ToLower() != "n")
                {
                    return "tbd";
                }
                break;
            }
        }
    } while (true);
}

static string NumberOutput(string prompt)
{
    do
    {
        Console.WriteLine();
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (input == "?")
        {
            return input = "tbd";
        }
        else if (int.TryParse(input, out int num))
        {
            return input;
        }

        Console.Write("Invalid number input.");
    }
    while (true);
}

static int AnimalCount(int maxPets, string[,] ourAnimals)
{
    int petCount = 0;
    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] != "ID #: ")
            petCount++;
    }
    return petCount;
}