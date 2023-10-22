using System.Security.Cryptography.X509Certificates;
using static System.Convert;

Console.WriteLine("\t\t\t\tBoss Battle: The Point\n\nThe first pedestal asks you to create a Point class to store a point in two dimensions. Each point is\nrepresented by an x-coordinate (x), a side-to-side distance from a special central point called the origin,\nand a y-coordinate (y), an up-and-down distance away from the origin.\n\nObjectives:\n-\tDefine a new Point class with properties for X and Y.\n-\tAdd a constructor to create a point from a specific x- and y-coordinate.\n-\tAdd a parameterless constructor to create a point at the origin (0, 0).\n-\tIn your main method, create a point at (2, 3) and another at (-4, 0). Display these points on the\n\tconsole window in the format (x, y) to illustrate that the class works.\n-\tAnswer these questions: Are your X and Y properties immutable? Why did you choose what you did?\n\n");


// Point point = new() { X = 3, Y = 5 }; // object initializer syntax
Point point = new();    // using the parameterless constructor, setting X and Y to the _origin (0, 0)
Point pointA = new(2, 3);
Point pointB = new(-4, 0);
// pointA.X = 4;    // I decided to make the X and Y properties immutable because I want them to be unable to be altered after initialization.
Console.WriteLine(Point.GetCoordinates(point));
Console.WriteLine(point.GetOrigin());
Console.WriteLine(Point.GetCoordinates(pointA));
Console.WriteLine(Point.GetCoordinates(pointB));
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n\t\t\t\tBoss Battle: The Color\n\nThe second pedestal asks you to create a Color class to represent a color.\nThe color consists of three parts or channels: red, green, and blue, which indicates how much those\nchannels are lit up. Each channel can be from 0 to 255. 0 means completely off; 255 means completely on.\nThe pedestal also includes some color names, with a set of numbers indicating their specific values for\neach channel. These are commonly used colors:\n\nWhite (255, 255, 255)\t\tBlack (0, 0, 0)\nRed (255, 0, 0)\t\t\tOrange (255, 165, 0)\nYellow (255, 255, 0)\t\tGreen (0, 128, 0)\nBlue (0, 0, 255)\t\tPurple (128, 0, 128)\n\nObjectives:\n-\tDefine a new Color class with properties for its red, green, and blue channels.\n-\tAdd appropriate constructors that you feel make sense for creating new Color objects.\n-\tCreate static properties to define the eight commonly used colors for easy access.\n-\tIn your main method, make two Color-typed variables. Use a constructor to create a color instance\n\tand use a static property for the other. Display each of their red, green, and blue channel values.\n\n");

Color colorA = new(); // using static properties to create a Color instance
Console.WriteLine(Color.GetChannelValues(colorA)); // using the constructor to create a Color instance

Color colorB = new("Angelo's fur", 0, 0, 0);
Console.WriteLine(Color.GetChannelValues(colorB));

// confirming the 8 commonly used colors and static report method are fully functioning
Console.WriteLine(Color.GetChannelValues(Color.White));
Console.WriteLine(Color.GetChannelValues(Color.Black));
Console.WriteLine(Color.GetChannelValues(Color.Red));
Console.WriteLine(Color.GetChannelValues(Color.Orange));
Console.WriteLine(Color.GetChannelValues(Color.Yellow));
Console.WriteLine(Color.GetChannelValues(Color.Green));
Console.WriteLine(Color.GetChannelValues(Color.Blue));
Console.WriteLine(Color.GetChannelValues(Color.Purple));
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n\t\t\t\tBoss Battle: The Card\n\nThe digital Realms of C# have playing cards like ours but with some differences. Each card has a color\n(red, green, blue, yellow) and a rank (the numbers 1 through 10, followed by the symbols $, %, ^, and &).\nThe third pedestal requires that you create a class to represent a card of this nature.\n\nObjectives:\n\n-\tDefine enumerations for card colors and card ranks.\n-\tDefine a Card class to represent a card with a color and a rank, as described above.\n-\tAdd properties or methods that tell you if a card is a number or symbol card (the equivalent of a face card).\n-\tCreate a main method that will create a card instance for a whole deck (every color with every\n\trank) and display each (for example, \"The Red Ampersand\" and \"The Blue Seven\").\n-\tAnswer this question: Why do you think we used a color enumeration here but made a color class in the previous challenge?\n\n");

