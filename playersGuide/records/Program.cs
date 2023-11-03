/*SpeedRun
    
    Records are a compact alternative for defining a dta-centric class or struct:

            public record Point(float X, floatY);
    
    The compiler automatically generates a constructor, properties, ToString, equality with value semantics, and deconstruction.

    You can add additionally members or provide a definition for most compiler-synthesized members.

    Records are turned into classes by default or into a struct:

            public record struct Point(...)

    Records can be used in a with expression: 

            Point modified = p with { X = -1 };
*/

/*                                                              Records

        C# has an ultra-compact way to define certain kinds of classes or structs called a 'record'
        The typical situation where a record makes sense is when your type is little more than a set of properties - a data-focused entity

            The following shows a simple Point record, defined with an X and Y property:

                    public record Point(Float X, float Y);  // That's all!

            The compiler will expand the above code into something like:

                    public class Point
                    {
                        public float X { get; init; }
                        public float Y { get; init; }

                        public point(float x, float y)
                        {
                            X = x;
                            Y = y;
                        }
                    }

                        When we define a record, we get several features for free.
                            It starts with properties that match the names you provided in the record definition and a matching constructor.
                                Note: These properties are init properties, so, the class is by default immutable.
                                    That's only the beginning;
                            
                            We get several other things for free: A nice string representation, value semantics, deconstruction, and creating copies with tweaks.
        
        String Representation:
            Records automatically override the ToString method with a convenient, readable representation of its data.

                For example, new Point(2, 3).ToString() will produce: Point { X = 2, Y = 3 }

                    When a type's data is the focus, a string representation like this is a nice bonus.
                    You could do this manually by overriding ToString, but we get it free with records.
        
        Value Semantics:
            Recall that value semantics are when the thing's value or data counts, not its reference.
            While structs have value semantics automatically, classes have reference semantics by default.
                However, records automatically have value semantics.

                In a record, the Equals method (the == operator and != operator) are redefined to give it value semantics
                    For example:

                            Point a = new Point(2, 3);
                            Point b = new Point(2, 3);
                            Console.WRiteLine(a == b);

                    Though a and b refer to different instances and use separate memory locations, this code displays True because the data are a perfect match.
        
        Deconstruction:
            In a previous lesson, we saw how to deconstruct a tuple, unpacking the data into separate variables:

                    (string first, string last) = ("Jack", "Sparrow");
                
                You can do the same thing with records:

                        Point p = new Point(-2, 5);
                        (float x, float y) = p;
        
        with Statements:
            Given that records are immutable be default, it is not uncommon to want a second copy with most of the same data,
            just with one or two of the properties tweaked.

            While you could always just call the constructor, passing in the right values, records give you extra powers in the form of a 'with' statement:

                    Point p1 = new Point(-2, 5);
                    Point p2 = p1 with { X = 0 };
                
                You can replace many properties at once by separating them with commas:

                        Point p3 = p1 with { X = 0, Y = 0 };

                            In this case, since we've replaced ALL the properties with new values, it might have been better to just write new Point(0, 0).
                                We're just showing the mechanics of the 'with' statement.
        
        Advanced Scenarios:
            Most records you define will be a single, similar to the Point record defined earlier.
            But when you have the need, they can be much much more.
            You can add additional members and make your own definition to supplant most compiler-generated members.

                                                Additional Members:
                
                In any record, you can add any members you need to flesh out your record type, just like a class.

                    The following shows a Rectangle record with Width and Height properties and then adds in an Area property, calculated using the Width and Height:

                            public record Rectangle(float Width, float Height)
                            {
                                public float Area => Width * Height;
                            }

                                    There are no limits to what members you can add to a record

                                                Replacing Synthesized Members:
                            
                The compiler generates quite a few members to provide the features that make records attractive.
                While you can't remove any of those features, you can customize most of them to meet your needs;

                    For example, the Point record defines ToString to display text like:
                            
                            Point { X = 2, Y = 3 }
                        
                        If you wanted your Point record to show it like: (2, 3) instead, you could simply add in your own definition for ToString:

                                public record Point(float X, floatY)
                                {
                                    public override string ToString() => $"({X}, {Y})";
                                }

                                    In most situations where the compiler would normally synthesize a member for you, if it sees that you've provided a definition,
                                    it will use your version instead.
                        
                        One use for this is defining the properties as mutable properties or fields instead of the default init-only property.
                        The compiler will not automatically assign initial values to your version if you do this. You'll want to initialize them yourself like so:

                                public record Point(float X, float Y)
                                {
                                    public float X { get; set; } = X;
                                }

                You cannot supply a definition for the constructor (though this limitation is removed if you make a non-positional record, described later).

                You cannot define many of the equality-related members, including Equals(object) or the == and the != operators.

                    However, you can define Equals(Point), or whatever the record's type is.
                        Equals(object), ==, and != each call Equals(Point), so you can usually achieve what you want despite this limitation.
                    
                                                Non-Positional Records:
                    
                    Most records will include a set of properties in parentheses after the record name.
                    These are positional records because the properties have a known, fixed ordering (which also matters for deconstruction).
                        These parameters are not strictly required. You could aso write a simple record like this:

                                public record Point
                                {
                                    public float X { get; init; }
                                    public float Y { get; init; }
                                }

                                    In this case, you wouldn't get he constructor or the ability to do deconstruction (unless you add them in yourself),
                                    but otherwise this is the same as any other record.

                                                Struct- and Class-based Records:
                    
                    The compiler turns records into classes by default because this si the more common scenario.
                        However, we can also make a record struct instead:

                                public record struct Point(float X, float Y);
                        
                        This code will now generate a struct instead of a class, bringing along all the other things we know about structs vs. classes
                            Example: We now have a record that defines a value type instead of a reference type.
                    
                    A record struct creates properties slightly different from class-based structs.
                    They are defined as get/set properties instead of get/init.
                        The record struct above becomes something more like this:

                                public struct Point
                                {
                                    public float X { get; set; }
                                    public float Y { get; set; }

                                    public Point(float x, float y)
                                    {
                                        X = x;
                                        Y = y;
                                    }
                                }
                    
                    Records are class-based, by default, but if you want to call it out specifically, you can right it out specifically:

                            public record class Point(float X, float Y);

                            This definition is no different that if it were defined without the 'class' keyword,
                            other than drawing a bit more attention to the choice of making the record class-based.

                    Whichever way you go, you can generally expect the same things of a record as you can of the class or struct it would become.

                        For example, since ou can make a class abstract or sealed, those are also options for class-based records.


                                                        Inheritance:
                
                Class-based records can also participate in inheritance with a few limitations.
                Records cannot derive from normal classes, and normal classes cannot derive from records.

                The syntax for inheritance in a record is worth showing:

                        public record Point(float X, float Y);
                        public record ColoredPoint(Color color, float X, float Y) : Point(X, Y);

                                                        
                                                        When To Use A Record:
            
            When defining a class or a struct, you have the option to use the record syntax.
            So, when should we make a record, and when should we create a normal class or struct?

            The record syntax conveys a lot of information in a very short space.
            If the feature set of records fits your needs, you should generally prefer the record syntax.
            Records give you a concise way to make a type with several properties and a constructor to initialize them.
                They also give you a nice string representation, value semantics, deconstruction, and the ability to use 'with' statements.

                    If that suits your needs, a record is likely the right choice.
                    If those features get in the way or are unhelpful, then a regular class or struct is the better choice.

            You should also consider records as a possible alternative to tuples.
            You need to go through the trouble of formally defining the record type, but, you get actual names for the type and its members.

            Fortunately, it isn't usually hard to swap out one of these options for another.
            If you change you mind, you can change the code (and your intuition will get better with practice).
*/

