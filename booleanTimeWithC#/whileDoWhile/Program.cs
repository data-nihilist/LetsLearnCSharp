//-----------------------------------do-while statement
// // The do=while statement executes a statement or block of statements while a specific Boolean expression evaluates to true
// // do {
// //
// // } while (true)
// // Flow of execution starts inside of the curly brace. Code executes at least one time, then the boolean in the while() is evaluated.
// // If the while(boolean) returns true, the code block is executed again.
// // This loop can easily cause an infinite loop if nothing is triggering the while(boolean) to return false.

Random randomC = new Random();

int currentC = 0;

do {
    currentC = randomC.Next(1, 11); // random.Next(1, 7) will result in an infinite loop B)
    Console.WriteLine($"{currentC} first example\n");
} while ( currentC != 7);

//-----------------------------------while statement

Random randomB = new Random();

int current = randomB.Next(1, 11);

while (current >= 3) {
    Console.WriteLine(current);
    current = randomB.Next(1, 11);
}

Console.WriteLine($"The loop has finished. {current} was the Final number.\n");

//-----------------------------------Using continue to step directly to the Boolean expression

Random randomA = new Random();

int currentA = randomA.Next(1, 11);

do {
    currentA = randomA.Next(1, 11);

    if (currentA >= 8) continue; // transfer control to the end of the code block and the while will evaluate (current !=7).

    Console.WriteLine($"{currentA} is no larger than 8.");
} while (currentA != 7); // The loop will continue to iterate as long as the value of current is not equal to 7.

/*
                    Considering the difference between the ```continue``` and ```break``` statements:

                        The continue statement transfers execution to the end of the current iteration.

                        This behavior is different than what we saw the break statement do;
                        The break statement terminates the iteration (or ```switch```) and transfers control to the statement that follows the terminated statement;
                        If there is no statement after the terminated statement, then control transfers to the end of the file or method.


                                    Big Takeaways:

                                        The do-while statement iterates through a code block at least once, and may continue to iterate based on a Boolean expression.
                                        The evaluation of the Boolean expression usually depends on some value generated or retrieved inside of the code block.

                                        The while statement evaluates a Boolean expression first, and continues to iterate through
                                        the code block as long as the Boolean expression evaluates to true.

                                        The continue keyword to step immediately to the Boolean expression.
*/
//------------------------------------------------------------------Microsoft Challenge: Role Playing Game Battle Challenge
// Here are the rules for the battle game that you need to implement in your code project:

    // You must use either the do-while statement or the while statement as an outer game loop.
    // The hero and the monster will start with 10 health points.
    // All attacks will be a value between 1 and 10.
    // The hero will attack first.
    // Print the amount of health the monster lost and their remaining health.
    // If the monster's health is greater than 0, it can attack the hero.
    // Print the amount of health the hero lost and their remaining health.
    // Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
    // Print the winner.


//--------------------------------------------------------------------my solution:

Random random = new Random();

int heroHealth = 10;
int monsterHealth = 10;

int heroAttack = 0;
int monsterAttack = 0;
Console.WriteLine("___________________________________________________________________________________\nBattle!");
do {

    if (heroHealth > 0) {
        heroAttack = random.Next(1, 11);
        if (heroAttack >= 8) Console.WriteLine("Our Hero Is Fueled With The Flame of Ambition! :o");

        monsterHealth = monsterHealth - heroAttack;
        Console.WriteLine($"Hero attacks for\t{heroAttack}dmg\t\t>>\t\tMonster's health is now {monsterHealth}\n");

            if ((monsterHealth < 0) || (monsterHealth == 0)) {
                Console.WriteLine("\t\tThe monster is slain! Our Hero Lives Another Day :')\n___________________________________________________________________________________");
            }

        if (monsterHealth > 0) {
            monsterAttack = random.Next(1, 11);
            heroHealth = heroHealth - monsterAttack;
            Console.WriteLine($"Monster attacks for\t{monsterAttack}dmg\t\t<<\t\tHero's health is now {heroHealth}\n");

            if ((heroHealth < 0) || (heroHealth == 0)) {
                Console.WriteLine("\tThe hero has been slain! What ever will the people do now!?? :'c\n___________________________________________________________________________________");
            }
        }
    }

} while ((heroHealth > 0) && (monsterHealth > 0));