Card cardTest = new(CardColor.Green, CardRank.Cash);

Console.WriteLine(Card.DrawCard(cardTest));
Console.WriteLine(cardTest.GetRankType(cardTest));

Card[] deck = BuildDeck();
foreach (Card card in deck) Console.WriteLine(Card.DrawCard(card));
Card[] BuildDeck()
{
    Card[] deck = new Card[56];
    int cardCount = 0;

    for (int i = 1; i <= 4; i++)
    {
        for (int j = 1; j <= 14; j++)
        {
            if (cardCount < 56)
            {
                deck[cardCount] = new Card((CardColor)i, (CardRank)j);
                cardCount++;
            }
        }
    }

    return deck;
}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n\t\t\t\tBoss Battle: The Locked Door\n\nThe fourth pedestal demands constructing a door class with a locking mechanism that requires a unique\nnumeric code to unlock. You have done something similar before with using a class, but the locking\nmechanism is new. The door should only unlock if the pass code is the right one.\n\n\t\tThe following statements describe how the door works:\n\n\t\tAn open door can always be closed.\n\t\tA closed (but not locked) door can always be opened.\n\t\tA closed door can always be locked.\n\t\tA locked door can be unlocked, but a numeric pass code is needed, and the door will only unlock if\n\t\tthe code supplied matches the door's current pass code.\n\t\tWhen a door is created, it must be given an initial pass code.\n\t\tAdditionally, you should be able to change the pass code by supplying the current code and a new\n\t\tone. The pass code should only change if the correct, current code is given.\n\nObjectives:\n\n-\tDefine a Door class that can keep track of whether it is locked, open, or closed.\n-\tMake it so you can perform the four transitions defined above the methods.\n-\tBuild a constructor that requires the starting numeric pass code.\n-\tBuild a method that will allow you to change the pass code for an existing door by supplying the\n\tcurrent pass code and new pass code. Only change the pass code if the current pass code is correct.\n-\tMake your main method ask the user for a starting pass code, then create a new Door instance. Allow\n\tthe user to attempt the four transitions described above (open, close, lock, unlock) and change the\n\tcode by typing in text commands.\n\n");

// Door firstDoor = new(5, 9, 20, 100);
// Console.WriteLine(firstDoor.IsClosed);
// Console.WriteLine(firstDoor.IsLocked);
// Console.WriteLine(firstDoor.IsUnlocked);
// Console.WriteLine(firstDoor.IsOpen);
// Door.CheckDoor(firstDoor);
// Door.UnlockDoor(firstDoor);
// Door.OpenDoor(firstDoor);
// Console.WriteLine(firstDoor.IsClosed);
// Console.WriteLine(firstDoor.IsLocked);
// Console.WriteLine(firstDoor.IsUnlocked);
// Console.WriteLine(firstDoor.IsOpen);
// Door.CheckDoor(firstDoor);
// Door.CloseDoor(firstDoor);
// firstDoor.LockDoor();
// firstDoor.ChangePassCode();
// firstDoor.ChangePassCode();
// Console.WriteLine(firstDoor.IsClosed);
// Console.WriteLine(firstDoor.IsLocked);
// Console.WriteLine(firstDoor.IsUnlocked);
// Console.WriteLine(firstDoor.IsOpen);

