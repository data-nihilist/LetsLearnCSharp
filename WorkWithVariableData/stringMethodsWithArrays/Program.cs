// We can use the [string] data type's Array methods to parse a larger string into an array.

string value = "abc123";
char[] valueArray = value.ToCharArray();
Console.WriteLine("From:\tstring value = 'abc123'\nTo:char[] valueArray = value.ToCharArray();");
Array.Reverse(valueArray);
Console.WriteLine("\nPrinting each element in our valueArray after reversing the original order:\n");
foreach (var element in valueArray)
{
    Console.WriteLine($"{element}");
}
string result = new string(valueArray); // here, the 'new' keyword is required!
Console.WriteLine($"Returning the array back to a string with: string result = string(valueArray);\n\n{result}\n");
Console.WriteLine("The expression above creates a new empty instance of the System.String class (which is the same as the string data type in C#)\nand passes in the char array as a constructor.\n");

char[] anotherArray = result.ToCharArray();
string anotherResult = string.Join(",", anotherArray);
Console.WriteLine($"Our array using string.Join() to add a comma to separate each element of our charArray and return a new string:\n{anotherResult}");

string[] items = anotherResult.Split(",");
Console.WriteLine("\nUsing the stringArray method .Split() to remove the commas we added to our previous array and storing the product in a new array:\nstring[] items = anotherResult.Split(',');\n");
foreach(string item in items)
{
    Console.WriteLine($"{item}");
}
//-----------------------------------------Microsoft Challenge: Reversing Words In A Sentence Challenge
//---------------------------------------------------------------Attempt #1:
        // Reverse the letters of each word of the pangram below and print the reversed results to the console.

// string pangram = "The quick brown fox jumps over the lazy dog";
// Console.WriteLine(pangram);
// string[] pangramSplit = pangram.Split(" ");
// string separator = " ";
// string[] newItems = new string[pangramSplit.Length];
// // foreach (var item in newItems)
// // {
// //     Console.WriteLine(item);
// // }
// foreach (var piece in pangramSplit)
// {   
//     char[] newPieces = piece.ToCharArray();
//     // for (int i = 0; i < newPieces.Length; i++)
//     // {
//     //     Console.WriteLine(newPieces[i]);
//     // }
//     Array.Reverse(newPieces);
//     Console.Write(newPieces);
//     string displayPieces = string.Join(" ", newPieces);
//     Console.Write(displayPieces);
// }
//---------------------------------------------------------------Attempt #2:
string pangram = "The quick brown fox jumps over the lazy dog";

// Step 1
string[] message = pangram.Split(' ');

//Step 2
string[] newMessage = new string[message.Length];

// Step 3
for (int i = 0; i < message.Length; i++)
{
    char[] letters = message[i].ToCharArray();
    Array.Reverse(letters);
    newMessage[i] = new string(letters);
}

//Step 4
string results = String.Join(" ", newMessage);
Console.WriteLine(results);

//-----------------------------------------Microsoft Challenge: Parse a string of orders, sort the orders, and tag possible errors
// We're provided with a variable containing a string of multiple order IDs separated by commas
string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
Console.WriteLine(orderStream);
// Parse the "order IDs" from the string of incoming orders and store the order IDs in an array
char[] charOrderStream = orderStream.ToCharArray();
string[] orderIDs = orderStream.Split(",");
foreach (var order in orderIDs)
{
    if(order.Length != 4)
    {
        Console.WriteLine($"{order}\t-Error");
    }
    else
    {
        Console.WriteLine(order);
    }
}

