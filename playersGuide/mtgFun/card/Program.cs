Console.WriteLine("\t\t\t\tMTG Commander Playground\n\n");

public interface ICardService
{
    void DisplayCard();
}
public class Card : ICardService
{
    private readonly string Name;
    public Color[] ManaColors { get; set; }
    public int TotalCost { get; set; }

    public Card(string name, Color[] manaColors)
    {
        Name = name;
        ManaColors = manaColors;
    }

    public void DisplayCard()
    {
        Console.WriteLine($"_________________________________\n{Name}\t\t\n---------------------------------");
    }

}
public enum Color { Generic, Black, White, Blue, Green, Red }
public record ColorCost(Color Color, int Cost);
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