// Console.WriteLine("You'd like to create a door? Please enter a four digit a pass code for your new door. Bare in mind that each number must be between 0 and 255");
// int? userOne = Convert.ToInt16(Console.ReadLine());
// int? userTwo = Convert.ToInt16(Console.ReadLine());
// int? userThree = Convert.ToInt16(Console.ReadLine());
// int? userFour = Convert.ToInt16(Console.ReadLine());
// Door userDoor = new Door((byte)userOne, (byte)userTwo, (byte)userThree, (byte)userFour);
// Door.CheckDoor(userDoor);
// userDoor.ChangePassCode();
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n\t\t\t\tBoss Battle: The Password Validator\n\nThe fifth and final pedestal describes a class that represents a concept more abstract than the first four:\na password validator. You must create a class that can determine if a password is valid (meets the rules\ndefined for a legitimate password). The pedestal initially doesn't describe any rules, but as you brush the\ndust off the pedestal, it vibrates for a moment, and the following rules appear:\n\n\t\tPasswords must be at least 6 letters long and no more than 13 letters long.\n\t\tPasswords must contain at least one uppercase letter, one lowercase letter, and one number.\n\t\tPasswords cannot contain a capital T or an ampersand(&) because Ingelmar in IT has decreed it.\n\nThe last rule seems random, and you wonder if the pedestal is just tormenting you with obscure rules.\n\nYou ponder for a moment about how to decide if a character is uppercase, lowercase, or a number, but\nwhile scratching your head, you notice a piece of folded parchment on the ground near your feet. You\npick it up, unfold it, and read it:\n\"foreach with a string lets you get its characters!\n> foreach (char letter in word) { ... }\n\nchar has static methods to categorize letters!\n> char.IsUpper('A'), char.IsLower('a'), char.IsDigit('0')\n\nThat might be useful information! You are grateful to whoever left it behind. It is signed simply \"A.\"\n\nObjectives:\n\n-\tDefine a new PasswordValidator class that can be given a password and determine if the\npassword follows the rules above.\n-\tMake your main method loop forever, asking for a password and reporting whether the password is allowed using an instance of the PasswordValidator class.\n\n");

// string? passwordTest = Console.ReadLine();
// PasswordValidator.CheckPassword(passwordTest);
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n\t\t\t\tBoss Battle: Tic-Tac-Toe\n\nCompleting designs for the three games in the Chamber of Design causes the pedestals to light up red\nagain, and another door opens, letting you into the final chamber. This chamber has only a single large,\nbroad pedestal. Inscribed on the stone floor in a circle around the pedestal are the engraved words, \"Only\na True Programmer can build object-oriented programs.\"\n\nMore text engraved on the pedestal describes what you recognize as the game of Tic-Tac-Toe, stating\nthat in ancient times, inhabitants of the land would use this as a Battle of Wits to determine the outcome\nof political strife. Instead of fighting wars, they would battle it out n a game of Tic-Tac-Toe.\n\nYour job is to recreate the game of Tic-Tac-Toe, allowing two players to compete against each other. The\nfollowing features are required:\n\n\t\tTwo human players take turns entering their choice using the same keyboard.\n\t\tThe players designate which square they want to play in. HINT: You might consider using the number\n\t\tpad as a guide. For example, if they enter 7, they have chosen the top left corner of the board.\n\t\tThe game should prevent players from choosing squares that are already occupied. If such a move\n\t\tis attempted, the player should be told of the problem and given another chance.\n\t\tThe game must detect when a player wins or when the board is full with no winner (draw/\"cat\").\n\t\tWhen the game is over, the outcome is displayed to the players.\n\t\tThe state of the board must be displayed to the player after each play.\n\nObjectives:\n\n-\tBuild the game of Tic-Tac-Toe as described in the requirements above. Starting the CRC cards is\n\trecommended, but the goal is to make working software, not CRC cards.\n-\tAnswer this question: How might you modify your completed program if running multiple rounds\n\twas a requirement (for example, a best-out-of-five series)?\n\n");

Board board = new();
Console.WriteLine(board.SetBoard());
Player playerOne = new("Matthew");
Player playerTwo = new("Angelo");
TicTacToeReferee referee = new();
referee.RunGame(board, playerOne, playerTwo);

//-----------------------------------------------------Tic-Tac-Toe (start)

