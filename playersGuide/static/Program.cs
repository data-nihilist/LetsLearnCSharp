/*
    Static things (values, methods, constructors) that are owned by the type rather than a single instance (shared across all instances)
    If a class is marked static, it can only contain static members (Console, Convert, Math)

        pubic class SomeClass
        {
            private int _number;            // Each instance of SomeClass will have its own _number field.
            public int Number => _number;   // Calling this property will be calling something that's associated with the instance itself (its _number data) not the class

            public SomeClass(int value)
            {
                _number = value;
            }
        }
                                            // Each instance is independent of the others, other than sharing the same class definition.
    
    We can mark members of a class with the static keyword to detach them from individual instances and tie it to the class itself.

    By applying the 'static' keyword to a field, we create a static field or static variable.
    These are especially useful for defining variables that affect every instance in the class.

    For example, we can add these two static fields that will help determine if a score (an instance of a Score class) is worth putting on on the high score table:
    
    Static fields are conventionally UpperCamelCase as opposed to what we've seen so far so they stand out in our code.

        public class Score
        {
            private static readonly int PointThreshold = 1000;
            private static readonly int LevelThreshold = 4;
        }
    
    We can use all the same modifiers on a static field as a normal field. Occasionally, regular, non-static fields are referred to as instance fields for clarity.

    Static fields are used within the class in the same way that you would use any other field.

    public bool IsWorthyOfTheHighScoreTable()
    {
        if (Points < PointThreshold) return false;
        if (Level < LevelThreshold) return false;
        return true;
    }

    If a static field is public, it can be used outside the class through the class name (Score.PointThreshold, for example)
    CAUTION: If a field is static, public, and not read-only, it creates 'global state.' Global state is data that can be changed and used anywhere in our program.
        -Global state is considered dangerous because one part of our program can affect other parts even though they seem unrelated to each other.
        -Unexpected changes to global state can lead to bugs that take a long time to figure out, and in most situations, we're better off not having it.
        -It's the combination that makes it dangerous, so, making the field private instead of public limits access to just hte class which is easier to manage.
        -Making the field readonly ensures it can't change over time, preventing one part of the code from interfering with other parts.
        -If it is not static, only parts of the program that have a reference to the object will be able to do anything with it.
        -Just be cautious any time we create a public static field.
    
    Properties can also be made static - these can use static fields as their backing fields, or you can make them auto-properties.
    These have the same global state issue that fields have, so be careful with public static properties as well.

    Here's the property version of those two thresholds that we made as fields earlier:

        public class Score
        {
            public static int PointThreshold { get; } = 1000;
            public static int LevelThreshold { get; } = 4;
        }

    We've used static properties on the Console class.
        Console.ForegroundColor and Console.Title are examples we've used so far, which are both good examples of the danger of global state;
            If one part of the code changes the color to red to display an error, everything afterward will also be written in red until somebody changes it back.
    

    A static method is not tied to a single instance, so it cannot refer to any non-static (instance) fields, properties, or methods.

    Static methods are most often used for utility or helper methods that provide some sort of service related to the class they are placed in, but that isn't tied directly to a single instance.

    For example - determining how many scores in an array belong to a specific player:

        ...
        public static int CountForPlayer(string playerName, Score[] scores)
        {
            int count = 0;
            foreach (Score score in scores)
                if (score.Name == playerName) count++;
            return count;
        }
        ...
    
    This method wouldn't make sense as an instance method because it is about many scores, not a single score.
    It makes sense as a static method in the Score class because it is closely related to the Score concept.

    Another common use of static methods is a 'factory method', which creates new instances for the outside world as an alternative to calling a constructor.

    For example, this method could be a factory method in our Rectangle class:

        public static Rectangle CreateSquare(float size) => new Rectangle(size, size);

    This method can be called like this:

        Rectangle rectangle = Rectangle.CreateSquare(2);
    
    This code also illustrates how to invoke static members from outside the class. BUt it should look familiar; this is how we've been calling things like
    Console.WriteLine and Convert.ToInt32, which are also static methods.

    If a class has static fields or properties, you may need to run some logic to initialize them. To address this you could define a static constructor:
        A static constructor cannot have parameters, nor can you call it directly.
        Instead, it runs automatically the first time you use the class.
        Because of this, you cannot place an accessibility modifier like public or private on it.

        public class Score
        {
            public static readonly int PointThreshold;
            public static readonly int LevelThreshold;

            static Score()
            {
                PointThreshold = 1000;
                LevelThreshold = 4;
            }

            // ...
        }

    Some classes are nothing more than a collection of related utility methods, fields, or properties - Console, COnvert, and Math are all examples of this.

    In these cases, you may want to forbid creating instances of the class, which is done by marking it with the static keyword:

        public static class Utilities
        {
            public static int Helper1() => 4;
            public static double HelperProperty => 4.0;
            public static int AddNumbers(int a, int b) => a + b;
        }

    The compiler will ensure that you don't accidentally add non-static members to a static class and prevent new instances from being created with the 'new' keyword.

    Because Console, Convert, and Math are all static classes, we never needed - nor are we allowed - to make an instance with the 'new' keyword
*/

//----------------------------------------------------------------------------------Arrow Factories (start)
Console.WriteLine("\t\t\t\tArrow Factories\n");

Arrow eliteArrow = Arrow.CreateEliteArrow();
Console.WriteLine(eliteArrow.PriceOfArrow());
Console.WriteLine();

Arrow beginnerArrow = Arrow.CreateBeginnerArrow();
Console.WriteLine(beginnerArrow.PriceOfArrow());
Console.WriteLine();

Arrow marksmanArrow = Arrow.CreateMarksmanArrow();
Console.WriteLine(marksmanArrow.PriceOfArrow());
Console.WriteLine();


public class Arrow
{
    private Arrowhead _arrowhead;
    private float _length;    // between 60 and 100 cm
    private Fletching _fletching;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)    // constructor
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

    public static Arrow CreateEliteArrow()
    {
        return new Arrow (Arrowhead.Steel, Fletching.Plastic, 95);
    }

    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow (Arrowhead.Wood, Fletching.GooseFeathers, 75);
    }

    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow (Arrowhead.Steel, Fletching.GooseFeathers, 65);
    }

public Arrow()          // constructor
    {
        _length = 80;
    }

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
//----------------------------------------------------------------------------------Arrow Factories (end)