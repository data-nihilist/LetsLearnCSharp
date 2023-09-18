//                                  Contoso Petting Zoo

// There are currently three visiting schools
    // School A has six visiting groups (the default number)
    // School B has three visiting groups
    // School C has two visiting groups

// For each visiting school, perform the following tasks
    // Randomize the animals
    // Assign the animals to the correct number of groups
    // Print the school name
    // Print the animal groups

//---------------------------------------------------------provided code

string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

PlanSchoolVisit("SchoolA");
PlanSchoolVisit("School A", 3);
PlanSchoolVisit("School C", 2);

void PlanSchoolVisit(string schoolName, int groups = 6)
{
    Console.WriteLine();
    RandomizeAnimals();
    string[,] group1 = AssignGroup(groups);
    Console.WriteLine(schoolName);
    PrintGroup(group1);
}

// make this into a method that can do this for multiple schools
// RandomizeAnimals();
// string[,] group = AssignGroup();
// Console.WriteLine("School A");
// PrintGroup(group);

void RandomizeAnimals() // we'll be using the global pettingZoo variable, so no parameters are required for this method
{
    Random random = new Random();

    for (int i = 0; i < pettingZoo.Length; i++)
    {
        int r = random.Next(i, pettingZoo.Length);

        string temp = pettingZoo[i];
        pettingZoo[i] = pettingZoo[r];
        pettingZoo[r] = temp;
    }
}

//----------------------------------testing RandomizeAnimals() method
// foreach(string animal in pettingZoo)
// {
//     Console.WriteLine(animal);
// }
//--------------------------------------------------------------------

string[,] AssignGroup(int groups = 6)
{
    string[,] result = new string[groups, pettingZoo.Length/groups];

    int start = 0;

    for (int i = 0; i < groups; i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i,j] = pettingZoo[start++];
        }
    }

    return result;
}

void PrintGroup(string[,] group)
{
    for (int i = 0; i < group.GetLength(0); i++)
    {
        Console.Write($"Group {i + 1}: ");
        for (int j = 0; j < group.GetLength(1); j++)
        {
            Console.Write($"{group[i,j]} ");
        }
        Console.WriteLine();
    }
}
//----------------------------------------------------------------------------------------------------------------
                                            // Mini-game
    // variables:
        // Variables to determine the size of the Terminal window
        // Variables to track the locations of the player and food
        // Arrays 'states' and 'foods' to provide available player and food appearances
        // Variables to track the current player and food appearance
    
    // methods:
        // Determine if the Terminal window was resized
        // Display a random food appearance at a random location
        // Change the player appearance to match the food consumed
        // Temporarily freezes the player movement
        // Move the player according to directional input
        // Sets up initial game state

    // The following features are missing:
        // Determining if the player has consumed the food displayed
        // Determining if the food consumed should freeze player movement
        // Determining if the food consumed should increase player movement
        // Code that increases movement speed
        // Code to redisplay the food after it's consumed by the player
        // Code to terminate execution if an unsupported key is entered
        // Code to terminate execution if the terminal was resized

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit)
{   
    if (TerminalResized())
    {
        Console.Clear();
        Console.Write("Console was resized. Program exiting.");
        shouldExit = true;
    }
    else
    {
        if (PlayerIsFaster())
        {
            Move(1, false);
        }
        else if (PlayerIsSick())
        {
            FreezePlayer();
        }
        else
        {
            Move(otherKeysExit: false);
        }
        if (GotFood())
        {
            ChangePlayer();
            ShowFood();
        }
    }
}

// Returns true if the Terminal was resized
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Returns true if the player location matches the food location
bool GotFood()
{
    return playerY == foodY && playerX == foodX;
}

// Returns true if the player appearance represents a sick state
bool PlayerIsSick()
{
    return player.Equals(states[2]);
}

// Returns true if the player appearance represents a fast state
bool PlayerIsFaster()
{
    return player.Equals(states[1]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(int speed = 1, bool otherKeysExit = false)
{
    int lastX = playerX;
    int lastY = playerY;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;

        case ConsoleKey.DownArrow:
            playerY++;
            break;
        
        case ConsoleKey.LeftArrow:
            playerX -= speed;
            break;

        case ConsoleKey.RightArrow:
            playerX += speed;
            break;
        
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        
        default:
            // Exit if any other keys are pressed
            shouldExit = otherKeysExit;
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep the player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}