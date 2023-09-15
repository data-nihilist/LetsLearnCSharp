//------------------------------Adding parameters to our methods B)

// Information consumed by a method is called a parameter.
// We can supply as many parameters as needed to accomplish its task or, none at all as seen in previous lessons.

/*

CountTo(5)

void CountTo(int max)  // Declaring Parameters: Specifying the data type followed by the name of the parameter
{
    for (int i = 0; i < max; i++) // Here we're referencing the declared parameter in our for-loop
    {
        Console.WriteLine($"{i}, ");
    }
};

*/

using System.Runtime.InteropServices;

int[] schedule = { 800, 1200, 1600, 2000 };
DisplayAdjustedTimes(schedule, 6, -6);

void DisplayAdjustedTimes(int[] times, int currentGMT, int newGMT) // Multiple params are separated by commas
{
    int diff = 0;

    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
    {
        Console.WriteLine("Invalid GMT");
    }
    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
    {
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
    }
    else
    {
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
    }

    for (int i = 0; i < times.Length; i++)
    {
        int newTime = ((times[i] + diff)) % 2400;
        Console.WriteLine($"{times[i]} -> {newTime}");
    }
}

// We don't have to declare the variables newGMT and currentGMT since they're already declared in the method signature.
// We also don't initialize the variables since the method assumes the caller supplies those arguments with assigned values.

//-------------------------------------------------------------------------Method Scope
// 'Scope' is the region of a program where certain data is accessible
// Variables declared within the scope of a method are only accessible within that method.

string[] students = { "Jenna", "Ayesha", "Carlos", "Viktor" };

DisplayStudents(students); // Using a global variable we declared up above
DisplayStudents(new string[] {"Robert", "Vaynya"}); // Using a locally scoped variable that's called in the caller B)

void DisplayStudents(string[] students)
{
    foreach (string student in students)
    {
        Console.Write($"{student}, ");
    }
    Console.WriteLine();
}

DisplayNumbers();

void DisplayNumbers()
{
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7}; // This variable is locally scoped to the DisplayNumbers() method as well
    foreach (int number in numbers)
    {
        Console.Write(number);
    }
    Console.WriteLine();
}
Console.WriteLine();

//------------------------------------------------------Playing around with scope

double pi = 3.14159; // This variable needs to be declared ABOVE the call of a function that depends on it
PrintCircleInfo(12);
PrintCircleInfo(24);

// double pi = 3.14159; // Error

void PrintCircleInfo(int radius)
{
    Console.WriteLine($"Circle with radius {radius}");
    PrintCircleArea(radius);
    PrintCircleCircumference(radius);
}


void PrintCircleArea(int radius)
{
    // double pi = 3.14159;     // variables pi && radius are accessible only within the scope of PrintCircleArea()
    double area = pi * (radius * radius);
    Console.WriteLine($"Using {radius}, Area = {area}");
}

void PrintCircleCircumference(int radius)
{
    // double pi = 3.14159;
    double circumference = 2 * pi * radius;
    Console.WriteLine($"Using {radius}, Circumference = {circumference}");
}

// Since pi is set to the same fixed value and used in both of the methods above, pi should be a globally scoped variable.

Console.WriteLine();
//--------------------------------------------Using value and reference type parameters

// Value type parameters

int a = 3;
int b = 4;
int c = 0;

Multiply(a, b, c);
Console.WriteLine($"global statement: {a} x {b} = {c}");

void Multiply(int a, int b, int c)
{
    c = a * b;
    Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
}

Console.WriteLine();

int[] array = { 1, 2, 3, 4, 5 };

PrintArray(array); // outputs: 1 2 3 4 5 (the values of int[] array)
Clear(array); // sets our array values all to 0
PrintArray(array); // appends 0 0 0 0 0 to our previous output (the values of int[] array have been mutated by Clear())

void PrintArray(int[] array)
{
    foreach (int a in array)
    {
        Console.Write($"{a} ");
    }
}

void Clear(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = 0;
    }
}
Console.WriteLine();
//----------------------------------------------Testing with strings
Console.WriteLine();
string status = "Healthy";

Console.WriteLine($"Start: {status}");
SetHealth(/*status, */false);
Console.WriteLine($"End: {status}");

void SetHealth(/*string status, */bool isHealthy)
{
    status = isHealthy ? "Healthy" : "Unhealthy"; // overwriting the global status variable with a new string value
    Console.WriteLine($"Middle: {status}");
}

Console.WriteLine();
//---------------------------------------------Methods with optional parameters

string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
string[] rsvps = new string[10];
int count = 0;

// RSVP("Rebecca", 1, "none", true);
// RSVP("Nadia", 2, "Nuts", true);
// RSVP( name: "Linh", partySize: 2, allergies: "none", inviteOnly: false); // using named arguments for code clarity
// RSVP("Tony", partySize: 1, allergies: "Jackfruit", true); // name and inviteOnly are now positional arguments, meaning they need to be in the order in which we defined the method
// RSVP("Noor", 4, "none", false);
// RSVP( partySize: 2, name: "Jonte", inviteOnly: false, allergies: "Stone fruit"); // When using all named arguments, position is irrelevant
// ShowRSVPs();

RSVP("Rebecca");
RSVP("Nadia", 2, "Nuts");
RSVP("Linh", partySize: 2, inviteOnly: false);
RSVP("Tony", allergies: "Jackfruit", inviteOnly: true);
RSVP("Noor", 4, inviteOnly: false);
RSVP("Jonte", 2, "Stone fruit", false);
ShowRSVPs();



// void RSVP(string name, int partySize, string allergies, bool inviteOnly)
void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)  //------using optional parameters:
{
    if (inviteOnly)
    {
        // search guestList before adding rsvp
        bool found = false;
        foreach (string guest in guestList)
        {
            if(guest.Equals(name))
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Sorry, {name} is not on the guest list.");
            return;
        }
    }

    rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
    count++;
}

void ShowRSVPs()
{
    Console.WriteLine("\nTotal RSVPs:");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(rsvps[i]);
    }
}

//------------------------------------Microsoft Challenge: Add a method to display email addresses challenge
Console.WriteLine("\t\t\t\tChallenge\n");
//-----------provided code
string[,] corporate =
{
    { "Robert", "Bavin" }, { "Simon", "Bright" },
    { "Kim", "Sinclair" }, { "Aashrita", "Kamath" },
    { "Sarah", "Delucchi" }, { "Sinan", "Ali" }
};
string[,] external = 
{
    { "Vinnie", "Ashton" }, { "Cody", "Dysart" },
    { "Shay", "Lawrence" }, { "Daren", "Valdes" }
};

Emails(corporate, "contoso.com");
Emails(external, "hayworth.com");

void Emails(string[,] array, string domain)
{
    for (int i = 0; i< array.GetLength(0); i++)
    {
        // display internal email addresses
        string firstName = array[i, 0];
        string processedFirstName = firstName.ToLower();
        string choppedFirstName = processedFirstName.Substring(0, 2);
        string lastName = array[i, 1];
        string processedLastName = lastName.ToLower();
        string email = $"{choppedFirstName}{processedLastName}@{domain}";
        Console.WriteLine(email);
    }
}