//---------------------------------------------------------------------Microsoft's Solution:

int hero = 10;
int monster = 10;

Random dice = new Random();

do {
    int roll = dice.Next(1, 11);
    monster -= roll;
    Console.WriteLine($"Monster was damaged and lost {roll} health and now has {monster} health.");

    if (monster <= 0) continue;

    roll = dice.Next(1, 11);
    hero -= roll;
    Console.WriteLine($"Hero was damaged and lost {roll} health and now has {hero} health.");

} while (hero > 0 && monster > 0);

Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");

//---------------------------------------------------------------------------------------------------Examining the difference between do and while statement iterations

string? readResult0; // nullable type string
Console.WriteLine("Enter a string:");
    int numericValue = 0;
    bool validNumber0 = false;
do{
    readResult0 = Console.ReadLine();

//---------------------------------TryParse method:
    validNumber0 = int.TryParse(readResult0, out numericValue);
    Console.WriteLine($"Valid Number? {validNumber0}\tUser Input: {readResult0}");

} while (validNumber0 == false);

// // while (readResult != null) makes this never cease.
// // while (readResult == null) exits the do-while statement after entering a string then hitting enter.
// // while (readResult.Length <=3) exits after an entered string is more than 3 characters long.

/*
    The Console.ReadLine() statement returns a string value.
        If you want to use ReadLine() input as numeric values, you need to convert the string value to a numeric type.
            The int.TryParse() method can be used to convert a string value to an integer. 
*/
//------------------------------------------------Challenge 1 code:
string? readResult1;
string valueEntered = "";
int numValue = 0;
bool validNumber = false;

Console.WriteLine("Enter an integer value between 5 and 10");

do {
    readResult1 = Console.ReadLine();
    if (readResult1 != null) {
        valueEntered = readResult1;
    }

    validNumber = int.TryParse(valueEntered, out numValue);

    if (validNumber == true) {
        if (numValue <= 5 || numValue >= 10) {
            validNumber = false;
            Console.WriteLine($"You entered {numValue}. Please enter a number between 5 and 10.");
        }
    }
    else
    {
        Console.WriteLine("Sorry, you entered an invalid entry please try again");
    }
} while (validNumber == false);

Console.WriteLine($"You input value ({numValue}) has been accepted. ");
readResult1 = Console.ReadLine();

// ------------------------------------------------Challenge 2 code:
string? readResult2;
string roleName = "";
bool validEntry = false;

do {
    Console.WriteLine("Enter your role: (Administrator, Manager, or User)");
    readResult2 = Console.ReadLine();
    if(readResult2 != null) {
        roleName = readResult2.Trim();
    }

    if (roleName.ToLower() == "administrator" || roleName.ToLower() == "manager" || roleName.ToLower() == "user") {
        validEntry = true;
    }
    else
    {
        Console.Write($"The role name that you entered, \"{roleName}\" is not valid.\n");
    }
} while (validEntry == false);

Console.WriteLine($"Your input value ({roleName}) has been accepted.");
readResult2 = Console.ReadLine();
//------------------------------------------------Challenge 3 code:
string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int stringsCount = myStrings.Length;

string myString = "";
int periodLocation = 0;

for (int i = 0; i < stringsCount; i++) {
    myString = myStrings[i];
    periodLocation = myString.IndexOf(".");

    string mySentence;

    // extract sentences from each string and display them one at a time
    while (periodLocation != -1) {

        // first sentence is the string value to the left of the period location
        mySentence = myString.Remove(periodLocation);

        // the remainder of myString is the string value to the right of the location
        myString = myString.Substring(periodLocation + 1);

        // remove any leading white-space from myString
        myString = myString.TrimStart();

        // updated the comma location and increment the counter
        periodLocation = myString.IndexOf(".");

        Console.WriteLine(mySentence);
    }

    mySentence = myString.Trim();
    Console.WriteLine(mySentence);
}