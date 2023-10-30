/*
    Inheritance lets you derive new classes based on existing ones
        The new class inherits everything except constructors from the base class;
                
                class Derived : Base { ... }
        
        Classes derive from 'object' by default, and everything eventually derives from 'object' even if 
        another class is explicitly stated.

        Constructors in a derived class MUST 'call out' the constructor they are using from the base class
        UNLESS they are using a parameterless constructor:

                class Derived : Base
                {
                    ...
                    public Derived (int x) : base(x)
                    {
                        ...
                    }
                }

        Derived class instances can be used where the base class is expected:

                Base x = new Derived();
        
        The 'protected' accessibility modifier makes things accessible in the class and any derived classes.

    Object-Oriented Principle #4: Inheritance - Basing one class on another, retaining the original class's functionality
    while extending the new class with additional capabilities.

    When we define an inheritance relationship between two classes, three things happen:
        
        1. The new class gets everything the old class ('base class', sometimes 'parent' or 'super' class) has,
        2. The new class (sometimes 'child' or 'sub' class) can add in extra stuff,
        3. The new class can always be treated as though it were the original since it has all of those capabilities
    
    As it turns out, we've been using inheritance for a while up to this point in the text book;

        Every class we define automatically has a base class called 'object'.

        When we made an Asteroid or a Point class, these were derived from, or extended, the object class.
            Asteroid and Point are the derived classes in the relationship, and object is the base class.
*/

// We can create instances of the object class and use 'object' as the type for a variable like so:
object thing1 = new object();

// The ToString() method creates a string representation of any object.
Console.WriteLine(thing1.ToString()); // outputs System.Object, because the Object class lives in the System namespace

    /*
        The object class doesn't have many responsibilities, so creating instances of object itself is relatively rare.
    */

object thing2 = thing1;
object thing3 = new object();
Console.WriteLine(thing1.Equals(thing2)); // outputs True
Console.WriteLine(thing1.Equals(thing3)); // outputs False

    /*
        By default, Equals() returns whether two things are references to the same object on the heap.
    */

Point p1 = new Point(2, 4);
Console.WriteLine(p1.X);
Point p2 = p1;
Console.WriteLine(p1.ToString());
Console.WriteLine(p1.Equals(p2));

object p3 = new Point(6, 9);
Console.WriteLine(p3.ToString());
// Because Point is an extension of object, the 2 lines above will output 'Point' and not 'System.Object'

// Console.WriteLine(p3.X); // The compiler will throw an error because once we throw a reference to a derived class
                            //into a base class variable like object, derived information is lost.
                            
                            // We'll look into how we can regain access to the object as the derived type later

//-----------------------------------------------Casting and Checking for Types

/* It's considered 'risky' coding whenever we use casting to satisfy the compiler - this method should be avoided

We can check for the exact type of an object by using the built in C# method GetType()

    Whenever we're creating a class, the C# runtime will create an object representing information about that type.
    These objects are instances of the Type class, which is a type that has metadata about other types in your program.
*/
Console.WriteLine(p3.GetType());

    // typeof is a keyword that lets us access these special objects by type name instead:
if (p3.GetType() == typeof(Object)) Console.WriteLine("It was an object all along!");
    // Although Object is the parent class for our hand made classes, GetType() & typeof() requires an exact match.
if (p3.GetType() == typeof(Point)) Console.WriteLine("Dis a Point!");

//----------------------------------------------The 'as' and 'is' keywords
/*
    The 'as' keyword simultaneously does a check AND the conversion.
    
    The 'is' keyword is powerful and is one way to use patterns - later chapters - it's frequently used to simply check the
    type and assign it to a new variable
*/

// see "./mtgFun/card" for simple examples of these keywords

