// Classes are objectively the most powerful way to define new types.
/*
    Object-Oriented Principle # 1: Encapsulation
        -Combining data  (fields) and the operations on that data (methods) into a well-defined unit (like a class).
*/


Score best = new Score();   // At this point of creating our Score class, we haven't created a constructor for our Score class. The compiler is nice enough to generate a default one for us until we do.

// new Score() creates a new instance of the Score class, placing its data on the heap (it is a reference type, after all) and grabbing a reference to it. That reference is then stored in the above 'best' variable.

// Now that our instance has been created we can work with its fields and invoke its methods:
best._name = "R2-D2";
best._points = 12420;
best._level = 15;

if (best.EarnedStar())
{
    Console.WriteLine("You earned a star!");
}


Score a = best; // copying the values of best's fields into a new instance of the same class
Score b = new();    // We can omit the class name after the 'new' keyword since in C# we have to declare the type of our variables/objects, the compiler can infer the rest. It's like the var keyword approach only it's happening on the opposite side of the equal sign.
Console.WriteLine(b._name);      // "Unknown" by our constructor --- There's now a string array of name: string [U][n][k][n][o][w][n] on the heap. Before a constructor was added, the default constructor initialized room for our object, but name was initialized to null
b._name = "C-3PO";
b._points = 8543;
b._level = 8;

if (a.EarnedStar())
    Console.WriteLine($"{a._name} earned a star!");

if (b.EarnedStar())
    Console.WriteLine($"{b._name} earned a star!");

/*      Reminder that class objects live on the heap

-----------------------------------------------------
    The Stack   |     The Heap
    [[main]]    |
    [b]>>>>>>[[Score]]             [[string]]
                |--[name]>>>>>>>>>>[C][-][3][P][O]
                |--[points: 8543]
                |--[level :    8]
    [a]>>>>>>>>>[[Score]]             [[string]]
                |--[name]>>>>>>>>>>[R][2][-][D][2]
                |--[points: 12420]
                |--[level :    15]
    [best]>>>>>>[[Score]]             [[string]]
                |--[name]>>>>>>>>>>[R][2][-][D][2]
                |--[points: 12420]
                |--[level :    15]
*/
//------------------------------------------------------------------------------------------Vin Fletcher's Arrows(start)
Console.WriteLine("\n\t\t\t\tVin FLetcher's Arrows\n");

Arrow test = new(Arrowhead.Obsidian, Fletching.Plastic, 80); // initializes a new instance of our Arrow class, default constructor initializes each field to its respective type's default value.

Console.WriteLine($"{test.PriceOfArrow()}");
class Arrow
{
    public Arrowhead _arrowhead;
    public byte _length;    // between 60 and 100 cm
    public Fletching _fletching;
    public int cost;

    public Arrow(Arrowhead arrowhead, Fletching fletching, byte length)
    {
        this._arrowhead = arrowhead;
        this._fletching = fletching;
        this._length = length;
    }

    public Arrow()
    {

    }

    public string PriceOfArrow()
    {
        float finalPrice;
        int arrowheadMaterialCosts = 0;
        int fletchingMaterialCosts = 0;

        if (this._arrowhead == Arrowhead.Steel)
            arrowheadMaterialCosts += 10;
        if (this._arrowhead == Arrowhead.Obsidian)
            arrowheadMaterialCosts += 5;
        if (this._arrowhead == Arrowhead.Wood)
            arrowheadMaterialCosts += 3;

        Console.WriteLine($"The cost of this arrow's arrowhead is {arrowheadMaterialCosts}");
        
        if (this._fletching == Fletching.Plastic)
            fletchingMaterialCosts += 10;
        if (this._fletching == Fletching.TurkeyFeathers)
            fletchingMaterialCosts += 5;
        if (this._fletching == Fletching.GooseFeathers)
            fletchingMaterialCosts += 3;

        Console.WriteLine($"The cost of this arrow's fletching is {fletchingMaterialCosts}");

        float lengthMaterialCosts = (float)(_length * .05);
        Console.WriteLine($"An arrow of a length of {_length} will add {lengthMaterialCosts} gold to the final price.");

        finalPrice = (arrowheadMaterialCosts + fletchingMaterialCosts) + lengthMaterialCosts;
        
        return $"This arrow, considering its materials and length, costs {finalPrice} gold.";
    }
}

enum Arrowhead { Steel, Wood, Obsidian};
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };

//------------------------------------------------------------------------------------------Vin Fletcher's Arrows(end)

// Defining a new class:        (see class definitions at the bottom of the main method (program.cs OR its own file))
// It's common convention in C# to place an underscore before field names. ** Basically, one "places a little field before a field's name to show/see that it is a field."
class Score 
{
    public string _name;// = "Unknown";
    public int _level;// = 0;            Another way of initializing instances' fields is in-line - although use of a constructor will over-ride these settings
    public int _points;// = 0;

/*
    Creating a new object reserves space for the object's data on the heap. It's also vital that new objects come into existence in legitimate starting states.
    That's why we make constructors - special methods that run when an object comes to life to ensure it begins life in a good state.

    Constructors must use the same name as the class, and they cannot list a return type.
*/
    // public Score()
    // {
    //     this._name = "Unknown";
    //     this._points = 0;
    //     this._level = 1;
    // }
/*
    Constructors are allowed to have parameters just like other methods.

    Classes can have as many constructors as they need. With multiple constructors, the outside world gets to pick which constructor it wants to use.

    Above, the 'this' keyword is used to accomplish 'name hiding,' and we've also implemented the standard convention for naming fields using the the underscore character appended in front of each field's name: _
*/
    public Score() : this("Unknown", 0, 0)  // Sometimes we'd like to re-use the code in one constructor from another. But we can't just call a constructor without using 'new'.
    {                                       //If we did that, we'd be creating a second object while creating the first, which isn't what we want. If we want one constructor to build off another one, use the 'this' keyword.
    }

    public Score(string n, int p, int l)
    {
        _name = n;
        _points = p;
        _level = l;
    }

    public bool EarnedStar() => (_points / _level) > 1000;
}