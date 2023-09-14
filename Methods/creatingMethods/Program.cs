Console.WriteLine("The following calls to our SayHello() method are being made on lines of code that exist above our defining of the SayHello() method!\n");
Console.WriteLine("Before calling SayHello()");
SayHello();
Console.WriteLine("After calling SayHello()");

void SayHello() // Methods use PascalCase, meaning each word of the method name is capitalized: ThisIsPascalCase
{
    Console.WriteLine("Hello World!");
}

// Notice that it isn't necessary to have the method defined before you call it.
// This flexibility allows you to organize your code as you see fit. It's common to define all methods at the end of the program:
Console.WriteLine("");

int[] a ={ 1, 2, 3, 4, 5 };

Console.WriteLine("Contents of Array:");
PrintArray(); // We haven't defined this method yet, tho we've called it to keep our code's flow more readable

void PrintArray() // Now we've defined our method.
{
    foreach (int x in a)
    {
        Console.WriteLine($"{x} ");
    }
    Console.WriteLine("");
}

string[] introRecap =
{
    "Once a method is defined, it can be called any time, as many times as you need to use it.",
    "You can use methods inside of if-else statements, for-loops, switch statements, even to initialize variables, and so much more!"
};

foreach (string line in introRecap)
{
    Console.WriteLine(line);
};

Console.WriteLine("");
//------------------------------------Creating a method to display random numbers:
string[] onMethods =
{
    "\t\t\t\tCreating A Method\n",
    "To create a method, first create a method signature and then add the method body.",
    "To create the method signature, you declare the return type, method name, and parameters.",
    "Create the method body by using brackets {} that contain the code.",
    "Let's begin by creating the following method:\tvoid DisplayRandomNumbers();",
    "In this case, the method just needs to generate and display information, so the return type is [void].",
    "For now, we don't need to provide any parameters."
};

foreach (string line in onMethods)
{
    Console.WriteLine(line + "\n");
};

void DisplayRandomNumbers()
{
    Random random = new Random(); // Here we create a Random object (from the .NET Class Library) that is used to generate numbers

    Console.WriteLine("Generating random numbers:");

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"{random.Next(1, 100)} "); // Generating a number 1 - 99 (inclusive)
    }

    Console.WriteLine(); // Displays a new line before the method terminates
}

DisplayRandomNumbers();

//-------------------------------Creating Reusable Methods:

//------------------------------------------------------------------------------------Provided code:

int[] times = { 800, 1200, 1600, 2000 };
int diff = 0;

Console.WriteLine("Enter current GMT");
int currentGMT = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Current Medicine Schedule:");
                                                            // REPLACING
DisplayTimes();
                                                            // // Format and display medicine times
                                                            // foreach (int val in times)
                                                            // {
                                                            //     string time = val.ToString();
                                                            //     int len = time.Length;

                                                            //     if (len >= 3)
                                                            //     {
                                                            //         time = time.Insert(len - 2, ":");
                                                            //     }
                                                            //     else if (len == 2)
                                                            //     {
                                                            //         time = time.Insert(0, "0:");
                                                            //     }
                                                            //     else
                                                            //     {
                                                            //         time = time.Insert(0, "0:0");
                                                            //     }

                                                            //     Console.WriteLine($"{time} ");
                                                            // }

Console.WriteLine();

Console.WriteLine("Enter new GMT");

int newGMT = Convert.ToInt32(Console.ReadLine());

if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
{
    Console.WriteLine("Invalid GMT");
}
else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
{
    diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
AdjustTimes();
    // // Adjust the times by adding the difference, keeping the value within 24 hours
    // for (int i = 0; i < times.Length; i++)
    // {
    //     times[i] = ((times[i] + diff)) % 2400;
    // }
}
else
{
    diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
AdjustTimes();
    // // Adjust the times by adding the difference, keeping the value within 24 hours
    // for (int i = 0; i < times.Length; i++)
    // {
    //     times[i] = ((times[i] + diff)) % 2400;
    // }
}

Console.WriteLine("New Medicine Schedule:");
                                                        // REPLACING
DisplayTimes();
                                                        // // Format and display medicine times
                                                        // foreach (int val in times)
                                                        // {
                                                        //     string time = val.ToString();
                                                        //     int len = time.Length;

                                                        //     if (len >= 3)
                                                        //     {
                                                        //         time = time.Insert(len - 2, ":");
                                                        //     }
                                                        //     else if (len == 2)
                                                        //     {
                                                        //         time = time.Insert(0, "0:");
                                                        //     }
                                                        //     else
                                                        //     {
                                                        //         time = time.Insert(0, "0:0");
                                                        //     }

                                                        //     Console.Write($"{time} ");
                                                        // }

Console.WriteLine();
//----------------------------------------------------------------------------------End of provided code
// Notice above there are several for-loops that are repeated with identical code.
// There are also two foreach loops that format and display the medicine times.
// There are another two for-loops that adjust the times according to the time zone difference.
// As we write our code, areas we find ourselves repeating are perfect opportunities to consolidate our code by using a method to perform the task instead.

void DisplayTimes()
{
    // Format and display medicine times
    foreach (int val in times)
    {
        string time = val.ToString();
        int len = time.Length;

        if (len >= 3)
        {
            time = time.Insert(len - 2, ":");
        }
        else if (len == 2)
        {
            time = time.Insert(0, "0:");
        }
        else
        {
            time = time.Insert(0, "0:0");
        }

        Console.Write($"{time} ");
    }

    Console.WriteLine();
}

void AdjustTimes()
{
    // Adjust the times by adding the difference, keeping the value within 24 hours
    for (int i = 0; i < times.Length; i++)
    {
        times[i] = ((times[i] + diff)) % 2400;
    }
}
