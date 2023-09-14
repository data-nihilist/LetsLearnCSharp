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
Console.WriteLine("");
//----------------------------------Formatting Numbers
decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units"); // By default, the N numeric format specifier displays only two digits after the decimal point
Console.WriteLine($"Measurement: {measurement:N4} units"); // outputs: Measurement 123,456.7891 units
Console.WriteLine("");
//----------------------------------Formatting Percentages
decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}"); // outputs: Tax rate: 36.79 %
Console.WriteLine("");
//----------------------------------Combining Formatting Approaches
decimal newPrice = 67.55m;
decimal salePrice = 59.99m;

string yourDiscount = string.Format("You saved {0:C2} off the regular {1:C2} price.", (newPrice - salePrice), newPrice);

yourDiscount += $"\tA discount of {((newPrice - salePrice)/newPrice):P2}!"; // adding the percentage using string interpolation
Console.WriteLine(yourDiscount); // outputs: You saved $7.56 off the regular $67.55 price
Console.WriteLine("");
//----------------------------------Exploring String Interpolation
int invoiceNumber = 1201;
decimal productShares = 25.4568m;
decimal subtotal = 2750.00m;
decimal taxPercentage = .15825m;
decimal total = 3185.19m;

Console.WriteLine($"\nInvoice Number: {invoiceNumber}");

// Display the product shares with on thousandth of a share (0.001) precision
Console.WriteLine($"\t\tShares: {productShares:N3} Product");
// Display the subtotal that you charge the customer formatted as currency
Console.WriteLine($"\t\tSub Total: {subtotal:C}");
// Display the tax charged on the sale formatted as a percentage
Console.WriteLine($"\t\t\tTax: {taxPercentage:P2}");
// Finalize receipt with the total amount due formatted as currency
Console.WriteLine($"\t\tTotal Billed: {total:C}");
Console.WriteLine("");
//-----------------------------------------Padding: Adding whitespace before or after strings
string input = "Pad this";
Console.WriteLine(input.PadLeft(12));
Console.WriteLine(input.PadRight(12));
// An overloaded method is another version of the method with different or extra arguments that modify the functionality of the method slightly
Console.WriteLine(input.PadLeft(12, '-')); // be keen that we need to use single quotations for this method
Console.WriteLine(input.PadRight(12, '-'));
Console.WriteLine("");
string paymentId = "769C";
var formattedLine = paymentId.PadRight(6);
Console.WriteLine(formattedLine);
string payeeName = "Mr. Stephen Ortega";
formattedLine += payeeName.PadRight(24);
Console.WriteLine(formattedLine);
string paymentAmount = "$5,000.00";
formattedLine += paymentAmount.PadLeft(10);
Console.WriteLine(formattedLine);
Console.WriteLine("");
Console.WriteLine("1234567890123456789012345678901234567890");
Console.WriteLine(formattedLine);
Console.WriteLine("");
//----------------------------------Exercise: Format A Letter
string customerName = "Ms. Barros";
string currentProduct = "Magic Yield";
int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;
string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;
//-------------------------------------------------My logic here
string dearCustomer = $"Dear, {customerName}";
string intro = $"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n";
string current = $"Currently, you own {currentShares:N2} at a return of {currentReturn:P2}\n";
string pitch = $"Our new product, {newProduct} offers a return of {newReturn:P2}. Given your current volume, your potential profit would be {newProfit:C}\n";
Console.WriteLine(dearCustomer);
Console.WriteLine(intro);
Console.WriteLine(current);
Console.WriteLine(pitch);
Console.WriteLine("Here's a quick comparison:\n");
string comparisonMessage = "";
comparisonMessage = currentProduct.PadRight(20);
comparisonMessage += string.Format("{0:P}", currentReturn).PadRight(10);
comparisonMessage += string.Format("{0:C}", currentProfit).PadRight(20);
comparisonMessage += "\n";
comparisonMessage += newProduct.PadRight(20);
comparisonMessage += string.Format("{0:P}", newReturn).PadRight(10);
comparisonMessage += string.Format("{0:C}", newProfit).PadRight(20);
//-------------------------------------------------

Console.WriteLine(comparisonMessage);