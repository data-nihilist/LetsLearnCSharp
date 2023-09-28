//                  Things I wasn't Exactly Aware Of Before This Introduction

Console.WriteLine("1. The way RB breaks down the C#/.NET BCL-namespace-class-method system is very well put:\n");

string[] introInsights =
{
    "Base Class Library (BCL) -- this is a super container",
    "System (namespace -- a container of many built-in C# classes)",
};

string[] systemClassesExamples =
{
    "Console",
    "Convert",
    "Math",
};

string[] consoleMethods =
{
    "WriteLine()",
    "ReadLine()",
};

string[] convertMethods =
{
    "ToInt32()",
    "ToString()",
};

string[] mathMethods =
{
    "Sqrt()",
    "Max()",
};

namespacingSummary();

            // 2. The way RB breaks down the general structure of a C# application

string[] generalStructure =
{
    "c:\\ Console Application",
    "\tProgram",
    "\tMain",
    "\tnamed variables"
};

foreach (string line in generalStructure)
{
    Console.WriteLine(line);
}

//------------------------------------------------------------------------------------------------
void namespacingSummary()
{
    for (int i = 0; i < introInsights.Length; i++)
    {   
        if (i == 0)
        {
            Console.WriteLine(introInsights[i]);
        }
        
        if (i == 1)
        {   
            Console.WriteLine($"\n\t{introInsights[i]}\n");

            for (int j = 0; j < systemClassesExamples.Length; j++)
            {
                if (systemClassesExamples[j] == "Console")
                {
                    Console.WriteLine($"\t\t{systemClassesExamples[j]} -- build in System class");

                    foreach(string example in consoleMethods)
                    {
                        Console.WriteLine($"\t\t\t{example} -- method that belongs to this class");
                    }
                    Console.WriteLine();
                }
                else if (systemClassesExamples[j] == "Convert")
                {
                    Console.WriteLine($"\t\t{systemClassesExamples[j]}");

                    foreach(string example in convertMethods)
                    {
                        Console.WriteLine($"\t\t\t{example}");
                    }
                    Console.WriteLine();

                }
                else if (systemClassesExamples[j] == "Math")
                {
                    Console.WriteLine($"\t\t{systemClassesExamples[j]}");

                    foreach(string example in mathMethods)
                    {
                        Console.WriteLine($"\t\t\t{example}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
};
