// Tuples combine multiple elements into a single bundle:
        //                                                  (double, double) point = (2, 4)
// You can give (ephemeral) names to tuple elements, which can be used later:
        //                                                  (double x, double y) point = (2, 4)

// Tuples can be used like any other type, including variable and return types.
// Deconstruction unpacks tuples into multiple variables:
        //                                                  (double x, double y) = MakePoint();
// Two tuple values are equal if their corresponding items are all equal

// Forming a tuple is as simple as taking the pieces you need and placing them in parentheses, separated by commas

(string, int, int) score1 = ("R2-D2", 12420, 15); // the long type name is why some prefer to use var instead
Console.WriteLine(score1);

var score2 = ("C-3PO", 8543, 9); // the exact type here is a 3-tuple
Console.WriteLine(score2);

// We can access the items of a tuple like so:
Console.WriteLine($"Name: {score2.Item1}, Score: {score2.Item2}, Level: {score2.Item3}");

// copy a tuple into a new tuple:
var score1Copy = score1;
Console.WriteLine(score1Copy);

// neither of these will compile:
// (string, int) partialScore = score1; --> not the same number of items
// (int, int, string) mixedUpScore = score1 --> items in a different order

/* Tuples are value types, like int, bool and double, meaning they store their data inside them.

    Assigning one variable to another will copy all the data from all of the items in the process.
    This is made a little more complicated due to tuples being composite types (larger made of smaller parts).
    If a tuple has parts that are value types themselves, those bytes will get copied, but if an item is a 
    reference type, then the reference is copied.
*/

// The compiler lets us 'pretend' that we can name out tuple items:
(string Name, int Points, int Level) score3 = ("Gonk", -1, 1);
Console.WriteLine($"Name: {score3.Name} Level: {score3.Level} Score: {score3.Points}");

// We aren't required to name every tuple member. Any unnamed item will keep its original ItemN name

// Using var lets us name our elements in the formation of the tuple rather than when declaring types:
var scoreMatthew = (Name: "Matthew", Level: 20, Score: 54333);
Console.WriteLine($"Name: {scoreMatthew.Name}, Level: {scoreMatthew.Level}, Score: {scoreMatthew.Score}");

(string, int P, int L) scoreCharlie = (Name: "Charlie", Points: 69000, Level: 420);
Console.WriteLine($"Name: {scoreCharlie.Item1}, Level: {scoreCharlie.L}, Score: {scoreCharlie.P}");

/*
    Although the above code will run, while building the compiler will throw warnings because the names given 
    during the 3-tuple's declaration (Item1, P, L) will take precedent over the ones given in the formation of the 
    3-tuple (Name, Points, Level).

    Lesson Learned: Even though adding names can lead to clearer code, the names are fluid and are not a part of
                    tuple itself. For tuples, names are only cosmetic.
*/

void DisplayScore((string Name, int Points, int Level) score)   // We don't need names here, but parameters cannot use var, so we must list off the tuple types
{
    Console.WriteLine(
        $"Name: {score.Name}\tLevel: {score.Level}\tScore: {score.Points}");  // We could just use the ItemN for each element
}

(string Name, int Points, int Level) GetScore() => ("Jesse", 7777777, 69);

var scoreJesse = GetScore();
Console.WriteLine($"Name: {scoreJesse.Name}, Level: {scoreJesse.Level}, Score: {scoreJesse.Points}");

/* Much of the above can be done together with differing names. Since return types don't need to match those of our variable, we can illustrate how names are not part of the tuple.

    (string One, int Two, int Three) score = GetScore();
    DisplayScore(score);

    (string N, int P, int L) getScore() => ("R2-D2", 12420, 15);

    void DisplayScore((string Name, int Points, int Level) score)
    {
        Console.WriteLine(
            $"Name: {score.Name}\tLevel: {score.Level}\tScore: {score.Points}");
    }
*/

//-------------------------------------------------------------------------------------More tuple examples

