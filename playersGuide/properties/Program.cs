/*
    Properties give you field-like access while still protecting data with methods:
        public float Width { get => width; set => width = value; }
            To use a property:  rectangle.Width = 3;
    
    Auto-properties are for when no extra logic is needed:
        public float Width { get; set; }
    
    Properties can be read-only, only settable in a constructor:
        public float Width { get; }
        
    Fields can also be read-only:
        private readonly float _width = 3;

    With properties, objects can be initialized using object initializer syntax:
        new Rectangle() { Width = 2, Height = 3 }

    an 'init' accessor is like a setter but only usable in object initializer syntax:
        public float Width { get; init; }
*/

// In C#, there is a tool we can use to get the benefits of both information hiding and abstraction while keeping our code simple: properties

// A property pairs a getter and setter under a shared name with field-like access.

/*
    Consider the three elements that dealt with the rectangle's width from the most recent lessons (see informationHiding's and class's Program.cs files):

        private float _width;

        public float GetWidth() => _width;

        public void SetWidth(float value) => _width = value;
    
    To swap this out with a property, we would write the following code:

        private float _width;

        public float Width
        {
            get => _width;
            set => _width = value;
        }
    
    This defines a property with the name Width whose type is float. Properties are another type of member that we can put in a class.
    They have their own accessibility level. We made this one public since the equivalent methods, GetWidth() and SetWidth() were public.
    Each property has a type. This one uses float.
    After modifiers and the type is the name (Width). Note the capitalization - it is typical to use UpperCamelCase for property names.

    The above code uses expression bodies, but we can also use block bodies (for either or both) like so:

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
    In this case the expression body is simpler. In other situations we will NEED to use a block body.

    The getter is required to return a value of the same type as the property (float).
    The setter has access to the special value variable in its body. We didn't define a value parameter, but in essence, one automatically exists in a property setter.

    Properties do not require both getters and setters. We can have a get-only property or a set-only property.

    A get-only property makes sense for something that can't be changed frm the outside.
    The rectangle's area is like this, so, we could make a get-only property for it:

        public float Area
        {
            get => _width * _height;
        }

        * If a property is a get-only and the getter has an expression body, we can simplify it even further:

        public float Area => _width * _height;
    
    With a property-based approach, our Rectangle class could now looks something like this:

        public class Rectangle
        {
            private float _width;
            private float _height;

            public Rectangle(float width, float height)
            {
                _width = width;
                _height = height;
            }

            public float Width
            {
                get => _width;
                set => _width = value;
            }

            public float Height
            {
                get => _height;
                set => _height = value;
            }

            public float Area => _width * _height;
        }

    The most significant benefit comes in the outside world, which now has field-like access to the properties instead of method-like access:

    Rectangle r = new Rectangle(2, 3);
    r.Width = 5; --> using the Width property's setter to change the width of our rectangle. 5 is the special 'value' variable we auto-magically gain when making setters.
    Console.WriteLine($"A {r.Width}x{r.Height} rectangle has an area of {r.Area;}."); --> calling the getters for each of those properties.

    A property's getter ad setter do not need to have the same accessibility level. Either getter or setter can reduce accessibility from what the property has.

    If we want the property to have a public getter and a private setter, we could do this:

        public float Width
        {
            get => _width;
            private set => _width = value;
        }
*/