//--------------------------------------------------------------------Challenge: War Preparations
Console.WriteLine("\t\t\t\tChallenge: War Preparations\n\nAs you pass through the city of Rocaard, two blacksmiths, Cygnus and Lyra, approach you.\"We know\nwhere this is headed. A confrontation with the Uncoded One's forces,\" Lyra says. Cygnus continues,\n\"You're going to need an army at your side - one prepared to do battle. We forge enchanted swords and\nwill do everything we can to support this cause. We need the Power of Programming to flow unfettered,\ntoo. We want to help, but we can't equip an entire army without the help ofa program to aid in crafting\nswords.\" They describe the program they need, and you dive in to help.\n\n");
Console.WriteLine("Objectives:\n\n-\tSwords can be made out lf any of the following materials: wood, bronze, iron, steel, and the rare\n\tbinarium. Create an enumeration to represent the material type.\n-\tGemstones can be attached to a sword, which gives them strange powers through Cygnus and Lyra's\n\ttouch. Gemstone types include emerald, amber, sapphire, diamond, and the rare bitstone. Or no\n\tgemstone at all. Create an enumeration to represent a gemstone type.\n-\tCreate a Sword record with a material, gemstone, length, and cross-guard width.\n-\tIn your main program, create a basic Sword instance made out of iron and with no gemstone. Then\n\tcreate two variations on the basic sword 'with' expressions.\n-\tDisplay all three sword instances with code like Console.WriteLine(original);\n\n");
//--------------------------------------------War Preparations(start)
Sword basicSword = new(Material.Iron, Gemstone.None);
Sword sapphireSword = basicSword with { Gemstone = Gemstone.Sapphire, Length = 60 };
Sword ultraSword = sapphireSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone, CrossGuardWidth = 22 };

Console.WriteLine(basicSword);  // overriding the record provided ToString() method
Console.WriteLine(sapphireSword);
Console.WriteLine(ultraSword);
public record Sword (Material Material, Gemstone Gemstone)
{
    public float Length { get; set; } = 45;
    public float CrossGuardWidth { get; set; } = 18;
    public override string ToString() => $"\n{Gemstone} encrusted {Material} Sword.\nLength of {Length}units, with a cross guard width of {CrossGuardWidth}units.\nForged by Cygnus & Lyra.";
}
public enum Material { Wood, Bronze, Iron, Steel, Binarium };
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone };
//--------------------------------------------War Preparations(end)