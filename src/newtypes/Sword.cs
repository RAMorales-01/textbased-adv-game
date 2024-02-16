using Ranks;

namespace GameEquipment
{
    internal class Sword : IEquipment
    {
        public string ID { get; protected set; } = string.Empty;
        public Rank EquipmentRank { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Info { get; protected set; } = string.Empty;
        public int Weight { get; protected set; }
        public int Price { get; protected set; }

        // Next property is exclusive to a Sword class equipment only.
        public int SwordDmg { get; protected set; }

        /// <summary>
        /// Constructor for class Sword, instance is determined by the parameter of enum type Rank.
        /// </summary>
        /// <param name="rank"></param>
        public Sword(Rank rank)
        {
            switch(rank)
            {
                case Rank.D:
                    this.ID = "SWORD-RD";
                    this.EquipmentRank = Rank.D;
                    this.Name = "Wooden Sword";
                    this.Info = "A sword used solely for training, might do some damage if the one wielding it hits very hard.";
                    this.Weight = 2;
                    this.Price = 10;
                    this.SwordDmg = 1;
                    break;

                case Rank.C:
                    this.ID = "SWORD-RC";
                    this.EquipmentRank = Rank.C;
                    this.Name = "Iron Sword";
                    this.Info = "A very common sword used across the kingdom, mostly used by city guards and common bandits.";
                    this.Weight = 8;
                    this.Price = 100;
                    this.SwordDmg = 4;
                    break;
                
                case Rank.B:
                    this.ID = "SWORD-RB";
                    this.EquipmentRank = Rank.B;
                    this.Name = "Steel Sword";
                    this.Info = "This sword is used by high-ranking Kinghts, not only is stronger than an iron sword but it is also lighter.";
                    this.Weight = 4;
                    this.Price = 1000;
                    this.SwordDmg = 6;
                    break;
                
                case Rank.A:
                    this.ID = "SWORD-RA";
                    this.EquipmentRank = Rank.A;
                    this.Name = "Mithril Sword";
                    this.Info = "Light and sharp sword made of the very hard to find mithril, it is said that only the most skilled dwarven smiths can work this metal.";
                    this.Weight = 2;
                    this.Price = 3000;
                    this.SwordDmg = 10;
                    break;
                
                case Rank.S:
                    this.ID = "SWORD-RS";
                    this.EquipmentRank = Rank.S;
                    this.Name = "Moonlight Sword";
                    this.Info = "Sword made of the mythical moon ore, if you tought mithril was rare this metal can only be found on the moon, forged by the gods themselves.";
                    this.Weight = 6;
                    this.Price = 8000;
                    this.SwordDmg = 15;
                    break;
                
                case Rank.Legendary:
                    this.ID = "SWORD-LEGEND";
                    this.EquipmentRank = Rank.Legendary;
                    this.Name = "Void-Forged Sword";
                    this.Info = "Sword forged by unknown means, said to come from far beyond the void that surrounds the moon and even the sun...";
                    this.Weight = 0;
                    this.Price = 20000;
                    this.SwordDmg = 35;
                    break;
            }
        }
    }
}