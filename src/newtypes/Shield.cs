using Ranks;

namespace GameEquipment
{
    internal class Shield : IEquipment
    {
        public string ID { get; protected set; } = string.Empty;
        public Rank EquipmentRank { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Info { get; protected set; } = string.Empty;
        public int Weight { get; protected set; }
        public int Price { get; protected set; }

        // Next property is exclusive to a Shield class equipment only.
        public int ShieldDef { get; protected set; }

        public Shield(Rank rank)
        {
            switch(rank)
            {
                case Rank.D:
                    this.ID = "SHIELD-RD";
                    this.EquipmentRank = Rank.D;
                    this.Name = "Bended Shield";
                    this.Info = "An used shield that has seen better days, you might still be able to use it to block..just don't use it to much.";
                    this.Weight = 4;
                    this.Price = 10;
                    this.ShieldDef = 1;
                    break;
                
                case Rank.C:
                    this.ID = "SHIELD-RC";
                    this.EquipmentRank = Rank.C;
                    this.Name = "Strong Shield";
                    this.Info = "Shield made of hard wood covered in leather of good quality, commonly use among all type of warriors.";
                    this.Weight = 6;
                    this.Price = 360;
                    this.ShieldDef = 4;
                    break;
                
                case Rank.B:
                    this.ID = "SHIELD-RB";
                    this.EquipmentRank = Rank.B;
                    this.Name = "Steel Shield";
                    this.Info = "An used shield that has seen better days, you might still be able to use it to block..just don't use it to much.";
                    this.Weight = 8;
                    this.Price = 1600;
                    this.ShieldDef = 8;
                    break;
                
                case Rank.A:
                    this.ID = "SHIELD-RA";
                    this.EquipmentRank = Rank.A;
                    this.Name = "Drake-Scale Shield";
                    this.Info = "Strong and light-weight made from a dragon scale, the scales of drgaon can resist any type of arrow or magic.";
                    this.Weight = 4;
                    this.Price = 4600;
                    this.ShieldDef = 10;
                    break;
                
                case Rank.S:
                    this.ID = "SHIELD-RS";
                    this.EquipmentRank = Rank.S;
                    this.Name = "Sunlight Shield";
                    this.Info = "Shield made of moon ore that has been bathed in sunrays for hundreds of years, used by Solaire the sunlight knight.";
                    this.Weight = 6;
                    this.Price = 6600;
                    this.ShieldDef = 15;
                    break;
                
                case Rank.Legendary:
                    this.ID = "SHIELD-LEGEND";
                    this.EquipmentRank = Rank.Legendary;
                    this.Name = "Hell-Walker Shield";
                    this.Info = "Shield made of pure hatred, created by thousands of souls of demons slain by a man who became doom itself.";
                    this.Weight = 10;
                    this.Price = 20600;
                    this.ShieldDef = 35;
                    break;
            }
        }
    }
}