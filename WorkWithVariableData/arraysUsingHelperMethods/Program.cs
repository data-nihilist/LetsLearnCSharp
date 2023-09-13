//                  In this module we will:
// Sort and reverse the order of array elements.
// Clear and resize the elements of an array.
// Split a string into an array of strings or characters (chars).
// Join array elements into a string.

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
Console.WriteLine("Reversed...");
Array.Reverse(pallets2);
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

string[] pallets4 = { "B14", "A11", "B12", "A13", "B14", "A11", "B12", "A13", "B14", "A11", "B12", "A13", "B14", "A11", "B12", "A13" };
// Array.Resize(ref pallets4, 6);
// Console.WriteLine($"Resizing to 6 ... count: {pallets4.Length}");

pallets4[4] = "C01";
pallets4[5] = "C02";

foreach (var pallet in pallets4)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("Here we're calling the Resize() method, passing in the pallets array by reference using the `ref` keyword.");
Console.WriteLine("Sometimes, methods ask us to pass arguments by value (the default) or by reference (using the ref keyword.)");
Console.WriteLine("Always feel comfortable to consider the documentation on C# Array methods and implementation during times of uncertainty.");

Console.WriteLine("");

// Console.WriteLine("Conversely, we can use Resize() to remove array elements:");
// Array.Resize(ref pallets4, 3);
// Console.WriteLine($"Resizing to 3 ... count: {pallets4.Length}");
// foreach (var pallet in pallets4)
// {
//     Console.WriteLine($"-- {pallet}");
// }

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
int control = 0;
int insight = 0;
// int index = 0; // see line 117 for reference
for (int i = 0; i < countedPallets.Length; i++)
{   
    count++;
    if(pallets4[i] != null)
    {   
        countedPallets[i] = pallets4[i];
        control = 0;
    }
    if(pallets4[i] == null){
        countedPallets[i - control] = "fizz";
        insight++;
        
    }
}
Console.WriteLine("\nCounted Pallets\n");
foreach (var pallet in countedPallets)
{
    Console.WriteLine($"Counted Pallet: -- {pallet}");
}
Console.WriteLine($"Total amount of null elements from the parent array for Counted Pallets: {insight}");