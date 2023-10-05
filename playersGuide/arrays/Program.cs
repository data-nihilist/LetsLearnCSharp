Console.Clear();

// InitializingAnArray();

//  collection initializer syntax:      int[] scores = new int[10] { 100, 95, 92, 87, 55, 50, 48, 40, 35, 10 };
// we can skip stating the length:      int[] scores = new int[] { 100, 95, 92, 87, 55, 50, 48, 40, 35, 10 };
// the compiler can infer the type:     int[] scores = new [] { 100, 95, 92, 87, 55, 50, 48, 40, 35, 10 };

// LoopingThroughArrays();

Console.WriteLine("\n\t\t\t\tThe Replicator of D'To\n");
Console.WriteLine("While searching an abandoned storage building containing strange code artifacts, you uncover the\nancient Replicator of D'To. This can replicate the contents of any int array into another array. But it\nappears broken and needs a Programmer to reforge the magic that allows it to replicate once again.\nObjectives:\n\n-\tMake a program that creates an array of length 5\n-\tAsk the user for five numbers and put them in the array\n-\tMake a second array of length 5\n-\tUse a loop to copy the values out of the original array and into the new one.\n-\tDisplays the contents of both arrays one at a time to illustrate that the Replicator of D'To works again\n");

// TheReplicatorOfDToQuest();


Console.WriteLine("\n\t\t\t\tThe Laws of Freach\n");
Console.WriteLine("The town of Freach recent had an awful looping disaster. The lead investigator found that it was a faulty ++ operator\nin an old for-loop, but the town council has chosen to ban all loops but the foreach-loop.\nYet Freach uses the code presented earlier in this level to compute the minimum and the average value\nin an int array. They have hired you to rework their existing for-based code to use foreach-loops instead.\nObjectives:\n\n-\tStart with the code for computing an array's minimum and average values from before\n-\tModify the code to use foreach-loops instead of for-loops\n");

// TheLawsOfFreachQuest();

MultiDimensionalArrays();

void MultiDimensionalArrays()
{
    Console.WriteLine("\t\t\t\tMulti-Dimensional Arrays\n");
    /*
        |1  2|
        |3  4|
        |5  6|
    */

    int[][] matrix = new int[3][];
    matrix[0] = new int[] { 1, 2 };
    matrix[1] = new int[] { 3, 4 };
    matrix[2] = new int[] { 6, 6 };

    Console.WriteLine(matrix[0][1]); // outputs 2
    /*
        The setup for an array of arrays is ugly because each array within the main array must be
        initialized independently.
        Arrays of arrays are most often used when each of the smaller arrays needs to be a different size.
        This is sometimes referred to as a 'jagged array'.
    */

    int[,] rectangularMatrix = new int[3, 2] { { 1, 2 }, { 3, 4 }, {5, 6 } };
    Console.WriteLine(rectangularMatrix[0, 1]); // outputs 2
    /*
        We often want a grid with a specific number of rows and columns.
        C# arrays can be multi-dimensional, containing more than one index.
        Arrays of this nature are called 'multi-dimensional arrays' or 'rectangular arrays'
    */
    
    Console.WriteLine("To loop through all elements of a multi-dimensional array, we'll want to use the GetLength method\nHere we hand GetLength the dimension we're interested in (starting with 0, not 1)");

    int[,] newMatrix = new int[4,4];

    for (int row = 0; row < newMatrix.GetLength(0); row++)
    {
        for (int column = 0; column < newMatrix.GetLength(1); column++)
            Console.WriteLine(newMatrix[row, column] + " ");
        
        Console.WriteLine();
    }
}

void TheLawsOfFreachQuest()
{
    Console.WriteLine("\t\t\t\tObtaining the smallest number from an int array using a foreach loop\n");
    int[] minMaxArray = new [] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

    int currentSmallest = int.MaxValue;

    foreach (int element in minMaxArray)
    {
        if (element < currentSmallest)
            currentSmallest = element;
    }

    Console.WriteLine(currentSmallest);
    
    Console.WriteLine("\n\t\t\t\tCalculating the average value fo the numbers in an array\n");

    int[] anAverageArray = minMaxArray[0..];

    int total = 0;
    foreach(int element in anAverageArray)
        total += element;
    
    float average = (float)total / anAverageArray.Length;
    Console.WriteLine(average);
}

void TheReplicatorOfDToQuest()
{
    int[] programmedArray = new int[5];
    int[] replicatorDTo = new int[programmedArray.Length];
    for(int i = 0; i < programmedArray.Length; i++)
    {
        Console.WriteLine($"index[{i}]'s value?");
        int transcribedValue = Convert.ToInt32(Console.ReadLine());
        programmedArray[i] = transcribedValue;
        Console.WriteLine($"placing {transcribedValue} into the Replicator's array @ index[{i}]");
        replicatorDTo[i] = programmedArray[i];
        Console.WriteLine($"Replicator D'To!\t\treplicatorDto[{i}] = {replicatorDTo[i]} as well\n");
    }

    Console.WriteLine("\n\t\t\t\tResults\n");
    Console.WriteLine("Programmed Array:\n");
    foreach(int element in programmedArray) Console.WriteLine(element);
    Console.WriteLine("\nReplicator's Array:\n");
    foreach(int element in replicatorDTo) Console.WriteLine(element);
}

