// Use character escape sequences to add tabs, new lines, and Unicode characters to our strings.
// Create verbatim string literals, and escape common characters like backslash (\) and double-quotes(&quot;).
// Merge templates with variables using composite formatting and string interpolation.
// Include various format specifiers for percentages, currency, and numbers.


        // From a high-level perspective, software developers are concerned with:

        // Data Input: Including data typed in by a user from a keyboard, using their mouse, a device, or by another software system via a network request.
        // Data Processing: Including decision logic, manipulating data, and performing calculations.
        // Data Output: Including presentation to an end user via a:
        //               -command-line message
        //               -a window, a web page, or saving the processed data into a file, and sending it to a network service.

//-----------------------Composite Formatting
Console.WriteLine("Composite Formatting using the string helper method Format():");
string first = "Hello";
string second = "World";
string result = string.Format("{0} {1}!", first, second);
Console.WriteLine(result);
// Data types and variables of a given data type have built-in "helper methods" to make certain tasks easy.
// The literal string "{0} {1}!" forms a template, parts of which are replaced at run time.
// The token {0} is replaced by the first argument after the string template, in other words, the value of the variable first.
// The token {1} is replaced by the second argument after the string template, in other words, the value of the variable second.
Console.WriteLine("{1} {0}!", first, second);
Console.WriteLine("{0} {0} {0}!", first, second);

//------------------------------------------Simplifying composite formatting using String Interpolation
Console.WriteLine("\nSimplifying composite formatting using string interpolation:");
Console.WriteLine($"{first} {second}!");
Console.WriteLine($"{second} {first}!");
Console.WriteLine($"{first} {first} {first}!");

//----------------------------------------------Formatting Currency
decimal price = 123.45m;
int discount = 50;
Console.WriteLine($"Price: {price:C} (Save {discount:C})");
// Executing this code on a computer that has a Windows display language set to "english (United States)", you'll observe the following:
//                          Price: $123.45 (Save $50.00)

//                          In France:      Price: 123,45 € (Save 50,00 €)

// The reason for the previous "€" output is that the string currency formatting feature is dependent on the local computer setting for culture.
// In this context, the term "culture" refers to the country/region and language of the end user.
// The culture code is a five character string that computers use to identify the location and language of the end user.
// The culture code ensures certain information like dates and currency can be presented properly.

// For example:

// the culture code of an English speaker in the USA is en-US.
// the culture code of a French speaker in France is fr-FR.
// the culture code of a French speaker in Canada is fr-CA.
// The culture affects the writing system, the calendar that's used, the sort order of strings, and formatting for dates and numbers (like formatting currency).

// Unfortunately, making sure your code works correctly on all computers regardless of the country/region or the end user's language is challenging.
// This process is known as localization (or globalization).
// Localization depends on many factors not discussed in this module, but simply:
// The string formatting syntax may use a different format depending on the user's culture.

//----------------------------------Formatting Numbers
decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units"); // By default, the N numeric format specifier displays only two digits after the decimal point
Console.WriteLine($"Measurement: {measurement:N4} units"); // outputs: Measurement 123,456.7891 units
//----------------------------------Formatting Percentages
decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}"); // outputs: Tax rate: 36.79 %

//----------------------------------Combining Formatting Approaches
decimal newPrice = 67.55m;
decimal salePrice = 59.99m;

string yourDiscount = string.Format("You saved {0:C2} off the regular {1:C2} price.", (newPrice - salePrice), newPrice);

yourDiscount += $"\tA discount of {((newPrice - salePrice)/newPrice):P2}!"; // adding the percentage using string interpolation
Console.WriteLine(yourDiscount); // outputs: You saved $7.56 off the regular $67.55 price
