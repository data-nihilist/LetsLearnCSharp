Console.Clear();
Console.WriteLine("\n\tFood For Thought: Is it possible that attempting to change the value's data type would throw an exception at run time? See lines 4-6.\n");
Console.WriteLine("int first = 2;\nstring second = ''4''\nstring result = first + second\n");
int first = 2;
string second = "4";
string result = first + second; // int result = first + second; // error: [string] to [int]
Console.WriteLine("\tReferencing our code, on line 6: If we initialized result as an [int] data type, the compiler will throw an error: cannot do [string] to [int]\n");
Console.WriteLine($"\tInitializing result as a [string], the compiler concatenates [int]2 + [string]4, resulting with: {result}\n");

string[] intro =
{
    "\t\tTo perform data conversion, we can use one of several techniques:\n",
    "\t\tUse a helper method on the data type.\n",
    "\t\tUse a helper method on the variable itself.\n",
    "\t\tUse the Convert class' methods.\n",
    "With these things in mind: Is it possible that attempting to change the value's data type to result in the loss of information??\n\n"
};

for (int i = 0; i < intro.Length; i++)
{
    Console.WriteLine(intro[i]);
}

//-------------------------------------------------------------------------------------------Widening Conversion:
Console.WriteLine("\t\t\t\t\tWidening Conversion\n");

int myInt = 3;
decimal myDecimal = myInt;

Console.WriteLine($"Converting a value like so: couldHoldLess = couldHoldMore\t\tint to be widened: {myInt}\n");
Console.WriteLine($"Any [int] value can easily fit inside of a [decimal] value:\t\tdecimal: {myDecimal}\tThe compiler performs an Implicit Conversion.\n");
//-------------------------------------------------------------------------------------------Narrowing Conversion:
Console.WriteLine("\t\t\t\t\tNarrowing Conversion\n");
Console.WriteLine("Converting a value like so: ([cast]) => differingTypeDataValue\n");
decimal myDecimal2 = 3.14m;
Console.WriteLine($"\ndecimal2: {myDecimal2}\n");
Console.WriteLine("We explicitly instruct the compiler, `I know I'll lose the data after the decimal point.`\n");
int myInt2 = (int)myDecimal;
Console.WriteLine($"int2:{myInt2}\tThe compiler performs an Explicit Conversion.\n");

//--------------------------------------------------------------------------------------------Determining if a conversion is 'widening' or 'narrowing'

decimal anotherDecimal = 1.23456789m;
float myFloat = (float)anotherDecimal;

Console.WriteLine($"\ndecimal anotherDecimal = {anotherDecimal}");
Console.WriteLine($"float myFloat = (float)anotherDecimal\t\tOutput: {myFloat}  (We've lost precision.)");
Console.WriteLine("Which means this is a narrowing conversion.\n");

//--------------------------------------------------------------------------------------------Performing Data Conversions:
// ToString() to convert a number to a string

int third = 5;
int fourth = 7;
string message = third.ToString() + fourth.ToString();
Console.WriteLine($"Message: {message}");

// Parse() to convert a string to a number

string fifth = "5";
string sixth = "7";
int sum = int.Parse(fifth) + int.Parse(sixth);
Console.WriteLine("Sum: " + sum);
Console.WriteLine("The easiest way to mitigate this situation is by using TryParse(), which is a better version of the Parse method\n");

//----------------------------------------------------------What if either of the variables from above are set to values that can't be converted to an [int]?
// TryParse() method from the Convert class

string value1 = "5";
string value2 = "7";
int result2 = Convert.ToInt32(value1) * Convert.ToInt32(value2);
Console.WriteLine(result2);

int value3 = (int)1.5m; // casting truncates (rounds down)

int value4 = Convert.ToInt32(1.5m); // converting rounds up

