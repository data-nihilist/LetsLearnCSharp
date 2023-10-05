Console.WriteLine("To which number would you like me to count to? ");
// int userProvidedNumber = Convert.ToInt32(Console.ReadLine());    // refactored to below
// int userProvidedNumber = ReadNumber();   // refactored to just use the function (line 5)

Count(ReadNumber());  // When Count is invoked, the value currently in userProvidedNumber is copied into Count's numberToCountTo parameter
Count(20);

CountBetween(20, 30);

GetUserName();

AskForANumber("How many years has it been since Bloodborne was released?");

AskForNumberInRange("It was definitely between the years of your freshman year at SSU and when you started reading this textbook..", 1, 10);

Console.WriteLine($"\n{Factorial(5)}");

Console.WriteLine("\n\t\t\t\tCountdown\n");
Console.WriteLine("Rewrite the following countdown loop as a recursive method.\nfor (int x = 10; x > 0; x--)\n\tConsole.WriteLine(x);\n-\tRemember that you must have a base case that ends the recursion and that every time you call the method recursively, you must be getting closer and closer to that base case.");
Console.WriteLine();

Console.WriteLine(CountDown(10));

Console.WriteLine("\n\t\t\t\tBOSS BATTLE: Hunting The Manticore\n");

HuntingTheManticore();

static void HuntingTheManticore()
{
    string divider = "---------------------------------------------------------------";
    int cityHealth = 15;
    int manticoreHealth = 10;
    int round = 1;

    Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
    int manticorePosition = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    Console.WriteLine("Player 2, it's your turn.");
    Console.WriteLine(divider);
    int cityCurrent = cityHealth;
    int manticoreCurrent = manticoreHealth;
    int cannonDamage = 1;
    do
    {
        Console.WriteLine($"STATUS: Round {round}\tCity: {cityCurrent}/{cityHealth}\tManticore: {manticoreCurrent}/{manticoreHealth}");

        if(round % 3 == 0 || round % 5 == 0)
            cannonDamage = 3;
        if (round % 3 == 0 && round % 5 == 0)
            cannonDamage = 10;
        else
            cannonDamage = 1;

        Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
        Console.WriteLine("Enter desired cannon range: ");
        int desiredCannonRange = Convert.ToInt32(Console.ReadLine());
        if (desiredCannonRange == manticorePosition)
        {
            Console.WriteLine("That round was a DIRECT HIT!");
            manticoreCurrent -= cannonDamage;
        }
        if (desiredCannonRange < manticorePosition)
        {
            Console.WriteLine("That round FELL SHORT of the target.");
        }
        if (desiredCannonRange > manticorePosition)
        {
            Console.WriteLine("That round OVERSHOT the target.");
        }
        cityCurrent--;
        round++;
        if (cityCurrent <= 0)
        {
            Console.WriteLine("The city of Consolas has fallen! Run for your lives!");
        }
        if (manticoreCurrent <= 0)
        {
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        }

        Console.WriteLine(divider);
    }
    while(cityCurrent > 0 && manticoreCurrent > 0);


}

int CountDown(int x)
{
    Console.WriteLine(x--);
    if (x == 1) return 1;
    return CountDown(x);
}

void CountBetween(int start, int end)
{
    Console.WriteLine();
    for (int current = start; current <= end; current++)
        Console.WriteLine(current);
}

static void Count(int numberToCountTo)
{   
    Console.WriteLine();

    if (numberToCountTo < 1)
        return;
    
    for(int current = 1; current <= numberToCountTo; current++)
        Console.WriteLine(current);
}
/*
    With static void on the method, if we use a variable in the containing method, the compiler will give us an error.
    If one keeps running into accidentally using variables from outside the method, consider using static as a safety precaution.

    A method whose return type is void indicates that it does not produce or return a value.
    They can just run until the end of the method with no return statements.
    However, void methods can still 'return early' with a simple 'return;' statement.

*/

int ReadNumber()
{
    string input = Console.ReadLine();
    int number = Convert.ToInt32(input);
    return number;
}

string GetUserName()
{
    while (true)
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        
        if (name != "") // empty string
            return name;
        Console.WriteLine("Let's try that again.");
    }
}
/*
    By listing a non-void return type in our method above, we promise to produce a result of the specified type.
    We must deliver on that promise, no matter what if statements and loops you encounter.
*/

int AskForANumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    Console.WriteLine(text);
    int guess = 0;
    while (guess < min || guess > max)
    {
        guess = AskForANumber("Guess a number in range :D");
    }

    Console.WriteLine("You're in range! At least of our best guess..");
    return guess;
}

int Factorial(int number)
{
    if (number == 1) return 1;
    return number * Factorial(number - 1);
}