// while loops repeat code over and over for as along as some given condition evaluates to true

/*
    while ( condition )
    {
        This code is repeated as long as the condition is true
    }

    1. If the loop's condition is false initially, the loop's body will not run at all.
    2. The loop's condition is only evaluated when we check it at the start of each cycle.
        If the condition changes in the middle of executing the loop's body, it does not immediately leave the loop.
    3. It is entirely possible to build a loop whose condition never becomes false.
        If we forgot the 'x++;' in the example function below, in the above loop it would run over and over causing an infinite loop.
        It is occasionally done on purpose but usually represents a bug.
        If your program seems like it has gotten stuck, check to see if you created an infinite loop.
*/
Console.WriteLine("\t\t\t\tWhile Loop Examples");

WhileLoopExample();
WhileLoopWithUserInputExample();

void WhileLoopExample()
{
    int x = 1;
    while (x <= 5)
    {
        Console.WriteLine(x);
        x++;
    }
}

void WhileLoopWithUserInputExample()
{
    int playersNumber = -1; // All variables need to be initialized before they can be used by our while loop and we also need our condition to initially evaluate to true for this loop to begin (-1 is less than 0, as per our condition)
    while (playersNumber < 0 || playersNumber > 10)
    {
        Console.Write("Enter a number between 0 and 10: ");
        string? playerResponse = Console.ReadLine();
        playersNumber = Convert.ToInt32(playerResponse);
    }
}

// The do/while loop evaluates its condition at the end the loop instead of at the beginning. This ensures the loop runs at least once.

/*
    do
    {
        code to run at least once
    }
    while ( condition )
*/
Console.WriteLine("\t\t\t\tDo/While Loop Example");

DoWhileLoopExample();

void DoWhileLoopExample()
{
    int playersNumber;  // Because the loop's body always runs at least once, we no longer need to initialize the variable to -1 as we did above, just declare it. playersNumber will be initialized to a value inside the loop to whatever the player chooses.
                        // We also need to declare this variable outside of the do's code-block in order to access it as the while's condition.
    do
    {
        Console.Write("Enter a number between 0 and 10: ");
        string? playerResponse = Console.ReadLine();
        playersNumber = Convert.ToInt32(playerResponse);
    }
    while(playersNumber < 0 || playersNumber > 10); // necessary semi-colon!
}

// The for loop allows you to pack loop management code into a single line:
/*
    for (initialization statement; condition to evaluate; updating action)
    {
        code-code-code-code
    }

    ** While most for-loops use all three statements, any of them can be left out if nothing needs to be done.
    ** You will even occasionally encounter a loop that looks like: for (;;) { ... } to indicate a for-loop with no condition.
        This will loop forever, though I'd prefer to use a while (true) { ... } in place of an omitted for-loop.
*/

Console.WriteLine("\t\t\t\tFor loop example");

ForLoopExample();

void ForLoopExample()
{
    for (int x = 0; x <= 5; x++)    // Initializing x to 0 to differ from the first while-loop example
        Console.WriteLine(x);       // Here I'm using a 'single statement' rather than a block statement.
}                                   // I personally prefer block statements for readability, but this is just an example

// BREAK out of loops and CONTINUE to the next pass
/*
    The break and continue statements give you more control over how looping is handled.

    A break statement forces the loop to terminate immediately without reevaluating thee loop's condition.
            -This lets us escape a loop we no longer want to keep running.
            -The loop's condition is not reevaluated, so it means we can leave the loop while its condition is still technically true.

    A continue statement will also cause the loop to stop running the current pass through the loop BUT
            -Will advance to the next pass, recheck the condition, and keep looping if the condition still holds.
            -You can think of continue as, "Skip the rest of this pass through the loop and continue to the next pass."
    
    Most loops don't need breaks and continues - but the nuanced control is sometimes helpful.
*/
Console.WriteLine("\t\t\t\tBreaking and Continuing");

BreakingAndContinuingExample();