string[] onToInt32 =
{
    "\nWhy is the method name ToInt32() and not just ToInt()?\n",
    "System.Int32 is the name of the underlying data type in the .NET Class Library that the C# programming language maps to the keyword [int].\n",
    "Because the Convert class is also part of the .NET Class Library, it is called by its full name, not its C# name.\n",
    "By defining data types as part of the .NET Class Library, multiple .NET languages like Visual Basic, F#, IronPython, and others can share the same data types and the same classes in the .NET Class Library.\n",
    "ToInt32() method has 19 overload versions allowing it to accept virtually every data type.\n",
    "We used the Convert.ToInt32() method with a string here, but we should probably use TryParse() when possible.\n",
    "So, when should we use the Convert class?\n",
    "The Convert class is best for converting fractional numbers into whole numbers [int] because it rounds up the way you would expect.\n",
    $"int value3 = (int)1.5m;\t\t\toutputs: {value3}\tThis truncates the value (rounds down)",
    $"int value4 = Convert.ToInt32(1.5m);\toutputs: {value4}\tThis rounds the value up",
    "\n\n\t\t\t\tQuick Q&A",
    "\nWhich is the best technique to convert a decimal type to an int type in C#?",
    "\nCasting. [decimal] to [int] is a narrowing conversion, so, cast is the best option.",
    "\nGive an example of a conversion that rounds up (as opposed to truncating) a value:",
    "\nint cost = Convert.ToInt32(3.75m);"
};

for (int i = 0; i < onToInt32.Length; i++)
{
    Console.WriteLine(onToInt32[i]);
}

//------------------------------------------------------------------------------------------------Examining the TryParse() method

// Sometimes you need to convert a string data into a numeric data type.

            //          As we learned in the previous section, because the string data type can hold a non-numeric value,
            //          it's possible that performing a conversion from a [string] into a numeric data type causes a runtime error.
// string name = "Bob";
// Console.WriteLine(int.Parse(name)); // Throws error: 'The input string was not in a correct format.

//------------------------------------------------------------------------------------------------Using the TryParse() method
string[] onMethods = 
{   
    "\n\t\t\t\tOn Methods\n",
    "TryParse() attempts to parse a string into the given numeric data type.\n",
    "If successful, it stores the converted value in an out parameter, explained below.\n",
    "This returns a [bool] to indicate whether the action succeeded or failed.\n",
    "Methods can return a value or return `void`, meaning they return no value.\n",
    "Methods can also return values through Out Parameters, which are defined just like an input parameter, but include the out keyword.\n"
};

for (int i = 0; i < onMethods.Length; i++)
{
    Console.WriteLine(onMethods[i]);
};
//-----------------------------------------------------------------------------------------------TryParse() a [string] into an [int]
// string value5 = "bad"; // Comment in to throw an error
string value5 = "102"; // Comment out to throw an error
int result3 = 0;
if (int.TryParse(value5, out result3))
{
    Console.WriteLine($"Measurement: {result3}");
}
else
{
    Console.WriteLine("\t\t\tIGNORE THIS LINE. SEE CODE SECTION LINE 118-135 FOR CONTEXT.");
}
//-------------------------added to throw error-------------------//
if (result3 > 0)                                                  //
{                                                                 //
    Console.WriteLine($"Measurement (w/ offset): {50 + result3}");//
}                                                                 //
//----------------------------------------------------------------//
string[] onTryParse = 
{
    "\n\t\t\t\tOn The TryParse() Method\n",
    "When calling a method with an [out] parameter, you must use the keyword `out` before the variable, which holds the value.\n",
    "The [out] parameter is assigned to the `result5` variable declared above in the code (int.TryParse(value5, out result3)).\n",
    "You can then use the value the [out] parameter contains throughout the rest of your code using the variable result5.\n",
    "\nThe int.TryParse() method returns `true` if it successfully converted the [string] variable value into an [int]; otherwise it returns false.\n",
    "So, surround the statement in an `if` statement, and then perform the decision logic accordingly.\n",
    "\n\t\t\t\tReferencing our code:\n",
    "The converted value is stored in the [int] variable result3. The [int] variable result3 is declared and initialized before this line of code.\n",
    "This means result3 should be accessible both inside the code blocks that belong to the if and else statements, as well as outside of them!\n",
    "The `out` keyword instructs the compiler that the TryParse() method won't return a value the traditional way only (as a return value), but also will communicate an output through this two-way parameter.\n",
    "Adding to our code: Console.WriteLIne($''Measurement (w/ offset): {50 + result3}'');\n",
    $"Outputs:  Measurement (w/ offset): {50 + result3})\n",
    "See code lines 118-135 for more on this topic, and why you saw that message up above.\n"
};

for(int i = 0; i < onTryParse.Length; i++)
{
    Console.WriteLine(onTryParse[i]);
}

