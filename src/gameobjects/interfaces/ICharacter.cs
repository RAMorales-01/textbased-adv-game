using Ranks;

namespace GameCharacters
{
    interface ICharacter
    {
        Rank WarriorRank { get; }
        string Name { get; }
        int HP { get; }
        int AttackValue { get; }
        int DefenseValue { get; }
    }
}