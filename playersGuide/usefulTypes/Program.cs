//--------------------------------------------------------------------------------------------------------Random class
/*
        The Random class generates random numbers.
        Some programs (like games) are more likely to use random numbers than others, but randomness can be found anywhere.

        Pseudo-random generators have to start with an initial value called a 'seed'
            If you re-use the same seed, you will get the same random-looking sequence again precisely.
                    This can be both good and bad
                        Minecraft generates worlds based on a seed - sometimes you want a specific random world
                        By telling Minecraft to use a particular seed, you can see the same world again
                        But most of the time you want a random seed to get a unique world.
        Example:

                Random random = new Random()
            
            The Random() constructor is initialized with an arbitrary seed value, which means you will not see the same sequence
            appear ever again with another random object or by re-running the program.
        
        Random's most basic method is the Next() method.
            Next picks a random non-negative (0 or positive) int with equal chances of each other.
                You're just as likely to get 7 as 1,844,349,103
                    Such a large range is rarely useful, so a couple overloads of Next give you more control.
                        Next(int x) let's you pick the ceiling:

                                Console.WriteLine(random.Next(6));

                                    random.Next(6) will give you 0, 1, 2, 3, 4, 5 (but not 6) as possible choices, each equally probable.

            It's common to add 1 to finish the expression to include the integer provided as the ceiling, like so:

                    Console.WriteLine($"Rolling a six-sided die: {random.Next(6) + 1}");
            
            The third overload of Next() allows you to name the minimum value:

                    Console.WriteLine(random.Next(18, 22));

                        This will randomly pick from the values 18, 19, 20, and 21 (but not 22)

            If you want floating-point values instead of integers, you can use NextDouble():

                    Console.WriteLine(random.NextDouble());

                This will give you a double in a range of 0.0 to 1.0 (strictly speaking, 1.0 won't ever come up, but 0.99999999 can).
                    You can stretch this out over a larger range with some simple arithmetic.
                        The following will produce random numbers in the range 0 to 10:

                                Console.WriteLine(random.NextDouble() * 10);
                            
                            And this will produce random numbers in the range -10 to +10:

                                    Console.WriteLine(random.NextDouble() * 20 - 10);

                            The Random class also has a constructor that lets you pass in a a specific seed:

                                    Random random = new Random(3445);
                                    Console.WriteLine(random.Next());
*/
//--------------------------------------------------------------------------------------------------------DateTime struct
/*
    When dealing with dates and times, this is your go-to struct to represent them and get the current date and time;

        The DateTime struct stores moments in time and allows you to get the current time.
        One way to create a DateTime value is ith its constructors:

            DateTime time1 = new DateTime(2022, 12, 31);
            DateTime time2 = new DateTime(2022, 12, 31, 23, 59, 55);
        
        This creates a time at the start of 31, December 2022, and at 11:59:55PM on 31, December 2022, respectively.
            There are 12 total constructors for DateTime, each requiring different information.
        
        Even more useful are the static DateTime.Now and DateTime.UtcNow properties:

                DateTime nowLocal = DateTime.Now;
                DateTime nowUtc = DateTime.UtcNow;
            
            DateTime.Now is in your local time zone, as determined by your computer.
            DateTime.UtcNow gives you the current time in Coordinate Universal Time (or UTC), which is essentially the worldwide time.
        
        A DateTime value has various properties to see the year, month, day, hour, minute, second, and millisecond - among other things.
            The following demonstrates some simple uses:

                    DateTime time = DateTime.Now;
                    if(time.Month == 10)
                    {
                        Console.WriteLine("Happy Halloween!");
                    }
                    else if(time.Month == 4 && time.Day == 1)
                    {
                        Console.WriteLine("April Fools!");
                    }
            
                There are also methods for getting new DateTime values relative to another:

                        DateTime tomorrow = DateTime.Now.AddDays(1);
                    
            The DateTime struct is very smart, handling many easy-to-forget corner cases, such as leap years and day-of-the-week calcs.
            
*/
//--------------------------------------------------------------------------------------------------------TimeSpan struct
/*
    The TimeSpan struct represents a span of time.
        You can create values of the TimeSpan struct in one of two ways - several constructors let you dictate the length of time:

                TimeSpan timeSpan1 = new TimeSpan(1, 30, 0);            // 1 hour, 30 minutes, 0 seconds
                TimeSpan timeSpan2 = new TimeSpan(2, 12, 0, 0);         // 2 days, 12 hours
                TimeSpan timeSpan3 = new TimeSpan(0, 0, 0, 0, 500);     // 500 milliseconds
                TimeSpan timeSpan4 = new TimeSpan(10);                  // 10 "ticks" == 1 microsecond
        
        That last one is notable;
            Internally, TimeSpan keeps track of times in a unit called a 'tick,' which is 0.1 microseconds, or 100 nanoseconds
                This is as fine-grained as a TimeSpan can get, but you rarely need more than that.
        
        The other way to create TimeSpans is with one of the various From'X' methods:

                TimeSpan aLittleWhile = TimeSpan.FromSeconds(3.5);
                TimeSpan quiteAWhile = TimeSpan.FromHours(1.21);
            
            The whole collection includes FromTicks, FromMilliseconds, FromSeconds, FromHours, and FromDays.
        
        TimeSpan has two sets of properties that are worth mentioning;
            - First is this set:    Days, Hours, Minutes, Seconds, Milliseconds
                These represent the various components of the TimeSpan:

                        TimeSpan timeLeft = new TimeSpan(1, 30, 0);
                        Console.WriteLine($"{timeLeft.Days}d {timeLeft.Hours}h {timeLeft.Minutes}m");
                    
                    timeLeft.Minutes does not return 90, since 60 of those come from a full hour, represented by the Hours property.
            
            -Another set of properties capture the entire timespan in the unit requested;  
                TotalDays, TotalHours, TotalMinutes, TotalSeconds, and TotalMilliseconds:

                        TimeSpan timeRemaining = new TimeSpan(1, 30, 0);
                        Console.WriteLine(timeRemaining.TotalHours);        => 1.5
                        Console.WriteLine(timeRemaining.TotalMinutes);      => 90
        
        Both DateTime and TimeSpan have defined several operators for things like comparison (>, <, >=, <=), addition, and subtraction.

                DateTime eventTime = new DateTime(2022, 12, 4, 5, 29, 0); // 4 Dec 2022 @ 5:29am
                TimeSpan timeLeft = eventTime - DateTime.Now;
                // 'TimeSpan.Zero' is no time at all.
                if(timeLeft > TimeSpan.Zero)
                {
                    Console.WriteLine($"{timeLeft.Days}d {timeLeft.Hours}h {timeLeft.Minutes}m");
                }
                else
                {
                    Console.WriteLine("This event has passed.");
                }
            
    The second line above shows that subtracting one DateTime from another results in a TimeSPan that is the amount of time between the two.
    The if statement shows a comparison against the special TimeSpan.Zero value.
*/
//--------------------------------------------------------------------------------------------------------Guid struct
/*
        The Guid struct represents a globally unique identifier - or GUID (usually pronounced like it rhymes with 'squid')
        You may find value in giving objects or items a unique identifier to track them independently from other similar objects in certain programs.
            This is especially true if you send information across a network, where you can't just use a simple reference.
                While you could use an int or long as unique numbers for these objects, it can be tough to ensure that each item has a truly unique number.
                    This is especially true if different computers have to create the unique number.
            
            The idea is that if you have enough possible choices, two people picking at random won't pick the same thing.

        If all of humanity had a beach party and each of us went and picked a gain of sand on the beach, the chance that any of us pick the same grain is vanishingly small.
            The generation of new identifiers with the Guid struct is similar:

                    Guid id = Guid.NewGuid();
                
                Each Guid value is 16bytes (4 times as many as an int), ensuring plenty of available choices.
                    But NewGuid() is smarter than just picking a random number.

                    It has smarts built in that ensure that other computers won't pick the same value.
                        It ensures that multiple calls to NewGuid() won't ever give you the same number again.
        
        A Guid is just a collection of 16 bytes, but it is usually written in hexadecimal with dashes breaking it into smaller chunks like this:

                10A24EC2-3008-4678-AD86-FCCCDA8CE868
        
                        Once you know about GUIDs, you will see them pop up all over the place.
        
        If you already have a GUID and do not want to generate a new one, there are other constructs that you can use to build a new Guid value that represents it:

                Guid id = new Guid("10A24EC2-3008-4678-AD86-FCCCDA8CE868");

            Just be careful about inadvertently reusing a GUID in situations that could cause conflicts.
            Copying and pasting GUIDs can lead to accidental reuse.
                Visual Studio has a tool to generate a random GUID under Tools > Create GUID, and you can find similar things online.
*/
//--------------------------------------------------------------------------------------------------------List<T> class
/*
        The List<T> class (System.Collections.Generic namespace) is perhaps the most versatile generic class in .NET.
            List<T> is a collection class where order matters, you can access items by their index, and where items can be added and removed easily.

                They are like an array, but their ability to grow and shrink makes them superior in virtually all circumstances.
                    In fact, going forward from this chapter, we'll rarely use arrays.
        The List<T> class is a complex class with many capabilities. We won't look at all of them here, but let's check out the most important onces

--------------------------------------------------------Creating List Instances
                                    
        There are many ways to create a new list, but the most common is to make an empty list:

                List<int> numbers = new List<int>();
            
            This makes a new List<int> instance with nothing in it. You will do this most of the time.
                If a list has a known set of initial items you can use collection initializer syntax as we did with arrays:

                        List<int> numbers = new List<int>() { 1, 2, 3 };

                            If the constructor is parameterless, we can omit the parentheses during initialization => List,int> numbers = new List<int> { 1, 2, 3 };
        
        Lists also support indexing just like arrays, and use 0-based indexing:

                List<string> words = new List<string>() { "apple", "banana", "corn", "durian" };
                Console.WriteLine(words[2]);    => "corn"
            
            We can also replace items in the list as we do with arrays:

                    words[0] = "avocado";

--------------------------------------------------------Adding And Removing From A List
        
        A key benefit of lists over arrays is the easy ability to add and remove items:

                List<string> words = new List<string>();
                words.Add("apple");

                    Add() puts items at the back of the list.
                    To put something in the middle, you use Insert, which requires an index and the item:

                            List<string> words  = new List<string>() { "apple", "banana", "durian" };
                            words.Insert(2, "corn");
                
                If you need to add or insert many items, the AddRange() and InsertRange() methods will accomplish this like so:

                        List<string> words = new List<string>();
                        words.AddRange(new string[] { "apple", "durian" });
                        words.InsertRange(1, new string[] { "banana", "corn" });
                
                These allow you to supply a collection of items to add to the back of the list (AddRange) or insert in the middle (InsertRange).
                We used arrays above, though the specific type involved is the IEnumberable<T> interface, which we will discuss next.
            
            To remove items from the list, you can name the item to remove with the Remove method:

                    List<string> words = new List<string>() { "apple", "banana", "corn", "durian" };
                    words.Remove("banana");
                
                If an item is in the collection more than once, only the first occurrence is removed. Remove returns a bool that tells you whether anything was removed.
                If you need to remove al occurrences, you could oop until that starts returning false.
            
            If you want to remove the item at a specific index, use RemoveAt:

                    words.RemoveAt(0);

            The Clear method removes everything in the list:

                    words.Clear();
                
                Since we're talking about adding and removing items from a list, you might be wondering how to determine how many things are in the list.
                Unlike an array, which has aLength property, a list has a Count property:
                        
                        Console.WriteLine(words.Count); => will output 0, since we just used Clear() on our list.

--------------------------------------------------------foreach Loops and LIsts
        
        We can use a foreach loop with a List<T> as you might with an array:

                foreach(Ship ship in ships)
                {
                    ship.Update();
                }
        
        But there's a crucial catch: you cannot add or remove items in a List<T> while a foreach is in progress.
            This doesn't cause issues very often, but every so often, it is painful.

                    Example:
                        You have a List<Ship> for a game and you use foreach to iterate through each and let them update.
                        While updating, some ships may be destroyed and removed.

                        By removing something from the list, the iteration mechanism used with foreach cannot keep track ofw hat it has seen, and it will crash.
                            Specifically it will throw an InvalidOperationException
            
            There are two workarounds for this.
                One is use a plain for-loop; Using a for loop and retrieving the item at the current index lets you sidestep the iteration mechanism that a foreach loop uses:

                        for (int index = 0; index < ships.Count; index++)
                        {
                            Ship ship = ships[index];
                            ship.Update();
                        }

                            If you add or remove items farther down the list (at an index beyond the current one), there are not generally complications.

                            But if you add or remove an item before the spot you are currently at, ou will have to account for it;
                                If you are looking at the item at index 3 and insert at index 0 (the start), then what was once index 3 is now index 4.
                                If you remove the item at index 0, then what was once at index 3 is now index 2.
                                You can use ++ and -- to account for this, but it is a tricky situation to avoid if possible.

                                        for (int index = 0; index < ships.Count; index++)
                                        {
                                            Ship ship = ships[index];
                                            ship.Update();
                                            if(ship.IsDead)
                                            {
                                                ships.Remove(ship);
                                                index--;
                                            }
                                        }
                        
                        Another workaround is to hold off on any actual addition or removal during the foreach loop.
                            Instead, we can remember which things need to be added or removed with two lists (toBeAdded and toBeRemoved, respectively)
                                Then, after the foreach, go through the items in those two helper list and useList<T>'s Add, Remove, InsertAt, RemoveAt, etc.

--------------------------------------------------------Other Useful Things

The Contains method tells you if the list contains a specific item, returning 'true' if it is there and 'false' if it is not:

        bool hasApples = words.Contains("apple");
        if(hasApples)
        {
            Console.WriteLine("Apples are already on the shopping list.");
        }

The IndexOf method tells you where in a list an item can be found, or -1 if it is not there:

        int index = words.IndexOf("apple");

            The List<T> class has quite a bit more than we have discussed here, though we have covered the highlights.
*/
//--------------------------------------------------------------------------------------------------------IEnumerable<T> interface
/*
        While List<T> might be the most versatile generic type, IEnumerable,T> might be the most foundational.
        IEnumerable<T> defines a mechanism that allows you to inspect items one at a time.
            This mechanism is the basis for a foreach loop!

                IEnumerable<T> is anything that can provide an 'enumerator,' and the definition looks something like this:

                        public interface IEnumerator<T>
                        {
                            IEnumerator<T> GetEnumerator();
                        }
                
                What is an enumerator?
                    It's a thing that lets you look at items in a set, one at a time, with the ability to start over.
                        The definition looks something like this:

                                public interface IEnumerator<T>
                                {
                                    T Current { get; }
                                    bool MoveNext();
                                    void Reset();
                                }
                        The Current property lets you see the current item.
                        The MoveNext advances to the next item and then returns a bool if there's another item.
                        Reset starts over from the beginning
                            Almost nobody uses an IEnumerator<T> directly.
                            The let the foreach loop deal with it:

                                    List<string> words = new List<string> { "apple", "banana", "corn", "durian" };

                                    foreach(string word in words)
                                    {
                                        Console.WriteLine(word);
                                    }
                                    
                                    while(iterator.MoveNext())
                                    {
                                        string word = iterator.Current;
                                        Console.WriteLine(word);;
                                    }
                            
                            List<T> and arrays both implement IEnumerable<T>, but dozens of other collection types also implement this interface.
                            It is the basis of all collection types.
                            You will see IEnumerable<T> everywhere.
*/
//--------------------------------------------------------------------------------------------------------Dictionary<TKey, TValue> class
/*
        Sometimes you want to look up one object or piece of information using another.
            A dictionary (also called an 'associative array' or a 'map' in other languages), is a data type that makes this possible.
                A dictionary provides this functionality.
        
        You add new items to the dictionary by supplying a 'key' to store the item under, and when you want to retrieve it, you provide the key again to get the item back out.
            The value stored and retrieved via the key is called the 'value'.
        
        The origin of the name - and an illustrative example - is a standard English dictionary.
        Dictionaries store words and their definition.s
        For any word, you can look up its definition in teh dictionary.
        If we wanted to make an English language dictionary in C# code, we could use the generic Dictionary<TKey, TValue> class:

                Dictionary<string, string> dictionary = new Dictionary<String, string>();
        
        We can add items to dictionary using the indexing operator with the key instead of an int:

                dictionary["battleship"] = "a large warship with big guns";
                dictionary["cruiser"] = "a fast but large warship";
                dictionary["submarine"] = "a ship capable of moving under the water's surface";
                Console.WriteLine(dictionary["battleship"]); => "a large warship with big guns"

                    If you reuse a key, the new value replaces the first - the first is gone

                            dictionary["carrier"] = "a ship that carries stuff";
                            dictionary["carrier"] = "a ship that serves as a floating runway for aircraft";
                            Console.WriteLine(dictionary["carrier"]);
                    
                    What if we try to access a value by invoking a key that isn't in dictionary?

                            Console.WriteLine(dictionary["gunship"]);
                        
                        This blows up. It throws a KeyNotFoundException.
                            We can get around this by first checking if the key exists before retrieving it/its value:

                                    if(dictionary.ContainsKey("gunship"))
                                    {
                                        Console.WriteLine(dictionary["gunship"])
                                    }
                            Or we could ask it to use a fallback value with the GetValueOrDefault method:

                                    Console.WriteLine(dictionary.GetValueOrDefault("gunship", "unknown"));
                        
                        If you want to remove a key and its value from dictionary, use the Remove method:

                                dictionary.Remove("battleship");

                                        This returns a bool that indicates if anything was removed.
                
                Dictionaries are generically typed, meaning we can use any types as the <Tkey, Tvalue> types - even classes:

                        Dictionary<int, GameObject> gameObjects = new Dictionary<int, GameObject>();
        
        There is more to Dictionary<Tkey, Tvalue> than we covered above, though we have covered the most essential use cases.
*/
//--------------------------------------------------------------------------------------------------------Nullable<T> struct
/*
        The Nullable<T> struct lets you pretend that a value type can take on a null value.
        It does this by attaching a bool HasValue property to the original value.
        This property indicates whether the value should be considered legitimate.
            One way to work with Nullable<T> is like so:

                    Nullable<int> maybeNumber = new Nullable<int>(3);
                    Nullable<int> another = new Nullable<int>();
            
            The first creates a Nullable<int> where the value is considered legitimate and whose value is 3.
            The second is a Nullable<int> where the value is missing.

                **Nullable<T> does not create true null references

                        It must use value types and is a value type itself.
                        The bytes are still allocated (plus an extra byte for the Boolean HasValue property).
                        It is just that the current content isn't considered valid.

                                if(maybeNumber.HasValue)
                                {
                                    Console.WriteLine($"The number is {maybeNumber.Value}.");
                                }
                                else
                                {
                                    Console.WriteLine("The number is missing.");
                                }
                C# provides a syntax to make working with Nullable<T> easy.
                    You can use 'int?' instead of Nullable<int>.
                
                You can also automatically convert from the underlying type to the nullable type, and even convert from the literal null.
                Most C# programmers will use the following instead:
                        int? maybe number = 3;
                        int? another = null;
                
                Nullable<T> is a convenient way to represent values when the value may be missing.
                    But remember, this is different from null references.
                        Interestingly, operators on the underlying type work on the nullable counterparts:
                                
                                maybeNumber += 2;
                            
                            Unfortunately, that only applies to operators, not methods or properties.
                            If you want to invoke a method or property on a nullable value, you must call the Value property to get a copy of that value first.
*/
//--------------------------------------------------------------------------------------------------------ValueTuple Structs
/*
        We have seen many examples where the C# language makes it easy to work with some common type.
        As we just saw above, int? is the same as Nullable<int>, and even int itself is simply the Int32 struct.
            Tuples also have this treatment and are a shorthand way to use the ValueTuple generic structs.
                We saw how to do the following in a previous chapter:

                        (string, int, int) score = ("R2-D2", 12420, 15);
        
        This is a shorthand version of:

                ValueTuple<string, int, int> score = new ValueTuple<string, int, int>("R2-D2", 12420, 15);
            
            Most C# programmers prefer the first, simpler syntax, but sometimes the name ValueTuple leaks out, and it is worth knowing the two are the same when it does.
*/
//--------------------------------------------------------------------------------------------------------StringBuilder class
/*
        One problem with doing lots of operations with strings is that it has to duplicate all of the string contents in memory for every modification.


            string text = "";
            while(true)
            {
                string? input = Console.ReadLine();
                if(input == null || input == "")
                {
                    break;
                }
                text += input;
                text += ' ';
            }
            Console.WriteLine(text);
        
        We keep creating new strings that are longer and longer.
        The user enters "abc", and this code creates a string containing "abc".
        It then immediately makes another string with the text "abc ".
        Then the user enters "def", and your program will make another string containing "abc def" and then another containing "abc def ".
        These partial strings could get long, take up a lot of memory, and make the garbage collector work hard.

            An alternative is the StringBuilder class in the System.Text namespace.
            System.Text is not one of the namespaces we get automatic access to, so the code below includes the System.Text namespace when referencing StringBuilder:

                    System.Text.StringBuilder text = new System.Text.StringBuilder();
                    while(true)
                    {
                        string? input = Console.ReadLine();
                        if(input == null || input == "")
                        {
                            break;
                        }
                        text.Append(input);
                        text.Append(' ');
                    }
                    Console.WriteLine(text.ToString());
            
            This class hangs on to fragments of strings and does not assemble them into the final string until it is done.
            It will get a reference to the string "abc" and "def", but won't make any temporary combined strings until you ask for it with the ToString() method.

            StringBuilder is an optimization to use when necessary, not something to do all the time.
            A few extra relatively short strings won't hurt anything.
            But if you are doing anything intensive, StringBuilder may be an easy substitute to help keep memory usage in check.
*/