void BreakingAndContinuingExample()
{
    while (true)                    // technically this would never finish
    {
        Console.Write("Think of a number and type it here: ");
        string? input = Console.ReadLine();

        if (input == "quit" || input == "exit")
            break;      // Causing the flow of execution to escape the loop and
                        // ensures we can break out of the 'while (true)' loop
        int number = Convert.ToInt32(input);

        if (number == 12)
        {
            Console.WriteLine("I don't like that number. Pick another one.");
            continue;   // The flow of execution jumps to the loop's beginning, our condition is rechecked, and the loop runs again.
        }
        Console.WriteLine($"I like {number}. It's the one before {number + 1}!");
    }
}

// Nesting Loops

/*
    Nested loops are common when you need to do something with every combination of two sets of things.
*/
Console.WriteLine("\t\t\t\tNesting Loops");

NestedLoopsExample();

void NestedLoopsExample()
{
    int totalRows = 5;
    int totalColumns = 10;

    for (int currentRow = 1; currentRow <= totalRows; currentRow++)
    {
        for (int currentColumn = 1; currentColumn <= totalColumns; currentColumn++)
            Console.Write("*");
        
        Console.WriteLine();
    }
}

Console.WriteLine("\n\t\t\t\tThe Prototype\n");
Console.WriteLine("Mylara, the captain of the Guard of Consolas, has approached you with the beginnings ofa plan to hunt\ndown The Uncoded One's airship. \"If we're going to be able to track this thing down,\" she says,\n\"we need you to make us a program that can help us home in on a location.\" She lays out a plan for a program to\nhelp with the hunt.\n\nOne user, representing the airship pilot, picks a number between 0 and 100.\nAnother user, the hunter, will then attempt to guess the number.\nThe program will tell the hunter that they guessed correctly or that\nthe number was too high or too low.\nThe program repeats until the hunter guesses the number correctly.\nMylara claims, \"If we can build this program, we can use what we learn to build\na better version to hunt down the Uncoded One's airship.\"");
Console.WriteLine();

ThePrototypeQuest();

void ThePrototypeQuest()
{
    int userOneNumber;

    Console.Write("User 1, enter a number between 0 and 100: ");
    userOneNumber = Convert.ToInt32(Console.ReadLine());

    while (userOneNumber < 0 || userOneNumber > 100)
    {
        Console.WriteLine("User 1, please, enter a number between 0 and 100");
        userOneNumber = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("User 2, guess the number.");
    int userTwoNumber;
    do
    {
        Console.Write("What is your next guess? ");
        userTwoNumber = Convert.ToInt32(Console.ReadLine());

        if (userTwoNumber < userOneNumber)
        {
            Console.WriteLine($"{userTwoNumber} is too low.");
            continue;
        }
        if (userTwoNumber > userOneNumber)
        {
            Console.WriteLine($"{userTwoNumber} is too high.");
            continue;
        }
        if (userTwoNumber == userOneNumber)
            break;
    }
    while(userTwoNumber != userOneNumber);

    Console.WriteLine("You guessed the number!");
    Console.ReadLine(); // pausing execution
}

Console.WriteLine("\n\t\t\t\tThe Magic Cannon\n");
Console.WriteLine("Skorin, a member of Consolas's wall guard, has constructed a magic cannon that draws power from two\ngems: a fire gem and an electric gem. Every third turn of a crank, the fire gem activates, and the cannon\n produces a fire blast. The electric gem activates every fifth turn of the crank, and the cannon makes an\nelectric blast. When the two line up, it generates a potent combined blast. Skorin would like your help to\nproduce a program that can warn the crew about which turns of the crank will produce the different\nblasts before they do it.\n");
Console.WriteLine();
/*
        A partial output of the desired program looks like this:

        1: Normal
        2: Normal
        3: Fire
        4: Normal
        5: Electric
        6: Fire
        7: Normal
*/

TheMagicCannonQuest();

void TheMagicCannonQuest()
{
    for(int n = 0; n <= 100; n++)
    {
        if(n % 5 == 0 && n % 3 == 0)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{n}. Fire&Electric!");
        }
        else if(n % 3 == 0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{n}. Fire");
        }
        else if(n % 5 == 0)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{n}. Electric");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{n}. Normal");
        }
    }
}