// This tuple represents a point in a two-dimensional space:
(double X, double Y) point = (2.0, 4.0);    // Think of how nice it could be to combine these two coordinates into a single thing and pass it around in a 2D world!

// If we have a grid based world, what about using a tuple with elements for the grid square's type and location?
var tile = (Row: 2, Column: 4, Type: TileType.Grass);
// Here's an example that creates and returns an array of (string, int, int) tuples to create the full scoreboard for our scores
var scoresTable = CreateHighScores();
foreach(var tuple in scoresTable)
{
    Console.WriteLine($"\t\t{tuple.Name}\t{tuple.Points}\t{tuple.Level}");
}

(string Name, int Points, int Level)[] CreateHighScores()
{
    return new (string, int, int)[3]
    {
        ("R2-D2",  12420,  15),
        ("C-3PO",   8543,   9),
        ("GONK",      -1,   1),
    };
}

// Tuple deconstruction has many uses, but a clever usage is swapping the contents of two variables:
double x = 4;
double y = 2;
(x, y) = (y, x);
// The two variables' contents are copied over to a new tuple and then copied back to x and y.
// The result is x and y have swapped values with only a single line.

// Tuple deconstruction also demands that the variables on the left match the tuple both in count and types.
// Sometimes we only care about some of the values - rather than make a variable called, 'junk' or 'unused,' we can use a discard variable using a simple underscore with no type.

// '_' is a discard variable - the compiler will invent a name for it behind the scenes so the code can work, but it won't clutter up the code with useless names and leads to more readable code.

//-------------------------------------------------------------------------Simula's Soup
Console.WriteLine("\n\t\t\t\tSimula's Soup\n");
bool simula = true;

Seasoning seasoning = new();
MainIngredient mainIngredient = new();
Recipe recipe = new();

do
{
    Console.WriteLine("Time to make some food! What type of recipe should we go with? Our options are soup, stew, or gumbo.");
    string? choiceRecipe = Console.ReadLine();
    if (choiceRecipe == "exit")
        simula = false;

    if (choiceRecipe == "soup")
        recipe = Recipe.Soup;
    if (choiceRecipe == "stew")
        recipe = Recipe.Stew;
    if (choiceRecipe == "gumbo")
        recipe = Recipe.Gumbo;
    
    Console.WriteLine($"Okay, I've got the recipe to create a {recipe}, but we're missing a couple of things. What's the main ingredient of our dish??\nYou choose. Will our {recipe} star mushroom, chicken, carrot, or potatoes?");
    string? choiceMainIngredient = Console.ReadLine();
    if (choiceMainIngredient == "exit")
        simula = false;

    if (choiceMainIngredient == "mushroom")
        mainIngredient = MainIngredient.Mushroom;
    if (choiceMainIngredient == "chicken")
        mainIngredient = MainIngredient.Chicken;
    if (choiceMainIngredient == "carrot")
        mainIngredient = MainIngredient.Carrot;
    if (choiceMainIngredient == "potatoes")
        mainIngredient = MainIngredient.Potato;

    Console.WriteLine($"Awesome! I love {mainIngredient} in my {recipe}. Now to season - oooo this place is gonna smell so good!\nLooking in my pantry now we could go spicy, salty, or sweet - which would you prefer?");
    string? choiceSeasoning = Console.ReadLine();
    if (choiceSeasoning == "exit")
        simula = false;
    
    if (choiceSeasoning == "salty")
        seasoning = Seasoning.Salty;
    if (choiceSeasoning == "sweet")
        seasoning = Seasoning.Sweet;
    if (choiceSeasoning == "spicy")
        seasoning = Seasoning.Spicy;

(Seasoning, MainIngredient, Recipe) finalRecipe = (seasoning, mainIngredient, recipe);

Console.WriteLine(finalRecipe);
simula = false;

}while(simula);



enum Recipe { Soup, Stew, Gumbo };
enum MainIngredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet };

enum TileType { Grass, Water, Rock };