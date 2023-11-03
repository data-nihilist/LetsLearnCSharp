/* SpeedRun
                                                Structs
        
        A struct is a custom value type that defines a data structure without complex behavior:

                public struct Point
                {
                    //...
                }

                Structs are not focused on behavior but can have properties and methods.
        
        Compared to classes: structs are value types, automatically have value semantics, and cannot be used in inheritance

        Make structs small, immutable, and ensure the default value is legitimate.

        All the built-in types are aliases for other struts (and a few classes).
            Example:
                    int is shorthand for System.Int32
        
        Value types can be stored in reference-typed variables
            Example:
                    object thing = 3;           But will cause the value to be boxed and placed on the heap.
*/

/*
    While classes are a great way to create a new reference type, C# also lets us make custom value types.

    Making a struct is nearly the same as making a class.
    We've seen many variations on a Point class so far, here's a Point struct:

            public struct Point
            {
                public float X { get; }
                public float Y { get; }

                public Point(float x, float y)
                {
                    X = x;
                    Y = y;
                }
            }
        The only major difference is we're using the 'struct' keyword instead of the 'class' keyword.
        Most aspects of making a struct are the same as making a class.
            We can add fields, properties, methods, and constructors, along with some other member types we have not discussed yet.
        
        Using a struct is the same as using a class:

                Point p1 = new Point(2, 4);
                Console.WriteLine($"({p1.X}, {p1.Y})");
    
    The critical difference is that structs are value types instead of reference types.

        That means variables whose type is a struct contain the data where the variable lives,
            instead of holding a reference that points to the data, as is the case with classes.
        
        Variable's contents are copied when passing something between methods (an argument or return value).
            For a reference type like classes, that means the reference is copied.
            The calling method and the called method both have their own reference.
            But both references point to the same object.
        
        For a value type like structs, the entire block of data is copied, and each ends up with a full copy of the data.
            The same is true when assigning a value from one local variable to another or working with expressions.
        
        Structs are primarily useful for representing small data-related concepts that don't have a lot of behavior.
            Representing a 2D point, as we did above, is a good candidate for a struct.
                A circle, a line, or a matrix could also be good candidates.
        
        In situations where the concept is not a small data-related concept, a class is usually better.
            Even still, some small data-related concepts are still better than a class.
                We'll analyze the class vs. struct decision in more depth in a moment.
*/

/*
                                            Memory and Constructors:
    
    Because structs are value types (not reference types), memory usage and constructs are two critical ways
        structs differ from the classes we have been making in the past chapters.
    
    Reference types, such as a class, can be null.
        The memory for an object doesn't exist until it is explicitly created by calling a constructor with the 'new' keyword.
    
    For value types like structs, we don't have that option.
        The variable's mere existence means its memory must also exist, even before it has been initialized by a constructor.

        This model has a lot of implications that may be surprising.
    
    First, while a constructor can be used to initialize data, invoking a constructor is not always necessary.
        Consider this struct:

                public struct PairOfInts
                {
                    public int A; // These are public fields, which are usually best to avoid
                    public int B;
                }
        
        Now look at this code with a PairOfInts local variable:

                PairOfInts pair;
                pair.A = 2;
                Console.WriteLine(pair.A);

                It calls no constructor but still assigns a value to its A field.

                The pair variable acts like two separate local variables, each of which can be initialized and used like any other
                local variable but through a shared name.

            Now imagine we add this class into the mix:

                    public class PairOfPairs
                    {
                        public PairOfInts _one;
                        public PairOfInts _two;

                        public void Display()
                        {
                            Console.WriteLine($"{_one.A}, {_one.B} and {_two.A}, {_two.B}");
                        }
                    }

                    Once again, we can use these structs without calling a constructor.
                    In this case, the structs are initialized to default values by zeroing out their memory;
                        Meaning A and B of both _one and _two will be 0 until somebody changes it.

                            No matter what constructors you give a struct, they may simply not be called!
        
            Second, structs will always have a public parameterless constructor.
                If a class doesn't define any constructors, 
                the compiler automatically generates a parameterless constructor for any class you make.

                    The compiler does the same thing for a struct.
                
                For a class, if you define a different constructor, the compiler no longer makes a parameterless constructor.

                For a struct, the compiler will define a public parameterless constructor anyway.
                    You cannot get rid of the public parameterless constructor.
                        
                However, you may define this public, parameterless constructor yourself if you need it to do something specific.

            Third, field initializers are a bit weird in a struct. Consider this version of PairOfInts:

                    public struct PairOfInts
                    {
                        public int A = 10;
                        public int B = -2;
                    }

                    These initializers do not always run when you use a PairOfInts.

            -Field and property initializers don't ever run if no constructor is called.
            -The compiler-generated constructor runs these initializers only if the struct has no constructors.
            -If you add your own constructor, these initializes wil only run as a part of constructors you have defined
                NOT the compiler generated one.

// PairOfInts firstPair = new();
// Console.WriteLine(firstPair.A);
// Console.WriteLine(firstPair.B);
// public struct PairOfInts    // A struct with field initializers must provide an explicitly declared constructor
// {
//     public int A = 10;
//     public int B = -2;

//     // public PairOfInts()
//     // {

//     // }
// }
            To ensure the third rule stated above doesn't catch us off guard, we want to define a parameterless constructor
            when adding initializers to fields or properties.

            Always double check code to ensure our assumptions while constructing objects are correct!
*/

