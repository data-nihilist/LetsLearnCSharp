/*SpeedRun
        An interface is a type that defines a 'contract,' or, 'role,' that objects can fulfill or implement:

                public interface ILevelBuilder               // declaring an interface
                { 
                    Level BuildLevel(int levelNumber);       // naming a role that a class will need to fulfill
                }

        Classes can implement interfaces:

                public class LevelBuilder : ILevelBuilder   // implementing our interface using the : symbol (same as inheritance of a base class to a derived class)
                {
                    public Level BuildLevel(int levelNumber) => new Level();    // here's that role our interface had listed before
                }

        A class can have only one base class but can implement many interfaces.
*/

/*
    We can create new types using enumerations and classes, but you can make several other flavors of type definitions in C#;

                                                                    Interfaces:

        An interface is a type that defines an object's interface, or, 'boundary' by listing the methods, properties, etc. that an object
        must have without supplying any behavior for them.

        You could also think of an interface as defining a specific 'role' or 'responsibility' in the system without providing the code to make it happen.

            We see interfaces in the real world all the time: 
                
            A piano with its 88 black and white keys and an expectation that pushing the keys will play certain pitches is an interface.
                Electric keyboards, upright pianos, grand pianos, and even organs and harpsichords provide the same interface.
                    A user of the interface - a pianist - can play nay of these instruments in the same way without worrying about how they each produce sound.

            We see a similar thing with vehicles, which all present a steering wheel, an accelerator, and a brake pedal.
                As a driver, it doesn't matter if the engine is gas, diesel, or electric or whether the brakes are frictional or electromagnetic.
        
        Interfaces give us the most flexibility in how something accomplishes its job.
            It is almost as though we have made a class where every member is abstract - though it is even more flexible than that!

    Interfaces are perfect for situations where we know we may want to substitute entirely different or unrelated objects to fulfill a specific role or 
        responsibility in our system - they give us the most flexibility in evolving our code over time.

        The only assumption made about the object is that it complies with the defined interface.
            As long as two things implement the same interface, we can swap one for another, and the rest o the system is none the wiser.
*/

/*
                                                                Defining Interfaces:

        Let's say we have a game where the player advances through levels, one at at time.
            We'll keep it simple and say that each level is a grid of different terrain types from this enumeration:

                    public enum TerrainType { Desert, Forests, Mountains, Pastures, Fields, Hills }     // enumeration type for example code
            
            Each level is a 2D grid of these terrain types, represented by an instance of this class:

                    public class Level                 // Level class definition
                    {
                        public int Width { get; }       // property
                        public int Height { get; }      // property
                        public TerrainType GetTerrainAt(int row, int column)    // member method
                        {
                            //...
                        }
                        //...
                    }
            
            We find a use for interfaces when deciding where level definitions come from. There are many options;
                We could define them directly in code, setting terrain types at each row and column in C# code.
                We could load them from files on our computer.
                We could load them from a database.
                We Could randomly generate them.
                There are many options, and each possibility has the same result and the same job, role, or responsibility: create a level to play.

                    Yet, the code for each is entirely unrelated to the code for the other options..
            
            We may not know yet which of these we will end up using, or,
            perhaps we plan to retrieve the levels from the internet but don't intend to get a web server running for a few months and need a short-term fix.
        
        To preserve as much flexibility as possible around this decision, we simply define what this role must do;
            What interface, or boundary, the object/objects fulfilling this role will have:

                    public interface ILevelBuilder
                    {
                        Level BuildLevel(int levelNumber);
                    }
                
                Interface types are defined similarly to a class but with a few differences - for starters, we use the 'interface' keyword in place of 'class'

                You can see in the code above we started the interface name with a capital 'I' - not necessary! But it's common convention in C#.
                    This will lead to the occasional double 'I' names.. but you get used to it.

        Because an interface defines just the boundary, or 'job', to be done, its members don't have an implementation;
            There is an exception to this, we'll look at that soon.
        
        Most things you might place in a class can also be placed in an interface (without an implementation) except fields.

                While the ILevelBuilder interface above has a single method, interfaces can have as many members as they need to define the role they represent.
                    Example: We could let the rest of the game know how many levels are in the set by adding an 'int Count { get; }' property.
*/

