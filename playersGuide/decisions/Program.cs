
ConvertClassReferenceTable();

void ConvertClassReferenceTable()
{   
    Console.WriteLine("\t\tConversion Reference Table\n");
string[] columns = { "Method Name", "Target Type" };
string[,] methods = {
    { "ToByte", "byte" },
    { "ToInt16", "short" },
    { "ToInt32", "int" },
    { "ToInt64}", "long" },
    { "ToChar", "char" },
    { "ToSingle", "float" },
    { "ToDecimal", "decimal" },
    { "ToSByte", "sbyte" },
    { "ToUInt16", "ushort" },
    { "ToUInt32", "uint" },
    { "ToUInt64", "ulong" },
    { "ToString", "string" },
    { "ToDouble", "double" },
    { "ToBoolean", "bool" }
};

Console.WriteLine("<<type> <variableName> = Convert.<MethodName(referenceVariableToConvert)>>\n");

    foreach (string column in columns)
    {
        Console.Write($"\t{column}");
    }
    Console.WriteLine();
    for(int i = 0; i < methods.Length / 2; i++)
    {
        Console.WriteLine($"{methods[i, 0]}:   {methods[i, 1]}");
    }
}

Console.WriteLine("\t\t\t\tRepairing The Clocktower\n");
Console.WriteLine("The recent attacks damaged the great Clocktower of Consolas. The citizens of Consolas have repaired most of it, except\none piece that requires the steady hand of a Programmer. It is the part that makes the clock tick and tock. Numbers\nflow in to the clock to make it go, and if the number ise ven, the clock's pendulum should 'tick' to the left, if the\nnumber is odd, the pendulum should 'tock' to the right. Only a programmer can recreate this critical clock element to\nmake it work again.");
Console.WriteLine();
/*
Take a number as input from the console.
Display the word "Tick" if the number is even.
Display the word "Tock" if the number is odd.

// my notes
- clocks only ever work with whole numbers, so edge cases involving partial numbers (decimals) isn't a concern.
*/

TickTock();

void TickTock()
{
    Console.WriteLine("Which hour is it?");

    string? timeCheck = Console.ReadLine();
    int tickOrTock = Convert.ToInt32(timeCheck);

    if (tickOrTock % 2 == 0)
    {
        Console.WriteLine("Tick");
    }
    else
    {
        Console.WriteLine("Tock");
    }
}

Console.WriteLine("\t\t\t\tBuying Inventory\n");
Console.WriteLine("It is time to resupply. A nearby outfitter shop has the supplies you need but is so disorganized that they\ncannot sell things to you. `Can't sell if I can't find the price list,` Tortuga, the owner,\ntells you as he turns over and attempts to go back to sleep in his reclining chari in the corner.\nThere's a simple solution: use your programming powers to build\nsomething to report the prices of various pieces of equipment based on the user's selection.\n");
Console.WriteLine();
/*
You search around the shop and find ledgers showing the prices for these items:
Rope: 10 gold
Torches: 16 gold,
Climbing Equipment: 24 gold,
Clean Water: 2 gold,
Machete: 20 gold,
Canoe: 200 gold,
Food Supplies: 2 gold

Build a program that will show the menu illustrated above.
Ask the user to enter a number from the menu.
Using the information above, use a switch (either statement or expression) to show the item's cost.
*/

BuyingInventory();

void BuyingInventory()
{
    string[,] itemsForSale = 
    {
        { "Rope", "10" },
        { "Torches", "16" },
        { "Climbing Equipment", "24" },
        { "Clean Water", "2" },
        { "Machete", "20" },
        { "Canoe", "200" },
        { "Food Supplies", "2" },
    };
    
    Console.WriteLine("What are ye intristeddin' buyin'?");
    for(int i = 0; i < itemsForSale.Length / 2; i++)
    {
        Console.WriteLine($"{i + 1} - {itemsForSale[i, 0]}");
    }
    Console.WriteLine("Enter the number corresponding to the item you'd like to get the price of.");
    int choice = Convert.ToInt32(Console.ReadLine());

    int price = int.Parse(itemsForSale[choice - 1, 1]);

    Console.WriteLine("Say, remind me yer name, friend.");
    string? playerName = Console.ReadLine();

    if(playerName == "Matthew")
    {
        price /= 2;
        Console.WriteLine("Ah, great to see you Matthew. Thank you for helping my shop get back in business. Enjoy a discount while yer in town.");
    }
    else
    {
        Console.WriteLine("Thanks fer comin' in today. Here's the price of that inventory you were lookin' at.");
    }

    string response = choice switch
    {
        1 => $"Rope'll cost ye {price} gold.",
        2 => $"Torches cost {price} gold.",
        3 => $"Climbing Equipment is a little pricey these days. It'll cost ye {price} gold.",
        4 => $"Clean water? {price} gold.",
        5 => $"Nice. My machetes cost {price} gold each.",
        6 => $"Never know when you'll need to make a keen getaway. The canoe will be {price} gold.",
        7 => $"Food Supplies? {price} gold.",
        _ => "Quit bein' 'round the bush. Tell me what ye want."
    };

    Console.WriteLine(response);
}