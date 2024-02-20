using System;
using System.Threading;
using Ranks;
using GameEquipment;

namespace GameCharacters
{
    internal class Player : ICharacter
    {
        private const int DefaultAttackValue = 5;
        private const int DefaultDefenseValue = 5;

        public Rank WarriorRank { get; internal set; } = Rank.D;
        public string Name { get; internal set; } = string.Empty;
        public int HP { get; internal set; } = 100;
        public int AttackValue { get; private set; } = DefaultAttackValue;
        public int DefenseValue { get; private set; } = DefaultDefenseValue;

        public Sword? EquipedSword { get; internal set; } = null;
        public Shield? EquipedShield { get; internal set; } = null;
        public Armor? EquipedArmor { get; internal set; } = null;

        public Player(string name, Sword sword, Shield shield, Armor armor)
        {
            this.Name = name;
            this.EquipedSword = sword;
            this.EquipedShield = shield;
            this.EquipedArmor = armor;
        }
    }
}