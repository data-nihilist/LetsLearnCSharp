string byteMatrixTop = (
" __________________________________________________________________________________________________________________\n|128\t\t64\t\t32\t\t16\t\t8\t\t4\t\t2\t\t1  |"
);
string byteMatrixBottom = (
"|1\t\t1\t\t0\t\t0\t\t0\t\t0\t\t1\t\t1  |\n|__________________________________________the above matrix = int 195______________________________________________|"
);
// the above matrix = int 195
Console.WriteLine(byteMatrixTop);
Console.WriteLine(byteMatrixBottom);
string[] onMemory = 
    {
        "\n\t\t\t\t\t\t\tRECAP\nValues are stored as bits:",
        "\t\tSimple 'on' 'off' switches. Combining enough of these switches allows you to store just about any possible value.\n",
        "There are two basic categories of data types: value and reference types;",
        "\t\tThe difference is how and where the values are stored by the computer as your program executes.\n",
        "Simple value types use a keyword (alias) to represent formal names of types in the .NET Library.",
        "\t\tExample: The C# keyword [int] is an alias of a value type defined in the .NET Class Library [System.Int32]",
        "\nA value type variable stores its values directly in an area of storage called the stack.",
        "When the stack frame has finished executing, the values in the stack are removed.",

};

for(int i = 0; i < onMemory.Length; i++ )   Console.WriteLine(onMemory[i]);

Console.WriteLine();
Console.WriteLine();

string[] onIntegrals = 
    {
        "\n\t\t\t\t\t\t\tOn Integrals\n\tSigned integral types:\n",
        $"\tsbyte  : {sbyte.MinValue} to {sbyte.MaxValue}",
        $"\tshort  : {short.MinValue} to {short.MaxValue}",
        $"\tint    : {int.MinValue} to {int.MaxValue}",
        $"\tlong   : {long.MinValue} to {long.MaxValue}\n",
        "\tUnsigned integral types:\n",
        $"\tbyte    : {byte.MinValue} to {byte.MaxValue}",
        $"\tushort  : {ushort.MinValue} to {ushort.MaxValue}",
        $"\tuint    : {uint.MinValue} to {uint.MaxValue}",
        $"\tulong   : {ulong.MinValue} to {ulong.MaxValue}",
        "\n\t\t\t\t\t\t\tOn Floats",
        "FOR APPROXIMATIONS: use [float] or [double] - these large numbers can be stored with a small memory footprint.",
        "FOR PRECISION: use [decimal] - these numbers will take up more data with the added benefit of higher accuracy.\n",
        "E notation:\t\t5E+2 would be the value 500 because it's the equivalent of 5 * 10^2, or 5 x 102.",
        $"\n\tFloating point types:\n",
        $"\tfloat    : {float.MinValue}\t\t\tto\t{float.MaxValue}",
        $"\tdouble   : {double.MinValue}\t\tto\t{double.MaxValue}",
        $"\tdecimal  : {decimal.MinValue}\tto\t{decimal.MaxValue}",
        "\n\nA floating-point type is a simple value data type that can hold fractional numbers.",
        "\nChoosing the right floating-point type for your application requires you to consider more than just the maximum and minimum values that it can hold;",
        "\n\tYou must also consider:\n",
        "\t\t\t1. How many values can be preserved after the decimal",
        "\t\t\t2. How the numbers are stored",
        "\t\t\t3. How their internal storage affects the outcome of math operations.",
        "\nThere's a fundamental difference in how the compiler and runtime handle [decimal] as opposed to [float] or [double],",
        "\tespecially when determining how much accuracy is necessary from math operations."
    };

for(int i = 0; i < onIntegrals.Length; i++)   Console.WriteLine(onIntegrals[i]);

string[] onReferenceTypes = 
{
    "\n\t\t\t\t\t\t\tOn Reference Types\n",
    "Reference types include arrays, classes, and strings.",
    "Reference types are treated differently from value types regarding the way values are stored when the application is executing.",
    "A reference type variable stores its values in a separate memory from the stack. This region is called the heap.",
    "The heap is a memory area that is shared across many applications running on the operating system at the same time.",
    "\n\tThe .NET Runtime communicates with the operating system to determine what memory addresses are available, and requests an address where it can store the value.",
    "\tThe .NET Runtime stores the value, and then returns the memory address to the variable.",
    "\tWhen code uses the variable, the .NET Runtime seamlessly looks up the address stored in the variable, and retrieves the value that's stored there."  
};

for(int i = 0; i < onReferenceTypes.Length; i++)    Console.WriteLine(onReferenceTypes[i]);
Console.WriteLine("\n\nSee Program.cs for the remainder of this review.\n\n(Lines 75-109)\n");

int[] exampleData;

//                  Line 75: A variable that can hold a value of type int array is defined.

//                  At this point, exampleData is merely a variable that could hold a reference, a memory address, of a value in the heap.
//                  Because it isn't pointing to a memory address, it's called a 'null reference'.

exampleData = new int[3];

//                  Line 82: The 'new' keyword informs .NET Runtime to:
//                  Create an instance of int array
//                  Then coordinate with the operating system to store the array sized for three int values in memory.

//                  The .NET Runtime complies, and returns a memory address of the new int array.
//                  Finally, the memory address is stored in the variable exampleData.
//                  The int array's elements default to the value 0, because that is the default value of an int.

//--------------------------------------------------------------------------------------------------------------------Example of line 90's insight:
// int[] otherExampleData;
// otherExampleData = new int[3];
// Console.WriteLine("\n\nThe following code was not manually assigned the value of zero.
// Console.WriteLine("This is the default value of an empty int array.\n");
// for(int i = 0; i < otherExampleData.Length; i++)    Console.WriteLine(otherExampleData[i]);
//----------------------------------------------------------intentional error
// int extraExample = 0; // You can't declare a single new int variable - it must be called on an array
// Console.WriteLine($"This is extraExample: {extraExample}");
//----------------------------------------------------------

//                  The string data type is also a reference type.
//                  However, it's used so frequently you can use the following format:

string farewellForNow = "This concludes the module. Be sure to use this file as needed for reference.";

Console.WriteLine(farewellForNow);
// Behind the scenes, a new instance of System.String is called and initialized to say the defined value.

//                     byte:     Working with encoded data that comes from other computer systems or using different character sets.
//                   double:     Working with geometric or scientific purposes. double is used frequently when building games involving motion.
//          System.DateTime:     For a specific date and time value.
//          System.TimeSpan:     For a span of years / months / days / hours / minutes / seconds / milliseconds.