/*
                                                                Implementing Interfaces:

                Once an interface has been created, the next step is to build a class that fulfills the job described by the interface.
                        This is called, "implementing the interface".
                It looks a lot like inheritance, so some programmers also call it 'extending' the interface, or, 'deriving from' the interface.

                    Moving forward, we'll refer to these subtleties as: "implementing an interface" and "extending a base class", respectively
                
                The simplest implementation of the ILevelBuilder interface is probably defining levels in code:

                        public class FixedLevelBuilder : ILevelBuilder
                        {
                            public Level BuildLevel(int levelNumber)
                            {
                                Level level = new Level(10, 10, TerrainType.Forests);

                                level.SetTerrainAt(2, 4, TerrainType.Mountains);
                                level.SetTerrainAt(2, 5, TerrainType.Mountains);
                                level.SetTerrainAt(6, 1, TerrainType.Desert);

                                return level;
                            }
                        }
                
                We're taking a few liberties with the BuildLevel above:
                            1. It's using a constructor and a SetTerrainAt method that we didn't not define earlier in the Level class (imagine we included them)
                            2. It also creates the same level every time, ignoring the levelNumber parameter.
                                    In a real-world situation, we'd probably need to do more.
                                        The vital part of the above code is how FixedLevelBuilder implements the ILevelBuilder interface.
                    
                    Like extending a base class through inheritance, we place a colon, : , followed by the name of the interface we're implementing.
            
            NOTE: We must define each member included in the interface, as we did with the BuildLevel method.
                    These will be 'public' but do not put the 'override' keyword on them! This isn't an override.
                        It's simply filling in the definition of how this class performs the job it has claimed to do by implementing the interface.

            NOTE: An interface can declare a property with a 'get' accessor, while a class that implements it can ALSO include a 'set' or 'init' accessor.
        
        We can create variables that use an interface as their type and place in it anything that implements that interface:

                ILevelBuilder levelBuilder = LocateLevelBuilder();

                int currentLevel = 1;

                while (true)
                {
                    Level level = levelBuilder.BuildLevel(currentLevel);
                    RunLevel(level);
                    currentLevel++;
                }

                        The rest of the game doesn't care which implementation of ILevelBuilder is being used.
                        However, with the code we have written so far, we know it will be FixedLevelBuilder since that is the only one that exists!

            By doing nothing more than adding a new class that implements ILevelBuilder and changing the implementation of LocateLevelBuilder to return that instead,
            we can completely change the source of levels in our game!

            The entire rest of the game does not care where they come from, as long as the object building them conforms to the ILevelBuilder interface.

            We have reserved a great degree of flexibility for the future by merely defining and using an interface.
*/

/*
                                                                Interfaces and Base Classes:
                        
            Interfaces and base classes can play nicely together.
            A class can simultaneously extend a base class and implement an interface.
            Do this by listing the base class followed by the interface after the colon, separated by commas:

                    public class MySqlDatabaseLevelBuilder : BasicDatabaseLevelBuilder, ILevelBuilder       <--(base class to extend, interface to implement)
                    {
                        // ...
                    }

        A class can implement several interfaces in the same way by listing each one, separated by commas:

                public class SomeClass : ISomeInterface1, ISomeInterface2
                {
                    // ...
                }
            
                While you can only have one base class, a class can implement as many interfaces as you want.

                    NOTE: Implementing many interfaces may signify that an object or class is trying to do too much
            
            Finally, an interface itself can list other interfaces (but not classes) that it augments or extends:

                    public interface IBroaderInterface : INarrowerInterface
                    {
                        // ...
                    }
                
                When a class implements IBroaderInterface, they will also be on the hook to implement INarrowerInterface.
*/

/*
                                                        SIDE QUEST: Explicit Interface Implementations
            
            Occasionally, a class implements two different interfaces containing members with the same name but different meanings. For example:

                        public interface IBomb { void BlowUp(); }
                        public interface IBalloon { void BlowUp(); }

                        public class ExplodingBalloon : IBomb, IBalloon
                        {
                            public void BlowUp()
                            {
                                // ...
                            }
                        }

                            This single method is enough to implement both IBomb and IBalloon. If this one method definition is a good fit for both - you're done!
            
            On the other hand, in this situation, "Blow up" means different things for bombs than it does for balloons.

                When we define ExplodingBalloon's BlowUp method, which one are we referring to?

            If you have control over these interfaces, consider renaming one or the other. We could rename IBomb.BlowUp to Detonate, or IBalloon.BlowUp to Inflate.

            But, if you don't want to or simply can't, the other choice is to make a definition for each using an 'explicit interface implementation':

                    public class ExplodingBalloon : IBomb, IBalloon
                    {
                        void IBomb.BlowUp() { Console.WriteLine("Kaboom!"); }
                        void IBalloon.BlowUp { Console.WriteLine("Whoosh"); }
                    }
                
                    By prefacing the method name with the interface name, you can define two versions of BlowUp, one for each interface.
                        NOTE: The 'public' has been removed. This is required with explicit interface implementations.
            
            The big surprise is that explicit implementations are detached from their containing class:

                    ExplodingBalloon explodingBalloon = new ExplodingBalloon();
                    // explodingBalloon.BlowUp() // COMPILER ERROR

                    IBomb bomb = explodingBalloon;
                    bomb.BlowUp();

                    IBalloon balloon = explodingBalloon;
                    balloon.BlowUp();

                        In this situation, ou cannot call BlowUp directly on ExplodingBalloon!
                            Instead, we must store it in a variable that is either IBomb or IBalloon (or cast it to one or the other).
                                Then it becomes available because it is no longer ambiguous which BlowUp method it needs to call.
                        
                        If one of the two is more natural for the class, you can choose to do an explicit implementation for only one, leaving the other as the default.
                        If you do this, then the non-explicit implementation is accessible on the object without casting it to the interface type.
*/

