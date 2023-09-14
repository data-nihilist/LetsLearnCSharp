//---------------------------Writing code to find parenthesis pairs embedded in string
string message = "Find what is (inside the parentheses)";

int openingPosition = message.IndexOf('(');
int closingPosition = message.IndexOf(')');

Console.WriteLine(openingPosition); // outputs 13
Console.WriteLine(closingPosition); // outputs 36

// int length = closingPosition - openingPosition;
// Console.WriteLine(message.Substring(openingPosition, length)); // failure

// The Substring() method needs the starting position and the number of characters, or length, to retrieve.
// We calculated the length in a temporary variable, length, and pass it with the openingPosition to retrieve the string inside the parenthesis.
// The current result is close, however the output includes the opening parentheses.
// We need to update the code so that we skip the index of the parenthesis itself.

openingPosition += 1; // iykyk: calculate the length of the

int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length)); // success!

Console.WriteLine("");

string message2 = "\nWhat is the value <span>between the tags</span>?";

// const string openSpan = "<span>";
// const string closeSpan = "</span>";

// Console.WriteLine(openSpan);
// Console.WriteLine(closeSpan);
const string openSpan = "<span>"; // declaring 'magic number'
const string closeSpan = "</span>"; // declaring 'magic number'
                    /*
                                Avoid hardcoded magic values.
                                Instead, define a const variable.
                                A constant variable's value can't be changed after initialization.
                    */

int openingPosition2 = message2.IndexOf(openSpan);
int closingPosition2 = message2.IndexOf(closeSpan);

// openingPosition2 += openSpan.Length; // close
openingPosition2 += openSpan.Length; //success! The length of openingPosition2 is used to calculate the offset for length.

int length2 = closingPosition2 - openingPosition2;
Console.WriteLine(message2.Substring(openingPosition2, length2));

Console.WriteLine("");

//-------------------------------------------[string]'s IndexOfAny() && LastIndexOf() helper methods

//------Retrieving The Last Occurrence Of A Sub String
string message3 = "(What if) I am (only interested) in the last (set of parentheses)?";
int openingPosition3 = message3.LastIndexOf('(');

openingPosition3 += 1;
int closingPosition3 = message3.LastIndexOf(')');
int length3 = closingPosition3 - openingPosition3;
Console.WriteLine(message3.Substring(openingPosition3, length3));

Console.WriteLine("");
//------Retrieving All Instances Of Substrings Inside Parentheses
string message4 = "(What if) there are (more than) one (set of parentheses)?";
while(true)
{
    int openingPosition4 = message4.IndexOf('(');
    if (openingPosition4 == -1) break;    // The IndexOf() method returns -1 if it can't find the input parameter
                                          // in the string. You merely check for the value -1 and break out of the loop.

    openingPosition4 += 1;
    int closingPosition4 = message4.IndexOf(')');
    int length4 = closingPosition4 - openingPosition4;
    Console.WriteLine(message4.Substring(openingPosition4, length4));
/*
                        When you use Substring() without specifying a length input parameter,
                        it will return every character after the starting position you specify.
                        Since message = "(What if) there are (more than) one (set of parentheses)?" there's 
                        advantage to removing the first set of parentheses (What if) from the value of message.

                        What remains is then processed in the next iteration of the while loop*.
        *(line 84)
*/
    message4 = message4.Substring(closingPosition4 + 1);
}

Console.WriteLine("");
//---------------------------- -------------------------working with different types of symbol sets
string message9 = "Help (find) the {opening symbols}";
Console.WriteLine($"Searching THIS Message: {message9}");
char[] openSymbols = { '[', '{', '(' };
int startPosition = 6;
int openingPosition9 = message9.IndexOfAny(openSymbols);
Console.WriteLine($"Found WITHOUT using startPosition: {message9.Substring(openingPosition9)}"); // failure

openingPosition9 = message9.IndexOfAny(openSymbols, startPosition);
Console.WriteLine($"Found WITH using startPosition: {message9.Substring(openingPosition9)}"); // success!

Console.WriteLine("");

string messageX = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// The IndexOfAny() helper method requires a char array of characters.
// We want to look for:

char[] openSymbolsX = { '[', '{', '(' };

// We'll use a slightly different technique for iterating through the characters in the string.
// This time, use the closingPosition of the previous iteration as the starting index for the
//next open symbol. So, we need to initialize the closingPosition variable at zero:

