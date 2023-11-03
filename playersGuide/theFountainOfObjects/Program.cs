ConsoleHelper.Write("Do you want to play a small, medium, or large game? ", ConsoleColor.White);

Console.ForegroundColor = ConsoleColor.Cyan;
FountainOfObjectsGame game = Console.ReadLine() switch
{
    "small" => CreateSmallGame(),
    "medium" => CreateMediumGame(),
    "large" => CreateLargeGame()
};

DisplayIntro();

game.Run();

//------------------------------------------------------------------------------------------Methods

void DisplayIntro()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("You enter the Cavern of Objects, a maze filled with dangerous pits, in search");
    Console.WriteLine("of the Fountain of Objects.");
    Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
    Console.WriteLine("You must navigate the Caverns with your other senses.");
    Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
    Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you");
    Console.WriteLine("enter a room with a pit, you will die.");
    Console.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport");
    Console.WriteLine("you to any other location in the caverns. You will be able to hear their growling and");
    Console.WriteLine("groaning in nearby rooms.");
    Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but they stink and can be");
    Console.WriteLine("smelled in nearby rooms.");
    Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the");
    Console.WriteLine("caverns but be warned: you have a limited supply.");
}

// for small game (4x4)
FountainOfObjectsGame CreateSmallGame()
{
    Map map = new Map(4, 4);
    Location start = new Location(0, 0);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Pit);

    Monster[] monsters = new Monster[]
    {
        new Maelstrom(new Location(2, 0)),
        new Amarok(new Location(0, 3))
    };

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}

// for medium game (6x6)
FountainOfObjectsGame CreateMediumGame()
{
    Map map = new Map(6, 6);
    Location start = new Location(5, 0);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(2, 4), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(3, 0), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Pit);

    Monster[] monsters = new Monster[]
    {
        new Maelstrom(new Location(2, 2)),
        new Amarok(new Location(5, 3)),
        new Amarok(new Location(1, 0))
    };

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}

// for large game (8x8)
FountainOfObjectsGame CreateLargeGame()
{
    Map map = new Map(8, 8);
    Location start = new Location(3, 7);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(4, 2), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(7, 0), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(4, 5), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(0, 5), RoomType.Pit);

    Monster[] monsters = new Monster[]
    {
        new Maelstrom(new Location(1, 3)),
        new Maelstrom(new Location(5, 5)),
        new Amarok(new Location(7, 5)),
        new Amarok(new Location(5, 2)),
        new Amarok(new Location(1, 1))
    };

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}

//------------------------------------------------------------------------------------------Types

public class FountainOfObjectsGame
{
    public Map Map { get; }

    public Player Player { get; }

    public Monster[] Monsters { get; }

    public bool IsFountainOn { get; set; }

    private readonly ISense[] _senses;

    public FountainOfObjectsGame(Map map, Player player, Monster[] monsters)
    {
        Map = map;
        Player = player;
        Monsters = monsters;

        _senses = new ISense[]
        {
            new LightInEntranceSense(),
            new FountainSense(),
            new PitBreezeSense(),
            new AmarokSense()
        };
    }