/*                                          Classes verses Structs

    Classes and structs have a lot in common. But let's take some time to compare the two and describe when you might want each;

        The main difference is that classes are reference types and structs are value types.
        We touched on this in the previous section, but it means struct-typed variables store their data directly,
            while class-typed variables store a reference to their data - the actual data lives somewhere else.
        
        This one difference has a lot of ramifications, not the least of which is the differences in constructors described above;

        Another key difference is that structs cannot take on a null value, though we will see a way to pretend so later on.

        Because structs are value types, reading and writing values to variables involves copying the whole pile of data around
            - not just a reference.
        
        Like with a double, when we copy a value from one variable to another results in a copy:

                PairOfInts first = new PairOfInts(2, 10);
                PairOfInts second = first;

                    Here, second will get a copy of both the 2 and 10 assigned to its fields.
                    The same thing would happen if we passed a PairOfInts to a method as an argument.
            
            Additionally, inheritance doesn't work well when copying value types around (research "object slicing" for more info).
                So, structs do not support it.
            
            A struct cannot pick a base class (they all derive from ValueType, which derives from Object).
            
            They can, however, implement interfaces.
        
        Equality is also different for structs.
        As we've seen, value types have value semantics - two things are equal if all of their data members are equal.
        Any struct you create will automatically have value semantics.
            The Equals method and the == and != operators are automatically defined to compare the struct's fields for equality.
*/