//----------------------------------------------------------------------------------------------------------Auto-Implemented Properties
/*
    Some properties will have complex logic for its getter, setter, or both. But others do not need anything fancy and end up looking like this:

        public class Player
        {
            private string _name;

            public string Name
            {
                get => _name;
                set => _name = value;
            }
        }
    
    Because these are so common place, there is a concise way to define properties of this nature called an 'auto-implemented property' or an 'auto property':

        public class Player
        {
            public string Name { get; set; }
        }

    Here we don't define bodies for either getter or setter, and we don't even define the backing field. You just end the getter and setter with a semicolon.
    The compiler will generate a backing field for this property (_name) and create a basic getter and setter method around it.

    The backing field is no longer directly accessible in your code, but that's rarely an issue.
    However, one problematic place is initializing the backing field to a specific starting value.
    We can still solve that with an auto-property like this:

        public string Name {get; set;} = "Player"; <-- DON'T forget this semicolon!
    
    A version of our Rectangle class that uses auto-properties might look something like this:

        public class Rectangle
        {
            public float Width { get; set; }
            public float Height { get; set; }
            public float Area => Width * Height;

            public Rectangle(float width, float height)
            {
                Width = width;
                Height = height;
            }
        }
//----------------------------------------------------------------------------------------------------------Immutable Fields and Properties
    Auto-properties can be get-only, like a regular property - they cannot be set-only; there is no scenario where that is useful. It would be a black hole for data.

        This makes the property immutable; "im" meaning 'not,' and "mutable" meaning 'changeable.
        When a property is get-only, it can still be assigned values, but only from within a constructor (when we're actively initializing a new instance of our object)

            These are also referred to as 'read-only properties'

            Consider this version of the Player class, which has a Name immutable:


        Player one = new("Matthew");
        Console.WriteLine(one.Name);
        // one.Name = "Angelo";       // Will not compile, because the Name property is a read-only
                        public class Player
                        {
                            public string Name { get; } = "Player 1";   // making Name a read-only by being a get-only property

                            public Player(string name)   //
                            {                            //      Without this code, one.Name outputs "Player 1";
                                Name = name;             //          With this code, we also MUST use this constructor
                            }                            //
                        }
        
//------------------------------------------------------------------------------------What about fields?

If you have a field that you don't want to change after construction, you can apply the 'readonly' keyword to it as a modifier:


        Player one = new("Angelo");
        Console.WriteLine(one._name); // will not compile due to accessibility level
        Console.WriteLine(one.GetName());   // this getter needed to be created in order to access the field's value
                public class Player
                {
                    private readonly string _name;

                    public Player(string name)
                    {
                        _name = name;
                    }

                    public string GetName() => _name;
                }

WHen all of a class's properties and fields are immutable (get-only auto-properties and readonly fields), the entire object is immutable.
Not every object should be made immutable. But when they can be, they are much easier to work with because you know the object cannot change.

//------------------------------------------------------------------------------------Object Initializer Syntax and Init Properties

While constructors should get he object into a good starting state, some initialization is best done immediately AFTER the object is constructed,
changing the values of a handful of properties right after construction.
It is like making some final adjustments as the concrete is still drying.

Let's say we have a Circle class:

public class Circle
{
    public float X { get; set; } = 0; // The x-coordinate of the circle's center.
    public float Y { get; set; } = 0; // The y-coordinate of the circle's center.
    public float Radius { get; set; } =0;
}

With this definition, we could make a new circle and set its properties like this:

Circle circle = new Circle();
circle.Radius = 3;
circle.X = -4;

C# provides a simple syntax for setting properties right as the object is created called 'object initializer syntax', shown below:

    Circle circle = new Circle() { Radius = 3, X = -4 }; 

    and if the constructor is parameterless, we can leave out the parentheses:

    Circle otherCircle = new Circle { Radius = 3, X = -4 };

We cannot use object initializer syntax with properties that are get-only. 
While we can assign a value to them in the constructor, object initializer syntax comes after the constructor finishes
This causes a predicament because it would mean you must make your properties mutable (have a setter) to use them in object initializer syntax - which is too much power in some situations.

The middle ground is an init accessor. This is a setter that can be used in limited circumstances, including an inline initializer (the 0's below) and in the constructor, but
also in object initializer syntax:

            public class Circle
            {
                public float X { get; init; } = 0;
                public float Y { get; init; } = 0;
                public float Radius { get; init; } = 0;
            }

This now allows for:
Circle circle = new Circle { X = 1, Y = 4, Radius = 3 };

Console.WriteLine(circle.X);
circle.X = 2; // won't compile
*/

//----------------------------------------------------------------------------------------------------The Properties of Arrows (start)
Console.WriteLine("\n\t\t\t\tThe Properties of Arrows\n");

Arrow arrow = new Arrow() { Arrowhead = Arrowhead.Wood, Fletching = Fletching.Plastic, Length = 69 };

Console.WriteLine(arrow.Length); // compiles thanks to us accessing the _fletching field via our class's property
// Console.WriteLine(arrow._fletching); // won't compile due to accessibility level ('private float _length')

Arrow anotherArrow = new();

Console.WriteLine(anotherArrow.Length);

//-------------------------------------------------------------------side quest: Anonymous Types
var anonymous = new { Name = "Angelo", Age = 3.5, Species = "Kitty" };
Console.WriteLine($"{anonymous.Name}, The {anonymous.Species}, is {anonymous.Age} years old.");
//---------------------------------------------------------------------------------------------
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

    // public Arrowhead GetArrowhead() => _arrowhead;
    // public Fletching GetFletching() => _fletching;
    // public float GetLength() => _length;

    public Arrowhead Arrowhead { get; init; } = Arrowhead.Steel;
    public Fletching Fletching { get; init; } = Fletching.GooseFeathers;

    public float Length { get; init; } = 80;


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
//----------------------------------------------------------------------------------------------------The Properties of Arrows (end)