string[] quickRecap = 
{
    "\n\t\t\t\tOn The TryParse() Method\n",
    "Use TryParse() when converting a string into a numeric data type.\n",
    "TryPrase() returns `true` if the conversion is successful, `false` if it's unsuccessful.\n",
    "Out parameters provide a secondary means of a method returning a value; In this case, the out parameter returns the converted value.\n",
    "Use the keyword out when passing in an argument to a method that has defined an out parameter.\n"
};

for (int i = 0; i < quickRecap.Length; i++)
{
    Console.WriteLine(quickRecap[i]);
}

string checkString = "2.71828";
decimal checkResult = 0;
decimal.TryParse(checkString, out checkResult);
Console.WriteLine(checkResult);

//------------------------------------------------------Microsoft Challenge: Combine string array values as strings and as integers
string[] values = { "12.3", "45", "ABC", "11", "DEF" };
                                    // Expected output:
                                            // Message: ABCDEF
                                            // Total: 68.3

decimal total = 0m;
string alphabeticalElements = "";

foreach (var value in values)
{
    decimal number; // storing the TryParse "out" value
    if (decimal.TryParse(value, out number))
    {
        total += number;
    }
    else
    {
        alphabeticalElements += value;
    }
}
Console.WriteLine("\n\n\t\t\t\tMicrosoft Challenges Output: (reference code past line 177)");
Console.WriteLine($"Message: {alphabeticalElements}");
Console.WriteLine($"Total: {total}\n");
//-------------------------------------------------------------
int challengeValue1 = 12;
decimal challengeValue2 = 6.2m;
float challengeValue3 = 4.3f;

// Your code here to set challengeResult1
// Hint: ;You need to round the result to nearest integer (don't just truncate)
int challengeResult1 = Convert.ToInt32((decimal)challengeValue1 / challengeValue2);

Console.WriteLine($"Dividing value1 by value2.\tThe result as an int:\t\t{challengeResult1}");

// Your code here to set challengeResult2
decimal challengeResult2 = challengeValue2 / (decimal)challengeValue3;

Console.WriteLine($"Dividing value2 by value3.\tThe result as a decimal:\t{challengeResult2}");

// Your code here to set challengeResult3
float challengeResult3 = challengeValue3 / challengeValue1;

Console.WriteLine($"Dividing value3 by value1.\tThe result as a float:\t\t{challengeResult3}");

//---------knowledge checks
Console.WriteLine("\n\t\t\t\tKnowledge Check\n");

// string knowledge = "4.123456789";
// Console.WriteLine((decimal)knowledge); // Comment in to see error: 'Cannot convert type string to int'

Console.WriteLine("Check 1: We shouldn't try to cast (decimal) against a string of a decimal because we cannot convert a type [string] into an [int]\n");

string knowledgeForCheck2 = "4.123456789";

decimal check2UsingDecimalTryParse = 0;

if (decimal.TryParse(knowledgeForCheck2, out check2UsingDecimalTryParse)){
    Console.WriteLine($"Check 2: {check2UsingDecimalTryParse}\n");
}

string knowledgeForCheck3 = "4.123456789";

decimal check3UsingConvertClassMethod = Convert.ToDecimal(knowledgeForCheck3);

Console.WriteLine($"Check 3: {check3UsingConvertClassMethod}\n");

string[] summary =
{   
    "\n\t\t\t\tIn Summary\n",
    "Our goal was to use several different techniques to change the data type of a given value.\n",
    "We used Implicit Conversion, relying on the C# compiler to perform Widening Conversions:\n",
    "\t-When the compiler was unable to perform an implicit conversion, we used Explicit Conversions.\n",
    "\t-We used the ToString() method to explicitly convert a numeric data type into a [string].\n\n",
    "When we needed to perform Narrowing Conversions, we used several different techniques:\n",
    "\t-We used the casting operator () when the conversion could be made safely and were willing to accept truncation of values after the decimal.\n",
    "\t-We also used the Convert() method when we wanted to perform a conversion and use common rounding rules when performing a narrowing conversion.\n\n",
    "Finally, we used the TryParse() methods when the conversion from a [string] to a numeric data type could potentially result in a data type conversion exception.\n",
    "Use this newfound knowledge to build error free applications!"
};

for (int i = 0; i < summary.Length; i++)
{
    Console.WriteLine(summary[i]);
}