    public void Run()
    {

        while(!HasWon && Player.IsAlive)
        {
            DisplayStatus();
            ICommand command = GetCommand();
            command.Execute(this);

            foreach (Monster monster in Monsters)
            {
                if(monster.Location == Player.Location && monster.IsAlive)
                {
                    monster.Activate(this);
                }
            }

            if(CurrentRoom == RoomType.Pit)
            {
                Player.Kill("You have fallen into a pit and died.");
            }
        }

        if(HasWon)
        {
            ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.DarkGreen);
            ConsoleHelper.WriteLine("You win!", ConsoleColor.DarkGreen);
        }
        else
        {
            ConsoleHelper.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
            ConsoleHelper.WriteLine("You lost.", ConsoleColor.Red);
        }
    }


    private void DisplayStatus()
    {
        ConsoleHelper.WriteLine("--------------------------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}).", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You have {Player.ArrowsRemaining} arrows remaining.", ConsoleColor.Gray);

        foreach(ISense sense in _senses)
        {
            if(sense.CanSense(this))
            {
                sense.DisplaySense(this);
            }
        }
    }

    private ICommand GetCommand()
    {
        while(true)
        {
            ConsoleHelper.Write("What do you want to do?", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            if(input == "move north") return new MoveCommand(Direction.North);
            if(input == "move south") return new MoveCommand(Direction.South);
            if(input == "move east") return new MoveCommand(Direction.East);
            if(input == "move west") return new MoveCommand(Direction.West);
            if(input == "shoot north") return new ShootCommand(Direction.North);
            if(input == "shoot south") return new ShootCommand(Direction.South);
            if(input == "shoot east") return new ShootCommand(Direction.East);
            if(input == "shoot west") return new ShootCommand(Direction.West);
            if(input == "enable fountain") return new EnableFountainCommand();
            if(input == "help") return new HelpCommand();
            // more commands?

            ConsoleHelper.WriteLine($"I did not understand '{input}'.", ConsoleColor.Red);
        }
    }

    public bool HasWon => CurrentRoom == RoomType.Entrance && IsFountainOn;

    public RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);
}

public class Map
{

    private readonly RoomType[,] _rooms;

    public int Rows { get; }

    public int Columns { get; }

    public Map(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _rooms = new RoomType[rows, columns];
    }


    public RoomType GetRoomTypeAtLocation(Location location) => IsOnMap(location) ? _rooms[location.Row, location.Column] : RoomType.OffTheMap;

    public bool HasNeighborWithType(Location location, RoomType roomType)
    {
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column + 1)) == roomType) return true;
        return false;
    }

    public bool IsOnMap(Location location) =>
        location.Row >= 0 &&
        location.Row < _rooms.GetLength(0) &&
        location.Column >= 0 &&
        location.Column < _rooms.GetLength(1);
    
    public void SetRoomTypeAtLocation(Location location, RoomType type) => _rooms[location.Row, location.Column] = type;
}

public record Location(int Row, int Column);

public class Player
{
    public Location Location { get; set; }
    public bool IsAlive { get; private set; } = true;
    public string CauseOfDeath { get; private set; } = "";
    public int ArrowsRemaining { get; set; } = 5;
    public Player(Location start) => Location = start;
    public void Kill(string cause)
    {
        IsAlive = false;
        CauseOfDeath = cause;
    }
}

public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;
    public Monster(Location start) => Location = start;

    public abstract void Activate(FountainOfObjectsGame game);
}

public class Maelstrom : Monster
{
    public Maelstrom(Location start) : base(start) { }
    public override void Activate(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You have encountered a maelstrom and have been swept away to another room!", ConsoleColor.Magenta);
        game.Player.Location = Clamp(new Location(game.Player.Location.Row - 1, game.Player.Location.Column + 2), game.Map.Rows, game.Map.Columns);
        Location = Clamp(new Location(Location.Row + 1, Location.Column - 2), game.Map.Rows, game.Map.Columns);
    }

    private Location Clamp(Location location, int totalRows, int totalColumns)
    {
        int row = location.Row;
        if(row < 0)
        {
            row = 0;
        }
        if(row >= totalRows)
        {
            row = totalRows - 1;
        }

        int column = location.Column;
        if(column < 0)
        {
            column = 0;
        }
        if(column >= totalColumns)
        {
            column = totalColumns - 1;
        }

        return new Location(row, column);
    }
}

public class Amarok : Monster
{
    public Amarok(Location start) : base(start) { }
    public override void Activate(FountainOfObjectsGame game) => game.Player.Kill("You have encountered an amarok and have died.");
}

public interface ICommand
{
    void Execute(FountainOfObjectsGame game);
}

