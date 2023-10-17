using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

Season current = Season.Fall;

if (current == Season.Summer || current == Season.Winter)
    Console.WriteLine("Happy Solstice!");
else
    Console.WriteLine("Happy Equinox!");

// Enumerations (listing things off one by one) are essentially custom types, and are especially useful if we have an exact amount of values a type can be
bool simula = true;
SimulasBox box =  new(); // the compiler can infer the type that box is intended to be, so we can omit the enum's name here and just use 'new()' if it makes code clearer
Actions playerAction = Actions._;
Console.WriteLine($"{playerAction}");

do
{
    Console.WriteLine($"\nThe box is {box}. What do you want to do?");
    string? choice = Console.ReadLine();

    if (choice == "unlock")
    {
        playerAction = Actions.Unlock;
        if (box == SimulasBox.ClosedAndLocked && playerAction == Actions.Unlock)
        {
            box = SimulasBox.ClosedAndUnlocked;
        }
    }
    if (choice == "open")
    {
        playerAction = Actions.Open;
        if (box == SimulasBox.ClosedAndLocked && playerAction == Actions.Open)
        {
            Console.WriteLine("We have to unlock the box first..");
        }
        if (box == SimulasBox.ClosedAndUnlocked && playerAction == Actions.Open)
        {
            box = SimulasBox.Opened;
        }
    }
    if (choice == "close")
    {
        playerAction = Actions.Close;
        if (box == SimulasBox.Opened && playerAction == Actions.Close)
        {
            box = SimulasBox.ClosedAndUnlocked;
        }
    }
    if (choice == "lock")
    {
        playerAction = Actions.Lock;
        if(box == SimulasBox.ClosedAndUnlocked && playerAction == Actions.Lock)
        {
            box = SimulasBox.ClosedAndLocked;
        }
    }

    if (choice == "exit")
    simula = false;

}while(simula);

int number = (int)Season.Fall;
Season now = (Season)2;
Console.WriteLine(number);
Console.WriteLine(now);
// Enums live outside of our Main method - meaning we either place them at the end of a file or in a separate file altogether

enum SimulasBox { ClosedAndLocked, ClosedAndUnlocked, Opened }; // enums default to the first enumerated value if not specified, because enums underlying type is int!
enum Actions { Lock, Unlock, Open, Close, _ };
enum Season { Winter, Spring, Summer, Fall }; // enum Season { Winter = 0, Spring, Summer, Fall }; --> Spring = 1, Summer = 2, Fall = 3