public class Board
{
    public static int _playableSpace = 1;
    public string FieldOfPlay { get; set; } = $" {_playableSpace++} | {_playableSpace++} | {_playableSpace++} \n---+---+---\n {_playableSpace++} | {_playableSpace++} | {_playableSpace++} \n---+---+---\n {_playableSpace++} | {_playableSpace++} | {_playableSpace++} ";
    public Board()
    {}
    public string SetBoard()
    {
        return FieldOfPlay;
    }
}

public class Player
{
    private char _playerSymbol;
    private string _playerName;
    private bool isValidSymbol = false;
    public Player(string playerName)
    {
        _playerName = playerName;
        char playerSymbol = Convert.ToChar(Console.ReadLine());
        while(char.IsDigit(playerSymbol))
        {
                Console.WriteLine("Please select a character that isn't a number.");
                playerSymbol = Convert.ToChar(Console.ReadLine());
        }
        _playerSymbol = playerSymbol;
        isValidSymbol = true;
        GetPlayerSymbol();
    }
    public string ChoosePlayableField(Board board)
    {
        Console.WriteLine($"It's {_playerName}'s turn.");

        string optionsToPickFrom = board.SetBoard();
        Console.WriteLine(optionsToPickFrom);
        Console.WriteLine("Select where you'd like to place your symbol.");
        char? playersChoice = Convert.ToChar(Console.ReadLine());
        string returnString = "";

        foreach(char unit in optionsToPickFrom)
        {
            if(Convert.ToChar(unit) == Convert.ToChar(playersChoice))
            {
                Console.WriteLine($"You selected {unit}");
                returnString += _playerSymbol;
            }
            else
                returnString += unit;
        }
        board.FieldOfPlay = returnString;
        return $"\n{board.FieldOfPlay}\n";
    }
    public char GetPlayerSymbol() => _playerSymbol;
    public string GetPlayerName() => _playerName;
}

public class TicTacToeReferee
{
    public TicTacToeReferee()
    {}
    public void CheckPlay(Board board, Player player)
    {
        char symbolToConnect = player.GetPlayerSymbol();
        Console.WriteLine($"Current field of play:\n{board.FieldOfPlay}\n");
        Console.WriteLine($"Checking connections for {player.GetPlayerName()}'s {player.GetPlayerSymbol()}..");
        foreach(char unit in board.FieldOfPlay)
        {
            // checking for connection of 3 fields of play
            // ...
            // ...
        }
    }

    public void RunGame(Board board, Player playerOne, Player playerTwo)
    {
        playerOne.ChoosePlayableField(board);
        CheckPlay(board, playerOne);
        playerTwo.ChoosePlayableField(board);
        CheckPlay(board, playerTwo);
        playerOne.ChoosePlayableField(board);
        CheckPlay(board, playerOne);
        playerTwo.ChoosePlayableField(board);
        CheckPlay(board, playerTwo);
        playerOne.ChoosePlayableField(board);
        CheckPlay(board, playerOne);
        playerTwo.ChoosePlayableField(board);
        CheckPlay(board, playerTwo);
        playerOne.ChoosePlayableField(board);
        CheckPlay(board, playerOne);
        playerTwo.ChoosePlayableField(board);
        CheckPlay(board, playerTwo);

    }
}
//-----------------------------------------------------Tic-Tac-Toe (end)
//-----------------------------------------------------The Password Validator (start)
public class PasswordValidator
{
    private static bool PasswordIsValid { get; set; } = false;

