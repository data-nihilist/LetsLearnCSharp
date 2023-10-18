//------------------------------------------------------------------------------Vin's Troubles (start)
Console.WriteLine("\t\t\t\tVin's Troubles\n");


Arrow arrow = new Arrow(Arrowhead.Steel, Fletching.TurkeyFeathers, 101); // ensuring the min and max lengths are applied to arrow when initialized
Arrow anotherArrow = new(); // initializes with default field values (see enums for first items, then see constructor for length)
Console.WriteLine(anotherArrow.GetLength());

Console.WriteLine(arrow.GetLength());
// arrow._length = 75; // arrow._length is inaccessible due to its protection level B)
Console.WriteLine(arrow.GetLength());

Console.WriteLine(arrow.PriceOfArrow());
public class Arrow
{
    private Arrowhead _arrowhead;
    private float _length;    // between 60 and 100 cm
    private Fletching _fletching;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;

        float minimumLength = 60;
        float maximumLength = 100;
        if (length < 60 || length > 100)
        {
            if (length < 60)
            _length = minimumLength;
            if (length > 100)
            _length = maximumLength;
        }
        else
        _length = length;
    }

    public Arrow()
    {
        _length = 80;   // these are the 'stock' arrows that Vin typically has on hand for travelers.
    }

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;


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

        float lengthMaterialCosts = _length * (float).05;
        Console.WriteLine($"An arrow of a length of {_length} will add {lengthMaterialCosts} gold to the final price.");

        finalPrice = arrowheadMaterialCosts + fletchingMaterialCosts + lengthMaterialCosts;
        
        return $"This arrow, considering its materials and length, costs {finalPrice} gold.";
    }
}

public enum Arrowhead { Steel, Wood, Obsidian};
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };
//--------------------------------------------------------------------------------------Vin's Troubles (end)
/*
    Information hiding is where some details are hidden from the outside world while still presenting a public boundary that the outside world can still interact with.
    Class members should be marked 'public' or 'private' to indicate which of the two is intended.

    Data (fields) should be private in nearly all cases.

    Abstraction: When things are private, they can change without affecting the outside world.
        The outside world depends on the public parts, while anything private can change without problems.
    A third level is internal, which is meant to be used only inside the project.
    Classes and other types also have an accessibility level: public class X { ... }

    Object-Oriented Principle # 2: Information Hiding
        Only the object itself should directly access its data.
    
    Information hiding allows an object to protect its data. Each object is its own gatekeeper. If another object wants to see what state the object is in or change its state, it must
    request that information by calling a getter or setter method, rather than just reaching in and grabbing it.

    This way objects can enforce rules about their data, as we see here with the rules around a rectangle's area.

    The default accessibility level is 'private'. In most cases, its suggested to include the accessibility level whenever possible.
*/
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// consider the code below:

// class Rectangle
// {
//     public float _width;
//     public float _height;
//     public float _area;

//     public Rectangle(float width, float height, float area)
//     {
//         _width = width;
//         _height = height;
//         _area = area;
//     }
// }

/*
    This is a good beginning.. but.. there's a problem. A rectangle's area is defined as its width and height multiplied together.
        A rectangle with a length of 1 and a height of 1 has an area of 1. A rectangle with a length of 2 and a height of 3 has an area of 6.
    However, our current definition of Rectangle could allow this:

    Rectangle rectangle = new Rectangle(2, 3, 2000000)

    Wouldn't it be nice if we could enforce this kind of rule? Removing the area parameter from the constructor and computing the area instead prevents somebody
    (including ourselves in 3 weeks when we forget the details) from accidentally supplying an illogical area.
*/
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// We should now re-define our Rectangle class as so:

// class Rectangle
// {
//     public float _width;
//     public float _height;
//     public float _area;

//     public Rectangle(float width, float height)
//     {
//         _width = width;
//         _height = height;
//         _area = width * height;
//     }
// }

/*
    This ensures new rectangles always start with the correct area. But we still have a problem!

    Rectangle rectangle = new Rectangle(2, 3);
    rectangle._area = 2000000;
    Console.WriteLine(rectangle._area); --> we've changed the area of our rectangle to be illogical :')

    While we initially computed the area of our rectangle correctly, our code as of now does not stop somebody from accidentally or intentionally changing the area.
    The outside world can reach in and mess with the rectangle's data in ways that shouldn't be allowed.

    If the Rectangle class could keep its data hidden, the outside world could not put Rectangle instances into illogical or inconsistent states.

    Of course, the outside world will sometimes want to know about the rectangle's current size and area and may want to change its size, but, all of that can be
    carefully protected through methods.
*/

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

