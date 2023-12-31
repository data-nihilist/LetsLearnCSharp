﻿/*
    Polymorphism lets a derived class supply its own definition ("override") for a member declared in its base class.
    Marking a member with 'virtual' indicates it can be overridden.
    Derived classes override a member by marking it with 'override'.
    Classes can leave members unimplemented with 'abstract', but the class must also be abstract.
*/

/*
    Consider the following code:

            public class ChessPiece
            {
                public int Row { get; set; }
                public int Column { get; set; }
                public bool IsLegalMove(int row, int column ) =>
                                IsOnBoard(row, column) && !IsCurrentLocation(row, column);
                
                public bool IsOnBoard(int row, int column) =>
                                row >= 0 && row < 8 && column >= 0 && column < 8;

                public bool IsCurrentLocation(int row, int column) =>
                                row == Row && column == Column;
            }
    
    We've defined a ChessPiece class so that we can have the separate pieces of chess inherit these members for their own
    class definitions:

            public class King : ChessPiece
            {
                public bool IsLegalKingMove(int row, int column)
                {
                    if (!IsLegalMove(row, column)) return false;

                    // Moving more than one row or one column is not a legal king move.
                    if (Math.Abs(row - Row) > 1) return false;
                    if (Math.Abs(column - Column) > 1) return false;

                    return true;
                }
            }
        
        An issue swiftly arises - we have to make individual 'IsLegal[chess piece type]Move' methods for each type of chess piece.
        Polymorphism to the rescue!

        Polymorphism means "many forms" in Greek - it is the mechanism that lets different classes related by inheritance
        provide their own definition for a method. When something class the method, the version that belongs to the object's
        actual type will be determined and called.
        
    Object-Oriented Principle #5: Polymorphism - Derived classes can override methods from the base class.
                                    The correct version is determined at runtime, so you will get different behavior
                                    depending on the object's class.
        
        In our chess example, each derived class will be able to supply its own version of IsLegalMove().
            When the program runs, the correct IsLegalMove method is called, depending on the actual object involved.
*/

/*
    We can re-write our ChessPiece class using the 'virtual' keyword on the IsLegalMove() method indicating it can be overridden:
            
            public class ChessPiece
            {
                ...
                       !!!!!!!
                public virtual bool IsLegalMove(int row, int column ) =>
                                IsOnBoard(row, column) && !IsCurrentLocation(row, column);
                
                ...
            }

    Now we can replace - or 'override' - the method with an alternative version in a derived class. Our King class can be:

            // ...
                   !!!!!!!!
            public override bool IsLegalMove(int row, int column)
            {
                    !!!!!
                if (!base.IsLegalMove(row, column)) return false;

                // Moving more than one row or one column is not a legal king move.
                if (Math.Abs(row - Row) > 1) return false;
                if (Math.Abs(column - Column) > 1) return false;

                return true;
            }
            // ...

        The King class has now provided its own definition for IsLegalMove(). It has overridden the version supplied
        by the base class. Pawn, Rook, and the others can do so as well.

    When we override a method, it is a total replacement. If we want to reuse the overridden logic from the base class,
    we can do so through the 'base' keyword. The logic above in our King class's definition of IsLegalMove() does this
    in order to keep the logic for staying on the board.

    Not all overrides call the base class's version of the method, but it is common (chess is a great example of that).

    You can override most types of members except fields and constructors (which aren't inherited anyway!).

    Just because a method is virtual does not mean a derived class MUST override it. With our chess example,
    they all probably will. In other situations, some derived classes will find the base class version sufficient.

        When a normal (non-virtual) member is called, the compiler can determine which method to call at compile time.
        When a method is virtual, it cannot.
        Instead, it records some metadata in the compiled code to know what to look up as it is running.
            This lookup as the program is running takes a tiny bit of time.
            You do not want to just make everything virtual "just in case."
            Instead, consider what a derived class may need to replace and make only those virtual.
    
    The overriding method must match the name and parameters (both count and type) as the overridden method.
        However, we can use a more specific type for the return value if you want.
        For example, if you have a 'public virtual object Clone()' method, it can be overridden:
            'public override SpecificClass Clone() since SpecificClass is derived from object.
*/