int closingPositionX = 0;

while(true)
{
    int openingPositionX = messageX.IndexOfAny(openSymbolsX, closingPositionX);

    if (openingPositionX == -1) break;

    string currentSymbolX = messageX.Substring(openingPositionX, 1);

    // Now find the matching closing symbol
    char matchingSymbolX = ' ';

    switch (currentSymbolX)
    {
        case "[":
            matchingSymbolX = ']';
            break;
        
        case "{":
            matchingSymbolX = '}';
            break;
        
        case "(":
            matchingSymbolX = ')';
            break;
    }

    // To find the closingPosition, use an overload of the IndexOf method to specify that the search for
    //the matchingSymbol should start at the openingPosition in the string.

    openingPositionX += 1;
    closingPositionX = messageX.IndexOf(matchingSymbolX, openingPositionX);
    // The variable closingPositionX is used in the Substring() method, but is also used to find the next openingPositionX
    //value:        (line 117): int openingPositionX = messageX.IndexOfAny(openSymbolsX, closingPositionX);
    // For this reason, the closingPositionX variable is defined outside of the while loop scope and initialized to 0 for the first iteration.

    // Finally, we use the techniques we've already learned to display the sub-string:

    int lengthX = closingPositionX - openingPositionX;
    Console.WriteLine(messageX.Substring(openingPositionX, lengthX));
}

//                  LastIndexOf()   :   returns the last position of a character or string inside of another string.
//                  IndexOfAny()    :   returns the first position of an array of char that occurs inside of another string.

Console.WriteLine("");
//------------------------------------------------------Exercise: Use the Remove() and Replace() methods

// Removing characters in specific locations from a string
string data = "12345John Smith          5000  3  ";
string updatedData = data.Remove(5, 20); // Removes 'John Smith' && stores the value into a variable
Console.WriteLine(updatedData);

                                // The Remove() method works similarly to the Substring() method.
                                // You supply a starting position and the length to remove those characters from the string.

Console.WriteLine("");

// Removing characters no matter where they appear in a string
string message8 = "This--is--ex-amp-le--da-ta";
message8 = message8.Replace("--", " ");
message8 = message8.Replace("-", "");
Console.WriteLine(message8); // outputs: "This is example data"

                            // Here you used the Replace() method twice.
                            // The first time you replaced the string -- with an empty space.
                            // The second time you replaced the string with an empty string, which completely removes the character from the string.
    
    //  The Remove()    :   Works like the Substring() method, except that it deletes the specified characters in the string.
    //  The Replace()   :   Swaps all instances of a string with a new string.

Console.WriteLine("");
//-----------------------------------------------------Microsoft Challenge: Extract, Replace, and Remove data from an input string Challenge
const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

Console.WriteLine("Provided Code: " + input);

Console.WriteLine("");

string quantity = "";
string output7 = input.Remove(0, 5);

int updatedOutputOpeningPosition = output7.LastIndexOf('<');
int updatedOutputClosingPosition = output7.LastIndexOf('>');
Console.WriteLine("Updated Output Opening Position: " + updatedOutputOpeningPosition);
Console.WriteLine("Updated Output Closing Position: " + updatedOutputClosingPosition);


// Console.WriteLine(output7.Length - 1);
int lengthB = (updatedOutputClosingPosition - updatedOutputOpeningPosition) + 1;
Console.WriteLine("Length: " + lengthB);

//--------------------------------------Code Here
const string openSpan7 = "<span>"; // declaring 'magic number'
const string closeSpan7 = "</span>"; // declaring 'magic number'

                    /*
                                Avoid hardcoded magic values.
                                Instead, define a const variable.
                                A constant variable's value can't be changed after initialization.
                    */

int quantityOpeningPosition = input.IndexOf(openSpan7);
int quantityClosingPosition = input.IndexOf(closeSpan7);

// quantityOpeningPosition += openSpan7.Length; // close
quantityOpeningPosition += openSpan7.Length; //success! The length of quantityOpeningPosition is used to calculate the offset for length.

int length7 = quantityClosingPosition - quantityOpeningPosition;
string finalOutput = output7.Remove(updatedOutputOpeningPosition, lengthB);
//--------------------------------------
Console.WriteLine("Quantity: " + input.Substring(quantityOpeningPosition, length7));
Console.WriteLine("Output: " + finalOutput);