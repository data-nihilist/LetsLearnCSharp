//                  Things I wasn't Exactly Aware Of Before This Introduction
using System.Collections;

Console.WriteLine("Below is a numbered list of my favorite insights that RB's introduction for The C# Player's Guide 5th edition\n\n");
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

Console.WriteLine();

Console.WriteLine("2. RB's deconstruction of a C# application's structure:\n");

string[] generalStructure =
{
    "c:\\ Console Application",
    "\tProgram.cs",
    "\t\t<Main>$ -- a method call -- this is the \"entry point\" for the computer to run our program(s)",
    "\t\t\tnamed variables -- variables are simply containers for data"
};

foreach (string line in generalStructure)
{
    Console.WriteLine(line);
}
// var name = 1222.5m; // having fun with implicitly typed variables (this is a neat way to see the compiler's suggestions for data types)

Console.WriteLine("\n\n");

Console.WriteLine("All 14 variables covered in Level 6: The C# Type System\n");

byte minByte = 0;
byte maxByte = 255;

short minShort = -32768;
short maxShort = 32_767; // we can use underscores in place of commas to display integral data variables of many digits

int minInt = -2_147_483_648;
int maxInt = 2_147_483_647;

long minLong = -9_223_372_036_854_775_808;
long maxLong = 9_223_372_036_854_775_807;

sbyte minSignedByte = -128;
sbyte maxSignedByte = 127;

ushort minUnsignedShort = 0;
ushort maxUnsignedShort = 65535;

uint minUnsignedInt = 0;
uint maxUnsignedInt = 4_294_967_295;

ulong minUnsignedLong = 0;
ulong maxUnsignedLong = 18_446_744_073_709_551_615;

// array format: number of bytes the data type requires for storage, minimum value, maximum value
byte[] byteInformation = { 1, minByte, maxByte };
short[] shortInformation = { 2, minShort, maxShort };
int[] intInformation = { 4, minInt, maxInt };
long[] longInformation = { 8, minLong, maxLong };
sbyte[] signedByteInformation = { 1, minSignedByte, maxSignedByte };
ushort[] unsignedShortInformation = { 2, minUnsignedShort, maxUnsignedShort };
uint[] unsignedIntInformation = { 4, minUnsignedInt, maxUnsignedInt };
ulong[] unsignedLongInformation = { 8, minUnsignedLong, maxUnsignedLong };

integerTypesSummary();

Console.WriteLine("\n\t\t\tBinary & Hexadecimal Literals\n");
Console.WriteLine($"Binary Literal:\t\t\tint thirteen = 0b00001101\t--> {0b00001101}");
Console.WriteLine($"Hexadecimal Literal:\t\tint theColorMagenta = 0xFF00FF\t--> {0xFF00FF}");

Console.WriteLine();

Console.WriteLine($"char typed variables represent a single character, while strings can be text of any length.");
char aLetter = 'a'; // notice the single quotation marks
char baseball = '⚾';
Console.WriteLine($"a character literal: {aLetter}");
Console.WriteLine($"a unicode character literal, the symbol for a baseball: {baseball}");

Console.WriteLine("\n\t\t\t\tFloating-Point Types\n\nType\tBytes\t\tRange\t\t\tDigits of Precision\tHardware Supported\n");

byte floatBytes = 4;
string floatRange = "± 1.0 × 10^45 to ± 3.4 × 10^38";
string floatPrecision = "7";
string floatsAreHardwareSupported = "Yes";

byte doubleBytes = 8;
string doubleRange = "±5 × 10^324 to ±1.7 × 10^308";
string doublePrecision = "15-16";
string doublesAreHardwareSupported = "Yes";

byte decimalBytes = 16;
string decimalRange = "±1.0 × 10^28 to ±7.9 × 10^28";
string decimalPrecision = "28-29";
string decimalsAreHardwareSupported = "No";

string[] floatInformation = { floatRange, " ", floatPrecision, "\t", floatsAreHardwareSupported };
string[] doubleInformation = { doubleRange, " ", doublePrecision, "\t", doublesAreHardwareSupported };
string[] decimalInformation = { decimalRange, " ", decimalPrecision, "\t", decimalsAreHardwareSupported };

floatingPointTypesSummary();

Console.WriteLine("\n\t\t\tBoolean Types\n");

bool angeloIsACutie = true;
bool theBltIsNotASandwich = false;

Console.WriteLine($"Angelo is a cutie-pie: {angeloIsACutie}");
Console.WriteLine($"The BLT is not a sandwich: {theBltIsNotASandwich}");

Console.WriteLine();