// The 'public' and 'private' accessibility modifiers
/*
    When we reviewed classes, we slapped 'public' on all our fields and methods. This is the root of our information hiding problem - it makes it so the outside world can reach it.

    Every member of a class -fields and methods alike- has an accessibility level. This level determines where the thing is accessible from.

    The 'public' keyword gives the member public accessibility - usable anywhere.
    The 'private' keyword gives the member private accessibility - usable only within the class itself.

    The 'public' and 'private' keywords are both called accessibility modifiers because they change the accessibility level of the thing they are applied to.
    If we make our fields private, then the outside world cannot directly interfere with them
*/

class Rectangle
{
    private float _width;
    private float _height;
    private float _area;

    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
        _area = width * height;
    }
/*
    Now we have the opposite problem - we've sealed off all access to the fields. The outside world will want SOME visibility and perhaps some control over the rectangle.
    With all our fields marked private, we can no longer even do this:

        Rectangle rectangle = new Rectangle(2, 3);
        Console.WriteLine(rectangle._area); --> DOESN'T COMPILE! D:
        
    Since the outside world needs to know the rectangle's area, does that mean we must make the field public anyway? In general, no.
    Instead of allowing direct access to our fields, we provide controlled access through methods.
*/

// For example, the outside world will want to know the rectangle's width, height, and area. So, we add these methods to the Rectangle class:
    public float GetWidth() => _width;
    public float GetHeight() => _height;
    public float GetArea() => _area;

// Methods that retrieve a field's current value are called GETTERS.
// The fields remain private, and the outside world can still get their questions answered without having unfettered access to the data.

// If the outside world also needs to change the rectangle's dimensions as opposed to viewing them, we can also solve that with methods:
    public void SetWidth(float value)
    {
        _width = value;
        _area = _width * _height;
    // We need to remember that our originally computed area was referencing a previously set _width. Our rectangle's area would be using old data if we forget this.
    }

    public void SetHeight(float value)
    {
        _height = value;
        _area = _width * _height;
    }
    // methods that assign a new value to a field are called SETTERS.
    // We've decided we don't want to let people directly change the area, so we skip creating a method that does so.
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

/*
    Object-Oriented Principle # 3: Abstraction
        The outside world does not need to know each object or class's inner workings and can deal with it as an abstract concept.
        Abstraction allows the inner workings to change without affecting the outside world.

    Earlier versions of our Rectangle class above had a field for the rectangle's area, which got updated any time the width or height changed.
    We can change this to compute the area as needed and ditch the field without affecting the rest of our program like so:
*/

class RectangleNoAreaField
{
    private float _height;
    private float _width;

    public RectangleNoAreaField(float width, float height)
    {
        _width = width;
        _height = height;
    }

    public float GetWidth() => _width;
    public float GetHeight() => _height;
    public float GetArea() => _width * _height;

    public void SetWidth(float value) => _width = value;
    public void SetHeight(float value) => _height = value;
}
/*
    The _area field is gone, and SetWidth(), SetHeight(), and the constructor no longer calculate the area. Instead, it is calculated on demand when somebody asks for the area
    via GetArea(). The outside world is oblivious to this change. They used to retrieve the rectangle's area through GetArea() and still do.

    Abstraction is a vital ingredient in building larger programs. It lets you make one piece of your program at a time without having to remember every detail as you go.
*/
//-------------------------------------------------------------------------------------Type accessibility levels and the 'internal' modifier
/*    
    We can (and usually should) place accessibility levels on the types we define.
    Like so:
    
        public class Rectangle
        {
            ...
        }

    It makes no sense to add 'private' to a whole class.
    You may think this leaves 'public' as the only option, but there is another - 'internal'
    Initially, we won't see many differences between 'public' and 'internal.' The difference is that things made public can be accessed everywhere, including other projects,
    while internal can only be used in the project it is defined in.

    Consider, for example, all of the code in .NET's Base Class Library, like Console and Convert. That code is meant to be reused everywhere. Console and Convert are public.

    If we make a new type (class, enumeration, etc.) and feel that its role is a supporting role but not something we would want the outside world to know exists,
    we might choose to make this type internal.

    There are 3 levels of share/don't-share decisions to make:
        1) Do I share a project or not?
        2) Should this individual type definition be shared or not?
        3) Should this member - a field or a method - be shared or not?
    
    C# programmers usually consider these different levels in isolation.
    
    Suppose you're deciding whether to make something public, internal, or private. You assume that its container is as broadly available as possible and say, 
        "If this thing's container were useable anywhere, how available should this specific item be?"
    For a class, we would say,
        "If this project were available to anybody, would I want them to be able to reuse this class? Or is this a secret detail that I'd want 
        to reserve the right to change without affecting anybody?"
    For a method,
        "If this class were public, would I want this method to be public, or is this something I want to make less accessible so that I can change it more easily later?"
*/