    public PasswordValidator()
    {
    }
    public static void CheckPassword(string password)
    {
        if (password.Length < 6 || password.Length > 13)
        {
            if (password.Length < 6)
                Console.WriteLine("Your attempt of a password is too short. Try again.");
            if (password.Length > 13)
                Console.WriteLine("Can't you think of anything more concise? Try again.");

        }
        else
        {
            int upperCaseCounter = 0;
            int lowerCaseCounter = 0;
            int numberCounter = 0;
            char inglemarsT = 'T';
            char inglemarsAmp = '&';
            int capitalTDetector = 0;
            int ampersandDetector = 0;
            foreach (char letter in password)
            {
                if (char.IsUpper(letter))
                {
                    upperCaseCounter++;
                }
                if (char.IsLower(letter))
                {
                    lowerCaseCounter++;
                }
                if (char.IsDigit(letter))
                {
                    numberCounter++;
                }
                if (char.Equals(letter, inglemarsT))
                {
                    capitalTDetector++;
                }
                if (char.Equals(letter, inglemarsAmp))
                {
                    ampersandDetector++;
                }
            }
            if (upperCaseCounter > 0 && lowerCaseCounter > 0 && numberCounter > 0 && capitalTDetector == 0 && ampersandDetector == 0)
            {
                Console.WriteLine("Password is valid. Thank you.");
                PasswordIsValid = true;
            }
            else
            {
                Console.WriteLine($"{password} ISN'T A VALID PASSWORD. YOU NEED TO GIVE ME A PASSWORD THAT MAKES SENSE. JESUS FUCKING CHRIST. -Inglemar, IT");
            }
        }
    }
}
//-----------------------------------------------------The Password Validator (end)
//-----------------------------------------------------The Locked Door (start)
public class Door
{
    private byte[] _passCode = new byte[4];
    public bool IsOpen { get; set; } = false;
    public bool IsClosed { get; set; } = true;
    public bool IsLocked { get; set; } = true;
    public bool IsUnlocked { get; set; } = false;

    public Door(byte one, byte two, byte three, byte four)
    {
        _passCode[0] = one;
        _passCode[1] = two;
        _passCode[2] = three;
        _passCode[3] = four;
    }

    public void ChangePassCode()
    {
        if (IsClosed && IsLocked)
        {
            Console.WriteLine("\n\t\tYou'd like to change your pass code? Sure.\nEnter the current pass code first.");

            int? checkOne = Convert.ToInt16(Console.ReadLine());
            int? checkTwo = Convert.ToInt16(Console.ReadLine());
            int? checkThree = Convert.ToInt16(Console.ReadLine());
            int? checkFour = Convert.ToInt16(Console.ReadLine());

            if (checkOne == _passCode[0] && checkTwo == _passCode[1] && checkThree == _passCode[2] && checkFour == _passCode[3])
            {
                Console.WriteLine("\n\t\tPlease enter your new byte[4] pass code.");

                int? newOne = Convert.ToInt16(Console.ReadLine());
                _passCode[0] = (byte)newOne;

                int? newTwo = Convert.ToInt16(Console.ReadLine());
                _passCode[1] = (byte)newTwo;

                int? newThree = Convert.ToInt16(Console.ReadLine());
                _passCode[2] = (byte)newThree;

                int? newFour = Convert.ToInt16(Console.ReadLine());
                _passCode[3] = (byte)newFour;
            }
            else Console.WriteLine("Nice try.");
        }
        if (IsClosed && IsUnlocked) Console.WriteLine("The door needs to be both closed and locked before you can reset your pass code.");
        if (IsOpen) Console.WriteLine("You need to close the door first...");

    }
    public static void CheckDoor(Door door)
    {
        if (door.IsClosed)
        {
            if (door.IsLocked) Console.WriteLine("The door is closed and it is locked.");
            if (door.IsUnlocked) Console.WriteLine("The door is closed but it is unlocked.");
        }
        if (door.IsOpen) Console.WriteLine("The door is currently open..");
    }
    public static void UnlockDoor(Door door)
    {
        if (door.IsClosed && door.IsLocked)
        {
            Console.WriteLine("What's the pass code?");

            int? checkOne = Convert.ToInt16(Console.ReadLine());
            int? checkTwo = Convert.ToInt16(Console.ReadLine());
            int? checkThree = Convert.ToInt16(Console.ReadLine());
            int? checkFour = Convert.ToInt16(Console.ReadLine());

            if (checkOne == door._passCode[0] && checkTwo == door._passCode[1] && checkThree == door._passCode[2] && checkFour == door._passCode[3])
            {
                door.IsLocked = false;
                door.IsUnlocked = true;
            }
            Door.CheckDoor(door);
        }

    }
    public static void OpenDoor(Door door)
    {
        if (door.IsLocked)
        {
            Console.WriteLine("What's the pass code?");

            int? checkOne = Convert.ToInt16(Console.ReadLine());
            int? checkTwo = Convert.ToInt16(Console.ReadLine());
            int? checkThree = Convert.ToInt16(Console.ReadLine());
            int? checkFour = Convert.ToInt16(Console.ReadLine());

            if (checkOne == door._passCode[0] && checkTwo == door._passCode[1] && checkThree == door._passCode[2] && checkFour == door._passCode[3])
            {
                door.IsLocked = false;
                door.IsUnlocked = true;
            }
        }
        if (door.IsUnlocked && door.IsClosed)
        {
            door.IsClosed = false;
            door.IsOpen = true;
        }
    }
    public static void CloseDoor(Door door)
    {
        if (door.IsOpen)
        {
            door.IsOpen = false;
            door.IsClosed = true;
            Console.WriteLine("*creeeeeeea-SLAM.");
        }
    }
    public void LockDoor()
    {
        if (IsOpen || (IsClosed && IsUnlocked))
            Console.WriteLine("The door is now locked.");
        IsOpen = false;
        IsClosed = true;
        IsLocked = true;
        IsUnlocked = false;
    }
}
//-----------------------------------------------------The Locked Door (end)
//-----------------------------------------------------The Card (start)
public class Card
{
    private CardColor _color;
    private CardRank _rank;
    public Card(CardColor color, CardRank rank)
    {
        _color = color;
        _rank = rank;
    }