//-------------------------------------------------------functions for console output are fun
void floatingPointTypesSummary()
{
    byte memory;
    string[] typeNames = { "float", "double", "decimal" };

    for (int i = 0; i < typeNames.Length; i++)
    {
        if (typeNames[i] == "float")
        {
            memory = floatBytes;
            string info = "";
            foreach (string bitOfInfo in floatInformation)
            {
                info += $"{bitOfInfo}\t";
            }
            Console.WriteLine($"{typeNames[i]}\t{memory}\t{info}");
        }
        else if (typeNames[i] == "double")
        {
            memory = doubleBytes;
            string info = "";
            foreach (string bitOfInfo in doubleInformation)
            {
                info += $"{bitOfInfo}\t";
            }
            Console.WriteLine($"{typeNames[i]}\t{memory}\t{info}");
        }
        else if (typeNames[i] == "decimal")
        {
            memory = decimalBytes;
            string info = "";
            foreach (string bitOfInfo in decimalInformation)
            {
                info += $"{bitOfInfo}\t";
            }
            Console.WriteLine($"{typeNames[i]}\t{memory}\t{info}");
        }
        else
        {
            Console.WriteLine();
        }
    }
}

void integerTypesSummary()
{
    string yes = "Yes";
    string no = "No";

    string min = "Minimum";
    string max = "Maximum";
    string[] intColumns = { "Name", "Bytes", "Allow Negatives", min, "\t", max, "\n" };

    string table = "";
    foreach (string column in intColumns)
    {
        table += $"{column}\t\t";
    };
    Console.WriteLine("\n\t\tInteger Types:\n");
    Console.WriteLine(table);

    string[] typeNames = { "byte", "short", "int", "long", "sbyte", "ushort", "uint", "ulong" };

    for (int i = 0; i < typeNames.Length; i++)
    {
        switch (typeNames[i])
        {
            case "byte":
                Console.WriteLine($"{typeNames[i]}\t\t{byteInformation[0]}\t\t{no}\t\t\t{byteInformation[1]}\t\t\t\t\t{byteInformation[2]}");
                break;

            case "short":
                Console.WriteLine($"{typeNames[i]}\t\t{shortInformation[0]}\t\t{yes}\t\t\t{shortInformation[1]}\t\t\t\t\t{shortInformation[2]}");
                break;

            case "int":
                Console.WriteLine($"{typeNames[i]}\t\t{intInformation[0]}\t\t{yes}\t\t\t{intInformation[1]}\t\t\t\t{intInformation[2]}");
                break;

            case "long":
                Console.WriteLine($"{typeNames[i]}\t\t{longInformation[0]}\t\t{yes}\t\t\t{longInformation[1]}\t\t\t{longInformation[2]}");
                break;

            case "sbyte":
                Console.WriteLine($"{typeNames[i]}\t\t{signedByteInformation[0]}\t\t{yes}\t\t\t{signedByteInformation[1]}\t\t\t\t\t{signedByteInformation[2]}");
                break;

            case "ushort":
                Console.WriteLine($"{typeNames[i]}\t\t{unsignedShortInformation[0]}\t\t{no}\t\t\t{unsignedShortInformation[1]}\t\t\t\t\t{unsignedShortInformation[2]}");
                break;

            case "uint":
                Console.WriteLine($"{typeNames[i]}\t\t{unsignedIntInformation[0]}\t\t{no}\t\t\t{unsignedIntInformation[1]}\t\t\t\t\t{unsignedIntInformation[2]}");
                break;

            case "ulong":
                Console.WriteLine($"{typeNames[i]}\t\t{unsignedLongInformation[0]}\t\t{no}\t\t\t{unsignedLongInformation[1]}\t\t\t\t\t{unsignedLongInformation[2]}");
                break;

            default:
                Console.WriteLine();
                break;
        }
    }

}

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
                    Console.WriteLine($"\t\t{systemClassesExamples[j]} -- built in System class");

                    foreach (string example in consoleMethods)
                    {
                        Console.WriteLine($"\t\t\t{example} -- method that belongs to this class");
                    }
                    Console.WriteLine();
                }
                else if (systemClassesExamples[j] == "Convert")
                {
                    Console.WriteLine($"\t\t{systemClassesExamples[j]}");

                    foreach (string example in convertMethods)
                    {
                        Console.WriteLine($"\t\t\t{example}");
                    }
                    Console.WriteLine();

                }
                else if (systemClassesExamples[j] == "Math")
                {
                    Console.WriteLine($"\t\t{systemClassesExamples[j]}");

                    foreach (string example in mathMethods)
                    {
                        Console.WriteLine($"\t\t\t{example}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
