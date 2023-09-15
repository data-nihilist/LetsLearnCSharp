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

string[] names = new string[] { "Sophia", "Andrew", "AllGreetings" };

string messageText = "";

foreach (string name in names)
{
    if (name == "Sophia")  // breakpoint
    {
        messageText = SophiaMessage(); // stepInto 1 && stepOut 1
    }
    else if (name == "Andrew")
    {
        messageText = AndrewMessage();
    }
    else if (name == "AllGreetings")
    {
        messageText = SophiaMessage();
        messageText = messageText + "\n\r" + AndrewMessage();   // stepInto 3 ---> We've found what was causing our output problem B)
    }                                                           // Adding code blocks {} should remedy this issue.

    Console.WriteLine(messageText + "\n\r");
}

// bool pauseCode = true;
// while (pauseCode == true); // this makes your application stall in place. Comment this in/out as needed.

static string SophiaMessage()
{                                           // stepInto 2
    return "Hello, my name is Sophia";
}

static string AndrewMessage()
{
    return "Hi, my name is Andrew. Good to meet you.";
}

//              Setting Breakpoints
        // Because our code executes in micro-seconds, effective code debugging depends on
        //our ability to pause the program on any statement within our code.
        // Breakpoints are used to specify where code execution pauses
        // We can save a breakpoint without removing it by right clicking and selecting "Disable Breakpoint"

//              Editing Breakpoints
        // Right clicking a breakpoint and selecting "Edit Breakpoint"
        // We can also set a Conditional Breakpoint directly by right clicking where we want to set it and selecting that option

//              Conditional Breakpoints
        // When we create a conditional breakpoint, we need to specify an expression that represents the condition
        // Each time our debugger encounters that breakpoint, it evaluates the expression.
        // If the expression evaluates as false, execution continues as if there was no breakpoint

int n = 9;

for (int i = 0; i <= n; i++)
{
    Console.WriteLine(i);   // conditional breakpoint: i > 3 ------> Execution pauses once i = 4
}

//              Hit Points
        // A 'hit point' is used to specify the number of times that a breakpoint must be encountered 
        //before it will 'break' execution.

//              Logpoints
        // A 'Logpoint' is a varient ofa breakpoint that does not "break" into the debugger but instead
        //logs a message to the debug console.
        // Logpoints can include a conditional 'expression' and/or 'hit count' to further control when logging
        //messages are generated.