    public CardRank GetRankType(Card card)
    {
        if (card._rank == CardRank.Cash || card._rank == CardRank.Modulo || card._rank == CardRank.Carrot || card._rank == CardRank.Ampersand)
            Console.WriteLine("This card is a face card.");
        else
            Console.WriteLine("This card is NOT a face card.");

        return card._rank;
    }
    public static string DrawCard(Card card)
    {
        return $"The {card._color} {card._rank}";
    }
}
public enum CardColor { Red = 1, Green = 2, Blue = 3, Yellow = 4 }; // an enumeration is best here - although we just made a color class, these are two different concepts
public enum CardRank
{
    One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7,
    Eight = 8, Nine = 9, Ten = 10, Cash = 11, Modulo = 12, Carrot = 13, Ampersand = 14
};
//-----------------------------------------------------The Card (end)
//-----------------------------------------------------The Color (start)
public class Color
{
    public byte RedChannel { get; init; } = 255;
    public byte GreenChannel { get; init; } = 255;
    public byte BlueChannel { get; init; } = 255;
    public string Name { get; init; } = "Unknown";

    public Color(string nameValue, byte redValue, byte greenValue, byte blueValue)
    {
        Name = nameValue;
        RedChannel = redValue;
        GreenChannel = greenValue;
        BlueChannel = blueValue;
    }

    public Color()
    {

    }

    public static string GetChannelValues(Color color)
    {
        return $"Color: {color.Name}\t\tRed Channel: {color.RedChannel}, Green Channel: {color.GreenChannel}, Blue Channel: {color.BlueChannel}";
    }

    public static Color White = new Color("White", 255, 255, 255);
    public static Color Black = new Color("Black", 0, 0, 0);
    public static Color Red = new Color("Red", 255, 0, 0);
    public static Color Orange = new Color("Orange", 255, 165, 0);
    public static Color Yellow = new Color("Yellow", 255, 255, 0);
    public static Color Green = new Color("Green", 0, 128, 0);
    public static Color Blue = new Color("Blue", 0, 0, 255);
    public static Color Purple = new Color("Purple", 128, 0, 128);
}
//-----------------------------------------------------The Color (end)
//-----------------------------------------------------The Point (start)
public class Point
{
    private (float, float) _origin = (0, 0);
    private float X { get; set; }
    private float Y { get; set; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
        (X, Y) = _origin;
    }

    public static string GetCoordinates(Point point)
    {
        return $"({point.X}, {point.Y})";
    }
    public (float, float) GetOrigin()
    {
        return _origin;
    }
}
//-----------------------------------------------------The Point (end)