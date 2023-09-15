// methods can return values

using System.Diagnostics;

double total = 0;
double minimumSpend = 30.00;

double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

for (int i = 0; i < items.Length; i++)
{
    total += GetDiscountedPrice(i);
}

total -= TotalMeetsMinimum() ? 5.00 : 0.00;

if (TotalMeetsMinimum())
{
    total -= 5.00;
}

Console.WriteLine($"Total: ${FormatDecimal(total)}");

double GetDiscountedPrice(int itemIndex)
{
    return items[itemIndex] * (1 - discounts[itemIndex]);
}

bool TotalMeetsMinimum() // This method will return a 'true' or 'false' value, so it can be used in a conditional statement
{
    return total >= minimumSpend;
}

string FormatDecimal(double input)
{
    return input.ToString().Substring(0, 5);
}

Console.WriteLine();

//-----------------------------------Returning numbers from methods

double usd = 23.73;
int vnd = UsdToVnd(usd);

Console.WriteLine($"${usd} USE = ${vnd} VND");
Console.WriteLine($"${vnd} VND = ${VndToUsd(vnd)} USD");

int UsdToVnd(double usd)
{
    int rate = 23500; // locally scoped variable that will be used to calculate the value in VND
    return (int) (rate * usd); // utilizing the globally scoped variable usd, returning the processed result
    // If we don't cast our return as an int using (int), we'll get an error: 'Cannot implicitly convert type 'double' to 'int'
    // So, we use casting to explicitly convert the return value into an integer
}

Console.WriteLine();

//-----------------------------------Returning a double
double VndToUsd(int vnd)
{
    double rate = 23500;    // Here, rate needs to be a double because our compiler will otherwise use integer division
    return vnd / rate;      //we need to return a decimal number
}

Console.WriteLine();

//-----------------------------------Returning a string

string input = "snake";

Console.WriteLine($"Original input: {input}");
Console.WriteLine($"Reversing the input: {ReverseWord(input)}");

string ReverseWord(string word)
{
    string result = "";
    for (int i = word.Length - 1; i >= 0; i--)
    {
        result += word[i];
    }
    return result;
}

// now reverse a word in a sentence

string inputSentence = "There're snakes at the zoo!";

Console.WriteLine($"Before ReverseSentence(): {inputSentence}");
Console.WriteLine($"After ReverseSentence(): {ReverseSentence(inputSentence)}");

string ReverseSentence(string inputSentence)
{
    string result = "";
    string[] words = inputSentence.Split(" ");
    foreach(string word in words)
    {
        result += ReverseWord(word) + " "; // So long as the data type matches the requirements, methods can be called anywhere
    }
    return result.Trim();
}

//-----------------------------------Returning a boolean

// palindromes

string[] words = { "racecar", "talented", "deified", "tent", "tenet" };

Console.WriteLine("Is this a palindrome?");

foreach (string word in words)
{
    Console.WriteLine($"{word}: {IsPalindrome(word)}");
}

bool IsPalindrome(string word)
{
    int start = 0;
    int end = word.Length - 1;

    while (start < end) // stop execution once the start index is greater than the end index (middle of the word)
    {
        if (word[start] != word[end])
        {
            return false;
        }
        start++;
        end--;
    }

    return true;
}

Console.WriteLine();

//-----------------------------------Returning array
//-------------1D array return:

int target1 = 60;
int[] coins1 = new int[] { 5, 5, 50, 25, 25, 10, 5 };
int[] result1 = TwoCoins1(coins1, target1);

if (result1.Length == 0)
{
    Console.WriteLine("No two coins1 make change");
}
else
{
    Console.WriteLine($"Change found at positions {result1[0]} and {result1[1]}");
}

int[] TwoCoins1(int[] coins1, int target1)
{
    for(int curr = 0; curr < coins1.Length; curr++)
    {
        for (int next = curr + 1; next < coins1.Length; next++)
        {
            if (coins1[curr] + coins1[next] == target1)
            {
                return new int[]{curr, next};
            }
        }
    }

    return new int[0]; // we can create and return values using a return statement B)
}

Console.WriteLine();

//-------------2D array return:
// int target = 80; // failure path
int target = 30;
int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };
int[,] result = TwoCoins(coins, target);

if (result.Length ==0)
{
    Console.WriteLine("No two coins make change");
}
else
{
    Console.WriteLine("Change found at positions:");
    for (int i = 0; i < result.GetLength(0); i++)
    {
        if (result[i,0] == -1)
        {
            break;
        }
        Console.WriteLine($"{result[i,0]},{result[i,1]}");
    }
}

int[,] TwoCoins(int[] coins, int target)
{
    int[,] result = { {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1}, {-1, -1} };
    int count = 0;

    for (int curr = 0; curr < coins.Length; curr++)
    {
        for (int next = curr + 1; next < coins.Length; next++)
        {
            if (coins[curr] + coins[next] == target)
            {
                result[count, 0] = curr;
                result[count, 1] = next;
                count++;
            }
            if (count == result.GetLength(0))
            {
                return result;
            }
        }
    }
    if (count == 0)
    {
        return new int[0,0];
    }
    return result;
    // return (count == 0) ? new int[0,0] : result; // ternary option
}

Console.WriteLine();

//----------------------------------------------------------------------Exercise: Adding Methods To A Game
// mini-game requirements:
// game should select a target number that is a random number between one and five (inclusive)
// the player must roll a six-sided die.
// To win, the player must roll a number greater than the target number.
// At the end of each round, the player should be asked if they would like to play again,
//and the game should continue or terminate accordingly

//-----------provided code
Random random = new Random();

Console.WriteLine("Would you like to play a game? (Y/N)");
if (ShouldPlay())
{
    PlayGame();
}

bool ShouldPlay()
{
    string response = Console.ReadLine();
    return response.ToLower().Equals("y");
}

void PlayGame()
{
    var play = true;

    while (play)
    {
        var target = GetTarget();
        var roll = RollDice();

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(roll, target));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();

    }
}

int GetTarget()
{
    return random.Next(1, 6);
}

int RollDice()
{
    return random.Next(1, 7);
}

string WinOrLose(int roll, int target)
{
    if (roll > target)
    {
        return "You win!";
    }
    return "You lose!";
}

Console.WriteLine(KnowledgeCheck());

int KnowledgeCheck()
{
    return 5 % 2; // success
    // return Console.WriteLine(); //failure
    // return void; // failure
}