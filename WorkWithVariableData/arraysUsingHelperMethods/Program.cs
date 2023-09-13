//                  In this module we will:
// Sort and reverse the order of array elements.
// Clear and resize the elements of an array.
// Split a string into an array of strings or characters (chars).
// Join array elements into a string.

using System.Data;

Console.WriteLine("The Array class contains methods that you can use to manipulate the content, arrangement, and size of an array.");
Console.WriteLine("We're going to write code that performs various operations on an array of pallet identifiers.\n\n");

string[] pallets1 = { "B14", "A11", "B12", "A13" };

Console.WriteLine("Here we use the Sort() method of the Array class to sort the items in the array alphanumerically:\n");
Console.WriteLine("Sorted...");

Array.Sort(pallets1);

foreach (var pallet in pallets1)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");

string[] pallets2 = { "B14", "A11", "B12", "A13" };

Console.WriteLine("And here we use use the Array.Reverse() method to reverse the order of the pallets:\n");

Array.Reverse(pallets2);

Console.WriteLine("Reversed...");

foreach (var pallet in pallets2)
{
    Console.WriteLine($"~~ {pallet}");
}

Console.WriteLine("\n");

Console.WriteLine($"pallets[0] before using Array.Clear() method : {pallets2[0]/*.ToLower()*/}");

Array.Clear(pallets2, 0, 2);

Console.WriteLine($"\t\t\t     pallets[0] after: {pallets2[0]/*.ToLower()*/}  <--nothingness\n\nClearing 2 ... count: {pallets2.Length}");
Console.WriteLine("'After' isn't pointing to an empty string that's stored in pallets[0];");
Console.WriteLine("The C# Compiler implicitly converts the null value to an empty string for presentation, so, that isn't the case.");
                        // Before using Array.Clear() method : b14
                        // Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
                        //    at Program.<Main>$(String[] args) in /Users/juice/Desktop/LetsLearnCSharp/WorkWithVariableData/arraysUsingHelperMethods/Program.cs:line 32

if (pallets2[0] != null)
{
    Console.WriteLine($"After null check of pallets[0]: {pallets2[0].ToLower()}");
} else if (pallets2[0] == null)
{
    Console.WriteLine($"Null check failed! {pallets2[0]} <--nothingness");
}
string[] pallets3 = { "B14", "A11", "B12", "A13" };

foreach (var pallet in pallets3)
{
    Console.WriteLine($"-- {pallet}");
}
Console.WriteLine("");

string[] pallets4 = { "B14", "A11", "B12", "A13", "B22", "A22", "B33", "A33", "D32", "E11", "F99", "G47", "H14", "I88", "J22", "K55" };

foreach (var pallet in pallets4)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("Here we're calling the Resize() method, passing in the pallets array by reference using the `ref` keyword.");
Console.WriteLine("Sometimes, methods ask us to pass arguments by value (the default) or by reference (using the ref keyword.)");
Console.WriteLine("Always feel comfortable to consider the documentation on C# Array methods and implementation during times of uncertainty.");

Console.WriteLine("");

Console.WriteLine("\nClearing pallets[1] ... ...");

Array.Clear(pallets4, 1, 1);
Array.Clear(pallets4, 5, 3);

foreach (var pallet in pallets4)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("\n\t\t\t\tTo Remove null elements from an array:");

int count = 0;

Console.WriteLine($"Count before checking for non-null elements: {count}");
Console.WriteLine("We must count the number of non-null elements by iterating through each item and increment a counter.");

for (int i = 0; i < pallets4.Length; i++)
{
    if(pallets4[i] != null)
    {
        count++;
    }
}

Console.WriteLine("Next, we create a second array that is the size of the counter variable.");
string[] countedPallets = new string[count];

Console.WriteLine($"Counted Pallets length: {countedPallets.Length}");
Console.WriteLine("Finally, we loop through each element in the original array and copy non-null values into the new array.");

Array.Sort(pallets4);

int insight = 0;

Console.WriteLine($"Sorted pallets array length before null check: {pallets4.Length}");
Console.WriteLine("Sorting out null values of pallets array ...");

Array.Reverse(pallets4);

foreach (var pallet in pallets4)
{
    if (pallet != null)
    {
        Console.WriteLine($"Sorted Pallet: -- {pallet}");
    }
    else
    {
        insight++;
        Console.WriteLine("Null value found");
    }
}

Console.WriteLine($"Sorted pallets array length after null check: {pallets4.Length}");
Console.WriteLine($"Amount of null valued pallets found: {insight}");

Array.Resize(ref pallets4, pallets4.Length - insight);

foreach (var pallet in pallets4)
{
    Console.WriteLine($"Updated pallets array values: --{pallet}");
}

Array.Copy(pallets4, countedPallets, pallets4.Length);
Array.Sort(countedPallets);

foreach (var pallet in countedPallets)
{
    Console.WriteLine($"Counted Pallets Array: --{pallet}");
}

Console.WriteLine($"Length of updated, sorted pallets array: --{countedPallets.Length}");