/*
    Sometimes, a base class wants to require that all derived classes supply a definition for a method but can't provide
    its own implementation.
    In such cases, it can define an 'abstract' method - specifying the method's signature without providing a method body.
        When a class has an abstract method, derived classes MUST override the method; There is nothing to fall back on.
            In fact, any class with an abstract method is an incomplete class.
                You cannot create instances of it (only derived class instances),
                and you must mark the class itself as 'abstract' as well.
            
            Here's what our ChessPiece class might look like with an abstract IsLegalMove method:

                           !!!!!!!!
                    public abstract class ChessPiece
                    {          !!!!!!!!                                                  !
                        public abstract bool IsLegalMove(int targetRow, int targetColumn);

                        // ...
                    }
            
            Adding the 'abstract' keyword (instead of 'virtual') to a method says,
                "Not only can you override this method, but you MUST override this method because I'm not supplying a definition."
            
            Instead of a body, an abstract method ends with a semicolon.
            Once a method is abstract, the class must become abstract as well (shown above).

        If a derived class defines a member whose name matches something in a base class without overriding it, a new
        member will be created, which hides (instead of overrides) the base class member.
            This is nearly always an accident caused by forgetting the 'override' keyword.
            The compiler assumes as much and gives you a warning for it.
        
        In the rare cases where this was by design, you can tell the compiler it was intentional by adding the 'new'
        keyword to the member in the derived class:


Derived d = new Derived();
Base b = d;

Console.WriteLine(d.Method() + " " + b.Method()); // outputs '4 0', not '4 4' as we would expect with polymorphism.
public class Base
{
    public int Method() => 0;
}
public class Derived : Base
{
    public new int Method() => 4;
}
*/

//-----------------------------------------------Challenge: Labeling Inventory
Console.WriteLine("\t\t\t\tChallenge: Labeling Inventory\n");
Console.WriteLine("You realize that your inventory items are not easy to sort through. If you could make it easy to label all\nof your inventory items, it would be easier to know what items you have in your pack.\n\nModify your inventory program (inheritance chapter) as described below.\n\n");
Console.WriteLine("Objectives:\n\n-\tOverride the existing ToString method (from the object base class) on all of your inventory item\n\tsubclasses to give them a name. For example, new Rope().ToString() should return \"Rope\".\n-\tOverride ToString() on the Pack class to display the contents of the pack. If a pack contains water,\n\trope, and two arrows, then calling ToString on the Pack object could look like \"Pack\n\tcontaining Water Rope Arrow Arrow\".\n-\tBefore the user chooses the next item to add, display the pack's current contents via its new\n\tToString method.\n\n");

Pack pack = new(5, 20, 15);
Rope rope = new Rope();
Sword sword = new Sword();
Food food = new Food();
pack.CheckPack();
pack.AddItem(food);
pack.AddItem(food);
pack.AddItem(food);
pack.AddItem(sword);
pack.AddItem(rope);
pack.AddItem(rope);
//-----------------------------------------------Challenge: The Old Robot
Console.WriteLine("\n\n\t\t\t\tChallenge: The Old Robot\n");
Console.WriteLine("You spot something shiny, half-buried in the mud. You pull it out and realize that it seems to be some\nmechanical automaton with the \"Property of Dynamak\" etched into it. As you knock of the caked-\non mud, you realize that it seems like this old automaton might even be programmable if you can give it\nthe proper commands. The automaton seems to be structured like this:\n");
Console.WriteLine("\t\t\tpublic class Robot\n\t\t\t{\n\t\t\t\tpublic int X { get; set; }\n\t\t\t\tpublic int Y { get; set; }\n\t\t\t\tpublic bool IsPowered { get; set; }\n\t\t\t\tpublic RobotCommand?[] Commands { get; } = new RobotCommand?[3];\n\t\t\t\tpublic void Run()\n\t\t\t\t{\n\t\t\t\t\tforeach (RobotCommand? command in Commands)\n\t\t\t\t\t{\n\t\t\t\t\t\tcommand?.Run(this);\n\t\t\t\t\t\tConsole.WriteLine($\"[{X} {Y} {IsPowered}]\");\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}");
Console.WriteLine("\n\nYou don't see a definition of that RobotCommand class. Still, you think you might be able to recreate it\n(a class with only an abstract Run command) and then make derived classes that extend RobotCommand\nthat move it in each of the four directions and power it on and off.(You wish you could manufacture a\nwhole army of these!)\n\n");
Console.WriteLine("Objectives:\n\n-\tCopy the code above into a new project.\n-\tCreate a RobotCommand class with a public and abstract void Run(Robot robot) method. (The\n\tcode above should compile after this step.)\n-\tMake OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot\n\ton or off by overriding the Run method.\n-\tMake a NorthCommand, SouthCommand, WestCommand, and EastCommand that move the robot 1\n\tunit in the +Y direction, 1 unit in the -Y direction, 1 unit in the -X direction, and 1 unit in the +X\n\tdirection, respectively. Also, ensure that these commands only work if the robot's IsPowered\n\tproperty is true.\n-\tMake your main method able to collect three commands from the console window. Generate new\n\tRobotCommand objects based on the text entered. After filling the robot's command set with these\n\tnew RobotCommand objects, use the robot's Run method to execute them. For example:\n\n\ton\n\tnorth\n\twest\n\n\t[0 0 True]\n\t[0 1 True]\n\t[-1 1 True]\n\n\t\t\tNote: You might find this strategy for making commands that update other objects useful in some\n\t\t\tof the larger challenges in the coming levels.\n\n");

