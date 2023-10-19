// Reference types may contain a reference to nothing: null, representing a lack of an object.
// Carefully consider whether null makes sense as an option for a variable and program accordingly.
// Check for null with x == null, the null conditional operators ( x?.DoStuff() and x?[3]), 
// and use ?? to allow null values to fall back to some other default: x ?? "empty"

/*
    Reference type variables like string, arrays, and classes don't store their data directly in the variable.
        The variable holds a reference and the data lives on the heap somewhere.
    Most of the time, these references point to a specific object, but in some cases, the reference is a special one indicating the absence of a value.
    This special reference is called a 'null reference'.
    In code, we indicate a null reference with the 'null' keyword:

        string name = null;
    
    Null references are helpful when it is possible for there to be no data available for something.
        Imagine making a game where you control a character that can climb into a vehicle and drive it around.
        The vehicle may have a Character _driver field that can point out which character is currently in the driver's seat.
        The driver's seat might be empty, which could be represented by having _driver contain a null reference.
    
    Null is the default for reference types.

    But null values are not without consequences. Consider the following code:

        string name = null;
        Console.WriteLine(name.Length);
    
    This will crash because it tries to get the Length on a non-existent string.

    Spotting this flaw is easy because name is always null; it is less evident in other situations:

        string name = Console.ReadLine(); // Can return null    
        Console.WriteLine(name.Length);
    
    Did ReadLine give us an actual string instance or null? There are certain situations where ReadLine can return null.
    The mere possibility that it could be null requires us to proceed with caution.

//----------------------------------------------------------------------------------Null or Not?
    For reference-typed variables, stop and think if null should be an option;
        If null is allowed, you will want to check it for null before using its members (methods, properties, fields, etc.).
        If null is not allowed, you will want tot check any value you assign to it to ensure you don't accidentally assign null to it.

    After deciding if a variable should allow null, we want to indicate this decision in our code.
    Any reference-typed variable can either have a '?' at the end or not. A '?" means that it may legitimately contain a null value:

        string? name = Console.ReadLine(); // Can return null

        In this code, name's type is now 'string?', which indicates it can contain any legitimate string instance, but it may also be null.
        Without the '?', we show that null is not an option.
    
    If we correctly apply (or skip) the '?' to our variables, we'll be able to get the compiler's help to check for null correctly. This help is immensely valuable.
    With the compiler helping us spot null-related issues, we won't miss much.
    Of course, the second benefit is that the code clearly shows whether null is a valid option for a variable.
    This helps programmers (including yourself) read your code.

//----------------------------------------------------------------------------------Checking for Null

    Once we take null references into account, we'll find ourselves needing to check for null often.
    The easiest way is to compare a reference against the null literal - called a 'null check':

        string? name = Console.ReadLine();
        if (name != null)
            Console.WriteLine("The name is not null.");
        
        If a variable indicates that null is an option, we will want to do a null check before using its members.
        If a variable indicates that null is NOT an option, we will want to do a null check on any value we're about to assign to the variable to ensure
        we don't accidentally put a null in it.
    
    Once compiled, there's no difference between 'string?' and 'string'.
    If you ignore the compiler warnings that are trying to help you get it right, even a plain string (without the ?) can still technically hold a null value.
    Look for these compiler warnings and fix them by adding appropriate null checking or correctly marking a variable as allowing or forbidding null.

//----------------------------------------------------------------------------------Null-Conditional Operators: ?. and ?[]
    One problem with null checking is that there may be implications down the line:

        private string? GetTopPlayerName()
        {
            return _scoreManager.GetScores()[0].Name;
        }

        _scoreManager could be null
        GetScores() could return null
        The array could contain a null reference at index 0

    If any of those are null, it will crash.

    We need to check each step:

        private string? GetTopPlayerName()
        {
            if (_scoreManager == null) return null;

            Score[]? scores = _scoreManager.GetScores();
            if (scores == null) return null;

            Score? topScore = scores[0];
            if (topScore == null) return null;

            return topScore.Name;
        }

        The null checks make the code hard to read. They obscure the interesting parts.

    There is another way --> null-conditional operators.

    The '?.' and '?[]' operators can be used in place of '.' and '[]' to simultaneously check for null and access the member:

        private string? GetTopPlayerName()
        {
            return _scoreManager?.GetScores()?[0]?.Name;
        }

        Both '?.' and '?[]' evaluate the part before it to see if it is null.
        If it is, then no further evaluation happens, and the whole expression evaluates to null. 
        If it is not null, evaluation will continue as though it had been a normal '.' or '[]' operator.

        If _scoreManager is null, then the above code returns a null value without calling GetScores.
        If GetScores() returns null, the above code returns a null without accessing index 0.

These operators do not cover every null-related scenario -
    we will sometimes need a good old fashioned 'if (x == null)' - but they can be a simple solution in many scenarios.

//----------------------------------------------------------------------------------Null Coalescing Operator: '??'
The null coalescing operator (??) takes an expression that might be null and provides a value or expression to use as a fallback if it is:

        private string GetTopPlayerName() // no longer needs to allow nulls.
        {
            return _scoreManager?.GetScores()?[0].Name ?? "(not found)";
        }

        If the code before the '??' evaluates to null, then the fallback value of "(not found)" will be used instead.

        There is also a compound assignment operator for this:

        private string GetTopPlayerName()
        {
            string? name = _scoreManager?.GetScores()?[0].Name;
            name ??= "(not found)";
            return name;            // no compiler warning. '??=' ensures we have a real value.
        }

//----------------------------------------------------------------------------------Null-Forgiving Operator: '!'
The compiler is pretty thorough in analyzing what can and can't be null and giving us appropriate warnings.
On infrequent occasions, you know something about the code that the compiler simply can't infer from its analysis:

    string message = MightReturnNullIfNegative(+10);

    Assuming the return type of MightReturnNullIfNegative is string?, the compiler will flag this as a situation where you are assigning a potentially null value to
    a variable that indicates null isn't allowed.
    Assuming the method isn't a lie (which isn't always a safe assumption), we know hte returned value can't be null.

    To get rid of the compiler warning, we can use the 'null-forgiving operator' (!).
        C# uses this same symbol for the Boolean 'not' operator.

    This operator tells the compiler, "I know this looks like a potential null problem, but it won't be. Trust me."

        string message = MightReturnNullIfNegative(+10)!;

        We place it at the nd of an expression that might be null to tell the compiler that it won't actually evaluate to null.
        With the '!' in there, the compiler warning will go away.

    There's a danger to this operator. We want to be absolutely sure we're correct when using it.

*/
