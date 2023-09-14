// We can quickly structure programs just by naming your tasks as methods,
//then filling in the logic after you've identified all the necessary tasks.
//---------------------------------------------------------------------------Using methods to structure code
// Suppose we're candidates in a coding interview:
// The interviewer wants us to write a program that checks whether an IPv4 address is valid or invalid.
// We're given the following rules:
// 1. A valid IPv4 address consists of four numbers separated by dots
// 2. Each number must not contain leading zeroes
// 3. each number must range from 0 - 255

// 1.1.1.1 and 255.255.255.255 are examples of valid IP addresses.

// The IPv4 address is provided as a string.
// We can assume that it only consists of digits and dots (there are no letters in the provided string)

// ** Even if we aren't familiar with IP addresses, we can still tackle this problem! Let's jump in.

//----------------------------------------------Step 1: Breaking down the problem:

/*
if ipAddress consists of 4 numbers
and
if each ipAddress number has no leading zeroes
and
if each ipAddress number is in range 0 - 255

then ipAddress is valid

else ipAddress is invalid
*/

//--------------Transform the above pseudo-code into callable methods and output results:

// if (ValidateLength() && validateZeroes() && ValidateRange())
// {
//     Console.WriteLine($"ip is a valid IPv4 address");
// }
// else
// {
//     Console.WriteLine($"ip is an invalid IPv4 address");
// }

// //--------------Create our methods being called above:

// string ipv4Input = "107.31.1.5";
string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" }; // It's important to test code with different input cases.
string[] address; // update
bool validLength = false;
bool validZeroes = false;
bool validRange = false;

foreach (string ip in ipv4Input)
{
    address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);

    ValidateLength();
    ValidateZeroes();
    ValidateRange();

    if (validLength && validZeroes && validRange)
    {
        Console.WriteLine($"{ip} is a valid IPv4 address");
    }
    else
    {
        Console.WriteLine($"{ip} is an invalid IPv4 address");
    }
}
//-------------------methods
void ValidateLength()
{
    // string[] address = ipv4Input.Split("."); // update
    validLength = address.Length == 4;
}

void ValidateZeroes()
{
    // string[] address = ipv4Input.Split("."); // update
    foreach (string number in address)
    {
        if (number.Length > 1 && number.StartsWith("0"))
        {
            validZeroes = false;
            return;
        }
    }

    validZeroes = true;
}

void ValidateRange()
{
    // string[] address = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries); // update
    // StringSplitOptions.RemoveEmptyEntries omits empty entries from the address array and prevents attempts to

    foreach (string number in address)
    {
        if (int.Parse(number) > 255)
        {
            validRange = false;
            return; // the return keyword can be used here to terminate method execution
        }
    }
    validRange = true;
}

Console.WriteLine();
//------------------------------------------------------------------------------------Telling A Fortune

Random random = new Random();
int luck = random.Next(100);
// int luck = 20; // testing

string[] text =
{
    "You have much to",
    "Today is a day to",
    "Whatever work you do",
    "This is an ideal time to",
};
string[] good =
{
    "look forward to.",
    "try new things!",
    "is likely to success.",
    "accomplish your dreams!"
};
string[] bad =
{
    "fear.",
    "avoid major decisions.",
    "may have unexpected outcomes.",
    "re-evaluate your life."
};
string[] neutral =
{
    "appreciate.",
    "enjoy time with friends.",
    "should align with your values.",
    "get in tune with nature."
};

Console.WriteLine($"Your current luck stat is: {luck}");
Console.WriteLine("A fortune teller whispers the following words:");
TellFortune();

// string [] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));

// for (int i = 0; i < 4; i++)
// {
//     Console.Write($"{text[i]} {fortune[i]} ");
// };

void TellFortune()
{
    string textLine = text[random.Next(1, text.Length)];

    if (luck > 75)
    {
        string goodResult = good[random.Next(good.Length)];
        Console.WriteLine(textLine + " " + goodResult);
    }
    else if (luck < 25)
    {
        string badResult = bad[random.Next(bad.Length)];
        Console.WriteLine(textLine + " " + badResult);
    }
    else
    {
        string neutralResult = neutral[random.Next(neutral.Length)];
        Console.WriteLine(textLine + " " + neutralResult);
    }
};
//------------------------------For fun, trying to implement a switch statement, but it isn't necessarily warranted here
    // switch($"{luck}") // error: can't implicitly convert type 'bool' to 'int'
    // {
    //     case (luck > 75):
    //         string goodResult = good[random.Next(1, good.Length)];
    //         Console.WriteLine(textLine + " " + goodResult);
    //         break;
        
    //     case (luck < 25):
    //         string badResult = bad[random.Next(1, bad.Length)];
    //         Console.WriteLine(textLine + " " + badResult);
    //         break;
        
    //     default:
    //         string neutralResult = neutral[random.Next(1, neutral.Length)];
    //         Console.WriteLine(textLine + " " + neutralResult);
    //         break;
    // }
// }
Console.WriteLine();
string[] recap =
{   
    "\t\t\t\tQuick Recap\n",
    "Example of correctly declaring a method:\tvoid DisplayNumbers() { };\n",
    "Example of correctly calling a method:\t\tGenerateID();\n",
    "The return keyword can be used to terminate the execution of a method."
};

foreach (string line in recap)
{
    Console.WriteLine(line);
}