Robot robot = new();

Console.WriteLine("Type your command.\n\t\toptions:\t[ on ]\t[ off ]");

string? firstCommand = Console.ReadLine();
if (firstCommand == "on")
{
    robot.Commands[0] = new OnCommand();

    Console.WriteLine("I can move North, South, East, and West. I can also be turned off by typing 'off'.");
    string? nowWhat = Console.ReadLine();
    
}
else
{
    robot.Commands[1] = new NorthCommand();
    robot.Commands[2] = new NorthCommand();
}
robot.Run();


//-----------------------------------------------The Old Robot (start)
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand      // line 121
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == false)
        {
            robot.IsPowered = true;
        }
        else 
        {
            Console.WriteLine("I'm on!");
        }
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.IsPowered = false;
        }
        else 
        {
            Console.WriteLine("//silence//");
        }
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y++;
        }
        else
        {
            Console.WriteLine("* beep. *");
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y--;
        }
        else
        {
            Console.WriteLine("*beep.");
        }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X--;
        }
        else
        {
            Console.WriteLine("*beebeep*");
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X++;
        }
        else
        {
            Console.WriteLine("*beeep*");
        }
    }
}
//-----------------------------------------------The Old Robot (end)

//-----------------------------------------------Labeling Inventory (start)
public class Pack
{
    private static int TotalNumberOfItems { get; set; }
    private float _maxWeight;
    private float _maxVolume;
    private int ItemCount { get; set; } = 0;
    private float CurrentWeight { get; set; } = 0f;
    private float CurrentVolume { get; set; } = 0f;
    public InventoryItem[] ItemsArray { get; set; }
    public Pack(int totalNumberOfItems, float maxWeight, float maxVolume)
    {
        TotalNumberOfItems = totalNumberOfItems;
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        ItemsArray = new InventoryItem[totalNumberOfItems];
    }

    public void CheckPack()
    {
        Console.WriteLine($"Your pack can hold {TotalNumberOfItems - ItemCount} more items.\nThis pack can hold a maximum of {_maxWeight - CurrentWeight} more pounds with a combined mass of {_maxVolume - CurrentVolume} sq. units.\n");
        Console.WriteLine($"There are currently {ItemCount} items in your pack:\n");
        for (int i = ItemCount; i < ItemsArray.Length; i--)
        {
            if(i - 1 < 0)
            break;
            Console.WriteLine(ItemsArray[i - 1].ToString());
        }
        Console.WriteLine();
    }
    public void AddItem(InventoryItem item)
    {
        if (ItemCount < TotalNumberOfItems)
        {
            if ((item._itemWeight + CurrentWeight) <= _maxWeight && (item._itemVolume + CurrentVolume) <= _maxVolume)
            {
                ItemsArray[ItemCount] = item;
                ItemCount++;
                CurrentWeight += item._itemWeight;
                CurrentVolume += item._itemVolume;
                CheckPack();
            }
            else
            {
                Console.WriteLine($"You cannot fit that {item} in your pack - you need to make space!\n");
                CheckPack();
            }
        }
        else
        Console.WriteLine("Your pack can't store any more items.");
    }
}
public class InventoryItem
{
    public float _itemWeight;
    public float _itemVolume;

    public InventoryItem(float weight, float volume)
    {
        _itemWeight = weight;
        _itemVolume = volume;
    }
    public InventoryItem()
    {
        _itemWeight = 0f;
        _itemVolume = 0f;
    }

    public void ItemDetails()
    {
        Console.WriteLine($"This {ToString()} weighs {_itemWeight}lbs and has a mass of {_itemVolume} sq. units.\n");
    }

    public override string ToString()
    {
        return $"{GetType()}";
    }
}

public class Arrow : InventoryItem
{
    public Arrow()
    {
        _itemWeight = 0.1f;
        _itemVolume = 0.05f;
    }
}

public class Bow : InventoryItem
{
    public Bow()
    {
        _itemWeight = 1f;
        _itemVolume = 4f;
    }
}

public class Rope : InventoryItem
{
    public Rope()
    {
        _itemWeight = 1f;
        _itemVolume = 1.5f;
    }
}

public class Water : InventoryItem
{

    public Water()
    {
        _itemWeight = 2f;
        _itemVolume = 3f;
    }
}

public class Food : InventoryItem
{

    public Food()
    {
        _itemWeight = 1f;
        _itemVolume = 0.5f;
    }
}

public class Sword : InventoryItem
{

    public Sword()
    {
        _itemWeight = 5f;
        _itemVolume = 3f;
    }
}
//-----------------------------------------------Labeling Inventory (end)