/*                                          Choosing To Make A Class or a Struct

    Given how similar structs and classes are, you're probably wondering how to decide between the two;

        Ultimately, the deciding factor should be if you need a reference type or a value type.
            That's the main difference, and it should drive your selection.
    
    Structs are usually better choice for small, data-focused types.
    A struct may be better if a concept is primarily about representing data and not doing actual work.

    If the concept's behavior is important, then things like inheritance and polymorphism often are as well - so you'd pick class.
        We can't get inheritance or polymorphism from a struct.
    
    That done't mean a struct can't have methods.
        A struct's methods are usually focused on answering questions about the data instead of getting work done.

    The way structs and classes are managed in memory is also a driving force.
        Reference types like classes always get allocated individually on the heap.
        Structs get allocated directly in whatever contains them.
            That is sometimes the stack and sometimes a larger object on the heap
                Such as an array or class with value-typed fields.
        
        Therefore, instances of classes make the garbage collector work harder, while structs do not.
    
    Let's say we have the following two types that differ only by whether they are a struct (value type) or class (reference type):

            public struct CircleStruct
            {
                public double X { get; }
                public double Y { get; }
                public double Radius { get; }

                public CircleStruct(double x, double y, double radius)
                {
                    X = x; Y = y; Radius = radius;
                }
            }

            public class CircleClass
            {
                public double X { get; }
                public double y { get; }
                public double Radius { get; }

                public CircleClass(double x, double y, double radius )
                {
                    X = x; Y = y; Radius = radius;
                }
            }
        
        Now consider this code:

                for(int number = 0; number < 10000; number++)
                {
                    CircleStruct circle = new CircleStruct(0, 0, 10);
                    Console.WriteLine($"X = {circle.X}, Y = {circle.Y}, Radius = {circle.Radius}");
                }

                    Here, every time the for-loop runs (10,000 times, mind you), we are replacing the value that's stored in
                    circle (since it's a struct - a value type). Memory location is being re-used.

                for(int number = 0; number < 10000; number++)
                {
                    CircleClass circle = new CircleClass(0, 0, 10);
                    Console.WriteLine($"X = {circle.X}, Y = {circle.Y}, Radius = {circle.Radius}");
                }
                    Here, every time the for-loop runs those 10,000 times, we're adding new instances of the CircleClass class
                    onto the heap. The garbage collector is going to be very busy!
        
        But structs don't always have the upper hand with memory usage.
            Consider this scenario, where we pass a circle as an argument to a method 10,000 times:

                    CircleStruct circleStruct = new CircleStruct(0, 0, 10);
                    for (int number = 0; number < 10000; number++)
                    {
                        DisplayStruct(circleStruct);
                    }

                    CircleClass circleClass = new CircleClass(0, 0, 10);
                    for (int number = 0; number < 10000; number++)
                    {
                        DisplayClass(circleClass);
                    }

                    void DisplayStruct(CircleStruct circle) => Console.WriteLine($"X = {circle.X}, Y = {circle.Y}, Radius = {circle.Radius}");
                    void DisplayClass(CircleClass circle) => Console.WriteLine($"X = {circle.X}, Y = {circle.Y}, Radius = {circle.Radius}");

                Above, we only create on struct and class instance, but we repeatedly call the DisplayStruct and DisplayClass methods.
                    In doing so, the contents of circleStruct are copied to DisplayStruct's circle parameter,
                    and the contents of circleClass are copied to DisplayClass's circle parameter repeatedly.

                            For the struct, that means copying all 24 bytes of the data structure, for a total of 240,000 bytes copied.
                            For the class, we're only copying the 8-byte reference and a total of 80,000 bytes, which is far less.
                    
                    The bottom line is that you'll get different memory usage patterns depending on which one you pick.
                        Those differences play a key role in deciding whether to choose a class or a struct.

                        In short, we should consider a struct when we have a type that is:
                            1. Focused on data instead of behavior.
                            2. Is small in size.
                            3. Where we don't need shared references.
                            4. When being a value type works to your advantage instead of against you.

                                If any of the above 4 guidelines are not true, we should prefer a class over a struct.
                                A point, rectangle, circle, and score could each potentially fit those criteria, depending on how you're using them in your project.

                        You'll probably write out 50 times as many classes as structs, but a few strategically placed structs make a big difference.
*/

