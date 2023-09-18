//          Creating the launch.json file
// 1. Open the Run menu at the top of our desktop and select "Add Configuration"
// 2. Choose the debugger option ".NET 5+ and .NET Core"
// 3. Select "Add Configuration" then choose "{} .NET: Launch .NET Core Console App"
// 4. Examine the launch.json file that has been added to our projects .vscode folder:
// We see
// 'program: "${workspaceFolder}/bin/debug/<target-framework>/<project-name.dll>",
// Update to:
//                                                         !!!!!!!!!!!!!!!!!!!!!!!!
// 'program: "${workspaceFolder}/bin/debug/net7.0/NAMEOFPROJECT.dll",

//<target-framework> normally found in the project file as the 'TargetFramework' property
//<project-name.dll> normally the same as the project file name but with a '.dll' extension


//          Creating the tasks.json file
// 1. Open the View menu at the top of our desktop and select "Command Pallet"
// 2. At Command Pallet prompt, type "task" to filter the list of commands
// 3. Select "Tasks: Configure Default Build Task", then "Create tasks.json file from template", then ".NET Core"
// 4. Booyah!


//------------------------------------Using a standard breakpoint to examine our data:

// int productCount = 2000;
// string[,] products = new string[productCount, 2];

// LoadProducts(products, productCount);

// for (int i = 0; i < productCount; i++)
// {
//     string result;
//     result = Process1(products, i);

//     if (result != "obsolete")
//     {
//         result = Process2(products, i );
//     }
// }

// bool pauseCode = true;
// while (pauseCode == true) ;


// static void LoadProducts(string[,] products, int productCount)
// {
//     Random rand = new Random();

//     for (int i = 0; i < productCount; i++)
//     {
//         int num1 = rand.Next(1, 10000) + 10000;
//         int num2 = rand.Next(1, 101);

//         string prodID = num1.ToString();

//         if (num2 < 91)
//         {
//             products[i, 1] = "existing";
//         }
//         else if (num2 == 91)
//         {
//             products[i, 1] = "new";
//             prodID = prodID + "-n";
//         }
//         else
//         {
//             products[i, 1] = "obsolete";
//             prodID = prodID + "-0";
//         }

//         products[i, 0] = prodID;
//     }
// }

// static string Process1(string[,] products, int item)
// {
//     Console.WriteLine($"Process1 message - working on {products[item, 1]} product");

//     return products[item, 1];
// }

// static string Process2(string[,] products, int item)
// {
//     Console.WriteLine($"Process2 message - working on product ID #: {products[item, 0]}");
//     if (products[item, 1] == "new")
//         Process3(products, item);

//     return "continue";
// }

// static void Process3(string[,] products, int item)
// {
//     Console.WriteLine($"Process3 message - processing product information for 'new' product");
// }

//-----------------------------------------------------------------------------------------------

string? readResult;
int startIndex = 0;
bool goodEntry = false;

int[] numbers = { 1, 2, 3, 4, 5 };

// Display the array to the console
Console.Clear();
Console.WriteLine("\n\rThe 'numbers' array contains {");
foreach (int number in numbers)
{
    Console.Write($"{number}");
}

// To calculate the sum of array elements,
//prompt the user for the starting element number.
Console.WriteLine($"}}\n\r\n\rTo sum values 'n' through 5, enter a value for 'n':");
while (goodEntry == false)
{
    readResult = Console.ReadLine();
    goodEntry = int.TryParse(readResult, out startIndex);

    if (startIndex > 5)
    {
        goodEntry = false;
        Console.WriteLine("\n\rEnter an integer value between 1 and 5");
    }
}

// Display the sum and then pause.
Console.WriteLine($"\n\rThe sum of numbers {startIndex} through {numbers.Length} is {SumValues(numbers, startIndex)}");

Console.WriteLine("press Enter to exit");
readResult = Console.ReadLine();

// This method returns the sum of elements n through 5
static int SumValues(int[] numbers, int n)
{
    int sum = 0;
    for (int i = n; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    return sum;
}