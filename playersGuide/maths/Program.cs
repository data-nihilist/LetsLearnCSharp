// Math :)

Console.WriteLine("\t\t\tThe Triangle Farmer\n");
/*
As you pass through the fields near Arithmetica City, you encounter P-Thag, a triangle farmer, scratching numbers in the dirt.
“What is all of that writing for?” you ask.
“I’m just trying to calculate the area of all of my triangles. They sell by their size. The bigger they are, the more they are worth!
But I have many triangles on my farm, and the math gets tricky, and I sometimes make mistakes. Taking a tiny triangle to town thinking
you’re going to get 100 gold, only to be told it’s only worth three, is not fun! If only I had a program that could help me....”
Suddenly, P-Thag looks at you with fresh eyes.
“Wait just a moment. You have the look of a Programmer about you. Can you help me write a program that will compute the areas for me, 
so I can quit worrying about math mistakes and get back to tending to my triangles? The equation I’m using is this one here,” 
he says, pointing to the formula, etched in a stone beside him:

(base * height) / 2
*/
decimal TriangleFarmer(decimal triangleBase, decimal triangleHeight)
{
    return (triangleBase * triangleHeight) / 2.0m;
}

decimal triangleOneArea = TriangleFarmer(3.6m, 5.2m);

Console.WriteLine(triangleOneArea);

Console.WriteLine($"And another triangle, please.\nArea = {TriangleFarmer(4.20m, 6.9m)}");

//--------------------------------------------------------------------------------------------------------------
Console.WriteLine("\nQuick rundown of integer division verses floating-point division");
int a = 5;
int b = 2;
int result = a / b;
Console.WriteLine("integer division of 5 / 2:");
Console.WriteLine(result); // outputs 2, because ints will truncate when handling floating point numbers

// adjustment for true result via casting ints as floats during an expression
float trueResult = (float)a / (float)b;
Console.WriteLine("floating point division of 5 / 2:");
Console.WriteLine(trueResult);
Console.WriteLine();
//-------------------------------------------------------------------------------------------------------------

Console.WriteLine("\t\t\tThe Four Sisters and the Duckbear\n");
/*
Four sisters own a chocolate farm and collect chocolate eggs laid by chocolate chickens every day. But more often than not, 
the number of eggs is not evenly divisible among the sisters, and everybody knows you cannot split a chocolate egg into pieces 
without ruining it.
The arguments have grown more heated over time. The town is tired of hearing the four sisters complain, and Chandra, the town’s 
Arbiter, has finally come up with a plan everybody can agree to. All four sisters get an equal number of chocolate eggs every day, 
and the remainder is fed to their pet duckbear.

All that is left is to have some skilled Programmer build a program to tell them how much each sister and the duckbear should get.
*/

string SisterEggs(int eggCount)
{
    int sisters = 4;
    decimal duckbearFood = 0;

    string message;

    decimal sharing = 0;

    if (eggCount % sisters == 0)
    {
        sharing = eggCount / sisters;
        message = $"The total amount of eggs {eggCount} is perfectly divisible amongst the four sisters! No duckbear food today. Each sister gets {sharing} eggs today.";
        return message;
    }
    else
    {
        sharing = eggCount / sisters;
        duckbearFood += (decimal)(eggCount % sisters);
        message = $"We will feed the duckbear {duckbearFood} eggs today";
        return message;
    }
}

Console.WriteLine($"{SisterEggs(12)}");

//--------------------------------------------------------------------------------------------------------------
Console.WriteLine("\nQuick rundown of compound assignment operators");

int c = 0;          Console.WriteLine($"Starting variable int c with a value of {c}");
c += 5;             Console.WriteLine($"c += 5; assigns c to be {c}");
c -= 2;             Console.WriteLine($"c -= 2; assigns c to be {c}");
c *= 4;             Console.WriteLine($"c *= 4; assigns c to be {c}");
c /= 2;             Console.WriteLine($"c /= 2; assigns c to be {c}");
c %= 2;             Console.WriteLine($"c %= 2; assigns c to be {c}");

Console.WriteLine();
//-------------------------------------------------------------------------------------------------------------

Console.WriteLine("\t\t\tThe Dominion of Kings\n");
/*
Three kings, Melik, Casik, and Balik, are sitting around a table, debating who has the greatest kingdom among them.
Each king rules an assortment of provinces, duchies, and estates. Collectively, they agree to a point system that helps 
them judge whose kingdom is greatest: 
Every estate is worth 1 point, 
every duchy is worth 3 points, 
and every province is worth 6 points. 
They just need a program that will allow them to enter their current holdings and compute a point total.
*/

Console.WriteLine($"Melik has {KingScore(1, 1, 1)} points.");
Console.WriteLine($"Casik has {KingScore(2, 2, 2)} points.");
Console.WriteLine($"Balik has {KingScore(6, 3, 7)} points.");

int KingScore(int estates, int duchies, int provinces)
{
    int totalScore = 0;
    totalScore += EstatePoints(estates);
    totalScore += DuchyPoints(duchies);
    totalScore += ProvincePoints(provinces);

    return totalScore;
}

int ProvincePoints(int numberOfProvinces)
{
    int worth = 6;
    int total = 0; // unless we initialize this at 0, the below code with throw an error.
    total += numberOfProvinces;
    total *= worth;
    return total;
}

int DuchyPoints(int numberOfDuchies)
{
    return numberOfDuchies * 3;
}

int EstatePoints(int numberOfEstates)
{
    int total = 0;
    int estatePointsWorth = 1;
    return total += (estatePointsWorth * numberOfEstates);
}
Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine();

byte aByte = 3;
int anInt = aByte;

int covenantInsightLevel = 2;

Console.WriteLine(Math.Clamp(covenantInsightLevel, 1, 20));
Console.WriteLine($"Current covenant insight level is: {covenantInsightLevel}");

int test1 = 8;
int test2 = 3;
Console.WriteLine($"Regular Math.Pow()\t:\t{Math.Pow(test1, test2)}");

float floatie = 3;
float floatieSquared = MathF.Pow(floatie, 2);
Console.WriteLine($"Using MathF.Pow()\t:\t{floatieSquared}");