void InitializingAnArray()
{
    Console.WriteLine("\t\t\t\tInitializing Arrays\n");

    byte[] byteScores = new byte[2];
    Console.WriteLine($"byteScores: {byteScores}");

    short[] shortScores = new short[16];
    Console.WriteLine($"shortScores: {shortScores}");

    int[] intScores = new int[32];
    intScores[9] = 69;
    intScores[8] = 420;
    Console.WriteLine($"intScores: {intScores}");
    // for (int i = intScores.Length - 1; i <= intScores.Length - 1; i--)
    // {
    //     if(i < 0)
    //     break;
    //     else                             // default int value = 0
    //     Console.WriteLine(intScores[i]);
    // }
    // Console.WriteLine(intScores.Length);
    long[] longScores = new long[64];
    Console.WriteLine($"longScores: {longScores}\nand so on for the remaining int types\n");
    bool[] booleanArray = new bool[3];
    Console.WriteLine(booleanArray);
    booleanArray[1] = true;
    for (int i = booleanArray.Length - 1; i <= booleanArray.Length - 1; i--)
    {
        if(i < 0)
        break;
        else                                // default bool value = false
        Console.WriteLine(booleanArray[i]);
    }

    Console.WriteLine("\nPlease provide the desired length of your brand new int[]");
    int length = Convert.ToInt32(Console.ReadLine());
    int[] userProvidedArray = new int[length];

    Console.WriteLine();

    for(int i = 0; i < userProvidedArray.Length; i++)
    {
        if(i % 2 == 0)
        {
            userProvidedArray[i] = 6;
            Console.WriteLine(userProvidedArray[i]);
        }
        else
        {
            userProvidedArray[i] = 9420;
            Console.WriteLine(userProvidedArray[i]);
        }
    }
    Console.WriteLine(userProvidedArray[^1]); // accessing the element stored in the last index of userProvidedArray

    Console.WriteLine("\nprinting a copy of the section (or 'range') within your new array, indexes 0 through 3:\n");
    foreach (int element in userProvidedArray[0..3]) Console.WriteLine(element);
    // Translation of range: "[Which index to begin with(inclusive), the amount of elements to copy]"

    Console.WriteLine("\nStoring a copy of that range into it's own array\n");
    int[] firstThreeElements = userProvidedArray[0..3];
    foreach(int element in firstThreeElements) Console.WriteLine(element);

    Console.WriteLine("\nNow copying those three into another separate array\n");
    int[] anotherCopy = firstThreeElements[0..firstThreeElements.Length]; // using [0..^1] actually chops off the final referenced element :o
    Console.WriteLine($"this array has a length of: {anotherCopy.Length}");
    foreach(int element in anotherCopy) Console.WriteLine(element);

    Console.WriteLine("\nCopying the middle of that array now...");
    int[] theMiddle = anotherCopy[1..^1];
    Console.WriteLine($"this array has a length of: {theMiddle.Length}");
    foreach(int element in theMiddle) Console.WriteLine(element);

    Console.WriteLine("\nMaking a copy of the second half of the originally requested array\n");
    int[] secondHalf = userProvidedArray[(userProvidedArray.Length / 2)..]; // Using an expression and omitting the 'volume to copy' argument
    Console.WriteLine($"this array has a length of: {secondHalf.Length}");  // Providing an array with an odd numbered length results in a copy that splits the length in half, then rounds up that value for a whole number.
    foreach(int element in secondHalf) Console.WriteLine(element);          // "The majority by 1 extra element, please"

    Console.WriteLine("\nSome further examples with arrays involving more complexity\n");

}

void LoopingThroughArrays()
{
        Console.WriteLine("\t\t\t\tLooping Through Arrays\n");

    Console.WriteLine("\t\tObtaining the smallest number from an int array\n");
    int[] minMaxArray = new [] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

    int currentSmallest = int.MaxValue; // The maximum size an int can be in any int[], so we know each element can be compared
    for (int i = 0; i < minMaxArray.Length; i++)
    {
        if (minMaxArray[i] < currentSmallest)
            currentSmallest = minMaxArray[i];
    }

    Console.WriteLine(currentSmallest);
    
    Console.WriteLine("\n\t\tCalculating the average value fo the numbers in an array\n");

    int[] anAverageArray = minMaxArray[0..];

    int total = 0;
    for(int i = 0; i < anAverageArray.Length; i++)
        total += anAverageArray[i];
    
    float average = (float)total / anAverageArray.Length;
    Console.WriteLine(average);
}