//---------------------------------------------The 'protected' access modifier
/*
    We've encountered three accessibility modifiers: private, public, and internal

    The fourth we'll look at is 'protected'
        If something is protected, then it is accessible within the class and also any derived classes.

            example:

            public class GameObject
            {
                public float PositionX { get; protected set; }
                public float PositionY { get; protected set; }
                public float VelocityX { get; protected set; }
                public float VelocityY { get; protected set; }
            }
    
    If we make these setters protected instead of public, only GameObject and its derived classes (like Asteroid and Ship)
    can change those properties; the outside world cannot.

    Additionally, if you want to forbid others from deriving from a specific class, we can use the 'sealed' modifier

            public sealed class Asteroid : GameObject
            {
                // ...
            }
    In this case, nobody will be able to derive a new class based on Asteroid. It is rare to want an outright ban on
    deriving from a class, but it has its occasional uses.

    Sealing a class can also sometimes result in a performance boost.
*/
//------------------------------------------------------------------------Challenge start
Console.WriteLine("\n\t\t\t\tChallenge: Packing Inventory\n\nYou know you have a long, dangerous journey ahead of you to travel to and repair the Fountain of\nObjects. You decide to build some classes and objects to manage your inventory to prepare for the trip.\n\nYou decide to create a Pack class to help in holding your items. Each pack has three limits: the total\nnumber of items it can hold, the weight it can carry, and the volume it can hold. Each item has a weight\nand volume, and you must not overload a pack by adding too many items, too much weight, or too much\nvolume.\n\n");
Console.WriteLine("There are many item types that you might add to your inventory, each their own class in the inventory system.\n(1) An arrow has a weight of 0.1 and a volume of 0.05.\n(2) A bow has a weight of 1 and a volume of 4.\n(3) Rope ahs a weight of 1 and a volume of 1.5.\n(4) water has a weight of 2 and a volume of 3.\n(5) Food rations have a weight of 1 and a volume of 0.5.\n(6) A sword has a weight of 5 and a volume of 3.\n\n");
Console.WriteLine("Objectives:\n\n-\tCreate an InventoryItem class that represents any of the different item types. This class must\n\trepresent the item's weight and volume, which it needs at creation time (constructor)\n-\tCreate derived classes for each of the types of items above. Each class should pass the correct weight\n\tand volume to the base class constructor but should be creatable themselves with a parameterless\n\tconstructor (for example, new Rope() or new Sword())\n-\tBuild a Pack class that can store an array of items. The total number of items, the maximum weight,\n\tand the maximum volume are provided at the creation time and cannot change afterward.\n-\tMake a public bool Add(InventoryItem item) method to Pack that allows you to add items\n\tof any type to the pack's contents. This method should fail (return false and not modify the pack's\n\tfields) if adding the item would cause it to exceed the pack's item, weight, or volume limit.\n-\tAdd properties to Pack that allow it to report the current item count, weight, and volume, and the\n\tlimits of each.\n-\tCreate a program that creates a new pack and then allow the user to add (or attempt to add) items\n\tchosen from a menu.\n\n");

Pack testPack = new(10, 35, 15);
testPack.CheckPack();

Arrow arrow = new Arrow();
Bow bow = new Bow();
Rope rope = new Rope();
Water water = new Water();
Food food = new Food();
Sword sword = new Sword();

arrow.ItemDetails();
bow.ItemDetails();
rope.ItemDetails();
water.ItemDetails();
food.ItemDetails();
sword.ItemDetails();

testPack.AddItem(arrow);
testPack.AddItem(sword);
testPack.AddItem(rope);
testPack.AddItem(food);
testPack.AddItem(sword);
testPack.AddItem(sword);
testPack.AddItem(bow); // pack is full!

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
        Console.WriteLine($"There are currently {ItemCount} items in your pack.\n");
        foreach (InventoryItem item in ItemsArray)
        {
            Console.WriteLine(item);
        }
    }
    public void AddItem(InventoryItem item)
    {
        if ((item._itemWeight + CurrentWeight) <= _maxWeight && (item._itemVolume + CurrentVolume) <= _maxVolume)
        {
            ItemsArray[ItemCount] = item;
            ItemCount++;
            CurrentWeight += item._itemWeight;
            CurrentVolume += item._itemVolume;
        }
        else
        {
            Console.WriteLine($"You cannot fit that {item} in your pack - you need to make space!\n");
            CheckPack();
        }
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
        Console.WriteLine($"This {GetType()} weighs {_itemWeight}lbs and has a mass of {_itemVolume} sq. units.\n");
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
//--------------------------------------------------------Challenge end
public class Point 
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x; Y = y;
    }
}