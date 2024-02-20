using Ranks;

namespace GameEquipment 
{
    /* Must have properties of each new type piece of equipment added to the game from now on. */
    interface IEquipment
    {
        string ID { get; }
        Rank EquipmentRank { get; }
        string Name { get; }
        string Info { get; }
        int Weight { get; }
        int Price { get; }
    }
}