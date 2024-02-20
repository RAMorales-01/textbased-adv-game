using Ranks;

namespace GameEquipment
{
    internal class Armor : IEquipment
    {
        public string ID { get; protected set; } = string.Empty;
        public Rank EquipmentRank { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Info { get; protected set; } = string.Empty;
        public int Weight { get; protected set; }
        public int Price { get; protected set; }

        // Next property is exclusive for Armor class equipment only.
        public int ArmorDef { get; protected set; }

        /// <summary>
        /// Constructor for class Armor, instance is determined by the parameter of enum type Rank.
        /// </summary>
        /// <param name="rank"></param>
        public Armor(Rank rank)
        {
            switch(rank)
            {
                case Rank.Default:
                    this.ID = "ARMOR-DEFAULT";
                    this.EquipmentRank = Rank.Default;
                    this.Name = "Old Cloth";
                    this.Info = "Just a old and stinky cloth...you might want to change it as soon as posible.";
                    this.Weight = 4;
                    this.Price = 10;
                    this.ArmorDef = 1;
                    break;

                case Rank.D:
                    this.ID = "ARMOR-RD";
                    this.EquipmentRank = Rank.D;
                    this.Name = "Rusted Armor";
                    this.Info = "An old armor in very bad shape, it seems its previous owner didn't gave any type of maintenance.";
                    this.Weight = 6;
                    this.Price = 200;
                    this.ArmorDef = 4;
                    break;
                
                case Rank.C:
                    this.ID = "ARMOR-RC";
                    this.EquipmentRank = Rank.C;
                    this.Name = "Leather Armor";
                    this.Info = "Armor made of hard leather, widely used among the common folk of all walks of life.";
                    this.Weight = 8;
                    this.Price = 660;
                    this.ArmorDef = 10;
                    break;
                
                case Rank.B:
                    this.ID = "ARMOR-RB";
                    this.EquipmentRank = Rank.B;
                    this.Name = "Steel Armor";
                    this.Info = "Used by high-ranking knights, very lightweight and offers good protection.";
                    this.Weight = 14;
                    this.Price = 2860;
                    this.ArmorDef = 18;
                    break;
                
                case Rank.A:
                    this.ID = "ARMOR-RA";
                    this.EquipmentRank = Rank.A;
                    this.Name = "Dragonbone Armor";
                    this.Info = "Made of the bones of a high dragon and because of this, the armor can resist high temperatures without loosing its shine and luster.";
                    this.Weight = 22;
                    this.Price = 6460;
                    this.ArmorDef = 22;
                    break;
                
                case Rank.S:
                    this.ID = "ARMOR-RS";
                    this.EquipmentRank = Rank.S;
                    this.Name = "Stardust Armor";
                    this.Info = "Armor forged with the remains of dying star, said to be the armor used by the knight at the service of the gods.";
                    this.Weight = 30;
                    this.Price = 8800;
                    this.ArmorDef = 25;
                    break;
                
                case Rank.Legendary:
                    this.ID = "ARMOR-LEGEND";
                    this.EquipmentRank = Rank.Legendary;
                    this.Name = "Death Conquering Armor";
                    this.Info = "Armor said to contain the soul of the phoenix, this armor can defy death itself.";
                    this.Weight = 20;
                    this.Price = 44400;
                    this.ArmorDef = 35;
                    break;
            }
        }
    }
}