public class HelpCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("help", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Displays this help information.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("enable fountain", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Turns on the Fountain of Objects if you are in the fountain room, or does nothing if you are not.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move north", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Moves to the room directly north of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move south", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Moves to the room directly south of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move east", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Moves to the room directly east of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move west", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Moves to the room directly west of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot north", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Fires an arrow into the room to the north, killing any monster in that room.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot south", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Fires an arrow into the room to the south, killing any monster in that room.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot east", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Fires an arrow into the room to the east, killing any monster in that room.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot west", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Fires an arrow into the room to the west, killing any monster in that room.", ConsoleColor.Gray);
    }
}

public class MoveCommand : ICommand
{
    public Direction Direction { get; }
    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(FountainOfObjectsGame game)
    {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1)
        };

        if (game.Map.IsOnMap(newLocation))
        {
            game.Player.Location = newLocation;
        }
        else
        {
            ConsoleHelper.WriteLine("There is a wall there.", ConsoleColor.Red);
        }
    }
}

public class ShootCommand : ICommand
{
    public Direction Direction { get; }
    public ShootCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(FountainOfObjectsGame game)
    {
        if (game.Player.ArrowsRemaining == 0)
        {
            ConsoleHelper.WriteLine("You don't have any arrows left!", ConsoleColor.Red);
            return;
        }

        Location currentLocation = game.Player.Location;
        Location targetLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1)
        };

        bool foundSomething = false;
        foreach (Monster monster in game.Monsters)
        {
            if(monster.Location == targetLocation && monster.IsAlive)
            {
                monster.IsAlive = false;
                foundSomething = true;
            }
        }

        if(foundSomething)
        {
            ConsoleHelper.WriteLine("YOu fire an arrow and hit soemthing!", ConsoleColor.Green);
        }
        else
        {
            ConsoleHelper.WriteLine("You fire an arrow and missed.", ConsoleColor.Magenta);
        }

        game.Player.ArrowsRemaining--;
    }
}

public class EnableFountainCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        if(game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain)
        {
            game.IsFountainOn = true;
        }
        else
        {
            ConsoleHelper.WriteLine("The fountain is not in this room. There was no effect.", ConsoleColor.Red);
        }
    }
}

public interface ISense
{
    bool CanSense(FountainOfObjectsGame game);
    void DisplaySense(FountainOfObjectsGame game);
}

public class LightInEntranceSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        return game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance;
    }

    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You see the light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
    }
}

public class FountainSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        return game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain;
    }

    public void DisplaySense(FountainOfObjectsGame game)
    {
        if(game.IsFountainOn)
        {
            ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.DarkCyan);
        }
        else
        {
            ConsoleHelper.WriteLine("you hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.DarkCyan);
        }
    }
}

public class PitBreezeSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        return game.Map.HasNeighborWithType(game.Player.Location, RoomType.Pit);
    }

    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.DarkGray);
    }
}

public class MaelstromSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        foreach (Monster monster in game.Monsters)
        {
            if(monster is Maelstrom && monster.IsAlive)
            {
                int rowDifference = Math.Abs(monster.Location.Row - game.Player.Location.Row);
                int columnDifference = Math.Abs(monster.Location.Column - game.Player.Location.Column);

                if(rowDifference <= 1 && columnDifference <= 1)
                {
                    return true;
                }

            }
        }
        return false;
    }
    
    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You hear the growling and groaning of a maelstrom nearby.", ConsoleColor.DarkGray);
    }
}

public class AmarokSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        foreach (Monster monster in game.Monsters)
        {
            if(monster is Amarok && monster.IsAlive)
            {
                int rowDifference = Math.Abs(monster.Location.Row - game.Player.Location.Row);
                int columnDifference = Math.Abs(monster.Location.Column - game.Player.Location.Column);

                if(rowDifference <= 1 && columnDifference <= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You smell the stench of an amarok nearby..", ConsoleColor.DarkRed);
    }
}

public static class ConsoleHelper
{
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
}

public enum RoomType { Normal, Entrance, Fountain, Pit, OffTheMap }
public enum Direction { North, South, West, East }