/*                                                  Rules to Follow When Making Structs

        There are three guidelines that you should follow when making a struct:

            First: Keep them small.
                That is subjective.. but an 8-byte struct is fine, while a 200-byte should generally be avoided. Those costs of copying large structs add up quick.
            
            Second: Make structs immutable.
                Structs should represent a single compound value, and as such, we should make their fields readonly and not have setters for its properties.
                    On properties: Not even 'private' - although an 'init' accessor is fine, however.
                Doing this prevents situations where somebody thought they had modified a struct value but modified a copy instead:
                        
                        public void ShiftLeft(Point p) => p.X -= 10;

                        Assuming Point is a struct, the data is copied into p when you call this method.
                        The variable p's X property is shifted, but it is ShiftLeft's copy. The original copy is unaffected.
                
                Making structs immutable sidesteps all sorts of bugs like this.
                If you want to shift a point to the left, you make a new Point value instead, with its X property adjusted for the desired shift.
                Making a new value is essentially the same thing you would o if it were just an int!

                        public void ShiftLeft(Point p) => new Point(p.X - 10, p.Y);

                        With this change, the calling method would do this:

                                Point somePOint = new Point(5, 5);
                                somePoint = ShiftLeft(somePoint);
            
            Third: Because structs can exist without calling a constructor, a default, zeroed-out struct should represent a valid value.

                        Consider the LineSegment class below:

                                public class LineSegment
                                {
                                    private readonly Point _start;
                                    private readonly Point _end;

                                    public LineSegment() {}

                                    // ...
                                }

                                When a new LineSegment is created, _start and _end are initialized to all zeroes.
                                Regardless of what constructors Point defines, they don't get called here.
                                    Fortunately, a Point whose X and Y values are 0 represents a point at the origin, which is a valid point.
*/

/*                                                      Boxing and Unboxing

    Classes and structs all ultimately share the same base class: object
        Classes derive from object directly (unless they choose another base class)
        Structs derive from the special System.ValueType class, which is derived from object.

        This creates an interesting situation:

                object thing = 3;
                int number = (int)thing;

            The number 3 is an int value, and int-typed variables contain the value directly, rather than a reference.
            But variables of the object type store references..
                It seems we have conflicting behaviors. How does the above code work?

            When a struct value is assigned to a variable that stores references, the data is pushed out to another location on the heap, in its own little container
                    - a box.
                        A reference to the box is then storedi n the 'thing' variable. THis is called a 'boxing conversion'
                            The value is copied onto the heap, allowing you to grab a reference to it.
            
            On the second line, the inverse happens.
                After ensuring that the type is correct, the box's contents are extracted - an 'unboxing conversion' and copied into the number variable.
            
                    "The 3 is boxed on the first line. Then unboxed on the second line."

            As shown above, boxing can happen implicitly, while unboxing must be explicit with a cast.

            The same thing happens when we use an interface type with a value type.
                Suppose a value type implements an interface, and you store it in a variable that uses an interface type.
                    In that case, it must box the value before storing it because interface types store references.

                            ISomeInterface thing = new SomeStruct();
                            SomeStruct s = (SomeStruct)thing;

                                Boxing and unboxing are efficient - but not free.
                                    If you are boxing and unboxing frequently, perhaps you should make it a class instead of a struct.
*/
//--------------------------------------------------------------Challenge: Room Coordinates
Console.WriteLine("\t\t\t\tChallenge: Room Coordinates\n\nThe time to enter the Fountain of Objects draws closer. While you don't know what to expect, you have\nfound some scrolls that describe the area in ancient times. It seems to be structred as a set of rooms\nin a grid-like arrangement.\n\nLocations of the room may be represented as a row and column, and you take it upon yourself to try to\ncapture this concept with a new struct definition.");
Console.WriteLine("\n\nObjectives:\n\n-\tCreate a Coordinate struct that can represent a room coordinate with a row and column.\n-\tEnsure Coordinate is immutable.\n-\tMake a method to determine if one coordinate is adjacent to another (differing only by a single row\n\tor column).\n-\tWrite a main method that creates a few coordinates and determines if they are adjacent to each\n\tother to prove that it is working correctly.\n\n");
//--------------------------------------------------------------Room Coordinates (start)
Coordinate a = new();
Coordinate b = new(0, -1);

Console.WriteLine(a.Row);
Console.WriteLine(a.Column);
Console.WriteLine(b.Row);
Console.WriteLine(b.Column);

Console.WriteLine(Coordinate.AreAdjacent(a, b));
public struct Coordinate
{
    public readonly int Row { get; init; }
    public readonly int Column { get; init; }
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = a.Row - b.Row;
        int columnChange = a.Column - b.Column;

        if(Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if(Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

        return false;
    }
}
//--------------------------------------------------------------Room Coordinates (end)