

Card smeagolHelpfulGuide = new("Smeagol, Helpful Guide", CardType.Creature, CardRank.Legendary);
Console.WriteLine(smeagolHelpfulGuide.ViewCard());


public class Card
{
    public string _cardName;
    public CardType _cardType;
    public CardRank _cardRank;

    public Card(string cardName, CardType cardType, CardRank cardRank)
    {
        _cardName = cardName;
        _cardType = cardType;
        _cardRank = cardRank;
    }


    public string ViewCard()
    {
        return $"{_cardName}\n\n{_cardRank} {_cardType}";
    }
}
public enum CardType { Land, Creature, Sorcery, Instant, Artifact, Other };
//--------------------------------------------------------------------
public enum CardRank { Standard, Legendary, PlainsWalker, Other };
//--------------------------------------------------------------------
public enum CreatureType { Human, Elf, Halfling, Avatar, Nazgul, Orc, Goblin, Troll, ArtifactCreature, Token, Other };
public enum CreatureTypeDecoration { Cleric, Wizard, Scout, Rogue, Ranger, Advisor, Horror, Other };
public enum ManaColor { White, Black, Red, Green, Blue };
public enum KeyWord { Haste, Vigilance, Menace, Flying, Reach, Flash, Other };