/*
                                                        SIDE QUEST: Default Interface Methods

        Interfaces allow you to create a default implementation for methods with some restrictions.
            If you do not like these restrictions, an abstract base class may be a better fit.
        Default implementations are primarily for growing or expanding an existing interface to do more.
            Imagine having an interface with ten classes that implement the interface.
                If you want to add a new method or property to this interface, you have to revisit each of the ten implementations to adapt them to the new changes.
        
        If you can get an interface definition right he first time around, it saves you from this rework.
        It is worth taking time to try and get interfaces right, but we can never guarantee that.
        Sometimes, things just need to change.

            Of course, you can just go for it and add the new member to each of the many implementations.
                This is often a good, clean solution, even if it takes time.
        
        In other situations, providing a default implementation for a method can be a decent alternative.
            Imagine you have an interface that a thousand programmers around the world use.
                If you change the interface, they'll all need to update their code.
                    A default implementation may save a lot of pain for many people.
        
        Let's suppose we started with this interface definition:

                public interface ILevelBuilder
                {
                    Level BuildLevel(int levelNumber);
                    int Count { get; }
                }

                    If we wanted to build all the levels at once, we might consider adding a Level[] BuildAllLevels() method to this interface. Not complicated:

                            public interface ILevelBuilder
                            {
                                Level BuildLevel(int levelNumber);
                                int Count {get; }

                                Level[] BuildAllLevels()
                                {
                                    Level[] levels = new Level[Count];

                                    for(int index = 1; index <= Count; index++)
                                    {
                                        levels[index - 1] = BuildLevel(index);
                                    }

                                    return levels;
                                }
                            }

                                With this default implementation, nobody else will have to write a bBuildAllLevels method unless they need something special.
                                    If they do, it is a simpl matter of adding a definition for the method in the class.
                
                A default implementation can use the other members of the interface. We see that above since BuildAllLevels calls both Count and BuildLevel.
*/

/*
                                                        SIDE QUEST: Supporting Default Interface Methods
            
            Default interface method implementations are a relatively new thing to C#.
            When they decided to add this feature, they provided many of the tools needed to do it well.
                For example, if a single method becomes too big, you can split some of the code into private methods.
                You can also create protected methods and static methods.
                We won't get into all the details because default method implementations are not all that common, and 
                the compiler will tell you if you attempt something that does not work.
                    However, one significant constraint is that you cannot add instance fields. Interfaces cannot contain data themselves (static fields are allowed)
        
                                                        SHOULD I USE DEFAULT INTERFACE METHODS?
                        
                        Adding default implementations in an interface was a somewhat controversial change.
                        It is hard for those making widely used interfaces to update every implementing class.
                        The benefits of default implementations are a lifesaver to them.
                            But for many others, the benefits are small, and it serves little value other than to cloud the concept of an interface.
                    
            QUESTION:   Should you embrace them and provide one for every method you make, avoid them like the plague, or something in between?

                        Interfaces are meant to define just the boundary, not the implementation.
                        Skip default implementations except when many classes implement the interface,
                            and when the default implementation is nearly always correct for the classes that use the interface.

                        Not every interface change can be solved with default method implementations.
                        It only works if you are adding new stuff to an interface.
                        If you are renaming or removing a method, you will just need to fix all the classes that implement the interface.
*/

//----------------------------------------------------------------------Challenge: Robotic Interface
Console.WriteLine("\n\t\t\t\tChallenge: Robotic Interface\n\nWith your knowledge of interfaces, you realize you can refine the old robot you found in the mud to use\ninterfaces instead of the original design. Instead of an abstract RobotCommand base class, it could\n\tbecome an IRobotCommand interface!\n\nBuilding on your solution to the Old Robot challenge, perform the changes below:");
Console.WriteLine("\n\nObjectives:\n\n-\tChange your abstract RobotCommand class into an IRobotCommand interface.\n-\tRemove the unnecessary 'public' and 'abstract' keywords from the Run method.\n-\tChange the Robot class to use IRobotCommand instead of RobotCommand.\n-\tMake all of your commands implmeent this new interface instead of extending the RobotCommand\n\tclass that no longer exists. You will also want to remove the override keywords in these classes.\n-\tEnsure your program still compiles and runs.\n-\tAnswer this question: Do you feel this is an improvement over using an abstract base class? Why or why not?\n\n");
//-----------------------------------------------Robotic Interface (start)
Robot robot = new Robot();

for(int index = 0; index < robot.Commands.Length; index++)
{
    string? input = Console.ReadLine();
    robot.Commands[index] = input switch        // been a while since I used a switch expression
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    };
}

Console.WriteLine();

robot.Run();

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}


public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
//-----------------------------------------------Robotic Interface (end)
// Answer this question: Do you feel this is an improvement over using an abstract base class? Why or why not?
//
// In this situation, I think this is better. For starters, there's less code to do the same thing. No need
// to have those abstracts and overrides everywhere. But at a more substantial level, inheritance is a pretty
// strong relationship, and these commands do not really need to have that strong of a relationship to each
// other. The only thing that really binds them together is that they do the same type of thing. So I think
// it is better for that reason.