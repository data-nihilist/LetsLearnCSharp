
Card smeagolHelpfulGuide = new("Smeagol, Helpful Guide", CardRank.Legendary, CardType.Creature, ManaColor.Black );
Console.WriteLine(smeagolHelpfulGuide.ViewCard());
Console.WriteLine(smeagolHelpfulGuide.ToString()); // using base class (object)'s method, ToString(): outputs 'Card'

Card swamp = new Land();
Console.WriteLine(swamp.ViewCard());

Card testLandCard = new Land();
Console.WriteLine(testLandCard.ViewCard());

if (testLandCard.GetType() == typeof(Land)) // true
{
    Console.WriteLine("We've got a Card type");
    if(testLandCard.GetType() == typeof(Land))
        Console.WriteLine("and it's a land!");
    else
        Console.WriteLine("...");
}

if (testLandCard.GetType() == typeof(Card)) // false
Console.WriteLine("This is a card");

if (testLandCard is Land) Console.WriteLine("testLandCard is a Land.");

Land? randomCard = smeagolHelpfulGuide as Land;
Console.WriteLine(randomCard?.ViewCard());

public class Card
{
    protected private string Name { get; init; } = "Unnamed";
    protected private CardType Type { get; init; }
    protected private CardRank Rank { get; init; }
    protected private ManaColor Colors { get; init; } = ManaColor.Generic;
    public Card()
    {

    }
    public Card(string cardName, CardRank cardRank, CardType cardType, ManaColor manaColors)
    {
        Name = cardName;
        Rank = cardRank;
        Type = cardType;
        Colors = manaColors;
    }


    public string ViewCard()
    {
        return $"{Name}\t\t{Colors}\n\n{Rank} {Type}";
    }
}

public class Land : Card
{
    public Land(string cardName, CardType cardType, CardRank cardRank, ManaColor manaColors) : base(cardName, cardRank, cardType, manaColors)
    {
        Name = cardName;
        Rank = cardRank;
        Type = CardType.Land;
        Colors = manaColors;
    }
    public Land()
    {
        Rank = CardRank.Basic;
        Type = CardType.Land;
    }
}
public enum CardType { Land, Creature, Sorcery, Instant, Artifact, Other };
//--------------------------------------------------------------------
public enum CardRank { Basic, Legendary, PlainsWalker, Other };
//--------------------------------------------------------------------
public enum CreatureTypeDecoration { Cleric, Wizard, Scout, Rogue, Ranger, Advisor, Horror, Other };
public enum ManaColor { Generic, White, Black, Red, Green, Blue, Mixed };
public enum KeyWord { Haste, Vigilance, Menace, Flying, Reach, Flash, Other };
public enum CreatureType
{
    Unspecified, Human, Elf, Halfling, Avatar, Nazgul, Orc, Goblin, Troll, Artifact, Token, Other
};